
import numpy as np
import torch
import torch.nn as nn
import torch.optim as optim
from mlagents_envs.environment import UnityEnvironment
from mlagents_envs.base_env import ActionTuple
from mlagents_envs.side_channel.engine_configuration_channel import EngineConfigurationChannel
from torch.distributions import Normal
from collections import deque
from collections import defaultdict

# 0. 하이퍼파라미터 설정
LEARNING_RATE = 0.0003
GAMMA = 0.99
LAMBDA = 0.95
EPS_CLIP = 0.2
K_EPOCHS = 3
BATCH_SIZE = 64
TRAIN_HORIZON = 2048
TOTAL_ITERATIONS = 1000  # 학습 반복 횟수

# 1. PPO 네트워크 정의 (Actor-Critic)
class PPO(nn.Module):
    def __init__(self, state_dim, action_dim):
        super(PPO, self).__init__()
        
        # Actor Network: 상태 -> 행동 (평균)
        self.actor = nn.Sequential(
            nn.Linear(state_dim, 64),
            nn.Tanh(),
            nn.Linear(64, 64),
            nn.Tanh(),
            nn.Linear(64, action_dim)
        )
        self.log_std = nn.Parameter(torch.zeros(1, action_dim)) # 표준편차는 학습 가능한 파라미터

        # Critic Network: 상태 -> 가치
        self.critic = nn.Sequential(
            nn.Linear(state_dim, 64),
            nn.Tanh(),
            nn.Linear(64, 64),
            nn.Tanh(),
            nn.Linear(64, 1)
        )

    def forward(self):
        raise NotImplementedError
    
    def get_action_and_value(self, state, action=None):
        mean = self.actor(state)
        std = self.log_std.exp().expand_as(mean)
        dist = Normal(mean, std)
        
        if action is None:
            action = dist.sample()
        
        action_log_prob = dist.log_prob(action).sum(axis=-1, keepdim=True)
        entropy = dist.entropy().sum(axis=-1, keepdim=True)
        value = self.critic(state)
        
        return action, action_log_prob, entropy, value

# 2. 메인 학습 루프
def main():
    print("Unity 환경에 연결 중...")
    
    # 엔진 설정 채널 (TimeScale)
    engine_config_channel = EngineConfigurationChannel()
    env = UnityEnvironment(file_name=None, base_port=5004, side_channels=[engine_config_channel])
    
    try:
        env.reset()
        engine_config_channel.set_configuration_parameters(time_scale=20.0)

        behavior_name = list(env.behavior_specs)[0]
        spec = env.behavior_specs[behavior_name]
        
        obs_dim = spec.observation_specs[0].shape[0]
        action_dim = spec.action_spec.continuous_size
        
        print(f"Observation Dimension: {obs_dim}")
        print(f"Action Dimension: {action_dim}")

        model = PPO(obs_dim, action_dim)
        optimizer = optim.Adam(model.parameters(), lr=LEARNING_RATE)
        
        # --- ONNX Export Helper Function (Unity ML-Agents 호환 포맷) ---
        def save_onnx_model(save_path):
            model.eval()
            
            class FullExport(nn.Module):
                def __init__(self, actor, action_dim):
                    super(FullExport, self).__init__()
                    self.actor = actor
                    self.action_dim = action_dim
                    
                    # 상수 텐서들 (ML-Agents 스펙 - Type Matching을 위해 Float32 사용)
                    self.register_buffer('version_number', torch.tensor([3], dtype=torch.float32))
                    self.register_buffer('memory_size', torch.tensor([0], dtype=torch.float32))
                    self.register_buffer('continuous_action_output_shape', torch.tensor([action_dim], dtype=torch.float32))
                    
                def forward(self, obs_0):
                    # Actor Inference (Mean Action)
                    continuous_actions = self.actor(obs_0)
                    
                    # Deterministic Action도 동일하게 Mean 사용
                    deterministic_continuous_actions = continuous_actions
                    
                    return (
                        self.version_number,
                        self.memory_size,
                        continuous_actions,
                        self.continuous_action_output_shape,
                        deterministic_continuous_actions
                    )
            
            export_module = FullExport(model.actor, action_dim)
            dummy_input = torch.randn(1, obs_dim)
            
            # 출력 이름 순서는 Unity ML-Agents가 기대하는 순서와 같거나 이름으로 매핑됨
            input_names = ['obs_0']
            output_names = [
                'version_number',
                'memory_size',
                'continuous_actions',
                'continuous_action_output_shape',
                'deterministic_continuous_actions'
            ]
            
            torch.onnx.export(
                export_module,
                dummy_input,
                save_path,
                export_params=True,
                opset_version=9,
                do_constant_folding=True,
                input_names=input_names,
                output_names=output_names,
                dynamic_axes={
                    'obs_0': {0: 'batch'},
                    'continuous_actions': {0: 'batch'},
                    'deterministic_continuous_actions': {0: 'batch'}
                }
            )
            model.train()
            print(f"Saved Unity-compatible ONNX model to {save_path}")
        # -------------------------------------------------------------

        print("학습 시작! (Multi-Agent & Best Model 저장 지원)")
        
        score_history = deque(maxlen=100)
        current_ep_reward = defaultdict(float)
        best_score = -float('inf')

        for iteration in range(TOTAL_ITERATIONS):
            env.reset()
            trajectories = {} 
            b_states, b_actions, b_logprobs, b_advantages, b_returns = [], [], [], [], []

            decision_steps, terminal_steps = env.get_steps(behavior_name)
            
            for t in range(TRAIN_HORIZON):
                if len(decision_steps) > 0:
                    obs = decision_steps.obs[0]
                    curr_states = torch.FloatTensor(obs)
                    
                    with torch.no_grad():
                        actions, log_probs, _, values = model.get_action_and_value(curr_states)
                    
                    actions_np = actions.numpy()
                    env.set_actions(behavior_name, ActionTuple(continuous=actions_np))
                    
                    for i, agent_id in enumerate(decision_steps.agent_id):
                        # Reward Tracking
                        r = decision_steps[agent_id].reward
                        current_ep_reward[agent_id] += r
                        
                        if agent_id not in trajectories: trajectories[agent_id] = []
                        if len(trajectories[agent_id]) > 0:
                            trajectories[agent_id][-1][4] = r
                        
                        trajectories[agent_id].append([
                            curr_states[i], actions[i], log_probs[i], values[i], 0.0
                        ])

                env.step()
                next_decision_steps, next_terminal_steps = env.get_steps(behavior_name)
                
                # Terminal Steps
                for agent_id in next_terminal_steps.agent_id:
                    final_reward = next_terminal_steps[agent_id].reward
                    
                    # Reward Tracking (End of Episode)
                    current_ep_reward[agent_id] += final_reward
                    score_history.append(current_ep_reward[agent_id])
                    current_ep_reward[agent_id] = 0.0 # Reset
                    
                    if agent_id in trajectories and len(trajectories[agent_id]) > 0:
                        trajectories[agent_id][-1][4] = final_reward
                        
                        traj = trajectories[agent_id]
                        states, acts, lprobs, vals, rews = zip(*traj)
                        
                        vals = torch.stack(vals).squeeze()
                        if vals.dim() == 0: vals = vals.unsqueeze(0)
                        
                        advs = []
                        gae = 0
                        next_val = 0 
                        
                        for i in reversed(range(len(rews))):
                            delta = rews[i] + GAMMA * next_val - vals[i]
                            gae = delta + GAMMA * LAMBDA * gae
                            advs.insert(0, gae)
                            next_val = vals[i]
                        
                        b_states.extend(states)
                        b_actions.extend(acts)
                        b_logprobs.extend(lprobs)
                        b_advantages.extend(advs)
                        b_returns.extend([a + v.item() for a, v in zip(advs, vals)])
                        
                        trajectories[agent_id] = []
                
                decision_steps = next_decision_steps
                terminal_steps = next_terminal_steps

            if len(b_states) > BATCH_SIZE:
                states_t = torch.stack(b_states)
                actions_t = torch.stack(b_actions)
                logprobs_t = torch.stack(b_logprobs)
                advantages_t = torch.tensor(b_advantages)
                returns_t = torch.tensor(b_returns)
                
                # Normalize Advantages
                advantages_t = (advantages_t - advantages_t.mean()) / (advantages_t.std() + 1e-8)
                
                # Epoch Check
                for _ in range(K_EPOCHS):
                    indices = torch.randperm(len(states_t))
                    for i in range(0, len(states_t), BATCH_SIZE):
                        idx = indices[i:i+BATCH_SIZE]
                        if len(idx) < BATCH_SIZE: continue
                        
                        mb_states = states_t[idx]
                        mb_actions = actions_t[idx]
                        mb_logprobs = logprobs_t[idx]
                        mb_advs = advantages_t[idx]
                        mb_rets = returns_t[idx]
                        
                        _, new_logprobs, entropy, new_vals = model.get_action_and_value(mb_states, mb_actions)
                        
                        ratio = (new_logprobs - mb_logprobs).exp()
                        surr1 = ratio * mb_advs
                        surr2 = torch.clamp(ratio, 1.0 - EPS_CLIP, 1.0 + EPS_CLIP) * mb_advs
                        
                        actor_loss = -torch.min(surr1, surr2).mean()
                        critic_loss = 0.5 * ((new_vals.squeeze() - mb_rets) ** 2).mean()
                        entropy_loss = -0.01 * entropy.mean()
                        
                        loss = actor_loss + critic_loss + entropy_loss
                        
                        optimizer.zero_grad()
                        loss.backward()
                        optimizer.step()
                
                # --- Check Improvement & Save ---
                avg_score = sum(score_history) / len(score_history) if len(score_history) > 0 else 0
                
                if len(score_history) >= 10 and avg_score > best_score:
                    best_score = avg_score
                    save_onnx_model(f"RollerBall_PPO_Best.onnx")
                    print(f"Iteration {iteration+1} - New Best Score: {avg_score:.2f} (Saved to RollerBall_PPO_Best.onnx)")
                else:
                    print(f"Iteration {iteration+1} - Score: {avg_score:.2f} (Best: {best_score:.2f})")
            else:
                print(f"Iteration {iteration+1} - 데이터 수집 중... ({len(b_states)} steps)")

        print("최종 모델 저장 중...")
        save_onnx_model("RollerBall_PPO_Final.onnx")
        print("완료.")
    
    except KeyboardInterrupt:
        print("\n학습 중단됨 (KeyboardInterrupt).")
    finally:
        env.close()
        print("Unity 환경 연결 해제됨.")

if __name__ == "__main__":
    main()
