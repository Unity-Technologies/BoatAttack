using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;

namespace WaterSystem
{
    public class WaterFXFeature : ScriptableRendererFeature
    {
        WaterFXPass m_WaterFXPass;
        
        public override void Create()
        {
            m_WaterFXPass = new WaterFXPass();
            m_WaterFXPass.renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;
        }
        
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(m_WaterFXPass);
        }
    }

    public class WaterFXPass : ScriptableRenderPass
    {
        const string k_RenderWaterFXTag = "Render Water FX";
        ShaderTagId m_WaterFXShaderTag = new ShaderTagId("WaterFX");
        Color m_ClearColor = new Color(0.0f, 0.5f, 0.5f, 0.5f);
        RenderTargetHandle m_WaterFX = RenderTargetHandle.CameraTarget;

        private FilteringSettings transparentFilterSettings { get; set; }

        public WaterFXPass()
        {
            m_WaterFX.Init("_WaterFXMap");
            transparentFilterSettings = new FilteringSettings(RenderQueueRange.transparent);
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            cameraTextureDescriptor.depthBufferBits = 0;
            cameraTextureDescriptor.width = cameraTextureDescriptor.width / 2;
            cameraTextureDescriptor.height = cameraTextureDescriptor.height / 2;
            cameraTextureDescriptor.colorFormat = RenderTextureFormat.Default;
            cmd.GetTemporaryRT(m_WaterFX.id, cameraTextureDescriptor, FilterMode.Bilinear);
            ConfigureTarget(m_WaterFX.Identifier());
            ConfigureClear(ClearFlag.Color, m_ClearColor);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterFXTag);

            using (new ProfilingSample(cmd, k_RenderWaterFXTag))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                var drawSettings = CreateDrawingSettings(m_WaterFXShaderTag, ref renderingData, SortingCriteria.CommonTransparent);
                var filteringSettings = transparentFilterSettings;

                context.DrawRenderers(renderingData.cullResults, ref drawSettings, ref filteringSettings);
            }
            
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(m_WaterFX.id);
        }
    }
}