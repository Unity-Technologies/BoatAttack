using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
public class AutoPerfControl : MonoBehaviour
{
    class Marker
    {
        public float time;
        public string label;
        public float avgFrameTime, avgCPUTime, avgGPUTime;
        public int CPULevel, GPULevel;
        public float tempLevel, tempTrend;
        public string warningLevel;
        public Marker(float Time, string Label, float AvgFrameTime, float AvgCPUTime, float AvgGPUTime, int _CPULevel, int _GPULevel, float TempLevel, float TempTrend, string WarningLevel)
        {
            time = Time;
            label = Label;
            avgFrameTime = AvgFrameTime;
            avgCPUTime = AvgCPUTime;
            avgGPUTime = AvgGPUTime;
            CPULevel = _CPULevel;
            GPULevel = _GPULevel;
            tempLevel = TempLevel;
            tempTrend = TempTrend;
            warningLevel = WarningLevel;
        }
    }
    public GameObject HighLevelLoad, MidLevelLoad, NoLoad;

    IAdaptivePerformance ap;
    TestSequence sequence;
    List<Marker> markers = new List<Marker>();
    Stopwatch watch = new Stopwatch();
    bool loop = false;
    bool autoMode = false;
    int loopCycles = 2;
    float timer = 0, timerMax = 3;
    int activeID = -1;

    [Tooltip("Time in seconds after which test will stop with a Timeout log")]
    public float testTimeout = 600;
    [Tooltip("Enable the Adaptive Performance Auto control mode which controls CPU and GPU levels based on current load")]
    public bool AutoControlMode = true;
    void Start()
    {
        ap = Holder.Instance;
        if (ap == null || !ap.Active)
        {
            Debug.Log("[AP APC] AP is not Active");
            enabled = false;
            return;
        }

        var seq = GameObject.Find("TestSequencer");
        sequence = seq.GetComponent<TestSequence>();
        loop = sequence.loop;
        autoMode = sequence.autoMode;

        ap.DevicePerformanceControl.AutomaticPerformanceControl = AutoControlMode;
        ap.DevelopmentSettings.Logging = true;
        ap.DevelopmentSettings.LoggingFrequencyInFrames = 200;

        Debug.Log($"Auto Performance Control overrides settings automatic performance mode to {ap.DevicePerformanceControl.AutomaticPerformanceControl},logging to {ap.DevelopmentSettings.Logging}.");
        // The base cycle amount for one test sequence
        loopCycles = 1;
        // If Auto mode is enabled, we're not using the loopCycles
        if (autoMode)
        {
            loop = false;
            // Since loopCycles won't be decremented, a value of 2 means it will be running forever
            loopCycles = 2;
        }
        if (loop) loopCycles = sequence.loopCycles;
        watch.Start();
        LogResult("Test start");

        ap.ThermalStatus.ThermalEvent += OnThermalEvent;
        StartCoroutine(continuousLogging());
    }

    void OnThermalEvent(ThermalMetrics ev)
    {
        if (loop)
            return;

        switch (ev.WarningLevel)
        {
            case WarningLevel.NoWarning:
                break;
            case WarningLevel.ThrottlingImminent:
                ap.ThermalStatus.ThermalEvent -= OnThermalEvent;
                LogResult("ThrottlingImminent state reached");
                StartCoroutine(FinishAutoMode());
                break;
            case WarningLevel.Throttling:
                ap.ThermalStatus.ThermalEvent -= OnThermalEvent;
                LogResult("Throttling state reached");
                StartCoroutine(FinishAutoMode());
                break;
        }
    }

    void Update()
    {
        if (!AutoControlMode)
        {
            ap.DevicePerformanceControl.CpuLevel = ap.DevicePerformanceControl.MaxCpuPerformanceLevel;
            ap.DevicePerformanceControl.GpuLevel = ap.DevicePerformanceControl.MaxGpuPerformanceLevel;
        }
        if (watch.ElapsedMilliseconds > testTimeout * 1000)
        {
            LogResult("Timeout reached");
            FinishTest();
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (activeID >= 0)
                LogResult("Finished with state: " + sequence.orderedLoadLevels[activeID].Name.ToString());
            int count = sequence.orderedLoadLevels.Count;
            if (activeID < count - 1)
            {
                activeID++;
            }
            else
            {
                if (loopCycles - 1 <= 0)
                    FinishTest();
                activeID = 0;
                // In auto mode the test cycles forever until thermal state is reached or timeout happens
                if (!autoMode) loopCycles--;
                LogResult("Finished one loop, starting a new one");
            }
            ActivateLoadLevel(count, activeID);
            LogResult("Beginning state: " + sequence.orderedLoadLevels[activeID].Name.ToString());
            timer = timerMax;
        }
    }

    void FinishTest()
    {
        Debug.Log("[AP APC] Test Finished, Outputting results:");
        LogResult("Test Finished");
        for (int i = 0; i < markers.Count; i++)
        {
            Debug.LogFormat("[AP APC] {0} , Timestamp: {1} , Average Frame time: {2} , " +
                "Avg CPU Time: {3}, Avg GPU Time: {4}, CPULevel: {5}/{6} , GPULevel: {7}/{8}, " +
                "Temp level: {9}, Temp trend: {10}, WarningLevel: {11}",
                markers[i].label, markers[i].time, markers[i].avgFrameTime,
                markers[i].avgCPUTime, markers[i].avgGPUTime, markers[i].CPULevel, ap.DevicePerformanceControl.MaxCpuPerformanceLevel,
                markers[i].GPULevel, ap.DevicePerformanceControl.MaxGpuPerformanceLevel, markers[i].tempLevel,
                markers[i].tempTrend, markers[i].warningLevel);
        }
        watch.Stop();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator FinishAutoMode()
    {
        LogResult("'ThrottlingImminent' reached");
        if (AutoControlMode)
        {
            LogResult("Setting TargetFrameRate to 45 and waiting for test to finish");
            Application.targetFrameRate = 45;
        }
        else
        {
            LogResult("Waiting for test to finish");
        }
        yield return null;
    }

    void LogResult(string Label)
    {
        Marker marker = new Marker(
            watch.ElapsedMilliseconds,
            "[AP APC] " + Label,
            ap.PerformanceStatus.FrameTiming.AverageFrameTime,
            ap.PerformanceStatus.FrameTiming.AverageCpuFrameTime,
            ap.PerformanceStatus.FrameTiming.AverageGpuFrameTime,
            ap.PerformanceStatus.PerformanceMetrics.CurrentCpuLevel,
            ap.PerformanceStatus.PerformanceMetrics.CurrentGpuLevel,
            ap.ThermalStatus.ThermalMetrics.TemperatureLevel,
            ap.ThermalStatus.ThermalMetrics.TemperatureTrend,
            ap.ThermalStatus.ThermalMetrics.WarningLevel.ToString()
        );
        markers.Add(marker);
        if (loggingActive)
            Debug.LogFormat("{0} | " +
                "Timestamp: {1} | " +
                "Average frame time: {2} | " +
                "Average CPU time: {3} | " +
                "Average GPU time: {4} | " +
                "Current CPU level: {5}/{6} | " +
                "Current GPU level: {7}/{8} | " +
                "Current Temp level: {9} | " +
                "Temp trend: {10} | " +
                "Temp Warning Level: {11} ",
                marker.label, marker.time, marker.avgFrameTime, marker.avgCPUTime, marker.avgGPUTime, marker.CPULevel, ap.DevicePerformanceControl.MaxCpuPerformanceLevel,
                marker.GPULevel, ap.DevicePerformanceControl.MaxGpuPerformanceLevel, marker.tempLevel, marker.tempTrend, marker.warningLevel);
    }

    void ActivateLoadLevel(int count, int ID)
    {
        for (int i = 0; i < count; i++)
        {
            sequence.orderedLoadLevels[i].isActive = false;
        }
        sequence.orderedLoadLevels[ID].isActive = true;
        timerMax = sequence.orderedLoadLevels[ID].Duration;
        switch (sequence.orderedLoadLevels[ID].Name)
        {
            case LoadLevel.loadlevels.High:
                EnableGameObject(HighLevelLoad);
                HighLevelLoadManager Hmanager = FindObjectOfType<HighLevelLoadManager>();
                Hmanager.SetLoad(Hmanager.startingLoadAmount);
                break;
            case LoadLevel.loadlevels.Mid:
                EnableGameObject(MidLevelLoad);
                MidLevelLoadManager Mmanager = FindObjectOfType<MidLevelLoadManager>();
                Mmanager.SetLoad(Mmanager.startingLoadAmount);
                break;
            case LoadLevel.loadlevels.No:
                EnableGameObject(NoLoad);
                break;
            default:
                Debug.Log("Unrecognized Load level");
                break;
        }
    }

    void EnableGameObject(GameObject level)
    {
        HighLevelLoad.transform.GetChild(0).gameObject.SetActive(false);
        MidLevelLoad.transform.GetChild(0).gameObject.SetActive(false);
        NoLoad.transform.GetChild(0).gameObject.SetActive(false);

        level.transform.GetChild(0).gameObject.SetActive(true);
    }

    [Tooltip("If checked, logs will be taken at the LoggingFrequency interval ")]
    public bool loggingActive = true;
    [Tooltip("Interval for logging data continuously, measured in seconds")]
    [Range(0.5f, 10)]
    public float loggingFrequency = 1.0f;
    IEnumerator continuousLogging()
    {
        while (true)
        {
            if (loggingActive) LogResult("Continuous Log");
            yield return new WaitForSeconds(loggingFrequency);
        }
    }
}
