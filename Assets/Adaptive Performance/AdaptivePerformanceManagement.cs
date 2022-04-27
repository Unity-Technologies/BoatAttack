using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class AdaptivePerformanceManagement : MonoBehaviour
{
    IAdaptivePerformance ap;

    public static AdaptivePerformanceManagement Instance;
    // Start is called before the first frame update
    void Start()
    {
        ap = Holder.Instance;
        if (ap == null || !ap.Active)
        {
            Debug.Log("[APMGM] Adaptive Performance is not Active");
            enabled = false;
            return;
        }
    }

    private void OnEnable()
    {
        Instance = this;
    }

    public void Boost()
    {
        ap.DevicePerformanceControl.CpuPerformanceBoost = true;
        ap.DevicePerformanceControl.GpuPerformanceBoost = true;
    }
}
