using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// Web 오브젝트에 부착하여 attack_boat와의 충돌을 감지
    /// 충돌 시 DefenseEnvController를 통해 그룹 보상으로 처리
    /// </summary>
    public class WebCollisionDetector : MonoBehaviour
    {
        [Header("Settings")]
        [Tooltip("충돌 감지할 적군 태그")]
        public string enemyTag = "attack_boat";

        [Tooltip("환경 컨트롤러 (충돌 시 알림)")]
        public DefenseEnvController envController;

        [Tooltip("충돌 효과 Prefab (선택적)")]
        public GameObject captureEffectPrefab;

        [Tooltip("효과 크기")]
        public float effectScale = 1f;

        [Header("Debug")]
        [Tooltip("디버그 로그 활성화")]
        public bool enableDebugLog = true;


        private bool _hasTriggered = false;

        private void Start()
        {
            // 환경 컨트롤러 자동 찾기 (멀티 환경 호환)
            if (envController == null)
            {
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                envController = envRoot.GetComponentInChildren<DefenseEnvController>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // 이미 트리거된 경우 무시
            if (_hasTriggered)
            {
                if (enableDebugLog)
                {
                    Debug.Log($"[WebCollisionDetector] 이미 트리거됨, 무시: {other.gameObject.name}");
                }
                return;
            }

            // attack_boat 태그 확인
            if (other.CompareTag(enemyTag))
            {
                _hasTriggered = true;

                // 적군 선박 참조
                GameObject enemyBoat = other.gameObject;

                if (enableDebugLog)
                {
                    Debug.Log($"[WebCollisionDetector] ========== 그물 충돌 감지! ==========");
                    Debug.Log($"[WebCollisionDetector] 적군 선박: {enemyBoat.name}");
                    Debug.Log($"[WebCollisionDetector] 적군 위치: {enemyBoat.transform.position}");
                    Debug.Log($"[WebCollisionDetector] 그물 위치: {transform.position}");
                    Debug.Log($"[WebCollisionDetector] 그물 크기: {transform.localScale}");
                }

                // DefenseEnvController를 통해 적군과 아군 모두 원점으로 리셋 처리 (에피소드 종료 없음)
                if (envController != null)
                {
                    if (enableDebugLog)
                    {
                        Debug.Log($"[WebCollisionDetector] DefenseEnvController에 포획 알림 전송");
                    }
                    envController.OnEnemyHitWeb(enemyBoat);
                }
                else
                {
                    if (enableDebugLog)
                    {
                        Debug.LogWarning("[WebCollisionDetector] DefenseEnvController를 찾을 수 없습니다!");
                    }
                }

                // 효과 생성
                if (captureEffectPrefab != null)
                {
                    GameObject effect = Instantiate(captureEffectPrefab, transform.position, Quaternion.identity);
                    effect.transform.localScale = Vector3.one * effectScale;
                    Destroy(effect, 3f);
                    if (enableDebugLog)
                    {
                        Debug.Log($"[WebCollisionDetector] 포획 효과 생성: {effect.name}");
                    }
                }
                else
                {
                    if (enableDebugLog)
                    {
                        Debug.LogWarning("[WebCollisionDetector] captureEffectPrefab이 할당되지 않았습니다!");
                    }
                }
                
                if (enableDebugLog)
                {
                    Debug.Log($"[WebCollisionDetector] ========================================");
                }
            }
            else
            {
                if (enableDebugLog)
                {
                    Debug.Log($"[WebCollisionDetector] 충돌 객체는 적군이 아님: {other.gameObject.name} (태그: {other.tag})");
                }
            }
        }

        /// <summary>
        /// 에피소드 리셋 시 호출
        /// </summary>
        public void ResetDetector()
        {
            _hasTriggered = false;
        }

        private void OnDrawGizmos()
        {
            // Web 범위 시각화
            Gizmos.color = _hasTriggered ? Color.green : Color.yellow;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }
    }
}
