using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

#endif

namespace BoatAttack
{
    public class Benchmark : MonoBehaviour
    {
        public Object[] scenes;

        private static bool _exitOnCompletion;
        public string scene;

        private void Start()
        {
#if UNITY_EDITOR
            
#endif
            DontDestroyOnLoad(gameObject);
            LoadBenchmark(scene, 4, true, true);
        }

        public static void LoadBenchmark(string scene, int runs, bool perfstats, bool quitOnFinish)
        {
            _exitOnCompletion = quitOnFinish;
            AppSettings.LoadScene(scene);
        }

        public static void EndBenchmark()
        {
            if (_exitOnCompletion)
            {
                AppSettings.ExitGame();
            }
        }
    }
    
#if UNITY_EDITOR
    [InitializeOnLoad]
    public class BenchmarkTool
    {
        static BenchmarkTool()
        {
            EditorApplication.playModeStateChanged += Cleanup;
        }
        
        [MenuItem("Boat Attack/Benchmark/Island Flythrough")]
        public static void IslandFlyThrough()
        {
            EditorApplication.EnterPlaymode();
            //EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            var go = new GameObject("BenchmarkManager");
            var bench = go.AddComponent<Benchmark>();
            bench.scene = "benchmark_island-flythrough";
        }

        private static void Cleanup(PlayModeStateChange state)
        {
            Debug.Log("statechange");
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                var go = GameObject.Find("BenchmarkManager");
                if(go)
                    Object.DestroyImmediate(go);
            }
        }
    }
#endif

    [Serializable]
    public class PerfBasic
    {
        public TestInfo info;
        public float RunTime;
        public int Frames;
        public float AvgMs;
        public float MinMs = Single.PositiveInfinity;
        public float MinMSFrame;
        public float MaxMs = Single.NegativeInfinity;
        public float MaxMSFrame;
        public float[] RawSamples;

        public PerfBasic(int frames)
        {
            Frames = frames;
            info = new TestInfo();
        }
    }

    [Serializable]
    public class TestInfo
    {
        public string Scene;
        public string UnityVersion;
        public string UrpVersion;
        public string BoatAttackVersion;
        public string Platform;
        public string API;
        public string CPU;
        public string GPU;
        public string Os;
        public string Quality;
        public string Resolution;

        public TestInfo()
        {
            Scene = SceneManager.GetActiveScene().name.Replace(" ", "");
            UnityVersion = Application.unityVersion;
            UrpVersion = "N/A";
            BoatAttackVersion = Application.version;
            Platform = Application.platform.ToString().Replace(" ", "");
            API = SystemInfo.graphicsDeviceType.ToString().Replace(" ", "");
            CPU = SystemInfo.processorType.Replace(" ", "");
            GPU = SystemInfo.graphicsDeviceName.Replace(" ", "");
            Os = SystemInfo.operatingSystem.Replace(" ", "");
            Quality = QualitySettings.names[QualitySettings.GetQualityLevel()].Replace(" ", "");
            Resolution = $"{Display.main.renderingWidth}x{Display.main.renderingHeight}";
        }
    }
}
