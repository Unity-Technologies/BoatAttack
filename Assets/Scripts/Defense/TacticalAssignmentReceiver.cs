using UnityEngine;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// Roonshot 전술 서버에서 수신한 배정 결과를 DefenseEnvController에 연동
    /// TacticalClient에서 배정 결과를 가져와 에이전트 관측에 타겟 정보를 제공합니다.
    /// </summary>
    public class TacticalAssignmentReceiver : MonoBehaviour
    {
        [Header("References")]
        [Tooltip("전술 클라이언트")]
        public TacticalClient tacticalClient;

        [Tooltip("방어 환경 컨트롤러")]
        public DefenseEnvController envController;

        [Header("Status (Read Only)")]
        [SerializeField] private string _currentFormation = "UNKNOWN";
        [SerializeField] private float _currentConfidence = 0f;
        [SerializeField] private int _assignmentCount = 0;

        // 에이전트별 타겟 적군 인덱스 (-1 = 배정 없음)
        private int _agent1TargetIndex = -1;
        private int _agent2TargetIndex = -1;

        // 타겟 적군 월드 위치 (에이전트 관측용)
        private Vector3 _agent1TargetPos = Vector3.zero;
        private Vector3 _agent2TargetPos = Vector3.zero;

        /// <summary>
        /// Agent1의 배정된 타겟 적군 인덱스 (-1 = 없음)
        /// </summary>
        public int Agent1TargetIndex => _agent1TargetIndex;

        /// <summary>
        /// Agent2의 배정된 타겟 적군 인덱스 (-1 = 없음)
        /// </summary>
        public int Agent2TargetIndex => _agent2TargetIndex;

        /// <summary>
        /// Agent1의 타겟 적군 위치
        /// </summary>
        public Vector3 Agent1TargetPosition => _agent1TargetPos;

        /// <summary>
        /// Agent2의 타겟 적군 위치
        /// </summary>
        public Vector3 Agent2TargetPosition => _agent2TargetPos;

        /// <summary>
        /// 현재 포메이션 이름
        /// </summary>
        public string CurrentFormation => _currentFormation;

        /// <summary>
        /// 현재 분류 신뢰도
        /// </summary>
        public float CurrentConfidence => _currentConfidence;

        private void Update()
        {
            if (tacticalClient == null || !tacticalClient.IsConnected)
                return;

            var assignment = tacticalClient.GetLatestAssignment();
            if (assignment == null || assignment.assignments == null)
                return;

            _currentFormation = assignment.formation ?? "UNKNOWN";
            _currentConfidence = assignment.confidence;
            _assignmentCount = assignment.assignments.Length;

            // 배정 결과 → 적군 인덱스 매핑
            _agent1TargetIndex = -1;
            _agent2TargetIndex = -1;

            foreach (var entry in assignment.assignments)
            {
                if (entry.pair == null || entry.pair.Length == 0)
                    continue;

                // target_enemy_id → enemyShips 배열 인덱스 찾기
                int enemyIndex = FindEnemyIndex(entry.target_enemy_id);

                // 어느 에이전트 쌍에 해당하는지 판별
                foreach (string friendlyId in entry.pair)
                {
                    if (friendlyId == "Friendly_0")
                    {
                        _agent1TargetIndex = enemyIndex;
                    }
                    else if (friendlyId == "Friendly_1")
                    {
                        _agent2TargetIndex = enemyIndex;
                    }
                }
            }

            // 타겟 위치 업데이트
            UpdateTargetPositions();
        }

        /// <summary>
        /// 적군 ID 문자열 → enemyShips 배열 인덱스 변환
        /// </summary>
        private int FindEnemyIndex(string enemyId)
        {
            if (string.IsNullOrEmpty(enemyId) || envController == null || envController.enemyShips == null)
                return -1;

            // "Enemy_0" → 0
            if (enemyId.StartsWith("Enemy_"))
            {
                string numStr = enemyId.Substring(6);
                if (int.TryParse(numStr, out int idx) && idx >= 0 && idx < envController.enemyShips.Length)
                {
                    return idx;
                }
            }

            return -1;
        }

        /// <summary>
        /// 타겟 적군 위치 업데이트
        /// </summary>
        private void UpdateTargetPositions()
        {
            if (envController == null || envController.enemyShips == null)
                return;

            var enemies = envController.enemyShips;

            if (_agent1TargetIndex >= 0 && _agent1TargetIndex < enemies.Length && enemies[_agent1TargetIndex] != null)
            {
                _agent1TargetPos = enemies[_agent1TargetIndex].transform.position;
            }
            else
            {
                _agent1TargetPos = Vector3.zero;
            }

            if (_agent2TargetIndex >= 0 && _agent2TargetIndex < enemies.Length && enemies[_agent2TargetIndex] != null)
            {
                _agent2TargetPos = enemies[_agent2TargetIndex].transform.position;
            }
            else
            {
                _agent2TargetPos = Vector3.zero;
            }
        }
    }
}
