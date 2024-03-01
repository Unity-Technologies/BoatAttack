using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BoatAttack
{
    public class LodTweaker : ScriptableRendererFeature
    {
        [SerializeField] private float reflectionCameraLodBias = 3;
        [SerializeField] private float nonreflectionCameraLodBias = 0.5f;
        void SetMaxLod(Camera cam) {
            if (cam == Camera.main || cam.cameraType == CameraType.SceneView || cam.cameraType == CameraType.Reflection)
                QualitySettings.lodBias = reflectionCameraLodBias;
            else
                QualitySettings.lodBias = nonreflectionCameraLodBias;
        }
        public override void Create()
        {
            //no pass;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            SetMaxLod(renderingData.cameraData.camera);
        }
        
    }
}
