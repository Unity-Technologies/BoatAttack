using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

public class SkyboxFeature : ScriptableRendererFeature
{
    class SkyboxPass : ScriptableRenderPass
    {
        private const string ProfilerTag = "Skybox Pass 3D";
        
        ShaderTagId[] m_ShaderTagIdList = {
            new("SRPDefaultUnlit"),
            new("UniversalForward"),
            new("LightweightForward")
        };

        public float Scale;
        private static SkyboxSystem system;
        public LayerMask mask;

        class PassData
        {
            internal RenderStateBlock m_RenderStateBlock;
            internal float scale;
            internal UniversalCameraData cameraData;
            internal RendererListHandle renderList;
            internal TextureHandle dst;
            internal TextureHandle dstDepth;
        }
        
        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            if (system == null) system = FindAnyObjectByType<SkyboxSystem>();
            
            using (var builder = renderGraph.AddRasterRenderPass<PassData>(ProfilerTag, out var passData, profilingSampler))
            {
                UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();
                UniversalRenderingData renderingData = frameData.Get<UniversalRenderingData>();
                UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();

                passData.cameraData = cameraData;
                
                passData.m_RenderStateBlock.mask = RenderStateMask.Stencil | RenderStateMask.Depth;
                var stencilState = StencilState.defaultValue;
                stencilState.SetCompareFunction(CompareFunction.Equal);
                passData.m_RenderStateBlock.stencilReference = 0;
                passData.m_RenderStateBlock.stencilState = stencilState;
                passData.scale = Scale;
                passData.dst = resourceData.activeColorTexture;
                passData.dstDepth = resourceData.activeDepthTexture;
                passData.renderList = renderGraph.CreateRendererList(
                    new RendererListDesc(m_ShaderTagIdList, renderingData.cullResults, cameraData.camera)
                    {
                        sortingCriteria = SortingCriteria.CommonTransparent,
                        renderQueueRange = RenderQueueRange.transparent,
                        layerMask = mask
                    });
                builder.AllowPassCulling(false);
                builder.SetRenderAttachment(resourceData.activeColorTexture,0);
                builder.UseRendererList(passData.renderList);
                builder.SetRenderFunc(static (PassData passData,RasterGraphContext context) => RenderFn(passData,context));
            }
        }

        static void RenderFn(PassData data, RasterGraphContext context)
        {
            // var cmd = context.cmd;
            // // setup skybox cam
            // var worldSpaceCameraPos = data.cameraData.worldSpaceCameraPos;
            // var viewMatrix = data.cameraData.GetViewMatrix();
            // var projMatrix = data.cameraData.GetGPUProjectionMatrix();
            //
            // var camPosition = viewMatrix.GetColumn(3);
            // var camScale = camPosition * data.scale;
            // var cameraTranslation = new Vector4(camScale.x, camScale.y, camScale.z, camPosition.w);
            // viewMatrix.SetColumn(3, cameraTranslation);
            // cmd.SetViewProjectionMatrices(viewMatrix, projMatrix);
            // cmd.SetGlobalVector("_WorldSpaceCameraPos", worldSpaceCameraPos * data.scale);
            // //draw transparent skybox
            //
            context.cmd.DrawRendererList(data.renderList);
            //return normal cam
            // cmd.SetViewProjectionMatrices(data.cameraData.GetViewMatrix(), projMatrix);
            // cmd.SetGlobalVector("_WorldSpaceCameraPos", worldSpaceCameraPos);
        }
    }

    SkyboxPass m_ScriptablePass;
    public RenderPassEvent injectionPoint;
    public LayerMask mask;
    public int ratioScale = 64;

    public override void Create()
    {
        m_ScriptablePass = new SkyboxPass
        {
            renderPassEvent = injectionPoint, 
            Scale = 1.0f / ratioScale, 
            mask = mask
        };
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}