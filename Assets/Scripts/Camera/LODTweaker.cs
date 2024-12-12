using UnityEngine;
using UnityEngine.Rendering;

namespace BoatAttack
{
    /// <summary>
    /// Used to lower the LOD bias on the planar reflections camera
    /// <para>Needs to be replaced with SRP pass structure later</para>
    /// </summary>
    [ExecuteInEditMode]
    public class LodTweaker : MonoBehaviour
    {
        /// <summary>
        /// Check to see if rendering the planar reflection camera, if so, lower LOD bias
        /// </summary>
        /// <param name="cam">The currently rendering camera from LWRP</param>
        static void SetMaxLod(ScriptableRenderContext src, Camera cam)
        {
            if (cam == Camera.main || cam.cameraType == CameraType.SceneView || cam.cameraType == CameraType.Reflection)
                QualitySettings.lodBias = 3;
            else
                QualitySettings.lodBias = 0.5f;
        }

        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoad()
        {
            RenderPipelineManager.beginCameraRendering -= SetMaxLod;
            RenderPipelineManager.beginCameraRendering += SetMaxLod;
        }
    }
}
