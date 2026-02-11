using UnityEngine;
using Unity.MLAgents;

namespace BoatAttack
{
    /// <summary>
    /// 2대의 방어 선박 사이에 동적으로 생성되는 Web (장막)
    /// 선박 간 거리에 따라 크기가 자동으로 조정됨
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]  // ML-Agents 빌드 호환성: 런타임 AddComponent 방지
    [RequireComponent(typeof(BoxCollider))]
    public class DynamicWeb : MonoBehaviour
    {
        [Header("Target Ships")]
        [Tooltip("방어 선박 1")]
        public Transform defenseShip1;

        [Tooltip("방어 선박 2")]
        public Transform defenseShip2;

        [Header("Web Anchor Points (Inspector에서 할당)")]
        [Tooltip("Web 시작점 (선박1에 부착된 자식 오브젝트)")]
        public Transform webAnchor1;

        [Tooltip("Web 끝점 (선박2에 부착된 자식 오브젝트)")]
        public Transform webAnchor2;

        [Header("Web Settings")]
        [Tooltip("Web 높이")]
        public float webHeight = 5f;

        [Tooltip("Web 두께")]
        public float webThickness = 0.5f;

        [Tooltip("Web 색상")]
        public Color webColor = new Color(0f, 1f, 1f, 0.3f); // 반투명 청록색

        [Header("Collision")]
        [Tooltip("Trigger 충돌 사용")]
        public bool isTrigger = true;

        [Header("Visual")]
        [Tooltip("Web 시각화 활성화")]
        public bool showVisual = true;

        [Header("Collision Reward")]
        [Tooltip("공격 보트를 막았을 때 방어선에게 주는 보상")]
        public float defenseReward = 10f;

        [Tooltip("아군 선박이 Web과 충돌했을 때 페널티")]
        public float allyWebCollisionPenalty = -2.0f;

        [Header("Explosion Effect")]
        [Tooltip("공격 보트 폭발 효과 Prefab (War FX)")]
        public GameObject explosionPrefab;

        [Tooltip("폭발 효과 크기 배율")]
        [Range(5f, 50f)]
        public float explosionScale = 15f;

        [Header("Visual Material")]
        [Tooltip("Web 시각화용 Material (비어있으면 기본 생성)")]
        public Material webMaterial;

        [Header("Managers")]
        [Tooltip("환경 컨트롤러 (수동 할당 가능, 비어있으면 자동으로 찾음)")]
        public DefenseEnvController envController;

        private BoxCollider _collider;
        private MeshRenderer _renderer;
        private GameObject _visualObject;
        private Color _lastWebColor;

        private void Start()
        {
            // BoxCollider 설정
            _collider = gameObject.GetComponent<BoxCollider>();
            if (_collider == null)
            {
                _collider = gameObject.AddComponent<BoxCollider>();
            }
            _collider.isTrigger = isTrigger;

            // 시각화 오브젝트 생성
            if (showVisual)
            {
                CreateVisual();
            }

            // 초기 색상 저장
            _lastWebColor = webColor;

            // DefenseEnvController 찾기 및 캐싱 (멀티 환경 호환)
            if (envController == null)
            {
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                envController = envRoot.GetComponentInChildren<DefenseEnvController>();
            }
        }

        private void Update()
        {
            if (defenseShip1 == null || defenseShip2 == null)
                return;

            UpdateWebTransform();

            // 색상 변경 감지 및 업데이트
            if (_lastWebColor != webColor)
            {
                SetColor(webColor);
                _lastWebColor = webColor;
            }
        }

        /// <summary>
        /// Web 위치 및 크기 업데이트
        /// </summary>
        private void UpdateWebTransform()
        {
            Vector3 pos1 = (webAnchor1 != null) ? webAnchor1.position : defenseShip1.position;
            Vector3 pos2 = (webAnchor2 != null) ? webAnchor2.position : defenseShip2.position;

            // Web 중심 위치
            Vector3 centerPos = (pos1 + pos2) / 2f;
            transform.position = centerPos;

            // Web 회전
            Vector3 direction = pos2 - pos1;
            direction.y = 0f;
            if (direction.magnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }

            // Web 크기
            float distance = Vector3.Distance(pos1, pos2);

            if (_collider != null)
            {
                _collider.size = new Vector3(webThickness, webHeight, distance);
            }

            if (_visualObject != null)
            {
                _visualObject.transform.localScale = new Vector3(webThickness, webHeight, distance);
            }
        }

        /// <summary>
        /// Web 시각화 생성
        /// </summary>
        private void CreateVisual()
        {
            _visualObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _visualObject.name = "WebVisual";
            _visualObject.transform.SetParent(transform);
            _visualObject.transform.localPosition = Vector3.zero;
            _visualObject.transform.localRotation = Quaternion.identity;

            Destroy(_visualObject.GetComponent<BoxCollider>());

            _renderer = _visualObject.GetComponent<MeshRenderer>();
            if (_renderer != null)
            {
                Material mat = null;

                if (webMaterial != null)
                {
                    mat = new Material(webMaterial);
                    mat.color = webColor;
                }
                else
                {
                    Shader standardShader = Shader.Find("Standard");
                    if (standardShader != null)
                    {
                        mat = new Material(standardShader);
                        mat.color = webColor;
                        mat.SetFloat("_Mode", 3);
                        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                        mat.SetInt("_ZWrite", 0);
                        mat.DisableKeyword("_ALPHATEST_ON");
                        mat.EnableKeyword("_ALPHABLEND_ON");
                        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                        mat.renderQueue = 3000;
                    }
                    else if (_renderer.sharedMaterial != null)
                    {
                        mat = new Material(_renderer.sharedMaterial);
                        mat.color = webColor;
                    }
                }

                if (mat != null)
                {
                    _renderer.material = mat;
                }
            }
        }

        /// <summary>
        /// Web 색상 변경
        /// </summary>
        public void SetColor(Color color)
        {
            webColor = color;
            if (_renderer != null && _renderer.material != null)
            {
                _renderer.material.color = color;
            }
        }

        private void OnValidate()
        {
            if (Application.isPlaying && showVisual && _renderer != null && _renderer.material != null)
            {
                SetColor(webColor);
            }
        }

        /// <summary>
        /// Trigger 충돌 감지
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("attack_boat"))
            {
                Debug.Log($"[DynamicWeb] Trigger 충돌 감지: {other.gameObject.name}");
                HandleAttackBoatCollision(other.gameObject);
            }
            else if (IsDefenseShip(other.gameObject))
            {
                Debug.Log($"[DynamicWeb] 아군 선박과 그물 충돌: {other.gameObject.name}");
                HandleAllyWebCollision(other.gameObject);
            }
        }

        /// <summary>
        /// 아군 선박인지 확인
        /// </summary>
        private bool IsDefenseShip(GameObject obj)
        {
            if (obj == null)
                return false;

            if (defenseShip1 != null && obj.transform == defenseShip1)
                return true;
            if (defenseShip2 != null && obj.transform == defenseShip2)
                return true;

            if (obj.GetComponent<DefenseAgent>() != null)
                return true;

            return false;
        }

        /// <summary>
        /// 아군 선박 Web 충돌 처리
        /// </summary>
        private void HandleAllyWebCollision(GameObject allyShip)
        {
            if (allyShip == null)
                return;

            if (envController == null)
            {
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                envController = envRoot.GetComponentInChildren<DefenseEnvController>();
            }

            if (envController != null)
            {
                envController.OnAllyHitWeb(allyShip, allyWebCollisionPenalty);
            }
        }

        /// <summary>
        /// 물리 충돌 감지
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("attack_boat"))
            {
                HandleAttackBoatCollision(collision.gameObject);
            }
            else if (IsDefenseShip(collision.gameObject))
            {
                HandleAllyWebCollision(collision.gameObject);
            }
        }

        /// <summary>
        /// attack_boat과의 충돌 처리
        /// </summary>
        private void HandleAttackBoatCollision(GameObject attackBoat)
        {
            if (attackBoat == null)
                return;

            if (envController == null)
            {
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                envController = envRoot.GetComponentInChildren<DefenseEnvController>();
                if (envController == null)
                {
                    Debug.LogWarning("[DynamicWeb] DefenseEnvController를 찾을 수 없습니다!");
                    return;
                }
            }

            Debug.Log($"[DynamicWeb] ========== 그물 충돌 감지 (Collision)! ==========");
            Debug.Log($"[DynamicWeb] 적군 선박: {attackBoat.name}");
            Debug.Log($"[DynamicWeb] 적군 위치: {attackBoat.transform.position}");
            Debug.Log($"[DynamicWeb] 그물 위치: {transform.position}");
            Debug.Log($"[DynamicWeb] DefenseEnvController에 포획 알림 전송");
            
            envController.OnEnemyHitWeb(attackBoat);
            
            Debug.Log($"[DynamicWeb] ========================================");
        }

        /// <summary>
        /// 폭발 효과 생성
        /// </summary>
        private void CreateExplosion(Vector3 position)
        {
            if (explosionPrefab == null)
                return;

            Vector3 explosionPosition = position;
            explosionPosition.y += 0.5f;

            GameObject explosion = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

            if (explosion != null)
            {
                explosion.SetActive(true);
                float scaleMultiplier = explosionScale;
                explosion.transform.localScale = Vector3.one * scaleMultiplier;

                ParticleSystem[] particleSystems = explosion.GetComponentsInChildren<ParticleSystem>();
                foreach (var ps in particleSystems)
                {
                    var main = ps.main;

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
            }
        }

        /// <summary>
        /// 방어선에게 보상 부여
        /// </summary>
        private void RewardDefenseShips()
        {
            if (defenseShip1 != null)
            {
                var agent = defenseShip1.GetComponent<Unity.MLAgents.Agent>();
                if (agent != null)
                {
                    agent.AddReward(defenseReward);
                }
            }

            if (defenseShip2 != null)
            {
                var agent = defenseShip2.GetComponent<Unity.MLAgents.Agent>();
                if (agent != null)
                {
                    agent.AddReward(defenseReward);
                }
            }
        }

        /// <summary>
        /// attack_boat 리셋
        /// </summary>
        private void ResetAttackBoat(GameObject attackBoat)
        {
            if (attackBoat == null)
                return;

            if (envController == null)
            {
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                envController = envRoot.GetComponentInChildren<DefenseEnvController>();
            }

            if (envController != null)
            {
                envController.OnEnemyHitWeb(attackBoat);
            }
        }

        /// <summary>
        /// Gizmo 시각화
        /// </summary>
        private void OnDrawGizmos()
        {
            if (defenseShip1 == null || defenseShip2 == null)
                return;

            Vector3 pos1 = defenseShip1.position;
            Vector3 pos2 = defenseShip2.position;
            Vector3 centerPos = (pos1 + pos2) / 2f;

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(pos1, pos2);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(centerPos, 1f);
        }
    }
}
