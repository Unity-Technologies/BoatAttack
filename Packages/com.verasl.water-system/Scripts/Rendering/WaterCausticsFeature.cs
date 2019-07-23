using UnityEngine;
using UnityEngine.Rendering;


namespace WaterSystem
{
    public class WaterCausticsFeature : UnityEngine.Rendering.Universal.ScriptableRendererFeature
    {
        private WaterCausticsPass m_WaterCausticsPass;
        public WaterCausticSettings settings = new WaterCausticSettings();
        
        [System.Serializable]
        public class WaterCausticSettings
        {
            public Material material;
        }
        
        public override void Create()
        {
            m_WaterCausticsPass = new WaterCausticsPass();
            m_WaterCausticsPass.m_WaterCausticMaterial = settings.material;
        }

        public override void AddRenderPasses(UnityEngine.Rendering.Universal.ScriptableRenderer renderer, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
        {
            renderer.EnqueuePass(m_WaterCausticsPass);
        }
    }

    public class WaterCausticsPass : UnityEngine.Rendering.Universal.ScriptableRenderPass
    {
        const string k_RenderWaterCausticsTag = "Render Water Caustics";
        public Material m_WaterCausticMaterial;

        public override void Execute(ScriptableRenderContext context, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
        {
            if (m_WaterCausticMaterial == null)
            {
                Debug.LogErrorFormat(
                    "Missing caustic material. {0} render pass will not execute. Check for missing reference in the renderer resources.",
                    GetType().Name);
                return;
            }

            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterCausticsTag);
            cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
            cmd.DrawMesh(UnityEngine.Rendering.Universal.RenderingUtils.fullscreenMesh, Matrix4x4.identity, m_WaterCausticMaterial, 0, 0);
            cmd.SetViewProjectionMatrices(renderingData.cameraData.camera.worldToCameraMatrix, renderingData.cameraData.camera.projectionMatrix);
            
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}