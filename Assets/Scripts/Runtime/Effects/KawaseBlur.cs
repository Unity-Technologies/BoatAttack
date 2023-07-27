using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class KawaseBlur : ScriptableRendererFeature
{
    [System.Serializable]
    public class KawaseBlurSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        public Material blurMaterial;

        [Range(2,15)]
        public int blurPasses = 1;

        [Range(1,4)]
        public int downsample = 1;
        public bool copyToFramebuffer;
        public string targetName = "_blurTexture";
    }

    public KawaseBlurSettings settings = new();

    public class KawasePass : ScriptableRenderPass
    {
        public static bool Enabled;
        public Material blurMaterial;
        public int passes;
        public int downsample;
        public bool copyToFramebuffer;
        public string targetName;        
        string profilerTag;

        int tmpId1;
        int tmpId2;

        RTHandle RT1;
        RTHandle RT2;
        
        public KawasePass(string profilerTag)
        {
            this.profilerTag = profilerTag;
        }

        /*
        public override void RecordRenderGraph(RenderGraph renderGraph, FrameResources frameResources, ref RenderingData renderingData)
        {
            using (var builder =
                   renderGraph.AddRasterRenderPass<KawaseBlurSettings>(PassName, out var passData, m_InfiniteWater_Profile))
            {
                builder.SetRenderFunc((KawaseBlurSettings data, RasterGraphContext context) =>
                {
                    
                });
            }
        }
        */

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cam = renderingData.cameraData.camera;
            if (cam.cameraType != CameraType.Game || !Enabled) return;
            
            CommandBuffer cmd = CommandBufferPool.Get(profilerTag);
            
            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;

            opaqueDesc.width /= downsample;
            opaqueDesc.height /= downsample;

            RenderingUtils.ReAllocateIfNeeded(ref RT1, opaqueDesc, name:"RT1");
            RenderingUtils.ReAllocateIfNeeded(ref RT2, opaqueDesc, name:"RT2");
            
            cmd.SetGlobalFloat("_offset", 1.5f);
            Blitter.BlitCameraTexture(cmd, renderingData.cameraData.renderer.cameraColorTargetHandle, RT1, blurMaterial, 0);
            for (var i=1; i<passes-1; i++) {
                cmd.SetGlobalFloat("_offset", 0.5f + i);
                Blitter.BlitCameraTexture(cmd, RT1, RT2, blurMaterial, 0);
                (RT1, RT2) = (RT2, RT1);
            }

            // final pass
            cmd.SetGlobalFloat("_offset", 0.5f + passes - 1f);
            if (copyToFramebuffer) {
                Blitter.BlitCameraTexture(cmd, RT1, renderingData.cameraData.renderer.cameraColorTargetHandle, blurMaterial, 0);
            } else {
                Blitter.BlitCameraTexture(cmd, RT1, RT2, blurMaterial, 0);
                cmd.SetGlobalTexture(targetName, RT2);
            }

            context.ExecuteCommandBuffer(cmd);
            cmd.Clear();

            CommandBufferPool.Release(cmd);
        }
    }

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
}


