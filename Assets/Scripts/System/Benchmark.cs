//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.SceneManagement;
//using Object = UnityEngine.Object;
//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEditor.SceneManagement;
//#endif

//namespace BoatAttack
//{
//    public class Benchmark : MonoBehaviour
//    {
//        public List<BenchmarkSettings> settings = new List<BenchmarkSettings>();
//        private static BenchmarkSettings _settings;

//        //public AssetReference perfStatsUI;
//        //public AssetReference perfSummaryUI;

//        private void Start()
//        {
//            SceneManager.sceneLoaded += OnSceneLoaded;
//            DontDestroyOnLoad(gameObject);
//            LoadBenchmark(settings[0]);
//        }

//        private void LoadBenchmark(BenchmarkSettings setting)
//        {
//            settings.RemoveAt(0);
//            _settings = setting;
//            AppSettings.LoadScene(setting.scene);
//        }

//        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//        {
//            if (scene.name == _settings.scene)
//            {
//                switch (_settings.type)
//                {
//                    case BenchmarkType.Track:
//                        SetupFlyThroughBenchmark();
//                        break;
//                    case BenchmarkType.Static:
//                        SetupStaticBenchmark();
//                        break;
//                    default:
//                        throw new ArgumentOutOfRangeException();
//                }
//            }
//        }

//        private void SetupFlyThroughBenchmark()
//        {
//            var go = GameObject.FindGameObjectWithTag("benchmark_flythrough");

//        }

//        private void SetupStaticBenchmark()
//        {
//            var go = GameObject.FindGameObjectWithTag("benchmark_static");
//        }

//        public static void EndBenchmark()
//        {
//            if (_settings.exitOnCompletion)
//            {
//                AppSettings.ExitGame();
//            }
//        }
//    }

//#if UNITY_EDITOR
//    [InitializeOnLoad]
//#endif
//    public class BenchmarkTool
//    {
//        static BenchmarkTool()
//        {
//#if UNITY_EDITOR
//            EditorApplication.playModeStateChanged += Cleanup;
//#endif
//        }

//#if UNITY_EDITOR
//        [MenuItem("Boat Attack/Benchmark/Island Flythrough")]
//        public static void IslandFlyThrough()
//        {
//            EditorApplication.EnterPlaymode();
//            var settings = new BenchmarkSettings("benchmark_island-flythrough",
//                4,
//                true,
//                true,
//                true,
//                BenchmarkType.Track);
//            CreateBenchmark(settings);
//        }

//        private static void Cleanup(PlayModeStateChange state)
//        {
//            Debug.Log("statechange");
//            if (state == PlayModeStateChange.EnteredEditMode)
//            {
//                var go = GameObject.Find("BenchmarkManager");
//                if(go)
//                    Object.DestroyImmediate(go);
//            }
//        }
//#endif
//        public static void CreateBenchmark(BenchmarkSettings settings)
//        {
//            var go = new GameObject("BenchmarkManager");
//            var bench = go.AddComponent<Benchmark>();
//            bench.settings.Add(settings);
//        }
//    }

//    [Serializable]
//    public class PerfBasic
//    {
//        public TestInfo info;
//        public float RunTime;
//        public int Frames;
//        public float AvgMs;
//        public float MinMs = Single.PositiveInfinity;
//        public float MinMSFrame;
//        public float MaxMs = Single.NegativeInfinity;
//        public float MaxMSFrame;
//        public float[] RawSamples;

//        public PerfBasic(int frames)
//        {
//            Frames = frames;
//            info = new TestInfo();
//        }
//    }

//    [Serializable]
//    public class TestInfo
//    {
//        public string Scene;
//        public string UnityVersion;
//        public string UrpVersion;
//        public string BoatAttackVersion;
//        public string Platform;
//        public string API;
//        public string CPU;
//        public string GPU;
//        public string Os;
//        public string Quality;
//        public string Resolution;

//        public TestInfo()
//        {
//            //Scene = SceneManager.GetActiveScene().name.Replace(" ", "");
//            UnityVersion = Application.unityVersion;
//            UrpVersion = "N/A";
//            //BoatAttackVersion = Application.version;
//            Platform = Application.platform.ToString().Replace(" ", "");
//            API = SystemInfo.graphicsDeviceType.ToString().Replace(" ", "");
//            CPU = SystemInfo.processorType.Replace(" ", "");
//            GPU = SystemInfo.graphicsDeviceName.Replace(" ", "");
//            Os = SystemInfo.operatingSystem.Replace(" ", "");
//            Quality = QualitySettings.names[QualitySettings.GetQualityLevel()].Replace(" ", "");
//            Resolution = $"{Display.main.renderingWidth}x{Display.main.renderingHeight}";
//        }
//    }

//    [Serializable]
//    public enum BenchmarkType
//    {
//        Track,
//        Static
//    }

//    [Serializable]
//    public class BenchmarkSettings
//    {
//        public string scene = "benchmark_island-flythrough";
//        public int runs = 4;
//        public bool exitOnCompletion = true;
//        public bool warmup = true;
//        public bool stats = false;
//        public BenchmarkType type;

//        public BenchmarkSettings(string scene, int runs, bool exitOnCompletion, bool warmup, bool stats, BenchmarkType type)
//        {
//            this.scene = scene;
//            this.runs = runs;
//            this.exitOnCompletion = exitOnCompletion;
//            this.warmup = warmup;
//            this.stats = stats;
//            this.type = type;
//        }
//    }
//}
