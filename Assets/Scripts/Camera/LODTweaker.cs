using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

[ExecuteInEditMode]
public class LODTweaker : MonoBehaviour {

	void SetMaxLOD(Camera cam)
	{
        if (cam == Camera.main)
        {
            QualitySettings.lodBias = 2;
        }
        else
        {
            QualitySettings.lodBias = 0.5f;
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
