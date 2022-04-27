using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;


public class ScalerProfileChanger : MonoBehaviour
{
    public ScalerProfileListItem Representation;
    public RectTransform Content;

    void Start()
    {
        IAdaptivePerformanceSettings settings = AdaptivePerformanceGeneralSettings.Instance.Manager.activeLoader?.GetSettings();
        if (settings == null)
            return;

        var scalerProfiles = settings.GetAvailableScalerProfiles();
        foreach (var scalerProfile in scalerProfiles)
        {
            Debug.Log($"[Scaler Profile Sample] Scaler Profile: {scalerProfile} added.");
            var spawnedListItem = Instantiate(Representation, Content);
            spawnedListItem.ScalerProfileName.text = scalerProfile;
        }
    }
}
