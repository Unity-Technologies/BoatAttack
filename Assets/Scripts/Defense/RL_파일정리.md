# 강화학습 관련 파일 정리

## 📁 파일 구조

```
Scripts/
├── MLAgents/
│   └── DefenseAgent.cs              # 방어 에이전트 (메인)
│
└── Defense/
    ├── DefenseEnvController.cs      # 환경 컨트롤러 (중앙 허브)
    ├── DefenseRewardCalculator.cs    # 보상 계산기
    │
    ├── MLAgents/
    │   ├── AttackAgent.cs           # 공격 에이전트
    │   ├── DynamicWeb.cs            # 웹 생성 및 관리
    │   ├── WebCollisionDetector.cs  # 웹 충돌 감지
    │   ├── SimpleExplosionOnCollision.cs  # 폭발 효과
    │   └── AttackBoatDisabler.cs    # 공격 보트 비활성화
    │
    ├── MotherShipCollisionDetector.cs  # 모선 충돌 감지
    └── MotherShipGenerator.cs          # 모선 생성
```

---

## 🎯 핵심 파일 설명

### 1. **DefenseAgent.cs** (`MLAgents/DefenseAgent.cs`)
**역할:** 방어 에이전트 (메인 학습 대상)

**주요 기능:**
- 2대의 방어 선박이 협력하여 적군을 web 사이로 유도
- 목표 속도 기반 연속 액션 (throttle, steering)
- 상대 좌표 기반 관측 (파트너, 적군, 모선, web)
- 그룹 보상 수신 (SimpleMultiAgentGroup)

**액션:**
- `ContinuousActions[0]`: throttle (-1 ~ 1)
- `ContinuousActions[1]`: steering (-1 ~ 1)

**관측:**
- 파트너 상대 위치/속도
- 적군 상대 위치/속도 (최대 5대)
- 모선 상대 위치
- Web 상대 위치
- 자신의 속도/각속도

---

### 2. **DefenseEnvController.cs** (`Defense/DefenseEnvController.cs`)
**역할:** 환경 컨트롤러 (중앙 허브)

**주요 기능:**
- 에피소드 시작/종료 관리
- 모든 선박 위치 리셋
- 적군 선박 재생성 및 추적
- 그룹 보상 분배
- Web 자동 생성 및 관리
- 충돌 이벤트 처리 (Web, MotherShip)

**핵심 메서드:**
- `RestartEpisode()`: 에피소드 재시작
- `ResetScene()`: 환경 리셋
- `ResetPositionsOnly()`: 위치만 리셋
- `OnEnemyHitWeb()`: 적군이 Web 충돌 시
- `OnEnemyHitMotherShip()`: 적군이 모선 충돌 시

---

### 3. **DefenseRewardCalculator.cs** (`Defense/DefenseRewardCalculator.cs`)
**역할:** 보상 계산기

**주요 기능:**
- 협동 기동 보상 계산
- 전술 기동 보상 계산
- 안전 및 제약 페널티 계산
- 에이전트 상태 수집

**보상 종류:**
- 협동 보상: 두 에이전트 간 거리 유지
- 전술 보상: 적군을 web 사이로 유도
- 안전 페널티: 충돌, 경계 침범 등

---

### 4. **AttackAgent.cs** (`Defense/MLAgents/AttackAgent.cs`)
**역할:** 공격 에이전트 (적군)

**주요 기능:**
- 모선에 접근하는 것이 목표
- 거리 기반 보상 (가까울수록 높은 보상)
- Raycast 기반 관측
- Heuristic 제공 (수동 조작 가능)

**보상:**
- 모선과의 거리가 가까울수록 보상
- 시간당 작은 페널티 (빠른 접근 유도)

---

## 🔧 보조 스크립트

### 5. **DynamicWeb.cs** (`Defense/MLAgents/DynamicWeb.cs`)
**역할:** Web 오브젝트 동적 생성 및 관리

**주요 기능:**
- 두 방어 선박 사이에 Web 생성
- Web 크기/위치/회전 자동 조정
- 충돌 감지용 Collider 설정

---

### 6. **WebCollisionDetector.cs** (`Defense/MLAgents/WebCollisionDetector.cs`)
**역할:** Web 충돌 감지

**주요 기능:**
- `attack_boat` 태그와 충돌 감지
- `DefenseEnvController.OnEnemyHitWeb()` 호출
- 폭발 효과 및 에피소드 재시작 트리거

---

### 7. **MotherShipCollisionDetector.cs** (`Defense/MotherShipCollisionDetector.cs`)
**역할:** 모선 충돌 감지

**주요 기능:**
- `attack_boat` 태그와 충돌 감지
- `DefenseEnvController.OnEnemyHitMotherShip()` 호출
- 폭발 효과 및 에피소드 재시작 트리거

---

### 8. **SimpleExplosionOnCollision.cs** (`Defense/MLAgents/SimpleExplosionOnCollision.cs`)
**역할:** 충돌 시 폭발 효과

**주요 기능:**
- 충돌 시 ParticleSystem 생성
- 일정 시간 후 자동 파괴

---

### 9. **AttackBoatDisabler.cs** (`Defense/MLAgents/AttackBoatDisabler.cs`)
**역할:** 공격 보트 비활성화 관리

**주요 기능:**
- 특정 조건에서 공격 보트 비활성화
- 에피소드 리셋 시 재활성화

---

## 📊 데이터 흐름

```
DefenseAgent (2대)
    ↓ 관측/액션
DefenseEnvController (중앙 허브)
    ↓ 보상 계산 요청
DefenseRewardCalculator
    ↓ 보상 반환
DefenseEnvController
    ↓ 그룹 보상 분배
SimpleMultiAgentGroup
    ↓ 보상 전달
DefenseAgent (2대)
```

---

## 🎮 에피소드 흐름

1. **시작:**
   - `DefenseEnvController.Start()` → `ResetScene()`
   - 모든 선박 초기 위치로 리셋
   - Web 자동 생성

2. **진행:**
   - `DefenseAgent`들이 관측 수집 및 액션 수행
   - `DefenseRewardCalculator`가 보상 계산
   - `DefenseEnvController`가 보상 분배

3. **종료 조건:**
   - 모든 적군 선박 파괴
   - 적군이 Web 충돌
   - 적군이 모선 충돌
   - 최대 환경 스텝 수 도달

4. **재시작:**
   - `RestartEpisode()` 호출
   - 모든 위치/속도 리셋
   - 파괴된 적군 재생성
   - Web 재생성

---

## 🔗 파일 간 의존성

```
DefenseAgent
    ├── DefenseEnvController (보상 수신, 에피소드 관리)
    ├── DefenseRewardCalculator (보상 계산)
    └── SimpleMultiAgentGroup (그룹 보상)

DefenseEnvController
    ├── DefenseAgent (에이전트 관리)
    ├── DefenseRewardCalculator (보상 계산)
    ├── SimpleMultiAgentGroup (그룹 보상)
    ├── WebCollisionDetector (Web 충돌)
    └── MotherShipCollisionDetector (모선 충돌)

AttackAgent
    └── DefenseEnvController (에피소드 관리)
```

---

## 📝 설정 파일

### Unity ML-Agents 설정
- Behavior Name: `DefenseAgent`
- Vector Observation Space: 변수 (파트너, 적군, 모선, web 등)
- Vector Action Space: Continuous (2) - throttle, steering
- Max Step: `DefenseEnvController.maxEnvironmentSteps`

### 인스펙터 설정
**DefenseEnvController:**
- `defenseAgent1`, `defenseAgent2`: 방어 에이전트 할당
- `motherShip`: 모선 GameObject
- `enemyShips[]`: 적군 선박 배열
- `webObject`: Web GameObject (자동 생성 가능)
- `maxEnvironmentSteps`: 최대 환경 스텝 수

**DefenseAgent:**
- `partnerAgent`: 파트너 에이전트
- `enemyShips[]`: 적군 선박 배열
- `webObject`: Web GameObject
- `motherShip`: 모선 GameObject

---

## 🚀 사용 방법

1. **씬 설정:**
   - `DefenseEnvController`를 씬에 추가
   - `DefenseAgent` 2개를 방어 선박에 추가
   - `AttackAgent`를 적군 선박에 추가 (선택사항)

2. **인스펙터 설정:**
   - `DefenseEnvController`에 에이전트 및 오브젝트 할당
   - `DefenseAgent`에 파트너 및 적군 할당

3. **학습 시작:**
   - Unity에서 Play 모드 실행
   - Python에서 ML-Agents 학습 시작
   - `mlagents-learn` 명령어 사용

---

## 📚 관련 문서

- `EpisodeEndConditions.md`: 에피소드 종료 조건 설명
- `SimpleMultiAgentGroup_설명.md`: 그룹 보상 설명
- `UnitySetupGuide.md`: Unity 설정 가이드
- `MA_PPO_Implementation_Plan.md`: 다중 에이전트 PPO 구현 계획

---

## ⚠️ 주의사항

1. **에이전트 등록:**
   - `DefenseAgent`는 `SimpleMultiAgentGroup`에 등록되어야 함
   - `DefenseEnvController.Start()`에서 자동 등록

2. **Web 생성:**
   - `DefenseEnvController.autoCreateWeb = true`로 설정 시 자동 생성
   - 수동 생성 시 `webObject`에 할당

3. **충돌 감지:**
   - Web과 모선에 Collider 및 Rigidbody 필요
   - `isTrigger = true` 설정 필요

4. **에피소드 리셋:**
   - 모든 위치 리셋은 코루틴으로 처리됨
   - 비활성화 → 리셋 → 활성화 순서로 진행

---

## 🔄 최근 변경사항

- 모든 디버그 로그 제거 (성능 최적화)
- Web 자동 생성 기능 추가
- 충돌 감지 시스템 개선
- 적군 선박 재생성 시스템 추가

---

**작성일:** 2026-01-26
**버전:** 1.0
