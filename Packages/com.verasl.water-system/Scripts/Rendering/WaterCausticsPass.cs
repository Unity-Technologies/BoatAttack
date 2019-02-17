using System.Net;
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
        //private RenderTargetHandle m_WaterCaustics = RenderTargetHandle.CameraTarget;
        //RenderTargetHandle m_TemporaryColorTexture;
        public Material m_WaterCausticMaterial;

        private Matrix4x4 view;
        private Matrix4x4 proj;

        private FilteringSettings transparentFilterSettings { get; set; }

        public WaterCausticsPassImpl()
        {
            RegisterShaderPassName("WaterFX");
            //m_WaterCaustics.Init("_WaterFXMap");
            //m_TemporaryColorTexture.Init("_TemporaryColorTexture");

            transparentFilterSettings = new FilteringSettings(RenderQueueRange.transparent);
        }

        public override void Execute(ScriptableRenderer renderer, ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (m_WaterCausticMaterial == null)
            {
                Debug.LogErrorFormat("Missing {0}. {1} render pass will not execute. Check for missing reference in the renderer resources.", m_WaterCausticMaterial, GetType().Name);
                return;
            }
            
            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterCausticsTag);

            RenderTextureDescriptor opaqueDesc = ScriptableRenderer.CreateRenderTextureDescriptor(ref renderingData.cameraData);
            opaqueDesc.msaaSamples = 1;

            //RenderTargetIdentifier src = m_WaterCaustics.Identifier();

            //cmd.GetTemporaryRT(m_TemporaryColorTexture.id, opaqueDesc, FilterMode.Point);
            //cmd.Blit(src, m_TemporaryColorTexture.Identifier(), blitMaterial, blitShaderPassIndex);
            //cmd.Blit(m_TemporaryColorTexture.Identifier(), src);

            view = renderingData.cameraData.camera.worldToCameraMatrix;
            proj = renderingData.cameraData.camera.projectionMatrix;
            
            cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
            //cmd.SetViewport(renderingData.cameraData.camera.pixelRect);
            ScriptableRenderer.RenderFullscreenQuad(cmd, m_WaterCausticMaterial);

            context.ExecuteCommandBuffer(cmd);

            cmd.Clear();

            cmd.SetViewProjectionMatrices(view, proj);
            context.ExecuteCommandBuffer(cmd);
            
            CommandBufferPool.Release(cmd);
        }

//        public override void FrameCleanup(CommandBuffer cmd)
//        {
//            cmd.SetViewProjectionMatrices(renderingData.cameraData.camera.worldToCameraMatrix,  renderingData.cameraData.camera.projectionMatrix);
//        }
    }
}