using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class AdaptiveFrameRateVRR : MonoBehaviour
{
    void Awake()
    {
        AdaptiveVariableRefreshRate AdaptiveVRRO = GameObject.FindObjectOfType<AdaptiveVariableRefreshRate>();
        if (!AdaptiveVRRO)
            return;

        AdaptiveVRRO.Enabled = true;

        AdaptiveVRRO.MinBound = 15;
        AdaptiveVRRO.MaxBound = 30;

        Debug.Log("Adaptive VRR deactivated by script.");

    }
}
