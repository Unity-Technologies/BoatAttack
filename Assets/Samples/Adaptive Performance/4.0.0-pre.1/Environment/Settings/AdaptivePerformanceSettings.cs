using UnityEngine;
using UnityEngine.AdaptivePerformance;

static class AdaptivePerformanceConfig
{
    /// <summary>
    /// In case you want to manually override settings during startup, this can be done with the IAdaptivePerformanceSettings.
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void Setup()
    {
        if (!AdaptivePerformanceGeneralSettings.Instance || !AdaptivePerformanceGeneralSettings.Instance.Manager || !AdaptivePerformanceGeneralSettings.Instance.Manager.isInitializationComplete)
            return;

        IAdaptivePerformanceSettings settings = AdaptivePerformanceGeneralSettings.Instance.Manager.activeLoader.GetSettings();
        if (settings == null)
            return;

        settings.automaticPerformanceMode = false;
        settings.logging = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
        Debug.Log($"AdaptivePerformanceConfig setting automatic performance mode to {settings.automaticPerformanceMode},logging to {settings.logging} targetFrameRate to {Application.targetFrameRate}. Override in Sample on demand.");
    }
}


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
    public bool AdaptiveTransparency = false;
    public bool AdaptiveSorting = false;
    public bool AdaptiveViewDistance = false;
    public bool AdaptiveVRR = false;
    public bool AdaptivePhysics = false;
    public bool AdaptiveDecals = false;
    public bool AdaptiveLayerCulling = false;

    /// <summary>
    /// In case you want to manually override settings from the Setting menu during awake, this can be done with the IAdaptivePerformanceSettings.
    /// </summary>
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
        settings.scalerSettings.AdaptiveShadowCascade.enabled = AdaptiveShadowCascades;
        settings.scalerSettings.AdaptiveShadowDistance.enabled = AdaptiveShadowDistance;
        settings.scalerSettings.AdaptiveShadowmapResolution.enabled = AdaptiveShadowmapResolution;
        settings.scalerSettings.AdaptiveShadowQuality.enabled = AdaptiveShadowQuality;
        settings.scalerSettings.AdaptiveSorting.enabled = AdaptiveSorting;
        settings.scalerSettings.AdaptiveTransparency.enabled = AdaptiveTransparency;
        settings.scalerSettings.AdaptiveViewDistance.enabled = AdaptiveViewDistance;
#if UNITY_ADAPTIVE_PERFORMANCE_SAMSUNG_ANDROID
        var adaptiveVRR = GameObject.FindObjectOfType<AdaptiveVariableRefreshRate>();
        if (adaptiveVRR)
            adaptiveVRR.Enabled = AdaptiveVRR;
#endif
        settings.scalerSettings.AdaptivePhysics.enabled = AdaptivePhysics;
        settings.scalerSettings.AdaptiveDecals.enabled = AdaptiveDecals;
        settings.scalerSettings.AdaptiveLayerCulling.enabled = AdaptiveLayerCulling;
    }
}
