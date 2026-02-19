using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// 전술 UI 컨트롤러 - Figma 디자인 기반
    /// 왼쪽 패널: 레이더, 공격 모드 버튼, 파라미터 슬라이더, 환경 정보
    /// 오른쪽 패널: 선박 스펙 슬라이더, 시뮬레이션 속도
    /// </summary>
    public class TacticalUIController : MonoBehaviour
    {
        [Header("=== References ===")]
        [Tooltip("방어 환경 컨트롤러")]
        public DefenseEnvController envController;

        [Tooltip("환경 컨트롤러 (파도/바람)")]
        public EnvironmentController environmentController;

        [Tooltip("레이더 디스플레이")]
        public RadarDisplay radarDisplay;

        [Header("=== Attack Mode Buttons ===")]
        [Tooltip("파상공격 버튼")]
        public Button btnWaveAttack;

        [Tooltip("양동작전 버튼")]
        public Button btnDiversionary;

        [Tooltip("집중공격 버튼")]
        public Button btnConcentrated;

        [Header("=== Left Panel Sliders ===")]
        [Tooltip("적군 수 슬라이더")]
        public Slider sliderEnemyCount;
        public Text textEnemyCount;

        [Tooltip("아군 수 슬라이더")]
        public Slider sliderFriendlyCount;
        public Text textFriendlyCount;

        [Tooltip("모선 피격 허용 횟수 슬라이더")]
        public Slider sliderMothershipHits;
        public Text textMothershipHits;

        [Header("=== Right Panel - Ship Spec Sliders ===")]
        [Tooltip("아군 속도 슬라이더 (horsePower)")]
        public Slider sliderFriendlySpeed;
        public Text textFriendlySpeed;

        [Tooltip("적군 속도 슬라이더")]
        public Slider sliderEnemySpeed;
        public Text textEnemySpeed;

        [Tooltip("아군 선회력 슬라이더 (steeringTorque)")]
        public Slider sliderFriendlyAngularSpeed;
        public Text textFriendlyAngularSpeed;

        [Tooltip("적군 선회력 슬라이더")]
        public Slider sliderEnemyAngularSpeed;
        public Text textEnemyAngularSpeed;

        [Tooltip("시뮬레이션 속도 슬라이더 (Time.timeScale)")]
        public Slider sliderSimSpeed;
        public Text textSimSpeed;

        [Header("=== Environment Info ===")]
        [Tooltip("해상 상태 텍스트")]
        public Text textSeaState;

        [Tooltip("바람 상태 텍스트")]
        public Text textWindState;

        [Tooltip("현재 공격 모드 텍스트")]
        public Text textAttackMode;

        [Header("=== Mode Button Colors ===")]
        public Color activeButtonColor = new Color(0.2f, 0.8f, 0.2f, 1f);
        public Color inactiveButtonColor = new Color(0.3f, 0.3f, 0.3f, 1f);

        // 현재 선택된 공격 모드
        public enum AttackMode { Wave, Diversionary, Concentrated }
        private AttackMode _currentMode = AttackMode.Wave;

        // 캐싱된 엔진 참조
        private List<Engine> _friendlyEngines = new List<Engine>();
        private List<Engine> _enemyEngines = new List<Engine>();

        private void Start()
        {
            // 1. 엔진 캐시 먼저 (현재 값을 읽기 위해)
            CacheEngines();

            // 2. 현재 실제 값으로 슬라이더 초기화 (리스너 없이 - 값 덮어쓰기 방지)
            InitSliderValues();

            // 3. 라벨 업데이트
            UpdateAllLabels();

            // 4. 리스너 등록 (초기화 완료 후에만 - 이후 사용자 조작만 반영)
            BindSliderListeners();

            SetupButtons();
            SetAttackMode(AttackMode.Wave);
        }

        /// <summary>
        /// 슬라이더 범위 설정 + 현재 실제 컴포넌트 값으로 초기화 (리스너 없이)
        /// </summary>
        private void InitSliderValues()
        {
            // 적군 수 (1~5) - EnvController 현재 값
            if (sliderEnemyCount != null)
            {
                sliderEnemyCount.minValue = 1;
                sliderEnemyCount.maxValue = 5;
                sliderEnemyCount.wholeNumbers = true;
                sliderEnemyCount.value = envController != null ? envController.stage3EnemyCount : 1;
            }

            // 아군 수 (표시용, 현재 고정 2)
            if (sliderFriendlyCount != null)
            {
                sliderFriendlyCount.minValue = 2;
                sliderFriendlyCount.maxValue = 6;
                sliderFriendlyCount.wholeNumbers = true;
                sliderFriendlyCount.value = 2;
            }

            // 모선 피격 허용 횟수 - EnvController 현재 값
            if (sliderMothershipHits != null)
            {
                sliderMothershipHits.minValue = 1;
                sliderMothershipHits.maxValue = 10;
                sliderMothershipHits.wholeNumbers = true;
                sliderMothershipHits.value = envController != null ? envController.maxCollisionCount : 1;
            }

            // 아군 속도 - 실제 Engine.horsePower에서 읽기
            if (sliderFriendlySpeed != null)
            {
                sliderFriendlySpeed.minValue = 1000f;
                sliderFriendlySpeed.maxValue = 15000f;
                sliderFriendlySpeed.value = GetCurrentFriendlyHorsePower();
            }

            // 적군 속도 - 실제 Engine.horsePower에서 읽기
            if (sliderEnemySpeed != null)
            {
                sliderEnemySpeed.minValue = 1000f;
                sliderEnemySpeed.maxValue = 15000f;
                sliderEnemySpeed.value = GetCurrentEnemyHorsePower();
            }

            // 아군 선회력 - 실제 Engine.steeringTorque에서 읽기
            if (sliderFriendlyAngularSpeed != null)
            {
                sliderFriendlyAngularSpeed.minValue = 1f;
                sliderFriendlyAngularSpeed.maxValue = 20f;
                sliderFriendlyAngularSpeed.value = GetCurrentFriendlySteeringTorque();
            }

            // 적군 선회력 - 실제 Engine.steeringTorque에서 읽기
            if (sliderEnemyAngularSpeed != null)
            {
                sliderEnemyAngularSpeed.minValue = 1f;
                sliderEnemyAngularSpeed.maxValue = 20f;
                sliderEnemyAngularSpeed.value = GetCurrentEnemySteeringTorque();
            }

            // 시뮬레이션 속도 - 현재 Time.timeScale에서 읽기
            if (sliderSimSpeed != null)
            {
                sliderSimSpeed.minValue = 0.1f;
                sliderSimSpeed.maxValue = 10f;
                sliderSimSpeed.value = Time.timeScale;
            }
        }

        /// <summary>
        /// 초기화 완료 후 리스너 바인딩 (값 설정 이후에만 호출)
        /// </summary>
        private void BindSliderListeners()
        {
            if (sliderEnemyCount != null) sliderEnemyCount.onValueChanged.AddListener(OnEnemyCountChanged);
            if (sliderFriendlyCount != null) sliderFriendlyCount.onValueChanged.AddListener(OnFriendlyCountChanged);
            if (sliderMothershipHits != null) sliderMothershipHits.onValueChanged.AddListener(OnMothershipHitsChanged);
            if (sliderFriendlySpeed != null) sliderFriendlySpeed.onValueChanged.AddListener(OnFriendlySpeedChanged);
            if (sliderEnemySpeed != null) sliderEnemySpeed.onValueChanged.AddListener(OnEnemySpeedChanged);
            if (sliderFriendlyAngularSpeed != null) sliderFriendlyAngularSpeed.onValueChanged.AddListener(OnFriendlyAngularSpeedChanged);
            if (sliderEnemyAngularSpeed != null) sliderEnemyAngularSpeed.onValueChanged.AddListener(OnEnemyAngularSpeedChanged);
            if (sliderSimSpeed != null) sliderSimSpeed.onValueChanged.AddListener(OnSimSpeedChanged);
        }

        #region Read Current Values from Engine

        private float GetCurrentFriendlyHorsePower()
        {
            foreach (var eng in _friendlyEngines)
                if (eng != null) return eng.horsePower;
            return 5800f; // 엔진 못 찾으면 Engine.cs 기본값
        }

        private float GetCurrentEnemyHorsePower()
        {
            foreach (var eng in _enemyEngines)
                if (eng != null) return eng.horsePower;
            return 5800f;
        }

        private float GetCurrentFriendlySteeringTorque()
        {
            foreach (var eng in _friendlyEngines)
                if (eng != null) return eng.steeringTorque;
            return 5f;
        }

        private float GetCurrentEnemySteeringTorque()
        {
            foreach (var eng in _enemyEngines)
                if (eng != null) return eng.steeringTorque;
            return 5f;
        }

        #endregion

        private void SetupButtons()
        {
            if (btnWaveAttack != null)
                btnWaveAttack.onClick.AddListener(() => SetAttackMode(AttackMode.Wave));
            if (btnDiversionary != null)
                btnDiversionary.onClick.AddListener(() => SetAttackMode(AttackMode.Diversionary));
            if (btnConcentrated != null)
                btnConcentrated.onClick.AddListener(() => SetAttackMode(AttackMode.Concentrated));
        }

        private void CacheEngines()
        {
            _friendlyEngines.Clear();
            _enemyEngines.Clear();

            if (envController == null) return;

            // 아군 엔진
            if (envController.defenseAgent1 != null)
            {
                var eng = envController.defenseAgent1.GetComponentInChildren<Engine>();
                if (eng != null) _friendlyEngines.Add(eng);
            }
            if (envController.defenseAgent2 != null)
            {
                var eng = envController.defenseAgent2.GetComponentInChildren<Engine>();
                if (eng != null) _friendlyEngines.Add(eng);
            }

            // 적군 엔진
            if (envController.enemyShips != null)
            {
                foreach (var enemy in envController.enemyShips)
                {
                    if (enemy != null)
                    {
                        var eng = enemy.GetComponentInChildren<Engine>();
                        if (eng != null) _enemyEngines.Add(eng);
                    }
                }
            }
        }

        private void Update()
        {
            UpdateEnvironmentInfo();
        }

        #region Slider Callbacks

        private void OnEnemyCountChanged(float value)
        {
            int count = Mathf.RoundToInt(value);
            if (envController != null)
            {
                envController.stage2EnemyCount = count;
                envController.stage3EnemyCount = count;
            }
            UpdateLabel(textEnemyCount, $"{count}");
        }

        private void OnFriendlyCountChanged(float value)
        {
            int count = Mathf.RoundToInt(value);
            UpdateLabel(textFriendlyCount, $"{count}");
        }

        private void OnMothershipHitsChanged(float value)
        {
            int hits = Mathf.RoundToInt(value);
            if (envController != null)
                envController.maxCollisionCount = hits;
            UpdateLabel(textMothershipHits, $"{hits}");
        }

        private void OnFriendlySpeedChanged(float value)
        {
            EnsureEnginesCached();
            foreach (var eng in _friendlyEngines)
            {
                if (eng != null) eng.horsePower = value;
            }
            UpdateLabel(textFriendlySpeed, $"{value:F0}");
        }

        private void OnEnemySpeedChanged(float value)
        {
            EnsureEnginesCached();
            foreach (var eng in _enemyEngines)
            {
                if (eng != null) eng.horsePower = value;
            }
            UpdateLabel(textEnemySpeed, $"{value:F0}");
        }

        private void OnFriendlyAngularSpeedChanged(float value)
        {
            EnsureEnginesCached();
            foreach (var eng in _friendlyEngines)
            {
                if (eng != null) eng.steeringTorque = value;
            }
            UpdateLabel(textFriendlyAngularSpeed, $"{value:F1}");
        }

        private void OnEnemyAngularSpeedChanged(float value)
        {
            EnsureEnginesCached();
            foreach (var eng in _enemyEngines)
            {
                if (eng != null) eng.steeringTorque = value;
            }
            UpdateLabel(textEnemyAngularSpeed, $"{value:F1}");
        }

        private void OnSimSpeedChanged(float value)
        {
            Time.timeScale = value;
            UpdateLabel(textSimSpeed, $"{value:F1}x");
        }

        #endregion

        #region Attack Mode

        public void SetAttackMode(AttackMode mode)
        {
            _currentMode = mode;
            UpdateModeButtons();
            UpdateLabel(textAttackMode, GetModeName(mode));
        }

        public AttackMode CurrentAttackMode => _currentMode;

        private string GetModeName(AttackMode mode)
        {
            switch (mode)
            {
                case AttackMode.Wave: return "파상공격";
                case AttackMode.Diversionary: return "양동작전";
                case AttackMode.Concentrated: return "집중공격";
                default: return "Unknown";
            }
        }

        private void UpdateModeButtons()
        {
            SetButtonColor(btnWaveAttack, _currentMode == AttackMode.Wave);
            SetButtonColor(btnDiversionary, _currentMode == AttackMode.Diversionary);
            SetButtonColor(btnConcentrated, _currentMode == AttackMode.Concentrated);
        }

        private void SetButtonColor(Button btn, bool active)
        {
            if (btn == null) return;
            var colors = btn.colors;
            colors.normalColor = active ? activeButtonColor : inactiveButtonColor;
            colors.highlightedColor = active ? activeButtonColor * 1.1f : inactiveButtonColor * 1.2f;
            btn.colors = colors;
        }

        #endregion

        #region Environment Info

        private void UpdateEnvironmentInfo()
        {
            if (environmentController == null) return;

            // 해상 상태
            if (textSeaState != null)
            {
                string seaLevel = GetSeaStateLabel(environmentController.waveStrength);
                textSeaState.text = $"Sea: {seaLevel} (Wave {environmentController.waveStrength:F1})";
            }

            // 바람 상태
            if (textWindState != null)
            {
                textWindState.text = $"Wind: {environmentController.windStrength:F0}m/s {environmentController.windDirection:F0}\u00b0";
            }
        }

        private string GetSeaStateLabel(float waveStrength)
        {
            if (waveStrength < 0.5f) return "Calm";
            if (waveStrength < 1.0f) return "Light";
            if (waveStrength < 2.0f) return "Moderate";
            if (waveStrength < 3.0f) return "Rough";
            return "Storm";
        }

        #endregion

        #region Helpers

        private void UpdateLabel(Text label, string value)
        {
            if (label != null) label.text = value;
        }

        private void UpdateAllLabels()
        {
            if (sliderEnemyCount != null) UpdateLabel(textEnemyCount, $"{Mathf.RoundToInt(sliderEnemyCount.value)}");
            if (sliderFriendlyCount != null) UpdateLabel(textFriendlyCount, $"{Mathf.RoundToInt(sliderFriendlyCount.value)}");
            if (sliderMothershipHits != null) UpdateLabel(textMothershipHits, $"{Mathf.RoundToInt(sliderMothershipHits.value)}");
            if (sliderFriendlySpeed != null) UpdateLabel(textFriendlySpeed, $"{sliderFriendlySpeed.value:F0}");
            if (sliderEnemySpeed != null) UpdateLabel(textEnemySpeed, $"{sliderEnemySpeed.value:F0}");
            if (sliderFriendlyAngularSpeed != null) UpdateLabel(textFriendlyAngularSpeed, $"{sliderFriendlyAngularSpeed.value:F1}");
            if (sliderEnemyAngularSpeed != null) UpdateLabel(textEnemyAngularSpeed, $"{sliderEnemyAngularSpeed.value:F1}");
            if (sliderSimSpeed != null) UpdateLabel(textSimSpeed, $"{sliderSimSpeed.value:F1}x");
        }

        /// <summary>
        /// 엔진 캐시가 비어있으면 자동 재캐싱 (Start 실행 순서 문제 대응)
        /// </summary>
        private void EnsureEnginesCached()
        {
            if (_friendlyEngines.Count == 0 && _enemyEngines.Count == 0)
                CacheEngines();
        }

        /// <summary>
        /// 엔진 캐시 갱신 (런타임에 선박이 추가/제거된 경우)
        /// </summary>
        public void RefreshEngineCache()
        {
            CacheEngines();
        }

        #endregion
    }
}
