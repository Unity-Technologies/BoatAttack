using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 방어 에이전트들의 보상을 중앙에서 계산하는 클래스
    /// 그룹 보상을 계산하여 DefenseEnvController에 전달
    /// 커리큘럼 학습 단계별로 다른 보상 함수 적용
    ///
    /// ETA-Hys-RL 논문 기반 개선:
    /// - Progress Reward: 적에게 가까워질 때마다 보상
    /// - Commit Zone: 근접 시 단계별 추가 보상
    /// - Stuck 감지: 진전 없는 에이전트에 페널티
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
        public float stage1SpeedRewardMultiplier = 4f;

        [Header("Stage 1 Individual Rewards (개별 보상)")]
        [Tooltip("Stage1 개별 속도 보상 (각 에이전트별로 부여)")]
        public float stage1IndividualSpeedReward = 0.02f;

        [Tooltip("명령 연속성 보상 계수 (추력/조향 변화가 작을수록 보상)")]
        public float actionSmoothnessCoeff = 0.002f;

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

        [Tooltip("정지 페널티 - 속도가 너무 낮을 때 (모든 Stage 공통)")]
        public float stationaryPenalty = -0.005f;

        [Tooltip("최소 속도 (m/s) - 이 속도 미만이면 정지 페널티 (모든 Stage 공통)")]
        public float minSpeed = 2f;

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
        public float perpendicularInterceptReward = 0.005f;

        [Tooltip("수직 차단 각도 허용 범위 (도)")]
        public float perpendicularAngleTolerance = 30f;

        [Tooltip("추적 이득 보상 (Stage2부터 적용)")]
        public float trackingGainReward = 0.002f;

        [Header("=== Progress Reward (Stage 2+) - 논문 기반 ===")]
        [Tooltip("Progress 보상 계수 (Web이 적에게 1m 가까워질 때마다 이 값만큼 보상)")]
        public float progressRewardCoeff = 0.01f;

        [Tooltip("Progress 페널티 계수 (Web이 적에게서 1m 멀어질 때마다 이 값만큼 페널티)")]
        public float progressPenaltyCoeff = 0.005f;

        [Header("=== Commit Zone Reward (Stage 2+) - 논문 기반 ===")]
        [Tooltip("Commit Zone 1 보상 (최대값) - 근접 시 추가 보상")]
        public float commitZone1Reward = 0.005f;

        [Tooltip("Commit Zone 1 거리 (m) - 이 거리 이내에서 Zone1 보상")]
        public float commitZone1Distance = 100f;

        [Tooltip("Commit Zone 2 보상 (최대값) - 매우 근접 시 추가 보상")]
        public float commitZone2Reward = 0.01f;

        [Tooltip("Commit Zone 2 거리 (m) - 이 거리 이내에서 Zone2 보상")]
        public float commitZone2Distance = 50f;

        [Header("=== Stuck Detection (Stage 2+) - 논문 기반 ===")]
        [Tooltip("Stuck 페널티 (한 번에 부과되는 페널티)")]
        public float stuckPenalty = -0.1f;

        [Tooltip("Stuck 판정 스텝 수 (이 스텝 동안 진전 없으면 Stuck)")]
        public int stuckThreshold = 40;

        [Tooltip("Stuck 판정 최소 진전 거리 (m) - 이 거리 이상 가까워져야 진전으로 인정)")]
        public float stuckProgressMinimum = 2f;

        [Header("Idle Penalty (Stage 2+)")]
        [Tooltip("Idle 페널티 (속도가 매우 낮을 때 추가 페널티)")]
        public float idlePenalty = -0.005f;

        [Tooltip("Idle 판정 속도 (m/s)")]
        public float idleSpeedThreshold = 1f;

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

        [Header("=== Event Rewards (이벤트 보상) ===")]
        [Tooltip("포획 성공 보상")]
        public float captureReward = 5.0f;

        [Tooltip("포획 거리 보너스 (최대) - 모선과 멀리서 포획할수록 보상")]
        public float captureDistanceBonus = 2.0f;

        [Tooltip("포획 거리 보너스 기준 (m) - 이 거리 이상에서 최대 보너스")]
        public float captureDistanceBonusRange = 500f;

        [Tooltip("모선 방어 성공 보상")]
        public float motherShipDefenseReward = 0.5f;

        [Tooltip("모선 충돌 패널티 (Game Over)")]
        public float motherShipCollisionPenalty = -2.0f;

        [Tooltip("방어선 침범 패널티")]
        public float boundaryBreachPenalty = -0.1f;

        [Tooltip("아군 거리 초과/미달 페널티")]
        public float allyDistancePenalty = -1.0f;

        [Tooltip("아군 위치 교차 페널티")]
        public float positionSwapPenalty = -1.0f;

        // === 내부 상태 변수 ===
        // 이전 스텝의 적-그물 거리 (추적 이득 계산용)
        private float _lastEnemyToWebDistance = float.MaxValue;

        // Progress Reward 추적용
        private float _lastProgressDistance = float.MaxValue;

        // Stuck 감지용
        private int _noProgressSteps = 0;
        private float _stuckCheckBaseDistance = float.MaxValue;

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
            float headingDiff = Mathf.Abs(Mathf.DeltaAngle(agent1.heading, agent2.heading));
            float headingFactor = 1f - (headingDiff / 180f);
            totalReward += stage1HeadingReward * headingFactor;

            // 2. 속도 동기화 (그라데이션: 속도 차이 0 = 최대 보상)
            float speedDiff = Mathf.Abs(agent1.speed - agent2.speed);
            float speedSyncFactor = Mathf.Clamp01(1f - (speedDiff / 10f));
            if (avgSpeed >= minSpeed)
            {
                totalReward += stage1SpeedSyncReward * speedSyncFactor;
            }

            // 3. 간격 유지 (그라데이션: 최적 거리에 가까울수록 높은 보상)
            float distance = Vector3.Distance(agent1.position, agent2.position);
            float distanceError = Mathf.Abs(distance - stage1OptimalDistance);
            float distanceFactor = Mathf.Clamp01(1f - (distanceError / 50f));
            totalReward += stage1DistanceReward * distanceFactor;

            // 4. 속도 보상 (그라데이션: 빠를수록 높은 보상) - 배수 적용
            float speedFactor = Mathf.Clamp01(avgSpeed / stage1SpeedThreshold);
            totalReward += stage1SpeedReward * speedFactor * stage1SpeedRewardMultiplier;

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
        /// 명령 연속성 보상 (각 에이전트별로 부여, 모든 Stage 적용)
        /// 추력/조향 명령의 변화가 작을수록 보상, 클수록 페널티
        /// </summary>
        public float CalculateActionSmoothnessReward(float throttleDelta, float steeringDelta)
        {
            float avgDelta = (throttleDelta + steeringDelta) * 0.5f;
            return (1f - 2f * avgDelta) * actionSmoothnessCoeff;
        }

        /// <summary>
        /// 협동 기동 보상 계산 (모든 Stage에서 Stage1 보상 사용)
        /// </summary>
        public float CalculateCooperativeRewards(AgentState agent1, AgentState agent2)
        {
            return CalculateStage1Rewards(agent1, agent2);
        }

        /// <summary>
        /// 전술 기동 보상 계산
        /// Stage2, Stage3에서 활성화 (Stage1에서는 0 반환)
        /// 수직 차단 + 추적 이득
        /// </summary>
        public float CalculateTacticalRewards(AgentState agent1, AgentState agent2,
            GameObject[] enemyShips, GameObject webObject)
        {
            float totalReward = 0f;

            // Stage1에서는 비활성
            if (currentStage == TrainingStage.Stage1_Formation)
                return totalReward;

            if (enemyShips == null || enemyShips.Length == 0 || webObject == null)
                return totalReward;

            // Web 중심에서 가장 가까운 적군 찾기
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
        /// [논문 기반] Progress Reward - Web이 적에게 가까워질 때 보상, 멀어지면 페널티
        /// Stage2, Stage3에서 활성화 (그룹 보상)
        /// </summary>
        public float CalculateProgressReward(GameObject[] enemyShips, GameObject webObject)
        {
            if (currentStage == TrainingStage.Stage1_Formation)
                return 0f;

            if (enemyShips == null || enemyShips.Length == 0 || webObject == null)
                return 0f;

            // Web 중심에서 가장 가까운 적 거리
            float nearestDistance = GetNearestEnemyDistance(enemyShips, webObject.transform.position);
            if (nearestDistance == float.MaxValue)
                return 0f;

            float reward = 0f;

            if (_lastProgressDistance != float.MaxValue)
            {
                float distanceChange = _lastProgressDistance - nearestDistance;

                if (distanceChange > 0f)
                {
                    // 가까워짐 → 보상
                    reward = distanceChange * progressRewardCoeff;
                }
                else if (distanceChange < 0f)
                {
                    // 멀어짐 → 페널티 (절반 크기)
                    reward = distanceChange * progressPenaltyCoeff;
                }
            }

            _lastProgressDistance = nearestDistance;
            return reward;
        }

        /// <summary>
        /// [논문 기반] Commit Zone Reward - Web이 적에게 근접할수록 단계별 추가 보상
        /// Stage2, Stage3에서 활성화 (그룹 보상)
        /// </summary>
        public float CalculateCommitZoneReward(GameObject[] enemyShips, GameObject webObject)
        {
            if (currentStage == TrainingStage.Stage1_Formation)
                return 0f;

            if (enemyShips == null || enemyShips.Length == 0 || webObject == null)
                return 0f;

            float nearestDistance = GetNearestEnemyDistance(enemyShips, webObject.transform.position);
            if (nearestDistance == float.MaxValue)
                return 0f;

            float reward = 0f;

            // Zone 1: commitZone1Distance 이내 → 그라데이션 보상
            if (nearestDistance <= commitZone1Distance)
            {
                float factor = 1f - (nearestDistance / commitZone1Distance);
                reward += commitZone1Reward * factor;
            }

            // Zone 2: commitZone2Distance 이내 → 추가 그라데이션 보상
            if (nearestDistance <= commitZone2Distance)
            {
                float factor = 1f - (nearestDistance / commitZone2Distance);
                reward += commitZone2Reward * factor;
            }

            return reward;
        }

        /// <summary>
        /// [논문 기반] Stuck 감지 - N스텝 동안 진전 없으면 페널티
        /// Stage2, Stage3에서 활성화 (그룹 보상)
        /// </summary>
        public float CalculateStuckPenalty(GameObject[] enemyShips, GameObject webObject)
        {
            if (currentStage == TrainingStage.Stage1_Formation)
                return 0f;

            if (enemyShips == null || enemyShips.Length == 0 || webObject == null)
                return 0f;

            float nearestDistance = GetNearestEnemyDistance(enemyShips, webObject.transform.position);
            if (nearestDistance == float.MaxValue)
                return 0f;

            // 첫 호출 시 기준 거리 설정
            if (_stuckCheckBaseDistance == float.MaxValue)
            {
                _stuckCheckBaseDistance = nearestDistance;
                _noProgressSteps = 0;
                return 0f;
            }

            // 진전 확인: 기준 거리 대비 stuckProgressMinimum 이상 가까워졌는가?
            float progress = _stuckCheckBaseDistance - nearestDistance;
            if (progress >= stuckProgressMinimum)
            {
                // 진전 있음 → 카운터 리셋
                _noProgressSteps = 0;
                _stuckCheckBaseDistance = nearestDistance;
                return 0f;
            }

            // 진전 없음 → 카운터 증가
            _noProgressSteps++;

            if (_noProgressSteps >= stuckThreshold)
            {
                // Stuck 판정 → 페널티 부과 + 카운터 리셋
                _noProgressSteps = 0;
                _stuckCheckBaseDistance = nearestDistance; // 새 기준 설정
                return stuckPenalty;
            }

            return 0f;
        }

        /// <summary>
        /// [논문 기반] Idle 페널티 - 개별 에이전트 속도가 매우 낮으면 페널티
        /// Stage2, Stage3에서 활성화 (개별 보상)
        /// </summary>
        public float CalculateIdlePenalty(AgentState agent)
        {
            if (currentStage == TrainingStage.Stage1_Formation)
                return 0f;

            if (agent.speed < idleSpeedThreshold)
            {
                return idlePenalty;
            }

            return 0f;
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

            // 정지 페널티 (모든 Stage 공통 - 평균 속도가 최소 속도 미만이면)
            float avgSpeed = (agent1.speed + agent2.speed) / 2f;
            if (avgSpeed < minSpeed)
            {
                totalPenalty += stationaryPenalty;
            }

            // Stage1: 대형 붕괴 페널티 (시간 패널티 없음)
            if (currentStage == TrainingStage.Stage1_Formation)
            {
                if (distance > stage1MaxDistance)
                {
                    totalPenalty += stage1FormationDistancePenalty;
                }

                if (headingDiff > stage1MaxAngleDiff)
                {
                    totalPenalty += stage1FormationAnglePenalty;
                }

                return totalPenalty;
            }

            // Stage2, Stage3: 기존 페널티 적용
            if (distance > maxFormationDistance || headingDiff > maxFormationAngleDiff)
            {
                totalPenalty += formationBreakPenalty;
            }

            // 시간 패널티
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
        /// Web 위치에서 가장 가까운 적까지의 거리
        /// </summary>
        public float GetNearestEnemyDistance(GameObject[] enemyShips, Vector3 referencePos)
        {
            float minDist = float.MaxValue;

            if (enemyShips == null) return minDist;

            foreach (var enemy in enemyShips)
            {
                if (enemy == null || !enemy.activeInHierarchy) continue;

                float dist = Vector3.Distance(referencePos, enemy.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                }
            }

            return minDist;
        }

        /// <summary>
        /// Web 위치에서 가장 가까운 적의 상대 위치 (관측용)
        /// </summary>
        public Vector3 GetNearestEnemyRelativePosition(GameObject[] enemyShips, Vector3 referencePos)
        {
            float minDist = float.MaxValue;
            Vector3 nearestRelative = Vector3.zero;

            if (enemyShips == null) return nearestRelative;

            foreach (var enemy in enemyShips)
            {
                if (enemy == null || !enemy.activeInHierarchy) continue;

                Vector3 relative = enemy.transform.position - referencePos;
                float dist = relative.magnitude;
                if (dist < minDist)
                {
                    minDist = dist;
                    nearestRelative = relative;
                }
            }

            return nearestRelative;
        }

        /// <summary>
        /// 포획 보상 계산 (기본 보상 + 거리 보너스)
        /// Stage2, Stage3에서만 활성화
        /// </summary>
        public float CalculateCaptureReward(Vector3 enemyPos, Vector3 motherShipPos)
        {
            if (currentStage == TrainingStage.Stage1_Formation)
                return 0f;

            float reward = captureReward;
            float distanceFromMotherShip = Vector3.Distance(enemyPos, motherShipPos);
            float distanceFactor = Mathf.Clamp01(distanceFromMotherShip / captureDistanceBonusRange);
            reward += captureDistanceBonus * distanceFactor;
            return reward;
        }

        /// <summary>
        /// 모선 충돌 페널티 반환 (Stage2, Stage3에서만 활성화)
        /// </summary>
        public float GetMotherShipCollisionPenalty()
        {
            if (currentStage == TrainingStage.Stage1_Formation)
                return 0f;
            return motherShipCollisionPenalty;
        }

        /// <summary>
        /// 리셋 (에피소드 시작 시)
        /// </summary>
        public void Reset()
        {
            _lastEnemyToWebDistance = float.MaxValue;
            _lastProgressDistance = float.MaxValue;
            _noProgressSteps = 0;
            _stuckCheckBaseDistance = float.MaxValue;
        }
    }
}
