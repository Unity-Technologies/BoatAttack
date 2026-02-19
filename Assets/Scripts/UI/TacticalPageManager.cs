using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 전술 UI 페이지 전환 관리자
    /// Tab/Enter 키 또는 UI 버튼으로 풀스크린 페이지 순환
    /// (Tactical → Friendly Spec → Enemy Spec)
    /// </summary>
    public class TacticalPageManager : MonoBehaviour
    {
        [Header("=== Pages ===")]
        [Tooltip("풀스크린 페이지 패널들 (순서대로 전환)")]
        public GameObject[] pages;

        [Header("=== Page Indicator ===")]
        [Tooltip("현재 페이지 표시 텍스트 (예: 1/3)")]
        public Text textPageIndicator;

        [Tooltip("페이지 이름 표시 텍스트")]
        public Text textPageName;

        [Header("=== Navigation Buttons ===")]
        [Tooltip("이전 페이지 버튼")]
        public Button btnPrev;
        [Tooltip("다음 페이지 버튼")]
        public Button btnNext;

        [Header("=== Page Names ===")]
        public string[] pageNames = { "TACTICAL COMMAND", "FRIENDLY SHIP SPEC", "ENEMY SHIP SPEC" };

        [Header("=== Settings ===")]
        [Tooltip("다음 페이지 키 (기본: Tab)")]
        public KeyCode nextPageKey = KeyCode.Tab;
        [Tooltip("이전 페이지 키 (기본: Escape)")]
        public KeyCode prevPageKey = KeyCode.Escape;
        [Tooltip("다음 페이지 보조 키 (기본: Return)")]
        public KeyCode nextPageKeyAlt = KeyCode.Return;

        private int _currentPage = 0;

        private void Start()
        {
            if (pages == null || pages.Length == 0)
            {
                Debug.LogWarning("[TacticalPageManager] pages 배열이 비어있습니다! Inspector에서 페이지를 할당하세요.");
                return;
            }

            // 버튼 리스너 연결
            if (btnPrev != null) btnPrev.onClick.AddListener(PrevPage);
            if (btnNext != null) btnNext.onClick.AddListener(NextPage);

            ShowPage(0);
            Debug.Log($"[TacticalPageManager] 초기화 완료. {pages.Length}개 페이지, Tab/Enter로 전환");
        }

        private void Update()
        {
            if (Input.GetKeyDown(nextPageKey) || Input.GetKeyDown(nextPageKeyAlt))
            {
                NextPage();
            }
            else if (Input.GetKeyDown(prevPageKey))
            {
                PrevPage();
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

            // 인디케이터 업데이트
            if (textPageIndicator != null)
                textPageIndicator.text = $"{_currentPage + 1}/{pages.Length}";

            if (textPageName != null && pageNames != null && _currentPage < pageNames.Length)
                textPageName.text = pageNames[_currentPage];
        }

        public int CurrentPage => _currentPage;
    }
}
