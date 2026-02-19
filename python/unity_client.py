#!/usr/bin/env python3
"""Unity Socket Client for RL Communication"""

import socket
import json
import time
import numpy as np
from typing import Dict, Tuple, Optional


class UnityClient:
    def __init__(self, host='localhost', port=9876):
        self.host = host
        self.port = port
        self.socket = None
        self.buffer = ""

    def connect(self, timeout=10):
        print(f"[UnityClient] Connecting to Unity at {self.host}:{self.port}...")
        self.socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.socket.settimeout(timeout)
        try:
            self.socket.connect((self.host, self.port))
            print("[UnityClient] Connected!")
            return True
        except Exception as e:
            print(f"[UnityClient] Connection failed: {e}")
            return False

    def disconnect(self):
        if self.socket:
            self.socket.close()
            print("[UnityClient] Disconnected")

    def send_action(self, throttle: float, steering: float, fire: bool = False):
        action = {
            'throttle': float(np.clip(throttle, 0.0, 1.0)),
            'steering': float(np.clip(steering, -1.0, 1.0)),
            'fire': bool(fire)
        }
        message = json.dumps(action) + "\n"
        try:
            self.socket.sendall(message.encode('utf-8'))
        except Exception as e:
            print(f"[UnityClient] Send error: {e}")

    def receive_observation(self) -> Optional[Dict]:
        try:
            data = self.socket.recv(4096).decode('utf-8')
            if not data:
                return None

            self.buffer += data
            if '\n' in self.buffer:
                lines = self.buffer.split('\n')
                self.buffer = lines[-1]
                for line in reversed(lines[:-1]):
                    if line.strip():
                        try:
                            return json.loads(line)
                        except json.JSONDecodeError:
                            continue
            return None
        except socket.timeout:
            return None
        except Exception as e:
            print(f"[UnityClient] Receive error: {e}")
            return None

    def reset(self):
        reset_msg = json.dumps({'command': 'reset'}) + "\n"
        try:
            self.socket.sendall(reset_msg.encode('utf-8'))
        except Exception as e:
            print(f"[UnityClient] Reset error: {e}")


class UnityEnv:
    """Gymnasium-style Unity environment wrapper"""

    def __init__(self, host='localhost', port=9876):
        self.client = UnityClient(host, port)
        self.observation_space_dim = 20
        self.action_space_dim = 2
        self.current_obs = None

    def connect(self):
        return self.client.connect()

    def reset(self) -> np.ndarray:
        self.client.reset()
        time.sleep(0.5)
        obs = None
        for _ in range(10):
            obs = self.client.receive_observation()
            if obs is not None:
                break
            time.sleep(0.1)
        if obs is None:
            return np.zeros(self.observation_space_dim)
        self.current_obs = obs
        return self._parse_observation(obs)

    def step(self, action: np.ndarray) -> Tuple[np.ndarray, float, bool, Dict]:
        throttle = float(action[0])
        steering = float(action[1]) if len(action) > 1 else 0.0
        self.client.send_action(throttle, steering, fire=False)

        obs = self.client.receive_observation()
        if obs is None:
            obs = self.current_obs
        self.current_obs = obs

        state = self._parse_observation(obs)
        reward = self._calculate_reward(obs)
        done = obs.get('done', False) if obs else False
        info = {'raw_obs': obs}
        return state, reward, done, info

    def _parse_observation(self, obs: Dict) -> np.ndarray:
        if obs is None:
            return np.zeros(self.observation_space_dim)
        state = []
        state.extend(obs.get('position', [0, 0, 0]))
        state.extend(obs.get('velocity', [0, 0, 0]))
        state.extend(obs.get('rotation', [0, 0, 0]))
        state.extend(obs.get('radarData', [1.0] * 8))
        state.append(obs.get('health', 100.0) / 100.0)
        state.append(obs.get('ammo', 50.0) / 100.0)
        state.append(obs.get('stepCount', 0) / 1000.0)
        return np.array(state, dtype=np.float32)

    def _calculate_reward(self, obs: Dict) -> float:
        if obs is None:
            return 0.0
        reward = 0.0
        velocity = obs.get('velocity', [0, 0, 0])
        reward += velocity[2] * 0.1
        if not obs.get('done', False):
            reward += 0.01
        return reward

    def close(self):
        self.client.disconnect()


def main():
    env = UnityEnv(host='localhost', port=9876)
    if not env.connect():
        return
    try:
        obs = env.reset()
        for step in range(100):
            action = np.random.uniform([0.0, -1.0], [1.0, 1.0])
            obs, reward, done, info = env.step(action)
            print(f"Step {step}: Reward={reward:.3f}, Done={done}")
            if done:
                obs = env.reset()
            time.sleep(0.1)
    except KeyboardInterrupt:
        print("\nStopped by user")
    finally:
        env.close()


if __name__ == '__main__':
    main()
