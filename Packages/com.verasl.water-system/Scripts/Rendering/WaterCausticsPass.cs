using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.LWRP;

namespace WaterSystem
{
    [ImageEffectAllowedInSceneView]
    public class WaterCausticsPass : MonoBehaviour, IAfterOpaquePass
    {
        private WaterCausticsPassImpl m_WaterCausticsPass;
        public Material m_WaterCausticMaterial;

        private WaterCausticsPassImpl waterCausticsPass
        {
            get
            {
                if (m_WaterCausticsPass == null)
                    m_WaterCausticsPass = new WaterCausticsPassImpl();

                m_WaterCausticsPass.m_WaterCausticMaterial = m_WaterCausticMaterial;
                
                return m_WaterCausticsPass;
            }
        }

        public ScriptableRenderPass GetPassToEnqueue(RenderTextureDescriptor baseDescriptor,
            RenderTargetHandle colorHandle, RenderTargetHandle depthHandle)
        {
            return waterCausticsPass;
        }
    }

    public class WaterCausticsPassImpl : ScriptableRenderPass
    {
        const string k_RenderWaterCausticsTag = "Render Water Caustics";
        public Material m_WaterCausticMaterial;

        private Matrix4x4 m_view;
        private Matrix4x4 m_proj;

        public override void Execute(ScriptableRenderer renderer, ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (m_WaterCausticMaterial == null)
            {
                Debug.LogErrorFormat("Missing caustic material}. {0} render pass will not execute. Check for missing reference in the renderer resources.", GetType().Name);
                return;
            }
            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterCausticsTag);

            m_view = renderingData.cameraData.camera.worldToCameraMatrix;
            m_proj = renderingData.cameraData.camera.projectionMatrix;
            
            cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
            ScriptableRenderer.RenderFullscreenQuad(cmd, m_WaterCausticMaterial);
            context.ExecuteCommandBuffer(cmd);

            cmd.Clear();

            cmd.SetViewProjectionMatrices(m_view, m_proj);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}