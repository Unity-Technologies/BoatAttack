using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace BoatAttack.Benchmark
{
    public class Benchmark : MonoBehaviour
    {
        // data
        public bool autoStart = true;
        private bool singleBench = false;
        [HideInInspector] public string urpVersion = "N/A";
        public static string UrpVersion;
        [HideInInspector] public int simpleRunScene = -1;
        public BenchmarkConfigData settings;
        public bool simpleRun = false;
        public FinishAction finish = FinishAction.Exit;
        public static bool SimpleRun;
        private int _benchIndex;
        public static BenchmarkData Current { get; private set; }

        private static PerfomanceStats _stats;

        // Timing data
        public static int CurrentRunIndex;
        public static int CurrentRunFrame;
        private int _totalRunFrames;
        private bool _running = false;

        // Bench results
        private readonly List<PerfBasic> _perfData = new List<PerfBasic>();

        private void Start()
        {
            if (settings == null) AppSettings.ExitGame("Benchmark Not Setup");
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            if (autoStart)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            UrpVersion = urpVersion;
            if(settings.disableVSync)
                QualitySettings.vSyncCount = 0;
            if(settings.stats)
                _stats = gameObject.AddComponent<PerfomanceStats>();
            DontDestroyOnLoad(gameObject);

            if (simpleRun && settings.benchmarkData?[simpleRunScene] != null)
            {
                if(settings.stats)
                    _stats.mode = PerfomanceStats.PerfMode.DisplayOnly;
                SimpleRun = simpleRun;
                Current = settings.benchmarkData?[simpleRunScene];
                LoadBenchmark();
            }
            else
            {
                if(settings.stats)
                    _stats.mode = PerfomanceStats.PerfMode.Benchmark;
                Current = settings.benchmarkData?[_benchIndex];
                LoadBenchmark();
            }
        }

        private void OnDestroy()
        {
            RenderPipelineManager.endFrameRendering -= EndFrameRendering;
#if UNITY_EDITOR
            EditorSceneManager.playModeStartScene = null; // need to reset benchmark start scene once benchmark is destroyed
#endif
        }

        public void LoadBenchmark(int index)
        {
            singleBench = true;
            _benchIndex = index;
            Initialize();
        }

        private void LoadBenchmark()
        {
            AppSettings.LoadScene(Current.scene);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.path != Current.scene) return;

            if (Current.warmup)
            {
                CurrentRunIndex = -1;
            }
            else
            {
                CurrentRunIndex = 0;
            }

            CurrentRunFrame = 0;

            switch (Current.type)
            {
                case BenchmarkType.Scene:
                    break;
                case BenchmarkType.Shader:
                    break;
                default:
                    AppSettings.ExitGame("Benchmark Not Setup");
                    break;
            }

            if(settings.stats)
                _stats.StartRun(Current.benchmarkName, Current.runLength);

            BeginRun();
            RenderPipelineManager.endFrameRendering += EndFrameRendering;
        }

        private void BeginRun()
        {
            CurrentRunFrame = 0;
        }

        private void EndFrameRendering(ScriptableRenderContext context, Camera[] cameras)
        {
            CurrentRunFrame++;
            if (CurrentRunFrame < Current.runLength) return;
            
            if(settings.stats)
                _stats.EndRun();

            CurrentRunIndex++;
            if (CurrentRunIndex < Current.runs || simpleRun)
            {
                BeginRun();
            }
            else
            {
                RenderPipelineManager.endFrameRendering -= EndFrameRendering;
                EndBenchmark();
            }
        }

        public void EndBenchmark()
        {
            if(settings.stats && settings.saveData) SaveBenchmarkStats();
            _benchIndex++;

            if (_benchIndex < settings.benchmarkData.Count && !singleBench)
            {
                Current = settings.benchmarkData[_benchIndex];
                LoadBenchmark();
            }
            else
            {
                FinishBenchmark();
            }
        }

        private void FinishBenchmark()
        {
            SaveBenchmarkFile();
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            switch (finish)
            {
                case FinishAction.Exit:
                    AppSettings.ExitGame();
                    break;
                case FinishAction.ShowStats:
                    break;
                case FinishAction.Nothing:
                    break;
                case FinishAction.MainMenu:
                    AppSettings.LoadScene(0);
                    break;
                default:
                    AppSettings.ExitGame("Benchmark Not Setup");
                    break;
            }
        }

        private void SaveBenchmarkStats()
        {
            var stats = _stats.EndBench();
            if (stats != null)
            {
                _perfData.Add(stats);
            }
        }

        private void SaveBenchmarkFile()
        {
            // File name
            var dateTimeNow = DateTime.Now;
            var filename = $"{Application.productName}-{SystemInfo.deviceName}-{dateTimeNow.ToShortDateString()}-{dateTimeNow.ToShortTimeString()}";
            filename = Path.GetInvalidFileNameChars().Aggregate(filename, (current, c) => current.Replace(c, '-'));
            var path = GetResultPath() + $"/{filename}.json";
            
            // Pack results
            var results = new PerfResults
            {
                fileName = Path.GetFileName(path),
                filePath = Path.GetFullPath(path),
                timestamp = DateTime.Now.ToString(DateTimeFormatInfo.InvariantInfo),
                perfStats = _perfData.ToArray()
            };

            // Write file
            File.WriteAllText(path, JsonUtility.ToJson(results));
        }

        private static string GetResultPath()
        {
            var path = Application.isEditor ? Directory.GetParent(Application.dataPath).ToString() : Application.persistentDataPath;
            path += "/PerformanceResults";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        public static List<PerfResults> LoadAllBenchmarkStats()
        {
            var list = new List<PerfResults>();
            var fileList = Directory.GetFiles(GetResultPath());

            foreach (var file in fileList)
            {
                if(!File.Exists(file))
                    break;

                var data = File.ReadAllText(file);
                var result = JsonUtility.FromJson<PerfResults>(data);
                list.Add(result);
            }

            return list;
        }
    }
    
    public class PerfResults
    {
        public string fileName;
        public string filePath;
        public string timestamp;
        public PerfBasic[] perfStats;
    }

    [Serializable]
    public class PerfBasic
    {
        public TestInfo info;
        public int Frames;
        public RunData[] RunData;

        public PerfBasic(string benchmarkName, string urpVersion, int frames)
        {
            Frames = frames;
            info = new TestInfo(benchmarkName) {UrpVersion = urpVersion};
            RunData = new RunData[Benchmark.Current.runs];
            for (var index = 0; index < RunData.Length; index++)
            {
                RunData[index] = new RunData(new float[frames]);
            }
        }
    }

    [Serializable]
    public class RunData
    {
        public float RunTime;
        public float AvgMs;
        public FrameData MinFrame = FrameData.DefaultMin;
        public FrameData MaxFrame = FrameData.DefaultMax;
        public float[] rawSamples;

        public RunData(float[] times) { rawSamples = times; }

        public void Average()
        {
            AvgMs = 0.0f;
            foreach (var sample in rawSamples)
            {
                AvgMs += sample / rawSamples.Length;
            }
        }
        public void SetMin(float ms, int frame) { MinFrame.ms = ms; MinFrame.frameIndex = frame; }
        public void SetMax(float ms, int frame) { MaxFrame.ms = ms; MaxFrame.frameIndex = frame; }

        public void EndRun(float runtime, FrameData min, FrameData max)
        {
            RunTime = runtime;
            MinFrame = min;
            MaxFrame = max;
            Average();
        }

    }

    [Serializable]
    public class FrameData
    {
        public int frameIndex;
        public float ms;

        public FrameData(int frameNumber, float frameTime)
        {
            frameIndex = frameNumber;
            ms = frameTime;
        }

        public void Set(int frameNumber, float frameTime)
        {
            frameIndex = frameNumber;
            ms = frameTime;
        }

        public static FrameData DefaultMin => new FrameData(-1, Single.PositiveInfinity);

        public static FrameData DefaultMax => new FrameData(-1, Single.NegativeInfinity);
    }

    [Serializable]
    public class TestInfo
    {
        public string BenchmarkName;
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

        public TestInfo(string benchmarkName, string urpVersion = "N/A")
        {
            BenchmarkName = benchmarkName;
            Scene = Utility.RemoveWhitespace(SceneManager.GetActiveScene().name);
            UnityVersion = Application.unityVersion;
            UrpVersion = urpVersion;
            BoatAttackVersion = Application.version;
            Platform =  Utility.RemoveWhitespace(Application.platform.ToString());
            API =  Utility.RemoveWhitespace(SystemInfo.graphicsDeviceType.ToString());
            CPU =  Utility.RemoveWhitespace(SystemInfo.processorType);
            GPU =  Utility.RemoveWhitespace(SystemInfo.graphicsDeviceName);
            Os =  Utility.RemoveWhitespace(SystemInfo.operatingSystem);
            Quality =  Utility.RemoveWhitespace(QualitySettings.names[QualitySettings.GetQualityLevel()]);
            Resolution = $"{Display.main.renderingWidth}x{Display.main.renderingHeight}";
        }
    }
}
