using UnityEngine;
using UnityEngine.InputSystem;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Collections.Generic;
using System.Linq;

namespace BoatAttack
{
    /// <summary>
    /// 방어 에이전트: 2대가 협력하여 적군 선박을 web 사이로 유도하는 것이 목표
    /// 목표 속도 기반 액션 및 상대 좌표 기반 관측 사용
    /// 보상은 DefenseEnvController를 통해 그룹 보상으로 분배됨
    /// </summary>
    public class DefenseAgent : Agent
    {
        [Header("Boat Components")]
        [Tooltip("Boat 컴포넌트 (자동으로 찾음)")]
        private Boat _boat;

        [Tooltip("Engine 컴포넌트 (자동으로 찾음)")]
        public Engine _engine;

        [Header("Observation Settings")]
        [Tooltip("관측할 적군 선박들 (인스펙터에서 할당)")]
        public GameObject[] enemyShips = new GameObject[5];  // 최대 5대까지 지원

        [Tooltip("최대 관측 가능한 적군 수")]
        public int maxEnemyCount = 5;

        [Header("Target Settings")]
        [Tooltip("파트너 방어 선박 (다른 DefenseAgent)")]
        public DefenseAgent partnerAgent;

        [Tooltip("모선 (MotherShip 태그)")]
        public GameObject motherShip;

        [Tooltip("모선 태그")]
        public string motherShipTag = "MotherShip";

        [Tooltip("Web 오브젝트 (충돌 감지용, 2대 사이에 배치)")]
        public GameObject webObject;

        [Header("Action Settings")]
        [Tooltip("최대 선속도 (m/s)")]
        public float maxLinearVelocity = 200f;

        [Tooltip("최대 각속도 (deg/s)")]
        public float maxAngularVelocity = 90f;

        [Tooltip("속도 제어 게인 (PID 또는 비례 제어) - 높을수록 빠른 가속")]
        public float velocityControlGain = 2.5f;  // 1.0 → 2.5로 증가 (더 빠른 가속)

        [Tooltip("각속도 제어 게인")]
        public float angularVelocityControlGain = 1.0f;

        [Tooltip("최대 선가속도 (m/s²) - 물리적 한계 - 높을수록 빠른 가속")]
        public float maxLinearAcceleration = 12f;  // 5 → 12로 증가 (더 빠른 가속)

        [Tooltip("최대 각가속도 (deg/s²) - 물리적 한계")]
        public float maxAngularAcceleration = 45f;

        [Header("Control Settings")]
        [Range(0f, 1f)]
        [Tooltip("기본 전진값 (키 입력 없을 때 적용)")]
        public float baseThrottle = 0.5f;

        [Range(0f, 1f)]
        [Tooltip("최소 전진값 (후진 방지용, 이 값 이하로 내려가지 않음)")]
        public float minThrottle = 0.5f;

        [Range(0.1f, 2.0f)]
        [Tooltip("조종 감도 조절")]
        public float steeringSensitivity = 0.3f;

        [Range(0.01f, 1.0f)]
        [Tooltip("입력 스무스 처리 (1.0 = 즉각 반응, 0.5 = 부드러움)")]
        public float inputSmoothing = 1.0f;  // 1.0 = 스무딩 없음 (즉각 반응)

        [Header("Debug")]
        [Tooltip("에디터에서 Raycast 시각화")]
        public bool showRaycasts = true;

        [Tooltip("디버그 로그 활성화")]
        public bool enableDebugLog = true;  // 기본값을 true로 변경하여 디버깅 용이하게

        [Header("Reward Display")]
        [Tooltip("현재 에피소드의 총 보상")]
        #pragma warning disable CS0414
        [SerializeField] private float _totalReward = 0f;
        [SerializeField] private float _lastStepReward = 0f;
        #pragma warning restore CS0414

        // 내부 변수
        private bool _episodeEnded = false;

        // 저주파 필터 (Low-Pass Filter) - 이전 명령과의 연속성 부여
        private float _prevThrottle = 0f;
        private float _prevSteering = 0f;

        // 개별 보상용 이전 헤딩 저장
        private float _prevHeading = 0f;
        private bool _hasPrevHeading = false;

        /// <summary>
        /// 이전 프레임의 헤딩값 반환 (개별 보상 계산용)
        /// </summary>
        public float PreviousHeading => _prevHeading;

        /// <summary>
        /// 이전 헤딩값이 유효한지 여부
        /// </summary>
        public bool HasPreviousHeading => _hasPrevHeading;

        /// <summary>
        /// 현재 헤딩을 이전 헤딩으로 저장 (매 프레임 호출)
        /// </summary>
        public void UpdatePreviousHeading()
        {
            _prevHeading = transform.eulerAngles.y;
            _hasPrevHeading = true;
        }

        private new void Awake()
        {
            // Boat와 Engine 컴포넌트 찾기
            if (TryGetComponent(out _boat))
            {
                _engine = _boat.engine;
            }
            else
            {
                Debug.LogError($"[DefenseAgent] Boat 컴포넌트를 찾을 수 없습니다. {gameObject.name}");
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            // 모선 찾기
            if (motherShip == null)
            {
                var ship = GameObject.FindGameObjectWithTag(motherShipTag);
                if (ship != null)
                {
                    motherShip = ship;
                }
                else
                {
                    Debug.LogWarning($"[DefenseAgent] 모선을 찾을 수 없습니다. 태그: {motherShipTag}");
                }
            }
        }
        
        private void Start()
        {
            // DecisionRequester 확인
            var decisionRequester = GetComponent<Unity.MLAgents.DecisionRequester>();
            if (decisionRequester == null)
            {
                Debug.LogError($"[DefenseAgent] ⚠️ DecisionRequester 컴포넌트가 없습니다! {gameObject.name}\n" +
                              "Add Component → Decision Requester를 추가하세요.");
            }
            else
            {
                if (enableDebugLog)
                {
                    Debug.Log($"[DefenseAgent] DecisionRequester 확인됨: {gameObject.name}, " +
                             $"Decision Period: {decisionRequester.DecisionPeriod}, " +
                             $"Take Actions Between Decisions: {decisionRequester.TakeActionsBetweenDecisions}");
                }
            }
            
            // Behavior Parameters 확인
            var behaviorParams = GetComponent<Unity.MLAgents.Policies.BehaviorParameters>();
            if (behaviorParams != null)
            {
                if (enableDebugLog)
                {
                    Debug.Log($"[DefenseAgent] Behavior Parameters 확인됨: {gameObject.name}, " +
                             $"Behavior Name: {behaviorParams.BehaviorName}, " +
                             $"Behavior Type: {behaviorParams.BehaviorType}");
                }
            }
            
            // Engine 확인
            if (_engine == null)
            {
                Debug.LogError($"[DefenseAgent] ⚠️ Engine이 null입니다! {gameObject.name}\n" +
                             "Boat 컴포넌트와 Engine이 제대로 설정되어 있는지 확인하세요.");
            }
            else if (_engine.RB == null)
            {
                Debug.LogError($"[DefenseAgent] ⚠️ Engine.RB (Rigidbody)가 null입니다! {gameObject.name}");
            }
            else
            {
                if (enableDebugLog)
                {
                    Debug.Log($"[DefenseAgent] Engine 확인됨: {gameObject.name}, " +
                             $"maxLinearVelocity: {maxLinearVelocity}, maxAngularVelocity: {maxAngularVelocity}");
                }
            }
        }

        public override void OnEpisodeBegin()
        {
            _episodeEnded = false;
            _totalReward = 0f;
            _lastStepReward = 0f;
            _prevThrottle = 0.5f;  // Mapping 최소값 (0.5~1.0 범위)
            _prevSteering = 0f;
            _prevHeading = transform.eulerAngles.y;
            _hasPrevHeading = false;  // 첫 프레임에는 이전 헤딩 없음

            // PushBlockEnvController 패턴: 
            // ML-Agents가 자동으로 OnEpisodeBegin을 호출하므로,
            // 환경 리셋은 DefenseEnvController.ResetScene()에서 처리됨
            // 여기서는 에이전트 자체의 상태만 초기화

            if (enableDebugLog)
            {
                Debug.Log($"[DefenseAgent] 에피소드 시작: {gameObject.name} (ML-Agents 자동 호출)");
            }
        }

        /// <summary>
        /// 관측 수집 (상대 좌표 기반 - 좌우 편향 방지)
        /// - 자신: 헤딩, 속도 = 2개 (절대 위치 제거로 좌우 편향 방지)
        /// - 팀원: 상대 위치(x,z), 상대 헤딩, 속도 = 4개
        /// - 적군들: 상대 위치(x,z), 상대 헤딩, 속도 = 4 × 적군수 (거리순 정렬)
        /// - 모선: 상대 위치(x,z), 거리 = 3개
        /// 총 관측: 2 + 4 + (4 × 5) + 3 = 29개
        /// </summary>
        public override void CollectObservations(VectorSensor sensor)
        {
            if (_engine == null || _engine.RB == null)
            {
                // 기본값 추가: 2 + 4 + (4 * maxEnemyCount) + 3 = 29
                int totalObservations = 2 + 4 + (4 * maxEnemyCount) + 3;
                for (int i = 0; i < totalObservations; i++)
                {
                    sensor.AddObservation(0f);
                }
                return;
            }

            Vector3 myPos = transform.position;
            Vector3 myForward = transform.forward;
            Vector3 myRight = transform.right;
            float myAngle = transform.eulerAngles.y;

            // === 1. 자신의 상태 (2개) - 절대 위치 제거 (좌우 편향 방지) ===
            // 헤딩과 속도만 유지 - 두 에이전트가 같은 정책을 공유할 때 대칭성 보장
            sensor.AddObservation(myAngle / 360f);
            sensor.AddObservation(_engine.RB.velocity.magnitude / 20f);

            // === 2. 팀원(파트너) 상태 (4개) - 상대 좌표로 변경 ===
            if (partnerAgent != null && partnerAgent._engine != null && partnerAgent._engine.RB != null)
            {
                Vector3 relativeToPartner = partnerAgent.transform.position - myPos;
                // 상대 위치를 로컬 좌표계로 변환
                float relativeX = Vector3.Dot(relativeToPartner, myRight) / 100f;
                float relativeZ = Vector3.Dot(relativeToPartner, myForward) / 100f;
                float relativeDistance = relativeToPartner.magnitude / 100f;
                float relativeAngle = Mathf.DeltaAngle(myAngle, partnerAgent.transform.eulerAngles.y) / 180f;  // -1~1

                sensor.AddObservation(relativeX);
                sensor.AddObservation(relativeZ);
                sensor.AddObservation(relativeAngle);
                sensor.AddObservation(partnerAgent._engine.RB.velocity.magnitude / 20f);
            }
            else
            {
                sensor.AddObservation(0f);
                sensor.AddObservation(0f);
                sensor.AddObservation(0f);
                sensor.AddObservation(0f);
            }

            // === 3. 적군 선박들 (4 × maxEnemyCount) - 거리 기반 정렬 + 상대 좌표 ===
            // 먼저 적군을 거리순으로 정렬 (활성화된 적군만)
            List<(GameObject enemy, float distance)> sortedEnemies = new List<(GameObject, float)>();
            for (int i = 0; i < enemyShips.Length && i < maxEnemyCount; i++)
            {
                // null 체크 + 활성화 체크 (Stage1에서 비활성화된 적군 제외)
                if (enemyShips[i] != null && enemyShips[i].activeInHierarchy)
                {
                    float dist = Vector3.Distance(myPos, enemyShips[i].transform.position);
                    sortedEnemies.Add((enemyShips[i], dist));
                }
            }
            sortedEnemies.Sort((a, b) => a.distance.CompareTo(b.distance));  // 가까운 순으로 정렬

            // 정렬된 적군을 관측값에 추가
            for (int i = 0; i < maxEnemyCount; i++)
            {
                if (i < sortedEnemies.Count)
                {
                    GameObject enemy = sortedEnemies[i].enemy;
                    Vector3 relativeToEnemy = enemy.transform.position - myPos;

                    // 상대 좌표 (로컬 좌표계)
                    float relativeX = Vector3.Dot(relativeToEnemy, myRight) / 100f;
                    float relativeZ = Vector3.Dot(relativeToEnemy, myForward) / 100f;
                    float relativeDistance = relativeToEnemy.magnitude / 100f;
                    float relativeAngle = Mathf.DeltaAngle(myAngle, enemy.transform.eulerAngles.y) / 180f;

                    sensor.AddObservation(relativeX);
                    sensor.AddObservation(relativeZ);
                    sensor.AddObservation(relativeAngle);
                    
                    Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                    sensor.AddObservation(enemyRb != null ? enemyRb.velocity.magnitude / 20f : 0f);
                }
                else
                {
                    // 0으로 채움
                    sensor.AddObservation(0f);
                    sensor.AddObservation(0f);
                    sensor.AddObservation(0f);
                    sensor.AddObservation(0f);
                }
            }

            // === 4. 모선 상대거리 (3개) - 상대 좌표 ===
            if (motherShip != null)
            {
                Vector3 relativePos = motherShip.transform.position - myPos;
                float relativeX = Vector3.Dot(relativePos, myRight) / 1000f;
                float relativeZ = Vector3.Dot(relativePos, myForward) / 1000f;
                sensor.AddObservation(relativeX);
                sensor.AddObservation(relativeZ);
                sensor.AddObservation(relativePos.magnitude / 1000f);
            }
            else
            {
                sensor.AddObservation(0f);
                sensor.AddObservation(0f);
                sensor.AddObservation(0f);
            }
        }

        /// <summary>
        /// 액션 수신 및 실행 (목표 속도 기반)
        /// - actions[0]: 목표 선속도 (정규화: -1~1)
        /// - actions[1]: 목표 각속도 (정규화: -1~1)
        /// </summary>
        public override void OnActionReceived(ActionBuffers actions)
        {
            if (_engine == null || _engine.RB == null || _episodeEnded)
            {
                if (enableDebugLog && (_engine == null || _engine.RB == null))
                {
                    Debug.LogWarning($"[DefenseAgent] _engine 또는 RB가 null입니다! {gameObject.name}, " +
                                   $"_engine={_engine != null}, RB={(_engine != null && _engine.RB != null)}");
                }
                return;
            }

            // 액션 값 직접 사용 (정규화된 값 -1~1)
            float throttleInput = actions.ContinuousActions[0];  // 전진/후진: -1(후진) ~ 1(전진)
            float steeringInput = actions.ContinuousActions[1];   // 좌회전/우회전: -1(좌) ~ 1(우)
            
            // ⚠️ NaN 방지
            if (float.IsNaN(throttleInput) || float.IsInfinity(throttleInput))
            {
                throttleInput = 0f;
            }
            if (float.IsNaN(steeringInput) || float.IsInfinity(steeringInput))
            {
                steeringInput = 0f;
            }
            
            // Steering 범위 제한
            steeringInput = Mathf.Clamp(steeringInput, -1f, 1f);

            // Throttle: Mapping 방식 (-1~1 → 0.5~1.0)
            // -1 → 0.5, 0 → 0.75, 1 → 1.0
            float throttle = (throttleInput + 1f) * 0.25f + 0.5f;

            // Steering에 감도 적용
            float steering = steeringInput * steeringSensitivity;
            steering = Mathf.Clamp(steering, -1f, 1f);

            // ⚠️ 저주파 필터 제거 - 즉각적인 반응으로 변경
            // 필요시 inputSmoothing으로 스무딩 활성화 가능
            if (inputSmoothing < 1f)
            {
                throttle = Mathf.Lerp(_prevThrottle, throttle, inputSmoothing);
                steering = Mathf.Lerp(_prevSteering, steering, inputSmoothing);
            }
            _prevThrottle = throttle;
            _prevSteering = steering;

            // Engine에 전달
            _engine.Accelerate(throttle);
            _engine.Turn(steering);
            
            // 디버그: Engine 제어 값 출력
            if (enableDebugLog && (Mathf.Abs(throttle) > 0.01f || Mathf.Abs(steering) > 0.01f))
            {
                if (Time.frameCount % 30 == 0)  // 0.5초마다 로그
                {
                    Debug.Log($"[DefenseAgent] Engine 제어: {gameObject.name}, " +
                             $"Throttle={throttle:F2}, Steering={steering:F2}");
                }
            }

            // ⚠️ 개별 보상 제거 - DefenseEnvController에서 그룹 보상으로 처리
        }

        /// <summary>
        /// Web-적군 충돌 처리 (외부에서 호출)
        /// DefenseEnvController로 전달하여 그룹 보상으로 처리
        /// </summary>
        public void OnEnemyCaptured(Vector3 enemyPosition)
        {
            if (_episodeEnded)
                return;

            _episodeEnded = true;

            // DefenseEnvController에 알림 (그룹 보상으로 처리)
            DefenseEnvController envController = FindObjectOfType<DefenseEnvController>();
            if (envController != null)
            {
                envController.OnEnemyCaptured(enemyPosition);
            }

            if (enableDebugLog)
            {
                Debug.Log($"[DefenseAgent] 포획 성공! {gameObject.name}");
            }

            // 에피소드 종료는 DefenseEnvController에서 처리
        }

        /// <summary>
        /// 수동 조종 (키보드 테스트용) - 직접 throttle/steering 출력
        /// Agent1: WASD
        /// Agent2: Arrow Keys
        /// Unity의 새로운 Input System (UnityEngine.InputSystem)을 사용합니다.
        /// ⚠️ 주의: ML-Agents에서 Heuristic을 사용하려면 DecisionRequester 컴포넌트가 필요합니다
        /// </summary>
        public override void Heuristic(in ActionBuffers actionsOut)
        {
            var continuousActions = actionsOut.ContinuousActions;

            // Unity Input System 사용 (Legacy Input 대신)
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
            {
                // 키보드가 없으면 0으로 설정
                continuousActions[0] = 0f;
                continuousActions[1] = 0f;
                if (enableDebugLog && Time.frameCount % 60 == 0)
                {
                    Debug.LogWarning($"[DefenseAgent] 키보드를 찾을 수 없습니다! {gameObject.name}");
                }
                return;
            }

            // 키보드 입력을 throttle/steering으로 직접 변환 (-1~1)
            // 기본 전진값 적용 (키 안 눌러도 전진)
            float throttle = baseThrottle;
            float steering = 0f;
            
            // Agent 이름으로 구분 (더 유연한 매칭)
            string agentName = gameObject.name.ToLower();
            bool isAgent1 = agentName.Contains("1") || agentName.Contains("agent1") || agentName.Contains("defense1");
            bool isAgent2 = agentName.Contains("2") || agentName.Contains("agent2") || agentName.Contains("defense2");

            // 디버그: 키 입력 확인
            bool hasInput = false;

            if (isAgent1)
            {
                // WASD
                if (keyboard.wKey.isPressed)
                {
                    throttle = 1f;  // 전진
                    hasInput = true;
                }
                else if (keyboard.sKey.isPressed)
                {
                    throttle = -0.5f;  // 후진 (느리게)
                    hasInput = true;
                }

                if (keyboard.dKey.isPressed)
                {
                    steering = 1f;  // 우회전
                    hasInput = true;
                }
                else if (keyboard.aKey.isPressed)
                {
                    steering = -1f;  // 좌회전
                    hasInput = true;
                }
            }
            else if (isAgent2)
            {
                // Arrow Keys
                if (keyboard.upArrowKey.isPressed)
                {
                    throttle = 1f;
                    hasInput = true;
                }
                else if (keyboard.downArrowKey.isPressed)
                {
                    throttle = -0.5f;
                    hasInput = true;
                }

                if (keyboard.rightArrowKey.isPressed)
                {
                    steering = 1f;
                    hasInput = true;
                }
                else if (keyboard.leftArrowKey.isPressed)
                {
                    steering = -1f;
                    hasInput = true;
                }
            }
            else
            {
                // 기본값: 첫 번째 에이전트는 WASD, 나머지는 Arrow Keys
                // 또는 둘 다 같은 키 사용
                if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
                {
                    throttle = 1f;
                    hasInput = true;
                }
                else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
                {
                    throttle = -0.5f;
                    hasInput = true;
                }

                if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
                {
                    steering = 1f;
                    hasInput = true;
                }
                else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
                {
                    steering = -1f;
                    hasInput = true;
                }
            }

            // 액션 값 직접 출력 (-1~1)
            continuousActions[0] = Mathf.Clamp(throttle, -1f, 1f);
            continuousActions[1] = Mathf.Clamp(steering, -1f, 1f);
            
            // 디버그: 액션 값 출력
            if (enableDebugLog && hasInput && Time.frameCount % 30 == 0)
            {
                Debug.Log($"[DefenseAgent] Heuristic 호출됨 - 키 입력 감지: {gameObject.name}, " +
                         $"Throttle={continuousActions[0]:F2}, Steering={continuousActions[1]:F2}");
            }
        }

        /// <summary>
        /// 아군 충돌 감지
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            if (_episodeEnded)
                return;

            // 아군 또는 모선과 충돌 체크
            // DefenseAgent는 컴포넌트이므로 태그 대신 컴포넌트로 확인
            if (collision.gameObject.GetComponent<DefenseAgent>() != null || 
                collision.gameObject.CompareTag("MotherShip"))
            {
                DefenseEnvController envController = FindObjectOfType<DefenseEnvController>();
                if (envController != null)
                {
                    envController.OnFriendlyCollision();
                }
            }
        }

        /// <summary>
        /// Gizmo 시각화
        /// </summary>
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            // 자신 표시 (파란색)
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 2f);

            // 파트너와 연결선 (녹색)
            if (partnerAgent != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, partnerAgent.transform.position);
            }

            // 적군과 연결선 (빨간색)
            if (enemyShips != null)
            {
                Gizmos.color = Color.red;
                foreach (var enemy in enemyShips)
                {
                    if (enemy != null)
                    {
                        Gizmos.DrawLine(transform.position, enemy.transform.position);
                    }
                }
            }

            // Web 위치 표시 (노란색)
            if (webObject != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(webObject.transform.position, 3f);
            }
        }
    }
}
