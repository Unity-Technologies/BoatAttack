using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

public class KawaseBlur : ScriptableRendererFeature
{
   public class KawasePass : ScriptableRenderPass
    {
        public static bool Enabled;
        public Material blurMaterial;
        public int passes;
        public int downsample;
        public bool copyToFramebuffer;
        public string targetName;
        string profilerTag;

        private RTHandle RT1;
        private RTHandle RT2;
        
        public KawasePass(string profilerTag)
        {
            this.profilerTag = profilerTag;
        }
        class PassData
        {
            internal TextureHandle src;
            internal TextureHandle dst;
            internal Material blurMat;
            internal float offset;
        }
        
        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
            UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();

            RenderTextureDescriptor opaqueDesc = cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;
            opaqueDesc.width /= downsample;
            opaqueDesc.height /= downsample;
            
            RenderingUtils.ReAllocateIfNeeded(ref RT1, opaqueDesc, name: "RT1");
            RenderingUtils.ReAllocateIfNeeded(ref RT2, opaqueDesc, name: "RT2");
            
            var rt1 = renderGraph.ImportTexture(RT1);
            var rt2 = renderGraph.ImportTexture(RT2);

            //First pass
            using (var builder = renderGraph.AddRasterRenderPass<PassData>(profilerTag, out PassData passData, profilingSampler))
            {
                passData.src = resourceData.activeColorTexture;
                passData.dst = rt1;
                passData.blurMat = blurMaterial;
                passData.offset = 1.5f;
                builder.UseTexture(passData.src);
                builder.SetRenderAttachment(passData.dst,0);
                builder.AllowGlobalStateModification(true);
                builder.SetRenderFunc(static (PassData data, RasterGraphContext context) =>
                {
                    context.cmd.SetGlobalFloat("_offset", data.offset);
                    Blitter.BlitTexture(context.cmd,data.dst,new Vector4(1,1,0,0),data.blurMat,0);
                });
            }
            //steps
            for (var i = 1; i < passes - 1; i++)
            {
                using (var builder =
                       renderGraph.AddRasterRenderPass<PassData>(profilerTag + "_step_" + i, out PassData passData, profilingSampler))
                {
                    passData.offset = 0.5f + i;
                    if (i % 2 == 0)
                    {
                        passData.src = rt1;
                        passData.dst = rt2;
                    }
                    else
                    {
                        passData.dst = rt1;
                        passData.src = rt2;
                    }
                    builder.AllowGlobalStateModification(true);
                    passData.blurMat = blurMaterial;
                    builder.UseTexture(passData.src);
                    builder.SetRenderAttachment(passData.dst,0);
                    builder.SetRenderFunc(static (PassData data, RasterGraphContext context) =>
                    {
                        context.cmd.SetGlobalFloat("_offset", data.offset);
                        Blitter.BlitTexture(context.cmd,data.dst,new Vector4(1,1,0,0),data.blurMat,0);
                    });
                }
            }
            
            //final
             using (var builder = renderGraph.AddRasterRenderPass<PassData>(profilerTag+"_Final", out PassData passData, profilingSampler))
             {
                passData.src = rt1;
                if (copyToFramebuffer)
                {
                    passData.dst = resourceData.activeColorTexture;
                }
                else
                {
                    passData.dst = rt2;
                }
                passData.blurMat = blurMaterial;
                passData.offset = 0.5f + passes - 1f;
                
                builder.UseTexture(passData.src);
                builder.SetRenderAttachment(passData.dst,0);
                builder.AllowGlobalStateModification(true);
                
                if (!copyToFramebuffer)
                {
                    builder.SetGlobalTextureAfterPass(rt2,Shader.PropertyToID(targetName));
                }
                
                builder.SetRenderFunc(static (PassData data, RasterGraphContext context) =>
                {
                    context.cmd.SetGlobalFloat("_offset", data.offset);
                    Blitter.BlitTexture(context.cmd,data.dst,new Vector4(1,1,0,0),data.blurMat,0);
                });

             }
        }
    }
   
    [System.Serializable]
    public class KawaseBlurSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
        public Material blurMaterial;

        [Range(2,15)]
        public int blurPasses = 2;

        [Range(1,16)]
        public int downsample = 1;
        public bool copyToFramebuffer;
        public string targetName = "_blurTexture";
    }
    
    public KawaseBlurSettings settings = new();
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
        var cam = renderingData.cameraData.camera;
            if (cam.cameraType != CameraType.Game) return;
            
        renderer.EnqueuePass(scriptablePass);
    }
}