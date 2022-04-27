using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AdaptivePerformance;

public class ScalerProfileListItem : MonoBehaviour
{
    public Text ScalerProfileName;

    public void LoadScalerProfile()
    {
        IAdaptivePerformanceSettings settings = AdaptivePerformanceGeneralSettings.Instance.Manager.activeLoader.GetSettings();
        if (settings == null)
            return;

        if (ScalerProfileName != null && ScalerProfileName.text.Length != 0)
        {
            Debug.Log($"[Scaler Profile Sample] Load Scaler profile {ScalerProfileName.text}");
            settings.LoadScalerProfile(ScalerProfileName.text);
        }
        else
            Debug.Log($"[Scaler Profile Sample] No scaler profiles availalbe to load. Please add at least 2 profiles.");
    }
}
