using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 전술 UI 컨트롤러
    /// 레이더/환경/선박스펙 페이지의 데이터 바인딩 관리
    /// Canvas에 상주하며 모든 페이지의 UI 요소 업데이트
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

        [Header("=== Simulation ===")]
        [Tooltip("시뮬레이션 속도 슬라이더 (Time.timeScale)")]
        public Slider sliderSimSpeed;
        public Text textSimSpeed;

        [Header("=== Radar Info ===")]
        [Tooltip("레이더 범위 표시")]
        public Text textRadarRange;
        [Tooltip("현재 공격 모드 텍스트")]
        public Text textAttackMode;

        [Header("=== Status Panel ===")]
        public Text textStatusFriendly;
        public Text textStatusEnemy;
        public Text textStatusMothership;
        public Text textStatusWeb;
        public Text textStatusTime;
        public Text textStatusEpisode;

        [Header("=== Environment Visuals ===")]
        [Tooltip("해상 상태 바")]
        public SeaStateBarUI seaStateBar;
        [Tooltip("해상 상태 라벨")]
        public Text textSeaStateLabel;

        [Tooltip("파도 세부 정보")]
        public Text textWaveStrength;
        public Text textWaveSpeed;
        public Text textWaveDirection;

        [Tooltip("바람 나침반")]
        public WindCompassUI windCompass;
        [Tooltip("풍속 텍스트")]
        public Text textWindStrength;
        [Tooltip("풍향 텍스트")]
        public Text textWindDirection;

        [Header("=== Mode Button Colors ===")]
        public Color activeButtonColor = new Color(0.2f, 0.8f, 0.2f, 1f);
        public Color inactiveButtonColor = new Color(0.3f, 0.3f, 0.3f, 1f);

        // 현재 선택된 공격 모드
        public enum AttackMode { Wave, Diversionary, Concentrated }
        private AttackMode _currentMode = AttackMode.Wave;

        private void Start()
        {
            InitSliderValues();
            UpdateAllLabels();
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
            if (sliderSimSpeed != null) sliderSimSpeed.onValueChanged.AddListener(OnSimSpeedChanged);
        }

        private void SetupButtons()
        {
            if (btnWaveAttack != null)
                btnWaveAttack.onClick.AddListener(() => SetAttackMode(AttackMode.Wave));
            if (btnDiversionary != null)
                btnDiversionary.onClick.AddListener(() => SetAttackMode(AttackMode.Diversionary));
            if (btnConcentrated != null)
                btnConcentrated.onClick.AddListener(() => SetAttackMode(AttackMode.Concentrated));
        }

        private void Update()
        {
            UpdateEnvironmentInfo();
            UpdateStatusInfo();
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

            // 해상 상태 바
            if (seaStateBar != null)
            {
                seaStateBar.SetValue(environmentController.waveStrength);
                if (textSeaStateLabel != null)
                    textSeaStateLabel.text = seaStateBar.GetSeaStateLabel();
            }

            // 파도 세부 정보
            if (textWaveStrength != null)
                textWaveStrength.text = $"Strength: {environmentController.waveStrength:F1}";
            if (textWaveSpeed != null)
                textWaveSpeed.text = $"Speed: {environmentController.waveSpeed:F1}";
            if (textWaveDirection != null)
                textWaveDirection.text = $"Direction: {environmentController.waveDirection:F0}\u00b0";

            // 바람 나침반
            if (windCompass != null)
                windCompass.SetWind(environmentController.windDirection, environmentController.windStrength);
            if (textWindStrength != null)
                textWindStrength.text = $"{environmentController.windStrength:F0} m/s";
            if (textWindDirection != null)
                textWindDirection.text = $"{environmentController.windDirection:F0}\u00b0";

            // 레이더 범위
            if (textRadarRange != null && radarDisplay != null)
                textRadarRange.text = $"{radarDisplay.radarRange:F0}m";
        }

        #endregion

        #region Status Info

        private void UpdateStatusInfo()
        {
            if (envController == null) return;

            if (textStatusFriendly != null)
            {
                int count = 0;
                if (envController.defenseAgent1 != null) count++;
                if (envController.defenseAgent2 != null) count++;
                textStatusFriendly.text = $"FRIENDLY: {count} vessels";
            }

            if (textStatusEnemy != null)
            {
                int active = 0;
                if (envController.enemyShips != null)
                    foreach (var e in envController.enemyShips)
                        if (e != null && e.activeInHierarchy) active++;
                textStatusEnemy.text = $"ENEMY: {active} vessels";
            }

            if (textStatusMothership != null)
            {
                bool alive = envController.motherShip != null && envController.motherShip.activeInHierarchy;
                textStatusMothership.text = alive ? "MOTHERSHIP: Active" : "MOTHERSHIP: --";
            }

            if (textStatusWeb != null)
            {
                bool hasWeb = envController.defenseAgent1 != null && envController.defenseAgent2 != null;
                if (hasWeb)
                {
                    float dist = Vector3.Distance(
                        envController.defenseAgent1.transform.position,
                        envController.defenseAgent2.transform.position);
                    textStatusWeb.text = $"WEB: {dist:F0}m";
                }
                else
                {
                    textStatusWeb.text = "WEB: --";
                }
            }

            if (textStatusTime != null)
                textStatusTime.text = $"TIME: {Time.time:F1}s";

            if (textStatusEpisode != null)
                textStatusEpisode.text = $"SPEED: {Time.timeScale:F1}x";
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
            if (sliderSimSpeed != null) UpdateLabel(textSimSpeed, $"{sliderSimSpeed.value:F1}x");
        }

        #endregion
    }
}
