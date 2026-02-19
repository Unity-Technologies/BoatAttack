using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 전술 시스템 자동 세팅 에디터 스크립트 (v5)
    /// - Page 0: 레이더 전용 (풀스크린 레이더 + 컨트롤)
    /// - Page 1: 환경 정보 (SeaState 바 + Wind 나침반)
    /// - Page 2: 아군 선박 스펙 (3D 프리뷰)
    /// - Page 3: 적군 선박 스펙 (3D 프리뷰)
    /// </summary>
    public static class TacticalSystemSetup
    {
        static readonly Color BG_DARK = new Color(0.06f, 0.06f, 0.12f, 0.95f);
        static readonly Color BG_PANEL = new Color(0.08f, 0.1f, 0.16f, 0.92f);
        static readonly Color ACCENT_GREEN = new Color(0.3f, 1f, 0.5f, 1f);
        static readonly Color ACCENT_CYAN = new Color(0.2f, 0.85f, 1f, 1f);
        static readonly Color ACCENT_RED = new Color(1f, 0.3f, 0.25f, 1f);
        static readonly Color ACCENT_YELLOW = new Color(1f, 0.9f, 0.3f, 1f);
        static readonly Color TEXT_DIM = new Color(0.6f, 0.6f, 0.7f, 1f);
        static readonly Color TEXT_BRIGHT = new Color(0.9f, 0.9f, 0.95f, 1f);
        static readonly Color SLIDER_BG = new Color(0.12f, 0.12f, 0.2f, 1f);
        static readonly Color SLIDER_FILL = new Color(0.15f, 0.5f, 0.25f, 1f);
        static readonly Color HANDLE_COLOR = new Color(0.85f, 0.85f, 0.9f, 1f);

        [MenuItem("BoatAttack/Setup Tactical System (All)", false, 100)]
        public static void SetupAll()
        {
            var env = Object.FindObjectOfType<DefenseEnvController>();
            if (env == null)
            {
                EditorUtility.DisplayDialog("Error",
                    "DefenseEnvController를 씬에서 찾을 수 없습니다.", "OK");
                return;
            }
            var envCtrl = Object.FindObjectOfType<EnvironmentController>();

            SetupTacticalNetwork(env);
            SetupFullUI(env, envCtrl);

            EditorUtility.DisplayDialog("Setup Complete",
                "전술 시스템 v5 세팅 완료!\n\n" +
                "- Page 0: 레이더 (풀스크린)\n" +
                "- Page 1: 환경 (SeaState + Wind)\n" +
                "- Page 2: 아군 선박 스펙 (3D)\n" +
                "- Page 3: 적군 선박 스펙 (3D)\n\n" +
                "[Tab] 페이지 전환\n" +
                "[Enter] 게임 모드 (UI 숨김 + 미니 레이더)\n" +
                "[Esc] 이전 페이지 / UI 복귀\n\n" +
                "Island 태그 추가 필요!\n" +
                "Ctrl+S로 씬 저장하세요.", "OK");
        }

        [MenuItem("BoatAttack/Tag Islands", false, 105)]
        public static void TagIslands()
        {
            int count = 0;
            // "Island Level" 이름으로 시작하는 오브젝트 검색
            foreach (var go in Object.FindObjectsOfType<GameObject>())
            {
                if (go.name.StartsWith("Island Level") || go.name.Contains("Island"))
                {
                    // Terrain 또는 MeshFilter가 있는 경우만
                    if (go.GetComponent<Terrain>() != null ||
                        go.GetComponentInChildren<MeshFilter>() != null)
                    {
                        if (go.tag != "Island")
                        {
                            Undo.RecordObject(go, "Tag Island");
                            go.tag = "Island";
                            EditorUtility.SetDirty(go);
                            count++;
                        }
                    }
                }
            }
            EditorUtility.DisplayDialog("Tag Islands",
                $"{count}개 오브젝트에 Island 태그 적용 완료.\nCtrl+S로 씬 저장하세요.", "OK");
        }

        [MenuItem("BoatAttack/Remove Tactical UI", false, 110)]
        public static void RemoveTacticalUI()
        {
            var pm = Object.FindObjectOfType<TacticalPageManager>();
            if (pm != null) Undo.DestroyObjectImmediate(pm.gameObject);
            var tc = Object.FindObjectOfType<TacticalClient>();
            if (tc != null) Undo.DestroyObjectImmediate(tc.gameObject);
        }

        static void SetupTacticalNetwork(DefenseEnvController env)
        {
            if (Object.FindObjectOfType<TacticalClient>() != null) return;

            var obj = new GameObject("TacticalSystem");
            Undo.RegisterCreatedObjectUndo(obj, "Create TacticalSystem");

            var client = obj.AddComponent<TacticalClient>();
            client.envController = env;
            client.host = "localhost";
            client.port = 9877;
            client.sendInterval = 0.1f;
            client.autoConnect = true;

            var receiver = obj.AddComponent<TacticalAssignmentReceiver>();
            receiver.tacticalClient = client;
            receiver.envController = env;
            EditorUtility.SetDirty(obj);
        }

        // ================================================================
        // Full UI
        // ================================================================

        static void SetupFullUI(DefenseEnvController env, EnvironmentController envCtrl)
        {
            var existing = Object.FindObjectOfType<TacticalPageManager>();
            if (existing != null) Undo.DestroyObjectImmediate(existing.gameObject);

            // Canvas
            var canvasObj = new GameObject("TacticalUI_Canvas");
            Undo.RegisterCreatedObjectUndo(canvasObj, "Create TacticalUI");

            var canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 100;

            var scaler = canvasObj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.matchWidthOrHeight = 0.5f;

            canvasObj.AddComponent<GraphicRaycaster>();

            // EventSystem 중복 방지 (비활성 포함 검색)
            var existingES = Object.FindObjectsOfType<UnityEngine.EventSystems.EventSystem>(true);
            if (existingES == null || existingES.Length == 0)
            {
                var esObj = new GameObject("EventSystem");
                esObj.AddComponent<UnityEngine.EventSystems.EventSystem>();
#if ENABLE_INPUT_SYSTEM
                esObj.AddComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
#else
                esObj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
#endif
                Undo.RegisterCreatedObjectUndo(esObj, "Create EventSystem");
            }

            var pm = canvasObj.AddComponent<TacticalPageManager>();

            // TacticalUIController는 Canvas에 (항상 활성)
            var uiCtrl = canvasObj.AddComponent<TacticalUIController>();
            uiCtrl.envController = env;
            uiCtrl.environmentController = envCtrl;

            // Page 0: Radar (풀스크린 레이더)
            var page0 = CreateFullscreenPage(canvasObj.transform, "Page_Radar");
            BuildRadarPage(page0, uiCtrl, env);

            // Page 1: Environment
            var page1 = CreateFullscreenPage(canvasObj.transform, "Page_Environment");
            BuildEnvironmentPage(page1, uiCtrl, envCtrl);

            // Page 2: Friendly Ship Spec
            var page2 = CreateFullscreenPage(canvasObj.transform, "Page_FriendlySpec");
            var fSpec = page2.AddComponent<ShipSpecPanel>();
            fSpec.envController = env;
            fSpec.isEnemy = false;
            BuildShipSpecPage(page2, fSpec, env, "FRIENDLY SHIP PARAMETER", ACCENT_CYAN, false);

            // Page 3: Enemy Ship Spec
            var page3 = CreateFullscreenPage(canvasObj.transform, "Page_EnemySpec");
            var eSpec = page3.AddComponent<ShipSpecPanel>();
            eSpec.envController = env;
            eSpec.isEnemy = true;
            BuildShipSpecPage(page3, eSpec, env, "ENEMY SHIP PARAMETER", ACCENT_RED, true);

            // PageManager
            pm.pages = new[] { page0, page1, page2, page3 };
            pm.pageNames = new[] { "RADAR", "ENVIRONMENT", "FRIENDLY SHIP", "ENEMY SHIP" };
            var indicatorObj = CreateIndicatorBar(canvasObj.transform, pm);
            pm.indicatorBar = indicatorObj;

            // 게임 모드용 미니 레이더 오버레이 (Canvas 직속, 시작 시 숨김)
            var radarOverlay = BuildMiniRadarOverlay(canvasObj.transform, env);
            pm.radarOverlay = radarOverlay;
            radarOverlay.SetActive(false);

            // SetDirty
            EditorUtility.SetDirty(pm);
            EditorUtility.SetDirty(uiCtrl);
            EditorUtility.SetDirty(fSpec);
            EditorUtility.SetDirty(eSpec);
            EditorUtility.SetDirty(canvasObj);
        }

        // ================================================================
        // Page 0: Tactical Command (레이더 좌상단 소형)
        // ================================================================

        static void BuildRadarPage(GameObject page, TacticalUIController uiCtrl, DefenseEnvController env)
        {
            page.AddComponent<Image>().color = BG_DARK;

            CreateLabel(page.transform, "Title", "TACTICAL COMMAND",
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(20, -10), new Vector2(-20, 25),
                22, FontStyle.Bold, ACCENT_GREEN);

            // === 좌상단: 소형 레이더 (화면의 약 1/5) ===
            var radarBg = CreatePanel(page.transform, "RadarBg",
                new Vector2(0.02f, 0.52f), new Vector2(0.38f, 0.95f),
                Vector2.zero, Vector2.zero, new Color(0.03f, 0.06f, 0.03f, 0.95f));

            var radarObj = new GameObject("RadarDisplay");
            radarObj.transform.SetParent(radarBg.transform, false);
            var radarRt = radarObj.AddComponent<RectTransform>();
            radarRt.anchorMin = new Vector2(0.03f, 0.03f);
            radarRt.anchorMax = new Vector2(0.97f, 0.97f);
            radarRt.offsetMin = Vector2.zero;
            radarRt.offsetMax = Vector2.zero;

            var radar = radarObj.AddComponent<RadarDisplay>();
            radar.envController = env;
            radar.radarRange = 1000f;
            uiCtrl.radarDisplay = radar;

            // 레이더 하단 정보
            var radarInfo = CreatePanel(page.transform, "RadarInfo",
                new Vector2(0.02f, 0.44f), new Vector2(0.38f, 0.52f),
                Vector2.zero, Vector2.zero, new Color(0.05f, 0.08f, 0.05f, 0.8f));

            CreateLabel(radarInfo.transform, "RangeLabel", "RANGE",
                new Vector2(0, 0), new Vector2(0.25f, 1),
                new Vector2(8, 0), Vector2.zero, 10, FontStyle.Normal, TEXT_DIM);

            uiCtrl.textRadarRange = CreateLabel(radarInfo.transform, "RangeVal", "1000m",
                new Vector2(0.25f, 0), new Vector2(0.55f, 1),
                Vector2.zero, Vector2.zero, 12, FontStyle.Bold, ACCENT_GREEN).GetComponent<Text>();

            // 범례
            CreateLabel(radarInfo.transform, "Legend",
                "\u25B2 Friend  \u25B2 Enemy  \u25C6 MS",
                new Vector2(0.55f, 0), new Vector2(1, 1),
                Vector2.zero, Vector2.zero, 9, FontStyle.Normal, TEXT_DIM);

            // === 우측: 공격 모드 + 슬라이더 ===
            var ctrlPanel = CreatePanel(page.transform, "ControlPanel",
                new Vector2(0.40f, 0.44f), new Vector2(0.98f, 0.95f),
                Vector2.zero, Vector2.zero, BG_PANEL);

            // 공격 모드
            CreateLabel(ctrlPanel.transform, "ModeTitle", "ATTACK MODE",
                new Vector2(0, 0.85f), new Vector2(0.4f, 0.98f),
                new Vector2(12, 0), Vector2.zero, 14, FontStyle.Bold, TEXT_DIM);

            uiCtrl.textAttackMode = CreateLabel(ctrlPanel.transform, "ModeVal", "파상공격",
                new Vector2(0.4f, 0.85f), new Vector2(0.75f, 0.98f),
                Vector2.zero, Vector2.zero, 14, FontStyle.Bold, ACCENT_YELLOW).GetComponent<Text>();

            // 공격 모드 버튼 (가로 배치)
            uiCtrl.btnWaveAttack = CreateBtn(ctrlPanel.transform, "BtnWave", "파상공격",
                new Vector2(0.02f, 0.7f), new Vector2(0.33f, 0.84f), new Color(0.15f, 0.45f, 0.15f, 1f));
            uiCtrl.btnDiversionary = CreateBtn(ctrlPanel.transform, "BtnDiv", "양동작전",
                new Vector2(0.35f, 0.7f), new Vector2(0.66f, 0.84f), new Color(0.25f, 0.25f, 0.3f, 1f));
            uiCtrl.btnConcentrated = CreateBtn(ctrlPanel.transform, "BtnConc", "집중공격",
                new Vector2(0.68f, 0.7f), new Vector2(0.98f, 0.84f), new Color(0.25f, 0.25f, 0.3f, 1f));

            // 구분선
            CreatePanel(ctrlPanel.transform, "Divider1",
                new Vector2(0.05f, 0.67f), new Vector2(0.95f, 0.675f),
                Vector2.zero, Vector2.zero, new Color(0.3f, 0.3f, 0.4f, 0.5f));

            // 파라미터 슬라이더
            CreateLabel(ctrlPanel.transform, "ParamTitle", "PARAMETERS",
                new Vector2(0, 0.56f), new Vector2(0.4f, 0.66f),
                new Vector2(12, 0), Vector2.zero, 14, FontStyle.Bold, TEXT_DIM);

            var slArea = CreatePanel(ctrlPanel.transform, "Sliders",
                new Vector2(0.02f, 0.03f), new Vector2(0.98f, 0.55f),
                Vector2.zero, Vector2.zero, new Color(0, 0, 0, 0));

            var (sl1, tx1) = MakeSlider(slArea.transform, "EnemyCount", "적군 수",
                new Vector2(0, 0.68f), new Vector2(0.48f, 1));
            uiCtrl.sliderEnemyCount = sl1; uiCtrl.textEnemyCount = tx1;

            var (sl2, tx2) = MakeSlider(slArea.transform, "MSHits", "모선 피격",
                new Vector2(0.52f, 0.68f), new Vector2(1, 1));
            uiCtrl.sliderMothershipHits = sl2; uiCtrl.textMothershipHits = tx2;

            var (sl3, tx3) = MakeSlider(slArea.transform, "SimSpeed", "시뮬레이션",
                new Vector2(0, 0.34f), new Vector2(0.48f, 0.66f));
            uiCtrl.sliderSimSpeed = sl3; uiCtrl.textSimSpeed = tx3;

            // === 하단: 상태 요약 ===
            var statusBar = CreatePanel(page.transform, "StatusBar",
                new Vector2(0.02f, 0.02f), new Vector2(0.98f, 0.42f),
                Vector2.zero, Vector2.zero, BG_PANEL);

            CreateLabel(statusBar.transform, "StatusTitle", "STATUS",
                new Vector2(0, 0.85f), new Vector2(0.3f, 1),
                new Vector2(12, 0), Vector2.zero, 16, FontStyle.Bold, TEXT_DIM);

            // 상태 정보 그리드
            uiCtrl.textStatusFriendly = CreateLabel(statusBar.transform, "StatFriendly",
                "FRIENDLY: 2 vessels",
                new Vector2(0.02f, 0.6f), new Vector2(0.48f, 0.82f),
                new Vector2(10, 0), Vector2.zero, 14, FontStyle.Normal, ACCENT_CYAN).GetComponent<Text>();

            uiCtrl.textStatusEnemy = CreateLabel(statusBar.transform, "StatEnemy",
                "ENEMY: 0 vessels",
                new Vector2(0.52f, 0.6f), new Vector2(0.98f, 0.82f),
                new Vector2(10, 0), Vector2.zero, 14, FontStyle.Normal, ACCENT_RED).GetComponent<Text>();

            uiCtrl.textStatusMothership = CreateLabel(statusBar.transform, "StatMS",
                "MOTHERSHIP: Active",
                new Vector2(0.02f, 0.35f), new Vector2(0.48f, 0.58f),
                new Vector2(10, 0), Vector2.zero, 14, FontStyle.Normal, mothershipColor()).GetComponent<Text>();

            uiCtrl.textStatusWeb = CreateLabel(statusBar.transform, "StatWeb",
                "WEB: Deployed",
                new Vector2(0.52f, 0.35f), new Vector2(0.98f, 0.58f),
                new Vector2(10, 0), Vector2.zero, 14, FontStyle.Normal, ACCENT_GREEN).GetComponent<Text>();

            uiCtrl.textStatusTime = CreateLabel(statusBar.transform, "StatTime",
                "TIME: 0.0s",
                new Vector2(0.02f, 0.1f), new Vector2(0.48f, 0.33f),
                new Vector2(10, 0), Vector2.zero, 14, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();

            uiCtrl.textStatusEpisode = CreateLabel(statusBar.transform, "StatEpisode",
                "EPISODE: 0",
                new Vector2(0.52f, 0.1f), new Vector2(0.98f, 0.33f),
                new Vector2(10, 0), Vector2.zero, 14, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();
        }

        static Color mothershipColor() => new Color(0.85f, 0.85f, 1f, 1f);

        // ================================================================
        // Page 1: Environment
        // ================================================================

        static void BuildEnvironmentPage(GameObject page, TacticalUIController uiCtrl, EnvironmentController envCtrl)
        {
            page.AddComponent<Image>().color = BG_DARK;

            CreateLabel(page.transform, "Title", "ENVIRONMENT",
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(20, -10), new Vector2(-20, 25),
                22, FontStyle.Bold, ACCENT_GREEN);

            // 좌측: Sea State
            var seaPanel = CreatePanel(page.transform, "SeaPanel",
                new Vector2(0.03f, 0.08f), new Vector2(0.48f, 0.92f),
                Vector2.zero, Vector2.zero, BG_PANEL);

            CreateLabel(seaPanel.transform, "SeaTitle", "SEA STATE",
                new Vector2(0, 0.88f), new Vector2(1, 0.98f),
                new Vector2(15, 0), Vector2.zero, 18, FontStyle.Bold, ACCENT_CYAN);

            // Sea State 바 (큰 버전)
            var seaBarObj = new GameObject("SeaStateBar");
            seaBarObj.transform.SetParent(seaPanel.transform, false);
            var seaBarRt = seaBarObj.AddComponent<RectTransform>();
            seaBarRt.anchorMin = new Vector2(0.05f, 0.7f);
            seaBarRt.anchorMax = new Vector2(0.95f, 0.82f);
            seaBarRt.offsetMin = Vector2.zero;
            seaBarRt.offsetMax = Vector2.zero;
            var seaBar = seaBarObj.AddComponent<SeaStateBarUI>();
            uiCtrl.seaStateBar = seaBar;

            uiCtrl.textSeaStateLabel = CreateLabel(seaPanel.transform, "SeaValue", "Calm",
                new Vector2(0.05f, 0.58f), new Vector2(0.95f, 0.7f),
                Vector2.zero, Vector2.zero, 28, FontStyle.Bold, ACCENT_GREEN).GetComponent<Text>();

            // Sea State 세부 정보
            CreateLabel(seaPanel.transform, "WaveHdr", "Wave Parameters",
                new Vector2(0.05f, 0.45f), new Vector2(0.95f, 0.55f),
                Vector2.zero, Vector2.zero, 14, FontStyle.Bold, TEXT_DIM);

            uiCtrl.textWaveStrength = CreateLabel(seaPanel.transform, "WaveStr", "Strength: 0.0",
                new Vector2(0.08f, 0.35f), new Vector2(0.95f, 0.44f),
                Vector2.zero, Vector2.zero, 15, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();

            uiCtrl.textWaveSpeed = CreateLabel(seaPanel.transform, "WaveSpd", "Speed: 0.0",
                new Vector2(0.08f, 0.25f), new Vector2(0.95f, 0.34f),
                Vector2.zero, Vector2.zero, 15, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();

            uiCtrl.textWaveDirection = CreateLabel(seaPanel.transform, "WaveDir", "Direction: 0\u00b0",
                new Vector2(0.08f, 0.15f), new Vector2(0.95f, 0.24f),
                Vector2.zero, Vector2.zero, 15, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();

            // 우측: Wind
            var windPanel = CreatePanel(page.transform, "WindPanel",
                new Vector2(0.52f, 0.08f), new Vector2(0.97f, 0.92f),
                Vector2.zero, Vector2.zero, BG_PANEL);

            CreateLabel(windPanel.transform, "WindTitle", "WIND",
                new Vector2(0, 0.88f), new Vector2(1, 0.98f),
                new Vector2(15, 0), Vector2.zero, 18, FontStyle.Bold, ACCENT_CYAN);

            // Wind 나침반 (큰 버전)
            var compassObj = new GameObject("WindCompass");
            compassObj.transform.SetParent(windPanel.transform, false);
            var compassRt = compassObj.AddComponent<RectTransform>();
            compassRt.anchorMin = new Vector2(0.1f, 0.3f);
            compassRt.anchorMax = new Vector2(0.9f, 0.85f);
            compassRt.offsetMin = Vector2.zero;
            compassRt.offsetMax = Vector2.zero;
            var compass = compassObj.AddComponent<WindCompassUI>();
            uiCtrl.windCompass = compass;

            // 풍속/풍향 텍스트
            uiCtrl.textWindStrength = CreateLabel(windPanel.transform, "WindSpeed", "0 m/s",
                new Vector2(0.05f, 0.15f), new Vector2(0.5f, 0.28f),
                Vector2.zero, Vector2.zero, 22, FontStyle.Bold, ACCENT_CYAN).GetComponent<Text>();

            uiCtrl.textWindDirection = CreateLabel(windPanel.transform, "WindDir", "0\u00b0",
                new Vector2(0.5f, 0.15f), new Vector2(0.95f, 0.28f),
                Vector2.zero, Vector2.zero, 22, FontStyle.Bold, TEXT_BRIGHT).GetComponent<Text>();

            CreateLabel(windPanel.transform, "WindSpeedLbl", "Wind Speed",
                new Vector2(0.05f, 0.08f), new Vector2(0.5f, 0.15f),
                Vector2.zero, Vector2.zero, 12, FontStyle.Normal, TEXT_DIM);

            CreateLabel(windPanel.transform, "WindDirLbl", "Direction",
                new Vector2(0.5f, 0.08f), new Vector2(0.95f, 0.15f),
                Vector2.zero, Vector2.zero, 12, FontStyle.Normal, TEXT_DIM);
        }

        // ================================================================
        // Page 2/3: Ship Spec (3D Preview)
        // ================================================================

        static void BuildShipSpecPage(GameObject page, ShipSpecPanel spec,
            DefenseEnvController env, string title, Color accent, bool isEnemy)
        {
            page.AddComponent<Image>().color = BG_DARK;

            // 타이틀
            CreateLabel(page.transform, "Title", title,
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(30, -15), new Vector2(-30, 30),
                26, FontStyle.Bold, accent);

            // 중앙: 3D 선박 프리뷰 (RawImage + ShipPreviewRenderer)
            var previewArea = CreatePanel(page.transform, "PreviewArea",
                new Vector2(0.28f, 0.12f), new Vector2(0.72f, 0.85f),
                Vector2.zero, Vector2.zero, new Color(0.04f, 0.06f, 0.1f, 0.5f));

            var rawImgObj = new GameObject("ShipPreviewImage");
            rawImgObj.transform.SetParent(previewArea.transform, false);
            var rawRt = rawImgObj.AddComponent<RectTransform>();
            rawRt.anchorMin = new Vector2(0.02f, 0.02f);
            rawRt.anchorMax = new Vector2(0.98f, 0.98f);
            rawRt.offsetMin = Vector2.zero;
            rawRt.offsetMax = Vector2.zero;
            var rawImg = rawImgObj.AddComponent<RawImage>();
            rawImg.color = Color.white;

            var preview = previewArea.AddComponent<ShipPreviewRenderer>();
            preview.targetImage = rawImg;
            preview.envController = env;
            preview.isEnemy = isEnemy;
            spec.shipPreview = preview;

            // 실시간 정보 바
            var rtBar = CreatePanel(page.transform, "RealtimeBar",
                new Vector2(0.25f, 0.86f), new Vector2(0.75f, 0.93f),
                new Vector2(5, 2), new Vector2(-5, -2), new Color(0.05f, 0.1f, 0.15f, 0.8f));

            spec.textShipName = CreateLabel(rtBar.transform, "Name", "VESSEL",
                new Vector2(0, 0), new Vector2(0.33f, 1), new Vector2(10, 0), Vector2.zero,
                16, FontStyle.Bold, accent).GetComponent<Text>();

            spec.textCurrentSpeed = CreateLabel(rtBar.transform, "Speed", "0 kn",
                new Vector2(0.33f, 0), new Vector2(0.66f, 1), Vector2.zero, Vector2.zero,
                14, FontStyle.Normal, ACCENT_YELLOW).GetComponent<Text>();

            spec.textCurrentHeading = CreateLabel(rtBar.transform, "Heading", "0\u00b0",
                new Vector2(0.66f, 0), new Vector2(1, 1), Vector2.zero, new Vector2(-10, 0),
                14, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();

            // 왼쪽 스펙
            var leftSpec = CreatePanel(page.transform, "LeftSpec",
                new Vector2(0, 0.08f), new Vector2(0.26f, 0.83f),
                new Vector2(20, 10), new Vector2(-5, -10), new Color(0, 0, 0, 0));
            BuildLeftSliders(leftSpec.transform, spec);

            // 오른쪽 스펙
            var rightSpec = CreatePanel(page.transform, "RightSpec",
                new Vector2(0.74f, 0.08f), new Vector2(1, 0.83f),
                new Vector2(5, 10), new Vector2(-20, -10), new Color(0, 0, 0, 0));
            BuildRightSliders(rightSpec.transform, spec, accent);

            EditorUtility.SetDirty(preview);
        }

        static void BuildLeftSliders(Transform p, ShipSpecPanel s)
        {
            var (s1, t1) = MakeSlider(p, "MaxSpeed", "Max Speed(kn)",
                new Vector2(0, 0.84f), new Vector2(1, 1));
            s.sliderMaxSpeed = s1; s.textMaxSpeed = t1;

            CreateLabel(p, "FuelLbl", "Fuel", new Vector2(0, 0.76f), new Vector2(0.5f, 0.82f),
                new Vector2(5, 0), Vector2.zero, 13, FontStyle.Normal, TEXT_DIM);
            s.textFuelPercent = CreateLabel(p, "FuelVal", "100%",
                new Vector2(0.5f, 0.76f), new Vector2(1, 0.82f),
                Vector2.zero, new Vector2(-5, 0), 14, FontStyle.Bold, ACCENT_GREEN).GetComponent<Text>();

            CreateLabel(p, "EngHdr", "[ENGINE]", new Vector2(0, 0.64f), new Vector2(1, 0.72f),
                new Vector2(5, 0), Vector2.zero, 15, FontStyle.Bold, TEXT_BRIGHT);

            var (s2, t2) = MakeSlider(p, "MinRPM", "Min RPM",
                new Vector2(0, 0.46f), new Vector2(1, 0.62f));
            s.sliderMinRPM = s2; s.textMinRPM = t2;

            var (s3, t3) = MakeSlider(p, "MaxRPM", "Max RPM",
                new Vector2(0, 0.28f), new Vector2(1, 0.44f));
            s.sliderMaxRPM = s3; s.textMaxRPM = t3;

            var (s4, t4) = MakeSlider(p, "MaxThrust", "Max Thruster",
                new Vector2(0, 0.1f), new Vector2(1, 0.26f));
            s.sliderMaxThrust = s4; s.textMaxThrust = t4;
        }

        static void BuildRightSliders(Transform p, ShipSpecPanel s, Color accent)
        {
            CreateLabel(p, "RudHdr", "[RUDDER]", new Vector2(0, 0.88f), new Vector2(1, 0.98f),
                new Vector2(5, 0), Vector2.zero, 15, FontStyle.Bold, TEXT_BRIGHT);

            var (s1, t1) = MakeSlider(p, "MaxAngle", "Max Angle",
                new Vector2(0, 0.7f), new Vector2(1, 0.86f));
            s.sliderMaxAngle = s1; s.textMaxAngle = t1;

            var (s2, t2) = MakeSlider(p, "AngSpeed", "Angle Speed",
                new Vector2(0, 0.52f), new Vector2(1, 0.68f));
            s.sliderAngleSpeed = s2; s.textAngleSpeed = t2;

            CreateLabel(p, "MissLbl", "\u25C6 Missile",
                new Vector2(0, 0.36f), new Vector2(0.6f, 0.46f),
                new Vector2(5, 0), Vector2.zero, 14, FontStyle.Normal, accent);
            s.textMissileCount = CreateLabel(p, "MissVal", "0",
                new Vector2(0.6f, 0.36f), new Vector2(1, 0.46f),
                Vector2.zero, new Vector2(-5, 0), 16, FontStyle.Bold, ACCENT_YELLOW).GetComponent<Text>();

            CreateLabel(p, "BulLbl", "\u25C6 Bullet",
                new Vector2(0, 0.22f), new Vector2(0.6f, 0.32f),
                new Vector2(5, 0), Vector2.zero, 14, FontStyle.Normal, accent);
            s.textBulletCount = CreateLabel(p, "BulVal", "0",
                new Vector2(0.6f, 0.22f), new Vector2(1, 0.32f),
                Vector2.zero, new Vector2(-5, 0), 16, FontStyle.Bold, ACCENT_YELLOW).GetComponent<Text>();
        }

        // ================================================================
        // Indicator Bar + Nav Buttons
        // ================================================================

        static GameObject CreateIndicatorBar(Transform root, TacticalPageManager pm)
        {
            var bar = CreatePanel(root, "PageIndicator",
                new Vector2(0, 0), new Vector2(1, 0),
                new Vector2(0, 0), new Vector2(0, 45), new Color(0.04f, 0.04f, 0.08f, 0.9f));

            pm.btnPrev = MakeNavBtn(bar.transform, "BtnPrev", "<",
                new Vector2(0, 0), new Vector2(0.06f, 1));

            pm.textPageIndicator = CreateLabel(bar.transform, "PageNum", "1/4",
                new Vector2(0.07f, 0), new Vector2(0.18f, 1), new Vector2(10, 0), Vector2.zero,
                16, FontStyle.Bold, ACCENT_GREEN).GetComponent<Text>();

            pm.textPageName = CreateLabel(bar.transform, "PageName", "RADAR",
                new Vector2(0.18f, 0), new Vector2(0.7f, 1), new Vector2(10, 0), Vector2.zero,
                14, FontStyle.Normal, TEXT_BRIGHT).GetComponent<Text>();

            CreateLabel(bar.transform, "Hint", "[Tab] Page  [Enter] Game Mode",
                new Vector2(0.7f, 0), new Vector2(0.93f, 1), Vector2.zero, Vector2.zero,
                10, FontStyle.Normal, TEXT_DIM);

            pm.btnNext = MakeNavBtn(bar.transform, "BtnNext", ">",
                new Vector2(0.94f, 0), new Vector2(1, 1));

            return bar;
        }

        static Button MakeNavBtn(Transform parent, string name, string label,
            Vector2 anchorMin, Vector2 anchorMax)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = anchorMin;
            rt.anchorMax = anchorMax;
            rt.offsetMin = new Vector2(2, 2);
            rt.offsetMax = new Vector2(-2, -2);

            var img = obj.AddComponent<Image>();
            img.color = new Color(0.15f, 0.2f, 0.3f, 1f);

            var btn = obj.AddComponent<Button>();
            var c = btn.colors;
            c.highlightedColor = new Color(0.25f, 0.35f, 0.5f, 1f);
            c.pressedColor = new Color(0.1f, 0.15f, 0.2f, 1f);
            btn.colors = c;

            var txt = CreateLabel(obj.transform, "Text", label,
                Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero,
                20, FontStyle.Bold, Color.white);
            txt.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

            return btn;
        }

        // ================================================================
        // Game Mode: Mini Radar Overlay
        // ================================================================

        static GameObject BuildMiniRadarOverlay(Transform canvasRoot, DefenseEnvController env)
        {
            // 왼쪽 상단 소형 레이더
            var overlay = new GameObject("RadarOverlay");
            overlay.transform.SetParent(canvasRoot, false);
            var rt = overlay.AddComponent<RectTransform>();
            rt.anchorMin = new Vector2(0, 1);
            rt.anchorMax = new Vector2(0, 1);
            rt.pivot = new Vector2(0, 1);
            // 좌상단 기준 10px 여백, 180x200 크기
            rt.offsetMin = new Vector2(0, -400);
            rt.offsetMax = new Vector2(360, 0);

            // 반투명 배경
            var bgImg = overlay.AddComponent<Image>();
            bgImg.color = new Color(0.03f, 0.06f, 0.03f, 0.75f);
            bgImg.raycastTarget = false;

            // 타이틀 바
            CreateLabel(overlay.transform, "OverlayTitle", "RADAR",
                new Vector2(0, 0.9f), new Vector2(1, 1),
                new Vector2(6, 0), Vector2.zero,
                10, FontStyle.Bold, ACCENT_GREEN);

            // 미니 레이더 (정사각형 영역)
            var radarObj = new GameObject("MiniRadar");
            radarObj.transform.SetParent(overlay.transform, false);
            var radarRt = radarObj.AddComponent<RectTransform>();
            radarRt.anchorMin = new Vector2(0.05f, 0.08f);
            radarRt.anchorMax = new Vector2(0.95f, 0.88f);
            radarRt.offsetMin = Vector2.zero;
            radarRt.offsetMax = Vector2.zero;

            var radar = radarObj.AddComponent<RadarDisplay>();
            radar.envController = env;
            radar.radarRange = 1000f;

            // 하단 힌트
            CreateLabel(overlay.transform, "OverlayHint", "[Enter] UI",
                new Vector2(0, 0), new Vector2(1, 0.08f),
                Vector2.zero, Vector2.zero,
                8, FontStyle.Normal, TEXT_DIM).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

            return overlay;
        }

        // ================================================================
        // UI Helper Methods
        // ================================================================

        static GameObject CreateFullscreenPage(Transform parent, string name)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = new Vector2(0, -45);
            return obj;
        }

        static GameObject CreatePanel(Transform parent, string name,
            Vector2 aMin, Vector2 aMax, Vector2 oMin, Vector2 oMax, Color col)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = aMin; rt.anchorMax = aMax;
            rt.offsetMin = oMin; rt.offsetMax = oMax;
            var img = obj.AddComponent<Image>();
            img.color = col;
            img.raycastTarget = col.a > 0.01f;
            return obj;
        }

        static GameObject CreateLabel(Transform parent, string name, string text,
            Vector2 aMin, Vector2 aMax, Vector2 oMin, Vector2 oMax,
            int size, FontStyle style, Color col)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = aMin; rt.anchorMax = aMax;
            rt.offsetMin = oMin; rt.offsetMax = oMax;
            var txt = obj.AddComponent<Text>();
            txt.text = text; txt.fontSize = size;
            txt.fontStyle = style; txt.color = col;
            txt.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            txt.alignment = TextAnchor.MiddleLeft;
            txt.raycastTarget = false;
            txt.horizontalOverflow = HorizontalWrapMode.Overflow;
            return obj;
        }

        static Button CreateBtn(Transform parent, string name, string label,
            Vector2 aMin, Vector2 aMax, Color bg)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);
            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = aMin; rt.anchorMax = aMax;
            rt.offsetMin = new Vector2(2, 2); rt.offsetMax = new Vector2(-2, -2);
            var img = obj.AddComponent<Image>();
            img.color = bg;
            var btn = obj.AddComponent<Button>();
            var c = btn.colors; c.normalColor = bg;
            c.highlightedColor = bg * 1.3f; c.pressedColor = bg * 0.7f;
            btn.colors = c;
            var t = CreateLabel(obj.transform, "Text", label,
                Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero,
                13, FontStyle.Bold, Color.white);
            t.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            return btn;
        }

        static (Slider slider, Text valueText) MakeSlider(Transform parent,
            string name, string label, Vector2 aMin, Vector2 aMax)
        {
            var container = new GameObject($"Slider_{name}");
            container.transform.SetParent(parent, false);
            var cRt = container.AddComponent<RectTransform>();
            cRt.anchorMin = aMin; cRt.anchorMax = aMax;
            cRt.offsetMin = new Vector2(5, 0); cRt.offsetMax = new Vector2(-5, 0);

            CreateLabel(container.transform, "Lbl", label,
                new Vector2(0, 0.5f), new Vector2(0.75f, 1),
                new Vector2(2, 0), Vector2.zero, 12, FontStyle.Normal, TEXT_DIM);

            var valObj = CreateLabel(container.transform, "Val", "0",
                new Vector2(0.75f, 0.5f), new Vector2(1, 1),
                Vector2.zero, new Vector2(-2, 0), 13, FontStyle.Bold, ACCENT_YELLOW);
            valObj.GetComponent<Text>().alignment = TextAnchor.MiddleRight;

            var slObj = new GameObject("Slider");
            slObj.transform.SetParent(container.transform, false);
            var slRt = slObj.AddComponent<RectTransform>();
            slRt.anchorMin = new Vector2(0, 0);
            slRt.anchorMax = new Vector2(1, 0.5f);
            slRt.offsetMin = new Vector2(2, 2); slRt.offsetMax = new Vector2(-2, -2);

            // Background
            var bgObj = new GameObject("Background");
            bgObj.transform.SetParent(slObj.transform, false);
            var bgRt = bgObj.AddComponent<RectTransform>();
            bgRt.anchorMin = new Vector2(0, 0.3f); bgRt.anchorMax = new Vector2(1, 0.7f);
            bgRt.offsetMin = Vector2.zero; bgRt.offsetMax = Vector2.zero;
            bgObj.AddComponent<Image>().color = SLIDER_BG;

            // Fill Area
            var fillArea = new GameObject("Fill Area");
            fillArea.transform.SetParent(slObj.transform, false);
            var faRt = fillArea.AddComponent<RectTransform>();
            faRt.anchorMin = new Vector2(0, 0.3f); faRt.anchorMax = new Vector2(1, 0.7f);
            faRt.offsetMin = Vector2.zero; faRt.offsetMax = Vector2.zero;

            var fillObj = new GameObject("Fill");
            fillObj.transform.SetParent(fillArea.transform, false);
            var fRt = fillObj.AddComponent<RectTransform>();
            fRt.anchorMin = new Vector2(0, 0); fRt.anchorMax = new Vector2(0, 1);
            fRt.offsetMin = Vector2.zero; fRt.offsetMax = Vector2.zero;
            fillObj.AddComponent<Image>().color = SLIDER_FILL;

            // Handle Area
            var handleArea = new GameObject("Handle Slide Area");
            handleArea.transform.SetParent(slObj.transform, false);
            var haRt = handleArea.AddComponent<RectTransform>();
            haRt.anchorMin = Vector2.zero; haRt.anchorMax = Vector2.one;
            haRt.offsetMin = new Vector2(5, 0); haRt.offsetMax = new Vector2(-5, 0);

            var handleObj = new GameObject("Handle");
            handleObj.transform.SetParent(handleArea.transform, false);
            var hRt = handleObj.AddComponent<RectTransform>();
            hRt.anchorMin = new Vector2(0, 0); hRt.anchorMax = new Vector2(0, 1);
            hRt.pivot = new Vector2(0.5f, 0.5f);
            hRt.sizeDelta = new Vector2(14, 0);
            var hImg = handleObj.AddComponent<Image>();
            hImg.color = HANDLE_COLOR;

            var slider = slObj.AddComponent<Slider>();
            slider.fillRect = fRt;
            slider.handleRect = hRt;
            slider.targetGraphic = hImg;
            slider.direction = Slider.Direction.LeftToRight;

            return (slider, valObj.GetComponent<Text>());
        }
    }
}
