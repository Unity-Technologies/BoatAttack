using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

public class LODTweaker : MonoBehaviour {

	void SetMaxLOD(Camera cam)
	{
        if (cam == Camera.main)
        {
            QualitySettings.maximumLODLevel = 0;
        }
        else
        {
            QualitySettings.maximumLODLevel = 2;
        }
    }

    void OnEnable()
    {
        LightweightPipeline.beginCameraRendering += SetMaxLOD;
    }

    void OnDisable()
    {
        LightweightPipeline.beginCameraRendering -= SetMaxLOD;
    }

}
