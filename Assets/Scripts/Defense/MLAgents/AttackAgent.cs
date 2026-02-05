using UnityEngine;
using UnityEngine.InputSystem;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

namespace BoatAttack
{
    /// <summary>
    /// 공격 에이전트: 모선에 접근하는 것이 목표
    /// 보상: 모선과의 거리가 가까울수록 보상
    /// </summary>
    public class AttackAgent : Agent, IHeuristicProvider
    {
        [Header("Boat Components")]
        [Tooltip("Boat 컴포넌트 (자동으로 찾음)")]
        private Boat _boat;
        
        [Tooltip("Engine 컴포넌트 (자동으로 찾음)")]
        private Engine _engine;
        
        [Header("Target Settings")]
        [Tooltip("공격 대상 모선 (태그로 찾거나 직접 할당)")]
        public GameObject targetMotherShip;
        
        [Tooltip("모선 태그 (targetMotherShip이 없을 때 사용)")]
        public string motherShipTag = "MotherShip";
        
        [Header("Observation Settings")]
        [Tooltip("Raycast로 주변 감지할 거리")]
        public float raycastDistance = 50f;
        
        [Tooltip("Raycast 방향 개수")]
        public int raycastCount = 8;
        
        [Header("Reward Settings")]
        [Tooltip("거리 기반 보상 계수 (가까울수록 높은 보상)")]
        public float distanceRewardMultiplier = 0.01f;
        
        [Tooltip("최대 보상 거리 (이 거리 이내면 보상)")]
        public float maxRewardDistance = 100f;
        
        [Tooltip("시간당 작은 페널티 (빠른 접근 유도)")]
        public float timePenalty = -0.001f;
        
        [Header("Control Settings")]
        [Range(0.1f, 2.0f)]
        [Tooltip("조종 감도 조절 (낮을수록 느림, 높을수록 빠름)")]
        public float steeringSensitivity = 0.3f;
        
        [Range(0.01f, 1.0f)]
        [Tooltip("입력 스무스 처리 속도 (낮을수록 더 부드러움, 높을수록 즉각 반응)")]
        public float inputSmoothing = 0.2f;
        
        [Header("Debug")]
        [Tooltip("에디터에서 Raycast 시각화")]
        public bool showRaycasts = true;
        
        [Header("Reward Display")]
        [Tooltip("현재 에피소드의 총 보상")]
        [SerializeField] private float _totalReward = 0f;

        [Header("Explosion Settings")]
        [Tooltip("폭발 효과 Prefab (War FX) - 자폭선박이 모선과 충돌 시 사용")]
        public GameObject explosionPrefab;
        
        [Tooltip("폭발 시 보상 (성공 보상)")]
        public float explosionReward = 50f;
        
        [Tooltip("폭발 효과 크기 배율")]
        [Range(5f, 50f)]
        public float explosionScale = 23f;
        
        [Header("Collision Detection")]
        [Tooltip("충돌 감지 방식: true=Trigger 사용 (보트 Collider의 Is Trigger 활성화 필요), false=물리 Collision 사용")]
        public bool useTriggerCollision = false;
        
        [Header("Waypoint Following")]
        [Tooltip("Waypoint를 따라갈지 여부 (true면 waypoint 경로를 따라가고, false면 모선을 직접 추적)")]
        public bool followWaypoints = true;
        
        [Tooltip("Waypoint 추적 모드일 때 모선 접근 거리 (이 거리 이내면 모선을 직접 추적)")]
        public float directChaseDistance = 50f;

        private float _lastDistance;
        private Vector3 _lastPosition;
        private float _episodeStartTime;
        
        // 스무스 입력을 위한 변수
        private float _smoothThrottle = 0f;
        private float _smoothSteering = 0f;
        
        // 폭발 관련 변수
        private bool _hasExploded = false;
        
        // Waypoint 추적 관련 변수 (AiController 참고)
        private int _currentWaypointIndex = 0;
        private Vector3 _currentWaypointPosition;
        private bool _waypointInitialized = false;

        private new void Awake()
        {
            // Boat와 Engine 컴포넌트 찾기
            if (TryGetComponent(out _boat))
            {
                _engine = _boat.engine;
            }
            else
            {
                Debug.LogError($"[AttackAgent] Boat 컴포넌트를 찾을 수 없습니다. {gameObject.name}");
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            // 모선 찾기
            if (targetMotherShip == null)
            {
                var ship = GameObject.FindGameObjectWithTag(motherShipTag);
                if (ship != null)
                {
                    targetMotherShip = ship;
                }
                else
                {
                    Debug.LogWarning($"[AttackAgent] 모선을 찾을 수 없습니다. 태그: {motherShipTag}");
                }
            }
            
            // Waypoint 초기화
            if (followWaypoints)
            {
                InitializeWaypoint();
            }
        }
        
        /// <summary>
        /// Waypoint 초기화 (첫 waypoint 할당)
        /// </summary>
        private void InitializeWaypoint()
        {
            if (WaypointGroup.Instance == null)
            {
                Debug.LogWarning("[AttackAgent] WaypointGroup.Instance가 null입니다. Waypoint를 따라갈 수 없습니다.");
                _waypointInitialized = false;
                return;
            }
            
            if (WaypointGroup.Instance.WPs == null || WaypointGroup.Instance.WPs.Count == 0)
            {
                Debug.LogWarning("[AttackAgent] Waypoint가 없습니다. Waypoint를 따라갈 수 없습니다.");
                _waypointInitialized = false;
                return;
            }
            
            // 첫 waypoint 할당
            _currentWaypointIndex = 0;
            var firstWaypoint = WaypointGroup.Instance.WPs[0];
            _currentWaypointPosition = firstWaypoint.point;
            _waypointInitialized = true;
            
            Debug.Log($"[AttackAgent] Waypoint 초기화 완료: 첫 waypoint = {_currentWaypointPosition}");
        }

        public override void OnEpisodeBegin()
        {
            // 에피소드 시작 시 초기화
            _episodeStartTime = Time.time;
            _totalReward = 0f; // 총 보상 초기화
            _smoothThrottle = 0f; // 스무스 입력 초기화
            _smoothSteering = 0f;
            _hasExploded = false; // 폭발 상태 초기화
            
            // Waypoint 초기화 (에피소드 재시작 시)
            if (followWaypoints)
            {
                InitializeWaypoint();
            }
            
            // 배 위치는 AttackBoatManager에서 재생성 시 설정되므로 여기서는 리셋하지 않음
            // 단, Rigidbody 속도 및 각속도만 리셋
            if (_engine != null && _engine.RB != null)
            {
                _engine.RB.velocity = Vector3.zero;
                _engine.RB.angularVelocity = Vector3.zero;
            }
            
            _lastPosition = transform.position;
            
            if (targetMotherShip != null)
            {
                _lastDistance = Vector3.Distance(transform.position, targetMotherShip.transform.position);
            }
            
            Debug.Log($"[AttackAgent] OnEpisodeBegin: 배 위치 = {transform.position}");
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            if (targetMotherShip == null || _engine == null)
            {
                // 관측 불가능한 경우 0으로 채움
                for (int i = 0; i < GetObservationSize(); i++)
                {
                    sensor.AddObservation(0f);
                }
                return;
            }

            // 1. 모선과의 상대 위치 (정규화)
            Vector3 toTarget = targetMotherShip.transform.position - transform.position;
            float distance = toTarget.magnitude;
            Vector3 direction = toTarget.normalized;
            
            sensor.AddObservation(distance / maxRewardDistance); // 거리 (0~1)
            sensor.AddObservation(direction.x); // 방향 X
            sensor.AddObservation(direction.z); // 방향 Z (Y는 무시)
            
            // 2. 자신의 속도 (정규화)
            float speed = _engine.RB.velocity.magnitude;
            sensor.AddObservation(Mathf.Clamp01(speed / 20f)); // 최대 속도 20 가정
            
            // 3. 자신의 방향 (forward 벡터)
            Vector3 forward = transform.forward;
            sensor.AddObservation(forward.x);
            sensor.AddObservation(forward.z);
            
            // 4. 모선 방향으로의 각도 (정규화)
            float angleToTarget = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
            sensor.AddObservation(angleToTarget / 180f); // -1 ~ 1
            
            // 5. Raycast로 주변 장애물 감지
            for (int i = 0; i < raycastCount; i++)
            {
                float angle = (360f / raycastCount) * i;
                Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
                
                RaycastHit hit;
                bool hasHit = Physics.Raycast(transform.position, rayDirection, out hit, raycastDistance);
                
                if (hasHit)
                {
                    sensor.AddObservation(1f - (hit.distance / raycastDistance)); // 거리 (0~1, 가까울수록 1)
                    // 장애물 타입 구분 (선택적)
                    sensor.AddObservation(hit.collider.CompareTag("boat") ? 1f : 0f);
                }
                else
                {
                    sensor.AddObservation(0f); // 장애물 없음
                    sensor.AddObservation(0f);
                }
            }
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            if (_engine == null)
            {
                return;
            }

            // Waypoint 추적 모드일 때 waypoint를 따라가도록 조정
            Vector3 targetDirection = GetTargetDirection();
            
            // Action 처리 (원본 입력)
            float rawThrottle = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
            float rawSteering = Mathf.Clamp(actions.ContinuousActions[1], -1f, 1f);
            
            // Waypoint 추적 모드일 때 방향 조정
            if (followWaypoints && _waypointInitialized)
            {
                // Waypoint 방향 계산
                Vector3 toWaypoint = (_currentWaypointPosition - transform.position).normalized;
                Vector3 forward = transform.forward;
                
                // Waypoint 방향과 현재 방향의 각도 차이 계산
                float angleToWaypoint = Vector3.SignedAngle(forward, toWaypoint, Vector3.up);
                
                // Waypoint 방향으로 조정 (하지만 ML-Agents의 학습을 방해하지 않도록 약간만 조정)
                // rawSteering에 waypoint 방향 힌트 추가
                float waypointSteeringHint = Mathf.Clamp(angleToWaypoint / 45f, -1f, 1f) * 0.3f; // 30% 힌트
                rawSteering = Mathf.Clamp(rawSteering + waypointSteeringHint, -1f, 1f);
                
                // Waypoint에 도달했는지 확인
                float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypointPosition);
                if (distanceToWaypoint < 10f) // 10미터 이내면 다음 waypoint로
                {
                    AdvanceToNextWaypoint();
                }
            }

            // 스무스 처리 (현실적인 반응)
            _smoothThrottle = Mathf.Lerp(_smoothThrottle, rawThrottle, inputSmoothing);
            _smoothSteering = Mathf.Lerp(_smoothSteering, rawSteering, inputSmoothing);
            
            // 감도 조절 적용 (HumanController와 동일)
            float adjustedSteering = Mathf.Clamp(_smoothSteering * steeringSensitivity, -1f, 1f);

            // Engine에 전달
            _engine.Accelerate(_smoothThrottle);
            _engine.Turn(adjustedSteering);

            // 보상 계산
            CalculateReward();
        }
        
        /// <summary>
        /// 현재 목표 방향 가져오기 (waypoint 또는 모선)
        /// </summary>
        private Vector3 GetTargetDirection()
        {
            if (followWaypoints && _waypointInitialized)
            {
                // 모선과의 거리가 가까우면 모선을 직접 추적
                if (targetMotherShip != null)
                {
                    float distanceToMotherShip = Vector3.Distance(transform.position, targetMotherShip.transform.position);
                    if (distanceToMotherShip < directChaseDistance)
                    {
                        return (targetMotherShip.transform.position - transform.position).normalized;
                    }
                }
                
                // 그 외에는 waypoint를 따라감
                return (_currentWaypointPosition - transform.position).normalized;
            }
            else
            {
                // Waypoint 추적 모드가 아니면 모선을 직접 추적
                if (targetMotherShip != null)
                {
                    return (targetMotherShip.transform.position - transform.position).normalized;
                }
            }
            
            return transform.forward;
        }
        
        /// <summary>
        /// 다음 waypoint로 진행
        /// </summary>
        private void AdvanceToNextWaypoint()
        {
            if (WaypointGroup.Instance == null || WaypointGroup.Instance.WPs == null || WaypointGroup.Instance.WPs.Count == 0)
            {
                return;
            }
            
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= WaypointGroup.Instance.WPs.Count)
            {
                // 마지막 waypoint에 도달하면 첫 번째로 돌아감 (루프)
                _currentWaypointIndex = 0;
            }
            
            var waypoint = WaypointGroup.Instance.WPs[_currentWaypointIndex];
            _currentWaypointPosition = waypoint.point;
            
            Debug.Log($"[AttackAgent] 다음 waypoint로 진행: {_currentWaypointIndex} = {_currentWaypointPosition}");
        }

        private void CalculateReward()
        {
            if (targetMotherShip == null)
            {
                return;
            }

            // 거리 기반 보상
            float currentDistance = Vector3.Distance(transform.position, targetMotherShip.transform.position);
            float rewardThisStep = 0f;
            
            // 거리가 가까워졌으면 보상
            if (currentDistance < _lastDistance)
            {
                float distanceImprovement = _lastDistance - currentDistance;
                rewardThisStep += distanceImprovement * distanceRewardMultiplier;
            }
            else if (currentDistance > _lastDistance)
            {
                // 거리가 멀어지면 작은 페널티
                float distanceWorsening = currentDistance - _lastDistance;
                rewardThisStep -= distanceWorsening * distanceRewardMultiplier * 0.5f;
            }

            // 최대 보상 거리 이내에 있으면 추가 보상
            if (currentDistance < maxRewardDistance)
            {
                float proximityReward = (maxRewardDistance - currentDistance) / maxRewardDistance;
                rewardThisStep += proximityReward * distanceRewardMultiplier * 0.1f;
            }

            // 시간 페널티 (빠른 접근 유도)
            rewardThisStep += timePenalty;

            // 보상 추가 및 총 보상 업데이트
            AddReward(rewardThisStep);
            _totalReward = GetCumulativeReward(); // ML-Agents의 총 보상 가져오기

            _lastDistance = currentDistance;
        }

        /// <summary>
        /// 관측 크기 계산 (디버깅용)
        /// </summary>
        private int GetObservationSize()
        {
            // 모선 정보: 5 (거리, 방향x2, 각도, 속도)
            // 자신 정보: 2 (방향x2)
            // Raycast: raycastCount * 2 (거리, 타입)
            return 7 + (raycastCount * 2);
        }

        /// <summary>
        /// Heuristic 함수: 키보드로 수동 테스트
        /// ML-Agents Behavior Type을 "Heuristic Only"로 설정하면 이 함수가 호출됩니다.
        /// Unity의 새로운 Input System (UnityEngine.InputSystem)을 사용합니다.
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
                return;
            }

            float throttle = 0f;
            float steering = 0f;

            // 가속/감속 (W/S 또는 위/아래 화살표)
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
            {
                throttle = 1f;
            }
            else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
            {
                throttle = -1f;
            }

            // 좌우 회전 (A/D 또는 왼쪽/오른쪽 화살표)
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            {
                steering = -1f;
            }
            else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            {
                steering = 1f;
            }

            // Action에 키보드 입력 전달
            continuousActions[0] = throttle;
            continuousActions[1] = steering;
        }

        /// <summary>
        /// 에디터에서 Raycast 시각화
        /// </summary>
        private void OnDrawGizmos()
        {
            if (!showRaycasts || targetMotherShip == null)
            {
                return;
            }

            // 모선 방향 표시
            Gizmos.color = Color.red;
            if (targetMotherShip != null)
            {
                Gizmos.DrawLine(transform.position, targetMotherShip.transform.position);
            }

            // Raycast 방향 표시
            Gizmos.color = Color.yellow;
            for (int i = 0; i < raycastCount; i++)
            {
                float angle = (360f / raycastCount) * i;
                Vector3 rayDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
                Vector3 endPoint = transform.position + rayDirection * raycastDistance;
                
                Gizmos.DrawLine(transform.position, endPoint);
            }
        }

        /// <summary>
        /// 에피소드 종료 조건 (선택적)
        /// </summary>
        private void CheckEpisodeEnd()
        {
            if (_hasExploded)
            {
                return;
            }

            if (targetMotherShip == null)
            {
                return;
            }

            float distance = Vector3.Distance(transform.position, targetMotherShip.transform.position);

            // 너무 멀어지면 실패
            if (distance > 500f)
            {
                AddReward(-1f); // 페널티
                EndEpisode();
            }

            // 시간 초과 (선택적)
            if (Time.time - _episodeStartTime > 300f) // 5분
            {
                EndEpisode();
            }
        }

        /// <summary>
        /// Trigger 충돌 감지 (IsTrigger가 활성화된 Collider)
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            if (!useTriggerCollision || _hasExploded)
            {
                return;
            }
            
            Debug.Log($"[AttackAgent] OnTriggerEnter 호출: {other.gameObject.name}, Tag: {other.tag}");
            
            // 충돌한 객체가 MotherShip인지 확인
            bool isMotherShip = IsMotherShip(other.gameObject);
            Debug.Log($"[AttackAgent] IsMotherShip 확인 결과: {isMotherShip}");
            
            if (isMotherShip)
            {
                Debug.Log("[AttackAgent] MotherShip 충돌 감지! 폭발 처리 시작");
                HandleMotherShipCollision(other.gameObject);
            }
            else
            {
                Debug.Log($"[AttackAgent] MotherShip이 아님. Tag: {other.tag}, Name: {other.gameObject.name}");
            }
        }

        /// <summary>
        /// Collision 충돌 감지 (물리 충돌)
        /// </summary>
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"[AttackAgent] OnCollisionEnter 호출: {collision.gameObject.name}, Tag: {collision.gameObject.tag}, useTriggerCollision: {useTriggerCollision}, _hasExploded: {_hasExploded}");
            
            if (_hasExploded)
            {
                Debug.Log("[AttackAgent] 이미 폭발했으므로 무시");
                return;
            }

            // 충돌한 객체가 MotherShip인지 먼저 확인
            bool isMotherShip = IsMotherShip(collision.gameObject);
            Debug.Log($"[AttackAgent] IsMotherShip 확인 결과: {isMotherShip}");
            
            // MotherShip과의 충돌은 useTriggerCollision 설정과 관계없이 항상 처리
            if (isMotherShip)
            {
                Debug.Log("[AttackAgent] MotherShip 충돌 감지! 폭발 처리 시작 (useTriggerCollision 설정 무시)");
                HandleMotherShipCollision(collision.gameObject);
                return;
            }
            
            // MotherShip이 아닌 경우, useTriggerCollision이 true면 무시
            if (useTriggerCollision)
            {
                Debug.Log("[AttackAgent] useTriggerCollision이 true이고 MotherShip이 아니므로 Collision 무시");
                return;
            }
            
            Debug.Log($"[AttackAgent] 일반 충돌: {collision.gameObject.name} (처리하지 않음)");
        }

        /// <summary>
        /// 충돌한 객체가 MotherShip인지 확인
        /// </summary>
        private bool IsMotherShip(GameObject obj)
        {
            if (obj == null)
            {
                Debug.LogWarning("[AttackAgent] IsMotherShip: obj가 null입니다");
                return false;
            }

            // 태그로 확인
            if (!string.IsNullOrEmpty(motherShipTag) && obj.CompareTag(motherShipTag))
            {
                Debug.Log($"[AttackAgent] IsMotherShip: 태그로 확인됨 ({motherShipTag})");
                return true;
            }

            // 직접 할당된 targetMotherShip과 비교
            if (targetMotherShip != null && obj == targetMotherShip)
            {
                Debug.Log("[AttackAgent] IsMotherShip: targetMotherShip과 일치");
                return true;
            }

            // 이름으로 확인 (선택적)
            if (obj.name.Contains("MotherShip") || obj.name.Contains("Mother"))
            {
                Debug.Log($"[AttackAgent] IsMotherShip: 이름으로 확인됨 ({obj.name})");
                return true;
            }

            Debug.Log($"[AttackAgent] IsMotherShip: 일치하지 않음. Tag: {obj.tag}, Name: {obj.name}, motherShipTag: {motherShipTag}");
            return false;
        }

        /// <summary>
        /// MotherShip과의 충돌 처리
        /// </summary>
        private void HandleMotherShipCollision(GameObject motherShip)
        {
            if (_hasExploded)
            {
                Debug.LogWarning("[AttackAgent] HandleMotherShipCollision: 이미 폭발했음");
                return;
            }

            Debug.Log($"[AttackAgent] HandleMotherShipCollision 호출! 폭발 처리 시작. MotherShip: {motherShip.name}");
            
            // 폭발 처리 (explosionPrefab이 없어도 진행)
            TriggerExplosion();
            
            // 보상 추가
            AddReward(explosionReward);
            Debug.Log($"[AttackAgent] 보상 추가: {explosionReward}, 총 보상: {GetCumulativeReward()}");
            
            // 폭발 효과가 보이도록 약간의 딜레이 후 에피소드 종료
            StartCoroutine(EndEpisodeAfterDelay(1.5f));
        }
        
        /// <summary>
        /// 딜레이 후 에피소드 종료 (폭발 효과가 보이도록)
        /// </summary>
        private System.Collections.IEnumerator EndEpisodeAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("[AttackAgent] 에피소드 종료");
            EndEpisode();
        }

        /// <summary>
        /// 폭발 효과 생성 및 처리
        /// </summary>
        private void TriggerExplosion()
        {
            if (_hasExploded)
            {
                Debug.LogWarning("[AttackAgent] TriggerExplosion: 이미 폭발했음");
                return;
            }

            Debug.Log($"[AttackAgent] TriggerExplosion 호출! 폭발 효과 생성 위치: {transform.position}");
            _hasExploded = true;

            // 폭발 효과 생성 검증
            if (explosionPrefab == null)
            {
                Debug.LogError("[AttackAgent] TriggerExplosion: explosionPrefab이 null입니다! Inspector에서 War FX 폭발 효과 Prefab을 할당해주세요.");
                Debug.LogError("[AttackAgent] 경로 예시: Assets/JMO Assets/WarFX/_Effects/Explosions/WFX_Explosion.prefab");
                return;
            }

            // 폭발 효과 생성 위치 (선박 위치, Y축은 약간 위로)
            Vector3 explosionPosition = transform.position;
            explosionPosition.y += 0.5f; // 폭발 효과가 선박 위에 보이도록
            
            // War FX 폭발 효과 생성
            GameObject explosion = Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
            
            // 폭발 효과 활성화 확인
            if (explosion != null)
            {
                explosion.SetActive(true);
                
                // 폭발 효과 크기 조정 (100 = 1.0배, 200 = 2.0배, 500 = 5.0배)
                float scaleMultiplier = explosionScale;
                explosion.transform.localScale = Vector3.one * scaleMultiplier;
                
                // 모든 ParticleSystem의 크기와 속도도 조정 (더 큰 폭발 효과)
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
                    
                    // Start Speed 증가 (폭발이 더 멀리 퍼지도록)
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
                
                Debug.Log($"[AttackAgent] 폭발 효과 생성 완료!");
                Debug.Log($"[AttackAgent] - 이름: {explosion.name}");
                Debug.Log($"[AttackAgent] - 위치: {explosionPosition}");
                Debug.Log($"[AttackAgent] - 크기 배율: {explosionScale}% ({scaleMultiplier}x)");
                Debug.Log($"[AttackAgent] - 활성화 상태: {explosion.activeSelf}");
                Debug.Log($"[AttackAgent] - ParticleSystem 개수: {particleSystems.Length}");
                
                if (particleSystems.Length == 0)
                {
                    Debug.LogWarning("[AttackAgent] 폭발 효과에 ParticleSystem이 없습니다! Prefab이 올바른지 확인하세요.");
                }
            }
            else
            {
                Debug.LogError("[AttackAgent] 폭발 효과 생성 실패! Instantiate가 null을 반환했습니다.");
            }
        }

        void Update()
        {
            // 에피소드 종료 조건 체크
            CheckEpisodeEnd();
        }
    }
}
