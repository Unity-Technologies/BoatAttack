using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AdaptivePerformance;

public class ShowFPS : MonoBehaviour
{
    public Text TargetFPS, CurrentFPS, RefreshRate;

    float frameAverage;
    IPerformanceStatus perfStatus;

    void Start()
    {
        var ap = Holder.Instance;
        if (ap == null || !ap.Active)
        {
            Debug.Log("[AP APC] Adaptive Performance not active");
            enabled = false;
            return;
        }
        perfStatus = ap.PerformanceStatus;
        TargetFPS.text = Application.targetFrameRate.ToString();
    }

    void Update()
    {
        frameAverage = 1 / perfStatus.FrameTiming.AverageFrameTime;
        CurrentFPS.text = frameAverage.ToString("F2");
        TargetFPS.text = Application.targetFrameRate.ToString();
        RefreshRate.text = Screen.currentResolution.refreshRate.ToString();
    }
}
