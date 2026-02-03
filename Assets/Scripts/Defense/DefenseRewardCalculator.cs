using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace BoatAttack
{
    /// <summary>
    /// 방어 에이전트들의 보상을 중앙에서 계산하는 클래스
    /// 그룹 보상을 계산하여 DefenseEnvController에 전달
    /// 커리큘럼 학습 단계별로 다른 보상 함수 적용
    /// </summary>
    public class DefenseRewardCalculator : MonoBehaviour
    {
        [Header("Training Stage")]
        [Tooltip("현재 학습 단계 (DefenseEnvController에서 자동 설정)")]
        public TrainingStage currentStage = TrainingStage.Stage1_Formation;

        [Header("=== Stage 1: Formation (양의 보상 + 대형붕괴 페널티) ===")]
        [Tooltip("Stage1 헤딩 동기화 보상 (최대값)")]
        public float stage1HeadingReward = 0.002f;

        [Tooltip("Stage1 속도 동기화 보상 (최대값)")]
        public float stage1SpeedSyncReward = 0.002f;

        [Tooltip("Stage1 간격 유지 보상 (최대값)")]
        public float stage1DistanceReward = 0.002f;

        [Tooltip("Stage1 속도 보상 (최대값) - 빠를수록 높음")]
        public float stage1SpeedReward = 0.002f;

        [Tooltip("Stage1 속도 보상 배수 (기본 2배, 더 키우려면 증가)")]
        [Range(1f, 10f)]
        public float stage1SpeedRewardMultiplier = 4f;  // 2 → 4배로 증가

        [Header("Stage 1 Individual Rewards (개별 보상)")]
        [Tooltip("Stage1 개별 속도 보상 (각 에이전트별로 부여)")]
        public float stage1IndividualSpeedReward = 0.02f;  // 0.001→0.02 (20배)

        [Tooltip("Stage1 선회 페널티 계수 (1도/초당 페널티량) - 변화량에 비례")]
        public float stage1SteeringPenaltyCoeff = 0.0002f;  // 100도/초에서 속도보상과 균형

        [Tooltip("Stage1 최적 거리 (m)")]
        public float stage1OptimalDistance = 50f;

        [Tooltip("Stage1 속도 보상 기준 (m/s)")]
        public float stage1SpeedThreshold = 10f;

        [Header("Stage 1 Penalties (대형 붕괴 + 정지)")]
        [Tooltip("Stage1 대형 붕괴 페널티 - 거리 초과 시")]
        public float stage1FormationDistancePenalty = -0.01f;

        [Tooltip("Stage1 최대 허용 거리 (m) - 이 거리 초과 시 페널티")]
        public float stage1MaxDistance = 100f;

        [Tooltip("Stage1 대형 붕괴 페널티 - 각도 차이 초과 시")]
        public float stage1FormationAnglePenalty = -0.01f;

        [Tooltip("Stage1 최대 허용 각도 차이 (도) - 이 각도 초과 시 페널티")]
        public float stage1MaxAngleDiff = 90f;

        [Tooltip("Stage1 정지 페널티 - 속도가 너무 낮을 때")]
        public float stage1StationaryPenalty = -0.005f;

        [Tooltip("Stage1 최소 속도 (m/s) - 이 속도 미만이면 정지 페널티")]
        public float stage1MinSpeed = 2f;

        [Header("=== Stage 2/3: Cooperative Rewards ===")]
        [Tooltip("헤딩 동기화 보상 (최대값)")]
        public float headingSyncReward = 0.001f;

        [Tooltip("헤딩 동기화 허용 범위 (도)")]
        public float headingSyncTolerance = 45f;

        [Tooltip("속도 동기화 보상 (최대값)")]
        public float speedSyncReward = 0.001f;

        [Tooltip("속도 동기화 허용 범위 (m/s)")]
        public float speedSyncTolerance = 5f;

        [Tooltip("간격 유지 보상 (최대값)")]
        public float distanceMaintainReward = 0.001f;

        [Tooltip("최적 거리 (m)")]
        public float optimalDistance = 50f;

        [Tooltip("거리 허용 범위 (m)")]
        public float distanceTolerance = 20f;

        [Header("Net Tension")]
        [Tooltip("그물 장력 보상 (최대값)")]
        public float netTensionReward = 0.001f;

        [Tooltip("그물 최대 길이 (m)")]
        public float netMaxLength = 50f;

        [Tooltip("최적 거리 비율 (최소)")]
        [Range(0.5f, 1.0f)]
        public float netOptimalMinRatio = 0.70f;

        [Tooltip("최적 거리 비율 (최대)")]
        [Range(0.5f, 1.0f)]
        public float netOptimalMaxRatio = 0.98f;

        [Header("Tactical Rewards (Stage 2+)")]
        [Tooltip("수직 차단 보상 (Stage2부터 적용)")]
        public float perpendicularInterceptReward = 0.001f;

        [Tooltip("수직 차단 각도 허용 범위 (도)")]
        public float perpendicularAngleTolerance = 30f;

        [Tooltip("추적 이득 보상 (Stage2부터 적용)")]
        public float trackingGainReward = 0.0005f;

        [Header("Speed Reward (Stage 2/3)")]
        [Tooltip("속도 보상 (빠를수록 높은 보상, 최대값)")]
        public float speedReward = 0.001f;

        [Tooltip("속도 보상 기준 속도 (m/s)")]
        public float speedRewardThreshold = 8f;

        [Header("Safety Penalties (Stage 2/3 Only)")]
        [Tooltip("충돌 패널티 (아군-아군, 아군-모선)")]
        public float collisionPenalty = -1.0f;

        [Tooltip("대형 붕괴 패널티")]
        public float formationBreakPenalty = -0.005f;

        [Tooltip("최대 대형 거리 (m)")]
        public float maxFormationDistance = 150f;

        [Tooltip("최대 대형 각도 차이 (도)")]
        public float maxFormationAngleDiff = 120f;

        [Header("Time Penalty (Stage 2/3 Only)")]
        [Tooltip("시간 패널티 (매 프레임) - Stage1에서는 적용 안 함")]
        public float timePenalty = -0.0001f;

        // 이전 스텝의 적-그물 거리 (추적 이득 계산용)
        private float _lastEnemyToWebDistance = float.MaxValue;

        /// <summary>
        /// 에이전트 상태 구조체
        /// </summary>
        public struct AgentState
        {
            public Vector3 position;
            public float heading;
            public float speed;
            public Rigidbody rb;
            public Transform transform;
        }

        /// <summary>
        /// Stage1 전용 보상 계산 - 양의 보상 + 대형붕괴/정지 페널티
        /// 방향 일치, 속도 동기화, 거리 유지, 속도에 따라 그라데이션 보상
        /// 핵심: 빠르게 움직이면서 대형 유지해야 높은 보상
        /// </summary>
        public float CalculateStage1Rewards(AgentState agent1, AgentState agent2)
        {
            float totalReward = 0f;
            float avgSpeed = (agent1.speed + agent2.speed) / 2f;

            // 1. 헤딩 동기화 (그라데이션: 완전 일치 = 최대 보상)
            // 180도 기준으로 정규화 (0도 = 1.0, 180도 = 0.0)
            float headingDiff = Mathf.Abs(Mathf.DeltaAngle(agent1.heading, agent2.heading));
            float headingFactor = 1f - (headingDiff / 180f);
            totalReward += stage1HeadingReward * headingFactor;

            // 2. 속도 동기화 (그라데이션: 속도 차이 0 = 최대 보상)
            // 단, 둘 다 움직이고 있을 때만 보상 (정지 상태 방지)
            float speedDiff = Mathf.Abs(agent1.speed - agent2.speed);
            float speedSyncFactor = Mathf.Clamp01(1f - (speedDiff / 10f));
            // 평균 속도가 최소 속도 이상일 때만 속도 동기화 보상
            if (avgSpeed >= stage1MinSpeed)
            {
                totalReward += stage1SpeedSyncReward * speedSyncFactor;
            }

            // 3. 간격 유지 (그라데이션: 최적 거리에 가까울수록 높은 보상)
            // 최적 거리에서 50m 벗어나면 0
            float distance = Vector3.Distance(agent1.position, agent2.position);
            float distanceError = Mathf.Abs(distance - stage1OptimalDistance);
            float distanceFactor = Mathf.Clamp01(1f - (distanceError / 50f));
            totalReward += stage1DistanceReward * distanceFactor;

            // 4. 속도 보상 (그라데이션: 빠를수록 높은 보상) - 배수 적용
            float speedFactor = Mathf.Clamp01(avgSpeed / stage1SpeedThreshold);
            totalReward += stage1SpeedReward * speedFactor * stage1SpeedRewardMultiplier;

            // 5. 그물 장력 (Net Tension) - Stage1에서도 적용
            float optimalMin = netMaxLength * netOptimalMinRatio;
            float optimalMax = netMaxLength * netOptimalMaxRatio;
            if (distance >= optimalMin && distance <= optimalMax)
            {
                float centerDistance = (optimalMin + optimalMax) / 2f;
                float distanceFromCenter = Mathf.Abs(distance - centerDistance);
                float maxDeviation = (optimalMax - optimalMin) / 2f;
                float tensionFactor = 1f - (distanceFromCenter / maxDeviation);
                totalReward += netTensionReward * tensionFactor;
            }

            return totalReward;
        }

        /// <summary>
        /// 개별 속도 보상 계산 (각 에이전트별로 부여)
        /// 빠를수록 높은 보상 - 모든 Stage에서 적용
        /// </summary>
        public float CalculateIndividualSpeedReward(AgentState agent)
        {
            float speedFactor = Mathf.Clamp01(agent.speed / stage1SpeedThreshold);
            return stage1IndividualSpeedReward * speedFactor;
        }

        /// <summary>
        /// 조향 페널티 계산 (각 에이전트별로 부여)
        /// 단순 선형: 선회량 × 계수 = 페널티 - 모든 Stage에서 적용
        /// </summary>
        public float CalculateSteeringStabilityReward(float currentHeading, float prevHeading, float deltaTime)
        {

            // 각도 변화량 계산 (도/초)
            float headingChange = Mathf.Abs(Mathf.DeltaAngle(currentHeading, prevHeading));
            float headingChangeRate = headingChange / Mathf.Max(deltaTime, 0.001f);

            // 단순 선형: 변화량 × 계수 = 페널티 (음수)
            // 직진(0도/초): 0
            // 10도/초: -0.02
            // 20도/초: -0.04
            return -(headingChangeRate * stage1SteeringPenaltyCoeff);
        }

        /// <summary>
        /// 협동 기동 보상 계산
        /// 모든 Stage에서 Stage1 보상 사용 (대형 유지 기반)
        /// Stage2/3: 포획 시 추가 보상 (별도 이벤트)
        /// </summary>
        public float CalculateCooperativeRewards(AgentState agent1, AgentState agent2)
        {
            // 모든 Stage에서 Stage1 보상 함수 사용
            return CalculateStage1Rewards(agent1, agent2);

            // 아래 코드는 더 이상 사용하지 않음 (Stage2 전용 보상 제거)
            /*

            float totalReward = 0f;

            // 1. 헤딩 동기화 (그라데이션)
            float headingDiff = Mathf.Abs(Mathf.DeltaAngle(agent1.heading, agent2.heading));
            if (headingDiff <= headingSyncTolerance)
            {
                float headingFactor = 1f - (headingDiff / headingSyncTolerance);
                totalReward += headingSyncReward * headingFactor;
            }

            // 2. 속도 동기화 (그라데이션)
            float speedDiff = Mathf.Abs(agent1.speed - agent2.speed);
            if (speedDiff <= speedSyncTolerance)
            {
                float speedSyncFactor = 1f - (speedDiff / speedSyncTolerance);
                totalReward += speedSyncReward * speedSyncFactor;
            }

            // 3. 간격 유지 (그라데이션)
            float distance = Vector3.Distance(agent1.position, agent2.position);
            float distanceError = Mathf.Abs(distance - optimalDistance);
            if (distanceError <= distanceTolerance)
            {
                float distanceFactor = 1f - (distanceError / distanceTolerance);
                totalReward += distanceMaintainReward * distanceFactor;
            }

            // 4. 속도 보상 (빠를수록 높은 보상)
            if (speedRewardThreshold > 0f)
            {
                float avgSpeed = (agent1.speed + agent2.speed) / 2f;
                float speedFactor = Mathf.Clamp01(avgSpeed / speedRewardThreshold);
                totalReward += speedReward * speedFactor;
            }

            // 5. 그물 장력 (Net Tension)
            float optimalMin = netMaxLength * netOptimalMinRatio;
            float optimalMax = netMaxLength * netOptimalMaxRatio;
            if (distance >= optimalMin && distance <= optimalMax)
            {
                float centerDistance = (optimalMin + optimalMax) / 2f;
                float distanceFromCenter = Mathf.Abs(distance - centerDistance);
                float maxDeviation = (optimalMax - optimalMin) / 2f;
                float tensionFactor = 1f - (distanceFromCenter / maxDeviation);
                totalReward += netTensionReward * tensionFactor;
            }

            return totalReward;
            */
        }

        /// <summary>
        /// 전술 기동 보상 계산
        /// Stage2, Stage3에서 활성화 (Stage1에서는 0 반환)
        /// 단순화: Stage2에서는 비활성화하여 포획 이벤트에만 집중
        /// </summary>
        public float CalculateTacticalRewards(AgentState agent1, AgentState agent2,
            GameObject[] enemyShips, GameObject webObject)
        {
            float totalReward = 0f;

            // Stage3에서만 전술 기동 보상 활성화 (Stage1, Stage2는 비활성)
            // Stage2는 Stage1 보상 + 포획 이벤트만 사용 (단순화)
            if (currentStage != TrainingStage.Stage3_Tactical)
            {
                return totalReward;
            }

            if (enemyShips == null || enemyShips.Length == 0 || webObject == null)
                return totalReward;

            // 가장 가까운 적군 찾기
            GameObject nearestEnemy = null;
            float minDistance = float.MaxValue;

            foreach (var enemy in enemyShips)
            {
                if (enemy == null || !enemy.activeInHierarchy) continue;

                float dist = Vector3.Distance(webObject.transform.position, enemy.transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy == null)
                return totalReward;

            // 1. 수직 차단 보상
            Vector3 netVector = agent2.position - agent1.position;
            Vector3 enemyToWeb = webObject.transform.position - nearestEnemy.transform.position;

            if (netVector.magnitude > 0.1f && enemyToWeb.magnitude > 0.1f)
            {
                float angle = Vector3.Angle(netVector, enemyToWeb);
                float angleDiff = Mathf.Abs(angle - 90f);

                if (angleDiff <= perpendicularAngleTolerance)
                {
                    float angleFactor = 1f - (angleDiff / perpendicularAngleTolerance);
                    totalReward += perpendicularInterceptReward * angleFactor;
                }
            }

            // 2. 추적 이득 (적-그물 거리 감소)
            float currentDistance = minDistance;
            if (_lastEnemyToWebDistance != float.MaxValue && currentDistance < _lastEnemyToWebDistance)
            {
                float distanceReduction = _lastEnemyToWebDistance - currentDistance;
                totalReward += trackingGainReward * (distanceReduction / 10f);
            }
            _lastEnemyToWebDistance = currentDistance;

            return totalReward;
        }

        /// <summary>
        /// 안전 및 제약 페널티 계산
        /// Stage1: 시간 패널티 없음, 대형 붕괴(거리/각도) 페널티만 적용
        /// Stage2/3: 시간 패널티 + 대형 붕괴 페널티
        /// </summary>
        public float CalculateSafetyPenalties(AgentState agent1, AgentState agent2)
        {
            float totalPenalty = 0f;
            float distance = Vector3.Distance(agent1.position, agent2.position);
            float headingDiff = Mathf.Abs(Mathf.DeltaAngle(agent1.heading, agent2.heading));

            // Stage1: 대형 붕괴 페널티 + 정지 페널티 (시간 패널티 없음)
            if (currentStage == TrainingStage.Stage1_Formation)
            {
                // 거리 초과 페널티
                if (distance > stage1MaxDistance)
                {
                    totalPenalty += stage1FormationDistancePenalty;
                }

                // 각도 차이 초과 페널티
                if (headingDiff > stage1MaxAngleDiff)
                {
                    totalPenalty += stage1FormationAnglePenalty;
                }

                // 정지 페널티 (평균 속도가 최소 속도 미만이면)
                float avgSpeed = (agent1.speed + agent2.speed) / 2f;
                if (avgSpeed < stage1MinSpeed)
                {
                    totalPenalty += stage1StationaryPenalty;
                }

                return totalPenalty;
            }

            // Stage2, Stage3: 기존 페널티 적용
            // 1. 대형 붕괴 체크
            if (distance > maxFormationDistance || headingDiff > maxFormationAngleDiff)
            {
                totalPenalty += formationBreakPenalty;
            }

            // 2. 시간 패널티
            totalPenalty += timePenalty;

            return totalPenalty;
        }

        /// <summary>
        /// 에이전트 상태 수집
        /// </summary>
        public AgentState GetAgentState(DefenseAgent agent)
        {
            if (agent == null)
            {
                return new AgentState();
            }

            AgentState state = new AgentState
            {
                position = agent.transform.position,
                heading = agent.transform.eulerAngles.y,
                transform = agent.transform
            };

            // Rigidbody에서 속도 가져오기
            Rigidbody rb = agent.GetComponent<Rigidbody>();
            if (rb != null)
            {
                state.rb = rb;
                state.speed = rb.velocity.magnitude;
            }
            else
            {
                state.speed = 0f;
            }

            return state;
        }

        /// <summary>
        /// 리셋 (에피소드 시작 시)
        /// </summary>
        public void Reset()
        {
            _lastEnemyToWebDistance = float.MaxValue;
        }
    }
}
