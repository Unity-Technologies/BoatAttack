using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 보상 계산기 (단순화)
    /// 매 스텝: 대형 유지 + 적 접근 + 시간 페널티
    /// 이벤트: 포획/모선충돌/아군충돌 (EnvController에서 직접 참조)
    /// </summary>
    public class DefenseRewardCalculator : MonoBehaviour
    {
        [Header("=== 매 스텝 보상 ===")]
        [Tooltip("대형 유지 보상 (아군 간격이 적정 범위 내일 때)")]
        public float formationReward = 0.001f;

        [Tooltip("아군 간 최적 거리 (m)")]
        public float optimalDistance = 50f;

        [Tooltip("거리 허용 범위 (±m) - 최적 거리 기준")]
        public float distanceTolerance = 25f;

        [Tooltip("적 접근 보상 (Web-적 거리 1m 감소당)")]
        public float approachRewardPerMeter = 0.001f;

        [Tooltip("시간 페널티 (매 스텝)")]
        public float timePenalty = -0.0001f;

        [Header("=== 이벤트 보상 ===")]
        [Tooltip("포획 성공 (적이 Web에 충돌)")]
        public float captureReward = 1.0f;

        [Tooltip("모선 충돌 페널티 (적이 모선에 충돌)")]
        public float motherShipHitPenalty = -1.0f;

        [Tooltip("충돌 페널티 (아군끼리/모선/거리초과 등)")]
        public float collisionPenalty = -0.5f;

        // 이전 스텝의 Web-적 거리 (접근 보상 계산용)
        private float _prevWebToEnemyDist = float.MaxValue;

        /// <summary>
        /// 에이전트 상태
        /// </summary>
        public struct AgentState
        {
            public Vector3 position;
            public float heading;
            public float speed;
        }

        /// <summary>
        /// 매 스텝 보상 계산: 대형 유지 + 적 접근 + 시간 페널티
        /// </summary>
        public float CalculateStepReward(AgentState agent1, AgentState agent2,
            GameObject[] enemyShips, GameObject webObject)
        {
            float reward = 0f;

            // 1. 대형 유지: 아군 간 거리가 적정 범위(optimalDistance ± tolerance) 내면 보상
            float allyDist = Vector3.Distance(agent1.position, agent2.position);
            float error = Mathf.Abs(allyDist - optimalDistance);
            if (error <= distanceTolerance)
            {
                reward += formationReward * (1f - error / distanceTolerance);
            }

            // 2. 적 접근: Web과 가장 가까운 적 사이 거리가 줄었으면 보상
            if (webObject != null && enemyShips != null)
            {
                float closestDist = GetClosestEnemyDistance(webObject.transform.position, enemyShips);
                if (closestDist < float.MaxValue && _prevWebToEnemyDist < float.MaxValue)
                {
                    float delta = _prevWebToEnemyDist - closestDist;
                    if (delta > 0f)
                    {
                        reward += approachRewardPerMeter * delta;
                    }
                }
                _prevWebToEnemyDist = closestDist;
            }

            // 3. 시간 페널티
            reward += timePenalty;

            return reward;
        }

        /// <summary>
        /// Web 위치에서 가장 가까운 활성 적군까지의 거리
        /// </summary>
        private float GetClosestEnemyDistance(Vector3 webPos, GameObject[] enemies)
        {
            float minDist = float.MaxValue;
            foreach (var enemy in enemies)
            {
                if (enemy == null || !enemy.activeInHierarchy) continue;
                float dist = Vector3.Distance(webPos, enemy.transform.position);
                if (dist < minDist) minDist = dist;
            }
            return minDist;
        }

        /// <summary>
        /// 에이전트 상태 수집
        /// </summary>
        public AgentState GetAgentState(DefenseAgent agent)
        {
            if (agent == null)
                return new AgentState();

            AgentState state = new AgentState
            {
                position = agent.transform.position,
                heading = agent.transform.eulerAngles.y
            };

            Rigidbody rb = agent.GetComponent<Rigidbody>();
            if (rb != null)
            {
                state.speed = rb.velocity.magnitude;
            }

            return state;
        }

        /// <summary>
        /// 리셋 (에피소드 시작 시)
        /// </summary>
        public void Reset()
        {
            _prevWebToEnemyDist = float.MaxValue;
        }
    }
}
