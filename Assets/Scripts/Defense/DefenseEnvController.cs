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
        [Tooltip("랜덤 스폰 범위 (기존 위치에서 반경 내 원형 영역)")]
        public float spawnRange = 30f;

        [Tooltip("랜덤 스폰 활성화 (에피소드 시작 시 랜덤 위치로 재생성)")]
        public bool enableRandomSpawn = true;

        [Tooltip("아군 선박 랜덤 시작 각도 범위 (±도)")]
        public float defenseRandomAngleRange = 30f;

        [Header("Enemy Path Randomization")]
        [Tooltip("적군 경로 랜덤화 활성화")]
        public bool enableEnemyPathRandomization = true;

        [Tooltip("적군 경로 랜덤 할당 활성화 (리셋 시 attack_track 중 랜덤 선택)")]
        public bool enableRandomPathAssignment = true;
        
        [Header("Mission Rewards")]
        [Tooltip("포획 성공 보상 (매 스텝 누적보상 대비 유의미한 크기로 설정)")]
        public float captureReward = 5.0f;

        [Tooltip("포획 거리 보너스 (최대) - 모선과 멀리서 포획할수록 보상")]
        public float captureDistanceBonus = 2.0f;

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

        // 씬의 모든 attack_track 경로 (랜덤 할당용)
        private CinemachineSmoothPath[] _availableAttackPaths;

        // 각 경로별 원본 웨이포인트 저장 (랜덤화용)
        private Vector3[][] _allOriginalWaypoints;

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
            
            // RewardCalculator 초기화
            if (rewardCalculator == null)
            {
                rewardCalculator = GetComponent<DefenseRewardCalculator>();
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
            
            // 만약 인스펙터 값이 (0,0,0)이면 강제로 기본값 설정
            if (defense1SpawnPos == Vector3.zero)
            {
                defense1SpawnPos = new Vector3(-115f, -8f, -10f);
            }
            if (defense2SpawnPos == Vector3.zero)
            {
                defense2SpawnPos = new Vector3(0f, -8f, -6f);
            }
            
            _originalDefense1Pos = defense1SpawnPos;
            _originalDefense2Pos = defense2SpawnPos;

            // 회전은 인스펙터에 설정된 각도 사용 (Euler → Quaternion 변환)
            _originalDefense1Rot = Quaternion.Euler(defense1SpawnRot);
            _originalDefense2Rot = Quaternion.Euler(defense2SpawnRot);

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

            // 씬의 모든 attack_track 경로 수집 및 원본 웨이포인트 저장
            FindAllAttackTrackPaths();
            SaveOriginalWaypoints();

            // 첫 에피소드 시작 (PushBlockEnvController 패턴)
            ResetScene();
            
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
                    RestartEpisode("AllyDistanceExceeded", allyDistancePenalty);
                    return;
                }

                // 최소 거리 미달 체크
                if (minAllyDistance > 0f && allyDist < minAllyDistance)
                {
                    RestartEpisode("AllyDistanceTooClose", allyDistancePenalty);
                    return;
                }

                // 위치 교차 체크 (왼쪽/오른쪽 위치가 바뀌면 페널티)
                bool agent1CurrentlyOnLeft = pos1.x < pos2.x;
                if (agent1CurrentlyOnLeft != _agent1StartsOnLeft)
                {
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
                return;
            }
            
            // 충돌 횟수 초기화 (에피소드 종료 시 즉시 리셋)
            _totalCollisionCount = 0;
            _collisionCooldownTimes.Clear();

            // Inspector 모니터 초기화
            _currentEpisodeReward = 0f;
            _lastStepReward = 0f;
            _cooperativeReward = 0f;
            _tacticalReward = 0f;
            _safetyPenalty = 0f;
            _currentStep = 0;
            _totalCollisions = 0;

            // 에피소드 번호 증가 및 로그 출력
            _episodeNumber++;
            
            // 타이머도 여기서 명시적으로 리셋 (안전장치)
            _resetTimer = 0;

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
            
            // 충돌 횟수 리셋
            _totalCollisionCount = 0;
            
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

            // 적군 경로 웨이포인트 랜덤화 (선박 리셋 전에 호출)
            RandomizeEnemyWaypoints();

            // 모든 선박 리셋
            ResetPositionsOnly();
            
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
                    return;
                }
            }

            // 충돌 시간 기록
            _collisionCooldownTimes[enemyBoat] = currentTime;

            // 통합 충돌 횟수 증가 (Web + MotherShip 합산)
            _totalCollisionCount++;

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

            // 페널티 부여 후 에피소드 종료
            RestartEpisode("AllyHitWeb", penalty);
        }

        /// <summary>
        /// 아군 선박들을 원점으로 리셋
        /// </summary>
        private void ResetDefenseAgentsToOrigin()
        {
            // 두 선박이 동일한 랜덤 각도를 바라보도록 한 번만 생성
            float sharedRandomAngle = enableRandomSpawn
                ? Random.Range(-defenseRandomAngleRange, defenseRandomAngleRange)
                : 0f;

            ResetDefenseAgentPosition(defenseAgent1, _originalDefense1Pos, defense1SpawnPos, _originalDefense1Rot, sharedRandomAngle);
            ResetDefenseAgentPosition(defenseAgent2, _originalDefense2Pos, defense2SpawnPos, _originalDefense2Rot, sharedRandomAngle);
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
                    return;
                }
            }

            // 충돌 시간 기록
            _collisionCooldownTimes[enemyBoat] = currentTime;

            // 통합 충돌 횟수 증가 (Web + MotherShip 합산)
            _totalCollisionCount++;

            // Stage1에서는 모선 충돌 페널티 비활성화
            // Stage2, Stage3에서만 페널티 부여
            float penalty = IsMotherShipPenaltyEnabled() ? motherShipCollisionPenalty : 0f;

            // 통합 충돌 횟수가 maxCollisionCount 이상이면 즉시 에피소드 종료
            if (_totalCollisionCount >= maxCollisionCount)
            {

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

            // 3. Cinemachine Dolly Cart 리셋 (랜덤 경로 할당 또는 원래 경로 복원)
            Cinemachine.CinemachineDollyCart dollyCart = attackBoat.GetComponent<Cinemachine.CinemachineDollyCart>();
            if (dollyCart != null)
            {
                CinemachinePathBase assignedPath = null;

                if (enableRandomPathAssignment)
                {
                    assignedPath = GetRandomAttackPath();
                }

                // 랜덤 경로가 없으면 원래 경로 fallback
                if (assignedPath == null && _attackBoatInitialPathsByName.ContainsKey(boatName))
                {
                    assignedPath = _attackBoatInitialPathsByName[boatName];
                }

                if (assignedPath != null)
                {
                    dollyCart.m_Path = assignedPath;
                }
                dollyCart.m_Position = 0f;
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
                enemyShips = new GameObject[foundBoats.Length];
                for (int i = 0; i < foundBoats.Length; i++)
                {
                    enemyShips[i] = foundBoats[i];
                }
            }
            
            foreach (var boat in foundBoats)
            {
                if (boat != null && !_attackBoats.Contains(boat))
                {
                    _attackBoats.Add(boat);
                    Vector3 initialPos = boat.transform.position;
                    _attackBoatInitialPositions[boat] = initialPos;

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
            
            // 모든 WAKE 객체 제거 및 WakeGenerator 비활성화
            DestroyAllWakeObjects();

            // ========================================
            // 1. 아군 선박(DefenseAgent) 위치 리셋 (비활성화 없이)
            // ========================================
            
            // 두 선박이 동일한 랜덤 각도를 바라보도록 한 번만 생성
            float sharedRandomAngle = enableRandomSpawn
                ? Random.Range(-defenseRandomAngleRange, defenseRandomAngleRange)
                : 0f;

            ResetDefenseAgentPosition(defenseAgent1, _originalDefense1Pos, defense1SpawnPos, _originalDefense1Rot, sharedRandomAngle);
            ResetDefenseAgentPosition(defenseAgent2, _originalDefense2Pos, defense2SpawnPos, _originalDefense2Rot, sharedRandomAngle);

            // 아군 선박 좌/우 위치 기록 (위치 교차 감지용)
            if (defenseAgent1 != null && defenseAgent2 != null)
            {
                Vector3 pos1 = defenseAgent1.transform.position;
                Vector3 pos2 = defenseAgent2.transform.position;
                // X축 기준으로 좌/우 판단 (pos1.x < pos2.x면 agent1이 왼쪽)
                _agent1StartsOnLeft = pos1.x < pos2.x;
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
        }

        /// <summary>
        /// 아군 선박 위치만 리셋 (비활성화 없이)
        /// originalPos = 인스펙터에 설정된 Spawn Position 값
        /// </summary>
        private void ResetDefenseAgentPosition(DefenseAgent agent, Vector3 originalPos, Vector3 defaultPos, Quaternion originalRot, float sharedRandomAngle)
        {
            if (agent == null)
                return;

            // originalPos가 (0,0,0)이면 defaultPos 사용 (fallback)
            Vector3 targetPos = originalPos;
            if (targetPos == Vector3.zero && defaultPos != Vector3.zero)
            {
                targetPos = defaultPos;
            }

            // 랜덤 스폰: 위치는 개별 랜덤, 각도는 두 선박 공유
            Quaternion targetRot = originalRot;
            if (enableRandomSpawn)
            {
                targetPos = GetRandomSpawnPosition(targetPos);
                targetRot = originalRot * Quaternion.Euler(0f, sharedRandomAngle, 0f);
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
            agent.transform.rotation = targetRot;

            // Engine 리셋 (Gerstner 파도 안정화 전까지 _yHeight 조건 무시)
            if (agent._engine != null)
            {
                agent._engine.OnEpisodeReset();
            }
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
                    
                    // Cinemachine Dolly Cart 리셋 (랜덤 경로 할당)
                    CinemachineDollyCart dollyCart = recreatedBoat.GetComponent<CinemachineDollyCart>();
                    if (dollyCart != null)
                    {
                        CinemachinePathBase assignedPath = enableRandomPathAssignment ? GetRandomAttackPath() : null;

                        if (assignedPath == null && _attackBoatInitialPathsByName.ContainsKey(boatName))
                        {
                            assignedPath = _attackBoatInitialPathsByName[boatName];
                        }

                        if (assignedPath != null)
                        {
                            dollyCart.m_Path = assignedPath;
                            dollyCart.m_Position = 0f;
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
                        if (dollyCart != null)
                        {
                            CinemachinePathBase assignedPath = enableRandomPathAssignment ? GetRandomAttackPath() : null;

                            if (assignedPath == null && _attackBoatInitialPathsByName.ContainsKey(boatName))
                            {
                                assignedPath = _attackBoatInitialPathsByName[boatName];
                            }

                            if (assignedPath != null)
                            {
                                dollyCart.m_Path = assignedPath;
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

                // Cinemachine Dolly Cart 리셋 (랜덤 경로 할당 또는 원래 경로 복원)
                CinemachineDollyCart dollyCart = boat.GetComponent<CinemachineDollyCart>();
                if (dollyCart != null)
                {
                    CinemachinePathBase assignedPath = null;

                    if (enableRandomPathAssignment)
                    {
                        assignedPath = GetRandomAttackPath();
                    }

                    // 랜덤 경로가 없으면 원래 경로 fallback
                    if (assignedPath == null)
                    {
                        if (_attackBoatInitialPathsByName.ContainsKey(boatName))
                        {
                            assignedPath = _attackBoatInitialPathsByName[boatName];
                        }
                        else if (_attackBoatInitialPaths.ContainsKey(boat) && _attackBoatInitialPaths[boat] != null)
                        {
                            assignedPath = _attackBoatInitialPaths[boat];
                            _attackBoatInitialPathsByName[boatName] = assignedPath;
                        }
                    }

                    if (assignedPath != null)
                    {
                        dollyCart.m_Path = assignedPath;
                        dollyCart.m_Position = 0f;

                        if (dollyCart.m_Speed < 0)
                        {
                            dollyCart.m_Speed = Mathf.Abs(dollyCart.m_Speed);
                        }

                        Vector3 pathStartPos = assignedPath.EvaluatePositionAtUnit(0f, CinemachinePathBase.PositionUnits.PathUnits);
                        boat.transform.position = pathStartPos;
                    }
                    else
                    {
                        boat.transform.position = spawnPos;
                    }
                }
                else
                {
                    // Dolly Cart가 없으면 저장된 위치 사용
                    boat.transform.position = spawnPos;
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
            float sharedAngle = enableRandomSpawn
                ? Random.Range(-defenseRandomAngleRange, defenseRandomAngleRange)
                : 0f;
            ResetDefenseAgentPosition(defenseAgent1, _originalDefense1Pos, defense1SpawnPos, _originalDefense1Rot, sharedAngle);
            ResetDefenseAgentPosition(defenseAgent2, _originalDefense2Pos, defense2SpawnPos, _originalDefense2Rot, sharedAngle);

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
        /// <summary>
        /// 원형 랜덤 스폰 위치 계산 (30m 반경 내 원형 영역)
        /// </summary>
        private Vector3 GetRandomSpawnPosition(Vector3 originalPos)
        {
            // 원형 영역 내 균등 분포 (극좌표 사용)
            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            float randomRadius = Mathf.Sqrt(Random.Range(0f, 1f)) * spawnRange; // sqrt로 균등 분포

            float randomX = originalPos.x + randomRadius * Mathf.Cos(randomAngle);
            float randomZ = originalPos.z + randomRadius * Mathf.Sin(randomAngle);
            return new Vector3(randomX, originalPos.y, randomZ);
        }

        /// <summary>
        /// 씬에서 "attack_track"을 이름에 포함하는 모든 오브젝트의 CinemachineSmoothPath를 수집
        /// </summary>
        private void FindAllAttackTrackPaths()
        {
            var paths = new System.Collections.Generic.List<CinemachineSmoothPath>();

            // 씬의 모든 CinemachineSmoothPath 중 이름에 "attacktrack"이 포함된 것을 수집
            var allPaths = FindObjectsOfType<CinemachineSmoothPath>();
            foreach (var path in allPaths)
            {
                string lowerName = path.gameObject.name.ToLower();
                if (lowerName.Contains("attacktrack") || lowerName.Contains("attack_track"))
                {
                    paths.Add(path);
                }
            }

            _availableAttackPaths = paths.ToArray();
        }

        /// <summary>
        /// 랜덤 attack_track 경로 반환
        /// </summary>
        private CinemachinePathBase GetRandomAttackPath()
        {
            if (_availableAttackPaths == null || _availableAttackPaths.Length == 0)
                return null;

            int index = Random.Range(0, _availableAttackPaths.Length);
            return _availableAttackPaths[index];
        }

        /// <summary>
        /// 모든 attack_track 경로의 원본 웨이포인트 저장 (Start()에서 호출)
        /// </summary>
        private void SaveOriginalWaypoints()
        {
            if (_availableAttackPaths == null || _availableAttackPaths.Length == 0)
                return;

            _allOriginalWaypoints = new Vector3[_availableAttackPaths.Length][];

            for (int p = 0; p < _availableAttackPaths.Length; p++)
            {
                var path = _availableAttackPaths[p];
                if (path == null || path.m_Waypoints == null)
                {
                    _allOriginalWaypoints[p] = new Vector3[0];
                    continue;
                }

                int waypointCount = path.m_Waypoints.Length;
                _allOriginalWaypoints[p] = new Vector3[waypointCount];

                for (int i = 0; i < waypointCount; i++)
                {
                    _allOriginalWaypoints[p][i] = path.m_Waypoints[i].position;
                }
            }
        }

        /// <summary>
        /// 모든 attack_track 경로의 웨이포인트 0, 1, 2번을 랜덤화 (에피소드 시작 시 호출)
        /// </summary>
        private void RandomizeEnemyWaypoints()
        {
            if (!enableEnemyPathRandomization)
                return;

            if (_availableAttackPaths == null || _allOriginalWaypoints == null)
                return;

            for (int p = 0; p < _availableAttackPaths.Length; p++)
            {
                var path = _availableAttackPaths[p];
                if (path == null || path.m_Waypoints == null)
                    continue;

                var origWaypoints = _allOriginalWaypoints[p];
                if (origWaypoints == null || origWaypoints.Length < 3)
                    continue;

                // 웨이포인트 0, 1, 2번만 랜덤화
                for (int i = 0; i < 3 && i < path.m_Waypoints.Length; i++)
                {
                    Vector3 originalPos = origWaypoints[i];
                    Vector3 randomizedPos = GetRandomSpawnPosition(originalPos);

                    if (path.transform.parent != null)
                    {
                        randomizedPos = path.transform.InverseTransformPoint(
                            path.transform.TransformPoint(originalPos) +
                            (randomizedPos - originalPos)
                        );
                    }
                    else
                    {
                        randomizedPos = originalPos + (randomizedPos - originalPos);
                    }

                    path.m_Waypoints[i].position = randomizedPos;
                }

                path.InvalidateDistanceCache();
            }
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


            // 적군 활성화/비활성화
            ApplyEnemyActivation(activeEnemyCount);

            // Stage별 추가 설정
            switch (currentStage)
            {
                case TrainingStage.Stage1_Formation:
                    // Stage1: 대형 유지에 집중
                    // 포획/모선 관련 이벤트는 발생해도 보상 없음 (적군이 비활성화되므로 발생 안함)
                    break;

                case TrainingStage.Stage2_Capture:
                    // Stage2: 포획 보상 활성화
                    break;

                case TrainingStage.Stage3_Tactical:
                    // Stage3: 전술 기동 보상 활성화
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
            int activated = 0;

            // enemyShips 배열 처리
            if (enemyShips != null && enemyShips.Length > 0)
            {
                for (int i = 0; i < enemyShips.Length; i++)
                {
                    if (enemyShips[i] != null)
                    {
                        bool shouldBeActive = activated < activeCount;
                        enemyShips[i].SetActive(shouldBeActive);

                        if (shouldBeActive)
                        {
                            activated++;
                        }
                    }
                }
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
        }

        /// <summary>
        /// Stage 변경 (Inspector 또는 코드에서 호출)
        /// </summary>
        public void SetTrainingStage(TrainingStage newStage)
        {
            if (currentStage != newStage)
            {
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

        #region Gizmo Visualization

        /// <summary>
        /// 에디터에서 스폰 범위 시각화
        /// </summary>
        private void OnDrawGizmos()
        {
            if (!enableRandomSpawn && !enableEnemyPathRandomization)
                return;

            // 아군 선박 스폰 범위 시각화 (Cyan)
            if (enableRandomSpawn)
            {
                Gizmos.color = new Color(0f, 1f, 1f, 0.3f); // 반투명 시안

                // Defense 1 스폰 범위
                Vector3 def1Pos = _originalDefense1Pos != Vector3.zero ? _originalDefense1Pos : defense1SpawnPos;
                if (def1Pos != Vector3.zero)
                {
                    DrawCircleGizmo(def1Pos, spawnRange, 32);
                    Gizmos.DrawWireSphere(def1Pos, 1f); // 중심점 표시
                }

                // Defense 2 스폰 범위
                Vector3 def2Pos = _originalDefense2Pos != Vector3.zero ? _originalDefense2Pos : defense2SpawnPos;
                if (def2Pos != Vector3.zero)
                {
                    DrawCircleGizmo(def2Pos, spawnRange, 32);
                    Gizmos.DrawWireSphere(def2Pos, 1f); // 중심점 표시
                }

                // 라벨 표시
                #if UNITY_EDITOR
                UnityEditor.Handles.color = Color.cyan;
                if (def1Pos != Vector3.zero)
                    UnityEditor.Handles.Label(def1Pos + Vector3.up * 5f, $"Defense1\n반경: {spawnRange}m");
                if (def2Pos != Vector3.zero)
                    UnityEditor.Handles.Label(def2Pos + Vector3.up * 5f, $"Defense2\n반경: {spawnRange}m");
                #endif
            }

            // 적군 웨이포인트 스폰 범위 시각화 (Red) - 모든 attack_track 경로
            if (enableEnemyPathRandomization && _availableAttackPaths != null)
            {
                Gizmos.color = new Color(1f, 0.3f, 0.3f, 0.3f); // 반투명 빨강

                for (int p = 0; p < _availableAttackPaths.Length; p++)
                {
                    var path = _availableAttackPaths[p];
                    if (path == null || path.m_Waypoints == null) continue;

                    for (int i = 0; i < 3 && i < path.m_Waypoints.Length; i++)
                    {
                        Vector3 waypointPos;
                        if (_allOriginalWaypoints != null && p < _allOriginalWaypoints.Length && i < _allOriginalWaypoints[p].Length)
                        {
                            waypointPos = _allOriginalWaypoints[p][i];
                        }
                        else
                        {
                            waypointPos = path.m_Waypoints[i].position;
                        }

                        if (path.transform != null)
                        {
                            waypointPos = path.transform.TransformPoint(waypointPos);
                        }

                        DrawCircleGizmo(waypointPos, spawnRange, 32);
                        Gizmos.DrawWireSphere(waypointPos, 2f);

                        #if UNITY_EDITOR
                        UnityEditor.Handles.color = Color.red;
                        UnityEditor.Handles.Label(waypointPos + Vector3.up * 5f, $"{path.gameObject.name} WP{i}\n반경: {spawnRange}m");
                        #endif
                    }
                }
            }
        }

        /// <summary>
        /// XZ 평면에 원 그리기 (Gizmo용)
        /// </summary>
        private void DrawCircleGizmo(Vector3 center, float radius, int segments)
        {
            float angleStep = 360f / segments;
            Vector3 prevPoint = center + new Vector3(radius, 0f, 0f);

            for (int i = 1; i <= segments; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;
                Vector3 newPoint = center + new Vector3(
                    Mathf.Cos(angle) * radius,
                    0f,
                    Mathf.Sin(angle) * radius
                );
                Gizmos.DrawLine(prevPoint, newPoint);
                prevPoint = newPoint;
            }
        }

        #endregion
    }
}
