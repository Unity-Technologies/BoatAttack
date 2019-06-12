using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;

public class Postv3Autofocus : MonoBehaviour
{
    public VolumeProfile profile;

    private DepthOfField dof;

    public CinemachineBrain cm;
    
    // Update is called once per frame
    void Update()
    {
        if (profile && cm)
        {
            profile.TryGet(out dof);

            CameraState state = cm.CurrentCameraState;

            if (dof)
                dof.focusDistance.value = (state.FinalPosition - state.ReferenceLookAt).magnitude;
        }
    }
}
