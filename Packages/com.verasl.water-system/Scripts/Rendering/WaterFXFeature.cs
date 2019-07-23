using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;


namespace WaterSystem
{
    public class WaterFXFeature : UnityEngine.Rendering.Universal.ScriptableRendererFeature
    {
        WaterFXPass m_WaterFXPass;
        
        public override void Create()
        {
            m_WaterFXPass = new WaterFXPass();
            m_WaterFXPass.renderPassEvent = UnityEngine.Rendering.Universal.RenderPassEvent.BeforeRenderingOpaques;
        }
        
        public override void AddRenderPasses(UnityEngine.Rendering.Universal.ScriptableRenderer renderer, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
        {
            renderer.EnqueuePass(m_WaterFXPass);
        }
    }

    public class WaterFXPass : UnityEngine.Rendering.Universal.ScriptableRenderPass
    {
        const string k_RenderWaterFXTag = "Render Water FX";
        ShaderTagId m_WaterFXShaderTag = new ShaderTagId("WaterFX");
        Color m_ClearColor = new Color(0.0f, 0.5f, 0.5f, 0.5f);
        UnityEngine.Rendering.Universal.RenderTargetHandle m_WaterFX = UnityEngine.Rendering.Universal.RenderTargetHandle.CameraTarget;

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

        public override void Execute(ScriptableRenderContext context, ref UnityEngine.Rendering.Universal.RenderingData renderingData)
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