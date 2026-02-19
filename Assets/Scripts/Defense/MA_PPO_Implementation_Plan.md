# MA-PPO 구현 계획서

## 1. 개요
- **목표**: 2대의 DefenseAgent가 협력하여 적 USV를 포획하는 Multi-Agent PPO 학습 시스템
- **환경**: Unity ML-Agents
- **알고리즘**: PPO (Proximal Policy Optimization) with Multi-Agent 설정

---

## 2. 보상 체계 구현 계획

### 2.1 임무 성과 (Mission Performance) - 최상/상 가중치

#### ✅ 적 포획 성공 (+1.0 + 위치 보너스)
- **현재 상태**: `OnEnemyCaptured()` 메서드로 구현됨
- **개선 사항**: 
  - 보상값을 1.0으로 변경 (현재 10.0)
  - 두 에이전트 모두 동일한 보상 수신 확인
  - **위치 기반 보너스 추가**: 그물의 중심에 가까울수록 추가 보상
    - 그물 중심 = 두 USV의 중점
    - 포획 시 적의 위치와 그물 중심 간 거리 계산
    - 거리가 가까울수록 보너스 보상 (최대 +0.3 정도)
    - 공식: `centerBonus = maxCenterBonus * (1 - distanceToCenter / maxDistance)`
    - 예: 중심에서 0m = +0.3, 10m = +0.2, 20m = +0.1, 30m 이상 = +0.0
    - **구현 방법**:
      - `WebCollisionDetector.OnTriggerEnter()`에서 적의 위치 저장
      - `OnEnemyCaptured(Vector3 enemyPosition)` 메서드 시그니처 변경
      - `DefenseAgent.OnEnemyCaptured()`에서 파트너와 함께 그물 중심 계산
      - 중심으로부터 거리에 따라 보너스 계산 및 추가 보상

#### ⚠️ 모선 방어 성공 (+0.5)
- **구현 필요**: 
  - `DefenseBoatManager`에 모선 참조 추가
  - 에피소드 종료 시점 체크 (`OnEpisodeEnd()` 또는 `EndCurrentEpisode()`)
  - 적이 모선으로부터 1km 이내 진입했는지 추적
  - 진입 실패 시 두 에이전트 모두 +0.5 보상

#### ⚠️ 방어선 침범 (-0.1)
- **구현 필요**:
  - 2km 경계선과 1km 경계선 정의
  - 적의 모선까지 거리 추적
  - 경계선 돌파 감지 시 즉시 -0.1 보상
  - 중복 보상 방지 (각 경계선당 1회만)

---

### 2.2 협동 기동 (Cooperative Maneuvering) - 중 가중치

#### ⚠️ 헤딩 동기화 (+0.0001~0.0005)
- **구현 필요**:
  - `CalculateReward()`에서 매 스텝 계산
  - 허용 범위 설정 (예: ±15도)
  - 범위 내일 때만 미세한 보상 부여
- **⚠️ 중요: 보상 값 조정**
  - **원래 계획**: +0.01 (매 스텝)
  - **문제점**: 에피소드가 25,000 스텝일 때, 1,000 스텝만 동기화해도 10.0 보상 → 최종 목표(+1.0) 압도
  - **해결책**: **+0.0001~0.0005**로 대폭 감소 (에피소드당 최대 1.25~6.25)
  - **상태 보상 방식**: 특정 오차 범위 내에 있을 때만 아주 미세하게 부여

#### ⚠️ 속도 동기화 (+0.0001~0.0005)
- **구현 필요**:
  - 두 USV의 속도 차이 계산
  - 허용 범위 설정 (예: ±2 m/s)
  - 범위 내일 때만 미세한 보상 부여
- **⚠️ 중요: 보상 값 조정**
  - **원래 계획**: +0.01 (매 스텝)
  - **해결책**: **+0.0001~0.0005**로 대폭 감소
  - **상태 보상 방식**: 속도 차이가 허용 범위 내일 때만 부여

#### ⚠️ 간격 유지 (+0.0001~0.0005)
- **현재 상태**: 거리 유지 페널티만 존재
- **개선 사항**:
  - 최적 거리(50m) 유지 시 미세한 보상 추가
  - 허용 범위 설정 (예: 45m~55m)
  - 기존 페널티는 유지하되, 보상도 추가
- **⚠️ 중요: 보상 값 조정**
  - **원래 계획**: +0.01 (매 스텝)
  - **해결책**: **+0.0001~0.0005**로 대폭 감소

#### ⚠️ 그물 장력 (Net Tension) (+0.0003~0.0008)
- **구현 필요**:
  - 두 배 사이의 거리가 그물 길이의 90~95% 수준일 때 보상 극대화
  - 그물이 최대로 펼쳐진 상태(팽팽한 상태) 유도
  - 방어 면적 최대화를 위한 보상
- **구현 방법**:
  - 그물 최대 길이 정의 (예: 50m)
  - 현재 두 배 간 거리 계산
  - 거리가 그물 길이의 90~95% 범위일 때 최대 보상
  - 공식: `tensionReward = maxReward * (1 - |distance - optimalDistance| / tolerance)`
  - 예: 그물 길이 50m, 최적 범위 45~47.5m (90~95%)
- **⚠️ 중요: 보상 값**
  - **권장 값**: **+0.0003~0.0008** (간격 유지보다 약간 높게)
  - 그물이 끊어지거나 엉키는 것을 방지하는 중요한 보상

---

### 2.3 전술 기동 (Tactical Maneuvering) - 하/최하 가중치

#### ⚠️ 수직 차단 (+0.0005~0.001)
- **구현 필요**:
  - 그물 선분 계산 (두 USV 사이 직선)
  - 적의 진입 경로 벡터 계산
  - 두 벡터 간 각도 계산 (90도에 가까울수록 보상)
  - 임계값 설정 (예: 75도~105도 범위)
- **⚠️ 중요: 보상 값 조정**
  - **원래 계획**: +0.005 (매 스텝)
  - **해결책**: **+0.0005~0.001**로 감소

#### ⚠️ 추적 이득 (+0.0001~0.0005)
- **구현 필요**:
  - 이전 스텝의 적-그물 거리 저장
  - 현재 스텝의 거리와 비교
  - 거리 감소 시 미세한 보상 부여 (Potential 기반)
- **⚠️ 중요: 보상 값 조정**
  - **원래 계획**: +0.001 (매 스텝)
  - **해결책**: **+0.0001~0.0005**로 감소

---

### 2.4 안전 및 제약 (Safety & Constraints) - 최상/중/최하 가중치

#### ⚠️ 충돌 발생 (-1.0)
- **구현 필요**:
  - `OnCollisionEnter()` 또는 `OnTriggerEnter()` 추가
  - 충돌 대상 확인 (아군-아군, 아군-모선)
  - 충돌 시 즉시 -1.0 보상 및 에피소드 종료

#### ⚠️ 모선 충돌 패널티 (Game Over) (-1.5 ~ -2.0) ⚠️ 최우선
- **구현 필요**:
  - 적군 선박(attack_boat 태그)이 모선(MotherShip 태그)과 충돌 시
  - **즉시 에피소드 종료** 및 큰 패널티 부여
  - 단순 실점이 아닌 **패배**로 처리
- **구현 방법**:
  - **옵션 1**: 모선에 `MotherShipCollisionDetector.cs` 컴포넌트 추가
    - `OnCollisionEnter()` 또는 `OnTriggerEnter()` 사용
    - 충돌 대상 태그 확인: `other.CompareTag("attack_boat")`
    - `DefenseEnvController.OnMotherShipCollision()` 호출
  - **옵션 2**: `DefenseBoatManager`에서 모선 충돌 감지
    - 모선에 충돌 감지 스크립트 추가
    - `DefenseEnvController` 참조를 통해 알림
  - 그룹 보상으로 패널티 분배: `m_AgentGroup.AddGroupReward(-1.75f)`
  - 즉시 에피소드 종료: `m_AgentGroup.EndGroupEpisode()`
- **⚠️ 중요: 보상 값**
  - **권장 값**: **-1.5 ~ -2.0** (아군 충돌 패널티 -1.0보다 더 큰 값)
  - 모선 방어 실패는 최악의 결과이므로 가장 큰 패널티 부여
  - 에피소드 즉시 종료로 학습 속도 향상
- **구현 예시**:
  ```csharp
  // MotherShipCollisionDetector.cs (모선에 부착)
  public class MotherShipCollisionDetector : MonoBehaviour
  {
      public DefenseEnvController envController;
      public string enemyTag = "attack_boat";
      
      private void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.CompareTag(enemyTag))
          {
              if (envController != null)
                  envController.OnMotherShipCollision(collision.gameObject);
          }
      }
      
      private void OnTriggerEnter(Collider other)
      {
          if (other.CompareTag(enemyTag))
          {
              if (envController != null)
                  envController.OnMotherShipCollision(other.gameObject);
          }
      }
  }
  ```

#### ⚠️ 대형 붕괴 (-0.05)
- **구현 필요**:
  - 두 배 간 거리 체크 (예: 100m 초과 시)
  - 헤딩 차이 체크 (예: 90도 이상)
  - 조건 만족 시 -0.05 보상

#### ✅ 시간 패널티 (-0.001)
- **현재 상태**: `timePenalty = -0.001f`로 구현됨
- **확인 사항**: 매 프레임 적용되는지 확인

---

## 3. 코드 구조 개선 계획

### 3.1 DefenseAgent.cs 개선

#### 추가할 필드:
```csharp
[Header("Observation Settings")]
[Tooltip("관측할 적군 선박들 (인스펙터에서 할당)")]
public GameObject[] enemyShips = new GameObject[5];  // 최대 5대까지 지원

[Tooltip("최대 관측 가능한 적군 수")]
public int maxEnemyCount = 5;

[Header("Action Settings")]
[Tooltip("최대 선속도 (m/s)")]
public float maxLinearVelocity = 20f;

[Tooltip("최대 각속도 (deg/s)")]
public float maxAngularVelocity = 90f;

[Tooltip("속도 제어 게인 (PID 또는 비례 제어)")]
public float velocityControlGain = 1.0f;

[Tooltip("각속도 제어 게인")]
public float angularVelocityControlGain = 1.0f;

[Tooltip("최대 선가속도 (m/s²) - 물리적 한계")]
public float maxLinearAcceleration = 5f;

[Tooltip("최대 각가속도 (deg/s²) - 물리적 한계")]
public float maxAngularAcceleration = 45f;

[Header("Reward Parameters")]
// 임무 성과
public float captureReward = 1.0f;  // 기존 10.0 → 1.0
public float captureCenterBonus = 0.3f;  // 그물 중심 포획 보너스 (최대)
public float captureCenterMaxDistance = 30f;  // 중심으로부터 최대 거리 (이 거리 이상이면 보너스 0)
public float motherShipDefenseReward = 0.5f;
public float boundaryBreachPenalty = -0.1f;
public float boundary2km = 2000f;
public float boundary1km = 1000f;

// 협동 기동 (⚠️ 보상 값 대폭 감소 - 보상 해킹 방지)
public float headingSyncReward = 0.0002f;  // 기존 0.01 → 0.0002 (50배 감소)
public float headingSyncTolerance = 15f;  // ±15도
public float speedSyncReward = 0.0002f;  // 기존 0.01 → 0.0002
public float speedSyncTolerance = 2f;  // ±2 m/s
public float distanceMaintainReward = 0.0002f;  // 기존 0.01 → 0.0002
public float optimalDistance = 50f;
public float distanceTolerance = 5f;  // ±5m

// 그물 장력 (Net Tension)
public float netTensionReward = 0.0005f;  // 그물이 팽팽할 때 보상
public float netMaxLength = 50f;  // 그물 최대 길이 (m)
public float netOptimalMinRatio = 0.90f;  // 최적 거리 비율 (최소)
public float netOptimalMaxRatio = 0.95f;  // 최적 거리 비율 (최대)
public float netTensionTolerance = 0.05f;  // 허용 오차

// 전술 기동 (⚠️ 보상 값 감소)
public float perpendicularInterceptReward = 0.0005f;  // 기존 0.005 → 0.0005 (10배 감소)
public float perpendicularAngleTolerance = 15f;  // 75~105도
public float trackingGainReward = 0.0002f;  // 기존 0.001 → 0.0002 (5배 감소)

// 안전 및 제약
public float collisionPenalty = -1.0f;  // 아군-아군, 아군-모선 충돌
public float motherShipCollisionPenalty = -1.75f;  // 적군-모선 충돌 (Game Over)
public float formationBreakPenalty = -0.05f;
public float maxFormationDistance = 100f;
public float maxFormationAngleDiff = 90f;
```

#### 수정할 메서드:
- `CollectObservations()` - 관측값 수집 로직 재구현
  - 자신 상태 (4개)
  - 팀원 상태 (4개)
  - 적군들 상태 (4 × 적군수)
  - 모선 상대거리 (3개: 상대 x, z, 총 거리)
- `OnActionReceived()` - 목표 속도 기반 액션 처리로 변경
  - 목표 선속도와 목표 각속도 수신
  - 속도 제어 컨트롤러를 통한 throttle/steering 변환
  - ⚠️ **개별 보상 제거**: `this.AddReward()` 호출 제거
- `Heuristic()` - 휴리스틱 메서드 수정
  - 키보드 입력을 목표 속도로 변환
  - HumanController와 유사한 방식으로 동작
- `CalculateReward()` - ⚠️ **제거 또는 비활성화**
  - 개별 보상 계산 로직을 `DefenseRewardCalculator`로 이동
  - 또는 빈 메서드로 유지 (호환성)

#### 추가할 메서드 (DefenseAgent):
- `SortEnemiesByDistance()` - 적군을 거리순으로 정렬 (학습 속도 향상)
- `ConvertToLocalCoordinates()` - 절대 좌표를 상대 좌표(로컬 좌표계)로 변환
- `ConvertTargetVelocityToThrottle()` - 목표 선속도를 throttle로 변환
- `ConvertTargetAngularVelocityToSteering()` - 목표 각속도를 steering으로 변환
- `ApplyAccelerationLimits()` - 목표 속도에 가속도 제한 적용
- `OnCollisionEnter()` - 충돌 감지 (EnvController에 알림)

#### 추가할 메서드 (DefenseRewardCalculator):
- `CalculateCooperativeRewards()` - 헤딩/속도/간격 동기화, 그물 장력 계산
- `CalculateNetTensionReward()` - 그물 장력 보상 계산
- `CalculateTacticalRewards()` - 수직 차단, 추적 이득 계산
- `CalculateMissionRewards()` - 임무 성과 보상 (포획, 모선 방어 등)
- `CalculateSafetyPenalties()` - 충돌, 대형 붕괴 등 페널티 계산
- `GetAgentStates()` - 두 에이전트의 현재 상태 수집

#### 추가할 메서드 (DefenseEnvController):
- `Update()` - 매 프레임 보상 계산 및 그룹 보상 분배
- `DistributeGroupReward()` - `m_AgentGroup.AddGroupReward()` 호출
- `OnEpisodeBegin()` - 에피소드 시작 시 초기화
- `RegisterAgent()` - 에이전트 등록
- `OnMotherShipCollision()` - 모선 충돌 감지 및 처리 (Game Over)

---

### 3.2 DefenseBoatManager.cs 개선

#### 추가할 필드:
```csharp
[Header("Mother Ship Defense")]
public GameObject motherShip;
public float motherShipDefenseRadius = 1000f;  // 1km
private bool _enemyEnteredDefenseZone = false;

[Header("Collision Detection")]
public DefenseEnvController envController;  // 모선 충돌 알림용
```

#### 추가할 메서드:
- `CheckMotherShipDefense()` - 모선 방어 성공 체크
- `CheckEnemyPosition()` - 적 위치 추적 (경계선 침범 감지)
- `OnMotherShipCollision()` - 모선 충돌 감지 (적군-모선 충돌 체크)
  - 모선에 `OnCollisionEnter()` 또는 `OnTriggerEnter()` 추가
  - 충돌 대상이 `attack_boat` 태그인지 확인
  - `envController.OnMotherShipCollision()` 호출

---

### 3.3 새로운 스크립트

#### MotherShipCollisionDetector.cs (필수) ⚠️
- **목적**: 모선과 적군 선박의 충돌을 감지
- **역할**:
  - 모선 GameObject에 부착
  - `OnCollisionEnter()` 또는 `OnTriggerEnter()`로 충돌 감지
  - 적군 태그(`attack_boat`) 확인
  - `DefenseEnvController`에 충돌 알림
- **구현 위치**: 모선 GameObject에 컴포넌트로 추가

#### DefenseRewardCalculator.cs (필수) ⚠️
- **목적**: 보상 계산 로직을 중앙화하여 그룹 보상 분배
- **역할**:
  - 두 에이전트의 상태를 모두 관찰
  - 협동 기동, 전술 기동, 그물 장력 등을 계산
  - `SimpleMultiAgentGroup.AddGroupReward()`를 통해 그룹 전체에 보상 분배
- **주요 메서드**:
  - `CalculateCooperativeRewards()` - 헤딩/속도/간격 동기화, 그물 장력
  - `CalculateTacticalRewards()` - 수직 차단, 추적 이득
  - `CalculateMissionRewards()` - 임무 성과 (포획, 모선 방어 등)
  - `CalculateSafetyPenalties()` - 충돌, 대형 붕괴 등

#### DefenseEnvController.cs (필수) ⚠️
- **목적**: 환경 전체를 관리하고 그룹 보상을 분배하는 컨트롤러
- **역할**:
  - `SimpleMultiAgentGroup` 참조 관리
  - `DefenseRewardCalculator`를 통한 보상 계산 및 분배
  - 에피소드 관리 및 리셋
- **주요 메서드**:
  - `Update()` - 매 프레임 보상 계산 및 분배
  - `OnEpisodeBegin()` - 에피소드 시작 시 초기화
  - `DistributeGroupReward()` - 그룹 전체에 보상 분배

#### 구현 예시 코드

**DefenseRewardCalculator.cs**:
```csharp
using UnityEngine;
using Unity.MLAgents;

namespace BoatAttack
{
    public class DefenseRewardCalculator : MonoBehaviour
    {
        [Header("Reward Parameters")]
        public float headingSyncReward = 0.0002f;
        public float headingSyncTolerance = 15f;
        public float speedSyncReward = 0.0002f;
        public float speedSyncTolerance = 2f;
        public float distanceMaintainReward = 0.0002f;
        public float optimalDistance = 50f;
        public float distanceTolerance = 5f;
        public float netTensionReward = 0.0005f;
        public float netMaxLength = 50f;
        public float netOptimalMinRatio = 0.90f;
        public float netOptimalMaxRatio = 0.95f;
        
        public struct AgentState
        {
            public Vector3 position;
            public float heading;
            public float speed;
            public Rigidbody rb;
        }
        
        public float CalculateCooperativeRewards(AgentState agent1, AgentState agent2)
        {
            float totalReward = 0f;
            
            // 1. 헤딩 동기화
            float headingDiff = Mathf.Abs(Mathf.DeltaAngle(agent1.heading, agent2.heading));
            if (headingDiff <= headingSyncTolerance)
                totalReward += headingSyncReward;
            
            // 2. 속도 동기화
            float speedDiff = Mathf.Abs(agent1.speed - agent2.speed);
            if (speedDiff <= speedSyncTolerance)
                totalReward += speedSyncReward;
            
            // 3. 간격 유지
            float distance = Vector3.Distance(agent1.position, agent2.position);
            float distanceError = Mathf.Abs(distance - optimalDistance);
            if (distanceError <= distanceTolerance)
                totalReward += distanceMaintainReward;
            
            // 4. 그물 장력 (Net Tension)
            float optimalMin = netMaxLength * netOptimalMinRatio;
            float optimalMax = netMaxLength * netOptimalMaxRatio;
            if (distance >= optimalMin && distance <= optimalMax)
            {
                // 최적 범위 내에서 거리에 따라 보상 조정
                float centerDistance = (optimalMin + optimalMax) / 2f;
                float distanceFromCenter = Mathf.Abs(distance - centerDistance);
                float maxDeviation = (optimalMax - optimalMin) / 2f;
                float tensionFactor = 1f - (distanceFromCenter / maxDeviation);
                totalReward += netTensionReward * tensionFactor;
            }
            
            return totalReward;
        }
        
        public AgentState GetAgentState(DefenseAgent agent)
        {
            AgentState state = new AgentState
            {
                position = agent.transform.position,
                heading = agent.transform.eulerAngles.y,
                rb = agent.GetComponent<Rigidbody>()
            };
            state.speed = state.rb != null ? state.rb.velocity.magnitude : 0f;
            return state;
        }
    }
}
```

**DefenseEnvController.cs**:
```csharp
using UnityEngine;
using Unity.MLAgents;

namespace BoatAttack
{
    public class DefenseEnvController : MonoBehaviour
    {
        [Header("Agents")]
        public DefenseAgent defenseAgent1;
        public DefenseAgent defenseAgent2;
        
        [Header("Components")]
        public SimpleMultiAgentGroup m_AgentGroup;
        public DefenseRewardCalculator rewardCalculator;
        
        [Header("Settings")]
        [Tooltip("보상 계산 주기 (프레임 단위)")]
        public int rewardCalculationInterval = 1;  // 매 프레임
        
        private int _frameCount = 0;
        
        private void Start()
        {
            // SimpleMultiAgentGroup 초기화
            if (m_AgentGroup == null)
                m_AgentGroup = GetComponent<SimpleMultiAgentGroup>();
            
            // 에이전트 등록
            if (m_AgentGroup != null)
            {
                m_AgentGroup.RegisterAgent(defenseAgent1);
                m_AgentGroup.RegisterAgent(defenseAgent2);
            }
            
            // RewardCalculator 초기화
            if (rewardCalculator == null)
                rewardCalculator = GetComponent<DefenseRewardCalculator>();
        }
        
        private void Update()
        {
            _frameCount++;
            
            // 보상 계산 주기 확인
            if (_frameCount % rewardCalculationInterval != 0)
                return;
            
            if (defenseAgent1 == null || defenseAgent2 == null || 
                rewardCalculator == null || m_AgentGroup == null)
                return;
            
            // 1. 관측: 두 에이전트의 상태 수집
            var agent1State = rewardCalculator.GetAgentState(defenseAgent1);
            var agent2State = rewardCalculator.GetAgentState(defenseAgent2);
            
            // 2. 계산: 협동 기동 보상 계산
            float cooperativeReward = rewardCalculator.CalculateCooperativeRewards(
                agent1State, agent2State);
            
            // 3. 부여: 그룹 전체에 보상 분배
            if (cooperativeReward > 0f)
                m_AgentGroup.AddGroupReward(cooperativeReward);
        }
        
        public void OnEnemyCaptured(Vector3 enemyPosition)
        {
            // 포획 성공 보상 (그룹 보상)
            float captureReward = 1.0f;
            // 위치 보너스 계산...
            m_AgentGroup.AddGroupReward(captureReward);
        }
        
        /// <summary>
        /// 모선 충돌 감지 및 처리 (Game Over)
        /// </summary>
        public void OnMotherShipCollision(GameObject enemyBoat)
        {
            if (m_AgentGroup == null)
                return;
            
            // 큰 패널티 부여 (그룹 보상)
            float penalty = -1.75f;  // -1.5 ~ -2.0 범위에서 조정 가능
            m_AgentGroup.AddGroupReward(penalty);
            
            // 즉시 에피소드 종료
            m_AgentGroup.EndGroupEpisode();
            
            Debug.Log($"[DefenseEnvController] 모선 충돌! Game Over. 패널티: {penalty}");
        }
    }
}
```

---

## 4. 구현 단계

### Phase 0: 관측값 및 액션 구조 개선 (최우선)
0. ⚠️ 관측값 구조 재설계 및 구현
   - 적군 선박 배열 필드 추가
   - `CollectObservations()` 메서드 재구현
   - **상대 좌표 기반 관측으로 변경** (일반화 성능 향상)
   - 모선 상대거리 계산 로직 추가
   - **적군 거리 기반 정렬 로직 추가** (학습 속도 향상)
   - Behavior Config의 Observation Space 크기 조정
0-1. ⚠️ 액션 공간 변경 (목표 속도 기반)
   - `OnActionReceived()` 메서드 수정
   - 목표 선속도/각속도를 throttle/steering으로 변환하는 로직 구현
   - **가속도 제한 및 스무딩 강화** (물리적 한계 고려)
   - 속도 제어 컨트롤러 구현 (PID 또는 비례 제어)
   - `HumanController`와 유사한 방식으로 Engine 제어
   - Behavior Config의 Action Space 크기 확인 (2개 유지)
0-2. ⚠️ 보상 아키텍처 변경 (개별 → 그룹 보상) ⚠️ 최우선
   - `DefenseRewardCalculator.cs` 생성 및 구현
   - `DefenseEnvController.cs` 생성 및 구현
   - `SimpleMultiAgentGroup` 설정 및 등록
   - `DefenseAgent.CalculateReward()`에서 개별 보상 제거
   - 모든 보상을 `m_AgentGroup.AddGroupReward()`로 변경
   - 그물 장력(Net Tension) 보상 추가
0-3. ⚠️ 보상 값 재조정 (보상 해킹 방지)
   - 협동 기동 보상 값 대폭 감소 (0.01 → 0.0002)
   - 전술 기동 보상 값 감소 (0.005 → 0.0005, 0.001 → 0.0002)
   - 그물 장력 보상 추가 (0.0005)
   - 보상 비율 검증 (최종 목표가 협동 보상 누적합보다 10배 이상 커야 함)

### Phase 1: 기본 보상 체계 구현 (우선순위 높음)
1. ✅ 적 포획 성공 보상 조정 (1.0)
2. ⚠️ 포획 위치 기반 보너스 구현 (그물 중심 포획 보상)
3. ⚠️ 모선 방어 성공 보상 구현
4. ⚠️ 방어선 침범 패널티 구현
5. ⚠️ 충돌 감지 및 패널티 구현 (아군-아군, 아군-모선)
6. ⚠️ **모선 충돌 패널티 구현 (Game Over)** ⚠️ 최우선
   - 적군-모선 충돌 감지
   - 즉시 에피소드 종료 및 큰 패널티 (-1.5 ~ -2.0)
   - 그룹 보상으로 분배

### Phase 2: 협동 기동 보상 (우선순위 중)
5. ⚠️ 헤딩 동기화 보상 구현
6. ⚠️ 속도 동기화 보상 구현
7. ⚠️ 간격 유지 보상 구현 (기존 페널티 개선)

### Phase 3: 전술 기동 보상 (우선순위 낮음)
8. ⚠️ 수직 차단 보상 구현
9. ⚠️ 추적 이득 보상 구현

### Phase 4: 안전 및 제약 (우선순위 높음)
10. ⚠️ 대형 붕괴 패널티 구현
11. ✅ 시간 패널티 확인 및 조정

### Phase 5: 테스트 및 최적화
12. 보상 값 튜닝
13. 학습 성능 검증
14. 디버깅 및 로깅 개선

---

## 5. ML-Agents 설정

### 5.1 Behavior Config 설정
- **Algorithm**: PPO
- **Multi-Agent**: 두 에이전트가 동일한 Behavior 사용 (Shared Policy)
- **⚠️ 중요: SimpleMultiAgentGroup 설정**
  - Unity Scene에 `SimpleMultiAgentGroup` 컴포넌트 추가
  - 두 `DefenseAgent`를 그룹에 등록
  - `DefenseEnvController`가 그룹 참조를 통해 `AddGroupReward()` 호출
- **Hyperparameters**:
  - Learning Rate: 3e-4
  - Batch Size: 128
  - Buffer Size: 2048
  - Beta (entropy): 0.01
  - Epsilon (clipping): 0.2
  - Lambda (GAE): 0.95
  - Gamma (discount): 0.99

### 5.2 Observation Space
- **새로운 관측 구조** (동적 크기):
  - **자신의 상태** (4개):
    - 위치 (x, z) - 정규화: /100
    - 헤딩 (y축 회전) - 정규화: 0~360 → 0~1
    - 속도 (magnitude) - 정규화: /20
  - **팀원(파트너) 선박 상태** (4개):
    - 위치 (x, z) - 정규화: /100
    - 헤딩 (y축 회전) - 정규화: 0~360 → 0~1
    - 속도 (magnitude) - 정규화: /20
  - **적군 선박들** (인스펙터에 할당된 개수만큼, 각 4개):
    - 위치 (x, z) - 정규화: /100
    - 헤딩 (y축 회전) - 정규화: 0~360 → 0~1
    - 속도 (magnitude) - 정규화: /20
    - **최대 적군 수 제한**: 예) 최대 5대까지 지원 (총 20개)
    - 적군이 없거나 할당되지 않은 경우 0으로 채움
  - **모선 상대거리** (1개 또는 3개):
    - 옵션 1: 총 거리만 (1개) - 정규화: /1000
    - 옵션 2: 상대 위치 벡터 (x, z, 거리) (3개) - 권장
    - 모선이 없으면 0으로 채움
  
- **총 관측 개수**: 4 + 4 + (4 × 적군수) + 3 = **11 + (4 × 적군수)**
  - 예: 적군 1대 → 15개
  - 예: 적군 3대 → 23개
  - 예: 적군 5대 → 31개

- **구현 방법**:
  - `DefenseAgent`에 `public GameObject[] enemyShips` 배열 필드 추가
  - 인스펙터에서 적군 선박들을 할당
  - `CollectObservations()`에서 배열 순회하며 관측값 추가
  - 최대 적군 수를 상수로 정의하여 관측 공간 크기 고정

- **구현 예시 코드** (⚠️ 상대 좌표 기반으로 개선):
```csharp
public override void CollectObservations(VectorSensor sensor)
{
    Vector3 myPos = transform.position;
    Vector3 myForward = transform.forward;
    float myAngle = transform.eulerAngles.y;
    
    // 1. 자신의 상태 (4개) - 절대 좌표 유지 (기준점)
    sensor.AddObservation(myPos.x / 100f);
    sensor.AddObservation(myPos.z / 100f);
    sensor.AddObservation(myAngle / 360f);
    sensor.AddObservation(_engine.RB.velocity.magnitude / 20f);
    
    // 2. 팀원(파트너) 상태 (4개) - ⚠️ 상대 좌표로 변경
    if (partnerAgent != null)
    {
        Vector3 relativeToPartner = partnerAgent.transform.position - myPos;
        // 상대 위치를 로컬 좌표계로 변환
        float relativeX = Vector3.Dot(relativeToPartner, transform.right) / 100f;
        float relativeZ = Vector3.Dot(relativeToPartner, transform.forward) / 100f;
        float relativeDistance = relativeToPartner.magnitude / 100f;
        float relativeAngle = Mathf.DeltaAngle(myAngle, partnerAgent.transform.eulerAngles.y) / 180f;  // -1~1
        
        sensor.AddObservation(relativeX);
        sensor.AddObservation(relativeZ);
        sensor.AddObservation(relativeAngle);
        sensor.AddObservation(partnerAgent._engine.RB.velocity.magnitude / 20f);
    }
    else { /* 0으로 채움 */ }
    
    // 3. 적군 선박들 (4 × maxEnemyCount) - ⚠️ 거리 기반 정렬 + 상대 좌표
    // 먼저 적군을 거리순으로 정렬
    List<(GameObject enemy, float distance)> sortedEnemies = new List<(GameObject, float)>();
    for (int i = 0; i < enemyShips.Length && i < maxEnemyCount; i++)
    {
        if (enemyShips[i] != null)
        {
            float dist = Vector3.Distance(myPos, enemyShips[i].transform.position);
            sortedEnemies.Add((enemyShips[i], dist));
        }
    }
    sortedEnemies.Sort((a, b) => a.distance.CompareTo(b.distance));  // 가까운 순으로 정렬
    
    // 정렬된 적군을 관측값에 추가
    for (int i = 0; i < maxEnemyCount; i++)
    {
        if (i < sortedEnemies.Count)
        {
            GameObject enemy = sortedEnemies[i].enemy;
            Vector3 relativeToEnemy = enemy.transform.position - myPos;
            
            // 상대 좌표 (로컬 좌표계)
            float relativeX = Vector3.Dot(relativeToEnemy, transform.right) / 100f;
            float relativeZ = Vector3.Dot(relativeToEnemy, transform.forward) / 100f;
            float relativeDistance = relativeToEnemy.magnitude / 100f;
            float relativeAngle = Mathf.DeltaAngle(myAngle, enemy.transform.eulerAngles.y) / 180f;
            
            sensor.AddObservation(relativeX);
            sensor.AddObservation(relativeZ);
            sensor.AddObservation(relativeAngle);
            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            sensor.AddObservation(enemyRb != null ? enemyRb.velocity.magnitude / 20f : 0f);
        }
        else { /* 0으로 채움 */ }
    }
    
    // 4. 모선 상대거리 (3개) - 이미 상대 좌표
    if (motherShip != null)
    {
        Vector3 relativePos = motherShip.transform.position - myPos;
        float relativeX = Vector3.Dot(relativePos, transform.right) / 1000f;
        float relativeZ = Vector3.Dot(relativePos, transform.forward) / 1000f;
        sensor.AddObservation(relativeX);
        sensor.AddObservation(relativeZ);
        sensor.AddObservation(relativePos.magnitude / 1000f);
    }
    else { /* 0으로 채움 */ }
}
```

// 목표 속도 기반 액션 처리 예시 (⚠️ 가속도 제한 및 스무딩 강화)
public override void OnActionReceived(ActionBuffers actions)
{
    if (_engine == null || _episodeEnded)
        return;
    
    // 목표 속도 수신 (정규화된 값 -1~1)
    float targetLinearVelNormalized = actions.ContinuousActions[0];
    float targetAngularVelNormalized = actions.ContinuousActions[1];
    
    // 정규화 해제
    float targetLinearVelocity = targetLinearVelNormalized * maxLinearVelocity;
    float targetAngularVelocity = targetAngularVelNormalized * maxAngularVelocity;
    
    // 현재 속도 측정
    float currentLinearVelocity = Vector3.Dot(_engine.RB.velocity, transform.forward);
    float currentAngularVelocity = _engine.RB.angularVelocity.y * Mathf.Rad2Deg;
    
    // ⚠️ 가속도 제한 적용 (물리적 한계 고려)
    float maxLinearAcceleration = 5f;  // m/s² (물리적으로 가능한 최대 가속도)
    float maxAngularAcceleration = 45f;  // deg/s²
    
    // 이전 목표 속도 저장 (가속도 제한 계산용)
    float prevTargetLinearVel = _lastTargetLinearVelocity;
    float prevTargetAngularVel = _lastTargetAngularVelocity;
    
    // 목표 속도 변화량 제한
    float deltaTime = Time.fixedDeltaTime;
    float maxLinearVelChange = maxLinearAcceleration * deltaTime;
    float maxAngularVelChange = maxAngularAcceleration * deltaTime;
    
    targetLinearVelocity = Mathf.Clamp(targetLinearVelocity, 
        prevTargetLinearVel - maxLinearVelChange, 
        prevTargetLinearVel + maxLinearVelChange);
    targetAngularVelocity = Mathf.Clamp(targetAngularVelocity,
        prevTargetAngularVel - maxAngularVelChange,
        prevTargetAngularVel + maxAngularVelChange);
    
    _lastTargetLinearVelocity = targetLinearVelocity;
    _lastTargetAngularVelocity = targetAngularVelocity;
    
    // 속도 차이 계산 및 throttle/steering 변환
    float velocityError = targetLinearVelocity - currentLinearVelocity;
    float throttle = Mathf.Clamp(velocityError * velocityControlGain / maxLinearVelocity, -1f, 1f);
    
    float angularVelocityError = targetAngularVelocity - currentAngularVelocity;
    float steering = Mathf.Clamp(angularVelocityError * angularVelocityControlGain / maxAngularVelocity, -1f, 1f);
    
    // ⚠️ 스무스 처리 강화 (더 보수적으로)
    float smoothFactor = 0.1f;  // 기존 inputSmoothing보다 더 작게 (더 부드럽게)
    _smoothThrottle = Mathf.Lerp(_smoothThrottle, throttle, smoothFactor);
    _smoothSteering = Mathf.Lerp(_smoothSteering, steering, smoothFactor);
    
    // Engine 제어
    _engine.Accelerate(Mathf.Clamp01(_smoothThrottle));  // throttle은 0~1 범위
    _engine.Turn(_smoothSteering * steeringSensitivity);
    
    // 보상 계산
    CalculateReward();
}

// 추가 필드 필요
private float _lastTargetLinearVelocity = 0f;
private float _lastTargetAngularVelocity = 0f;

// 휴리스틱 메서드 예시 (HumanController 방식)
// ⚠️ Unity의 새로운 Input System 사용 (UnityEngine.InputSystem)
using UnityEngine.InputSystem;

public override void Heuristic(in ActionBuffers actionsOut)
{
    var continuousActions = actionsOut.ContinuousActions;
    
    // Unity Input System 사용 (Legacy Input 대신)
    Keyboard keyboard = Keyboard.current;
    if (keyboard == null)
    {
        continuousActions[0] = 0f;
        continuousActions[1] = 0f;
        return;
    }
    
    // 키보드 입력을 목표 속도로 변환
    float targetLinearVel = 0f;
    float targetAngularVel = 0f;
    
    // Agent 이름으로 구분
    if (gameObject.name.Contains("1"))
    {
        // WASD
        if (keyboard.wKey.isPressed)
            targetLinearVel = maxLinearVelocity;  // 전진
        else if (keyboard.sKey.isPressed)
            targetLinearVel = -maxLinearVelocity * 0.5f;  // 후진 (느리게)
        
        if (keyboard.dKey.isPressed)
            targetAngularVel = maxAngularVelocity;  // 우회전
        else if (keyboard.aKey.isPressed)
            targetAngularVel = -maxAngularVelocity;  // 좌회전
    }
    else if (gameObject.name.Contains("2"))
    {
        // Arrow Keys
        if (keyboard.upArrowKey.isPressed)
            targetLinearVel = maxLinearVelocity;
        else if (keyboard.downArrowKey.isPressed)
            targetLinearVel = -maxLinearVelocity * 0.5f;
        
        if (keyboard.rightArrowKey.isPressed)
            targetAngularVel = maxAngularVelocity;
        else if (keyboard.leftArrowKey.isPressed)
            targetAngularVel = -maxAngularVelocity;
    }
    
    // 정규화 (-1~1)
    if (maxLinearVelocity > 0.01f)
        continuousActions[0] = Mathf.Clamp(targetLinearVel / maxLinearVelocity, -1f, 1f);
    else
        continuousActions[0] = 0f;
        
    if (maxAngularVelocity > 0.01f)
        continuousActions[1] = Mathf.Clamp(targetAngularVel / maxAngularVelocity, -1f, 1f);
    else
        continuousActions[1] = 0f;
}
```

### 5.3 Action Space
- **변경 사항**: 목표 속도 기반 액션으로 변경
  - **기존**: `actions[0]`: throttle (-1~1), `actions[1]`: steering (-1~1)
  - **신규**: `actions[0]`: 목표 선속도 (target linear velocity, -maxSpeed~maxSpeed)
  - **신규**: `actions[1]`: 목표 각속도 (target angular velocity, -maxAngularSpeed~maxAngularSpeed)
  - **정규화**: 
    - 목표 선속도: 예) -20~20 m/s → -1~1로 정규화
    - 목표 각속도: 예) -90~90 deg/s → -1~1로 정규화
- **구현 방법**:
  - `OnActionReceived()`에서 목표 속도 수신
  - 목표 속도를 실제 throttle/steering으로 변환하는 컨트롤러 필요
  - PID 컨트롤러 또는 비례 제어를 사용하여 목표 속도 달성
  - `HumanController`와 유사한 방식으로 Engine 제어

### 5.4 Behavior Config 설정 주의사항
- **Observation Space 크기**: 
  - 공식: `11 + (4 × maxEnemyCount)`
  - 예: maxEnemyCount = 5 → 31개
  - Unity ML-Agents Behavior Config에서 이 값으로 설정 필요
- **동적 적군 수 대응**:
  - 인스펙터에서 할당되지 않은 적군은 0으로 채움
  - 학습 시 항상 동일한 크기의 관측값 보장

---

## 6. 디버깅 및 모니터링

### 6.1 보상 추적
- 각 보상 카테고리별 누적 보상 표시
- Unity Inspector에서 실시간 확인 가능하도록

### 6.2 로깅
- 주요 이벤트 로깅 (포획, 충돌, 경계선 침범 등)
- **모선 충돌 이벤트 로깅** (Game Over 이벤트) ⚠️ 중요
- 보상 분포 분석용 CSV 출력 (선택사항)

### 6.3 시각화
- Gizmo로 경계선 표시
- 보상 히트맵 (선택사항)

---

## 7. 예상 결과

### 7.1 학습 목표
- 두 에이전트가 협력하여 적을 포획
- 모선 방어 성공률 향상
- 안전한 기동 (충돌 최소화)

### 7.2 성능 지표
- 포획 성공률
- 평균 포획 위치 (그물 중심으로부터 거리)
- 중심 포획 비율 (중심 10m 이내 포획 비율)
- 평균 에피소드 길이
- 충돌 발생률 (아군-아군, 아군-모선)
- **모선 충돌 발생률** (적군-모선, Game Over 비율) ⚠️ 중요
- 모선 방어 성공률

---

## 8. 다음 단계

1. **즉시 구현**: Phase 1 (임무 성과 + 안전)
2. **단계적 구현**: Phase 2, 3 (협동/전술 기동)
3. **튜닝**: 보상 값 최적화
4. **검증**: 학습 성능 평가

---

## 9. 참고사항

- 보상 값은 학습 과정에서 조정 필요
- Multi-Agent 환경에서는 보상 신호가 서로 영향을 줄 수 있음
- 경계선 침범 감지는 성능에 영향을 줄 수 있으므로 최적화 필요
- 그물(Web)의 실제 물리적 구현 확인 필요 (DynamicWeb.cs 참조)
- **포획 위치 보너스**: 그물 중심 포획을 유도하여 더 정확한 협동 기동 학습 유도
  - 중심 포획은 두 에이전트의 균형잡힌 협력이 필요함
  - 보너스 값은 학습 성과에 따라 조정 가능 (0.1~0.5 범위 권장)
- **관측값 구조**:
  - 적군 선박은 인스펙터에서 동적으로 할당 가능
  - 최대 적군 수는 고정하여 관측 공간 크기 일관성 유지
  - 모선은 상대거리만 사용하여 절대 위치 의존성 제거
  - 관측값 정규화는 학습 안정성을 위해 중요함
- **액션 공간 변경 (목표 속도 기반)**:
  - 기존 throttle/steering 직접 제어 → 목표 선속도/각속도 제어로 변경
  - `HumanController`와 유사한 방식으로 동작하도록 구현
  - 목표 속도를 실제 throttle/steering으로 변환하는 컨트롤러 필요
  - 속도 제어 게인은 튜닝이 필요할 수 있음
  - 학습 시 더 부드러운 기동이 가능하며, 속도 기반 보상 설계가 용이함
- **그물 장력 (Net Tension)**:
  - 두 배가 너무 멀어지면 그물이 끊어지고, 너무 가까워지면 엉킴
  - 그물 길이의 90~95% 수준에서 최대 보상 부여
  - 방어 면적 최대화를 위한 중요한 보상
  - 간격 유지 보상과 함께 작동하여 최적 거리 유지 유도
- **모선 충돌 패널티 (Game Over)**:
  - 적군 선박이 모선에 충돌하는 것은 단순 실점이 아닌 **패배**
  - 즉시 에피소드 종료 및 큰 패널티 (-1.5 ~ -2.0) 부여
  - 아군 충돌 패널티(-1.0)보다 더 큰 값으로 최악의 결과임을 명확히 전달
  - 모선 방어가 최우선 목표임을 학습에 반영
  - 그룹 보상으로 분배하여 두 에이전트 모두 패배를 인지

---

## 10. 공학적 위험 요소 및 개선 사항 ⚠️

### 10.1 보상 값의 수치적 균형 문제 (최우선)

#### 문제점
- **보상 해킹(Reward Hacking) 위험**: 협동 기동 보상(+0.01)이 매 스텝 부여되면 최종 목표(+1.0)를 압도
- **예시**: 에피소드 25,000 스텝 중 1,000 스텝만 동기화해도 `1,000 × 0.01 = 10.0` 보상
- **결과**: 에이전트가 "적을 잡으러 가는 리스크를 감수하느니, 그냥 우리끼리 춤추면서 시간을 끌자"라는 전략에 빠질 수 있음

#### 해결책
- ✅ **스텝당 보상 대폭 감소**: 0.01 → **0.0001~0.0005** (20~100배 감소)
- ✅ **상태 보상 방식**: 특정 오차 범위 내에 있을 때만 아주 미세하게 부여
- ✅ **보상 비율 조정**: 최종 목표 보상이 협동 보상의 누적합보다 압도적으로 커야 함

#### 수정된 보상 값
| 항목 | 원래 계획 | 수정 후 | 비율 |
|------|----------|---------|------|
| 헤딩 동기화 | +0.01 | +0.0002 | 50배 감소 |
| 속도 동기화 | +0.01 | +0.0002 | 50배 감소 |
| 간격 유지 | +0.01 | +0.0002 | 50배 감소 |
| 수직 차단 | +0.005 | +0.0005 | 10배 감소 |
| 추적 이득 | +0.001 | +0.0002 | 5배 감소 |

---

### 10.2 절대 좌표 vs 상대 좌표 (일반화 성능)

#### 문제점
- **절대 좌표 의존성**: `sensor.AddObservation(myPos.x / 100f)`와 같이 절대 좌표 사용
- **위험 요소**: AI가 특정 지도의 특정 좌표에 의존하게 됨
- **결과**: 모선이 이동하거나 훈련 구역이 바뀌면 성능 저하

#### 해결책
- ✅ **상대 좌표(Relative Coordinates) 적극 활용**
  - 나-파트너 사이의 벡터 (로컬 좌표계)
  - 나-적군 사이의 벡터 (로컬 좌표계)
  - 나-모선 사이의 벡터 (로컬 좌표계)
- ✅ **로컬 좌표계 변환**: `Vector3.Dot(relativePos, transform.right/forward)` 사용
- ✅ **일반화 성능 향상**: 어디서든 싸울 수 있는 지능 확보

#### 구현 예시
```csharp
// 절대 좌표 (기존)
sensor.AddObservation(partnerPos.x / 100f);
sensor.AddObservation(partnerPos.z / 100f);

// 상대 좌표 (개선)
Vector3 relativeToPartner = partnerAgent.transform.position - transform.position;
float relativeX = Vector3.Dot(relativeToPartner, transform.right) / 100f;
float relativeZ = Vector3.Dot(relativeToPartner, transform.forward) / 100f;
sensor.AddObservation(relativeX);
sensor.AddObservation(relativeZ);
```

---

### 10.3 적군 관측의 우선순위 정렬 부재

#### 문제점
- **배열 순서 의존성**: `enemyShips` 배열을 그대로 관측값에 추가
- **위험 요소**: 
  - 배열 순서가 바뀌면 AI 혼란
  - 1번 적이 멀고 2번 적이 가까울 때, 인덱스 순서대로 관측하면 불필요한 연산 소모
- **결과**: 학습 속도 저하 및 비효율적 전략 학습

#### 해결책
- ✅ **거리 기반 정렬(Sorting)**: 관측 전에 '나와 가까운 순서'로 정렬
- ✅ **모선 거리 기반 정렬**: '모선과 가까운 순서'로 정렬 (선택적)
- ✅ **학습 속도 향상**: AI가 위험한 적을 우선적으로 인식

#### 구현 예시
```csharp
// 거리순 정렬
List<(GameObject enemy, float distance)> sortedEnemies = new List<(GameObject, float)>();
for (int i = 0; i < enemyShips.Length; i++)
{
    if (enemyShips[i] != null)
    {
        float dist = Vector3.Distance(transform.position, enemyShips[i].transform.position);
        sortedEnemies.Add((enemyShips[i], dist));
    }
}
sortedEnemies.Sort((a, b) => a.distance.CompareTo(b.distance));  // 가까운 순으로 정렬
```

---

### 10.4 속도 기반 액션의 물리적 한계 간과

#### 문제점
- **물리 엔진 한계**: USV는 회전 반경(Turning Radius)과 관성이 큼
- **위험 요소**: RL이 "즉각적으로 90도 회전해서 시속 20m/s로 가라"고 명령했을 때, 물리 엔진이 따라가지 못함
- **결과**: RL이 자신이 내린 액션과 결과 사이의 상관관계를 이해하지 못함

#### 해결책
- ✅ **가속도 제한(Acceleration Limit)**: 물리적으로 가능한 수준의 명령만 전달
- ✅ **스무딩 강화**: `inputSmoothing`보다 더 보수적인 값 사용 (예: 0.1)
- ✅ **목표 속도 변화량 제한**: 이전 목표 속도와의 차이를 제한

#### 구현 예시
```csharp
// 가속도 제한 적용
float maxLinearAcceleration = 5f;  // m/s²
float maxAngularAcceleration = 45f;  // deg/s²

float maxLinearVelChange = maxLinearAcceleration * deltaTime;
targetLinearVelocity = Mathf.Clamp(targetLinearVelocity,
    prevTargetLinearVel - maxLinearVelChange,
    prevTargetLinearVel + maxLinearVelChange);
```

---

### 10.5 개별 보상 vs 그룹 보상 (MA-PPO 최적화) ⚠️ 최우선

#### 문제점
- **개별 보상 방식의 한계**: 각 에이전트가 `this.AddReward()`로 개별적으로 보상을 받음
- **위험 요소**:
  - 파트너 배는 내가 왜 점수를 받았는지 모름
  - 이기적인 에이전트가 될 확률 높음
  - 협동을 위한 개별 기동을 학습하기 어려움
- **예시**: A가 헤딩을 맞추면 A만 +0.01점을 받음. B는 점수를 못 받으니 왜 A가 저렇게 움직이는지 모름

#### 해결책: 그룹 보상 아키텍처
- ✅ **중앙화된 보상 계산**: `DefenseRewardCalculator`에서 두 에이전트의 상태를 모두 관찰
- ✅ **그룹 보상 분배**: `SimpleMultiAgentGroup.AddGroupReward()`를 통해 그룹 전체에 보상 분배
- ✅ **결과**: A가 B와 헤딩을 맞추면, 컨트롤러가 이를 감지하고 그룹 전체에 +0.01점을 줌. B도 "어? 우리가 지금 뭔가를 잘해서 팀 점수가 올랐네?"라고 인지하며, A와 보조를 맞추는 방향으로 정책을 업데이트

#### 보상 흐름 아키텍처

**기존 방식 (피해야 할 방식)**:
```csharp
// DefenseAgent.cs 내부
private void CalculateReward()
{
    // 개별 보상
    if (headingSync)
        this.AddReward(0.0002f);  // 나 혼자만 점수
}
```

**권장 방식 (MA-PPO 최적화)**:
```csharp
// DefenseEnvController.cs
private void Update()
{
    // 1. 관측: 두 에이전트의 상태 수집
    var agent1State = GetAgentState(defenseAgent1);
    var agent2State = GetAgentState(defenseAgent2);
    
    // 2. 계산: DefenseRewardCalculator가 협동 기동 계산
    float headingSyncReward = rewardCalculator.CalculateCooperativeRewards(
        agent1State, agent2State);
    
    // 3. 부여: 그룹 전체에 보상 분배
    if (headingSyncReward > 0)
        m_AgentGroup.AddGroupReward(headingSyncReward);  // 팀 전체 점수
}

// DefenseRewardCalculator.cs
public float CalculateCooperativeRewards(AgentState agent1, AgentState agent2)
{
    float totalReward = 0f;
    
    // 헤딩 동기화 체크
    float headingDiff = Mathf.Abs(Mathf.DeltaAngle(
        agent1.heading, agent2.heading));
    if (headingDiff <= headingSyncTolerance)
        totalReward += headingSyncReward;
    
    // 속도 동기화 체크
    float speedDiff = Mathf.Abs(agent1.speed - agent2.speed);
    if (speedDiff <= speedSyncTolerance)
        totalReward += speedSyncReward;
    
    // 그물 장력 체크
    float distance = Vector3.Distance(agent1.position, agent2.position);
    float optimalMin = netMaxLength * netOptimalMinRatio;
    float optimalMax = netMaxLength * netOptimalMaxRatio;
    if (distance >= optimalMin && distance <= optimalMax)
        totalReward += netTensionReward;
    
    return totalReward;
}
```

#### 구현 체크리스트
- [ ] `SimpleMultiAgentGroup` 컴포넌트를 Unity Scene에 추가
- [ ] 두 `DefenseAgent`를 그룹에 등록
- [ ] `DefenseRewardCalculator.cs` 생성 및 구현
- [ ] `DefenseEnvController.cs` 생성 및 구현
- [ ] `DefenseAgent.CalculateReward()`에서 개별 보상 제거
- [ ] 모든 보상을 `m_AgentGroup.AddGroupReward()`로 변경
- [ ] 그룹 보상 분배 로직 테스트

#### 비교표

| 구분 | 기존 방식 (피해야 할 방식) | 권장 방식 (MA-PPO 최적화) |
|------|------------------------|------------------------|
| 코드 위치 | DefenseAgent.cs 내부 | EnvController.cs (또는 전용 Calculator) |
| 사용 함수 | `this.AddReward(0.01f)` | `m_AgentGroup.AddGroupReward(0.01f)` |
| 보상 대상 | 나 혼자만 점수를 받음 | 내가 잘하면 우리 팀 전체가 점수를 받음 |
| 문제점 | 파트너 배는 내가 왜 점수를 받았는지 모름 | 파트너와 내가 항상 동일한 보상값을 공유함 |
| 결과 | 이기적인 에이전트가 될 확률 높음 | 협동을 위한 개별 기동을 학습함 |

---

### 10.6 추가 권장 사항

1. **보상 스케일링 검증**
   - 에피소드당 예상 보상 범위 계산
   - 최종 목표 보상이 협동 보상 누적합보다 최소 10배 이상 커야 함

2. **상대 좌표 테스트**
   - 다양한 초기 위치에서 학습 테스트
   - 모선 위치 변경 시 성능 유지 확인

3. **적군 정렬 성능 비교**
   - 정렬 전/후 학습 속도 비교
   - 최종 성능 차이 측정

4. **물리 제약 튜닝**
   - 실제 USV의 가속도/각가속도 한계 측정
   - 시뮬레이션과 실제 값 일치 확인

5. **그룹 보상 아키텍처 검증**
   - 개별 보상 vs 그룹 보상 학습 속도 비교
   - 최종 협동 성능 차이 측정
   - 그룹 보상 분배 타이밍 최적화 (매 프레임 vs 매 N 프레임)
