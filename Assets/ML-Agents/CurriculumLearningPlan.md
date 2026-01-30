# MA-PPO 방어 선박 커리큘럼 학습 계획

## 개요

두 대의 방어 선박이 협력하여 적군 선박을 포획하는 시스템을 **3단계 커리큘럼 학습**으로 구현한다.
각 단계는 이전 단계의 모델을 `--initialize-from`으로 불러와 전이 학습을 수행한다.

---

## Stage 1: 대형 유지 (Formation Keeping)

### 목표
- 두 선박이 **나란히 이동**
- **일정 거리 유지** (이격 거리 준수)
- 기본적인 협동 기동 학습

### 활성화할 보상

| 보상 항목 | 값 | 설명 |
|----------|-----|------|
| 헤딩 동기화 | `+0.0002` | 두 선박의 방향이 일치할 때 |
| 속도 동기화 | `+0.0002` | 두 선박의 속도가 일치할 때 |
| 간격 유지 | `+0.0002` | 최적 거리(50m) 유지 시 |
| 그물 장력 | `+0.0005` | 그물 길이 90~95% 유지 시 |
| 속도 보상 | `+0.0003` | 빠를수록 높은 보상 |

### 비활성화할 보상

| 보상 항목 | 값 | 이유 |
|----------|-----|------|
| 포획 보상 | `0` | Stage 2에서 활성화 |
| 수직 차단 보상 | `0` | Stage 3에서 활성화 |
| 추적 이득 보상 | `0` | Stage 3에서 활성화 |

### 페널티

| 페널티 항목 | 값 | 설명 |
|------------|-----|------|
| 아군 거리 초과 | `-2.0` | 거리 > maxAllyDistance 시 에피소드 종료 |
| 대형 붕괴 | `-0.05` | 거리 > 100m 또는 헤딩 > 90° |
| 시간 패널티 | `-0.001` | 매 스텝 |
| 아군 충돌 | `-1.0` | 아군끼리 충돌 시 |

### 에피소드 종료 조건
- 아군 간 거리 초과 (maxAllyDistance)
- 아군 충돌
- 최대 스텝 도달

### 환경 설정
- 적군 선박: **비활성화** 또는 0대
- 모선: 비활성화 (충돌 판정 제외)

### 학습 명령어
```bash
mlagents-learn config/Defense_Stage1.yaml --run-id=Defense_Stage1_Formation
```

### 성공 기준
- 평균 에피소드 길이가 최대 스텝에 근접
- 두 선박의 헤딩 차이가 지속적으로 15° 이내
- 거리 유지율 90% 이상

---

## Stage 2: 포획 보상 학습 (Capture Reward)

### 목표
- Stage 1의 대형 유지 능력 보존
- **적군 포획 시 보상** 학습
- **빠른 포획 = 높은 보상** 개념 학습

### 추가 활성화할 보상

| 보상 항목 | 값 | 설명 |
|----------|-----|------|
| 포획 성공 | `+1.0` | 적군이 Web에 충돌 시 |
| 포획 위치 보너스 | `+0.3` (최대) | 그물 중심에서 포획 시 |
| 모선 방어 성공 | `+0.5` | 에피소드 종료 시 모선 무사 |

### 추가 페널티

| 페널티 항목 | 값 | 설명 |
|------------|-----|------|
| 모선 충돌 | `-1.75` | 적군이 모선에 충돌 시 |
| 경계선 침범 | `-0.1` | 2km/1km 경계 초과 시 |

### 에피소드 종료 조건
- Stage 1 조건 모두 포함
- 총 충돌 횟수 ≥ 3 (Web + MotherShip 합산)
- 모선 충돌 (게임 오버)

### 환경 설정
- 적군 선박: **1~2대** (단순한 경로)
- 모선: 활성화
- 적군 속도: 느리게 설정

### 학습 명령어
```bash
mlagents-learn config/Defense_Stage2.yaml \
--run-id=Defense_Stage2_Capture \
--initialize-from=Defense_Stage1_Formation
```

### 성공 기준
- 포획 성공률 > 50%
- 평균 포획 시간 감소 추세
- 대형 유지율 80% 이상 (Stage 1 능력 보존)

---

## Stage 3: 전술 기동 (Tactical Maneuvering)

### 목표
- Stage 1 + Stage 2 능력 보존
- **적극적인 추적 및 차단** 학습
- **수직 차단 기동** 최적화
- 다수 적군 대응

### 추가 활성화할 보상

| 보상 항목 | 값 | 설명 |
|----------|-----|------|
| 수직 차단 | `+0.0005` | 그물-적 각도 ≈ 90° |
| 추적 이득 | `+0.0002` | 적-그물 거리 감소 시 |

### 환경 설정
- 적군 선박: **3~5대**
- 적군 속도: 정상 또는 빠르게
- 적군 경로: 다양화 (랜덤 요소 추가)

### 학습 명령어
```bash
mlagents-learn config/Defense_Stage3.yaml \
--run-id=Defense_Stage3_Tactical \
--initialize-from=Defense_Stage2_Capture
```

### 성공 기준
- 다수 적군 포획 성공률 > 70%
- 모선 생존율 > 90%
- 평균 포획 시간 최소화

---

## YAML 설정 파일 구조

### config/Defense_Stage1.yaml
```yaml
behaviors:
  DefenseAgent:
    trainer_type: ppo
    hyperparameters:
      batch_size: 1024
      buffer_size: 10240
      learning_rate: 3.0e-4
      beta: 5.0e-3
      epsilon: 0.2
      lambd: 0.95
      num_epoch: 3
      learning_rate_schedule: linear
    network_settings:
      normalize: true
      hidden_units: 256
      num_layers: 2
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 1.0
    max_steps: 1000000
    time_horizon: 64
    summary_freq: 10000
```

### config/Defense_Stage2.yaml
```yaml
# Stage 1과 동일하되, max_steps 증가
behaviors:
  DefenseAgent:
    # ... (Stage 1과 동일)
    max_steps: 2000000
```

### config/Defense_Stage3.yaml
```yaml
# Stage 2와 동일하되, max_steps 증가 및 하이퍼파라미터 미세 조정
behaviors:
  DefenseAgent:
    # ... (Stage 2와 동일)
    max_steps: 3000000
    hyperparameters:
      learning_rate: 1.0e-4  # 감소 (미세 조정)
```

---

## 코드 수정 체크리스트

### Stage 1 준비
- [x] DefenseEnvController에 `currentStage` 변수 추가 ✅
- [x] Stage별 보상 활성화/비활성화 로직 구현 ✅
- [x] 적군 선박 비활성화 옵션 추가 ✅
- [ ] Stage 1 전용 YAML 파일 생성

### Stage 2 준비
- [x] 적군 선박 1~2대 활성화 (`stage2EnemyCount` 설정) ✅
- [x] 포획 보상 활성화 (`IsCaptureRewardEnabled()`) ✅
- [x] 모선 충돌 페널티 활성화 (`IsMotherShipPenaltyEnabled()`) ✅

### Stage 3 준비
- [x] 적군 선박 3~5대 활성화 (`stage3EnemyCount` 설정) ✅
- [x] 수직 차단/추적 이득 보상 활성화 (`IsTacticalRewardEnabled()`) ✅
- [ ] 적군 경로 다양화

---

## 구현된 Inspector 설정

### DefenseEnvController
```
[Training Stage]
├── Current Stage: Stage1_Formation / Stage2_Capture / Stage3_Tactical
├── Disable Enemies In Stage1: true (Stage1에서 적군 비활성화)
├── Stage1 Enemy Count: 0
├── Stage2 Enemy Count: 2
└── Stage3 Enemy Count: 5
```

### DefenseRewardCalculator
```
[Training Stage]
└── Current Stage: (DefenseEnvController에서 자동 동기화)
```

### Stage별 보상 활성화 요약

| 보상/페널티 | Stage1 | Stage2 | Stage3 |
|------------|--------|--------|--------|
| 헤딩 동기화 | ✅ | ✅ | ✅ |
| 속도 동기화 | ✅ | ✅ | ✅ |
| 간격 유지 | ✅ | ✅ | ✅ |
| 그물 장력 | ✅ | ✅ | ✅ |
| 속도 보상 | ✅ | ✅ | ✅ |
| 대형 붕괴 페널티 | ✅ | ✅ | ✅ |
| 시간 페널티 | ✅ | ✅ | ✅ |
| 아군 거리 초과 | ✅ | ✅ | ✅ |
| **포획 보상** | ❌ | ✅ | ✅ |
| **모선 충돌 페널티** | ❌ | ✅ | ✅ |
| **수직 차단 보상** | ❌ | ❌ | ✅ |
| **추적 이득 보상** | ❌ | ❌ | ✅ |

---

## 폴더 구조

```
BoatAttack/
├── config/
│   ├── Defense_Stage1.yaml
│   ├── Defense_Stage2.yaml
│   └── Defense_Stage3.yaml
├── results/
│   ├── Defense_Stage1_Formation/
│   ├── Defense_Stage2_Capture/
│   └── Defense_Stage3_Tactical/
└── Assets/
    └── ML-Agents/
        ├── CurriculumLearningPlan.md  (이 파일)
        └── Models/
            ├── Defense_Stage1.onnx
            ├── Defense_Stage2.onnx
            └── Defense_Stage3.onnx
```

---

## 참고 명령어

### TensorBoard 모니터링
```bash
tensorboard --logdir=results
```

### 학습 재개
```bash
mlagents-learn config/Defense_Stage1.yaml --run-id=Defense_Stage1_Formation --resume
```

### 추론 모드 (학습된 모델 테스트)
```bash
mlagents-learn config/Defense_Stage1.yaml --run-id=Defense_Stage1_Formation --inference
```
