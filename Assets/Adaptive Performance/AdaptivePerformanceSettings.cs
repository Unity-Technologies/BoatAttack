using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceSettings : MonoBehaviour
{
    public bool AdaptiveBatching = false;
    public bool AdaptiveFramerate = false;
    public bool AdaptiveLOD = false;
    public bool AdaptiveLut = false;
    public bool AdaptiveMSAA = false;
    public bool AdaptiveResolution = false;
    public bool AdaptiveShadowCascades = false;
    public bool AdaptiveShadowDistance = false;
    public bool AdaptiveShadowmapResolution = false;
    public bool AdaptiveShadowQuality = false;
    public bool AdaptiveSorting = false;
    public bool AdaptiveVRR = false;

    private void Awake()
    {
        if (!AdaptivePerformanceGeneralSettings.Instance || !AdaptivePerformanceGeneralSettings.Instance.Manager || !AdaptivePerformanceGeneralSettings.Instance.Manager.isInitializationComplete)
            return;

        IAdaptivePerformanceSettings settings = AdaptivePerformanceGeneralSettings.Instance.Manager.activeLoader.GetSettings();
        if (settings == null)
            return;

        settings.scalerSettings.AdaptiveBatching.enabled = AdaptiveBatching;
        settings.scalerSettings.AdaptiveFramerate.enabled = AdaptiveFramerate;
        settings.scalerSettings.AdaptiveLOD.enabled = AdaptiveLOD;
        settings.scalerSettings.AdaptiveLut.enabled = AdaptiveLut;
        settings.scalerSettings.AdaptiveMSAA.enabled = AdaptiveMSAA;
        settings.scalerSettings.AdaptiveResolution.enabled = AdaptiveResolution;
        settings.scalerSettings.AdaptiveShadowCascades.enabled = AdaptiveShadowCascades;
        settings.scalerSettings.AdaptiveShadowDistance.enabled = AdaptiveShadowDistance;
        settings.scalerSettings.AdaptiveShadowmapResolution.enabled = AdaptiveShadowmapResolution;
        settings.scalerSettings.AdaptiveShadowQuality.enabled = AdaptiveShadowQuality;
        settings.scalerSettings.AdaptiveSorting.enabled = AdaptiveSorting;
        var adaptiveVRR = GameObject.FindObjectOfType<AdaptiveVariableRefreshRate>();
        if (adaptiveVRR)
            adaptiveVRR.Enabled = AdaptiveVRR;
    }
}
