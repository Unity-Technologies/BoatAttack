using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// 학습 모드와 플레이 모드를 관리하는 매니저
    /// 학습 모드: ML-Agents 에이전트가 제어
    /// 플레이 모드: 키보드로 직접 조작
    /// </summary>
    public class GameModeManager : MonoBehaviour
    {
        public enum GameMode
        {
            Play,      // 키보드 조작 모드
            Training   // ML-Agents 학습 모드
        }

        public static GameModeManager Instance { get; private set; }
        
        [Header("Mode Settings")]
        [SerializeField] private GameMode currentMode = GameMode.Play;
        
        [Header("Debug")]
        [SerializeField] private bool showDebugInfo = true;

        public static GameMode CurrentMode => Instance != null ? Instance.currentMode : GameMode.Play;
        
        public static bool IsTrainingMode => CurrentMode == GameMode.Training;
        public static bool IsPlayMode => CurrentMode == GameMode.Play;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            if (showDebugInfo)
                Debug.Log($"GameModeManager initialized. Current Mode: {currentMode}");
        }

        /// <summary>
        /// 런타임에 모드 전환 (디버그용)
        /// </summary>
        public void SetMode(GameMode mode)
        {
            if (currentMode == mode) return;
            
            currentMode = mode;
            
            if (showDebugInfo)
                Debug.Log($"Game mode changed to: {mode}");
            
            // 모드 변경 이벤트 발생 가능
            OnModeChanged?.Invoke(mode);
        }

        /// <summary>
        /// 모드 전환 이벤트
        /// </summary>
        public static System.Action<GameMode> OnModeChanged;

        /// <summary>
        /// 에디터에서 모드 전환 (런타임 테스트용)
        /// </summary>
        [ContextMenu("Switch to Play Mode")]
        private void SwitchToPlayMode()
        {
            SetMode(GameMode.Play);
        }

        [ContextMenu("Switch to Training Mode")]
        private void SwitchToTrainingMode()
        {
            SetMode(GameMode.Training);
        }

        private void OnGUI()
        {
            if (!showDebugInfo) return;
            
            // 화면 상단에 현재 모드 표시
            GUIStyle style = new GUIStyle();
            style.fontSize = 20;
            style.normal.textColor = currentMode == GameMode.Training ? Color.yellow : Color.white;
            style.alignment = TextAnchor.UpperLeft;
            
            GUI.Label(new Rect(10, 10, 300, 30), $"Mode: {currentMode}", style);
        }
    }
}
