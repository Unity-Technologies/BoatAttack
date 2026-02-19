#!/usr/bin/env python3
"""Training Loop for Unity RL with PPO"""

import os
import time
import argparse
import numpy as np
from datetime import datetime

try:
    import matplotlib
    matplotlib.use('Agg')
    import matplotlib.pyplot as plt
    HAS_MATPLOTLIB = True
except ImportError:
    HAS_MATPLOTLIB = False

from unity_client import UnityEnv
from ppo_agent import PPOAgent


def train(args):
    print("=" * 60)
    print(f"  PPO Training for Unity BoatAttack")
    print(f"  Host: {args.host}:{args.port}")
    print(f"  Episodes: {args.episodes}")
    print(f"  Max Steps: {args.max_steps}")
    print(f"  Update Interval: {args.update_interval} steps")
    print("=" * 60)

    # Environment
    env = UnityEnv(host=args.host, port=args.port)
    if not env.connect():
        print("Failed to connect to Unity. Make sure Unity is running.")
        return

    # Agent
    obs_dim = env.observation_space_dim
    action_dim = env.action_space_dim
    agent = PPOAgent(
        obs_dim=obs_dim,
        action_dim=action_dim,
        lr=args.lr,
        gamma=args.gamma,
        lambda_=args.lam
    )

    if args.load_model and os.path.exists(args.load_model):
        agent.load(args.load_model)
        print(f"Loaded model from {args.load_model}")

    # Logging
    os.makedirs(args.save_dir, exist_ok=True)
    episode_rewards = []
    episode_lengths = []
    losses = []
    best_reward = -float('inf')
    total_steps = 0

    try:
        for episode in range(1, args.episodes + 1):
            obs = env.reset()
            episode_reward = 0.0
            step = 0

            for step in range(1, args.max_steps + 1):
                action = agent.select_action(obs)
                next_obs, reward, done, info = env.step(action)
                agent.store_transition(reward, done)

                episode_reward += reward
                total_steps += 1
                obs = next_obs

                # Update policy
                if total_steps % args.update_interval == 0:
                    loss_info = agent.update(
                        epochs=args.ppo_epochs,
                        batch_size=args.batch_size
                    )
                    losses.append(loss_info['loss'])

                if done:
                    break

                time.sleep(args.step_delay)

            episode_rewards.append(episode_reward)
            episode_lengths.append(step)

            # Running average
            recent = episode_rewards[-100:]
            avg_reward = np.mean(recent)

            print(
                f"Episode {episode:4d} | "
                f"Reward: {episode_reward:8.2f} | "
                f"Avg(100): {avg_reward:8.2f} | "
                f"Steps: {step:4d} | "
                f"Total: {total_steps}"
            )

            # Save best model
            if avg_reward > best_reward and episode >= 10:
                best_reward = avg_reward
                save_path = os.path.join(args.save_dir, "best_model.pt")
                agent.save(save_path)

            # Periodic checkpoint
            if episode % args.save_interval == 0:
                save_path = os.path.join(args.save_dir, f"checkpoint_{episode}.pt")
                agent.save(save_path)

                if HAS_MATPLOTLIB:
                    plot_training(episode_rewards, losses, args.save_dir)

    except KeyboardInterrupt:
        print("\nTraining interrupted by user")
    finally:
        # Save final model
        save_path = os.path.join(args.save_dir, "final_model.pt")
        agent.save(save_path)

        if HAS_MATPLOTLIB and len(episode_rewards) > 0:
            plot_training(episode_rewards, losses, args.save_dir)

        env.close()
        print("Training complete!")
        print(f"  Total episodes: {len(episode_rewards)}")
        print(f"  Total steps: {total_steps}")
        if episode_rewards:
            print(f"  Best avg reward: {best_reward:.2f}")
            print(f"  Final avg reward: {np.mean(episode_rewards[-100:]):.2f}")


def plot_training(rewards, losses, save_dir):
    fig, axes = plt.subplots(2, 1, figsize=(12, 8))

    # Reward curve
    axes[0].plot(rewards, alpha=0.3, color='blue', label='Episode Reward')
    if len(rewards) >= 10:
        window = min(100, len(rewards))
        avg = np.convolve(rewards, np.ones(window)/window, mode='valid')
        axes[0].plot(range(window-1, len(rewards)), avg, color='red', label=f'Avg({window})')
    axes[0].set_xlabel('Episode')
    axes[0].set_ylabel('Reward')
    axes[0].set_title('Training Reward')
    axes[0].legend()
    axes[0].grid(True, alpha=0.3)

    # Loss curve
    if losses:
        axes[1].plot(losses, color='green', alpha=0.7)
        axes[1].set_xlabel('Update')
        axes[1].set_ylabel('Loss')
        axes[1].set_title('PPO Loss')
        axes[1].grid(True, alpha=0.3)

    plt.tight_layout()
    plt.savefig(os.path.join(save_dir, 'training_curve.png'), dpi=150)
    plt.close()


def main():
    parser = argparse.ArgumentParser(description='PPO Training for Unity BoatAttack')
    parser.add_argument('--host', type=str, default='localhost')
    parser.add_argument('--port', type=int, default=9876)
    parser.add_argument('--episodes', type=int, default=5000)
    parser.add_argument('--max-steps', type=int, default=1000)
    parser.add_argument('--update-interval', type=int, default=2048)
    parser.add_argument('--ppo-epochs', type=int, default=10)
    parser.add_argument('--batch-size', type=int, default=64)
    parser.add_argument('--lr', type=float, default=3e-4)
    parser.add_argument('--gamma', type=float, default=0.99)
    parser.add_argument('--lam', type=float, default=0.95)
    parser.add_argument('--step-delay', type=float, default=0.0,
                        help='Delay between steps in seconds (0 for max speed)')
    parser.add_argument('--save-dir', type=str, default='checkpoints')
    parser.add_argument('--save-interval', type=int, default=100)
    parser.add_argument('--load-model', type=str, default=None)
    args = parser.parse_args()
    train(args)


if __name__ == '__main__':
    main()
