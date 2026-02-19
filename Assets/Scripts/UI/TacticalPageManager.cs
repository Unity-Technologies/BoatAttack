using UnityEngine;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace BoatAttack
{
    /// <summary>
    /// 전술 UI 페이지 전환 관리자
    /// Tab: 다음 페이지, Esc: 이전 페이지
    /// Enter: 게임 모드 토글 (UI 숨김, 미니 레이더만 상단 표시)
    /// </summary>
    public class TacticalPageManager : MonoBehaviour
    {
        [Header("=== Pages ===")]
        [Tooltip("풀스크린 페이지 패널들 (순서대로 전환)")]
        public GameObject[] pages;

        [Header("=== Page Indicator ===")]
        [Tooltip("현재 페이지 표시 텍스트 (예: 1/4)")]
        public Text textPageIndicator;

        [Tooltip("페이지 이름 표시 텍스트")]
        public Text textPageName;

        [Header("=== Navigation Buttons ===")]
        public Button btnPrev;
        public Button btnNext;

        [Header("=== Game Mode ===")]
        [Tooltip("게임 모드 시 상단에 표시할 미니 레이더 오버레이")]
        public GameObject radarOverlay;

        [Tooltip("하단 페이지 인디케이터 바")]
        public GameObject indicatorBar;

        [Header("=== Page Names ===")]
        public string[] pageNames = { "RADAR", "ENVIRONMENT", "FRIENDLY SHIP", "ENEMY SHIP" };

        private int _currentPage = 0;
        private bool _gameMode = false;

        public bool IsGameMode => _gameMode;

        private void Start()
        {
            if (pages == null || pages.Length == 0)
            {
                Debug.LogWarning("[TacticalPageManager] pages 배열이 비어있습니다!");
                return;
            }

            if (btnPrev != null) btnPrev.onClick.AddListener(PrevPage);
            if (btnNext != null) btnNext.onClick.AddListener(NextPage);

            // 미니 레이더 오버레이는 시작 시 숨김
            if (radarOverlay != null)
                radarOverlay.SetActive(false);

            ShowPage(0);
            Debug.Log($"[TacticalPageManager] 초기화 완료. {pages.Length}개 페이지, Tab=전환, Enter=게임모드");
        }

        private void Update()
        {
            bool tabPressed = false;
            bool enterPressed = false;
            bool escPressed = false;

#if ENABLE_INPUT_SYSTEM
            var kb = Keyboard.current;
            if (kb != null)
            {
                tabPressed = kb.tabKey.wasPressedThisFrame;
                enterPressed = kb.enterKey.wasPressedThisFrame || kb.numpadEnterKey.wasPressedThisFrame;
                escPressed = kb.escapeKey.wasPressedThisFrame;
            }
#else
            tabPressed = Input.GetKeyDown(KeyCode.Tab);
            enterPressed = Input.GetKeyDown(KeyCode.Return);
            escPressed = Input.GetKeyDown(KeyCode.Escape);
#endif

            if (enterPressed)
            {
                ToggleGameMode();
            }
            else if (_gameMode)
            {
                // 게임 모드 중 Tab/Esc → UI 모드로 복귀
                if (tabPressed || escPressed)
                    SetGameMode(false);
            }
            else
            {
                // UI 모드: Tab=다음, Esc=이전
                if (tabPressed)
                    NextPage();
                else if (escPressed)
                    PrevPage();
            }
        }

        public void ToggleGameMode()
        {
            SetGameMode(!_gameMode);
        }

        public void SetGameMode(bool on)
        {
            _gameMode = on;

            if (_gameMode)
            {
                // 게임 모드: 모든 페이지 숨기고 미니 레이더만 표시
                for (int i = 0; i < pages.Length; i++)
                {
                    if (pages[i] != null)
                        pages[i].SetActive(false);
                }

                if (indicatorBar != null)
                    indicatorBar.SetActive(false);

                if (radarOverlay != null)
                    radarOverlay.SetActive(true);
            }
            else
            {
                // UI 모드 복귀: 현재 페이지 + 인디케이터 표시
                if (radarOverlay != null)
                    radarOverlay.SetActive(false);

                if (indicatorBar != null)
                    indicatorBar.SetActive(true);

                ShowPage(_currentPage);
            }
        }

        public void NextPage()
        {
            if (pages == null || pages.Length == 0) return;
            _currentPage = (_currentPage + 1) % pages.Length;
            ShowPage(_currentPage);
        }

        public void PrevPage()
        {
            if (pages == null || pages.Length == 0) return;
            _currentPage = (_currentPage - 1 + pages.Length) % pages.Length;
            ShowPage(_currentPage);
        }

        public void ShowPage(int index)
        {
            if (pages == null) return;
            _currentPage = Mathf.Clamp(index, 0, pages.Length - 1);

            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i] != null)
                    pages[i].SetActive(i == _currentPage);
            }

            if (textPageIndicator != null)
                textPageIndicator.text = $"{_currentPage + 1}/{pages.Length}";

            if (textPageName != null && pageNames != null && _currentPage < pageNames.Length)
                textPageName.text = pageNames[_currentPage];
        }

        public int CurrentPage => _currentPage;
    }
}
