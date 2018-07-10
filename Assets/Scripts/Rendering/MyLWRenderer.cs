using System;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering.LightweightPipeline
{
    public class MyLWRenderer : MonoBehaviour, IRendererSetup
    {
        private DepthOnlyPass m_DepthOnlyPass;
        private DirectionalShadowsPass m_DirectionalShadowPass;
        private LocalShadowsPass m_LocalShadowPass;
        private SetupForwardRenderingPass m_SetupForwardRenderingPass;
        private ScreenSpaceShadowResolvePass m_ScreenSpaceShadowResovePass;
        private CreateLightweightRenderTexturesPass m_CreateLightweightRenderTexturesPass;
        private BeginXRRenderingPass m_BeginXrRenderingPass;
        private SetupLightweightConstanstPass m_SetupLightweightConstants;
        private RenderOpaqueForwardPass m_RenderOpaqueForwardPass;
        private OpaquePostProcessPass m_OpaquePostProcessPass;
        private DrawSkyboxPass m_DrawSkyboxPass;
        private CopyDepthPass m_CopyDepthPass;
        private CopyColorPass m_CopyColorPass;
        private RenderTransparentForwardPass m_RenderTransparentForwardPass;
        private TransparentPostProcessPass m_TransparentPostProcessPass;
        private FinalBlitPass m_FinalBlitPass;
        private EndXRRenderingPass m_EndXrRenderingPass;

        private WaterFXPass m_WaterFXPass;

        [NonSerialized]
        private bool m_Initialized = false;

        private void Init(LightweightForwardRenderer renderer)
        {
            if (m_Initialized)
                return;

            m_DepthOnlyPass = new DepthOnlyPass(renderer);
            m_DirectionalShadowPass = new DirectionalShadowsPass(renderer);
            m_LocalShadowPass = new LocalShadowsPass(renderer);
            m_SetupForwardRenderingPass = new SetupForwardRenderingPass(renderer);
            m_ScreenSpaceShadowResovePass = new ScreenSpaceShadowResolvePass(renderer);
            m_CreateLightweightRenderTexturesPass = new CreateLightweightRenderTexturesPass(renderer);
            m_BeginXrRenderingPass = new BeginXRRenderingPass(renderer);
            m_SetupLightweightConstants = new SetupLightweightConstanstPass(renderer);
            m_RenderOpaqueForwardPass = new RenderOpaqueForwardPass(renderer);
            m_OpaquePostProcessPass = new OpaquePostProcessPass(renderer);
            m_DrawSkyboxPass = new DrawSkyboxPass(renderer);
            m_CopyDepthPass = new CopyDepthPass(renderer);
            m_CopyColorPass = new CopyColorPass(renderer);
            m_RenderTransparentForwardPass = new RenderTransparentForwardPass(renderer);
            m_TransparentPostProcessPass = new TransparentPostProcessPass(renderer);
            m_FinalBlitPass = new FinalBlitPass(renderer);
            m_EndXrRenderingPass = new EndXRRenderingPass(renderer);

            m_WaterFXPass = new WaterFXPass(renderer);

            m_Initialized = true;
        }

        public void Setup(LightweightForwardRenderer renderer, ref ScriptableRenderContext context,
            ref CullResults cullResults, ref RenderingData renderingData)
        {
            Init(renderer);

            renderer.Clear();

            renderer.SetupPerObjectLightIndices(ref cullResults, ref renderingData.lightData);
            RenderTextureDescriptor baseDescriptor = renderer.CreateRTDesc(ref renderingData.cameraData);
            RenderTextureDescriptor shadowDescriptor = baseDescriptor;
            shadowDescriptor.dimension = TextureDimension.Tex2D;

            bool requiresCameraDepth = renderingData.cameraData.requiresDepthTexture;
            bool requiresDepthPrepass = renderingData.shadowData.requiresScreenSpaceShadowResolve ||
                                        renderingData.cameraData.isSceneViewCamera ||
                                        (requiresCameraDepth &&
                                         !LightweightForwardRenderer.CanCopyDepth(ref renderingData.cameraData));

            // For now VR requires a depth prepass until we figure out how to properly resolve texture2DMS in stereo
            requiresDepthPrepass |= renderingData.cameraData.isStereoEnabled;

            if (renderingData.shadowData.renderDirectionalShadows)
                renderer.EnqueuePass(m_DirectionalShadowPass);

            if (renderingData.shadowData.renderLocalShadows)
                renderer.EnqueuePass(m_LocalShadowPass);

            renderer.EnqueuePass(m_SetupForwardRenderingPass);

            if (requiresDepthPrepass)
            {
                m_DepthOnlyPass.Setup(baseDescriptor, RenderTargetHandles.DepthTexture, SampleCount.One);
                renderer.EnqueuePass(m_DepthOnlyPass);
            }

            if (renderingData.shadowData.renderDirectionalShadows &&
                renderingData.shadowData.requiresScreenSpaceShadowResolve)
            {
                m_ScreenSpaceShadowResovePass.Setup(baseDescriptor, RenderTargetHandles.ScreenSpaceShadowmap);
                renderer.EnqueuePass(m_ScreenSpaceShadowResovePass);
            }

            bool requiresDepthAttachment = requiresCameraDepth && !requiresDepthPrepass;
            bool requiresColorAttachment =
                LightweightForwardRenderer.RequiresIntermediateColorTexture(
                    ref renderingData.cameraData,
                    baseDescriptor,
                    requiresDepthAttachment);
            RenderTargetHandle colorHandle = (requiresColorAttachment) ? RenderTargetHandles.Color : RenderTargetHandle.BackBuffer;
            RenderTargetHandle depthHandle = (requiresDepthAttachment) ? RenderTargetHandles.DepthAttachment : RenderTargetHandle.BackBuffer;

            var sampleCount = (SampleCount)renderingData.cameraData.msaaSamples;
            m_CreateLightweightRenderTexturesPass.Setup(baseDescriptor, colorHandle, depthHandle, sampleCount);
            renderer.EnqueuePass(m_CreateLightweightRenderTexturesPass);

            if (renderingData.cameraData.isStereoEnabled)
                renderer.EnqueuePass(m_BeginXrRenderingPass);

            renderer.EnqueuePass(m_WaterFXPass);

            Camera camera = renderingData.cameraData.camera;
            bool dynamicBatching = renderingData.supportsDynamicBatching;
            RendererConfiguration rendererConfiguration = LightweightForwardRenderer.GetRendererConfiguration(renderingData.lightData.totalAdditionalLightsCount);

            renderer.EnqueuePass(m_SetupLightweightConstants);

            m_RenderOpaqueForwardPass.Setup(baseDescriptor, colorHandle, depthHandle, LightweightForwardRenderer.GetCameraClearFlag(camera), camera.backgroundColor, rendererConfiguration, dynamicBatching);
            renderer.EnqueuePass(m_RenderOpaqueForwardPass);

            if (renderingData.cameraData.postProcessEnabled &&
                renderingData.cameraData.postProcessLayer.HasOpaqueOnlyEffects(renderer.postProcessRenderContext))
            {
                m_OpaquePostProcessPass.Setup(baseDescriptor, colorHandle);
                renderer.EnqueuePass(m_OpaquePostProcessPass);
            }

            if (camera.clearFlags == CameraClearFlags.Skybox)
                renderer.EnqueuePass(m_DrawSkyboxPass);

            if (depthHandle != RenderTargetHandle.BackBuffer)
            {
                m_CopyDepthPass.Setup(depthHandle);
                renderer.EnqueuePass(m_CopyDepthPass);
            }

            if (renderingData.cameraData.requiresOpaqueTexture)
            {
                m_CopyColorPass.Setup(colorHandle);
                renderer.EnqueuePass(m_CopyColorPass);
            }

            m_RenderTransparentForwardPass.Setup(baseDescriptor, colorHandle, depthHandle, ClearFlag.None, camera.backgroundColor, rendererConfiguration, dynamicBatching);
            renderer.EnqueuePass(m_RenderTransparentForwardPass);

            if (renderingData.cameraData.postProcessEnabled)
            {
                m_TransparentPostProcessPass.Setup(baseDescriptor, colorHandle);
                renderer.EnqueuePass(m_TransparentPostProcessPass);
            }
            else if (!renderingData.cameraData.isOffscreenRender && colorHandle != RenderTargetHandle.BackBuffer)
            {
                m_FinalBlitPass.Setup(baseDescriptor, colorHandle);
                renderer.EnqueuePass(m_FinalBlitPass);
            }

            if (renderingData.cameraData.isStereoEnabled)
            {
                renderer.EnqueuePass(m_EndXrRenderingPass);
            }
        }
    }
}
