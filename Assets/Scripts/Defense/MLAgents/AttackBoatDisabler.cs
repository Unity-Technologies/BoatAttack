using UnityEngine;
using BoatAttack;

namespace BoatAttack
{
    /// <summary>
    /// 공격 선박 비활성화 헬퍼: AttackAgent가 폭발 후 자동으로 비활성화되도록 합니다.
    /// 이 스크립트를 AttackAgent가 있는 GameObject에 추가하세요.
    /// </summary>
    [RequireComponent(typeof(AttackAgent))]
    public class AttackBoatDisabler : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("폭발 후 비활성화 딜레이 (초)")]
        public float disableDelay = 0.5f;
        
        [Header("Debug")]
        [Tooltip("디버그 로그 출력")]
        public bool debugLog = true;

        private AttackAgent _attackAgent;
        private bool _hasExploded = false;

        private void Awake()
        {
            _attackAgent = GetComponent<AttackAgent>();
        }

        private void OnEnable()
        {
            _hasExploded = false;
        }

        /// <summary>
        /// AttackAgent의 폭발 감지 및 비활성화 처리
        /// </summary>
        private void Update()
        {
            // AttackAgent가 폭발했는지 확인
            // AttackAgent의 _hasExploded는 private이므로, 
            // OnCollisionEnter나 OnTriggerEnter를 통해 간접적으로 감지
            
            // 대신 AttackAgent의 컴포넌트가 비활성화되거나 파괴되는 것을 감지
            if (_attackAgent == null || !_attackAgent.enabled)
            {
                return;
            }
        }

        /// <summary>
        /// 충돌 감지: AttackAgent의 충돌을 감지하고 비활성화 처리
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            // AttackAgent가 이미 충돌을 처리했는지 확인하기 어려우므로,
            // MotherShip과의 충돌을 직접 확인
            if (_hasExploded)
            {
                return;
            }

            GameObject other = collision.gameObject;
            
            // MotherShip 태그 확인
            if (other.CompareTag("MotherShip") || 
                other.name.Contains("MotherShip") || 
                other.name.Contains("Mother"))
            {
                if (debugLog)
                {
                    Debug.Log($"[AttackBoatDisabler] {gameObject.name}: MotherShip 충돌 감지! 비활성화 예약...");
                }
                
                _hasExploded = true;
                Invoke(nameof(DisableBoat), disableDelay);
            }
        }

        /// <summary>
        /// Trigger 충돌 감지
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (_hasExploded)
            {
                return;
            }

            GameObject otherObj = other.gameObject;
            
            // MotherShip 태그 확인
            if (otherObj.CompareTag("MotherShip") || 
                otherObj.name.Contains("MotherShip") || 
                otherObj.name.Contains("Mother"))
            {
                if (debugLog)
                {
                    Debug.Log($"[AttackBoatDisabler] {gameObject.name}: MotherShip Trigger 충돌 감지! 비활성화 예약...");
                }
                
                _hasExploded = true;
                Invoke(nameof(DisableBoat), disableDelay);
            }
        }

        /// <summary>
        /// 공격 선박 파괴 (비활성화 대신 파괴)
        /// </summary>
        private void DisableBoat()
        {
            if (debugLog)
            {
                Debug.Log($"[AttackBoatDisabler] {gameObject.name}: 공격 선박 파괴");
            }
            
            // GameObject 파괴 (방어 선박만 학습하므로 적군 선박은 단순히 파괴)
            Destroy(gameObject);
        }

        /// <summary>
        /// 외부에서 호출 가능한 비활성화 메서드
        /// </summary>
        public void Disable()
        {
            if (!_hasExploded)
            {
                _hasExploded = true;
                DisableBoat();
            }
        }
    }
}
