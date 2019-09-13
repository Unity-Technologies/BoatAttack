using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace WaterSystem
{
    public class WaterCausticsFeature : ScriptableRendererFeature
    {
        private WaterCausticsPass m_WaterCausticsPass;
        public WaterCausticSettings settings = new WaterCausticSettings();
        
        [System.Serializable]
        public class WaterCausticSettings
        {
            public Material material;
            public Mesh mesh;
        }
        
        public override void Create()
        {
            m_WaterCausticsPass = new WaterCausticsPass();
            m_WaterCausticsPass.m_WaterCausticMaterial = settings.material;
            m_WaterCausticsPass.m_mesh = settings.mesh;
            m_WaterCausticsPass.renderPassEvent = RenderPassEvent.AfterRenderingSkybox + 1;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(m_WaterCausticsPass);
        }
    }

    public class WaterCausticsPass : ScriptableRenderPass
    {
        const string k_RenderWaterCausticsTag = "Render Water Caustics";
        public Material m_WaterCausticMaterial;
        public Mesh m_mesh;

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (m_WaterCausticMaterial == null || m_mesh == null)
            {
                Debug.LogErrorFormat(
                    "Missing caustic material. {0} render pass will not execute. Check for missing reference in the renderer resources.",
                    GetType().Name);
                return;
            }

            Vector3 position = renderingData.cameraData.camera.transform.position;
            position.y = 0;
            Matrix4x4 matrix = Matrix4x4.TRS(position, Quaternion.identity, Vector3.one * 100f);

            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterCausticsTag);
            cmd.DrawMesh(m_mesh, matrix	, m_WaterCausticMaterial, 0, 0);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}