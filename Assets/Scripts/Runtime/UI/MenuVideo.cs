using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuVideo : MonoBehaviour
{
    private bool blurred;

    public VideoPlayer video;
    
    private void OnEnable()
    {
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
