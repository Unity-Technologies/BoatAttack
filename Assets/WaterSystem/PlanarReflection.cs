using UnityEngine;
using System.Collections;

// This is in fact just the Water script from Pro Standard Assets,
// just with refraction stuff removed.

[ExecuteInEditMode] // Make mirror live-update even when not in play mode
public class PlanarReflection : MonoBehaviour
{
    public int m_TextureSize = 256;
    public float m_ClipPlaneOffset = 0.07f;

    public LayerMask m_ReflectLayers = -1;

    private Camera _refCamera;
    private RenderTexture m_ReflectionTexture = null;
    private int m_OldReflectionTextureSize = 0;

    private static bool s_InsideRendering = false;

    // This is called when it's known that the object will be rendered by some
    // camera. We render reflections and do other updates here.
    // Because the script executes in edit mode, reflections for the scene view
    // camera will just work!
    public void OnWillRenderObject()
    {
        var rend = GetComponent<Renderer>();
        if (!enabled || !rend || !rend.enabled)
            return;

        Camera cam = Camera.current;
        if (!cam)
            cam = Camera.main;
        if (!cam)
            return;

        // Safeguard from recursive reflections.        
        if (s_InsideRendering)
            return;
        s_InsideRendering = true;

        //Camera reflectionCamera;
        if(!_refCamera)
            CreateMirrorObjects(cam, out _refCamera);

        // find out the reflection plane: position and normal in world space
        Vector3 pos = transform.position;
        Vector3 normal = transform.up;

        UpdateCameraModes(cam, _refCamera);

        // Render reflection
        // Reflect camera around reflection plane
        float d = -Vector3.Dot(normal, pos) - m_ClipPlaneOffset;
        Vector4 reflectionPlane = new Vector4(normal.x, normal.y, normal.z, d);

        Matrix4x4 reflection = Matrix4x4.identity;
        reflection *= Matrix4x4.Scale(new Vector3(1, -1, 1));

        //CalculateReflectionMatrix(ref reflection, reflectionPlane);
        Vector3 oldpos = cam.transform.position - new Vector3(0, transform.position.y * 2, 0);
        Vector3 newpos = ReflectPosition(oldpos); //reflection.MultiplyPoint(oldpos);
        _refCamera.transform.forward = Vector3.Scale(cam.transform.forward, new Vector3(1, -1, 1));
        //_refCamera.transform.Rotate(_refCamera.transform.forward, 360f-cam.transform.localEulerAngles.z, Space.Self);
        //_refCamera.worldToCameraMatrix = cam.worldToCameraMatrix;// * reflection;

        // Setup oblique projection matrix so that near plane is our reflection
        // plane. This way we clip everything below/above it for free.
        Vector4 clipPlane = CameraSpacePlane(_refCamera, pos, normal, 1.0f);
        //Matrix4x4 projection = cam.projectionMatrix;
        Matrix4x4 projection = cam.CalculateObliqueMatrix(clipPlane);
        _refCamera.projectionMatrix = projection;

        _refCamera.cullingMask = ~(1 << 4) & m_ReflectLayers.value; // never render water layer
        
        //GL.invertCulling = true;
        _refCamera.transform.position = newpos;
        //Vector3 euler = cam.transform.eulerAngles;
        //_refCamera.transform.eulerAngles = new Vector3(0, euler.y, euler.z);
        //_refCamera.Render();
        //_refCamera.transform.position = oldpos;
        //GL.invertCulling = false;

        Shader.SetGlobalTexture("_PlanarReflectionTexture", m_ReflectionTexture);

        s_InsideRendering = false;
    }


    // Cleanup all the objects we possibly have created
    void OnDisable()
    {
        if(_refCamera)
        {
            _refCamera.targetTexture = null;
            DestroyImmediate(_refCamera.gameObject);
        }
        if (m_ReflectionTexture)
        {
            DestroyImmediate(m_ReflectionTexture);
        }
        //m_ReflectionCameras.Clear();
    }


    private void UpdateCameraModes(Camera src, Camera dest)
    {
        if (dest == null)
            return;
        // set camera to clear the same way as current camera
        dest.clearFlags = src.clearFlags;
        dest.backgroundColor = src.backgroundColor;
        // update other values to match current camera.
        // even if we are supplying custom camera&projection matrices,
        // some of values are used elsewhere (e.g. skybox uses far plane)
        dest.farClipPlane = src.farClipPlane;
        dest.nearClipPlane = src.nearClipPlane;
        dest.orthographic = src.orthographic;
        dest.fieldOfView = src.fieldOfView;
        dest.allowHDR = src.allowHDR;
        dest.aspect = src.aspect;
        dest.orthographicSize = src.orthographicSize;
    }

    // On-demand create any objects we need
    private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera)
    {
        reflectionCamera = null;

        // Reflection render texture
        if (!m_ReflectionTexture || m_OldReflectionTextureSize != m_TextureSize)
        {
            if (m_ReflectionTexture)
                DestroyImmediate(m_ReflectionTexture);
            m_ReflectionTexture = new RenderTexture(m_TextureSize, m_TextureSize / 2, 16, RenderTextureFormat.ARGBHalf);
            m_ReflectionTexture.useMipMap = true;
            m_ReflectionTexture.autoGenerateMips = true;
            m_ReflectionTexture.name = "_PlanarReflection" + GetInstanceID();
            m_ReflectionTexture.isPowerOfTwo = true;
            m_ReflectionTexture.hideFlags = HideFlags.DontSave;
            m_OldReflectionTextureSize = m_TextureSize;
        }

        // Camera for reflection
        //reflectionCamera = Camera.current;// as Camera;
        if (!reflectionCamera) // catch both not-in-dictionary and in-dictionary-but-deleted-GO
        {
            GameObject go = new GameObject("Planar Refl Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(), typeof(Camera), typeof(Skybox));
            reflectionCamera = go.GetComponent<Camera>();
            //reflectionCamera.enabled = false;
            reflectionCamera.transform.position = transform.position;
            reflectionCamera.transform.rotation = transform.rotation;
            reflectionCamera.targetTexture = m_ReflectionTexture;
            reflectionCamera.allowMSAA = false;
            //reflectionCamera.clearFlags = CameraClearFlags.Depth;
            go.hideFlags = HideFlags.HideAndDontSave;
        }

        
    }

    // Extended sign: returns -1, 0 or 1 based on sign of a
    private static float sgn(float a)
    {
        if (a > 0.0f) return 1.0f;
        if (a < 0.0f) return -1.0f;
        return 0.0f;
    }

    // Given position/normal of the plane, calculates plane in camera space.
    private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
    {
        Vector3 offsetPos = pos + normal * m_ClipPlaneOffset;
        Matrix4x4 m = cam.worldToCameraMatrix;
        Vector3 cpos = m.MultiplyPoint(offsetPos);
        Vector3 cnormal = m.MultiplyVector(normal).normalized * sideSign;
        return new Vector4(cnormal.x, cnormal.y, cnormal.z, -Vector3.Dot(cpos, cnormal));
    }

    // Calculates reflection matrix around the given plane
    private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
    {
        reflectionMat.m00 = (1F - 2F * plane[0] * plane[0]);
        reflectionMat.m01 = (-2F * plane[0] * plane[1]);
        reflectionMat.m02 = (-2F * plane[0] * plane[2]);
        reflectionMat.m03 = (-2F * plane[3] * plane[0]);

        reflectionMat.m10 = (-2F * plane[1] * plane[0]);
        reflectionMat.m11 = (1F - 2F * plane[1] * plane[1]);
        reflectionMat.m12 = (-2F * plane[1] * plane[2]);
        reflectionMat.m13 = (-2F * plane[3] * plane[1]);

        reflectionMat.m20 = (-2F * plane[2] * plane[0]);
        reflectionMat.m21 = (-2F * plane[2] * plane[1]);
        reflectionMat.m22 = (1F - 2F * plane[2] * plane[2]);
        reflectionMat.m23 = (-2F * plane[3] * plane[2]);

        reflectionMat.m30 = 0F;
        reflectionMat.m31 = 0F;
        reflectionMat.m32 = 0F;
        reflectionMat.m33 = 1F;
    }

    private static Vector3 ReflectPosition(Vector3 pos)
    {
        Vector3 newPos = new Vector3(pos.x, -pos.y, pos.z);
        return newPos;
    }
}