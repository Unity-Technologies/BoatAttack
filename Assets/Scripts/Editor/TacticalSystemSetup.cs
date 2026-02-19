using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack
{
    /// <summary>
    /// 전술 시스템 자동 세팅 에디터 스크립트 (v3 - 선박 그래픽 + 네비 버튼)
    /// 메뉴: BoatAttack > Setup Tactical System
    /// Page 0: Tactical Command (레이더 + 모드 + 슬라이더)
    /// Page 1: Friendly Ship Spec (아군 선박 재원 + 선박 실루엣)
    /// Page 2: Enemy Ship Spec (적군 선박 재원 + 선박 실루엣)
    /// </summary>
    public static class TacticalSystemSetup
    {
        // 공통 색상
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
                    "DefenseEnvController를 씬에서 찾을 수 없습니다.\nROONSHOOT 씬을 열어주세요.", "OK");
                return;
            }
            var envCtrl = Object.FindObjectOfType<EnvironmentController>();

            SetupTacticalNetwork(env);
            SetupFullUI(env, envCtrl);

            EditorUtility.DisplayDialog("Setup Complete",
                "전술 시스템 세팅 완료!\n\n" +
                "- TacticalSystem (네트워크)\n" +
                "- TacticalUI Canvas (3페이지)\n" +
                "  Page 1: Tactical Command\n" +
                "  Page 2: Friendly Ship Spec\n" +
                "  Page 3: Enemy Ship Spec\n\n" +
                "Tab/Enter 키 또는 < > 버튼으로 페이지 전환\n" +
                "Ctrl+S로 씬 저장하세요.", "OK");
        }

        [MenuItem("BoatAttack/Remove Tactical UI", false, 110)]
        public static void RemoveTacticalUI()
        {
            var existing = Object.FindObjectOfType<TacticalPageManager>();
            if (existing != null)
            {
                Undo.DestroyObjectImmediate(existing.gameObject);
                Debug.Log("[TacticalSetup] 기존 TacticalUI 제거됨");
            }
            var existingSystem = Object.FindObjectOfType<TacticalClient>();
            if (existingSystem != null)
            {
                Undo.DestroyObjectImmediate(existingSystem.gameObject);
                Debug.Log("[TacticalSetup] 기존 TacticalSystem 제거됨");
            }
        }

        // ================================================================
        // Network
        // ================================================================

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
        // Full UI (3 pages)
        // ================================================================

        static void SetupFullUI(DefenseEnvController env, EnvironmentController envCtrl)
        {
            // 기존 UI 제거
            var existing = Object.FindObjectOfType<TacticalPageManager>();
            if (existing != null)
                Undo.DestroyObjectImmediate(existing.gameObject);

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

            // EventSystem
            if (Object.FindObjectOfType<UnityEngine.EventSystems.EventSystem>() == null)
            {
                var esObj = new GameObject("EventSystem");
                esObj.AddComponent<UnityEngine.EventSystems.EventSystem>();
                esObj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
                Undo.RegisterCreatedObjectUndo(esObj, "Create EventSystem");
            }

            // PageManager
            var pageManager = canvasObj.AddComponent<TacticalPageManager>();

            // --- Page 0: Tactical Command ---
            var page0 = CreateFullscreenPage(canvasObj.transform, "Page_TacticalCommand");
            var uiCtrl = page0.AddComponent<TacticalUIController>();
            uiCtrl.envController = env;
            uiCtrl.environmentController = envCtrl;
            BuildTacticalCommandPage(page0, uiCtrl, env);

            // --- Page 1: Friendly Ship Spec ---
            var page1 = CreateFullscreenPage(canvasObj.transform, "Page_FriendlySpec");
            var friendlySpec = page1.AddComponent<ShipSpecPanel>();
            friendlySpec.envController = env;
            friendlySpec.isEnemy = false;
            BuildShipSpecPage(page1, friendlySpec, "FRIENDLY SHIP PARAMETER", ACCENT_CYAN, false);

            // --- Page 2: Enemy Ship Spec ---
            var page2 = CreateFullscreenPage(canvasObj.transform, "Page_EnemySpec");
            var enemySpec = page2.AddComponent<ShipSpecPanel>();
            enemySpec.envController = env;
            enemySpec.isEnemy = true;
            BuildShipSpecPage(page2, enemySpec, "ENEMY SHIP PARAMETER", ACCENT_RED, true);

            // PageManager 설정
            pageManager.pages = new[] { page0, page1, page2 };
            pageManager.pageNames = new[] { "TACTICAL COMMAND", "FRIENDLY SHIP SPEC", "ENEMY SHIP SPEC" };

            // 하단 페이지 인디케이터 + 네비게이션 버튼 (Canvas 직속, 항상 표시)
            CreateIndicatorBar(canvasObj.transform, pageManager);

            // ★ 중요: 모든 컴포넌트 명시적 SetDirty (직렬화 보장)
            EditorUtility.SetDirty(pageManager);
            EditorUtility.SetDirty(uiCtrl);
            EditorUtility.SetDirty(friendlySpec);
            EditorUtility.SetDirty(enemySpec);
            EditorUtility.SetDirty(canvasObj);

            Debug.Log("[TacticalSetup] UI 생성 완료 - pages: " + pageManager.pages.Length);
        }

        // ================================================================
        // Page 0: Tactical Command
        // ================================================================

        static void BuildTacticalCommandPage(GameObject page, TacticalUIController uiCtrl, DefenseEnvController env)
        {
            // 왼쪽 패널 (anchor 0~0.45)
            var leftPanel = CreateAnchoredPanel(page.transform, "LeftPanel",
                new Vector2(0, 0), new Vector2(0.42f, 1),
                new Vector2(15, 15), new Vector2(-15, -50), BG_PANEL);

            // 타이틀
            CreateAnchoredLabel(leftPanel.transform, "Title", "TACTICAL COMMAND",
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(15, -15), new Vector2(-15, -15 + 35),
                20, FontStyle.Bold, ACCENT_GREEN);

            // 레이더 영역
            var radarBg = CreateAnchoredPanel(leftPanel.transform, "RadarBg",
                new Vector2(0.05f, 0.35f), new Vector2(0.95f, 0.9f),
                Vector2.zero, Vector2.zero, new Color(0.03f, 0.06f, 0.03f, 0.95f));

            var radarArea = CreateAnchoredImage(radarBg.transform, "RadarArea",
                new Vector2(0.1f, 0.05f), new Vector2(0.9f, 0.95f),
                Vector2.zero, Vector2.zero, new Color(0.02f, 0.04f, 0.02f, 1f));

            var radarDisplay = radarBg.AddComponent<RadarDisplay>();
            radarDisplay.envController = env;
            radarDisplay.radarRect = radarArea.GetComponent<RectTransform>();
            uiCtrl.radarDisplay = radarDisplay;

            // 하단 컨트롤 영역
            var controlArea = CreateAnchoredPanel(leftPanel.transform, "Controls",
                new Vector2(0, 0), new Vector2(1, 0.33f),
                new Vector2(10, 10), new Vector2(-10, -5), new Color(0, 0, 0, 0));

            // 공격 모드 버튼
            var btnRow = CreateAnchoredPanel(controlArea.transform, "BtnRow",
                new Vector2(0, 0.7f), new Vector2(1, 1),
                new Vector2(5, 0), new Vector2(-5, 0), new Color(0, 0, 0, 0));

            var btnW = CreateAnchoredButton(btnRow.transform, "BtnWave", "파상공격",
                new Vector2(0, 0), new Vector2(0.32f, 1), new Color(0.15f, 0.45f, 0.15f, 1f));
            var btnD = CreateAnchoredButton(btnRow.transform, "BtnDiv", "양동작전",
                new Vector2(0.34f, 0), new Vector2(0.66f, 1), new Color(0.25f, 0.25f, 0.3f, 1f));
            var btnC = CreateAnchoredButton(btnRow.transform, "BtnConc", "집중공격",
                new Vector2(0.68f, 0), new Vector2(1, 1), new Color(0.25f, 0.25f, 0.3f, 1f));

            uiCtrl.btnWaveAttack = btnW.GetComponent<Button>();
            uiCtrl.btnDiversionary = btnD.GetComponent<Button>();
            uiCtrl.btnConcentrated = btnC.GetComponent<Button>();

            // 슬라이더들
            var sliderArea = CreateAnchoredPanel(controlArea.transform, "Sliders",
                new Vector2(0, 0), new Vector2(1, 0.68f),
                new Vector2(5, 5), new Vector2(-5, -5), new Color(0, 0, 0, 0));

            var (sl1, tx1) = CreateResponsiveSlider(sliderArea.transform, "EnemyCount", "적군 수",
                new Vector2(0, 0.66f), new Vector2(1, 1));
            uiCtrl.sliderEnemyCount = sl1; uiCtrl.textEnemyCount = tx1;

            var (sl2, tx2) = CreateResponsiveSlider(sliderArea.transform, "MSHits", "모선 피격",
                new Vector2(0, 0.33f), new Vector2(1, 0.64f));
            uiCtrl.sliderMothershipHits = sl2; uiCtrl.textMothershipHits = tx2;

            var (sl3, tx3) = CreateResponsiveSlider(sliderArea.transform, "SimSpeed", "시뮬레이션",
                new Vector2(0, 0), new Vector2(1, 0.31f));
            uiCtrl.sliderSimSpeed = sl3; uiCtrl.textSimSpeed = tx3;

            // 오른쪽 패널 (anchor 0.45~1)
            var rightPanel = CreateAnchoredPanel(page.transform, "RightPanel",
                new Vector2(0.44f, 0), new Vector2(1, 1),
                new Vector2(15, 15), new Vector2(-15, -50), BG_PANEL);

            CreateAnchoredLabel(rightPanel.transform, "RightTitle", "SHIP & ENVIRONMENT",
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(15, -15), new Vector2(-15, -15 + 30),
                18, FontStyle.Bold, ACCENT_GREEN);

            var rightSliders = CreateAnchoredPanel(rightPanel.transform, "RightSliders",
                new Vector2(0, 0.15f), new Vector2(1, 0.92f),
                new Vector2(10, 5), new Vector2(-10, -5), new Color(0, 0, 0, 0));

            var (sl4, tx4) = CreateResponsiveSlider(rightSliders.transform, "FriendlySpeed", "아군 속도(HP)",
                new Vector2(0, 0.82f), new Vector2(1, 1));
            uiCtrl.sliderFriendlySpeed = sl4; uiCtrl.textFriendlySpeed = tx4;

            var (sl5, tx5) = CreateResponsiveSlider(rightSliders.transform, "EnemySpeed", "적군 속도(HP)",
                new Vector2(0, 0.64f), new Vector2(1, 0.8f));
            uiCtrl.sliderEnemySpeed = sl5; uiCtrl.textEnemySpeed = tx5;

            var (sl6, tx6) = CreateResponsiveSlider(rightSliders.transform, "FriendlyAngular", "아군 선회력",
                new Vector2(0, 0.46f), new Vector2(1, 0.62f));
            uiCtrl.sliderFriendlyAngularSpeed = sl6; uiCtrl.textFriendlyAngularSpeed = tx6;

            var (sl7, tx7) = CreateResponsiveSlider(rightSliders.transform, "EnemyAngular", "적군 선회력",
                new Vector2(0, 0.28f), new Vector2(1, 0.44f));
            uiCtrl.sliderEnemyAngularSpeed = sl7; uiCtrl.textEnemyAngularSpeed = tx7;

            // 환경 정보
            var envInfo = CreateAnchoredPanel(rightPanel.transform, "EnvInfo",
                new Vector2(0, 0), new Vector2(1, 0.14f),
                new Vector2(15, 10), new Vector2(-15, -5), new Color(0, 0, 0, 0));

            var seaText = CreateAnchoredLabel(envInfo.transform, "SeaState", "Sea: Calm",
                new Vector2(0, 0.5f), new Vector2(1, 1), Vector2.zero, Vector2.zero,
                13, FontStyle.Normal, ACCENT_CYAN);
            uiCtrl.textSeaState = seaText.GetComponent<Text>();

            var windText = CreateAnchoredLabel(envInfo.transform, "WindState", "Wind: 5m/s",
                new Vector2(0, 0), new Vector2(1, 0.5f), Vector2.zero, Vector2.zero,
                13, FontStyle.Normal, ACCENT_CYAN);
            uiCtrl.textWindState = windText.GetComponent<Text>();
        }

        // ================================================================
        // Page 1/2: Ship Spec (with ship graphic)
        // ================================================================

        static void BuildShipSpecPage(GameObject page, ShipSpecPanel spec, string title, Color accentColor, bool isEnemy)
        {
            // 배경
            var bg = page.AddComponent<Image>();
            bg.color = BG_DARK;
            bg.raycastTarget = true;

            // 타이틀
            CreateAnchoredLabel(page.transform, "Title", title,
                new Vector2(0, 1), new Vector2(1, 1), new Vector2(30, -15), new Vector2(-30, -15 + 45),
                26, FontStyle.Bold, accentColor);

            // 선박 이미지 영역 (중앙) - 선박 실루엣 그래픽 포함
            var shipImgArea = CreateAnchoredPanel(page.transform, "ShipImageArea",
                new Vector2(0.3f, 0.15f), new Vector2(0.7f, 0.85f),
                Vector2.zero, Vector2.zero, new Color(0.04f, 0.06f, 0.1f, 0.5f));

            // ★ 프로시저럴 선박 실루엣
            var shipGraphicObj = new GameObject("ShipGraphic");
            shipGraphicObj.transform.SetParent(shipImgArea.transform, false);
            var shipGraphicRt = shipGraphicObj.AddComponent<RectTransform>();
            shipGraphicRt.anchorMin = new Vector2(0.1f, 0.05f);
            shipGraphicRt.anchorMax = new Vector2(0.9f, 0.95f);
            shipGraphicRt.offsetMin = Vector2.zero;
            shipGraphicRt.offsetMax = Vector2.zero;

            var shipGraphic = shipGraphicObj.AddComponent<ShipGraphicUI>();
            shipGraphic.raycastTarget = false;
            if (isEnemy)
                shipGraphic.ApplyEnemyStyle();
            else
                shipGraphic.ApplyFriendlyStyle();

            // 실시간 정보 (선박 이미지 위)
            var realtimeBar = CreateAnchoredPanel(page.transform, "RealtimeBar",
                new Vector2(0.25f, 0.86f), new Vector2(0.75f, 0.93f),
                new Vector2(5, 2), new Vector2(-5, -2), new Color(0.05f, 0.1f, 0.15f, 0.8f));

            var nameText = CreateAnchoredLabel(realtimeBar.transform, "ShipName", "VESSEL",
                new Vector2(0, 0), new Vector2(0.33f, 1), new Vector2(10, 0), Vector2.zero,
                16, FontStyle.Bold, accentColor);
            spec.textShipName = nameText.GetComponent<Text>();

            var speedText = CreateAnchoredLabel(realtimeBar.transform, "Speed", "0 kn",
                new Vector2(0.33f, 0), new Vector2(0.66f, 1), Vector2.zero, Vector2.zero,
                14, FontStyle.Normal, ACCENT_YELLOW);
            spec.textCurrentSpeed = speedText.GetComponent<Text>();

            var headingText = CreateAnchoredLabel(realtimeBar.transform, "Heading", "0\u00b0",
                new Vector2(0.66f, 0), new Vector2(1, 1), Vector2.zero, new Vector2(-10, 0),
                14, FontStyle.Normal, TEXT_BRIGHT);
            spec.textCurrentHeading = headingText.GetComponent<Text>();

            // 왼쪽 스펙 (anchor 0~0.28)
            var leftSpec = CreateAnchoredPanel(page.transform, "LeftSpec",
                new Vector2(0, 0.08f), new Vector2(0.28f, 0.83f),
                new Vector2(20, 10), new Vector2(-5, -10), new Color(0, 0, 0, 0));

            BuildSpecSliders_Left(leftSpec.transform, spec);

            // 오른쪽 스펙 (anchor 0.72~1)
            var rightSpec = CreateAnchoredPanel(page.transform, "RightSpec",
                new Vector2(0.72f, 0.08f), new Vector2(1, 0.83f),
                new Vector2(5, 10), new Vector2(-20, -10), new Color(0, 0, 0, 0));

            BuildSpecSliders_Right(rightSpec.transform, spec, accentColor);
        }

        static void BuildSpecSliders_Left(Transform parent, ShipSpecPanel spec)
        {
            // Max Speed
            var (s1, t1) = CreateResponsiveSlider(parent, "MaxSpeed", "Max Speed(kn)",
                new Vector2(0, 0.84f), new Vector2(1, 1));
            spec.sliderMaxSpeed = s1; spec.textMaxSpeed = t1;

            // Fuel
            CreateAnchoredLabel(parent, "FuelLabel", "Fuel",
                new Vector2(0, 0.76f), new Vector2(0.5f, 0.82f), new Vector2(5, 0), Vector2.zero,
                13, FontStyle.Normal, TEXT_DIM);
            var fuelText = CreateAnchoredLabel(parent, "FuelValue", "100%",
                new Vector2(0.5f, 0.76f), new Vector2(1, 0.82f), Vector2.zero, new Vector2(-5, 0),
                14, FontStyle.Bold, ACCENT_GREEN);
            spec.textFuelPercent = fuelText.GetComponent<Text>();

            // Engine 헤더
            CreateAnchoredLabel(parent, "EngineHeader", "[ENGINE]",
                new Vector2(0, 0.64f), new Vector2(1, 0.72f), new Vector2(5, 0), Vector2.zero,
                15, FontStyle.Bold, TEXT_BRIGHT);

            // Min RPM
            var (s2, t2) = CreateResponsiveSlider(parent, "MinRPM", "Min RPM",
                new Vector2(0, 0.46f), new Vector2(1, 0.62f));
            spec.sliderMinRPM = s2; spec.textMinRPM = t2;

            // Max RPM
            var (s3, t3) = CreateResponsiveSlider(parent, "MaxRPM", "Max RPM",
                new Vector2(0, 0.28f), new Vector2(1, 0.44f));
            spec.sliderMaxRPM = s3; spec.textMaxRPM = t3;

            // Max Thruster
            var (s4, t4) = CreateResponsiveSlider(parent, "MaxThrust", "Max Thruster",
                new Vector2(0, 0.1f), new Vector2(1, 0.26f));
            spec.sliderMaxThrust = s4; spec.textMaxThrust = t4;
        }

        static void BuildSpecSliders_Right(Transform parent, ShipSpecPanel spec, Color accent)
        {
            // Rudder 헤더
            CreateAnchoredLabel(parent, "RudderHeader", "[RUDDER]",
                new Vector2(0, 0.88f), new Vector2(1, 0.98f), new Vector2(5, 0), Vector2.zero,
                15, FontStyle.Bold, TEXT_BRIGHT);

            // Max Angle
            var (s1, t1) = CreateResponsiveSlider(parent, "MaxAngle", "Max Angle",
                new Vector2(0, 0.7f), new Vector2(1, 0.86f));
            spec.sliderMaxAngle = s1; spec.textMaxAngle = t1;

            // Angle Speed
            var (s2, t2) = CreateResponsiveSlider(parent, "AngleSpeed", "Angle Speed",
                new Vector2(0, 0.52f), new Vector2(1, 0.68f));
            spec.sliderAngleSpeed = s2; spec.textAngleSpeed = t2;

            // Missile
            CreateAnchoredLabel(parent, "MissileIcon", "\u25C6 Missile",
                new Vector2(0, 0.36f), new Vector2(0.6f, 0.46f), new Vector2(5, 0), Vector2.zero,
                14, FontStyle.Normal, accent);
            var missileText = CreateAnchoredLabel(parent, "MissileVal", "0",
                new Vector2(0.6f, 0.36f), new Vector2(1, 0.46f), Vector2.zero, new Vector2(-5, 0),
                16, FontStyle.Bold, ACCENT_YELLOW);
            spec.textMissileCount = missileText.GetComponent<Text>();

            // Bullet
            CreateAnchoredLabel(parent, "BulletIcon", "\u25C6 Bullet",
                new Vector2(0, 0.22f), new Vector2(0.6f, 0.32f), new Vector2(5, 0), Vector2.zero,
                14, FontStyle.Normal, accent);
            var bulletText = CreateAnchoredLabel(parent, "BulletVal", "0",
                new Vector2(0.6f, 0.22f), new Vector2(1, 0.32f), Vector2.zero, new Vector2(-5, 0),
                16, FontStyle.Bold, ACCENT_YELLOW);
            spec.textBulletCount = bulletText.GetComponent<Text>();
        }

        // ================================================================
        // Page Indicator Bar + Navigation Buttons (항상 표시)
        // ================================================================

        static void CreateIndicatorBar(Transform canvasRoot, TacticalPageManager pm)
        {
            var bar = CreateAnchoredPanel(canvasRoot, "PageIndicator",
                new Vector2(0, 0), new Vector2(1, 0),
                new Vector2(0, 0), new Vector2(0, 45), new Color(0.04f, 0.04f, 0.08f, 0.9f));

            // 이전 버튼 [<]
            var btnPrevObj = CreateAnchoredButton(bar.transform, "BtnPrev", "<",
                new Vector2(0, 0), new Vector2(0.06f, 1),
                new Color(0.15f, 0.2f, 0.3f, 1f));
            btnPrevObj.GetComponentInChildren<Text>().fontSize = 20;
            pm.btnPrev = btnPrevObj.GetComponent<Button>();

            // 페이지 번호
            var pageNum = CreateAnchoredLabel(bar.transform, "PageNum", "1/3",
                new Vector2(0.07f, 0), new Vector2(0.18f, 1), new Vector2(10, 0), Vector2.zero,
                16, FontStyle.Bold, ACCENT_GREEN);
            pm.textPageIndicator = pageNum.GetComponent<Text>();

            // 페이지 이름
            var pageName = CreateAnchoredLabel(bar.transform, "PageName", "TACTICAL COMMAND",
                new Vector2(0.18f, 0), new Vector2(0.7f, 1), new Vector2(10, 0), Vector2.zero,
                14, FontStyle.Normal, TEXT_BRIGHT);
            pm.textPageName = pageName.GetComponent<Text>();

            // 힌트
            CreateAnchoredLabel(bar.transform, "Hint", "[Tab] / [Enter] Page Switch",
                new Vector2(0.7f, 0), new Vector2(0.93f, 1), Vector2.zero, Vector2.zero,
                11, FontStyle.Normal, TEXT_DIM);

            // 다음 버튼 [>]
            var btnNextObj = CreateAnchoredButton(bar.transform, "BtnNext", ">",
                new Vector2(0.94f, 0), new Vector2(1, 1),
                new Color(0.15f, 0.2f, 0.3f, 1f));
            btnNextObj.GetComponentInChildren<Text>().fontSize = 20;
            pm.btnNext = btnNextObj.GetComponent<Button>();
        }

        // ================================================================
        // Responsive UI Helpers (Anchor 기반)
        // ================================================================

        static GameObject CreateFullscreenPage(Transform parent, string name)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);

            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = new Vector2(0, -45); // 하단 인디케이터 바 여유

            return obj;
        }

        static GameObject CreateAnchoredPanel(Transform parent, string name,
            Vector2 anchorMin, Vector2 anchorMax,
            Vector2 offsetMin, Vector2 offsetMax, Color color)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);

            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = anchorMin;
            rt.anchorMax = anchorMax;
            rt.offsetMin = offsetMin;
            rt.offsetMax = offsetMax;

            var img = obj.AddComponent<Image>();
            img.color = color;
            img.raycastTarget = (color.a > 0.01f);

            return obj;
        }

        static GameObject CreateAnchoredImage(Transform parent, string name,
            Vector2 anchorMin, Vector2 anchorMax,
            Vector2 offsetMin, Vector2 offsetMax, Color color)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);

            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = anchorMin;
            rt.anchorMax = anchorMax;
            rt.offsetMin = offsetMin;
            rt.offsetMax = offsetMax;

            var img = obj.AddComponent<Image>();
            img.color = color;
            img.raycastTarget = false;

            return obj;
        }

        static GameObject CreateAnchoredLabel(Transform parent, string name, string text,
            Vector2 anchorMin, Vector2 anchorMax,
            Vector2 offsetMin, Vector2 offsetMax,
            int fontSize, FontStyle style, Color color)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);

            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = anchorMin;
            rt.anchorMax = anchorMax;
            rt.offsetMin = offsetMin;
            rt.offsetMax = offsetMax;

            var txt = obj.AddComponent<Text>();
            txt.text = text;
            txt.fontSize = fontSize;
            txt.fontStyle = style;
            txt.color = color;
            txt.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            txt.alignment = TextAnchor.MiddleLeft;
            txt.raycastTarget = false;
            txt.horizontalOverflow = HorizontalWrapMode.Overflow;

            return obj;
        }

        static GameObject CreateAnchoredButton(Transform parent, string name, string label,
            Vector2 anchorMin, Vector2 anchorMax, Color bgColor)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent, false);

            var rt = obj.AddComponent<RectTransform>();
            rt.anchorMin = anchorMin;
            rt.anchorMax = anchorMax;
            rt.offsetMin = new Vector2(2, 2);
            rt.offsetMax = new Vector2(-2, -2);

            var img = obj.AddComponent<Image>();
            img.color = bgColor;

            var btn = obj.AddComponent<Button>();
            var colors = btn.colors;
            colors.normalColor = bgColor;
            colors.highlightedColor = bgColor * 1.3f;
            colors.pressedColor = bgColor * 0.7f;
            btn.colors = colors;

            var textObj = CreateAnchoredLabel(obj.transform, "Text", label,
                Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero,
                13, FontStyle.Bold, Color.white);
            textObj.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

            return obj;
        }

        /// <summary>
        /// 반응형 슬라이더 (anchor 기반 - 리사이즈 시 자동 조정)
        /// </summary>
        static (Slider slider, Text valueText) CreateResponsiveSlider(Transform parent,
            string name, string label,
            Vector2 anchorMin, Vector2 anchorMax)
        {
            // 컨테이너
            var container = new GameObject($"Slider_{name}");
            container.transform.SetParent(parent, false);
            var containerRt = container.AddComponent<RectTransform>();
            containerRt.anchorMin = anchorMin;
            containerRt.anchorMax = anchorMax;
            containerRt.offsetMin = new Vector2(5, 0);
            containerRt.offsetMax = new Vector2(-5, 0);

            // 라벨 (상단 50%)
            CreateAnchoredLabel(container.transform, "Label", label,
                new Vector2(0, 0.5f), new Vector2(0.75f, 1),
                new Vector2(2, 0), Vector2.zero, 12, FontStyle.Normal, TEXT_DIM);

            // 값 텍스트 (상단 우측)
            var valueObj = CreateAnchoredLabel(container.transform, "Value", "0",
                new Vector2(0.75f, 0.5f), new Vector2(1, 1),
                Vector2.zero, new Vector2(-2, 0), 13, FontStyle.Bold, ACCENT_YELLOW);
            valueObj.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
            var valueTxt = valueObj.GetComponent<Text>();

            // 슬라이더 (하단 50%)
            var sliderObj = new GameObject("Slider");
            sliderObj.transform.SetParent(container.transform, false);
            var sliderRt = sliderObj.AddComponent<RectTransform>();
            sliderRt.anchorMin = new Vector2(0, 0);
            sliderRt.anchorMax = new Vector2(1, 0.5f);
            sliderRt.offsetMin = new Vector2(2, 2);
            sliderRt.offsetMax = new Vector2(-2, -2);

            // Background
            CreateAnchoredImage(sliderObj.transform, "Background",
                new Vector2(0, 0.3f), new Vector2(1, 0.7f),
                Vector2.zero, Vector2.zero, SLIDER_BG);

            // Fill Area
            var fillArea = new GameObject("Fill Area");
            fillArea.transform.SetParent(sliderObj.transform, false);
            var fillAreaRt = fillArea.AddComponent<RectTransform>();
            fillAreaRt.anchorMin = new Vector2(0, 0.3f);
            fillAreaRt.anchorMax = new Vector2(1, 0.7f);
            fillAreaRt.offsetMin = Vector2.zero;
            fillAreaRt.offsetMax = Vector2.zero;

            var fillObj = new GameObject("Fill");
            fillObj.transform.SetParent(fillArea.transform, false);
            var fillRt = fillObj.AddComponent<RectTransform>();
            fillRt.anchorMin = new Vector2(0, 0);
            fillRt.anchorMax = new Vector2(0, 1); // Slider controls anchorMax.x
            fillRt.offsetMin = Vector2.zero;
            fillRt.offsetMax = Vector2.zero;
            var fillImg = fillObj.AddComponent<Image>();
            fillImg.color = SLIDER_FILL;

            // Handle Area
            var handleArea = new GameObject("Handle Slide Area");
            handleArea.transform.SetParent(sliderObj.transform, false);
            var handleAreaRt = handleArea.AddComponent<RectTransform>();
            handleAreaRt.anchorMin = Vector2.zero;
            handleAreaRt.anchorMax = Vector2.one;
            handleAreaRt.offsetMin = new Vector2(5, 0);
            handleAreaRt.offsetMax = new Vector2(-5, 0);

            var handleObj = new GameObject("Handle");
            handleObj.transform.SetParent(handleArea.transform, false);
            var handleRt = handleObj.AddComponent<RectTransform>();
            handleRt.anchorMin = new Vector2(0, 0);
            handleRt.anchorMax = new Vector2(0, 1);
            handleRt.pivot = new Vector2(0.5f, 0.5f);
            handleRt.sizeDelta = new Vector2(14, 0);
            var handleImg = handleObj.AddComponent<Image>();
            handleImg.color = HANDLE_COLOR;

            // Slider component
            var slider = sliderObj.AddComponent<Slider>();
            slider.fillRect = fillRt;
            slider.handleRect = handleRt;
            slider.targetGraphic = handleImg;
            slider.direction = Slider.Direction.LeftToRight;

            return (slider, valueTxt);
        }
    }
}
