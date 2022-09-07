using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;

public class ToggleAP : MonoBehaviour
{
    public Toggle adaptivePerformanceRunning;

    public void Toggle()
    {
        if (adaptivePerformanceRunning.isOn)
            Holder.Instance.StartAdaptivePerformance();
        else
            Holder.Instance.StopAdaptivePerformance();        
    }
}
