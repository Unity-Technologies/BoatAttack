using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

namespace WaterSystem
{
    [ImageEffectAllowedInSceneView]
    public class WaterFXPass : MonoBehaviour, IAfterSkyboxPass
    {
        private WaterFXPassImpl m_WaterFXPass;

        WaterFXPassImpl waterFxPass
        {
            get
            {
                if (m_WaterFXPass == null)
                    m_WaterFXPass = new WaterFXPassImpl();

                return m_WaterFXPass;
            }
        }

        public ScriptableRenderPass GetPassToEnqueue(RenderTextureDescriptor baseDescriptor,
            RenderTargetHandle colorHandle, RenderTargetHandle depthHandle)
        {
            return waterFxPass;
        }
    }

    public class WaterFXPassImpl : ScriptableRenderPass
    {
        const string k_RenderWaterFXTag = "Render Water FX";
        private RenderTargetHandle m_WaterFX = RenderTargetHandle.CameraTarget;

        private FilterRenderersSettings transparentFilterSettings { get; set; }

        public WaterFXPassImpl()
        {
            RegisterShaderPassName("WaterFX");
            m_WaterFX.Init("_WaterFXMap");


            transparentFilterSettings = new FilterRenderersSettings(true)
            {
                renderQueueRange = RenderQueueRange.transparent,
            };
        }

        public override void Execute(ScriptableRenderer renderer, ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterFXTag);

            RenderTextureDescriptor descriptor = ScriptableRenderer.CreateRenderTextureDescriptor(ref renderingData.cameraData);
            descriptor.width = (int) (descriptor.width * 0.5f);
            descriptor.height = (int) (descriptor.height * 0.5f);

            using (new ProfilingSample(cmd, k_RenderWaterFXTag))
            {
                cmd.GetTemporaryRT(m_WaterFX.id, descriptor, FilterMode.Bilinear);

                SetRenderTarget(
                    cmd,
                    m_WaterFX.Identifier(),
                    RenderBufferLoadAction.DontCare,
                    RenderBufferStoreAction.Store,
                    ClearFlag.Color,
                    new Color(0.0f, 0.5f, 0.5f, 0.5f),
                    descriptor.dimension);

                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                var drawSettings = CreateDrawRendererSettings(renderingData.cameraData.camera,
                    SortFlags.CommonTransparent, RendererConfiguration.None, renderingData.supportsDynamicBatching);
                if (renderingData.cameraData.isStereoEnabled)
                {
                    Camera camera = renderingData.cameraData.camera;
                    context.StartMultiEye(camera);
                    context.DrawRenderers(renderingData.cullResults.visibleRenderers, ref drawSettings, transparentFilterSettings);
                    context.StopMultiEye(camera);
                }
                else
                    context.DrawRenderers(renderingData.cullResults.visibleRenderers, ref drawSettings, transparentFilterSettings);

            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            base.FrameCleanup(cmd);
            if (m_WaterFX != RenderTargetHandle.CameraTarget)
            {
                cmd.ReleaseTemporaryRT(m_WaterFX.id);
            }
        }
    }
}