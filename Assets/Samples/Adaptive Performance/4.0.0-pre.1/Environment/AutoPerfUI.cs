using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;
public class AutoPerfUI : MonoBehaviour
{
    private IAdaptivePerformance ap;
    public PerformanceBottleneck targetBN = PerformanceBottleneck.TargetFrameRate;
    public Text avgCPUTime, avgGPUTime, avgFrameTime, cpuLevel, gpuLevel, tempLevel, tempTrend, stateText;
    public Image tempBackground;
    float avgCPUfloat, avgGPUfloat, avgFramefloat;

    public GameObject GPUBound, CPUBound, TargetFrameRateBound, UnknownBound;
    public GameObject NoWarning, ThrottlingImminent, Throttling;

    void Start()
    {
        ap = Holder.Instance;
        if (ap == null || !ap.Active)
        {
            Debug.Log("[AP APC] Adaptive Performance not active");
            enabled = false;
            return;
        }

        // The game starts in a menu and we want to save power
        ap.DevicePerformanceControl.CpuLevel = 3;
        ap.DevicePerformanceControl.GpuLevel = 3;

        ap.PerformanceStatus.PerformanceBottleneckChangeEvent += OnBottleneckChange;
        ap.ThermalStatus.ThermalEvent += OnThermalEvent;

        checkStatus();
        maxCpuPerformanceLevel = ap.DevicePerformanceControl.MaxCpuPerformanceLevel;
        maxGpuPerformanceLevel = ap.DevicePerformanceControl.MaxGpuPerformanceLevel;
    }

    private void OnDestroy()
    {
        if (ap == null)
        {
            return;
        }
        ap.PerformanceStatus.PerformanceBottleneckChangeEvent -= OnBottleneckChange;
        ap.ThermalStatus.ThermalEvent -= OnThermalEvent;
    }

    void checkStatus()
    {
        DisableAllBottlenecks();
        DisableAllThermalWarnings();

        switch (ap.PerformanceStatus.PerformanceMetrics.PerformanceBottleneck)
        {
            case PerformanceBottleneck.CPU:
                Activate(CPUBound);
                break;
            case PerformanceBottleneck.GPU:
                Activate(GPUBound);
                break;
            case PerformanceBottleneck.TargetFrameRate:
                Activate(TargetFrameRateBound);
                break;
            case PerformanceBottleneck.Unknown:
                Activate(UnknownBound);
                break;
        }

        switch (ap.ThermalStatus.ThermalMetrics.WarningLevel)
        {
            case WarningLevel.NoWarning:
                Activate(NoWarning);
                break;
            case WarningLevel.ThrottlingImminent:
                Activate(ThrottlingImminent);
                break;
            case WarningLevel.Throttling:
                Activate(Throttling);
                break;
        }
    }

    float tempLevelLast;
    float tempLevelFloat;
    int maxCpuPerformanceLevel;
    int maxGpuPerformanceLevel;

    void Update()
    {
        avgCPUfloat = ap.PerformanceStatus.FrameTiming.AverageCpuFrameTime;
        avgGPUfloat = ap.PerformanceStatus.FrameTiming.AverageGpuFrameTime;
        avgFramefloat = ap.PerformanceStatus.FrameTiming.AverageFrameTime;
        cpuLevel.text = ap.PerformanceStatus.PerformanceMetrics.CurrentCpuLevel + "/" + maxCpuPerformanceLevel;
        gpuLevel.text = ap.PerformanceStatus.PerformanceMetrics.CurrentGpuLevel + "/" + maxGpuPerformanceLevel;
        tempLevelFloat = ap.ThermalStatus.ThermalMetrics.TemperatureLevel;
        if (tempLevelFloat != tempLevelLast)
            CheckTempColour(tempLevelFloat);
        tempLevel.text = tempLevelFloat.ToString("F2");
        tempTrend.text = ap.ThermalStatus.ThermalMetrics.TemperatureTrend.ToString("F2");
        avgCPUTime.text = (avgCPUfloat * 1000).ToString("F2") + " ms";
        avgGPUTime.text = (avgGPUfloat * 1000).ToString("F2") + " ms";
        avgFrameTime.text = (avgFramefloat * 1000).ToString("F2") + " ms";
        tempLevelLast = ap.ThermalStatus.ThermalMetrics.TemperatureLevel;
    }

    void CheckTempColour(float tempLevel)
    {
        if (tempLevel < 0.5f)
            tempBackground.color = Color.green;
        else if (tempLevel < 0.8f)
            tempBackground.color = Color.yellow;
        else tempBackground.color = Color.red;
    }

    void OnBottleneckChange(PerformanceBottleneckChangeEventArgs ev)
    {
        DisableAllBottlenecks();
        switch (ev.PerformanceBottleneck)
        {
            case PerformanceBottleneck.CPU:
                Activate(CPUBound);
                break;
            case PerformanceBottleneck.GPU:
                Activate(GPUBound);
                break;
            case PerformanceBottleneck.TargetFrameRate:
                Activate(TargetFrameRateBound);
                break;
            case PerformanceBottleneck.Unknown:
                Activate(UnknownBound);
                break;
        }
    }

    void OnThermalEvent(ThermalMetrics ev)
    {
        DisableAllThermalWarnings();
        switch (ev.WarningLevel)
        {
            case WarningLevel.NoWarning:
                Activate(NoWarning);
                break;
            case WarningLevel.ThrottlingImminent:
                Activate(ThrottlingImminent);
                break;
            case WarningLevel.Throttling:
                Activate(Throttling);
                break;
        }
    }

    void DisableAllBottlenecks()
    {
        CPUBound.SetActive(false);
        GPUBound.SetActive(false);
        TargetFrameRateBound.SetActive(false);
        UnknownBound.SetActive(false);
    }

    void DisableAllThermalWarnings()
    {
        NoWarning.SetActive(false);
        ThrottlingImminent.SetActive(false);
        Throttling.SetActive(false);
    }

    void Activate(GameObject go)
    {
        go.SetActive(true);
    }
}
