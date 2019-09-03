using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

public class BoatRenderer : ScriptableRenderer
{
    const int k_DepthStencilBufferBits = 32;
    const string k_CreateCameraTextures = "Create Camera Texture";

    ColorGradingLutPass m_ColorGradingLutPass;
    DepthOnlyPass m_DepthPrepass;
    MainLightShadowCasterPass m_MainLightShadowCasterPass;
    PostProcessPass m_PostProcessPass;
    PostProcessPass m_FinalPostProcessPass;
    MainRenderPass m_MainRenderPass;
    FinalBlitPass m_FinalBlitPass;
    CopyColorPass m_CopyColorPass;
    DrawObjectsPass m_RenderTransparentForwardPass;

    RenderTargetHandle m_ActiveCameraColorAttachment;
    RenderTargetHandle m_ActiveCameraDepthAttachment;
    public RenderTargetHandle m_CameraColorAttachment;
    public RenderTargetHandle m_CameraDepthAttachment;
    RenderTargetHandle m_AfterPostProcessColor;
    RenderTargetHandle m_ColorGradingLut;
    RenderTargetHandle m_OpaqueColor;
    
    RenderTargetHandle m_DepthTexture;

    ForwardLights m_ForwardLights;

    public BoatRenderer(BoatRendererData data) : base(data)
    {
        Material blitMaterial = CoreUtils.CreateEngineMaterial(data.shaders.blitPS);
        Material copyDepthMaterial = CoreUtils.CreateEngineMaterial(data.shaders.copyDepthPS);
        Material samplingMaterial = CoreUtils.CreateEngineMaterial(data.shaders.samplingPS);
        
        m_MainLightShadowCasterPass = new MainLightShadowCasterPass(RenderPassEvent.BeforeRenderingShadows);
        m_DepthPrepass = new DepthOnlyPass(RenderPassEvent.BeforeRenderingPrepasses, RenderQueueRange.opaque, -1);
        m_ColorGradingLutPass = new ColorGradingLutPass(RenderPassEvent.BeforeRenderingOpaques, data.postProcessData);
        m_PostProcessPass = new PostProcessPass(RenderPassEvent.BeforeRenderingPostProcessing, data.postProcessData);
        m_FinalPostProcessPass = new PostProcessPass(RenderPassEvent.AfterRenderingPostProcessing, data.postProcessData);
        m_MainRenderPass = new MainRenderPass(RenderPassEvent.BeforeRenderingOpaques, data.caustics);
        m_FinalBlitPass = new FinalBlitPass(RenderPassEvent.AfterRendering, blitMaterial);   
        m_CopyColorPass = new CopyColorPass(RenderPassEvent.BeforeRenderingTransparents, samplingMaterial);
        m_RenderTransparentForwardPass = new DrawObjectsPass("Render Transparents", false, RenderPassEvent.BeforeRenderingTransparents, RenderQueueRange.transparent, -1, StencilState.defaultValue, 0);

        // RenderTexture format depends on camera and pipeline (HDR, non HDR, etc)
        // Samples (MSAA) depend on camera and pipeline
        m_CameraColorAttachment.Init("_CameraColorTexture");
        m_CameraDepthAttachment.Init("_CameraDepthAttachment");
        m_AfterPostProcessColor.Init("_AfterPostProcessTexture");
        m_OpaqueColor.Init("_CameraOpaqueTexture");
        m_ColorGradingLut.Init("_InternalGradingLut");
        m_DepthTexture.Init("_CameraDepthTexture");
        m_ForwardLights = new ForwardLights();
    }

    public override void Setup(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        ref CameraData cameraData = ref renderingData.cameraData;
        var cameraTargetDescriptor = cameraData.cameraTargetDescriptor;
        bool mainLightShadows = m_MainLightShadowCasterPass.Setup(ref renderingData);
        bool resolveShadowsInScreenSpace = mainLightShadows && renderingData.shadowData.requiresScreenSpaceShadowResolve;
        
        // Depth prepass is generated in the following cases:
        // - We resolve shadows in screen space
        // - Scene view camera always requires a depth texture. We do a depth pre-pass to simplify it and it shouldn't matter much for editor.
        // - If game or offscreen camera requires it we check if we can copy the depth from the rendering opaques pass and use that instead.
        bool requiresDepthPrepass = renderingData.cameraData.isSceneViewCamera ||
            (cameraData.requiresDepthTexture && (!CanCopyDepth(ref renderingData.cameraData)));
        requiresDepthPrepass |= resolveShadowsInScreenSpace;

        bool createColorTexture = RequiresIntermediateColorTexture(ref renderingData, cameraTargetDescriptor)
                                      || rendererFeatures.Count != 0;

        // If camera requires depth and there's no depth pre-pass we create a depth texture that can be read
        // later by effect requiring it.
        bool createDepthTexture = cameraData.requiresDepthTexture && !requiresDepthPrepass;
        bool postProcessEnabled = cameraData.postProcessEnabled;

        bool requiresFinalPostProcessPass = postProcessEnabled &&
                                     renderingData.cameraData.antialiasing == AntialiasingMode.FastApproximateAntialiasing;

        m_ActiveCameraColorAttachment = (createColorTexture) ? m_CameraColorAttachment : RenderTargetHandle.CameraTarget;
        m_ActiveCameraDepthAttachment = (createDepthTexture) ? m_CameraDepthAttachment : RenderTargetHandle.CameraTarget;
        bool intermediateRenderTexture = createColorTexture || createDepthTexture;

        if (intermediateRenderTexture)
            CreateCameraRenderTarget(context, ref cameraData);

        ConfigureCameraTarget(m_ActiveCameraColorAttachment.Identifier(), m_ActiveCameraDepthAttachment.Identifier());

        for (int i = 0; i < rendererFeatures.Count; ++i)
        {
            rendererFeatures[i].AddRenderPasses(this, ref renderingData);
        }

        int count = activeRenderPassQueue.Count;
        for (int i = count - 1; i >= 0; i--)
        {
            if (activeRenderPassQueue[i] == null)
                activeRenderPassQueue.RemoveAt(i);
        }

        if (mainLightShadows)
            EnqueuePass(m_MainLightShadowCasterPass);

        if (postProcessEnabled)
        {
            m_ColorGradingLutPass.Setup(m_ColorGradingLut);
            EnqueuePass(m_ColorGradingLutPass);
        }

        m_MainRenderPass.renderer = this;
        EnqueuePass(m_MainRenderPass);
        
        if (renderingData.cameraData.requiresOpaqueTexture)
        {
            // TODO: Downsampling method should be store in the renderer isntead of in the asset.
            // We need to migrate this data to renderer. For now, we query the method in the active asset.
            Downsampling downsamplingMethod = UniversalRenderPipeline.asset.opaqueDownsampling;
            m_CopyColorPass.Setup(m_ActiveCameraColorAttachment.Identifier(), m_OpaqueColor, downsamplingMethod);
            EnqueuePass(m_CopyColorPass);
        }
        
        EnqueuePass(m_RenderTransparentForwardPass);
        
        if (postProcessEnabled)
        {
            if (requiresFinalPostProcessPass)
            {
                m_PostProcessPass.Setup(cameraTargetDescriptor, m_ActiveCameraColorAttachment, m_AfterPostProcessColor, m_ActiveCameraDepthAttachment, m_ColorGradingLut, true);
                EnqueuePass(m_PostProcessPass);
                m_FinalPostProcessPass.SetupFinalPass(m_AfterPostProcessColor);
                EnqueuePass(m_FinalPostProcessPass);
            }
            else
            {
                m_PostProcessPass.Setup(cameraTargetDescriptor, m_ActiveCameraColorAttachment, RenderTargetHandle.CameraTarget, m_ActiveCameraDepthAttachment, m_ColorGradingLut, false);
                EnqueuePass(m_PostProcessPass);
            }
        }
        else if (m_ActiveCameraColorAttachment != RenderTargetHandle.CameraTarget)
        {
            m_FinalBlitPass.Setup(cameraTargetDescriptor, m_ActiveCameraColorAttachment);
            EnqueuePass(m_FinalBlitPass);
        }
    }

    public override void SetupLights(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        m_ForwardLights.Setup(context, ref renderingData);
    }

    public override void SetupCullingParameters(ref ScriptableCullingParameters cullingParameters,
        ref CameraData cameraData)
    {
        Camera camera = cameraData.camera;
        cullingParameters.shadowDistance = Mathf.Min(cameraData.maxShadowDistance, camera.farClipPlane);
    }

    public override void FinishRendering(CommandBuffer cmd)
    {
        if (m_ActiveCameraColorAttachment != RenderTargetHandle.CameraTarget)
            cmd.ReleaseTemporaryRT(m_ActiveCameraColorAttachment.id);

        if (m_ActiveCameraDepthAttachment != RenderTargetHandle.CameraTarget)
            cmd.ReleaseTemporaryRT(m_ActiveCameraDepthAttachment.id);
    }

    void CreateCameraRenderTarget(ScriptableRenderContext context, ref CameraData cameraData)
    {
        CommandBuffer cmd = CommandBufferPool.Get(k_CreateCameraTextures);
        var descriptor = cameraData.cameraTargetDescriptor;
        int msaaSamples = descriptor.msaaSamples;
        if (m_ActiveCameraColorAttachment != RenderTargetHandle.CameraTarget)
        {
            bool useDepthRenderBuffer = m_ActiveCameraDepthAttachment == RenderTargetHandle.CameraTarget;
            var colorDescriptor = descriptor;
            colorDescriptor.depthBufferBits = (useDepthRenderBuffer) ? k_DepthStencilBufferBits : 0;
            cmd.GetTemporaryRT(m_ActiveCameraColorAttachment.id, colorDescriptor, FilterMode.Bilinear);
        }

        if (m_ActiveCameraDepthAttachment != RenderTargetHandle.CameraTarget)
        {
            var depthDescriptor = descriptor;
            depthDescriptor.colorFormat = RenderTextureFormat.Depth;
            depthDescriptor.depthBufferBits = k_DepthStencilBufferBits;
            depthDescriptor.bindMS = msaaSamples > 1 && !SystemInfo.supportsMultisampleAutoResolve && (SystemInfo.supportsMultisampledTextures != 0);
            cmd.GetTemporaryRT(m_ActiveCameraDepthAttachment.id, depthDescriptor, FilterMode.Point);
        }

        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }

    bool RequiresIntermediateColorTexture(ref RenderingData renderingData, RenderTextureDescriptor baseDescriptor)
    {
        ref CameraData cameraData = ref renderingData.cameraData;
        int msaaSamples = cameraData.cameraTargetDescriptor.msaaSamples;
        bool isStereoEnabled = renderingData.cameraData.isStereoEnabled;
        bool isScaledRender = !Mathf.Approximately(cameraData.renderScale, 1.0f);
        bool isCompatibleBackbufferTextureDimension = baseDescriptor.dimension == TextureDimension.Tex2D;
        bool requiresExplicitMsaaResolve = msaaSamples > 1 && !SystemInfo.supportsMultisampleAutoResolve;
        bool isOffscreenRender = cameraData.camera.targetTexture != null && !cameraData.isSceneViewCamera;
        bool isCapturing = cameraData.captureActions != null;

        bool requiresBlitForOffscreenCamera = cameraData.postProcessEnabled || cameraData.requiresOpaqueTexture || requiresExplicitMsaaResolve;
        if (isOffscreenRender)
            return requiresBlitForOffscreenCamera;

        return requiresBlitForOffscreenCamera || cameraData.isSceneViewCamera || isScaledRender || cameraData.isHdrEnabled ||
               !isCompatibleBackbufferTextureDimension || !cameraData.isDefaultViewport || isCapturing || Display.main.requiresBlitToBackbuffer
               || (renderingData.killAlphaInFinalBlit && !isStereoEnabled);
    }
    bool CanCopyDepth(ref CameraData cameraData)
    {
        bool msaaEnabledForCamera = cameraData.cameraTargetDescriptor.msaaSamples > 1;
        bool supportsTextureCopy = SystemInfo.copyTextureSupport != CopyTextureSupport.None;
        bool supportsDepthTarget = RenderingUtils.SupportsRenderTextureFormat(RenderTextureFormat.Depth);
        bool supportsDepthCopy = !msaaEnabledForCamera && (supportsDepthTarget || supportsTextureCopy);

        // TODO:  We don't have support to highp Texture2DMS currently and this breaks depth precision.
        // currently disabling it until shader changes kick in.
        //bool msaaDepthResolve = msaaEnabledForCamera && SystemInfo.supportsMultisampledTextures != 0;
        bool msaaDepthResolve = false;
        return supportsDepthCopy || msaaDepthResolve;
    }
}
