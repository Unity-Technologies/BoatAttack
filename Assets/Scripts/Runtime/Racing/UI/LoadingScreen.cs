using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    private float _tick;
    private int _vsyncBackup;
    private int _targetFramesBackup;
    private static float _progress;
    
    private void OnEnable()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        _vsyncBackup = QualitySettings.vSyncCount;
        QualitySettings.vSyncCount = 0;
        _targetFramesBackup = Application.targetFrameRate;
        Application.targetFrameRate = 15;
    }

    private void OnDestroy()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Normal;
        QualitySettings.vSyncCount = _vsyncBackup;
        Application.targetFrameRate = _targetFramesBackup;
    }

    private void Update()
    {
        SetLoad();
    }

    private void SetLoad()
    {
        if (!loadingText) return;
        
        _tick = Mathf.Repeat(_tick, 3f);
        loadingText.text = (int)_tick switch
        {
            0 => "Loading .",
            1 => "Loading ..",
            2 => "Loading ...",
            _ => loadingText.text
        };
        _tick += Time.unscaledDeltaTime;
    }

    public static void SetProgress(float progress)
    {
        _progress = progress;
    }
}
