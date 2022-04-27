using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;

public class BottleneckUI : MonoBehaviour
{
    private IAdaptivePerformance ap;
    public PerformanceBottleneck targetBottleneck = PerformanceBottleneck.TargetFrameRate;
    public Text avgCPUTime, avgGPUTime, avgFrameTime;
    float avgCPUfloat, avgGPUfloat, avgFramefloat;

    public GameObject GPUBound, CPUBound, TargetFrameRateBound, UnknownBound;
    public GameObject GPUBoundT, CPUBoundT, TargetFrameRateBoundT, UnknownBoundT;

    void Start()
    {
        ap = Holder.Instance;
        if (ap == null)
            return;

        ap.PerformanceStatus.PerformanceBottleneckChangeEvent += OnBottleneckChange;
    }

    private void OnDestroy()
    {
        if (ap == null)
            return;

        ap.PerformanceStatus.PerformanceBottleneckChangeEvent -= OnBottleneckChange;
    }

    void Update()
    {
        if (ap == null)
            return;

        avgCPUfloat = ap.PerformanceStatus.FrameTiming.AverageCpuFrameTime;
        avgGPUfloat = ap.PerformanceStatus.FrameTiming.AverageGpuFrameTime;
        avgFramefloat = ap.PerformanceStatus.FrameTiming.AverageFrameTime;

        avgCPUTime.text = $"{(avgCPUfloat * 1000):F2} ms";
        avgGPUTime.text = $"{(avgGPUfloat * 1000):F2} ms";
        avgFrameTime.text = $"{(avgFramefloat * 1000):F2} ms";

        CheckTargetBottleneck();
    }

    void CheckTargetBottleneck()
    {
        switch (targetBottleneck)
        {
            case PerformanceBottleneck.CPU:
                if (!CPUBoundT.activeSelf)
                    ActivateTargetBottleneckObject(CPUBoundT);
                break;
            case PerformanceBottleneck.GPU:
                if (!GPUBoundT.activeSelf)
                    ActivateTargetBottleneckObject(GPUBoundT);
                break;
            case PerformanceBottleneck.TargetFrameRate:
                if (!TargetFrameRateBoundT.activeSelf)
                    ActivateTargetBottleneckObject(TargetFrameRateBoundT);
                break;
            case PerformanceBottleneck.Unknown:
                if (!UnknownBoundT.activeSelf)
                    ActivateTargetBottleneckObject(UnknownBoundT);
                break;
        }
    }

    void ActivateTargetBottleneckObject(GameObject go)
    {
        CPUBoundT.SetActive(false);
        GPUBoundT.SetActive(false);
        TargetFrameRateBoundT.SetActive(false);
        UnknownBoundT.SetActive(false);
        go.SetActive(true);
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

    void DisableAllBottlenecks()
    {
        CPUBound.SetActive(false);
        GPUBound.SetActive(false);
        TargetFrameRateBound.SetActive(false);
        UnknownBound.SetActive(false);
    }

    void Activate(GameObject go)
    {
        go.SetActive(true);
    }
}
