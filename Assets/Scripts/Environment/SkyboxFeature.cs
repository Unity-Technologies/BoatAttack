using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SkyboxFeature : ScriptableRendererFeature
{
    class SkyboxPass : ScriptableRenderPass
    {
        private const string ProfilerTag = "3D Skybox Pass";
        FilteringSettings m_TransparentFilteringSettings;
        RenderStateBlock m_RenderStateBlock;
        List<ShaderTagId> m_ShaderTagIdList = new List<ShaderTagId>{new ShaderTagId("SRPDefaultUnlit"),
            new ShaderTagId("UniversalForward"),
            new ShaderTagId("LightweightForward")};

        public float Scale;
        private static SkyboxSystem system;
        public LayerMask mask;
        
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            if (system == null)
                system = FindObjectOfType<SkyboxSystem>();
            m_RenderStateBlock.mask = RenderStateMask.Stencil | RenderStateMask.Depth;
            StencilState stencilState = StencilState.defaultValue;
            stencilState.SetCompareFunction(CompareFunction.Equal);
            m_RenderStateBlock.stencilReference = 0;
            m_RenderStateBlock.stencilState = stencilState;

            m_TransparentFilteringSettings = new FilteringSettings(RenderQueueRange.transparent, mask);
        }
        
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cameraData = renderingData.cameraData;
            var cameraPosition = cameraData.camera.transform.position;
            DrawingSettings transparentDrawingSettings = CreateDrawingSettings(m_ShaderTagIdList, ref renderingData, SortingCriteria.CommonTransparent);

            CommandBuffer cmd = CommandBufferPool.Get(ProfilerTag);
            // setup skybox cam
            {
                var viewMatrix = cameraData.GetViewMatrix();
                var camPosition = viewMatrix.GetColumn(3);
                var camScale = camPosition * Scale;
                var cameraTranslation = new Vector4(camScale.x, camScale.y, camScale.z, camPosition.w);
                viewMatrix.SetColumn(3, cameraTranslation);

                RenderingUtils.SetViewAndProjectionMatrices(cmd, viewMatrix, cameraData.GetGPUProjectionMatrix(), true);
                cmd.SetGlobalVector("_WorldSpaceCameraPos", cameraPosition * Scale);
            }

            context.ExecuteCommandBuffer(cmd);
            cmd.Clear();

            //draw transparent skybox
            context.DrawRenderers(renderingData.cullResults, ref transparentDrawingSettings, ref m_TransparentFilteringSettings,
                ref m_RenderStateBlock);

            //return normal cam
            {
                RenderingUtils.SetViewAndProjectionMatrices(cmd, cameraData.GetViewMatrix(), cameraData.GetGPUProjectionMatrix(), true);
                cmd.SetGlobalVector("_WorldSpaceCameraPos", cameraPosition);
            }
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);

        }
    }

    SkyboxPass m_ScriptablePass;
    public RenderPassEvent injectionPoint;
    public LayerMask mask;
    public int ratioScale = 64;

    public override void Create()
    {
        m_ScriptablePass = new SkyboxPass {renderPassEvent = injectionPoint, Scale = 1.0f / ratioScale, mask = mask};
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}