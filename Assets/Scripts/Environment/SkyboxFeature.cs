using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SkyboxFeature : ScriptableRendererFeature
{
    class SkyboxPass : ScriptableRenderPass
    {
        private const string ProfilerTag = "3D Skybox Pass";
        FilteringSettings m_OpaqueFilteringSettings;
        FilteringSettings m_TransparentFilteringSettings;
        RenderStateBlock m_RenderStateBlock;
        readonly ProfilingSampler _profilingSampler = new ProfilingSampler("3D Skybox Pass");
        List<ShaderTagId> m_ShaderTagIdList = new List<ShaderTagId>{new ShaderTagId("SRPDefaultUnlit"),
            new ShaderTagId("UniversalForward"),
            new ShaderTagId("LightweightForward")};

        public float Scale;

        public LayerMask mask;
        // This method is called before executing the render pass.
        // It can be used to configure render targets and their clear state. Also to create temporary render target textures.
        // When empty this render pass will render to the active camera render target.
        // You should never call CommandBuffer.SetRenderTarget. Instead call <c>ConfigureTarget</c> and <c>ConfigureClear</c>.
        // The render pipeline will ensure target setup and clearing happens in an performance manner.
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            m_RenderStateBlock.mask = RenderStateMask.Stencil | RenderStateMask.Depth;
            StencilState stencilState = StencilState.defaultValue;
            stencilState.SetCompareFunction(CompareFunction.Equal);
            m_RenderStateBlock.stencilReference = 0;
            m_RenderStateBlock.stencilState = stencilState;
            //DepthState depthState = new DepthState(false, CompareFunction.Less);
            //m_RenderStateBlock.depthState = depthState;

            m_OpaqueFilteringSettings = new FilteringSettings(RenderQueueRange.opaque, mask);
            m_TransparentFilteringSettings = new FilteringSettings(RenderQueueRange.transparent, mask);
        }

        // Here you can implement the rendering logic.
        // Use <c>ScriptableRenderContext</c> to issue drawing commands or execute command buffers
        // https://docs.unity3d.com/ScriptReference/Rendering.ScriptableRenderContext.html
        // You don't have to call ScriptableRenderContext.submit, the render pipeline will call it at specific points in the pipeline.
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var cameraData = renderingData.cameraData;
            var cameraPosition = cameraData.camera.transform.position;
            DrawingSettings opaqueDrawingSettings = CreateDrawingSettings(m_ShaderTagIdList, ref renderingData, renderingData.cameraData.defaultOpaqueSortFlags);
            DrawingSettings transparentDrawingSettings = CreateDrawingSettings(m_ShaderTagIdList, ref renderingData, SortingCriteria.CommonTransparent);

            CommandBuffer cmd = CommandBufferPool.Get(ProfilerTag);
            using (new ProfilingScope(cmd, _profilingSampler))
            {
                // setup skybox cam
                {
                    var viewMatrix = cameraData.GetViewMatrix();
                    var camPosition = viewMatrix.GetColumn(3);
                    var camScale = camPosition * Scale + camPosition;
                    var cameraTranslation = new Vector4(camScale.x, camScale.y, camScale.z, camPosition.w);
                    viewMatrix.SetColumn(3, cameraTranslation);

                    RenderingUtils.SetViewAndProjectionMatrices(cmd, viewMatrix, cameraData.GetGPUProjectionMatrix(), true);
                    cmd.SetGlobalVector("_WorldSpaceCameraPos", cameraPosition * Scale + cameraPosition);
                    //cmd.SetGlobalVector("_WorldSpaceCameraPos", cameraPosition * Scale);
                }

                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                //draw opaque skybox
                context.DrawRenderers(renderingData.cullResults, ref opaqueDrawingSettings, ref m_OpaqueFilteringSettings,
                    ref m_RenderStateBlock);

                //draw transparent skybox
                context.DrawRenderers(renderingData.cullResults, ref transparentDrawingSettings, ref m_TransparentFilteringSettings,
                    ref m_RenderStateBlock);

                //return normal cam
                {
                    RenderingUtils.SetViewAndProjectionMatrices(cmd, cameraData.GetViewMatrix(), cameraData.GetGPUProjectionMatrix(), true);
                    cmd.SetGlobalVector("_WorldSpaceCameraPos", cameraPosition);
                }
            }
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        /// Cleanup any allocated resources that were created during the execution of this render pass.
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            base.OnCameraCleanup(cmd);
        }
    }

    SkyboxPass m_ScriptablePass;
    private RenderObjectsPass opaquePass;
    public RenderPassEvent injectionPoint;
    public LayerMask mask;
    public int ratioScale = 64;

    public override void Create()
    {
        m_ScriptablePass = new SkyboxPass {renderPassEvent = injectionPoint, Scale = 1.0f / ratioScale, mask = mask};
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}