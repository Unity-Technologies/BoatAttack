using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuVideo : MonoBehaviour
{
    private bool blurred;

    private void OnEnable()
    {
        if (!TryGetComponent(out VideoPlayer video)) return;
        
        //if(video.targetCamera == null)
            video.targetCamera = Camera.main;
    }

    public void ToggleBlurred()
    {
        blurred = !blurred;
        KawaseBlur.KawasePass.Enabled = blurred;
    }
    
    public void SetBlurred(bool enabled)
    {
        blurred = enabled;
        KawaseBlur.KawasePass.Enabled = enabled;
    }
}
