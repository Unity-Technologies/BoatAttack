using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PseudoLensflareFeature : ScriptableRendererFeature
{
    class PseudoLensflarePass : ScriptableRenderPass
    {
        public Material blitMaterial;
        private PseudoFlareVolume component { get; set; }
        private RenderTargetIdentifier source { get; set; }
        private RenderTargetHandle destination { get; set; }
        
        string m_ProfilerTag;

        public PseudoLensflarePass(Material blitMaterial)
        {
            this.blitMaterial = blitMaterial;
            renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
            m_ProfilerTag = "Grayscale";
        }

        public void Setup(RenderTargetIdentifier source, RenderTargetHandle destination, PseudoFlareVolume component)
        {
            this.component = component;
            this.source = source;
            this.destination = destination;
        }
        
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (component == null || !component.active) return;
            
            blitMaterial.SetFloat(Blend, component.blend.value);
            
            CommandBuffer cmd = CommandBufferPool.Get(m_ProfilerTag);

            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;

            Blit(cmd, source, destination.Identifier(), blitMaterial);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
    
    public Material blitMaterial;
    PseudoLensflarePass _blitPass;
    private static readonly int Blend = Shader.PropertyToID("_Blend");

    public override void Create()
    {
        _blitPass = new PseudoLensflarePass(blitMaterial);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        var component = VolumeManager.instance.stack.GetComponent<PseudoFlareVolume>();
        if (component == null || !component.active) return;
        
        if (blitMaterial == null)
        {
            Debug.LogWarningFormat("Missing Blit Material. {0} blit pass will not execute. Check for missing reference in the assigned renderer.", GetType().Name);
            return;
        }
        
        var src = renderer.cameraColorTarget;
        var dest = RenderTargetHandle.CameraTarget;
        
        _blitPass.Setup(src, dest, component);
        renderer.EnqueuePass(_blitPass);
    }
}