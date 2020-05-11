using UnityEngine;
using UnityEngine.AdaptivePerformance;
using System.Collections.Generic;

public class AdaptivePerformanceVisualize : MonoBehaviour
{
    [SerializeField] private Font m_Font;
    [SerializeField] private int m_FontSize = 16;
    private GUIStyle m_DefaultStyle;
    private GUIStyle m_BoldStyle;
    private List<AdaptivePerformanceScaler> m_AppliedScalers;
    private List<AdaptivePerformanceScaler> m_UnappliedScalers;

    private void Start()
    {
        m_DefaultStyle = new GUIStyle() { fontSize = m_FontSize, richText = true, normal = new GUIStyleState() { textColor = Color.white } };
        m_BoldStyle = new GUIStyle() { fontSize = m_FontSize, fontStyle = FontStyle.Bold, normal = new GUIStyleState() { textColor = Color.white } };

        m_AppliedScalers = new List<AdaptivePerformanceScaler>(16);
        m_UnappliedScalers = new List<AdaptivePerformanceScaler>(16);

        if (m_Font)
        {
            m_DefaultStyle.font = m_Font;
            m_BoldStyle.font = m_Font;
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();

        GUILayout.Label(string.Format("performance:"), m_BoldStyle);
        var currentFps = (int)(1f / Holder.Instance.PerformanceStatus.FrameTiming.AverageFrameTime);
        GUILayout.Label(string.Format("  fps: {0}", currentFps), m_DefaultStyle);
        GUILayout.Label(string.Format("  bootlneck: <b>{0}</b>", Holder.Instance.PerformanceStatus.PerformanceMetrics.PerformanceBottleneck), m_DefaultStyle);
        GUILayout.Label(string.Format("  gpu frame time: {0:0.####}s", Holder.Instance.PerformanceStatus.FrameTiming.AverageGpuFrameTime), m_DefaultStyle);
        GUILayout.Label(string.Format("  cpu frame time: {0:0.####}s", Holder.Instance.PerformanceStatus.FrameTiming.AverageCpuFrameTime), m_DefaultStyle);

        GUILayout.Label("thermal", m_BoldStyle);
        var tempTrend = Holder.Instance.ThermalStatus.ThermalMetrics.TemperatureTrend;
        if (tempTrend <= 0)
            GUILayout.Label(string.Format("  trend: <color=lime>{0:0.####}</color>", tempTrend), m_DefaultStyle);
        else
            GUILayout.Label(string.Format("  trend: <color=red>{0:0.####}</color>", tempTrend), m_DefaultStyle);
        var tempLevel = Holder.Instance.ThermalStatus.ThermalMetrics.TemperatureLevel;
        if (tempLevel < 0.8f)
            GUILayout.Label(string.Format("  level: <color=lime>{0:0.##}</color>", tempLevel), m_DefaultStyle);
        else
            GUILayout.Label(string.Format("  level: <color=red>{0:0.##}</color>", tempLevel), m_DefaultStyle);
        var tempWarning = Holder.Instance.ThermalStatus.ThermalMetrics.WarningLevel;
        if (tempWarning == WarningLevel.NoWarning)
            GUILayout.Label(string.Format("  warning: <color=lime>{0}</color>", tempWarning), m_DefaultStyle);
        else
            GUILayout.Label(string.Format("  warning: <color=red>{0}</color>", tempWarning), m_DefaultStyle);

        var indexer = Holder.Instance.Indexer;
        if (indexer != null)
        {
            GUILayout.Label(indexer.Active ? "<color=lime>indexer</color>" : "<color=red>indexer</color>", m_BoldStyle);
            if (indexer.Active)
            {
                GUILayout.Label(string.Format("  timer: <b>{0}</b>", Mathf.RoundToInt(indexer.TimeUntilNextAction)), m_DefaultStyle);
                GUILayout.Label("  applied scalers:", m_DefaultStyle);
                indexer.GetAppliedScalers(ref m_AppliedScalers);
                foreach (var scaler in m_AppliedScalers)
                    GUILayout.Label(string.Format("    name: {0} level: {1}/{2} cost: {3} <b>{4}#{5}</b>",
                        scaler.GetType().Name, scaler.CurrentLevel, scaler.MaxLevel, scaler.CalculateCost(), scaler.GpuImpact, scaler.CpuImpact), m_DefaultStyle);
                GUILayout.Label("  unapplied scalers:", m_DefaultStyle);
                indexer.GetUnappliedScaler(ref m_UnappliedScalers);
                foreach (var scaler in m_UnappliedScalers)
                    GUILayout.Label(string.Format("    name: {0} cost: {1} <b>{2}#{3}</b>",
                        scaler.GetType().Name, scaler.CalculateCost(), scaler.GpuImpact, scaler.CpuImpact), m_DefaultStyle);
                var perfAction = indexer.PerformanceAction;
                if (perfAction != StateAction.Decrease && perfAction != StateAction.FastDecrease)
                    GUILayout.Label(string.Format("  performance action: <color=lime>{0}</color>", perfAction), m_DefaultStyle);
                else
                    GUILayout.Label(string.Format("  performance action: <color=red>{0}</color>", perfAction), m_DefaultStyle);
                var tempAction = indexer.ThermalAction;
                if (tempAction != StateAction.Decrease && perfAction != StateAction.FastDecrease)
                    GUILayout.Label(string.Format("  thermal action: <color=lime>{0}</color>", tempAction), m_DefaultStyle);
                else
                    GUILayout.Label(string.Format("  thermal action: <color=red>{0}</color>", tempAction), m_DefaultStyle);
            }
            if (GUILayout.Button(indexer.Active ? "turn off" : "turn on"))
                indexer.Active = !indexer.Active;
        }

        GUILayout.EndVertical();
    }
}
