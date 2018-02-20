using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispCam : MonoBehaviour {

    Camera _dispCam;
    public float clipPlaneOffset;
    void Start () {
        _dispCam = GetComponent<Camera>();
        RenderTexture rt = new RenderTexture(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0);
        _dispCam.targetTexture = rt;
        Shader.SetGlobalTexture("_WaterDisplacementTexture", rt);
    }
	
	// Update is called once per frame
	void Update () {
        _dispCam.fieldOfView = Camera.main.fieldOfView;
		//_dispCam.projectionMatrix = _dispCam.CalculateObliqueMatrix(CameraSpacePlane(_dispCam, Vector3.zero, Vector3.up, -1f));
    }

    // Given position/normal of the plane, calculates plane in camera space.
    Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
    {
        Vector3 offsetPos = pos + normal * clipPlaneOffset; // Calculate offset
        Matrix4x4 m = cam.worldToCameraMatrix;
        Vector3 cpos = m.MultiplyPoint(offsetPos); // Get offset position
        Vector3 cnormal = m.MultiplyVector(normal).normalized * sideSign; // Normal
        return new Vector4(cnormal.x, cnormal.y, cnormal.z, -Vector3.Dot(cpos, cnormal)); // Return plane
    }
}
