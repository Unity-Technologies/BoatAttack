using System;
using Unity.Mathematics;
using UnityEngine.Rendering;
using WaterSystem;

namespace UnityEngine.Experimental.Rendering.LightweightPipeline
{
    [ImageEffectAllowedInSceneView]
    public class PlanerReflections : MonoBehaviour, LightweightPipeline.IBeforeCameraRender
    {
        [System.Serializable]
        public enum ResolutionMulltiplier
        {
            Full,
            Half,
            Third,
            Quarter
        }
        
        [System.Serializable]
        public class PlanarReflectionSettings
        {
            public ResolutionMulltiplier m_ResolutionMultiplier = ResolutionMulltiplier.Third;
            public float m_ClipPlaneOffset = 0.07f;
            public LayerMask m_ReflectLayers = -1;
        }

        
        [SerializeField]
        public PlanarReflectionSettings m_settings = new PlanarReflectionSettings();

        public GameObject target;
        
        private Camera m_ReflectionCamera;
        private int2 m_TextureSize = new int2(256, 128);
        private RenderTexture m_ReflectionTexture = null;
        
        
        private int2 m_OldReflectionTextureSize;

        // Cleanup all the objects we possibly have created
        void OnDisable()
        {
            if(m_ReflectionCamera)
            {
                m_ReflectionCamera.targetTexture = null;
                DestroyImmediate(m_ReflectionCamera.gameObject);
            }
            if (m_ReflectionTexture)
            {
                DestroyImmediate(m_ReflectionTexture);
            }
        }
        
        private void UpdateCamera(Camera src, Camera dest)
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
            dest.useOcclusionCulling = false;
            dest.aspect = src.aspect;
            dest.orthographicSize = src.orthographicSize;
        }

        
        private void UpdateReflectionCamera(Camera realCamera)
        {
            if (m_ReflectionCamera == null)
                m_ReflectionCamera = CreateMirrorObjects(realCamera);
            
            // find out the reflection plane: position and normal in world space
            Vector3 pos = Vector3.zero;
            Vector3 normal = Vector3.up;
            if (target != null)
            {
                pos = target.transform.position;
                normal = target.transform.up;
            }

            UpdateCamera(realCamera, m_ReflectionCamera);
            
            // Render reflection
            // Reflect camera around reflection plane
            float d = -Vector3.Dot(normal, pos) - m_settings.m_ClipPlaneOffset;
            Vector4 reflectionPlane = new Vector4(normal.x, normal.y, normal.z, d);

            Matrix4x4 reflection = Matrix4x4.identity;
            reflection *= Matrix4x4.Scale(new Vector3(1, -1, 1));

            CalculateReflectionMatrix(ref reflection, reflectionPlane);
            Vector3 oldpos = realCamera.transform.position - new Vector3(0, pos.y * 2, 0);
            Vector3 newpos = ReflectPosition(oldpos);
            m_ReflectionCamera.transform.forward = Vector3.Scale(realCamera.transform.forward, new Vector3(1, -1, 1));
            m_ReflectionCamera.worldToCameraMatrix = realCamera.worldToCameraMatrix * reflection;

            // Setup oblique projection matrix so that near plane is our reflection
            // plane. This way we clip everything below/above it for free.
            Vector4 clipPlane = CameraSpacePlane(m_ReflectionCamera, pos - Vector3.up * 0.1f, normal, 1.0f);
            Matrix4x4 projection = realCamera.CalculateObliqueMatrix(clipPlane);
            m_ReflectionCamera.projectionMatrix = projection;
            m_ReflectionCamera.cullingMask = m_settings.m_ReflectLayers; // never render water layer
            m_ReflectionCamera.transform.position = newpos;
                
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

        private float GetScaleValue()
        {
            switch(m_settings.m_ResolutionMultiplier)
            {
                case ResolutionMulltiplier.Full:
                    return 1f;
                case ResolutionMulltiplier.Half:
                    return 0.5f;
                case ResolutionMulltiplier.Third:
                    return 0.33f;
                case ResolutionMulltiplier.Quarter:
                    return 0.25f;
            }
            return 0.5f; // default to half res
        }
        
        // Compare two int2
        private static bool Int2Compare(int2 a, int2 b)
        {
            if(a.x == b.x && a.y == b.y)
                return true;
            else
                return false;
        }

        // Given position/normal of the plane, calculates plane in camera space.
        private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
        {
            Vector3 offsetPos = pos + normal * m_settings.m_ClipPlaneOffset;
            Matrix4x4 m = cam.worldToCameraMatrix;
            Vector3 cpos = m.MultiplyPoint(offsetPos);
            Vector3 cnormal = m.MultiplyVector(normal).normalized * sideSign;
            return new Vector4(cnormal.x, cnormal.y, cnormal.z, -Vector3.Dot(cpos, cnormal));
        }

        private Camera CreateMirrorObjects(Camera currentCamera)
        {
            LightweightPipelineAsset lwAsset = (LightweightPipelineAsset) GraphicsSettings.renderPipelineAsset;
            var resMulti = lwAsset.renderScale * GetScaleValue();
            m_TextureSize.x = (int) Mathf.Pow(2, Mathf.RoundToInt(Mathf.Log(currentCamera.pixelWidth * resMulti, 2)));
            m_TextureSize.y = (int) Mathf.Pow(2, Mathf.RoundToInt(Mathf.Log(currentCamera.pixelHeight * resMulti, 2)));
            // Reflection render texture
            if (Int2Compare(m_TextureSize, m_OldReflectionTextureSize) || !m_ReflectionTexture)
            {
                if (m_ReflectionTexture)
                    DestroyImmediate(m_ReflectionTexture);
                m_ReflectionTexture = new RenderTexture(m_TextureSize.x, m_TextureSize.y, 16,
                    currentCamera.allowHDR ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default);
                m_ReflectionTexture.useMipMap = m_ReflectionTexture.autoGenerateMips = false;
                m_ReflectionTexture.autoGenerateMips = false; // no need for mips(unless wanting cheap roughness)
                m_ReflectionTexture.name = "_PlanarReflection" + GetInstanceID();
                m_ReflectionTexture.isPowerOfTwo = true;
                m_ReflectionTexture.hideFlags = HideFlags.DontSave;
                m_OldReflectionTextureSize = m_TextureSize;
            }

            m_ReflectionTexture.DiscardContents();

            GameObject go =
                new GameObject("Planar Refl Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(),
                    typeof(Camera), typeof(Skybox));
            LightweightAdditionalCameraData lwrpCamData =
                go.AddComponent(typeof(LightweightAdditionalCameraData)) as LightweightAdditionalCameraData;
            lwrpCamData.renderShadows = false; // turn off shadows for the reflection camera
            var reflectionCamera = go.GetComponent<Camera>();
            reflectionCamera.transform.SetPositionAndRotation(transform.position, transform.rotation);
            reflectionCamera.targetTexture = m_ReflectionTexture;
            reflectionCamera.allowMSAA = true;
            reflectionCamera.depth = -10;
            reflectionCamera.enabled = false;
            go.hideFlags = HideFlags.HideAndDontSave;

            Shader.SetGlobalTexture("_PlanarReflectionTexture", m_ReflectionTexture);
            return reflectionCamera;
        }

        public void ExecuteBeforeCameraRender(
            LightweightPipeline pipelineInstance,
            ScriptableRenderContext context,
            Camera camera)
        {

            if (!enabled)
                return;
            
            GL.invertCulling = true;
            RenderSettings.fog = false;
            var bias = QualitySettings.lodBias;
            QualitySettings.lodBias = bias * 0.25f;
            
            UpdateReflectionCamera(camera);

            CullResults cullResults = new CullResults();
            LightweightPipeline.RenderSingleCamera(pipelineInstance, context, m_ReflectionCamera, ref cullResults);
            
            GL.invertCulling = false;
            RenderSettings.fog = true;
            QualitySettings.lodBias = bias;
        }
    }
}
