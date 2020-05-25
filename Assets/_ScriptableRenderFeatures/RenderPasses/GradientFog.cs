using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GradientFog : ScriptableRendererFeature
{
    [System.Serializable]
    public class GradientFogSettings
    {
        public RenderPassEvent Event = RenderPassEvent.AfterRenderingOpaques;
        public float StartDistance = 0;
        public float EndDistance = 50;
        public Color NearColor = new Color(0, 0.2f, 0.35f, 1);
        public Color MiddleColor = new Color(0.62f, 0.86f, 1, 1);
        public Color FarColor = new Color(0.85f, 0.96f, 1, 1);
        [Range(0, 1)] public float Fade = 0.5f;
    }
    
    
    class GradientFogPass : ScriptableRenderPass
    {
        public GradientFogSettings settings;

        private Material fogMaterial;

        private RenderTargetIdentifier source { get; set; }
        private RenderTargetHandle m_TempTex;

        public GradientFogPass()
        {
            m_TempTex.Init("_TempTex");
            fogMaterial = new Material(Shader.Find("Shader Graphs/ShaderGraph_GradientFog"));
        }

        public void Setup(RenderTargetIdentifier cameraColorTarget)
        {
            source = cameraColorTarget;
            fogMaterial.SetFloat("_StartDist", settings.StartDistance);
            fogMaterial.SetFloat("_EndDist", settings.EndDistance);
            fogMaterial.SetColor("_NearCol", settings.NearColor);
            fogMaterial.SetColor("_MidCol", settings.MiddleColor);
            fogMaterial.SetColor("_FarCol", settings.FarColor);
            fogMaterial.SetFloat("_Fade", settings.Fade);
        }
        
        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in an performance manner.
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get("Gradient Fog");

            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            
            opaqueDesc.depthBufferBits = 0;
            
            cmd.GetTemporaryRT(m_TempTex.id, opaqueDesc);
            
            
            Blit(cmd, source, m_TempTex.Identifier(), fogMaterial);
            Blit(cmd, m_TempTex.Identifier(), source);
            
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        /// Cleanup any allocated resources that were created during the execution of this render pass.
        public override void FrameCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(m_TempTex.id);
        }
    }

    GradientFogPass m_GradientFogPass;
    public GradientFogSettings settings = new GradientFogSettings();

    public override void Create()
    {
        m_GradientFogPass = new GradientFogPass();
        m_GradientFogPass.settings = settings;

        // Configures where the render pass should be injected.
        m_GradientFogPass.renderPassEvent = settings.Event;
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        var src = renderer.cameraColorTarget;
        m_GradientFogPass.Setup(src);
        renderer.EnqueuePass(m_GradientFogPass);
    }
}