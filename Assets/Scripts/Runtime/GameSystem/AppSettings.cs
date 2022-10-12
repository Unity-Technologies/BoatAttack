using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering.Universal;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
// ReSharper disable InconsistentNaming

namespace BoatAttack
{
    public class AppSettings : MonoBehaviour
    {
        public enum RenderRes
        {
            _Native,
            _1440p,
            _1080p,
            _720p
        }

        public enum Framerate
        {
            _30,
            _60,
            _120
        }

        public enum SpeedFormat
        {
            _Kph,
            _Mph
        }

        public static AppSettings Instance;

        public InputControls input;
        public static GameObject LastSelectedObject;
        
        private GameObject loadingScreenObject;
        public static Camera MainCamera;
        
        [Header("Resolution Settings")]
        public RenderRes maxRenderSize = RenderRes._720p;
        public bool variableResolution;
        [Range(0f, 1f)]
        public float axisBias = 0.5f;
        public float minScale = 0.5f;
        public Framerate targetFramerate = Framerate._30;
        private float currentDynamicScale = 1.0f;
        private float maxScale = 1.0f;
        public SpeedFormat speedFormat = SpeedFormat._Mph;

        [Header("Asset References")]
        public AssetReference loadingScreen;
        [Header("Prefabs")]
        public GameObject consoleCanvas;
        
        public static GameObject ConsoleCanvas;

        public BoatDataSO[] boats;
        public LevelData[] levels;

        // Use this for initialization
        private void Awake()
        {
            if(Debug.isDebugBuild)
                Debug.Log("AppManager initializing");
            Initialize();
            CmdArgs();
            SetRenderScale();
            SceneManager.sceneLoaded += LevelWasLoaded;
            if (SceneManager.GetActiveScene().name == "loader")
            {
                LoadScene(1);
            }
        }
        
        private void Initialize()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            input = new InputControls();
            input.BoatAttackUI.Move.performed += _ =>
            {
                if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject == null)
                {
                    PointerSelection.SetSelection(LastSelectedObject);
                }
            };
            input.Enable();

            ConsoleCanvas = Instantiate(consoleCanvas);
            DontDestroyOnLoad(ConsoleCanvas);
            MainCamera = Camera.main;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= LevelWasLoaded;
        }

        private static void LevelWasLoaded(Scene scene, LoadSceneMode mode)
        {
            CleanupCameras();
#if STATIC_EVERYTHING
            Utility.StaticObjects();
#endif
            Instance.Invoke(nameof(CleanupLoadingScreen), 0.5f);
        }

        private static void CleanupCameras()
        {
            foreach (var c in GameObject.FindGameObjectsWithTag("MainCamera"))
            {
                if (MainCamera != null && c != MainCamera.gameObject)
                {
                    Destroy(c);
                }
                else
                {
                    MainCamera = c.GetComponent<Camera>();
                }
            }
        }

        private void CleanupLoadingScreen()
        {
            if(loadingScreenObject) loadingScreen?.ReleaseInstance(loadingScreenObject);
        }

        private void SetRenderScale()
        {
            var res = maxRenderSize switch
            {
                RenderRes._720p => 1280f,
                RenderRes._1080p => 1920f,
                RenderRes._1440p => 2560f,
                _ => Screen.width
            };
            var renderScale = Mathf.Clamp(res / Screen.width, 0.1f, 1.0f);

            if(Debug.isDebugBuild)
                Debug.Log($"Settings render scale to {renderScale * 100}% based on {maxRenderSize.ToString()}");

            maxScale = renderScale;
#if !UNITY_EDITOR
            UniversalRenderPipeline.asset.renderScale = renderScale;
#endif
        }

        private void Update()
        {
#if !UNITY_EDITOR
            Utility.CheckQualityLevel(); //TODO - hoping to remove one day when we have a quality level callback
#endif

            if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject != LastSelectedObject)
            {
                LastSelectedObject = EventSystem.current.currentSelectedGameObject;
            }
            
            if (!MainCamera) return;

            if (variableResolution)
            {
                MainCamera.allowDynamicResolution = true;

                var offset = 0f;
                var currentFrametime = Time.unscaledDeltaTime;
                const float rate = 0.1f;

                offset = targetFramerate switch
                {
                    Framerate._30 => currentFrametime > (1000f / 30f) ? -rate : rate,
                    Framerate._60 => currentFrametime > (1000f / 60f) ? -rate : rate,
                    Framerate._120 => currentFrametime > (1000f / 120f) ? -rate : rate,
                    _ => offset
                };

                currentDynamicScale = Mathf.Clamp(currentDynamicScale + offset, minScale, 1f);

                var offsetVec = new Vector2(Mathf.Lerp(1, currentDynamicScale, Mathf.Clamp01((1 - axisBias) * 2f)),
                    Mathf.Lerp(1, currentDynamicScale, Mathf.Clamp01(axisBias * 2f)));

                ScalableBufferManager.ResizeBuffers(offsetVec.x, offsetVec.y);
            }
            else
            {
                MainCamera.allowDynamicResolution = false;
            }
        }
        
        public void ToggleSRPBatcher(bool enabled)
        {
            UniversalRenderPipeline.asset.useSRPBatcher = enabled;
        }
        
        [Console.ConsoleCmd]
        public static void LoadScene(int buildIndex, LoadSceneMode mode = LoadSceneMode.Single)
        {
            Application.backgroundLoadingPriority = ThreadPriority.Low;
            switch (mode)
            {
                case LoadSceneMode.Single:
                    Instance.StartCoroutine(LoadSceneInternal(buildIndex));
                    break;
                case LoadSceneMode.Additive:
                    SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        public static void LoadLevel(LevelData level)
        {
            Instance.StartCoroutine(LoadSceneInternal(level.masterScene, level.supportScenes));
        }
        
        private static IEnumerator LoadSceneInternal(AssetReference scene, AssetReference[] support = null)
        {
            yield return InvokeLoadingScreen();
            
            if(support != null && support.Length > 0)
                Debug.LogError("Support scenes are not supported yet.");
            
            // load new scene
            var load = scene.LoadSceneAsync();
            while (!load.IsDone)
            {
                LoadingScreen.SetProgress(Mathf.SmoothStep(0.5f, 1.0f, load.PercentComplete));
                yield return null;
            }
        }
        
        private static IEnumerator LoadSceneInternal(int buildIndex)
        {
            yield return InvokeLoadingScreen();
            
            // load new scene
            var load = SceneManager.LoadSceneAsync(buildIndex);
            while (!load.isDone)
            {
                LoadingScreen.SetProgress(Mathf.SmoothStep(0.5f, 1.0f, load.progress));
                yield return null;
            }
        }
        
        private static IEnumerator InvokeLoadingScreen()
        {
            var openSceneCount = SceneManager.sceneCount;
            // load loading screen
            var loadingScreenLoading = Instance.loadingScreen.InstantiateAsync();
            yield return loadingScreenLoading;
            Instance.loadingScreenObject = loadingScreenLoading.Result;
            DontDestroyOnLoad(Instance.loadingScreenObject);
            
            // create and set a loading scene as active
            var loadingScene = SceneManager.CreateScene("Loading");
            SceneManager.SetActiveScene(loadingScene);
            
            // unload all other scenes
            var operations = new AsyncOperation[openSceneCount];
            for (var i = openSceneCount - 1; i >= 0; i--)
            {
                var s = SceneManager.GetSceneAt(i);
                if(s != SceneManager.GetActiveScene()) 
                    operations[i] = SceneManager.UnloadSceneAsync(s, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            }
            // wait for unloading to complete
            while (true)
            {
                var unloadCount = operations.Count(asyncOperation => asyncOperation.isDone);
                LoadingScreen.SetProgress(Mathf.SmoothStep(0.0f, 0.5f, (float)operations.Length / unloadCount));
                if(unloadCount == operations.Length) break;
                yield return null;
            }
        }
        
        private static IEnumerator LoadPrefab<T>(AssetReference assetRef, AsyncOperationHandle assetLoading, Transform parent = null)
        {
            if (typeof(T) == typeof(GameObject))
            {
                assetLoading = assetRef.InstantiateAsync(parent);
            }
            else
            {
                assetLoading = assetRef.LoadAssetAsync<T>();
            }
            yield return assetLoading;
        }

        public static void ExitGame(string s = "null")
        {
            if(s != "null")
                Debug.LogError(s);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }

        private static void CmdArgs()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length <= 0) return;
            foreach (var argRaw in args)
            {
                if(string.IsNullOrEmpty(argRaw) || argRaw[0] != '-') continue;
                var arg = argRaw.Split(':');

                switch (arg[0])
                {
                    case "-loadlevel":
                        if(int.TryParse(arg[1], out var i)) LoadScene(i);
                        break;
                    case "-benchmarkFlythrough":
                        //TODO load benchmark
                        break;
                }
            }
        }
    }

    public static class ConstantData
    {
        public static string GetLevelName(int level)
        {
            if (AppSettings.Instance.levels.Length < level)
            {
                return AppSettings.Instance.levels[level].levelName;
            }
            Debug.LogError($"No level at index:{level}");
            return "null";
        }

        public static readonly string[] AiNames =
        {
            "Felipe",
            "Andre",
            "Elvar",
            "Jonas",
            "Erika",
            "Tim",
            "Florin",
            "Andy",
            "Hakeem",
            "Sophia",
            "Martin",
        };

        public static readonly int[] Laps =
        {
            1,
            3,
            6,
            9
        };

        public static int SeedNow
        {
            get
            {
                DateTime dt = DateTime.Now;
                return dt.Year + dt.Month + dt.Day + dt.Hour + dt.Minute + dt.Second;
            }
        }

        private static Color[] ColorPalette;
        private static Texture2D _colorPaletteRaw;

        public static Color GetPaletteColor(int index)
        {
            GenerateColors();
            return ColorPalette[index];
        }

        public static Color GetRandomPaletteColor
        {
            get
            {
                GenerateColors();
                Random.InitState(SeedNow+Random.Range(0,1000));
                return ColorPalette[Random.Range(0, ColorPalette.Length)];
            }
        }

        public static Color[] GetPalette
        {
            get
            {
                GenerateColors();
                return ColorPalette;
            }
        }

        private static void GenerateColors()
        {
            if (ColorPalette != null && ColorPalette.Length != 0) return;

            if (_colorPaletteRaw == null)
                _colorPaletteRaw = Resources.Load<Texture2D>("textures/colorSwatch");

            ColorPalette = _colorPaletteRaw.GetPixels();
            Debug.Log($"Found {ColorPalette.Length} colors.");
        }

    }
}
