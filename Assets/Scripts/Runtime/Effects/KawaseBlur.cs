using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using WaterSystem;
using WaterSystem.Rendering;

public class KawaseBlur : ScriptableRendererFeature
{
    [System.Serializable]
    public class KawaseBlurSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        public Material blurMaterial = null;

        [Range(2,15)]
        public int blurPasses = 1;

        [Range(1,4)]
        public int downsample = 1;
        public bool copyToFramebuffer;
        public string targetName = "_blurTexture";
    }

    public KawaseBlurSettings settings = new KawaseBlurSettings();
    
    KawasePass scriptablePass;

    public override void Create()
    {
        scriptablePass = new KawasePass("KawaseBlur")
        {
            blurMaterial = settings.blurMaterial,
            passes = settings.blurPasses,
            downsample = settings.downsample,
            copyToFramebuffer = settings.copyToFramebuffer,
            targetName = settings.targetName,
            renderPassEvent = settings.renderPassEvent
        };
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(scriptablePass);
    }

    protected override void Dispose(bool disposing)
    {
        scriptablePass.Dispose();
    }
    
    public class KawasePass : ScriptableRenderPass
    {
        public static bool Enabled;

        public class PassData
        {
            public Material material;
            public TextureHandle rtA;
            public TextureHandle rtB;
            public float offset;
        }
        
        public Material blurMaterial;
        public int passes;
        public int downsample;
        public bool copyToFramebuffer;
        public string targetName;        
        string profilerTag;
        private ProfilingSampler profileSampler;

        RTHandle tmpRT1;
        RTHandle tmpRT2;

        public KawasePass(string profilerTag)
        {
            this.profilerTag = profilerTag;
            profileSampler = new ProfilingSampler(this.profilerTag);
        }
        
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData data)
        {
            var desc = data.cameraData.cameraTargetDescriptor;
            desc.width /= downsample;
            desc.height /= downsample;
            desc.bindMS = false;
            desc.msaaSamples = 1;
            desc.depthBufferBits = 0;

            RenderingUtils.ReAllocateIfNeeded(ref tmpRT1, desc, name:"KawazeRT1");
            RenderingUtils.ReAllocateIfNeeded(ref tmpRT2, desc, name:"KawazeRT2");
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera;
            if (cam.cameraType != CameraType.Game || !Enabled) return;
            
            var cmd = CommandBufferPool.Get(profilerTag);
            
            cmd.SetGlobalFloat("_offset", 1.5f);
            Blitter.BlitCameraTexture(cmd, renderingData.cameraData.renderer.cameraColorTargetHandle, tmpRT1, blurMaterial, 0);
            
            for (var i=1; i<passes-1; i++) {
                cmd.SetGlobalFloat("_offset", 0.5f + i);
                Blitter.BlitCameraTexture(cmd, tmpRT1, tmpRT2, blurMaterial, 0);

                // pingpong
                (tmpRT1, tmpRT2) = (tmpRT2, tmpRT1);
            }

            // final pass
            cmd.SetGlobalFloat("_offset", 0.5f + passes - 1f);
            if (copyToFramebuffer)
            {
                Blitter.BlitCameraTexture(cmd, tmpRT1, renderingData.cameraData.renderer.cameraColorTargetHandle, blurMaterial, 0);
            } 
            else
            {
                Blitter.BlitCameraTexture(cmd, tmpRT1, tmpRT2, blurMaterial, 0);
                cmd.SetGlobalTexture(targetName, tmpRT2);
            }
            

            context.ExecuteCommandBuffer(cmd);
            cmd.Clear();

            CommandBufferPool.Release(cmd);
        }

        public override void RecordRenderGraph(RenderGraph renderGraph, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera;
            if (cam.cameraType != CameraType.Game || !Enabled) return;

            var desc = renderingData.cameraData.cameraTargetDescriptor;
            desc.width /= downsample;
            desc.height /= downsample;
            desc.bindMS = false;
            desc.msaaSamples = 1;
            desc.depthBufferBits = 0;

            var colorA = CreateRenderGraphTexture(renderGraph, desc, "KawazeA");
            var colorB = CreateRenderGraphTexture(renderGraph, desc, "KawazeB");

            renderGraph.BeginProfilingSampler(profileSampler);
            
            DoBlurStep(renderGraph, UniversalRenderer.m_ActiveRenderGraphColor, colorA, 1.5f, "Kawaze First Pass");
            for (var i = 1; i < passes - 1; i++)
            {
                DoBlurStep(renderGraph, colorA, colorB, 0.5f + i, $"Kawaze Passes");
                (colorA, colorB) = (colorB, colorA);
            }
            DoBlurStep(renderGraph, colorA, UniversalRenderer.m_ActiveRenderGraphColor, 0.5f + passes - 1f, "Kawase Final Pass");
            
            renderGraph.EndProfilingSampler(profileSampler);
            
        }

        private void DoBlurStep(RenderGraph graph, TextureHandle handleA, TextureHandle handleB, float offset, string name)
        {
            using (var builder = graph.AddRenderPass<PassData>(name, out var pass))
            {
                builder.AllowPassCulling(false);

                pass.rtA = builder.ReadTexture(handleA);
                pass.rtB = builder.UseColorBuffer(handleB, 0);
                pass.offset = offset;

                pass.material = blurMaterial;
                
                builder.SetRenderFunc((PassData data, RenderGraphContext context) =>
                {
                    context.cmd.SetGlobalFloat("_offset", data.offset);
                    Blitter.BlitCameraTexture(context.cmd, data.rtA, data.rtB, pass.material, 0);
                });
            }
        }

        public void Dispose()
        {
            tmpRT1?.Release();
            tmpRT2?.Release();
        }
    }
    
    static TextureHandle CreateRenderGraphTexture(RenderGraph renderGraph, RenderTextureDescriptor desc, string name, bool clear = false,
        FilterMode filterMode = FilterMode.Point, TextureWrapMode wrapMode = TextureWrapMode.Clamp)
    {
        TextureDesc rgDesc = new TextureDesc(desc.width, desc.height);
        rgDesc.dimension = desc.dimension;
        rgDesc.clearBuffer = clear;
        rgDesc.bindTextureMS = desc.bindMS;
        rgDesc.colorFormat = desc.graphicsFormat;
        rgDesc.depthBufferBits = (DepthBits)desc.depthBufferBits;
        rgDesc.slices = desc.volumeDepth;
        rgDesc.msaaSamples = (MSAASamples)desc.msaaSamples;
        rgDesc.name = name;
        rgDesc.enableRandomWrite = false;
        rgDesc.filterMode = filterMode;
        rgDesc.wrapMode = wrapMode;
        rgDesc.isShadowMap = desc.shadowSamplingMode != ShadowSamplingMode.None;
        // TODO RENDERGRAPH: depthStencilFormat handling?

        return renderGraph.CreateTexture(rgDesc);
    }
}


