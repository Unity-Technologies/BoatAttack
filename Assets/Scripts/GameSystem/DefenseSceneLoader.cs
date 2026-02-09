using UnityEngine;
using UnityEngine.InputSystem;

namespace BoatAttack
{
    /// <summary>
    /// Defense 씬을 로드하는 헬퍼 클래스
    /// 메인 메뉴나 다른 곳에서 Defense 씬으로 전환할 때 사용
    /// </summary>
    public class DefenseSceneLoader : MonoBehaviour
    {
        [Header("Scene Paths")]
        [Tooltip("플레이 모드 씬 경로\n⚠️ 폴더가 없으면 먼저 Assets/scenes/ml_agents/ 폴더를 생성하세요")]
        public string playScenePath = "scenes/ml_agents/defense_play";
        
        [Tooltip("학습 모드 씬 경로\n⚠️ 폴더가 없으면 먼저 Assets/scenes/ml_agents/ 폴더를 생성하세요")]
        public string trainingScenePath = "scenes/ml_agents/defense_training";
        
        [Header("Fallback (임시 사용)")]
        [Tooltip("ml_agents 폴더가 없을 때 사용할 임시 씬 경로")]
        public string fallbackScenePath = "scenes/demo_Island";

        /// <summary>
        /// 플레이 모드 씬 로드 (키보드 조작 가능)
        /// </summary>
        public void LoadPlayScene()
        {
            var scenePath = GetValidScenePath(playScenePath);
            Debug.Log($"Loading Defense Play Scene: {scenePath}");
            AppSettings.LoadScene(scenePath);
        }

        /// <summary>
        /// 학습 모드 씬 로드 (ML-Agents 학습용)
        /// </summary>
        public void LoadTrainingScene()
        {
            var scenePath = GetValidScenePath(trainingScenePath);
            Debug.Log($"Loading Defense Training Scene: {scenePath}");
            AppSettings.LoadScene(scenePath);
        }
        
        /// <summary>
        /// 씬 경로가 유효한지 확인하고, 없으면 폴백 경로 반환
        /// </summary>
        private string GetValidScenePath(string preferredPath)
        {
            // Unity에서 씬 경로 확인 (간단한 체크)
            var buildIndex = UnityEngine.SceneManagement.SceneUtility.GetBuildIndexByScenePath(preferredPath);
            
            if (buildIndex == -1)
            {
                Debug.LogWarning($"씬을 찾을 수 없습니다: {preferredPath}\n" +
                               $"임시로 폴백 씬을 사용합니다: {fallbackScenePath}\n" +
                               $"⚠️ Unity 에디터에서 Assets/scenes/ml_agents/ 폴더를 생성하고 씬을 만들어주세요.");
                return fallbackScenePath;
            }
            
            return preferredPath;
        }

        /// <summary>
        /// 커스텀 씬 경로로 로드
        /// </summary>
        /// <param name="scenePath">로드할 씬 경로</param>
        public void LoadCustomScene(string scenePath)
        {
            Debug.Log($"Loading Custom Scene: {scenePath}");
            AppSettings.LoadScene(scenePath);
        }

        /// <summary>
        /// 키보드 단축키로 씬 전환 (디버그용)
        /// F1: 플레이 씬, F2: 학습 씬
        /// Unity의 새로운 Input System 사용
        /// </summary>
        private void Update()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null) return;
            
            if (keyboard.f1Key.wasPressedThisFrame)
            {
                LoadPlayScene();
            }
            else if (keyboard.f2Key.wasPressedThisFrame)
            {
                LoadTrainingScene();
            }
        }
    }
}
