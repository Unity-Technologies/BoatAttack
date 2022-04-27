using UnityEngine;
using UnityEngine.AdaptivePerformance;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    private IAdaptivePerformance ap;

    public GameObject CPUNoBoost, CPUBoost;
    public GameObject GPUNoBoost, GPUBoost;

    void Start()
    {
        ap = Holder.Instance;
        if (ap == null || !ap.Active)
        {
            Debug.Log("[AP BoostUI] Adaptive Performance not active");
            return;
        }
        ap.PerformanceStatus.PerformanceBoostChangeEvent += OnBoostModeEvent;
        Activate(CPUNoBoost);
        Activate(GPUNoBoost);
    }

    private void OnDestroy()
    {
        if (ap == null || !ap.Active)
            return;

        ap.PerformanceStatus.PerformanceBoostChangeEvent -= OnBoostModeEvent;
    }

    void OnBoostModeEvent(PerformanceBoostChangeEventArgs ev)
    {
        DisableAllBoostModes();
        if (ev.CpuBoost)
            Activate(CPUBoost);
        else
            Activate(CPUNoBoost);

        if (ev.GpuBoost)
            Activate(GPUBoost);
        else
            Activate(GPUNoBoost);
    }

    void DisableAllBoostModes()
    {
        CPUNoBoost.SetActive(false);
        CPUBoost.SetActive(false);
        GPUNoBoost.SetActive(false);
        GPUBoost.SetActive(false);
    }

    void Activate(GameObject go)
    {
        go.SetActive(true);
    }
}
