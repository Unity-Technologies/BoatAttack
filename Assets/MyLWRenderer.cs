using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.LightweightPipeline;
using UnityEngine.Rendering;

public class MyLWRenderer : MonoBehaviour, IRendererSetup
{
    private DepthOnlyPass m_DepthOnlyPass;
    private DirectionalShadowsPass m_DirectionalShadowPass;
    private LocalShadowsPass m_LocalShadowPass;
    private SetupForwardRendering m_SetupForwardRendering;
    private ScreenSpaceShadowResolvePass m_ScreenSpaceShadowResovePass;
    private ConfigureForwardRTs m_ConfigureForwardRTs;
    private BeginXRRendering m_BeginXrRendering;
    private RenderOpaqueForward m_RenderOpaqueForward;
    private OpaquePostProcessPass m_OpaquePostProcessPass;
    private CopyDepthPass m_CopyDepthPass;
    private CopyColorPass m_CopyColorPass;
    private RenderTransparentForward m_RenderTransparentForward;
    private TransparentPostProcessPass m_TransparentPostProcessPass;
    private FinalBlitPass m_FinalBlitPass;
    private EndXRRendering m_EndXrRendering;

    
    [NonSerialized]
    private LightweightForwardRenderer m_Renderer;

    [NonSerialized]
    private bool m_Initialized = false;

    private void Init(LightweightForwardRenderer renderer)
    {
        if (m_Initialized)
            return;

        m_DepthOnlyPass = new DepthOnlyPass(renderer);
        m_DirectionalShadowPass = new DirectionalShadowsPass(renderer);
        m_LocalShadowPass = new LocalShadowsPass(renderer);
        m_SetupForwardRendering = new SetupForwardRendering(renderer);
        m_ScreenSpaceShadowResovePass = new ScreenSpaceShadowResolvePass(renderer);
        m_ConfigureForwardRTs = new ConfigureForwardRTs(renderer);
        m_BeginXrRendering = new BeginXRRendering(renderer);
        m_RenderOpaqueForward = new RenderOpaqueForward(renderer);
        m_OpaquePostProcessPass = new OpaquePostProcessPass(renderer);
        m_CopyDepthPass = new CopyDepthPass(renderer);
        m_CopyColorPass = new CopyColorPass(renderer);
        m_RenderTransparentForward = new RenderTransparentForward(renderer);
        m_TransparentPostProcessPass = new TransparentPostProcessPass(renderer);
        m_FinalBlitPass = new FinalBlitPass(renderer);
        m_EndXrRendering = new EndXRRendering(renderer);
        m_Renderer = renderer;

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

        renderer.EnqueuePass(m_SetupForwardRendering);

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

        var sampleCount = (SampleCount) renderingData.cameraData.msaaSamples;
        m_ConfigureForwardRTs.Setup(baseDescriptor, colorHandle, depthHandle, sampleCount);
        renderer.EnqueuePass(m_ConfigureForwardRTs);

        if (renderingData.cameraData.isStereoEnabled)
            renderer.EnqueuePass(m_BeginXrRendering);

        Camera camera = renderingData.cameraData.camera;
        bool dynamicBatching = renderingData.supportsDynamicBatching;
        RendererConfiguration rendererConfiguration = GetRendererConfiguration(renderingData.lightData.totalAdditionalLightsCount);

        m_RenderOpaqueForward.Setup(baseDescriptor, colorHandle, depthHandle, GetCameraClearFlag(camera), camera.backgroundColor, rendererConfiguration, dynamicBatching);
        renderer.EnqueuePass(m_RenderOpaqueForward);

        if (renderingData.cameraData.postProcessEnabled &&
            renderingData.cameraData.postProcessLayer.HasOpaqueOnlyEffects(renderer.postProcessRenderContext))
        {
            m_OpaquePostProcessPass.Setup(baseDescriptor, colorHandle);
            renderer.EnqueuePass(m_OpaquePostProcessPass);
        }

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

        m_RenderTransparentForward.Setup(baseDescriptor, colorHandle, depthHandle, ClearFlag.None, camera.backgroundColor, rendererConfiguration, dynamicBatching);
        renderer.EnqueuePass(m_RenderTransparentForward);

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
            renderer.EnqueuePass(m_EndXrRendering);
        }
    }

    private static ClearFlag GetCameraClearFlag(Camera camera)
    {
        ClearFlag clearFlag = ClearFlag.None;
        CameraClearFlags cameraClearFlags = camera.clearFlags;
        if (cameraClearFlags != CameraClearFlags.Nothing)
        {
            clearFlag |= ClearFlag.Depth;
            if (cameraClearFlags == CameraClearFlags.Color || cameraClearFlags == CameraClearFlags.Skybox)
                clearFlag |= ClearFlag.Color;
        }

        return clearFlag;
    }

    RendererConfiguration GetRendererConfiguration(int localLightsCount)
    {
        RendererConfiguration configuration = RendererConfiguration.PerObjectReflectionProbes | RendererConfiguration.PerObjectLightmaps | RendererConfiguration.PerObjectLightProbe;
        if (localLightsCount > 0)
        {
            if (m_Renderer.useComputeBufferForPerObjectLightIndices)
                configuration |= RendererConfiguration.ProvideLightIndices;
            else
                configuration |= RendererConfiguration.PerObjectLightIndices8;
        }

        return configuration;
    }
}