using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PseudoLensflareFeature : ScriptableRendererFeature
{
    public class PseudoLensflarePass : ScriptableRenderPass
    {
        public Material blitMaterial;
        private Material samplingMaterial;
        private PseudoFlareVolume component { get; set; }
        private RenderTargetIdentifier source { get; set; }
        private RenderTargetHandle destination { get; set; }

        RenderTargetHandle m_TmpRT1;
        RenderTargetHandle m_TmpRT2;

        string m_ProfilerTag;

        public PseudoLensflarePass(Material blitMaterial)
        {
            this.blitMaterial = blitMaterial;
            samplingMaterial = CoreUtils.CreateEngineMaterial("Hidden/Universal Render Pipeline/Sampling");
            renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
            m_ProfilerTag = "Grayscale";
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            var width = cameraTextureDescriptor.width / 4;
            var height = cameraTextureDescriptor.height / 4;
            m_TmpRT1.Init("tempRT1");
            m_TmpRT2.Init("tempRT2");

            cmd.GetTemporaryRT(m_TmpRT1.id, width, height, 0, FilterMode.Bilinear, cameraTextureDescriptor.graphicsFormat);
            cmd.GetTemporaryRT(m_TmpRT2.id, width, height, 0, FilterMode.Bilinear, cameraTextureDescriptor.graphicsFormat);
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

            blitMaterial.SetFloat(Offset, component.offset.value);
            blitMaterial.SetFloat(Power, component.power.value);
            blitMaterial.SetFloat(GhostSpacing, component.ghostSpacing.value);
            blitMaterial.SetFloat(GhostCount, component.ghostCount.value);
            blitMaterial.SetFloat(HaloWidth, component.haloWidth.value);

            CommandBuffer cmd = CommandBufferPool.Get(m_ProfilerTag);

            // first pass
            cmd.SetGlobalFloat(BlurOffset, 1.5f);
            cmd.Blit(source, m_TmpRT1.Identifier(), blitMaterial, 1);

            const int passes = 5;

            for (var i=1; i<passes-1; i++) {
                cmd.SetGlobalFloat(BlurOffset, 0.5f + i);
                cmd.Blit(m_TmpRT1.Identifier(), m_TmpRT2.Identifier(), blitMaterial, 1);

                // pingpong
                var rttmp = m_TmpRT1;
                m_TmpRT1 = m_TmpRT2;
                m_TmpRT2 = rttmp;
            }

            // final pass
            cmd.SetGlobalFloat(BlurOffset, 0.5f + passes - 1f);
            Blit(cmd, m_TmpRT1.Identifier(), source, blitMaterial);

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            base.OnCameraCleanup(cmd);
            CoreUtils.Destroy(samplingMaterial);
        }
    }



    public Material blitMaterial;
    PseudoLensflarePass _blitPass;

    private static readonly int Offset = Shader.PropertyToID("_Offset");
    private static readonly int Power = Shader.PropertyToID("_Power");
    private static readonly int GhostSpacing = Shader.PropertyToID("_GhostSpacing");
    private static readonly int GhostCount = Shader.PropertyToID("_GhostCount");
    private static readonly int HaloWidth = Shader.PropertyToID("_HaloWidth");
    private static readonly int BlurOffset = Shader.PropertyToID("_BlurOffset");

    public override void Create()
    {
        _blitPass = new PseudoLensflarePass(blitMaterial);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        InjectPass(renderer, _blitPass);
    }

    public static void InjectPass(ScriptableRenderer renderer, PseudoLensflarePass pass)
    {
        var component = VolumeManager.instance.stack.GetComponent<PseudoFlareVolume>();
        if (component == null || !component.enabled.value) return;

        if (pass.blitMaterial == null)
        {
            Debug.LogWarningFormat("Missing Blit Material. blit pass will not execute. Check for missing reference in the assigned renderer.");
            return;
        }

        var src = renderer.cameraColorTarget;
        var dest = RenderTargetHandle.CameraTarget;

        pass.Setup(src, dest, component);
        renderer.EnqueuePass(pass);
    }
}