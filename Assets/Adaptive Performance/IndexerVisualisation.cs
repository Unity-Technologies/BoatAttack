using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AdaptivePerformance;
using System.Collections.Generic;

public class IndexerVisualisation : MonoBehaviour
{
    public Text Timer;
    public Text Bottleneck;
    public Text PerformanceAction;
    public Text ThermalAction;
    public Text GpuFrameTime;
    public Text CpuFrameTime;
    public Transform Content;
    public ScalerVisualisation ScalerVisualisationPrefab;
    public Camera m_MainCams;
    public Camera m_APCam;

    List<ScalerVisualisation> m_ScalerVisualisations;
    List<AdaptivePerformanceScaler> m_AppliedScalers;
    List<AdaptivePerformanceScaler> m_UnappliedScalers;
    List<AdaptivePerformanceScaler> m_DisabledScalers;
    AdaptivePerformanceIndexer m_Indexer;

    private void Start()
    {
        var ap = Holder.Instance;
        if (ap == null || !ap.Active)
        {
            Debug.Log("[AP Indexer Visualisation] Adaptive Performance not active");
            enabled = false;
            return;
        }

        m_Indexer = Holder.Instance.Indexer;
        if (m_Indexer == null)
        {
            Debug.Log("[AP Indexer Visualisation] No indexer available");
            enabled = false;
            return;
        }

        m_ScalerVisualisations = new List<ScalerVisualisation>();
        m_AppliedScalers = new List<AdaptivePerformanceScaler>();
        m_UnappliedScalers = new List<AdaptivePerformanceScaler>();
        m_DisabledScalers = new List<AdaptivePerformanceScaler>();
    }

    private void Update()
    {
        if (!enabled)
            return;

        Apply();
    }

    public void SwitchCamera()
    {
        if(!m_APCam.enabled)
        {
            m_MainCams.enabled = false;
            m_APCam.enabled = true;
        }
        else
        {
            m_MainCams.enabled = true;
            m_APCam.enabled = false;
        }
    }

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
    public int m_activeScalerIndex = 0;

    public void NextScaler()
    {

        if (!AdaptivePerformanceGeneralSettings.Instance || !AdaptivePerformanceGeneralSettings.Instance.Manager || !AdaptivePerformanceGeneralSettings.Instance.Manager.isInitializationComplete)
            return;

        IAdaptivePerformanceSettings settings = AdaptivePerformanceGeneralSettings.Instance.Manager.activeLoader.GetSettings();
        if (settings == null)
            return;

        AdaptiveBatching = false;
        AdaptiveFramerate = false;
        AdaptiveLOD = false;
        AdaptiveLut = false;
        AdaptiveMSAA = false;
        AdaptiveResolution = false;
        AdaptiveShadowCascades = false;
        AdaptiveShadowDistance = false;
        AdaptiveShadowmapResolution = false;
        AdaptiveShadowQuality = false;
        AdaptiveSorting = false;
        AdaptiveVRR = false;

        switch(m_activeScalerIndex)
        {
            case 0: AdaptiveBatching = true; break;
            case 1: AdaptiveFramerate = true; break;
            case 2: AdaptiveLOD = true; break;
            case 3: AdaptiveLut = true; break;
            case 4: AdaptiveMSAA = true; break;
            case 5: AdaptiveResolution = true; break;
            case 6: AdaptiveShadowCascades = true; break;
            case 7: AdaptiveShadowDistance = true; break;
            case 8: AdaptiveShadowmapResolution = true; break;
            case 9: AdaptiveShadowQuality = true; break;
            case 10: AdaptiveSorting = true; break;
            case 11: AdaptiveVRR = true; break;
        }

        m_activeScalerIndex++;
        if (m_activeScalerIndex >= 12)
            m_activeScalerIndex = 0;

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

    private void Apply()
    {
        Debug.Assert(Timer);
        Debug.Assert(Bottleneck);
        Debug.Assert(PerformanceAction);
        Debug.Assert(ThermalAction);
        Debug.Assert(GpuFrameTime);
        Debug.Assert(CpuFrameTime);
        Debug.Assert(Content);
        Debug.Assert(ScalerVisualisationPrefab);


        Timer.text = $"  Timer: <b>{Mathf.RoundToInt(m_Indexer.TimeUntilNextAction)}</b>";
        Bottleneck.text =
            $"  Bottleneck: <b>{Holder.Instance.PerformanceStatus.PerformanceMetrics.PerformanceBottleneck}</b>";

        var perfAction = m_Indexer.PerformanceAction;
        if (perfAction != StateAction.Decrease && perfAction != StateAction.FastDecrease)
            PerformanceAction.text = $"  Perf action: <color=lime>{perfAction}</color>";
        else
            PerformanceAction.text = $"  Perf action: <color=red>{perfAction}</color>";

        var tempAction = m_Indexer.ThermalAction;
        if (tempAction != StateAction.Decrease && tempAction != StateAction.FastDecrease)
            ThermalAction.text = $"  Thermal action: <color=lime>{tempAction}</color>";
        else
            ThermalAction.text = $"  Thermal action: <color=red>{tempAction}</color>";

        GpuFrameTime.text =
            $"  GPU frame time: {Holder.Instance.PerformanceStatus.FrameTiming.AverageGpuFrameTime:0.####}s";
        CpuFrameTime.text =
            $"  CPU frame time: {Holder.Instance.PerformanceStatus.FrameTiming.AverageCpuFrameTime:0.####}s";

        m_Indexer.GetAppliedScalers(ref m_AppliedScalers);
        foreach (var scaler in m_AppliedScalers)
            CreateScalerVisualisation(scaler);

        m_Indexer.GetUnappliedScalers(ref m_UnappliedScalers);
        foreach (var scaler in m_UnappliedScalers)
            CreateScalerVisualisation(scaler);

        m_Indexer.GetDisabledScalers(ref m_DisabledScalers);
        foreach (var scaler in m_DisabledScalers)
            CreateScalerVisualisation(scaler);
    }

    private void CreateScalerVisualisation(AdaptivePerformanceScaler scaler)
    {
        var scalerVisualisation = ContainsScaler(scaler);
        if (scalerVisualisation == null)
        {
            scalerVisualisation = Instantiate(ScalerVisualisationPrefab, Content);
            scalerVisualisation.Scaler = scaler;
            m_ScalerVisualisations.Add(scalerVisualisation);
        }
        if (scaler.Enabled)
            scalerVisualisation.gameObject.SetActive(true);
        else
            scalerVisualisation.gameObject.SetActive(false);
    }

    private ScalerVisualisation ContainsScaler(AdaptivePerformanceScaler scaler)
    {
        foreach (var current in m_ScalerVisualisations)
        {
            if (current.Scaler == scaler)
                return current;
        }
        return null;
    }
}
