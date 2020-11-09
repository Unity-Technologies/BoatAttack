using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private void OnEnable()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }

    private void OnDestroy()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Normal;
    }

    public void SetLoad(float load = 0.0f)
    {
        if (loadingText)
        {
            loadingText.text = $"{load * 100f}% Loading...";
        }
    }
}
