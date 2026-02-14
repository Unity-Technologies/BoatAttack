# Python RL Client for BoatAttack

Unity BoatAttack 프로젝트와 TCP 소켓으로 통신하는 Python 강화학습 클라이언트.

## 요구사항

```bash
pip install torch numpy matplotlib
```

## 파일 구조

| 파일 | 설명 |
|------|------|
| `unity_client.py` | TCP 클라이언트 + Gymnasium 스타일 래퍼 |
| `ppo_agent.py` | PyTorch PPO 에이전트 (ActorCritic, GAE) |
| `train.py` | 학습 루프 (체크포인트, 학습 곡선) |
| `test_connection.py` | Unity 연결 테스트 |

## 사용법

### 1. Unity 설정

Unity 씬에 아래 중 하나를 추가:
- **`SocketServer`** - 단일 에이전트 통신 (RLAgent와 함께 사용)
- **`MultiAgentServer`** - 다중 선박 통신 (모든 선박 상태 전송)

기본 포트: `9876`

### 2. 연결 테스트

Unity Play 모드 실행 후:

```bash
python test_connection.py
```

### 3. 학습 실행

```bash
# 기본 설정
python train.py

# 커스텀 설정
python train.py --episodes 10000 --lr 1e-4 --save-dir my_checkpoints

# 이어서 학습
python train.py --load-model checkpoints/best_model.pt
```

### 4. 주요 학습 파라미터

| 파라미터 | 기본값 | 설명 |
|----------|--------|------|
| `--episodes` | 5000 | 총 에피소드 수 |
| `--max-steps` | 1000 | 에피소드당 최대 스텝 |
| `--update-interval` | 2048 | PPO 업데이트 주기 (스텝) |
| `--lr` | 3e-4 | 학습률 |
| `--gamma` | 0.99 | 할인율 |
| `--save-interval` | 100 | 체크포인트 저장 주기 (에피소드) |

## ML-Agents vs 외부 Python

이 프로젝트는 두 가지 학습 방식을 지원합니다:

| 방식 | 장점 | 사용 시 |
|------|------|---------|
| **ML-Agents** | 안정적, 커리큘럼 학습, TensorBoard | `mlagents-learn config/defense_boat_trainer.yaml` |
| **외부 Python** | 커스텀 알고리즘, PyTorch 직접 제어 | `python train.py` |

두 방식을 동시에 사용하지 마세요. Unity 씬에서 하나만 활성화하세요.

## 통신 프로토콜

### Unity → Python (관측)

```json
{
  "ships": [
    {
      "id": "FriendlyBoat_0",
      "tag": "Friendly",
      "position": [x, y, z],
      "velocity": [vx, vy, vz],
      "rotation": [rx, ry, rz],
      "speed": 5.2
    }
  ],
  "frameCount": 120,
  "time": 12.5
}
```

### Python → Unity (액션)

```json
{
  "shipId": "FriendlyBoat_0",
  "throttle": 0.8,
  "steering": 0.3,
  "fire": false
}
```
