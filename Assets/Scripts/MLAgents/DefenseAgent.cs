using UnityEngine;
using UnityEngine.InputSystem;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// 방어 에이전트: 2대가 협력하여 적군 선박을 web 사이로 유도
    /// 상대 좌표 기반 관측, 보상은 DefenseEnvController에서 그룹 보상으로 분배
    /// </summary>
    public class DefenseAgent : Agent
    {
        [Header("Boat Components")]
        private Boat _boat;
        public Engine _engine;

        [Header("Observation Settings")]
        [Tooltip("관측할 적군 선박들 (인스펙터에서 할당)")]
        public GameObject[] enemyShips = new GameObject[5];

        [Tooltip("최대 관측 가능한 적군 수")]
        public int maxEnemyCount = 5;

        [Header("Target Settings")]
        public DefenseAgent partnerAgent;
        public GameObject motherShip;
        public string motherShipTag = "MotherShip";
        public GameObject webObject;

        [Header("Action Settings")]
        public float maxLinearVelocity = 200f;
        public float maxAngularVelocity = 90f;
        public float velocityControlGain = 2.5f;
        public float angularVelocityControlGain = 1.0f;
        public float maxLinearAcceleration = 12f;
        public float maxAngularAcceleration = 45f;

        [Header("Control Settings")]
        [Range(-1f, 1f)]
        [Tooltip("Throttle 입력에 더해지는 기본 오프셋 (-1~1 입력을 이동시킴)")]
        public float throttleOffset = 0.2f;

        [Range(0f, 1f)]
        public float minThrottle = 0.5f;

        [Range(0.1f, 2.0f)]
        public float steeringSensitivity = 0.3f;

        [Range(0.01f, 1.0f)]
        [Tooltip("입력 스무스 처리 (1.0 = 즉각 반응)")]
        public float inputSmoothing = 1.0f;

        [Header("Debug")]
        public bool showRaycasts = true;
        public bool enableDebugLog = true;

        [Header("Reward Display")]
        #pragma warning disable CS0414
        [SerializeField] private float _totalReward = 0f;
        [SerializeField] private float _lastStepReward = 0f;
        #pragma warning restore CS0414

        private bool _episodeEnded = false;
        private float _prevThrottle = 0f;
        private float _prevSteering = 0f;

        // 명령 변화량 (이전 스텝과의 차이, 보상 계산용)
        private float _throttleDelta = 0f;
        private float _steeringDelta = 0f;

        public float PrevThrottle => _prevThrottle;
        public float PrevSteering => _prevSteering;
        public float ThrottleDelta => _throttleDelta;
        public float SteeringDelta => _steeringDelta;

        private new void Awake()
        {
            if (TryGetComponent(out _boat))
            {
                _engine = _boat.engine;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (motherShip == null)
            {
                // 멀티 환경 호환: 같은 환경 계층 내에서 먼저 찾기
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                var allWithTag = GameObject.FindGameObjectsWithTag(motherShipTag);
                foreach (var obj in allWithTag)
                {
                    if (obj != null && obj.transform.IsChildOf(envRoot))
                    {
                        motherShip = obj;
                        break;
                    }
                }
                // 환경 내에서 못 찾으면 글로벌 fallback
                if (motherShip == null && allWithTag.Length > 0)
                {
                    motherShip = allWithTag[0];
                }
            }
        }

        public override void OnEpisodeBegin()
        {
            _episodeEnded = false;
            _totalReward = 0f;
            _lastStepReward = 0f;
            _prevThrottle = 0f;
            _prevSteering = 0f;
            _throttleDelta = 0f;
            _steeringDelta = 0f;
        }

        /// <summary>
        /// 관측 수집 (상대 좌표 기반)
        /// 자신(4) + 팀원(4) + 적군(4×maxEnemyCount) + 모선(3) = 31개
        /// </summary>
        public override void CollectObservations(VectorSensor sensor)
        {
            if (_engine == null || _engine.RB == null)
            {
                int totalObservations = 4 + 4 + (4 * maxEnemyCount) + 3;
                for (int i = 0; i < totalObservations; i++)
                    sensor.AddObservation(0f);
                return;
            }

            Vector3 myPos = transform.position;
            Vector3 myForward = transform.forward;
            Vector3 myRight = transform.right;
            float myAngle = transform.eulerAngles.y;

            // 1. 자신 (4개: 헤딩, 속도, 이전추력, 이전조향)
            sensor.AddObservation(myAngle / 360f);
            sensor.AddObservation(_engine.RB.velocity.magnitude / 20f);
            sensor.AddObservation(_prevThrottle);
            sensor.AddObservation(_prevSteering);

            // 2. 팀원 (4개)
            if (partnerAgent != null && partnerAgent._engine != null && partnerAgent._engine.RB != null)
            {
                Vector3 relativeToPartner = partnerAgent.transform.position - myPos;
                sensor.AddObservation(Vector3.Dot(relativeToPartner, myRight) / 100f);
                sensor.AddObservation(Vector3.Dot(relativeToPartner, myForward) / 100f);
                sensor.AddObservation(Mathf.DeltaAngle(myAngle, partnerAgent.transform.eulerAngles.y) / 180f);
                sensor.AddObservation(partnerAgent._engine.RB.velocity.magnitude / 20f);
            }
            else
            {
                for (int i = 0; i < 4; i++) sensor.AddObservation(0f);
            }

            // 3. 적군 (4 × maxEnemyCount) - 거리순 정렬
            var sortedEnemies = new List<(GameObject enemy, float distance)>();
            for (int i = 0; i < enemyShips.Length && i < maxEnemyCount; i++)
            {
                if (enemyShips[i] != null && enemyShips[i].activeInHierarchy)
                {
                    float dist = Vector3.Distance(myPos, enemyShips[i].transform.position);
                    sortedEnemies.Add((enemyShips[i], dist));
                }
            }
            sortedEnemies.Sort((a, b) => a.distance.CompareTo(b.distance));

            for (int i = 0; i < maxEnemyCount; i++)
            {
                if (i < sortedEnemies.Count)
                {
                    GameObject enemy = sortedEnemies[i].enemy;
                    Vector3 relativeToEnemy = enemy.transform.position - myPos;
                    sensor.AddObservation(Vector3.Dot(relativeToEnemy, myRight) / 100f);
                    sensor.AddObservation(Vector3.Dot(relativeToEnemy, myForward) / 100f);
                    sensor.AddObservation(Mathf.DeltaAngle(myAngle, enemy.transform.eulerAngles.y) / 180f);

                    Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                    sensor.AddObservation(enemyRb != null ? enemyRb.velocity.magnitude / 20f : 0f);
                }
                else
                {
                    for (int j = 0; j < 4; j++) sensor.AddObservation(0f);
                }
            }

            // 4. 모선 (3개)
            if (motherShip != null)
            {
                Vector3 relativePos = motherShip.transform.position - myPos;
                sensor.AddObservation(Vector3.Dot(relativePos, myRight) / 1000f);
                sensor.AddObservation(Vector3.Dot(relativePos, myForward) / 1000f);
                sensor.AddObservation(relativePos.magnitude / 1000f);
            }
            else
            {
                for (int i = 0; i < 3; i++) sensor.AddObservation(0f);
            }
        }

        /// <summary>
        /// 액션 수신: actions[0]=throttle(-1~1), actions[1]=steering(-1~1)
        /// </summary>
        public override void OnActionReceived(ActionBuffers actions)
        {
            if (_engine == null || _engine.RB == null || _episodeEnded)
                return;

            float throttleInput = actions.ContinuousActions[0];
            float steeringInput = actions.ContinuousActions[1];

            // NaN 방지
            if (float.IsNaN(throttleInput) || float.IsInfinity(throttleInput)) throttleInput = 0f;
            if (float.IsNaN(steeringInput) || float.IsInfinity(steeringInput)) steeringInput = 0f;

            steeringInput = Mathf.Clamp(steeringInput, -1f, 1f);

            // Throttle Mapping: -1~1 → 0.0~1.0 (정지 허용)
            float throttle = (throttleInput + throttleOffset) * 1.0f;

            // Steering 감도 적용
            float steering = Mathf.Clamp(steeringInput * steeringSensitivity, -1f, 1f);

            // 스무딩 (inputSmoothing < 1일 때만)
            if (inputSmoothing < 1f)
            {
                throttle = Mathf.Lerp(_prevThrottle, throttle, inputSmoothing);
                steering = Mathf.Lerp(_prevSteering, steering, inputSmoothing);
            }
            // 명령 변화량 기록 (보상 계산용)
            _throttleDelta = Mathf.Abs(throttle - _prevThrottle);
            _steeringDelta = Mathf.Abs(steering - _prevSteering);

            _prevThrottle = throttle;
            _prevSteering = steering;

            _engine.Accelerate(throttle);
            _engine.Turn(steering);

            // 디버그 로그
            if (enableDebugLog)
            {
                Debug.Log($"[{gameObject.name}] Throttle: {throttle:F2}, Steering: {steering:F2}");
            }
        }

        /// <summary>
        /// Web-적군 충돌 처리 → DefenseEnvController로 전달
        /// </summary>
        public void OnEnemyCaptured(Vector3 enemyPosition)
        {
            if (_episodeEnded)
                return;

            _episodeEnded = true;

            // 멀티 환경 호환: 같은 환경 계층 내에서 컨트롤러 찾기
            Transform envRoot = transform.parent != null ? transform.parent : transform;
            DefenseEnvController envController = envRoot.GetComponentInChildren<DefenseEnvController>();
            if (envController != null)
            {
                envController.OnEnemyCaptured(enemyPosition);
            }
        }

        /// <summary>
        /// 수동 조종 (Agent1: WASD, Agent2: Arrow Keys)
        /// </summary>
        public override void Heuristic(in ActionBuffers actionsOut)
        {
            var continuousActions = actionsOut.ContinuousActions;

            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
            {
                continuousActions[0] = 0f;
                continuousActions[1] = 0f;
                return;
            }

            float throttle = 0f;
            float steering = 0f;

            string agentName = gameObject.name.ToLower();
            bool isAgent1 = agentName.Contains("1") || agentName.Contains("agent1") || agentName.Contains("defense1");
            bool isAgent2 = agentName.Contains("2") || agentName.Contains("agent2") || agentName.Contains("defense2");

            if (isAgent1)
            {
                if (keyboard.wKey.isPressed) throttle = 1f;
                else if (keyboard.sKey.isPressed) throttle = -0.5f;
                if (keyboard.dKey.isPressed) steering = 1f;
                else if (keyboard.aKey.isPressed) steering = -1f;
            }
            else if (isAgent2)
            {
                if (keyboard.upArrowKey.isPressed) throttle = 1f;
                else if (keyboard.downArrowKey.isPressed) throttle = -0.5f;
                if (keyboard.rightArrowKey.isPressed) steering = 1f;
                else if (keyboard.leftArrowKey.isPressed) steering = -1f;
            }
            else
            {
                if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) throttle = 1f;
                else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) throttle = -0.5f;
                if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) steering = 1f;
                else if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) steering = -1f;
            }

            continuousActions[0] = Mathf.Clamp(throttle, -1f, 1f);
            continuousActions[1] = Mathf.Clamp(steering, -1f, 1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_episodeEnded)
                return;

            if (collision.gameObject.GetComponent<DefenseAgent>() != null ||
                collision.gameObject.CompareTag("MotherShip"))
            {
                // 멀티 환경 호환: 같은 환경 계층 내에서 컨트롤러 찾기
                Transform envRoot = transform.parent != null ? transform.parent : transform;
                DefenseEnvController envController = envRoot.GetComponentInChildren<DefenseEnvController>();
                if (envController != null)
                {
                    envController.OnFriendlyCollision();
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 2f);

            if (partnerAgent != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, partnerAgent.transform.position);
            }

            if (enemyShips != null)
            {
                Gizmos.color = Color.red;
                foreach (var enemy in enemyShips)
                {
                    if (enemy != null)
                        Gizmos.DrawLine(transform.position, enemy.transform.position);
                }
            }

            if (webObject != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(webObject.transform.position, 3f);
            }
        }
    }
}
