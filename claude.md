# BoatAttack Defense Training Project

## 프로젝트 개요
- Unity 기반 선박 시뮬레이션 + ML-Agents 강화학습
- 목표: 아군 선박 2대가 그물(Web)로 적군 선박 포획
- MA-PPO (Multi-Agent PPO) 협동 학습

## 핵심 파일 구조

### ML-Agents 관련
| 파일 | 설명 |
|------|------|
| `Assets/Scripts/Defense/DefenseEnvController.cs` | 환경 컨트롤러, 에피소드 관리, 리셋 |
| `Assets/Scripts/Defense/DefenseRewardCalculator.cs` | 보상 계산 (Stage별 분리) |
| `Assets/Scripts/MLAgents/DefenseAgent.cs` | 에이전트 정의, 관측/액션 처리 |
| `config/defense_boat_trainer.yaml` | 학습 하이퍼파라미터 설정 |

### 선박 물리
| 파일 | 설명 |
|------|------|
| `Assets/Scripts/Boat/Engine.cs` | 엔진 추진력, AddForce 처리, Gerstner 파도 연동 |
| `Assets/Scripts/Boat/Boat.cs` | 선박 기본 로직 |

## Stage 시스템 (Curriculum Learning)

| Stage | 목적 | 활성화 보상 |
|-------|------|------------|
| **Stage1_Formation** | 대형 유지 학습 | 개별속도, 선회페널티, 그룹대형(헤딩/속도/간격) |
| **Stage2_Capture** | 포획 학습 | 포획보상, 전술기동(수직차단/추적이득) |
| **Stage3_Tactical** | 종합 (Stage1+2) | Stage1 + Stage2 모든 보상 |

### Stage별 보상 매트릭스
| 보상 | Stage1 | Stage2 | Stage3 |
|------|--------|--------|--------|
| 개별 속도 보상 | O | X | O |
| 선회 페널티 | O | X | O |
| Stage1 그룹 보상 | O | X | O |
| 포획 보상 | X | O | O |
| 전술 기동 | X | O | O |

## 액션 공간

```csharp
// DefenseAgent.cs OnActionReceived()
float throttleInput = actions.ContinuousActions[0];  // -1 ~ 1
float steeringInput = actions.ContinuousActions[1];  // -1 ~ 1

// Throttle: Mapping 방식 (-1~1 → 0.5~1.0)
float throttle = (throttleInput + 1f) * 0.25f + 0.5f;
// -1 → 0.5, 0 → 0.75, 1 → 1.0
```

## 주요 보상 파라미터

### 개별 보상 (DefenseRewardCalculator)
```csharp
stage1IndividualSpeedReward = 0.02f;      // 속도 보상 (최대)
stage1SteeringPenaltyCoeff = 0.0002f;     // 선회 페널티 계수
stage1SpeedThreshold = 10f;               // 속도 보상 기준 (m/s)
```

### 포획 보상 (DefenseEnvController)
```csharp
captureReward = 1.0f;                     // 포획 시 기본 보상
captureDistanceBonus = 0.5f;              // 모선에서 멀리 포획 시 보너스
captureDistanceBonusRange = 500f;         // 최대 보너스 거리
```

### 페널티
```csharp
motherShipCollisionPenalty = -2.0f;       // 모선 충돌
allyDistancePenalty = -1.0f;              // 아군 간 거리 초과 (120m)
maxAllyDistance = 120f;                   // 아군 최대 허용 거리
```

## 알려진 이슈 및 해결책

### 에피소드 시작 시 배 날아감/뒤집힘
**원인**: transform 직접 설정 + 물리력 누적
**해결**:
```csharp
rb.velocity = Vector3.zero;
rb.angularVelocity = Vector3.zero;
rb.position = targetPos;      // transform 대신 rb 사용
rb.rotation = originalRot;
rb.Sleep();                   // 물리 시뮬레이션 일시 정지
```

### 학습 시 물리 불안정
**원인**: `time_scale: 20` → Gerstner 파도/부력 계산 불안정
**해결**: `time_scale: 10` 이하로 설정

### Mean Reward 고정 (탐험 부족)
**원인**: 보상 차이가 너무 작음 (0.0005)
**해결**: 보상 스케일 20배 증가

## 학습 명령어

```bash
# 새 학습 시작
mlagents-learn config/defense_boat_trainer.yaml --run-id=defense_v1

# 이어서 학습
mlagents-learn config/defense_boat_trainer.yaml --run-id=defense_v1 --resume

# TensorBoard 확인
tensorboard --logdir=results
```

## 학습 설정 (defense_boat_trainer.yaml)

```yaml
# 주요 설정
time_scale: 10          # 물리 안정성 위해 20→10 권장
batch_size: 1024
buffer_size: 10240
learning_rate: 0.0003
max_steps: 5000000
time_horizon: 64
```

## 물리 관련 주의사항

1. **Engine.cs의 ForceMode.Acceleration**: 질량 무관 가속, timeScale 영향 받음
2. **Gerstner 파도**: 위치 급변 시 `_yHeight` 계산 오류 가능
3. **inputSmoothing**: `_prevThrottle` 초기값이 0이면 Lerp로 throttle이 0.5 미만 될 수 있음 → 0.5로 초기화 필요

## 관측 공간 (CollectObservations)

- 자신: 위치(x,z), 헤딩, 속도 = 4개
- 팀원: 상대 위치(x,z), 상대 헤딩, 속도 = 4개
- 적군들: 상대 위치(x,z), 상대 헤딩, 속도 = 4 × 적군수
- 모선: 상대 위치(x,z), 거리 = 3개

## 자주 수정하는 파라미터 위치

| 파라미터 | 파일 | 변수명 |
|----------|------|--------|
| 보상 계산 주기 | DefenseEnvController | `rewardCalculationInterval` |
| 개별 속도 보상 | DefenseRewardCalculator | `stage1IndividualSpeedReward` |
| 선회 페널티 계수 | DefenseRewardCalculator | `stage1SteeringPenaltyCoeff` |
| 최적 거리 | DefenseRewardCalculator | `stage1OptimalDistance` (50m) |
| 학습 스테이지 | DefenseEnvController Inspector | `currentStage` |
