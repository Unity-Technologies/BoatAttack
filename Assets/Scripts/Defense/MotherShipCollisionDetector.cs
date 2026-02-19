using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 모선과 적군 선박의 충돌을 감지하는 컴포넌트
    /// 모선 GameObject에 부착하여 사용
    /// </summary>
    public class MotherShipCollisionDetector : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("충돌 감지할 적군 태그")]
        public string enemyTag = "attack_boat";
        
        [Tooltip("환경 컨트롤러 (충돌 시 알림)")]
        public DefenseEnvController envController;
        
        [Header("Debug")]
        [Tooltip("디버그 로그 활성화")]
        public bool enableDebugLog = true;
        
        private void Start()
        {
            // 환경 컨트롤러 자동 찾기 (멀티 환경 호환 - 루트까지 탐색)
            if (envController == null)
            {
                Transform current = transform;
                while (current != null)
                {
                    envController = current.GetComponentInChildren<DefenseEnvController>();
                    if (envController != null) break;
                    current = current.parent;
                }

                if (envController == null)
                {
                    Debug.LogWarning("[MotherShipCollisionDetector] DefenseEnvController를 찾을 수 없습니다!");
                }
            }
        }
        
        /// <summary>
        /// 충돌 감지 (Collision)
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(enemyTag))
            {
                if (enableDebugLog)
                {
                    Vector3 contactPoint = collision.contacts.Length > 0 ? collision.contacts[0].point : collision.gameObject.transform.position;
                    Debug.LogWarning($"[MotherShipCollisionDetector] 모선 충돌! 적군: {collision.gameObject.name}, " +
                                   $"충돌 위치: {contactPoint}, 상대 속도: {collision.relativeVelocity.magnitude:F1}m/s");
                }

                if (envController != null)
                {
                    envController.OnMotherShipCollision(collision.gameObject);
                }
            }
        }

        /// <summary>
        /// 충돌 감지 (Trigger)
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(enemyTag))
            {
                if (enableDebugLog)
                {
                    Debug.LogWarning($"[MotherShipCollisionDetector] 모선 트리거 충돌! 적군: {other.gameObject.name}, " +
                                   $"위치: {other.gameObject.transform.position}");
                }

                if (envController != null)
                {
                    envController.OnMotherShipCollision(other.gameObject);
                }
            }
        }
    }
}
