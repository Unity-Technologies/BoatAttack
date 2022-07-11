using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private int _tick = 0;
    
    private void OnEnable()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }

    private void OnDestroy()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Normal;
    }

    private void Update()
    {
        if (!loadingText) return;
        
        _tick = (int)Mathf.Repeat(_tick, 3);
        loadingText.text = _tick switch
        {
            0 => "Loading .",
            1 => "Loading ..",
            2 => "Loading ...",
            _ => loadingText.text
        };
        _tick++;
    }

    public void SetLoad(float load = 0.0f)
    {
        if (loadingText)
        {
            loadingText.text = $"{load * 100f}% Loading...";
        }
    }
}
