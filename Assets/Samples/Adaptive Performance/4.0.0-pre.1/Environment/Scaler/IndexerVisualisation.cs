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
    public Toggle ShowDisabledScaler;

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
        if (scaler.Enabled || ShowDisabledScaler.isOn)
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
