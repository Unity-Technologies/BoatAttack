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

        [Header("Managers")]
        [Tooltip("환경 컨트롤러 (수동 할당 가능, 비어있으면 자동으로 찾음)")]
        public DefenseEnvController envController;

        private BoxCollider _collider;
        private MeshRenderer _renderer;
        private GameObject _visualObject;
        private Color _lastWebColor; // 마지막 색상 추적

        private void Start()
        {
            // 태그 확인
            Debug.Log($"[DynamicWeb] Start: GameObject 이름 = {gameObject.name}, Tag = {gameObject.tag}");

            // BoxCollider 추가 (충돌 감지용)
            _collider = gameObject.GetComponent<BoxCollider>();
            if (_collider == null)
            {
                _collider = gameObject.AddComponent<BoxCollider>();
                Debug.Log("[DynamicWeb] BoxCollider 새로 생성");
            }
            else
            {
                Debug.Log("[DynamicWeb] 기존 BoxCollider 사용");
            }

            _collider.isTrigger = isTrigger;
            Debug.Log($"[DynamicWeb] Collider 설정 - isTrigger: {_collider.isTrigger}, size: {_collider.size}, center: {_collider.center}");

            // Rigidbody 확인 (RequireComponent로 자동 추가됨)
            // 런타임 AddComponent 제거 - ML-Agents 빌드 호환성 문제 방지
            var rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log($"[DynamicWeb] 기존 Rigidbody 사용: isKinematic = {rb.isKinematic}, useGravity = {rb.useGravity}");
            }

            // 시각화 오브젝트 생성
            if (showVisual)
            {
                CreateVisual();
            }

            // 초기 색상 저장
            _lastWebColor = webColor;
            
            // DefenseEnvController 찾기 및 캐싱
            // Inspector에서 할당되지 않았으면 자동으로 찾기
            if (envController == null)
            {
                envController = FindObjectOfType<DefenseEnvController>();
                if (envController == null)
                {
                    Debug.LogWarning("[DynamicWeb] DefenseEnvController를 찾을 수 없습니다. 적군 선박 파괴 추적이 작동하지 않을 수 있습니다.");
                }
                else
                {
                    Debug.Log("[DynamicWeb] DefenseEnvController 자동 발견 및 할당 완료");
                }
            }
            else
            {
                Debug.Log("[DynamicWeb] DefenseEnvController Inspector에서 할당됨");
            }

            Debug.Log("[DynamicWeb] Start 완료 - 충돌 감지 준비됨");
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

            // 디버그: Collider 정보 주기적으로 출력
            LogColliderInfo();
        }

        /// <summary>
        /// Web 위치 및 크기 업데이트
        /// </summary>
        private void UpdateWebTransform()
        {
            // Anchor가 할당되어 있으면 Anchor 사용, 아니면 선박 중심 사용
            Vector3 pos1 = (webAnchor1 != null) ? webAnchor1.position : defenseShip1.position;
            Vector3 pos2 = (webAnchor2 != null) ? webAnchor2.position : defenseShip2.position;

            // Web 중심 위치 (두 앵커/선박 중간)
            Vector3 centerPos = (pos1 + pos2) / 2f;
            transform.position = centerPos;

            // Web 회전 (두 점을 연결하는 방향)
            Vector3 direction = pos2 - pos1;
            direction.y = 0f; // Y축 회전만 고려
            if (direction.magnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }

            // Web 크기 (두 점 간 거리)
            float distance = Vector3.Distance(pos1, pos2);

            // BoxCollider 크기 조정
            if (_collider != null)
            {
                // X축: 두께, Y축: 높이, Z축: 거리
                _collider.size = new Vector3(webThickness, webHeight, distance);
            }

            // Visual 크기 조정
            if (_visualObject != null)
            {
                _visualObject.transform.localScale = new Vector3(webThickness, webHeight, distance);
            }
        }

        // 디버그용: Collider 정보 표시
        private float _lastLogTime = 0f;
        private void LogColliderInfo()
        {
            // 5초마다 한 번씩 로그
            if (Time.time - _lastLogTime > 5f)
            {
                _lastLogTime = Time.time;
                if (_collider != null)
                {
                    Debug.Log($"[DynamicWeb] Collider 정보 - Position: {transform.position}, Size: {_collider.size}, IsTrigger: {_collider.isTrigger}, Enabled: {_collider.enabled}");
                }
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

            // Collider 제거 (부모의 Collider만 사용)
            Destroy(_visualObject.GetComponent<BoxCollider>());

            // Material 설정
            _renderer = _visualObject.GetComponent<MeshRenderer>();
            if (_renderer != null)
            {
                Material mat = new Material(Shader.Find("Standard"));
                mat.color = webColor;

                // 반투명 설정
                mat.SetFloat("_Mode", 3); // Transparent
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 3000;

                _renderer.material = mat;

                Debug.Log($"[DynamicWeb] CreateVisual 완료: webColor = {webColor}, Material.color = {mat.color}");
            }
            else
            {
                Debug.LogError("[DynamicWeb] CreateVisual 실패: _renderer가 null입니다!");
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
            // 경고 로그 제거 - showVisual=false이거나 초기화 전일 수 있음 (정상 동작)
        }

        /// <summary>
        /// Inspector에서 값이 변경될 때 호출 (에디터 전용)
        /// </summary>
        private void OnValidate()
        {
            // 런타임에서만 색상 변경 적용 (showVisual && _renderer가 준비된 경우만)
            if (Application.isPlaying && showVisual && _renderer != null && _renderer.material != null)
            {
                SetColor(webColor);
            }
            // 경고 로그 제거 - 초기화 전에 OnValidate가 호출될 수 있음 (정상 동작)
        }

        /// <summary>
        /// Trigger 충돌 감지
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogWarning($"[DynamicWeb] ★★★ OnTriggerEnter 호출됨! ★★★");
            Debug.LogWarning($"[DynamicWeb] - 충돌한 객체: {other.gameObject.name}");
            Debug.LogWarning($"[DynamicWeb] - Tag: '{other.tag}'");
            Debug.LogWarning($"[DynamicWeb] - Layer: {LayerMask.LayerToName(other.gameObject.layer)}");
            Debug.LogWarning($"[DynamicWeb] - Position: {other.transform.position}");

            // attack_boat 태그를 가진 오브젝트와 충돌했는지 확인 (적군 포획)
            if (other.CompareTag("attack_boat"))
            {
                Debug.LogError($"[DynamicWeb] ★★★ attack_boat 충돌 감지!!! {other.gameObject.name} ★★★");
                Debug.LogError($"[DynamicWeb] HandleAttackBoatCollision 호출 직전");

                try
                {
                    HandleAttackBoatCollision(other.gameObject);
                    Debug.LogError($"[DynamicWeb] HandleAttackBoatCollision 호출 완료");
                }
                catch (System.Exception e)
                {
                    Debug.LogError($"[DynamicWeb] HandleAttackBoatCollision 실행 중 예외 발생: {e.Message}\n{e.StackTrace}");
                }
            }
            // 아군 선박이 Web과 충돌했는지 확인 (페널티)
            else if (IsDefenseShip(other.gameObject))
            {
                Debug.LogError($"[DynamicWeb] ★★★ 아군 선박 Web 충돌!!! {other.gameObject.name} ★★★");
                HandleAllyWebCollision(other.gameObject);
            }
            else
            {
                Debug.LogWarning($"[DynamicWeb] attack_boat/defense_boat 태그가 아닙니다. 현재 태그: '{other.tag}'");
            }
        }

        /// <summary>
        /// 아군 선박인지 확인
        /// </summary>
        private bool IsDefenseShip(GameObject obj)
        {
            // defenseShip1 또는 defenseShip2와 같은 오브젝트인지 확인
            if (defenseShip1 != null && obj.transform == defenseShip1)
                return true;
            if (defenseShip2 != null && obj.transform == defenseShip2)
                return true;

            // 또는 DefenseAgent 컴포넌트가 있는지 확인
            if (obj.GetComponent<DefenseAgent>() != null)
                return true;

            return false;
        }

        /// <summary>
        /// 아군 선박 Web 충돌 처리 (페널티 + 에피소드 종료)
        /// </summary>
        private void HandleAllyWebCollision(GameObject allyShip)
        {
            Debug.LogError($"[DynamicWeb] HandleAllyWebCollision: {allyShip.name}");

            if (envController == null)
            {
                envController = FindObjectOfType<DefenseEnvController>();
            }

            if (envController != null)
            {
                // DefenseEnvController에 아군 Web 충돌 알림
                envController.OnAllyHitWeb(allyShip, allyWebCollisionPenalty);
            }
            else
            {
                Debug.LogError("[DynamicWeb] DefenseEnvController를 찾을 수 없습니다!");
            }
        }

        /// <summary>
        /// 물리 충돌 감지 (Trigger가 아닌 경우)
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            Debug.LogWarning($"[DynamicWeb] ★★★ OnCollisionEnter 호출됨! ★★★");
            Debug.LogWarning($"[DynamicWeb] - 충돌한 객체: {collision.gameObject.name}");
            Debug.LogWarning($"[DynamicWeb] - Tag: '{collision.gameObject.tag}'");
            Debug.LogWarning($"[DynamicWeb] - Layer: {LayerMask.LayerToName(collision.gameObject.layer)}");
            Debug.LogWarning($"[DynamicWeb] - Position: {collision.transform.position}");

            // attack_boat 태그를 가진 오브젝트와 충돌했는지 확인 (적군 포획)
            if (collision.gameObject.CompareTag("attack_boat"))
            {
                Debug.LogError($"[DynamicWeb] ★★★ attack_boat 충돌 감지!!! {collision.gameObject.name} ★★★");
                HandleAttackBoatCollision(collision.gameObject);
            }
            // 아군 선박이 Web과 충돌했는지 확인 (페널티)
            else if (IsDefenseShip(collision.gameObject))
            {
                Debug.LogError($"[DynamicWeb] ★★★ 아군 선박 Web 충돌!!! {collision.gameObject.name} ★★★");
                HandleAllyWebCollision(collision.gameObject);
            }
            else
            {
                Debug.LogWarning($"[DynamicWeb] attack_boat/defense_boat 태그가 아닙니다. 현재 태그: '{collision.gameObject.tag}'");
            }
        }

        /// <summary>
        /// Trigger 지속 충돌 (디버그용)
        /// </summary>
        private void OnTriggerStay(Collider other)
        {
            // 프레임마다 출력하면 너무 많으니 생략
        }

        /// <summary>
        /// Collision 지속 충돌 (디버그용)
        /// </summary>
        private void OnCollisionStay(Collision collision)
        {
            // 프레임마다 출력하면 너무 많으니 생략
        }

        /// <summary>
        /// attack_boat과의 충돌 처리
        /// </summary>
        private void HandleAttackBoatCollision(GameObject attackBoat)
        {
            if (attackBoat == null)
            {
                return;
            }

            // DefenseEnvController에 직접 전달 (중복 처리 방지)
            // 폭발 효과, 보상 부여, 리셋 등 모든 처리는 OnEnemyHitWeb에서 일괄 처리
            if (envController == null)
            {
                envController = FindObjectOfType<DefenseEnvController>();
            }
            
            if (envController != null)
            {
                envController.OnEnemyHitWeb(attackBoat);
            }
        }

        /// <summary>
        /// 폭발 효과 생성
        /// </summary>
        private void CreateExplosion(Vector3 position)
        {
            Debug.LogError($"[DynamicWeb] CreateExplosion 호출: position = {position}");

            if (explosionPrefab == null)
            {
                Debug.LogError("[DynamicWeb] ★★★ explosionPrefab이 null입니다! 폭발 효과를 생성할 수 없습니다. ★★★");
                return;
            }

            Debug.LogError($"[DynamicWeb] explosionPrefab 확인 OK: {explosionPrefab.name}");


            // 폭발 효과 생성 위치 (약간 위로)
            Vector3 explosionPosition = position;
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

                Debug.Log($"[DynamicWeb] 폭발 효과 생성 완료: 위치 = {explosionPosition}, 크기 = {scaleMultiplier}x");
            }
            else
            {
                Debug.LogError("[DynamicWeb] 폭발 효과 생성 실패!");
            }
        }

        /// <summary>
        /// 방어선에게 보상 부여
        /// </summary>
        private void RewardDefenseShips()
        {
            Debug.LogError("[DynamicWeb] RewardDefenseShips 호출");

            // defenseShip1에게 보상
            if (defenseShip1 != null)
            {
                Debug.LogError($"[DynamicWeb] defenseShip1 확인: {defenseShip1.name}");
                var agent = defenseShip1.GetComponent<Unity.MLAgents.Agent>();
                if (agent != null)
                {
                    agent.AddReward(defenseReward);
                    Debug.LogError($"[DynamicWeb] ★★★ {defenseShip1.name}에게 보상 부여: +{defenseReward} ★★★");
                }
                else
                {
                    Debug.LogError($"[DynamicWeb] ★★★ {defenseShip1.name}에 Agent 컴포넌트가 없습니다! ★★★");
                }
            }
            else
            {
                Debug.LogError("[DynamicWeb] defenseShip1이 null입니다!");
            }

            // defenseShip2에게 보상
            if (defenseShip2 != null)
            {
                Debug.LogError($"[DynamicWeb] defenseShip2 확인: {defenseShip2.name}");
                var agent = defenseShip2.GetComponent<Unity.MLAgents.Agent>();
                if (agent != null)
                {
                    agent.AddReward(defenseReward);
                    Debug.LogError($"[DynamicWeb] ★★★ {defenseShip2.name}에게 보상 부여: +{defenseReward} ★★★");
                }
                else
                {
                    Debug.LogError($"[DynamicWeb] ★★★ {defenseShip2.name}에 Agent 컴포넌트가 없습니다! ★★★");
                }
            }
            else
            {
                Debug.LogError("[DynamicWeb] defenseShip2가 null입니다!");
            }
        }

        /// <summary>
        /// attack_boat 초기화 - 원점으로 리셋 (파괴하지 않음)
        /// </summary>
        private void ResetAttackBoat(GameObject attackBoat)
        {
            Debug.LogError($"[DynamicWeb] ResetAttackBoat 호출: {attackBoat.name}");

            if (attackBoat == null)
            {
                Debug.LogError("[DynamicWeb] attackBoat가 null입니다!");
                return;
            }

            // DefenseEnvController에 원점 리셋 요청 (파괴하지 않음)
            if (envController == null)
            {
                envController = FindObjectOfType<DefenseEnvController>();
                Debug.LogError($"[DynamicWeb] DefenseEnvController 재검색: {(envController != null ? "발견됨" : "찾을 수 없음")}");
            }
            
            if (envController != null)
            {
                Debug.LogError($"[DynamicWeb] DefenseEnvController.OnEnemyHitWeb() 호출: {attackBoat.name}");
                envController.OnEnemyHitWeb(attackBoat);
                Debug.LogError($"[DynamicWeb] DefenseEnvController.OnEnemyHitWeb() 호출 완료");
            }
            else
            {
                Debug.LogError("[DynamicWeb] ❌ DefenseEnvController를 찾을 수 없습니다!");
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

            // Web 범위 표시
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(pos1, pos2);

            // Web 중심 표시
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(centerPos, 1f);
        }
    }
}
