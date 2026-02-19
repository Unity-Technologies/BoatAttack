using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 간단한 충돌 폭발 컴포넌트
    /// MotherShip과 충돌 시 폭발 효과만 생성
    /// </summary>
    public class SimpleExplosionOnCollision : MonoBehaviour
    {
        [Header("Target Settings")]
        [Tooltip("모선 태그")]
        public string motherShipTag = "MotherShip";

        [Header("Explosion Settings")]
        [Tooltip("폭발 효과 Prefab (War FX)")]
        public GameObject explosionPrefab;

        [Tooltip("폭발 효과 크기 배율")]
        [Range(5f, 50f)]
        public float explosionScale = 23f;

        [Tooltip("폭발 후 오브젝트 제거 여부")]
        public bool destroyAfterExplosion = true;

        [Tooltip("폭발 후 제거까지의 딜레이 (초)")]
        public float destroyDelay = 1.5f;

        [Header("Collision Detection")]
        [Tooltip("충돌 감지 방식: true=Trigger 사용, false=물리 Collision 사용")]
        public bool useTriggerCollision = false;

        // 폭발 여부 플래그
        private bool _hasExploded = false;

        /// <summary>
        /// Trigger 충돌 감지
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (!useTriggerCollision || _hasExploded)
            {
                return;
            }

            Debug.Log($"[SimpleExplosion] OnTriggerEnter: {other.gameObject.name}, Tag: {other.tag}");

            if (IsMotherShip(other.gameObject))
            {
                Debug.Log("[SimpleExplosion] MotherShip 충돌 감지! 폭발 시작");
                HandleExplosion();
            }
        }

        /// <summary>
        /// Collision 충돌 감지
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            if (_hasExploded)
            {
                return;
            }

            Debug.Log($"[SimpleExplosion] OnCollisionEnter: {collision.gameObject.name}, Tag: {collision.gameObject.tag}");

            // MotherShip과의 충돌은 useTriggerCollision 설정과 관계없이 항상 처리
            if (IsMotherShip(collision.gameObject))
            {
                Debug.Log("[SimpleExplosion] MotherShip 충돌 감지! 폭발 시작");
                HandleExplosion();
                return;
            }

            // MotherShip이 아닌 경우, useTriggerCollision이 true면 무시
            if (useTriggerCollision)
            {
                return;
            }
        }

        /// <summary>
        /// 충돌한 객체가 MotherShip인지 확인
        /// </summary>
        private bool IsMotherShip(GameObject obj)
        {
            if (obj == null)
            {
                return false;
            }

            // 태그로 확인
            if (!string.IsNullOrEmpty(motherShipTag) && obj.CompareTag(motherShipTag))
            {
                Debug.Log($"[SimpleExplosion] 태그로 확인됨: {motherShipTag}");
                return true;
            }

            // 이름으로 확인
            if (obj.name.Contains("MotherShip") || obj.name.Contains("Mother"))
            {
                Debug.Log($"[SimpleExplosion] 이름으로 확인됨: {obj.name}");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 폭발 처리
        /// </summary>
        private void HandleExplosion()
        {
            if (_hasExploded)
            {
                return;
            }

            Debug.Log("[SimpleExplosion] 폭발 처리 시작");

            // 폭발 효과 생성
            TriggerExplosion();

            // 오브젝트 제거 (옵션)
            if (destroyAfterExplosion)
            {
                Destroy(gameObject, destroyDelay);
                Debug.Log($"[SimpleExplosion] {destroyDelay}초 후 오브젝트 제거 예약");
            }
        }

        /// <summary>
        /// 폭발 효과 생성
        /// </summary>
        private void TriggerExplosion()
        {
            if (_hasExploded)
            {
                return;
            }

            _hasExploded = true;
            Debug.Log($"[SimpleExplosion] 폭발 효과 생성 위치: {transform.position}");

            // 폭발 Prefab 검증
            if (explosionPrefab == null)
            {
                Debug.LogError("[SimpleExplosion] explosionPrefab이 null입니다! Inspector에서 War FX 폭발 효과 Prefab을 할당해주세요.");
                return;
            }

            // 폭발 효과 생성 위치
            Vector3 explosionPosition = transform.position;
            explosionPosition.y += 0.5f;

            // War FX 폭발 효과 생성
            GameObject explosion = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

            if (explosion != null)
            {
                explosion.SetActive(true);

                // 폭발 효과 크기 조정
                float scaleMultiplier = explosionScale;
                explosion.transform.localScale = Vector3.one * scaleMultiplier;

                // ParticleSystem 크기와 속도 조정
                ParticleSystem[] particleSystems = explosion.GetComponentsInChildren<ParticleSystem>();
                foreach (var ps in particleSystems)
                {
                    var main = ps.main;

                    // Start Size 증가
                    if (main.startSize.mode == ParticleSystemCurveMode.Constant)
                    {
                        main.startSize = main.startSize.constant * scaleMultiplier;
                    }
                    else if (main.startSize.mode == ParticleSystemCurveMode.TwoConstants)
                    {
                        main.startSize = new ParticleSystem.MinMaxCurve(
                            main.startSize.constantMin * scaleMultiplier,
                            main.startSize.constantMax * scaleMultiplier
                        );
                    }

                    // Start Speed 증가
                    if (main.startSpeed.mode == ParticleSystemCurveMode.Constant)
                    {
                        main.startSpeed = main.startSpeed.constant * scaleMultiplier;
                    }
                    else if (main.startSpeed.mode == ParticleSystemCurveMode.TwoConstants)
                    {
                        main.startSpeed = new ParticleSystem.MinMaxCurve(
                            main.startSpeed.constantMin * scaleMultiplier,
                            main.startSpeed.constantMax * scaleMultiplier
                        );
                    }
                }

                Debug.Log($"[SimpleExplosion] 폭발 효과 생성 완료!");
                Debug.Log($"[SimpleExplosion] - 위치: {explosionPosition}");
                Debug.Log($"[SimpleExplosion] - 크기 배율: {scaleMultiplier}x");
                Debug.Log($"[SimpleExplosion] - ParticleSystem 개수: {particleSystems.Length}");

                if (particleSystems.Length == 0)
                {
                    Debug.LogWarning("[SimpleExplosion] 폭발 효과에 ParticleSystem이 없습니다!");
                }
            }
            else
            {
                Debug.LogError("[SimpleExplosion] 폭발 효과 생성 실패!");
            }
        }
    }
}
