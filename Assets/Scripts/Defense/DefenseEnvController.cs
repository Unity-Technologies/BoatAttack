using UnityEngine;
using Unity.MLAgents;
using Cinemachine;
using System.Linq;

namespace BoatAttack
{
    /// <summary>
    /// 커리큘럼 학습 단계
    /// </summary>
    public enum TrainingStage
    {
        Stage1_Formation,   // 대형 유지 학습
        Stage2_Capture,     // 포획 보상 학습
        Stage3_Tactical     // 전술 기동 학습
    }

    /// <summary>
    /// 방어 환경 컨트롤러 (중앙 허브 버전)
    /// - 모든 에피소드 재시작 로직을 중앙에서 관리
    /// - 그룹 보상 분배 및 환경 관리
    /// - 선박 위치 리셋 및 적군 추적
    /// - 에피소드 시작/종료 관리
    /// - 커리큘럼 학습 단계별 보상 제어
    /// </summary>
    public class DefenseEnvController : MonoBehaviour
    {
        [Header("Training Stage")]
        [Tooltip("현재 학습 단계 (Stage1: 대형유지, Stage2: 포획, Stage3: 전술기동)")]
        public TrainingStage currentStage = TrainingStage.Stage1_Formation;

        [Tooltip("Stage1에서 적군 비활성화")]
        public bool disableEnemiesInStage1 = true;

        [Tooltip("Stage1에서 활성화할 적군 수 (disableEnemiesInStage1이 false일 때)")]
        [Range(0, 5)]
        public int stage1EnemyCount = 0;

        [Tooltip("Stage2에서 활성화할 적군 수")]
        [Range(1, 5)]
        public int stage2EnemyCount = 2;

        [Tooltip("Stage3에서 활성화할 적군 수")]
        [Range(1, 5)]
        public int stage3EnemyCount = 5;

        [Header("Agents")]
        [Tooltip("방어 에이전트 1")]
        public DefenseAgent defenseAgent1;
        
        [Tooltip("방어 에이전트 2")]
        public DefenseAgent defenseAgent2;
        
        [Header("Components")]
        [Tooltip("SimpleMultiAgentGroup (선택사항 - 없으면 개별 보상으로 fallback)")]
        public SimpleMultiAgentGroup m_AgentGroup;
        
        [Tooltip("보상 계산기")]
        public DefenseRewardCalculator rewardCalculator;
        
        [Header("Settings")]
        [Tooltip("보상 계산 주기 (프레임 단위, 1 = 매 프레임)")]
        public int rewardCalculationInterval = 1;
        
        [Tooltip("최대 환경 스텝 수 (에피소드가 이 스텝 수에 도달하면 자동 종료)")]
        public int maxEnvironmentSteps = 5000;
        
        [Tooltip("모선 참조")]
        public GameObject motherShip;
        
        [Tooltip("적군 선박들")]
        public GameObject[] enemyShips = new GameObject[5];
        
        [Tooltip("Web 오브젝트")]
        public GameObject webObject;
        
        [Header("Spawn Positions")]
        [Tooltip("방어 선박 1 초기 위치")]
        public Vector3 defense1SpawnPos = new Vector3(-115f, -8f, -10f);

        [Tooltip("방어 선박 1 초기 각도 (Euler 각도)")]
        public Vector3 defense1SpawnRot = new Vector3(0f, 0f, 0f);

        [Tooltip("방어 선박 2 초기 위치")]
        public Vector3 defense2SpawnPos = new Vector3(0f, -8f, -6f);

        [Tooltip("방어 선박 2 초기 각도 (Euler 각도)")]
        public Vector3 defense2SpawnRot = new Vector3(0f, 0f, 0f);

        [Tooltip("Web 오브젝트 위치 (2대 중간)")]
        public Vector3 webSpawnPos = new Vector3(0f, 0.8f, 0f);
        
        [Header("Episode End Conditions")]
        [Tooltip("Web/MotherShip 충돌 최대 허용 횟수 (이 횟수 이상 충돌 시 에피소드 종료)")]
        public int maxCollisionCount = 1;
        
        [Header("Random Spawn Settings")]
        [Tooltip("랜덤 스폰 범위 (기존 위치에서 ±range 범위로 랜덤 생성)")]
        public float spawnRange = 20f;
        
        [Tooltip("랜덤 스폰 활성화 (에피소드 시작 시 랜덤 위치로 재생성)")]
        public bool enableRandomSpawn = true;
        
        [Header("Mission Rewards")]
        [Tooltip("포획 성공 보상")]
        public float captureReward = 1.0f;
        
        [Tooltip("포획 거리 보너스 (최대) - 모선과 멀리서 포획할수록 보상")]
        public float captureDistanceBonus = 0.5f;

        [Tooltip("포획 거리 보너스 기준 (m) - 이 거리 이상에서 최대 보너스")]
        public float captureDistanceBonusRange = 500f;
        
        [Tooltip("모선 방어 성공 보상")]
        public float motherShipDefenseReward = 0.5f;
        
        [Tooltip("모선 방어 반경 (m)")]
        public float motherShipDefenseRadius = 1000f;
        
        [Tooltip("방어선 침범 패널티")]
        public float boundaryBreachPenalty = -0.1f;
        
        [Tooltip("2km 경계선")]
        public float boundary2km = 2000f;
        
        [Tooltip("1km 경계선")]
        public float boundary1km = 1000f;
        
        [Tooltip("모선 충돌 패널티 (Game Over)")]
        public float motherShipCollisionPenalty = -2.0f;
        
        [Header("Explosion Settings")]
        [Tooltip("폭발 효과 Prefab (War FX)")]
        public GameObject explosionPrefab;
        
        [Tooltip("폭발 효과 크기 배율")]
        [Range(5f, 50f)]
        public float explosionScale = 23f;
        
        [Tooltip("폭발 효과 지속 시간 (초) - 이 시간 후 에피소드 재시작")]
        public float explosionDuration = 2.0f;
        
        [Header("Collision Detection")]
        [Tooltip("충돌 패널티 (아군-아군, 아군-모선)")]
        public float collisionPenalty = -1.0f;
        
        [Header("Episode End Conditions")]
        [Tooltip("모든 적군 선박 파괴 시 에피소드 종료")]
        public bool endEpisodeOnAllEnemiesDestroyed = true;

        [Tooltip("아군 간 최대 허용 거리 (이 거리 초과 시 에피소드 종료)")]
        public float maxAllyDistance = 120f;  // Stage1 최적거리(50m) + 대형붕괴거리(100m) 사이 여유

        [Tooltip("아군 간 최소 허용 거리 (이 거리 미만 시 에피소드 종료)")]
        public float minAllyDistance = 4f;

        [Tooltip("아군 거리 초과/미달 페널티")]
        public float allyDistancePenalty = -1.0f;

        [Tooltip("아군 위치 교차 페널티 (왼쪽/오른쪽 위치가 바뀌면)")]
        public float positionSwapPenalty = -1.0f;

        [Header("Reward Monitor (Read Only)")]
        [SerializeField] private float _currentEpisodeReward = 0f;
        [SerializeField] private float _lastStepReward = 0f;
        [SerializeField] private float _cooperativeReward = 0f;
        [SerializeField] private float _tacticalReward = 0f;
        [SerializeField] private float _safetyPenalty = 0f;
        [SerializeField] private int _currentStep = 0;
        [SerializeField] private int _totalCollisions = 0;

        [Header("Debug")]
        [Tooltip("디버그 로그 활성화")]
        public bool enableDebugLog = false;
        
        private int _resetTimer = 0; // FixedUpdate 기반 타이머
        private bool _episodeActive = false;
        private bool _episodeEnding = false; // 에피소드 종료 중 플래그 (중복 호출 방지)
        private bool _enemyEnteredDefenseZone = false;
        private bool _boundary2kmBreached = false;
        private bool _boundary1kmBreached = false;
        
        // 에피소드 추적
        private int _episodeNumber = 0; // 에피소드 번호 (재시작 확인용)
        
        // 충돌 횟수 추적 (Web + MotherShip 통합 카운트)
        private int _totalCollisionCount = 0; // 총 충돌 횟수 (Web + MotherShip 합산)
        
        // 중복 충돌 방지 (같은 적군 선박이 짧은 시간 내 여러 번 충돌하는 것 방지)
        private float _collisionCooldown = 2.0f; // 충돌 쿨다운 시간 (초)
        private System.Collections.Generic.Dictionary<GameObject, float> _collisionCooldownTimes = new System.Collections.Generic.Dictionary<GameObject, float>();
        
        // 위치 리셋 관련
        private int _lastResetFrame = -1; // 중복 리셋 방지용
        private bool _isResettingPositions = false; // 위치 리셋 코루틴 실행 중 플래그
        private WebCollisionDetector _webDetector;
        
        // 원래 위치 및 각도 저장 (랜덤 스폰용)
        private Vector3 _originalDefense1Pos;
        private Vector3 _originalDefense2Pos;
        private Quaternion _originalDefense1Rot;
        private Quaternion _originalDefense2Rot;

        // 아군 선박 좌/우 위치 추적 (위치 교차 감지용)
        // 에피소드 시작 시 agent1이 agent2의 왼쪽에 있으면 true
        private bool _agent1StartsOnLeft = true;
        private System.Collections.Generic.Dictionary<GameObject, Vector3> _originalEnemyPositions = 
            new System.Collections.Generic.Dictionary<GameObject, Vector3>();
        private System.Collections.Generic.Dictionary<GameObject, Vector3> _originalBoatPositions = 
            new System.Collections.Generic.Dictionary<GameObject, Vector3>(); // 태그가 "boat"인 모든 선박의 초기 위치
        private System.Collections.Generic.Dictionary<GameObject, Quaternion> _originalBoatRotations = 
            new System.Collections.Generic.Dictionary<GameObject, Quaternion>(); // 태그가 "boat"인 모든 선박의 초기 각도
        
        // 적군 선박 (attack_boat 태그) 관리
        private System.Collections.Generic.List<GameObject> _attackBoats = new System.Collections.Generic.List<GameObject>();
        private System.Collections.Generic.Dictionary<GameObject, Vector3> _attackBoatInitialPositions = new System.Collections.Generic.Dictionary<GameObject, Vector3>();
        private System.Collections.Generic.Dictionary<GameObject, CinemachinePathBase> _attackBoatInitialPaths = new System.Collections.Generic.Dictionary<GameObject, CinemachinePathBase>();
        private System.Collections.Generic.Dictionary<string, GameObject> _attackBoatPrefabs = new System.Collections.Generic.Dictionary<string, GameObject>(); // 원본 attack_boat 프리팹 저장 (재생성용, 이름을 키로 사용)
        private System.Collections.Generic.Dictionary<string, Vector3> _attackBoatInitialPositionsByName = new System.Collections.Generic.Dictionary<string, Vector3>(); // 이름 기반 초기 위치 저장 (재생성용)
        private System.Collections.Generic.Dictionary<string, CinemachinePathBase> _attackBoatInitialPathsByName = new System.Collections.Generic.Dictionary<string, CinemachinePathBase>(); // 이름 기반 초기 경로 저장 (재생성용)
        private System.Collections.Generic.HashSet<string> _destroyedAttackBoatNames = new System.Collections.Generic.HashSet<string>(); // 파괴된 attack_boat 이름 추적
        private int _initialAttackBoatCount = 0;
        
        // Inspector에서 Stage 변경 시 자동 적용 (에디터 전용)
        private TrainingStage _lastStage;

        private void OnValidate()
        {
            // Play 모드에서만 실행
            if (!Application.isPlaying)
                return;

            // Stage가 변경되었는지 확인
            if (_lastStage != currentStage)
            {
                Debug.Log($"[OnValidate] Stage 변경 감지: {_lastStage} → {currentStage}");
                _lastStage = currentStage;
                SyncStageToRewardCalculator();
                ApplyStageSettings();
            }
        }

        private void Start()
        {
            // 초기 Stage 저장
            _lastStage = currentStage;

            // SimpleMultiAgentGroup 초기화
            if (m_AgentGroup == null)
            {
                m_AgentGroup = new SimpleMultiAgentGroup();
            }
            
            // 에이전트 등록 (SimpleMultiAgentGroup이 있는 경우만)
            if (m_AgentGroup != null)
            {
                if (defenseAgent1 != null)
                    m_AgentGroup.RegisterAgent(defenseAgent1);
                if (defenseAgent2 != null)
                    m_AgentGroup.RegisterAgent(defenseAgent2);
                
            }
            else
            {
            }
            
            // RewardCalculator 초기화
            if (rewardCalculator == null)
            {
                rewardCalculator = GetComponent<DefenseRewardCalculator>();
                if (rewardCalculator == null)
                {
                }
            }

            // RewardCalculator에 현재 Stage 동기화
            SyncStageToRewardCalculator();

            // Stage별 적군 활성화/비활성화
            ApplyStageSettings();
            
            // 모선 찾기
            if (motherShip == null)
            {
                motherShip = GameObject.FindGameObjectWithTag("MotherShip");
            }
            
            // WebCollisionDetector 설정
            if (webObject != null)
            {
                _webDetector = webObject.GetComponent<WebCollisionDetector>();
                if (_webDetector == null)
                {
                    _webDetector = webObject.AddComponent<WebCollisionDetector>();
                }
                _webDetector.envController = this;
            }

            // 에이전트 페어링
            if (defenseAgent1 != null && defenseAgent2 != null)
            {
                defenseAgent1.partnerAgent = defenseAgent2;
                defenseAgent2.partnerAgent = defenseAgent1;

                defenseAgent1.webObject = webObject;
                defenseAgent2.webObject = webObject;
                
                // 적군 배열 설정
                if (enemyShips != null && enemyShips.Length > 0)
                {
                    defenseAgent1.enemyShips = enemyShips;
                    defenseAgent2.enemyShips = enemyShips;
                }
            }

            // 원점 = 인스펙터에 설정된 Spawn Position 값 사용
            Debug.Log($"[Start] ⚠️ 인스펙터 값 확인 (저장 전):");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos} (IsZero: {defense1SpawnPos == Vector3.zero})");
            Debug.Log($"  - defense2SpawnPos: {defense2SpawnPos} (IsZero: {defense2SpawnPos == Vector3.zero})");
            
            // 만약 인스펙터 값이 (0,0,0)이면 강제로 기본값 설정 (테스트용)
            if (defense1SpawnPos == Vector3.zero)
            {
                Debug.LogWarning($"[Start] ⚠️ defense1SpawnPos가 (0,0,0)입니다! 강제로 기본값 설정: (-115, -8, -10)");
                defense1SpawnPos = new Vector3(-115f, -8f, -10f);
            }
            if (defense2SpawnPos == Vector3.zero)
            {
                Debug.LogWarning($"[Start] ⚠️ defense2SpawnPos가 (0,0,0)입니다! 강제로 기본값 설정: (0, -8, -6)");
                defense2SpawnPos = new Vector3(0f, -8f, -6f);
            }
            
            _originalDefense1Pos = defense1SpawnPos;
            _originalDefense2Pos = defense2SpawnPos;

            // 회전은 인스펙터에 설정된 각도 사용 (Euler → Quaternion 변환)
            _originalDefense1Rot = Quaternion.Euler(defense1SpawnRot);
            _originalDefense2Rot = Quaternion.Euler(defense2SpawnRot);

            Debug.Log($"[Start] ✅ 저장 후 값 확인:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - defense2SpawnPos: {defense2SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
            Debug.Log($"  - _originalDefense2Pos: {_originalDefense2Pos}");
            
            // ⚠️ 저장 후 검증: _originalDefense1Pos가 (0,0,0)이고 defense1SpawnPos가 (0,0,0)이 아니면 다시 저장
            if (_originalDefense1Pos == Vector3.zero && defense1SpawnPos != Vector3.zero)
            {
                Debug.LogWarning($"[Start] ⚠️ _originalDefense1Pos가 (0,0,0)입니다! defense1SpawnPos({defense1SpawnPos})로 다시 저장합니다.");
                _originalDefense1Pos = defense1SpawnPos;
            }
            if (_originalDefense2Pos == Vector3.zero && defense2SpawnPos != Vector3.zero)
            {
                Debug.LogWarning($"[Start] ⚠️ _originalDefense2Pos가 (0,0,0)입니다! defense2SpawnPos({defense2SpawnPos})로 다시 저장합니다.");
                _originalDefense2Pos = defense2SpawnPos;
            }
            
            // 태그가 "boat"인 모든 GameObject의 초기 위치 및 각도 저장 (WAKE 제외)
            _originalBoatPositions.Clear();
            _originalBoatRotations.Clear();
            GameObject[] allBoats = GameObject.FindGameObjectsWithTag("boat");
            foreach (var boat in allBoats)
            {
                // WAKE 객체는 제외 (파도 효과 등)
                if (boat != null && !boat.name.Contains("WAKE") && !boat.name.Contains("Wake") && !_originalBoatPositions.ContainsKey(boat))
                {
                    _originalBoatPositions[boat] = boat.transform.position;
                    _originalBoatRotations[boat] = boat.transform.rotation;
                }
            }
            
            // 적군 원래 위치 저장
            if (enemyShips != null)
            {
                foreach (var enemy in enemyShips)
                {
                    if (enemy != null && !_originalEnemyPositions.ContainsKey(enemy))
                    {
                        _originalEnemyPositions[enemy] = enemy.transform.position;
                    }
                }
            }
            
            // attack_boat 태그를 가진 모든 적군 선박 찾기 및 초기 위치 저장
            FindAndSaveAttackBoats();
            
            Debug.Log($"[Start] ⚠️ ResetScene() 호출 전 최종 확인:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
            
            // 첫 에피소드 시작 (PushBlockEnvController 패턴)
            ResetScene();
            
            Debug.Log($"[Start] ⚠️ ResetScene() 호출 후 확인:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
        }
        
        /// <summary>
        /// PushBlockEnvController 패턴: FixedUpdate에서 타이머 관리
        /// </summary>
        private void FixedUpdate()
        {
            // 에피소드가 종료 중이면 타이머 증가하지 않음
            if (_episodeEnding)
                return;
            
            // 에피소드가 활성화되지 않았으면 타이머만 증가하지 않음 (종료 조건은 체크 가능)
            if (!_episodeActive)
                return;
            
            _resetTimer++;
            
            // 최대 스텝 수 체크 (PushBlockEnvController 패턴)
            if (_resetTimer >= maxEnvironmentSteps && maxEnvironmentSteps > 0)
            {
                Debug.Log($"[FixedUpdate] ⚠️ 최대 스텝 수 도달! _resetTimer={_resetTimer}, maxEnvironmentSteps={maxEnvironmentSteps}");
                RestartEpisode("MaxEnvironmentSteps");
                return;
            }

            // 아군 간 거리 체크 (최대/최소)
            if (defenseAgent1 != null && defenseAgent2 != null)
            {
                Vector3 pos1 = defenseAgent1.transform.position;
                Vector3 pos2 = defenseAgent2.transform.position;
                float allyDist = Vector3.Distance(pos1, pos2);

                // 최대 거리 초과 체크
                if (maxAllyDistance > 0f && allyDist > maxAllyDistance)
                {
                    Debug.Log($"[FixedUpdate] ⚠️ 아군 간 거리 초과! 거리: {allyDist:F1}m > 최대: {maxAllyDistance}m → 에피소드 종료");
                    RestartEpisode("AllyDistanceExceeded", allyDistancePenalty);
                    return;
                }

                // 최소 거리 미달 체크
                if (minAllyDistance > 0f && allyDist < minAllyDistance)
                {
                    Debug.Log($"[FixedUpdate] ⚠️ 아군 간 거리 미달! 거리: {allyDist:F1}m < 최소: {minAllyDistance}m → 에피소드 종료");
                    RestartEpisode("AllyDistanceTooClose", allyDistancePenalty);
                    return;
                }

                // 위치 교차 체크 (왼쪽/오른쪽 위치가 바뀌면 페널티)
                bool agent1CurrentlyOnLeft = pos1.x < pos2.x;
                if (agent1CurrentlyOnLeft != _agent1StartsOnLeft)
                {
                    Debug.Log($"[FixedUpdate] ⚠️ 아군 위치 교차! 초기: agent1 왼쪽={_agent1StartsOnLeft}, 현재: agent1 왼쪽={agent1CurrentlyOnLeft} → 에피소드 종료");
                    RestartEpisode("PositionSwapped", positionSwapPenalty);
                    return;
                }
            }

            // 보상 계산 주기 확인
            if (_resetTimer % rewardCalculationInterval != 0)
                return;
            
            if (defenseAgent1 == null || defenseAgent2 == null || rewardCalculator == null)
                return;
            
            // 1. 관측: 두 에이전트의 상태 수집
            var agent1State = rewardCalculator.GetAgentState(defenseAgent1);
            var agent2State = rewardCalculator.GetAgentState(defenseAgent2);
            
            // 2. 계산: 협동 기동 보상
            float cooperativeReward = rewardCalculator.CalculateCooperativeRewards(
                agent1State, agent2State);
            
            // 3. 계산: 전술 기동 보상
            float tacticalReward = rewardCalculator.CalculateTacticalRewards(
                agent1State, agent2State, enemyShips, webObject);
            
            // 4. 계산: 안전 및 제약 페널티
            float safetyPenalty = rewardCalculator.CalculateSafetyPenalties(
                agent1State, agent2State);
            
            // 5. 계산: 방어선 침범 체크
            float boundaryPenalty = CheckBoundaryBreach();
            
            // 6. 부여: 그룹 보상 또는 개별 보상
            float totalReward = cooperativeReward + tacticalReward + safetyPenalty + boundaryPenalty;

            // Inspector 모니터링 업데이트
            _lastStepReward = totalReward;
            _currentEpisodeReward += totalReward;
            _cooperativeReward = cooperativeReward;
            _tacticalReward = tacticalReward;
            _safetyPenalty = safetyPenalty + boundaryPenalty;
            _currentStep = _resetTimer;
            _totalCollisions = _totalCollisionCount;

            if (Mathf.Abs(totalReward) > 0.0001f)
            {
                if (m_AgentGroup != null)
                {
                    // 그룹 보상 모드
                    m_AgentGroup.AddGroupReward(totalReward);
                }
                else
                {
                    // 개별 보상 모드 (fallback)
                    if (defenseAgent1 != null)
                        defenseAgent1.AddReward(totalReward);
                    if (defenseAgent2 != null)
                        defenseAgent2.AddReward(totalReward);
                }
            }

            // === 개별 보상 부여 (모든 Stage) ===
            // 그룹 보상과 별개로 각 에이전트에 직접 부여
            if (true)  // 모든 Stage에서 개별 보상 적용
            {
                float deltaTime = Time.fixedDeltaTime * rewardCalculationInterval;

                // Agent 1 개별 보상
                if (defenseAgent1 != null)
                {
                    // 개별 속도 보상
                    float speedReward1 = rewardCalculator.CalculateIndividualSpeedReward(agent1State);

                    // 조향 안정성 보상 (이전 헤딩이 있을 때만)
                    float stabilityReward1 = 0f;
                    if (defenseAgent1.HasPreviousHeading)
                    {
                        stabilityReward1 = rewardCalculator.CalculateSteeringStabilityReward(
                            agent1State.heading, defenseAgent1.PreviousHeading, deltaTime);
                    }

                    float individualReward1 = speedReward1 + stabilityReward1;
                    if (Mathf.Abs(individualReward1) > 0.00001f)
                    {
                        defenseAgent1.AddReward(individualReward1);
                    }

                    // 이전 헤딩 업데이트
                    defenseAgent1.UpdatePreviousHeading();
                }

                // Agent 2 개별 보상
                if (defenseAgent2 != null)
                {
                    // 개별 속도 보상
                    float speedReward2 = rewardCalculator.CalculateIndividualSpeedReward(agent2State);

                    // 조향 안정성 보상 (이전 헤딩이 있을 때만)
                    float stabilityReward2 = 0f;
                    if (defenseAgent2.HasPreviousHeading)
                    {
                        stabilityReward2 = rewardCalculator.CalculateSteeringStabilityReward(
                            agent2State.heading, defenseAgent2.PreviousHeading, deltaTime);
                    }

                    float individualReward2 = speedReward2 + stabilityReward2;
                    if (Mathf.Abs(individualReward2) > 0.00001f)
                    {
                        defenseAgent2.AddReward(individualReward2);
                    }

                    // 이전 헤딩 업데이트
                    defenseAgent2.UpdatePreviousHeading();
                }
            }
        }

        #region 중앙 허브: 통합 에피소드 재시작 로직
        
        /// <summary>
        /// 통합 에피소드 재시작 메서드 (중앙 허브)
        /// 모든 에피소드 재시작 로직을 여기서 처리합니다.
        /// </summary>
        /// <param name="reason">에피소드 종료 이유 (디버깅용)</param>
        /// <param name="finalReward">최종 보상 (선택사항)</param>
        public void RestartEpisode(string reason = "Unknown", float? finalReward = null)
        {
            // 중복 호출 방지
            if (_episodeEnding)
            {
                Debug.Log($"[RestartEpisode] ⚠️ 이미 에피소드 종료 중입니다. 무시합니다. (Reason: {reason})");
                return;
            }
            
            // ⚠️ 가장 먼저 충돌 횟수 초기화 (에피소드 종료 시 즉시 리셋)
            int previousTotalCount = _totalCollisionCount;
            _totalCollisionCount = 0;
            _collisionCooldownTimes.Clear();

            // Inspector 모니터 로그 및 초기화
            float previousEpisodeReward = _currentEpisodeReward;
            _currentEpisodeReward = 0f;
            _lastStepReward = 0f;
            _cooperativeReward = 0f;
            _tacticalReward = 0f;
            _safetyPenalty = 0f;
            _currentStep = 0;
            _totalCollisions = 0;

            // 에피소드 번호 증가 및 로그 출력
            _episodeNumber++;
            Debug.Log($"[RestartEpisode] ========== 에피소드 #{_episodeNumber} 종료 ==========");
            Debug.Log($"[RestartEpisode] 종료 사유: {reason}");
            Debug.Log($"[RestartEpisode] 누적 보상: {previousEpisodeReward:F3}");
            Debug.Log($"[RestartEpisode] 최종 보상: {(finalReward.HasValue ? finalReward.Value.ToString("F3") : "없음")}");
            Debug.Log($"[RestartEpisode] 이전 총 충돌 횟수 (Web+MotherShip): {previousTotalCount} → 초기화됨 (0)");
            Debug.Log($"[RestartEpisode] ==========================================");
            
            // 타이머도 여기서 명시적으로 리셋 (안전장치)
            _resetTimer = 0;
            
            Debug.Log($"[RestartEpisode] ✅ 충돌 횟수 및 타이머 초기화 완료: _resetTimer={_resetTimer}, _totalCollisionCount={_totalCollisionCount}");
            
            // 1단계: 에피소드 종료 플래그 설정
            _episodeEnding = true;
            
            // 2단계: 최종 보상 부여 (있는 경우)
            if (finalReward.HasValue)
            {
                if (m_AgentGroup != null)
                {
                    m_AgentGroup.AddGroupReward(finalReward.Value);
                }
                else
                {
                    if (defenseAgent1 != null)
                        defenseAgent1.AddReward(finalReward.Value);
                    if (defenseAgent2 != null)
                        defenseAgent2.AddReward(finalReward.Value);
                }
            }
            
            // 3단계: 모선 방어 성공 체크 (적이 방어 존에 진입하지 않았을 때)
            if (!_enemyEnteredDefenseZone && motherShip != null && reason != "MotherShipDefense")
            {
                if (m_AgentGroup != null)
                {
                    m_AgentGroup.AddGroupReward(motherShipDefenseReward);
                }
                else
                {
                    if (defenseAgent1 != null)
                        defenseAgent1.AddReward(motherShipDefenseReward);
                    if (defenseAgent2 != null)
                        defenseAgent2.AddReward(motherShipDefenseReward);
                }
            }
            
            // 4단계: 에이전트 에피소드 종료
            if (m_AgentGroup != null)
            {
                m_AgentGroup.EndGroupEpisode();
            }
            else
            {
                if (defenseAgent1 != null)
                {
                    defenseAgent1.EndEpisode();
                }
                if (defenseAgent2 != null)
                {
                    defenseAgent2.EndEpisode();
                }
            }
            
            // 5단계: 환경 리셋
            ResetScene();
        }
        
        /// <summary>
        /// PushBlockEnvController 패턴: 환경 리셋 (ML-Agents가 OnEpisodeBegin을 자동 호출)
        /// RestartEpisode()에서 호출됩니다.
        /// </summary>
        public void ResetScene()
        {
            Debug.Log($"[ResetScene] ========== 에피소드 #{_episodeNumber} 시작 ==========");
            Debug.Log($"[ResetScene] ⚠️ ResetPositionsOnly() 호출 전:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
            
            // 충돌 횟수 리셋
            _totalCollisionCount = 0;
            
            // ⚠️ _originalDefense1Pos가 (0,0,0)이면 defense1SpawnPos로 복구
            if (_originalDefense1Pos == Vector3.zero && defense1SpawnPos != Vector3.zero)
            {
                Debug.LogWarning($"[ResetScene] ⚠️ _originalDefense1Pos가 (0,0,0)입니다! defense1SpawnPos({defense1SpawnPos})로 복구합니다.");
                _originalDefense1Pos = defense1SpawnPos;
            }
            if (_originalDefense2Pos == Vector3.zero && defense2SpawnPos != Vector3.zero)
            {
                Debug.LogWarning($"[ResetScene] ⚠️ _originalDefense2Pos가 (0,0,0)입니다! defense2SpawnPos({defense2SpawnPos})로 복구합니다.");
                _originalDefense2Pos = defense2SpawnPos;
            }
            
            // 초기 각도 업데이트 (인스펙터 값 사용)
            _originalDefense1Rot = Quaternion.Euler(defense1SpawnRot);
            _originalDefense2Rot = Quaternion.Euler(defense2SpawnRot);

            // 기존 리셋 코루틴 중지 및 플래그 초기화
            StopAllCoroutines();
            _isResettingPositions = false;
            _lastResetFrame = -1; // 프레임 체크 초기화

            // 에피소드 종료 플래그를 먼저 리셋하여 다음 FixedUpdate()에서 타이머가 증가하지 않도록 함
            _episodeEnding = false;

            // 에피소드는 코루틴 완료 후 활성화 (초기에는 false로 시작)
            _episodeActive = false;

            _resetTimer = 0;
            _enemyEnteredDefenseZone = false;
            _boundary2kmBreached = false;
            _boundary1kmBreached = false;
            
            Debug.Log($"[ResetScene] ✅ 타이머 및 플래그 초기화 완료: _resetTimer={_resetTimer}, _episodeEnding={_episodeEnding}, _episodeActive={_episodeActive}");

            // 파괴된 적군 선박 목록 초기화 (에피소드 재시작 시)
            _destroyedAttackBoatNames.Clear();

            // RewardCalculator 리셋
            if (rewardCalculator != null)
            {
                rewardCalculator.Reset();
            }

            // Stage 설정 적용 (에피소드 시작 시마다)
            SyncStageToRewardCalculator();
            ApplyStageSettings();

            // 모든 선박 리셋
            ResetPositionsOnly();
            
            Debug.Log($"[ResetScene] ⚠️ ResetPositionsOnly() 호출 후:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
            Debug.Log($"[ResetScene] ========== 에피소드 #{_episodeNumber} 시작 완료 ==========");
        }
        
        #endregion
        
        /// <summary>
        /// 에피소드 시작 (ML-Agents가 자동으로 호출, 환경 리셋은 ResetScene에서 처리)
        /// </summary>
        public void OnEpisodeBegin()
        {
            // 모든 WAKE 객체 제거 및 WakeGenerator 비활성화
            DestroyAllWakeObjects();
        }
        
        /// <summary>
        /// 에피소드 종료 (레거시 호환성 - RestartEpisode()로 리다이렉트)
        /// </summary>
        public void OnEpisodeEnd()
        {
            RestartEpisode("OnEpisodeEnd");
        }
        
        /// <summary>
        /// 적 포획 성공 처리 (중앙 허브로 리다이렉트)
        /// </summary>
        public void OnEnemyCaptured(Vector3 enemyPosition)
        {
            // 에피소드가 종료 중이면 무시
            if (_episodeEnding)
                return;

            // 기본 포획 보상
            float totalReward = captureReward;

            // 거리 보너스 계산 (모선과 멀리서 포획할수록 보상)
            if (motherShip != null)
            {
                float distanceFromMotherShip = Vector3.Distance(enemyPosition, motherShip.transform.position);

                // 모선과의 거리가 멀수록 보너스 (최대 captureDistanceBonusRange에서 최대 보너스)
                float distanceFactor = Mathf.Clamp01(distanceFromMotherShip / captureDistanceBonusRange);
                float distanceBonus = captureDistanceBonus * distanceFactor;
                totalReward += distanceBonus;

                if (enableDebugLog)
                {
                    Debug.Log($"[OnEnemyCaptured] 모선과의 거리: {distanceFromMotherShip:F1}m, 거리 보너스: +{distanceBonus:F3}");
                }
            }

            // 통합 에피소드 재시작 메서드 호출
            RestartEpisode("EnemyCaptured", totalReward);
        }
        
        /// <summary>
        /// 적군이 Web에 충돌 시 처리 - 적군과 아군 모두 원점으로 리셋
        /// 충돌 횟수가 maxCollisionCount 이상이면 에피소드 종료
        /// </summary>
        public void OnEnemyHitWeb(GameObject enemyBoat)
        {
            // 에피소드가 종료 중이면 무시
            if (_episodeEnding)
                return;
            
            if (enemyBoat == null)
                return;
            
            // 중복 충돌 방지: 같은 적군 선박이 쿨다운 시간 내에 다시 충돌하면 무시
            float currentTime = Time.time;
            if (_collisionCooldownTimes.ContainsKey(enemyBoat))
            {
                float lastCollisionTime = _collisionCooldownTimes[enemyBoat];
                if (currentTime - lastCollisionTime < _collisionCooldown)
                {
                    Debug.Log($"[OnEnemyHitWeb] ⚠️ 중복 충돌 무시: {enemyBoat.name} (마지막 충돌: {currentTime - lastCollisionTime:F2}초 전)");
                    return;
                }
            }

            // 충돌 시간 기록
            _collisionCooldownTimes[enemyBoat] = currentTime;

            // 통합 충돌 횟수 증가 (Web + MotherShip 합산)
            _totalCollisionCount++;
            Debug.Log($"[OnEnemyHitWeb] Web 충돌 발생! 적군: {enemyBoat.name}, 총 충돌 횟수(Web+MotherShip): {_totalCollisionCount}/{maxCollisionCount}");

            // Stage1에서는 포획 보상 비활성화
            // Stage2에서만 포획 보상 부여
            float totalReward = IsCaptureRewardEnabled() ? captureReward : 0f;

            // 거리 보너스 계산 (모선과 멀리서 포획할수록 보상)
            if (motherShip != null && IsCaptureRewardEnabled())
            {
                float distanceFromMotherShip = Vector3.Distance(enemyBoat.transform.position, motherShip.transform.position);
                float distanceFactor = Mathf.Clamp01(distanceFromMotherShip / captureDistanceBonusRange);
                float distanceBonus = captureDistanceBonus * distanceFactor;
                totalReward += distanceBonus;
            }

            // 통합 충돌 횟수가 maxCollisionCount 이상이면 즉시 에피소드 종료
            if (_totalCollisionCount >= maxCollisionCount)
            {
                Debug.Log($"[OnEnemyHitWeb] ⚠️ 총 충돌 횟수({_totalCollisionCount}, Web+MotherShip)가 최대 허용 횟수({maxCollisionCount})에 도달! 에피소드 종료.");
                
                // 보상 부여
                if (m_AgentGroup != null)
                {
                    m_AgentGroup.AddGroupReward(totalReward);
                }
                else
                {
                    if (defenseAgent1 != null)
                        defenseAgent1.AddReward(totalReward);
                    if (defenseAgent2 != null)
                        defenseAgent2.AddReward(totalReward);
                }
                
                // 에피소드 종료 (RestartEpisode 내부에서 _episodeEnding 설정)
                RestartEpisode("WebCollisionLimit", totalReward);
                return; // 여기서 종료하여 아래 코드 실행 방지
            }
            
            // 충돌 횟수가 maxCollisionCount 미만이면 일반 처리
            // 포획 보상 이미 위에서 계산됨 (totalReward에 captureReward + distanceBonus 포함)

            // 보상 부여
            if (m_AgentGroup != null)
            {
                m_AgentGroup.AddGroupReward(totalReward);
            }
            else
            {
                if (defenseAgent1 != null)
                    defenseAgent1.AddReward(totalReward);
                if (defenseAgent2 != null)
                    defenseAgent2.AddReward(totalReward);
            }
            
            // 적군 선박을 원점으로 리셋 (모선 충돌과 동일한 메커니즘 사용)
            ResetSingleAttackBoat(enemyBoat);

            // 아군 선박 위치 리셋은 에피소드 종료 시에만 수행 (mid-episode 리셋 비활성화)
            // ResetDefenseAgentsToOrigin();
            
            // WebDetector 리셋
            if (_webDetector != null)
            {
                _webDetector.ResetDetector();
            }
        }

        /// <summary>
        /// 아군 선박이 Web과 충돌 시 처리 (페널티 + 에피소드 종료)
        /// </summary>
        public void OnAllyHitWeb(GameObject allyShip, float penalty)
        {
            if (_episodeEnding)
                return;

            Debug.LogError($"[OnAllyHitWeb] ⚠️ 아군 선박이 Web과 충돌! {allyShip.name}, 페널티: {penalty}");

            // 페널티 부여 후 에피소드 종료
            RestartEpisode("AllyHitWeb", penalty);
        }

        /// <summary>
        /// 단일 적군 선박을 원점으로 리셋 (레거시 - ResetSingleAttackBoat 사용 권장)
        /// </summary>
        private void ResetSingleAttackBoatToOrigin(GameObject attackBoat)
        {
            if (attackBoat == null)
                return;
            
            // 초기 위치 찾기 (이름 기반으로 찾기)
            Vector3 spawnPos;
            string boatName = attackBoat.name.Replace("(Clone)", "");
            
            if (_attackBoatInitialPositionsByName.ContainsKey(boatName))
            {
                spawnPos = _attackBoatInitialPositionsByName[boatName];
            }
            else if (_attackBoatInitialPositions.ContainsKey(attackBoat))
            {
                spawnPos = _attackBoatInitialPositions[attackBoat];
                _attackBoatInitialPositionsByName[boatName] = spawnPos;
            }
            else
            {
                spawnPos = attackBoat.transform.position;
                _attackBoatInitialPositions[attackBoat] = spawnPos;
                _attackBoatInitialPositionsByName[boatName] = spawnPos;
            }
            
            // Rigidbody 리셋
            Rigidbody rb = attackBoat.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            
            // 위치와 회전 설정
            attackBoat.transform.position = spawnPos;
            attackBoat.transform.rotation = Quaternion.identity;
            
            // Cinemachine Dolly Cart 리셋
            CinemachineDollyCart dollyCart = attackBoat.GetComponent<CinemachineDollyCart>();
            if (dollyCart != null)
            {
                CinemachinePathBase originalPath = null;
                
                if (_attackBoatInitialPathsByName.ContainsKey(boatName))
                {
                    originalPath = _attackBoatInitialPathsByName[boatName];
                }
                else if (_attackBoatInitialPaths.ContainsKey(attackBoat) && _attackBoatInitialPaths[attackBoat] != null)
                {
                    originalPath = _attackBoatInitialPaths[attackBoat];
                    _attackBoatInitialPathsByName[boatName] = originalPath;
                }
                
                if (originalPath != null)
                {
                    dollyCart.m_Path = originalPath;
                    dollyCart.m_Position = 0f;
                }
            }
        }
        
        /// <summary>
        /// 아군 선박들을 원점으로 리셋
        /// </summary>
        private void ResetDefenseAgentsToOrigin()
        {
            // ⚠️ _originalDefense1Pos가 (0,0,0)이면 defense1SpawnPos로 복구
            if (_originalDefense1Pos == Vector3.zero && defense1SpawnPos != Vector3.zero)
            {
                _originalDefense1Pos = defense1SpawnPos;
            }
            if (_originalDefense2Pos == Vector3.zero && defense2SpawnPos != Vector3.zero)
            {
                _originalDefense2Pos = defense2SpawnPos;
            }
            
            // 초기 각도 업데이트 (인스펙터 값 사용)
            _originalDefense1Rot = Quaternion.Euler(defense1SpawnRot);
            _originalDefense2Rot = Quaternion.Euler(defense2SpawnRot);
            
            // 아군 선박 위치 및 각도 리셋
            ResetDefenseAgentPosition(defenseAgent1, _originalDefense1Pos, defense1SpawnPos, _originalDefense1Rot);
            ResetDefenseAgentPosition(defenseAgent2, _originalDefense2Pos, defense2SpawnPos, _originalDefense2Rot);
        }
        
        /// <summary>
        /// 모선 충돌 처리 - 해당 공격선만 원점으로 리셋
        /// 충돌 횟수가 maxCollisionCount 이상이면 에피소드 종료
        /// </summary>
        public void OnMotherShipCollision(GameObject enemyBoat)
        {
            // 에피소드가 종료 중이면 무시
            if (_episodeEnding)
                return;
            
            if (enemyBoat == null)
                return;

            // 중복 충돌 방지: 같은 적군 선박이 쿨다운 시간 내에 다시 충돌하면 무시
            float currentTime = Time.time;
            if (_collisionCooldownTimes.ContainsKey(enemyBoat))
            {
                float lastCollisionTime = _collisionCooldownTimes[enemyBoat];
                if (currentTime - lastCollisionTime < _collisionCooldown)
                {
                    Debug.Log($"[OnMotherShipCollision] ⚠️ 중복 충돌 무시: {enemyBoat.name} (마지막 충돌: {currentTime - lastCollisionTime:F2}초 전)");
                    return;
                }
            }

            // 충돌 시간 기록
            _collisionCooldownTimes[enemyBoat] = currentTime;

            // 통합 충돌 횟수 증가 (Web + MotherShip 합산)
            _totalCollisionCount++;
            Debug.Log($"[OnMotherShipCollision] MotherShip 충돌 발생! 적군: {enemyBoat.name}, 총 충돌 횟수(Web+MotherShip): {_totalCollisionCount}/{maxCollisionCount}");

            // Stage1에서는 모선 충돌 페널티 비활성화
            // Stage2, Stage3에서만 페널티 부여
            float penalty = IsMotherShipPenaltyEnabled() ? motherShipCollisionPenalty : 0f;

            // 통합 충돌 횟수가 maxCollisionCount 이상이면 즉시 에피소드 종료
            if (_totalCollisionCount >= maxCollisionCount)
            {
                Debug.Log($"[OnMotherShipCollision] ⚠️ 총 충돌 횟수({_totalCollisionCount}, Web+MotherShip)가 최대 허용 횟수({maxCollisionCount})에 도달! 에피소드 종료.");

                // 패널티 부여 (Stage2, Stage3에서만)
                if (penalty != 0f)
                {
                    if (m_AgentGroup != null)
                    {
                        m_AgentGroup.AddGroupReward(penalty);
                    }
                    else
                    {
                        if (defenseAgent1 != null)
                            defenseAgent1.AddReward(penalty);
                        if (defenseAgent2 != null)
                            defenseAgent2.AddReward(penalty);
                    }
                }

                // 에피소드 종료 (RestartEpisode 내부에서 _episodeEnding 설정)
                RestartEpisode("MotherShipCollisionLimit", penalty != 0f ? penalty : (float?)null);
                return; // 여기서 종료하여 아래 코드 실행 방지
            }

            if (enableDebugLog)
            {
                Debug.Log($"[DefenseEnvController] 모선 충돌! 적군: {enemyBoat.name} - 해당 공격선만 원점으로 리셋");
            }

            // 충돌 횟수가 3회 미만이면 일반 처리
            // 패널티 부여 (Stage2, Stage3에서만)
            if (penalty != 0f)
            {
                if (m_AgentGroup != null)
                {
                    m_AgentGroup.AddGroupReward(penalty);
                }
                else
                {
                    if (defenseAgent1 != null)
                        defenseAgent1.AddReward(penalty);
                    if (defenseAgent2 != null)
                        defenseAgent2.AddReward(penalty);
                }
            }

            // 해당 공격선만 원점으로 리셋
            ResetSingleAttackBoat(enemyBoat);
        }

        /// <summary>
        /// 단일 공격선을 원점으로 리셋 (비활성화 없이 위치만 리셋 - Water System 호환)
        /// </summary>
        private void ResetSingleAttackBoat(GameObject attackBoat)
        {
            if (attackBoat == null)
                return;

            string boatName = attackBoat.name.Replace("(Clone)", "");

            // 1. Rigidbody 속도 초기화 + Sleep (비활성화 없이)
            Rigidbody rb = attackBoat.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();  // 물리 시뮬레이션 일시 정지
            }

            // 2. 원점 위치로 이동
            Vector3 initialPos = Vector3.zero;
            if (_attackBoatInitialPositionsByName.ContainsKey(boatName))
            {
                initialPos = _attackBoatInitialPositionsByName[boatName];
            }
            else if (_attackBoatInitialPositions.ContainsKey(attackBoat))
            {
                initialPos = _attackBoatInitialPositions[attackBoat];
            }

            attackBoat.transform.position = initialPos;
            attackBoat.transform.rotation = Quaternion.identity;

            // Engine 리셋 (Gerstner 파도 안정화 전까지 _yHeight 조건 무시)
            var boat = attackBoat.GetComponent<Boat>();
            if (boat != null && boat.engine != null)
            {
                boat.engine.OnEpisodeReset();
            }

            // 3. Cinemachine Dolly Cart 리셋 (경로 시작점으로)
            Cinemachine.CinemachineDollyCart dollyCart = attackBoat.GetComponent<Cinemachine.CinemachineDollyCart>();
            if (dollyCart != null)
            {
                if (_attackBoatInitialPathsByName.ContainsKey(boatName))
                {
                    CinemachinePathBase originalPath = _attackBoatInitialPathsByName[boatName];
                    if (originalPath != null)
                    {
                        dollyCart.m_Path = originalPath;
                    }
                }
                dollyCart.m_Position = 0f;
            }
            
            if (enableDebugLog)
            {
                Debug.Log($"[DefenseEnvController] 공격선 리셋 완료: {boatName} → 위치: {initialPos}");
            }
        }
        
        /// <summary>
        /// 아군 충돌 처리 (아군-아군 또는 아군-모선 충돌)
        /// 에피소드 종료 + 페널티 부여
        /// </summary>
        public void OnFriendlyCollision()
        {
            // 에피소드가 종료 중이면 무시
            if (_episodeEnding)
                return;

            Debug.LogWarning("[OnFriendlyCollision] ⚠️ 아군 충돌 발생! 에피소드 종료 + 페널티 부여");

            // RestartEpisode를 통해 일관된 방식으로 에피소드 종료
            // 패널티 부여 + EndGroupEpisode + ResetScene 모두 처리됨
            RestartEpisode("FriendlyCollision", collisionPenalty);
        }
        
        /// <summary>
        /// 방어선 침범 체크
        /// </summary>
        private float CheckBoundaryBreach()
        {
            if (motherShip == null || enemyShips == null)
                return 0f;
            
            float totalPenalty = 0f;
            
            foreach (var enemy in enemyShips)
            {
                if (enemy == null) continue;
                
                float distanceToMotherShip = Vector3.Distance(
                    enemy.transform.position, motherShip.transform.position);
                
                // 2km 경계선 체크
                if (!_boundary2kmBreached && distanceToMotherShip <= boundary2km)
                {
                    _boundary2kmBreached = true;
                    totalPenalty += boundaryBreachPenalty;
                }
                
                // 1km 경계선 체크
                if (!_boundary1kmBreached && distanceToMotherShip <= boundary1km)
                {
                    _boundary1kmBreached = true;
                    totalPenalty += boundaryBreachPenalty;
                }
                
                // 모선 방어 존 진입 체크
                if (distanceToMotherShip <= motherShipDefenseRadius)
                {
                    _enemyEnteredDefenseZone = true;
                }
            }
            
            return totalPenalty;
        }
        
        #region DefenseBoatManager 통합 기능
        
        /// <summary>
        /// 적군 선박 파괴 요청 (DynamicWeb, WebCollisionDetector에서 호출)
        /// 중앙 허브: 모든 파괴 로직을 중앙에서 관리
        /// </summary>
        public void RequestAttackBoatDestruction(GameObject attackBoat)
        {
            if (attackBoat == null)
                return;
            
            // 이미 파괴 요청이 처리되었는지 확인
            string boatName = attackBoat.name.Replace("(Clone)", "");
            if (_destroyedAttackBoatNames.Contains(boatName))
            {
                return;
            }
            
            // 다음 프레임에 파괴 처리 (물리 콜백 제약 회피)
            StartCoroutine(DestroyAttackBoatNextFrame(attackBoat));
        }
        
        /// <summary>
        /// 다음 프레임에 attack_boat 파괴 처리 (물리 콜백 제약 회피)
        /// </summary>
        private System.Collections.IEnumerator DestroyAttackBoatNextFrame(GameObject attackBoat)
        {
            // 다음 프레임까지 대기 (물리 콜백이 끝난 후)
            yield return null;
            
            if (attackBoat == null)
            {
                yield break;
            }
            
            // 파괴 처리
            OnAttackBoatDestroyed(attackBoat);
            
            // attack_boat 파괴
            Destroy(attackBoat);
        }
        
        /// <summary>
        /// 적군 선박이 파괴되었을 때 호출 (내부에서만 호출)
        /// 중앙 허브: 모든 파괴 정보를 중앙에서 관리
        /// </summary>
        private void OnAttackBoatDestroyed(GameObject destroyedBoat)
        {
            if (destroyedBoat == null)
                return;
            
            // 파괴된 선박의 이름 저장 (파괴 후에도 추적 가능하도록)
            string boatName = destroyedBoat.name.Replace("(Clone)", "");
            _destroyedAttackBoatNames.Add(boatName);
            
            // 초기 적군 선박 수가 0이면 다시 찾기 (Start()에서 찾지 못했을 수 있음)
            if (_initialAttackBoatCount == 0)
            {
                FindAndSaveAttackBoats();
            }
            
            // 파괴된 선박을 리스트에서 제거
            _attackBoats.Remove(destroyedBoat);
            
            // null이거나 파괴된 객체 제거
            _attackBoats.RemoveAll(boat => boat == null);
            
            // 현재 활성화된 적군 선박 수 확인 (씬에서 직접 찾기, 파괴된 선박 제외)
            GameObject[] allAttackBoatsInScene = GameObject.FindGameObjectsWithTag("attack_boat");
            // 파괴된 선박 이름을 기준으로 제외
            int activeCount = allAttackBoatsInScene.Count(boat => 
                boat != null && 
                !_destroyedAttackBoatNames.Contains(boat.name.Replace("(Clone)", ""))
            );
            
            // _attackBoats 리스트에서 활성화된 선박 수 확인
            int activeInList = _attackBoats.Count(boat => 
                boat != null && 
                boat.activeSelf && 
                !_destroyedAttackBoatNames.Contains(boat.name.Replace("(Clone)", ""))
            );
            
            // 모든 적군 선박이 파괴되었는지 확인
            // 조건: 초기 적군 수가 0보다 크고, 씬에 활성화된 적군이 0개이고, 리스트에도 활성화된 선박이 0개
            if (endEpisodeOnAllEnemiesDestroyed && _initialAttackBoatCount > 0 && activeCount == 0 && activeInList == 0)
            {
                // 에피소드가 이미 종료 중인 경우 중복 호출 방지
                if (_episodeEnding)
                {
                    return;
                }
                
                // 통합 에피소드 재시작 메서드 호출
                RestartEpisode("AllEnemiesDestroyed");
            }
        }
        
        /// <summary>
        /// attack_boat 태그를 가진 모든 적군 선박 찾기 및 초기 위치 저장
        /// 중앙 허브: 모든 적군 선박 정보를 중앙에서 관리
        /// </summary>
        private void FindAndSaveAttackBoats()
        {
            _attackBoats.Clear();
            _attackBoatInitialPositions.Clear();
            _attackBoatInitialPaths.Clear();
            // 프리팹 딕셔너리와 이름 기반 딕셔너리는 초기화하지 않음 (에피소드 재시작 시 재사용)
            
            // 씬의 모든 attack_boat 태그를 가진 객체 찾기
            GameObject[] foundBoats = GameObject.FindGameObjectsWithTag("attack_boat");
            
            // enemyShips 배열 자동 동기화 (인스펙터에 할당된 것과 씬의 실제 객체를 동기화)
            if (enemyShips == null || enemyShips.Length == 0 || enemyShips.All(e => e == null))
            {
                // enemyShips 배열이 비어있으면 자동으로 채움
                enemyShips = new GameObject[foundBoats.Length];
                for (int i = 0; i < foundBoats.Length; i++)
                {
                    enemyShips[i] = foundBoats[i];
                }
                }
                else
                {
                // enemyShips 배열에 있는 객체도 _attackBoats에 추가 (중복 방지)
                foreach (var enemyShip in enemyShips)
                {
                    if (enemyShip != null && enemyShip.CompareTag("attack_boat") && !_attackBoats.Contains(enemyShip))
                    {
                        // enemyShips 배열에 있지만 씬에서 찾지 못한 경우도 있으므로 확인
                        bool foundInScene = foundBoats.Contains(enemyShip);
                    }
                }
            }
            
            foreach (var boat in foundBoats)
            {
                if (boat != null && !_attackBoats.Contains(boat))
                {
                    _attackBoats.Add(boat);
                    Vector3 initialPos = boat.transform.position;
                    _attackBoatInitialPositions[boat] = initialPos;

                    Debug.Log($"[FindAndSaveAttackBoats] 적군 '{boat.name}' 초기 위치 저장: {initialPos}");
                    
                    // 원본 객체를 프리팹으로 저장 (파괴 후 재생성용)
                    // 이름을 키로 사용하여 같은 이름의 객체를 재생성할 수 있도록 함
                    string boatName = boat.name.Replace("(Clone)", ""); // Clone 접미사 제거
                    
                    // 이름 기반 초기 위치 저장 (재생성용)
                    if (!_attackBoatInitialPositionsByName.ContainsKey(boatName))
                    {
                        _attackBoatInitialPositionsByName[boatName] = initialPos;
                    }
                    
                    if (!_attackBoatPrefabs.ContainsKey(boatName))
                    {
                        // 원본 객체를 복제하여 프리팹으로 저장 (씬에 숨김)
                        GameObject prefabCopy = Instantiate(boat);
                        prefabCopy.name = boatName; // Clone 접미사 제거
                        prefabCopy.SetActive(false); // 비활성화하여 숨김
                        prefabCopy.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSave; // Hierarchy에서 숨기고 저장하지 않음
                        _attackBoatPrefabs[boatName] = prefabCopy;
                    }
                    
                    // Cinemachine Dolly Cart의 Path 저장
                    CinemachineDollyCart dollyCart = boat.GetComponent<CinemachineDollyCart>();
                    if (dollyCart != null)
                    {
                        _attackBoatInitialPaths[boat] = dollyCart.m_Path;
                        // 이름 기반 경로 저장 (재생성용)
                        if (!_attackBoatInitialPathsByName.ContainsKey(boatName))
                        {
                            _attackBoatInitialPathsByName[boatName] = dollyCart.m_Path;
                        }
                    }
                    else
                    {
                        _attackBoatInitialPaths[boat] = null;
                        if (!_attackBoatInitialPathsByName.ContainsKey(boatName))
                        {
                            _attackBoatInitialPathsByName[boatName] = null;
                        }
                    }
                }
            }
            
            _initialAttackBoatCount = _attackBoats.Count;
            
            // enemyShips 배열과 실제 씬의 객체 수가 다른 경우 경고
            int enemyShipsCount = enemyShips != null ? enemyShips.Count(e => e != null) : 0;
        }
        
        /// <summary>
        /// 위치만 리셋 (외부에서 호출 가능, ML-Agents 에피소드 재시작 시 사용)
        /// 모든 선박을 비활성화 → 위치 리셋 → 활성화
        /// </summary>
        public void ResetPositionsOnly()
        {
            // 코루틴이 이미 실행 중이면 중복 호출 방지
            if (_isResettingPositions)
            {
                return;
            }
            
            // 중복 호출 방지 (같은 프레임에서 여러 번 호출되는 것 방지)
            if (_lastResetFrame == Time.frameCount)
            {
                return;
            }
            
            _lastResetFrame = Time.frameCount;
            
            // 코루틴 실행 중 플래그 설정 (코루틴 시작 전에 설정하여 중복 실행 방지)
            _isResettingPositions = true;
            
            // _originalBoatPositions 업데이트 (새로 생성된 boat가 있을 수 있음)
            UpdateOriginalBoatPositions();
            
            // 코루틴으로 비활성화 → 리셋 → 활성화 순서로 진행
            StartCoroutine(ResetPositionsWithDeactivation());
        }
        
        /// <summary>
        /// _originalBoatPositions 딕셔너리 업데이트 (새로 생성된 boat 추가)
        /// </summary>
        private void UpdateOriginalBoatPositions()
        {
            GameObject[] allBoats = GameObject.FindGameObjectsWithTag("boat");
            
            int addedCount = 0;
            foreach (var boat in allBoats)
            {
                // WAKE 객체는 제외 (파도 효과 등)
                if (boat != null && !boat.name.Contains("WAKE") && !boat.name.Contains("Wake") && !_originalBoatPositions.ContainsKey(boat))
                {
                    _originalBoatPositions[boat] = boat.transform.position;
                    _originalBoatRotations[boat] = boat.transform.rotation;
                    addedCount++;
                }
            }
            
            // null이거나 WAKE인 항목 제거
            var keysToRemove = new System.Collections.Generic.List<GameObject>();
            foreach (var boat in _originalBoatPositions.Keys)
            {
                if (boat == null || boat.name.Contains("WAKE") || boat.name.Contains("Wake"))
                {
                    keysToRemove.Add(boat);
                }
            }
            foreach (var boat in keysToRemove)
            {
                _originalBoatPositions.Remove(boat);
                _originalBoatRotations.Remove(boat);
            }
        }
        
        /// <summary>
        /// 위치 리셋 코루틴 - 모든 선박 비활성화 없이 위치만 리셋 (Water System 호환)
        /// </summary>
        private System.Collections.IEnumerator ResetPositionsWithDeactivation()
        {
            Debug.Log($"[ResetPositionsWithDeactivation] ⚠️ 코루틴 시작:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
            
            // 모든 WAKE 객체 제거 및 WakeGenerator 비활성화
            DestroyAllWakeObjects();

            // ========================================
            // 1. 아군 선박(DefenseAgent) 위치 리셋 (비활성화 없이)
            // ========================================
            Debug.Log($"[ResetPositionsWithDeactivation] ⚠️ ResetDefenseAgentPosition 호출 전:");
            Debug.Log($"  - defense1SpawnPos: {defense1SpawnPos}");
            Debug.Log($"  - _originalDefense1Pos: {_originalDefense1Pos}");
            
            ResetDefenseAgentPosition(defenseAgent1, _originalDefense1Pos, defense1SpawnPos, _originalDefense1Rot);
            ResetDefenseAgentPosition(defenseAgent2, _originalDefense2Pos, defense2SpawnPos, _originalDefense2Rot);

            // 아군 선박 좌/우 위치 기록 (위치 교차 감지용)
            if (defenseAgent1 != null && defenseAgent2 != null)
            {
                Vector3 pos1 = defenseAgent1.transform.position;
                Vector3 pos2 = defenseAgent2.transform.position;
                // X축 기준으로 좌/우 판단 (pos1.x < pos2.x면 agent1이 왼쪽)
                _agent1StartsOnLeft = pos1.x < pos2.x;
                Debug.Log($"[ResetPositionsWithDeactivation] 초기 위치: agent1({pos1.x:F1}), agent2({pos2.x:F1}), agent1이 왼쪽: {_agent1StartsOnLeft}");
            }

            // ========================================
            // 2. 적군 선박들 위치 리셋 (비활성화 없이 - Water System Dictionary 충돌 방지)
            // ========================================
            ResetAttackBoatsToOrigin();

            // WebDetector 리셋
            if (_webDetector != null)
            {
                _webDetector.ResetDetector();
            }

            yield return null;

            // 코루틴 실행 완료 플래그 해제 및 에피소드 활성화
            _isResettingPositions = false;
            _episodeActive = true;
            Debug.Log($"[ResetPositionsWithDeactivation] ✅ 코루틴 완료: _episodeActive={_episodeActive}, _resetTimer={_resetTimer}");
        }

        /// <summary>
        /// 아군 선박 위치만 리셋 (비활성화 없이)
        /// originalPos = 인스펙터에 설정된 Spawn Position 값
        /// </summary>
        private void ResetDefenseAgentPosition(DefenseAgent agent, Vector3 originalPos, Vector3 defaultPos, Quaternion originalRot)
        {
            if (agent == null)
                return;

            Debug.Log($"[ResetDefenseAgentPosition] ⚠️ 함수 호출: {agent.name}");
            Debug.Log($"  - originalPos (전달받은 값): {originalPos} (IsZero: {originalPos == Vector3.zero})");
            Debug.Log($"  - defaultPos (전달받은 값): {defaultPos} (IsZero: {defaultPos == Vector3.zero})");
            Debug.Log($"  - _originalDefense1Pos (현재 필드 값): {_originalDefense1Pos} (IsZero: {_originalDefense1Pos == Vector3.zero})");
            Debug.Log($"  - defense1SpawnPos (현재 필드 값): {defense1SpawnPos} (IsZero: {defense1SpawnPos == Vector3.zero})");

            // 위치 계산: 인스펙터에 설정된 Spawn Position 사용
            // ⚠️ originalPos가 (0,0,0)이면 defaultPos 사용 (fallback)
            Vector3 targetPos = originalPos;
            if (targetPos == Vector3.zero && defaultPos != Vector3.zero)
            {
                Debug.LogWarning($"[ResetDefenseAgentPosition] ⚠️ originalPos가 (0,0,0)입니다! defaultPos({defaultPos})를 사용합니다.");
                targetPos = defaultPos;
            }

            if (enableRandomSpawn)
            {
                targetPos = GetRandomSpawnPosition(targetPos);
            }

            // Rigidbody 속도 초기화 + Sleep
            if (agent.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();  // 물리 시뮬레이션 일시 정지 (누적된 힘 제거)
            }

            // 위치와 회전 설정
            agent.transform.position = targetPos;
            agent.transform.rotation = originalRot;

            // Engine 리셋 (Gerstner 파도 안정화 전까지 _yHeight 조건 무시)
            if (agent._engine != null)
            {
                agent._engine.OnEpisodeReset();
            }

            // 항상 로그 출력 (디버깅용)
            Debug.Log($"[DefenseEnvController] 아군 선박 리셋: {agent.name} → {targetPos} (원점: {originalPos})");
        }
        
        /// <summary>
        /// 모든 적군 선박 (attack_boat 태그)을 원점으로 리셋
        /// 에피소드 재시작 시 호출되며, 파괴된 적군 선박도 다시 생성
        /// Stage 설정에 따라 재생성 수 제한
        /// </summary>
        private void ResetAttackBoatsToOrigin()
        {
            // null이거나 파괴된 객체 제거
            _attackBoats.RemoveAll(boat => boat == null);

            // Stage에 따른 목표 적군 수 결정
            int stageTargetCount = GetActiveEnemyCountForStage();

            // Stage1에서 적군 0대면 재생성 스킵
            if (stageTargetCount == 0)
            {
                Debug.Log("[ResetAttackBoatsToOrigin] Stage 설정에 따라 적군 재생성 스킵 (목표: 0대)");
                return;
            }

            // 씬의 모든 attack_boat 다시 찾기
            GameObject[] allAttackBoatsInScene = GameObject.FindGameObjectsWithTag("attack_boat");

            // 파괴된 attack_boat 재생성
            int recreatedCount = 0;

            // Stage 설정에 맞는 적군 수만큼만 재생성
            int targetCount = Mathf.Min(
                stageTargetCount,
                _initialAttackBoatCount > 0 ? _initialAttackBoatCount : _attackBoatPrefabs.Count
            );
            
            foreach (var kvp in _attackBoatPrefabs)
            {
                string boatName = kvp.Key;
                GameObject prefab = kvp.Value;
                
                if (prefab == null) continue;
                
                // 씬에서 같은 이름의 객체를 찾을 수 있는지 확인
                bool foundInScene = false;
                GameObject existingBoat = null;
                foreach (var boat in allAttackBoatsInScene)
                {
                    if (boat == null) continue;
                    string sceneBoatName = boat.name.Replace("(Clone)", "");
                    if (sceneBoatName == boatName)
                    {
                        foundInScene = true;
                        existingBoat = boat;
                        break;
                    }
                }
                
                // 씬에 없으면 재생성 필요 (단, 목표 수 초과 시 스킵)
                if (!foundInScene && recreatedCount < targetCount)
                {
                    // 프리팹에서 재생성
                    GameObject recreatedBoat = Instantiate(prefab);
                    recreatedBoat.name = boatName; // 원본 이름 유지
                    recreatedBoat.tag = "attack_boat"; // 태그 설정
                    recreatedBoat.SetActive(true); // 활성화
                    
                    // 초기 위치 찾기 (이름 기반 Dictionary에서 찾기)
                    Vector3 initialPos = Vector3.zero;
                    if (_attackBoatInitialPositionsByName.ContainsKey(boatName))
                    {
                        initialPos = _attackBoatInitialPositionsByName[boatName];
                    }
                    
                    recreatedBoat.transform.position = initialPos;
                    recreatedBoat.transform.rotation = Quaternion.identity;
                    
                    // Cinemachine Dolly Cart 리셋
                    CinemachineDollyCart dollyCart = recreatedBoat.GetComponent<CinemachineDollyCart>();
                    if (dollyCart != null)
                    {
                        // 원본 경로 찾기 (이름 기반 Dictionary에서 찾기)
                        if (_attackBoatInitialPathsByName.ContainsKey(boatName))
                        {
                            CinemachinePathBase originalPath = _attackBoatInitialPathsByName[boatName];
                            if (originalPath != null)
                            {
                                dollyCart.m_Path = originalPath;
                                dollyCart.m_Position = 0f;
                            }
                        }
                    }
                    
                    // Rigidbody 리셋
                    Rigidbody rb = recreatedBoat.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.velocity = Vector3.zero;
                        rb.angularVelocity = Vector3.zero;
                    }
                    
                    // 리스트에 추가
                    _attackBoats.Add(recreatedBoat);
                    _attackBoatInitialPositions[recreatedBoat] = initialPos;
                    if (dollyCart != null)
                    {
                        _attackBoatInitialPaths[recreatedBoat] = dollyCart.m_Path;
                    }
                    
                    // 이름 기반 Dictionary도 업데이트 (재생성된 객체용)
                    if (!_attackBoatInitialPositionsByName.ContainsKey(boatName))
                    {
                        _attackBoatInitialPositionsByName[boatName] = initialPos;
                    }
                    if (dollyCart != null && !_attackBoatInitialPathsByName.ContainsKey(boatName))
                    {
                        _attackBoatInitialPathsByName[boatName] = dollyCart.m_Path;
                    }
                    
                    recreatedCount++;
                }
            }
            
            // 씬의 모든 attack_boat를 _attackBoats 리스트에 추가 (없는 경우만)
            foreach (var boat in allAttackBoatsInScene)
            {
                if (boat != null && !_attackBoats.Contains(boat))
                {
                    _attackBoats.Add(boat);
                    
                    // 초기 위치/경로 저장 (아직 저장되지 않은 경우)
                    if (!_attackBoatInitialPositions.ContainsKey(boat))
                    {
                        Vector3 initialPos = boat.transform.position;
                        _attackBoatInitialPositions[boat] = initialPos;
                        
                        // 원본 프리팹 저장
                        string boatName = boat.name.Replace("(Clone)", "");
                        
                        // 이름 기반 초기 위치 저장
                        if (!_attackBoatInitialPositionsByName.ContainsKey(boatName))
                        {
                            _attackBoatInitialPositionsByName[boatName] = initialPos;
                        }
                        
                        if (!_attackBoatPrefabs.ContainsKey(boatName))
                        {
                            GameObject prefabCopy = Instantiate(boat);
                            prefabCopy.name = boatName;
                            prefabCopy.SetActive(false);
                            prefabCopy.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSave;
                            _attackBoatPrefabs[boatName] = prefabCopy;
                        }
                        
                        // Cinemachine Dolly Cart의 Path 저장
                        CinemachineDollyCart dollyCart = boat.GetComponent<CinemachineDollyCart>();
                        if (dollyCart != null)
                        {
                            _attackBoatInitialPaths[boat] = dollyCart.m_Path;
                            // 이름 기반 경로 저장
                            if (!_attackBoatInitialPathsByName.ContainsKey(boatName))
                            {
                                _attackBoatInitialPathsByName[boatName] = dollyCart.m_Path;
                            }
                        }
                        else
                        {
                            _attackBoatInitialPaths[boat] = null;
                            if (!_attackBoatInitialPathsByName.ContainsKey(boatName))
                            {
                                _attackBoatInitialPathsByName[boatName] = null;
                            }
                        }
                    }
                }
            }
            
            // 초기 선박 수 확인 및 업데이트
            // 재생성 후 총 선박 수가 초기 수보다 적으면 문제
            if (_attackBoats.Count < _initialAttackBoatCount && _initialAttackBoatCount > 0)
            {
                // 부족한 만큼 더 재생성 시도
                int missingCount = _initialAttackBoatCount - _attackBoats.Count;
                int additionalRecreated = 0;
                
                foreach (var kvp in _attackBoatPrefabs)
                {
                    if (additionalRecreated >= missingCount) break;
                    
                    string boatName = kvp.Key;
                    GameObject prefab = kvp.Value;
                    
                    if (prefab == null) continue;
                    
                    // 이미 리스트에 있는지 확인
                    bool alreadyInList = false;
                    foreach (var boat in _attackBoats)
                    {
                        if (boat != null)
                        {
                            string listBoatName = boat.name.Replace("(Clone)", "");
                            if (listBoatName == boatName)
                            {
                                alreadyInList = true;
                                break;
                            }
                        }
                    }
                    
                    if (!alreadyInList)
                    {
                        // 재생성
                        GameObject recreatedBoat = Instantiate(prefab);
                        recreatedBoat.name = boatName;
                        recreatedBoat.tag = "attack_boat";
                        recreatedBoat.SetActive(true);
                        
                        Vector3 initialPos = _attackBoatInitialPositionsByName.ContainsKey(boatName) 
                            ? _attackBoatInitialPositionsByName[boatName] 
                            : Vector3.zero;
                        
                        recreatedBoat.transform.position = initialPos;
                        recreatedBoat.transform.rotation = Quaternion.identity;
                        
                        CinemachineDollyCart dollyCart = recreatedBoat.GetComponent<CinemachineDollyCart>();
                        if (dollyCart != null && _attackBoatInitialPathsByName.ContainsKey(boatName))
                        {
                            CinemachinePathBase originalPath = _attackBoatInitialPathsByName[boatName];
                            if (originalPath != null)
                            {
                                dollyCart.m_Path = originalPath;
                                dollyCart.m_Position = 0f;
                            }
                        }
                        
                        Rigidbody rb = recreatedBoat.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.velocity = Vector3.zero;
                            rb.angularVelocity = Vector3.zero;
                        }
                        
                        _attackBoats.Add(recreatedBoat);
                        _attackBoatInitialPositions[recreatedBoat] = initialPos;
                        if (dollyCart != null)
                        {
                            _attackBoatInitialPaths[recreatedBoat] = dollyCart.m_Path;
                        }
                        
                        additionalRecreated++;
                    }
                }
                
                recreatedCount += additionalRecreated;
            }
            
            // 초기 선박 수 업데이트 (씬에 있는 선박 수가 더 많으면)
            if (_attackBoats.Count > _initialAttackBoatCount)
            {
                _initialAttackBoatCount = _attackBoats.Count;
            }
            
            // 모든 선박을 원점(초기 위치)으로 리셋 (비활성화/활성화 없이 - Water System 호환)
            int resetCount = 0;
            foreach (var boat in _attackBoats)
            {
                if (boat == null) continue;

                // 비활성화된 선박은 건너뛰지 않고 위치만 리셋
                // (SetActive 호출하지 않음 - Water System Dictionary 충돌 방지)

                // Rigidbody 리셋 (활성화 상태에서만 동작)
                if (boat.activeSelf)
                {
                    Rigidbody rb = boat.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.velocity = Vector3.zero;
                        rb.angularVelocity = Vector3.zero;
                    }
                }

                // 초기 위치로 리셋 (이름 기반으로 찾기)
                Vector3 spawnPos;
                string boatName = boat.name.Replace("(Clone)", "");

                if (_attackBoatInitialPositionsByName.ContainsKey(boatName))
                {
                    spawnPos = _attackBoatInitialPositionsByName[boatName];
                    if (!_attackBoatInitialPositions.ContainsKey(boat))
                    {
                        _attackBoatInitialPositions[boat] = spawnPos;
                    }
                }
                else if (_attackBoatInitialPositions.ContainsKey(boat))
                {
                    spawnPos = _attackBoatInitialPositions[boat];
                    _attackBoatInitialPositionsByName[boatName] = spawnPos;
                }
                else
                {
                    spawnPos = boat.transform.position;
                    _attackBoatInitialPositions[boat] = spawnPos;
                    _attackBoatInitialPositionsByName[boatName] = spawnPos;
                }

                // Cinemachine Dolly Cart 리셋 (위치 설정보다 먼저!)
                CinemachineDollyCart dollyCart = boat.GetComponent<CinemachineDollyCart>();
                if (dollyCart != null)
                {
                    CinemachinePathBase originalPath = null;

                    if (_attackBoatInitialPathsByName.ContainsKey(boatName))
                    {
                        originalPath = _attackBoatInitialPathsByName[boatName];
                    }
                    else if (_attackBoatInitialPaths.ContainsKey(boat) && _attackBoatInitialPaths[boat] != null)
                    {
                        originalPath = _attackBoatInitialPaths[boat];
                        _attackBoatInitialPathsByName[boatName] = originalPath;
                    }

                    if (originalPath != null)
                    {
                        dollyCart.m_Path = originalPath;
                        dollyCart.m_Position = 0f;

                        // Speed가 음수면 양수로 변경 (경로 0→끝 방향으로)
                        if (dollyCart.m_Speed < 0)
                        {
                            Debug.LogWarning($"[ResetAttackBoatsToOrigin] '{boatName}' Dolly Cart Speed가 음수({dollyCart.m_Speed})! 양수로 변경.");
                            dollyCart.m_Speed = Mathf.Abs(dollyCart.m_Speed);
                        }

                        // 경로 시작/끝 위치 확인
                        Vector3 pathStartPos = originalPath.EvaluatePositionAtUnit(0f, CinemachinePathBase.PositionUnits.PathUnits);
                        Vector3 pathEndPos = originalPath.EvaluatePositionAtUnit(originalPath.MaxPos, CinemachinePathBase.PositionUnits.PathUnits);
                        boat.transform.position = pathStartPos;
                        Debug.Log($"[ResetAttackBoatsToOrigin] '{boatName}' Dolly Cart - Position 0: {pathStartPos}, Position Max({originalPath.MaxPos}): {pathEndPos}, Speed: {dollyCart.m_Speed}");
                    }
                    else
                    {
                        // 경로가 없으면 저장된 위치 사용
                        boat.transform.position = spawnPos;
                        Debug.Log($"[ResetAttackBoatsToOrigin] '{boatName}' 저장된 위치로 리셋 (경로 없음): {spawnPos}");
                    }
                }
                else
                {
                    // Dolly Cart가 없으면 저장된 위치 사용
                    boat.transform.position = spawnPos;
                    Debug.Log($"[ResetAttackBoatsToOrigin] '{boatName}' 저장된 위치로 리셋 (Dolly Cart 없음): {spawnPos}");
                }

                boat.transform.rotation = Quaternion.identity;

                resetCount++;
            }
        }
        
        /// <summary>
        /// 씬에 있는 모든 WAKE(Clone) 객체를 찾아서 파괴하고, WakeGenerator 컴포넌트를 완전히 비활성화
        /// </summary>
        private void DestroyAllWakeObjects()
        {
            int destroyedCount = 0;
            
            // 씬에 있는 모든 GameObject를 찾아서 "Wake(Clone)" 이름을 가진 것들을 파괴
            // FindObjectsOfType은 활성화된 객체만 찾지만, FindObjectsOfTypeAll은 비활성화된 객체도 찾습니다
            GameObject[] allObjects = FindObjectsOfType<GameObject>(true); // true = 비활성화된 객체도 포함
            foreach (var obj in allObjects)
            {
                if (obj != null && obj.name.Contains("Wake") && (obj.name.Contains("Clone") || obj.name.Contains("(Clone)")))
                {
                    Destroy(obj);
                    destroyedCount++;
                }
            }
            
            // 모든 WakeGenerator 컴포넌트를 찾아서 비활성화하고 코루틴 중지
            WakeGenerator[] allWakeGenerators = FindObjectsOfType<WakeGenerator>(true); // true = 비활성화된 객체도 포함
            foreach (var wakeGen in allWakeGenerators)
            {
                if (wakeGen != null)
                {
                    // 모든 코루틴 중지
                    wakeGen.StopAllCoroutines();
                    // 컴포넌트 비활성화
                    wakeGen.enabled = false;
                }
            }
            
        }
        
        /// <summary>
        /// 위치 리셋 - 아군 선박은 비활성화 없이 위치만 리셋
        /// </summary>
        private void ResetPositions()
        {
            // 모든 WAKE(Clone) 객체 제거
            DestroyAllWakeObjects();

            // ========================================
            // 아군 선박(DefenseAgent)은 비활성화 없이 위치만 리셋
            // ========================================
            ResetDefenseAgentPosition(defenseAgent1, _originalDefense1Pos, defense1SpawnPos, _originalDefense1Rot);
            ResetDefenseAgentPosition(defenseAgent2, _originalDefense2Pos, defense2SpawnPos, _originalDefense2Rot);

            // Web 위치 설정 (2대 중간)
            if (webObject != null && defenseAgent1 != null && defenseAgent2 != null)
            {
                Vector3 webPos = (defenseAgent1.transform.position + defenseAgent2.transform.position) / 2f;
                webPos.y = webSpawnPos.y;
                webObject.transform.position = webPos;
            }
            else if (webObject != null)
            {
                webObject.transform.position = webSpawnPos;
            }
        }
        
        /// <summary>
        /// 기존 위치에서 랜덤 스폰 위치 생성
        /// </summary>
        private Vector3 GetRandomSpawnPosition(Vector3 originalPos)
        {
            float randomX = originalPos.x + Random.Range(-spawnRange, spawnRange);
            float randomZ = originalPos.z + Random.Range(-spawnRange, spawnRange);
            return new Vector3(randomX, originalPos.y, randomZ);
        }

        #endregion

        #region Stage Management

        /// <summary>
        /// RewardCalculator에 현재 Stage 동기화
        /// </summary>
        private void SyncStageToRewardCalculator()
        {
            if (rewardCalculator != null)
            {
                rewardCalculator.currentStage = currentStage;
                Debug.Log($"[SyncStageToRewardCalculator] Stage 동기화: {currentStage}");
            }
        }

        /// <summary>
        /// 현재 Stage에 맞는 설정 적용
        /// - Stage1: 적군 비활성화, 대형 유지만 학습
        /// - Stage2: 적군 1~2대 활성화, 포획 보상 학습
        /// - Stage3: 적군 3~5대 활성화, 전술 기동 학습
        /// </summary>
        private void ApplyStageSettings()
        {
            int activeEnemyCount = GetActiveEnemyCountForStage();

            Debug.Log($"[ApplyStageSettings] 현재 Stage: {currentStage}, 활성화할 적군 수: {activeEnemyCount}");

            // 적군 활성화/비활성화
            ApplyEnemyActivation(activeEnemyCount);

            // Stage별 추가 설정
            switch (currentStage)
            {
                case TrainingStage.Stage1_Formation:
                    // Stage1: 대형 유지에 집중
                    // 포획/모선 관련 이벤트는 발생해도 보상 없음 (적군이 비활성화되므로 발생 안함)
                    Debug.Log("[ApplyStageSettings] Stage1: 대형 유지 학습 모드");
                    break;

                case TrainingStage.Stage2_Capture:
                    // Stage2: 포획 보상 활성화
                    Debug.Log("[ApplyStageSettings] Stage2: 포획 보상 학습 모드");
                    break;

                case TrainingStage.Stage3_Tactical:
                    // Stage3: 전술 기동 보상 활성화
                    Debug.Log("[ApplyStageSettings] Stage3: 전술 기동 학습 모드");
                    break;
            }
        }

        /// <summary>
        /// 현재 Stage에서 활성화할 적군 수 반환
        /// </summary>
        private int GetActiveEnemyCountForStage()
        {
            switch (currentStage)
            {
                case TrainingStage.Stage1_Formation:
                    return disableEnemiesInStage1 ? 0 : stage1EnemyCount;

                case TrainingStage.Stage2_Capture:
                    return stage2EnemyCount;

                case TrainingStage.Stage3_Tactical:
                    return stage3EnemyCount;

                default:
                    return 0;
            }
        }

        /// <summary>
        /// 적군 선박 활성화/비활성화 적용
        /// </summary>
        private void ApplyEnemyActivation(int activeCount)
        {
            Debug.Log($"[ApplyEnemyActivation] ========== 적군 활성화 시작 ==========");
            Debug.Log($"[ApplyEnemyActivation] 목표 활성화 수: {activeCount}");
            Debug.Log($"[ApplyEnemyActivation] enemyShips 배열: {(enemyShips != null ? enemyShips.Length.ToString() + "개" : "null")}");
            Debug.Log($"[ApplyEnemyActivation] _attackBoats 리스트: {_attackBoats.Count}개");

            // enemyShips 배열과 _attackBoats 리스트 모두 처리
            int activated = 0;

            // enemyShips 배열 처리
            if (enemyShips != null && enemyShips.Length > 0)
            {
                for (int i = 0; i < enemyShips.Length; i++)
                {
                    if (enemyShips[i] != null)
                    {
                        bool shouldBeActive = activated < activeCount;
                        bool wasActive = enemyShips[i].activeSelf;
                        enemyShips[i].SetActive(shouldBeActive);

                        Debug.Log($"[ApplyEnemyActivation] [{i}] {enemyShips[i].name}: {(wasActive ? "ON" : "OFF")} → {(shouldBeActive ? "ON" : "OFF")}");

                        if (shouldBeActive)
                        {
                            activated++;
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"[ApplyEnemyActivation] [{i}] enemyShips[{i}]가 null입니다!");
                    }
                }
            }
            else
            {
                Debug.LogWarning("[ApplyEnemyActivation] ⚠️ enemyShips 배열이 비어있거나 null! Inspector에서 Enemy Ships에 적군을 할당하세요.");
            }

            // _attackBoats 리스트도 처리 (enemyShips와 중복되지 않는 것들)
            foreach (var boat in _attackBoats)
            {
                if (boat == null) continue;

                // enemyShips에 이미 포함되어 있는지 확인
                bool alreadyProcessed = false;
                if (enemyShips != null)
                {
                    foreach (var enemy in enemyShips)
                    {
                        if (enemy == boat)
                        {
                            alreadyProcessed = true;
                            break;
                        }
                    }
                }

                if (!alreadyProcessed)
                {
                    bool shouldBeActive = activated < activeCount;
                    boat.SetActive(shouldBeActive);

                    if (shouldBeActive)
                    {
                        activated++;
                    }
                }
            }

            Debug.Log($"[ApplyEnemyActivation] 총 {activated}대 적군 활성화됨 (목표: {activeCount})");
        }

        /// <summary>
        /// Stage 변경 (Inspector 또는 코드에서 호출)
        /// </summary>
        public void SetTrainingStage(TrainingStage newStage)
        {
            if (currentStage != newStage)
            {
                Debug.Log($"[SetTrainingStage] Stage 변경: {currentStage} → {newStage}");
                currentStage = newStage;
                SyncStageToRewardCalculator();
                ApplyStageSettings();
            }
        }

        /// <summary>
        /// 포획 보상 활성화 여부 (Stage2, Stage3에서만 true)
        /// </summary>
        public bool IsCaptureRewardEnabled()
        {
            return currentStage == TrainingStage.Stage2_Capture ||
                   currentStage == TrainingStage.Stage3_Tactical;
        }

        /// <summary>
        /// 모선 충돌 페널티 활성화 여부 (Stage2, Stage3에서만 true)
        /// </summary>
        public bool IsMotherShipPenaltyEnabled()
        {
            return currentStage == TrainingStage.Stage2_Capture ||
                   currentStage == TrainingStage.Stage3_Tactical;
        }

        /// <summary>
        /// 전술 기동 보상 활성화 여부 (Stage3에서만 true)
        /// </summary>
        public bool IsTacticalRewardEnabled()
        {
            return currentStage == TrainingStage.Stage3_Tactical;
        }

        #endregion
    }
}
