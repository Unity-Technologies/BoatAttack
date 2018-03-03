using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

public class ShadowOnlyPass : MonoBehaviour {

	private Light _light;

	void Start()
	{
        _light = GetComponent<Light>();
    }

	void ShadowCheck(Camera cam)
	{
        if (_light)
        {
            if (cam == Camera.main)
                _light.shadows = LightShadows.Soft;
            else
                _light.shadows = LightShadows.None;
        }
    }

    void OnEnable()
    {
        LightweightPipeline.beginCameraRendering += ShadowCheck;
    }

    // Cleanup all the objects we possibly have created
    void OnDisable()
    {
        LightweightPipeline.beginCameraRendering -= ShadowCheck;
    }

}
