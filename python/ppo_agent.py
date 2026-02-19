#!/usr/bin/env python3
"""Simple PPO Agent for Unity RL"""

import torch
import torch.nn as nn
import torch.optim as optim
import numpy as np
from torch.distributions import Normal


class ActorCritic(nn.Module):
    def __init__(self, obs_dim, action_dim, hidden_dim=256):
        super(ActorCritic, self).__init__()
        self.shared = nn.Sequential(
            nn.Linear(obs_dim, hidden_dim),
            nn.ReLU(),
            nn.Linear(hidden_dim, hidden_dim),
            nn.ReLU()
        )
        self.actor_mean = nn.Linear(hidden_dim, action_dim)
        self.actor_logstd = nn.Parameter(torch.zeros(action_dim))
        self.critic = nn.Linear(hidden_dim, 1)

    def forward(self, state):
        features = self.shared(state)
        action_mean = torch.tanh(self.actor_mean(features))
        action_std = torch.exp(self.actor_logstd)
        value = self.critic(features)
        return action_mean, action_std, value

    def get_action(self, state, deterministic=False):
        state = torch.FloatTensor(state).unsqueeze(0)
        with torch.no_grad():
            action_mean, action_std, value = self.forward(state)
        if deterministic:
            action = action_mean
        else:
            dist = Normal(action_mean, action_std)
            action = dist.sample()
        action = torch.clamp(action, -1.0, 1.0)
        return action.squeeze(0).numpy(), value.item()


class PPOAgent:
    def __init__(self, obs_dim, action_dim, lr=3e-4, gamma=0.99, lambda_=0.95):
        self.actor_critic = ActorCritic(obs_dim, action_dim)
        self.optimizer = optim.Adam(self.actor_critic.parameters(), lr=lr)
        self.gamma = gamma
        self.lambda_ = lambda_
        self.states = []
        self.actions = []
        self.rewards = []
        self.values = []
        self.dones = []

    def select_action(self, state):
        action, value = self.actor_critic.get_action(state)
        self.states.append(state)
        self.actions.append(action)
        self.values.append(value)
        return action

    def store_transition(self, reward, done):
        self.rewards.append(reward)
        self.dones.append(done)

    def update(self, epochs=10, batch_size=64):
        if len(self.states) == 0:
            return {'loss': 0.0}

        returns, advantages = self._compute_gae()

        states = torch.FloatTensor(np.array(self.states))
        actions = torch.FloatTensor(np.array(self.actions))
        returns = torch.FloatTensor(returns)
        advantages = torch.FloatTensor(advantages)
        advantages = (advantages - advantages.mean()) / (advantages.std() + 1e-8)

        with torch.no_grad():
            old_action_mean, old_action_std, _ = self.actor_critic(states)
            old_dist = Normal(old_action_mean, old_action_std)
            old_log_probs = old_dist.log_prob(actions).sum(dim=1)

        total_loss = 0.0
        for epoch in range(epochs):
            action_mean, action_std, values = self.actor_critic(states)
            dist = Normal(action_mean, action_std)
            log_probs = dist.log_prob(actions).sum(dim=1)
            entropy = dist.entropy().mean()

            ratio = torch.exp(log_probs - old_log_probs)
            surr1 = ratio * advantages
            surr2 = torch.clamp(ratio, 0.8, 1.2) * advantages
            actor_loss = -torch.min(surr1, surr2).mean()
            critic_loss = nn.MSELoss()(values.squeeze(), returns)

            loss = actor_loss + 0.5 * critic_loss - 0.01 * entropy

            self.optimizer.zero_grad()
            loss.backward()
            nn.utils.clip_grad_norm_(self.actor_critic.parameters(), 0.5)
            self.optimizer.step()

            total_loss += loss.item()

        self.clear_buffer()
        return {
            'loss': total_loss / epochs,
            'actor_loss': actor_loss.item(),
            'critic_loss': critic_loss.item()
        }

    def _compute_gae(self):
        returns = []
        advantages = []
        gae = 0
        next_value = 0
        for t in reversed(range(len(self.rewards))):
            delta = self.rewards[t] + self.gamma * next_value * (1 - self.dones[t]) - self.values[t]
            gae = delta + self.gamma * self.lambda_ * (1 - self.dones[t]) * gae
            advantages.insert(0, gae)
            returns.insert(0, gae + self.values[t])
            next_value = self.values[t]
        return returns, advantages

    def clear_buffer(self):
        self.states = []
        self.actions = []
        self.rewards = []
        self.values = []
        self.dones = []

    def save(self, path):
        torch.save({
            'model_state_dict': self.actor_critic.state_dict(),
            'optimizer_state_dict': self.optimizer.state_dict()
        }, path)
        print(f"Model saved to {path}")

    def load(self, path):
        checkpoint = torch.load(path)
        self.actor_critic.load_state_dict(checkpoint['model_state_dict'])
        self.optimizer.load_state_dict(checkpoint['optimizer_state_dict'])
        print(f"Model loaded from {path}")
