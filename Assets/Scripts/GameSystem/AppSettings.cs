using System;
using System.Collections;
using GameplayIngredients;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
// ReSharper disable InconsistentNaming

namespace BoatAttack
{
    [ManagerDefaultPrefab("AppManager")]
    public class AppSettings : Manager
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
        public AssetReference volumeManager;

        // Use this for initialization
        private void OnEnable()
        {
            Initialize();
            RenderPipelineManager.beginCameraRendering += SetRenderScale;
            SceneManager.sceneLoaded += LevelWasLoaded;
        }

        private void Initialize()
        {
            Instance = this;
            Application.targetFrameRate = 300;
            MainCamera = Camera.main;
            if(DefaultVolume.Instance == null)
                StartCoroutine(LoadPrefab<GameObject>(volumeManager, new AsyncOperationHandle()));
        }

        private void Start()
        {
            var obj = GameObject.Find("[Debug Updater]"); // TODO hack to solve input class issues
            if(obj != null)
                Destroy(obj);
        }

        private void OnDisable()
        {
            RenderPipelineManager.beginCameraRendering -= SetRenderScale;
        }

        private static void LevelWasLoaded(Scene scene, LoadSceneMode mode)
        {
            if (!MainCamera)
            {
                MainCamera = Camera.main;
            }
            else
            {
                var cams = GameObject.FindGameObjectsWithTag("MainCamera");
                foreach (var c in cams)
                {
                    if (c != MainCamera.gameObject) Destroy(c);
                }
            }

            Instance.Invoke(nameof(CleanupLoadingScreen), 0.5f);
        }

        private void CleanupLoadingScreen()
        {
            if (Instance.loadingScreenObject != null)
            {
                Instance.loadingScreen.ReleaseInstance(Instance.loadingScreenObject);
            }
        }

        private void SetRenderScale(ScriptableRenderContext context, Camera cam)
        {
            float res;
            switch (maxRenderSize)
            {
                case RenderRes._720p:
                    res = 1280f;
                    break;
                case RenderRes._1080p:
                    res = 1920f;
                    break;
                case RenderRes._1440p:
                    res = 2560f;
                    break;
                default:
                    res = cam.pixelWidth;
                    break;
            }

            var renderScale = Mathf.Clamp(res / cam.pixelWidth, 0.1f, 1.0f);
            maxScale = renderScale;
#if !UNITY_EDITOR
            UniversalRenderPipeline.asset.renderScale = renderScale;
#endif
        }

        private void Update()
        {
            if (!MainCamera) return;

            if (variableResolution)
            {
                MainCamera.allowDynamicResolution = true;

                var offset = 0f;
                var currentFrametime = Time.deltaTime;
                var rate = 0.1f;

                switch (targetFramerate)
                {
                    case Framerate._30:
                        offset = currentFrametime > (1000f / 30f) ? -rate : rate;
                        break;
                    case Framerate._60:
                        offset = currentFrametime > (1000f / 60f) ? -rate : rate;
                        break;
                    case Framerate._120:
                        offset = currentFrametime > (1000f / 120f) ? -rate : rate;
                        break;
                }

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

        public static void LoadScene(string scenePath, LoadSceneMode mode = LoadSceneMode.Single)
        {
            LoadScene(SceneUtility.GetBuildIndexByScenePath(scenePath), mode);
        }

        public static void LoadScene(int buildIndex, LoadSceneMode mode)
        {
            Application.backgroundLoadingPriority = ThreadPriority.Low;
            switch (mode)
            {
                case LoadSceneMode.Single:
                    Instance.StartCoroutine(LoadScene(buildIndex));
                    break;
                case LoadSceneMode.Additive:
                    SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        private static IEnumerator LoadScene(int scene)
        {
            var loadingScreenLoading = Instance.loadingScreen.InstantiateAsync();
            yield return loadingScreenLoading;
            Instance.loadingScreenObject = loadingScreenLoading.Result;
            DontDestroyOnLoad(Instance.loadingScreenObject);
            Debug.Log($"loading scene {SceneUtility.GetScenePathByBuildIndex(scene)} at build index {scene}");
            SceneManager.LoadScene(scene);
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

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }

    public static class ConstantData
    {
        private static readonly string[] Levels =
        {
            "Island",
        };

        public static string GetLevelName(int level)
        {
            return $"level_{Levels[level]}";
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

        public static Color[] ColorPalette;
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
