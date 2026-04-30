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
        private const string ProfilerTag = "3D Skybox Pass";
        private static readonly int s_WorldSpaceCameraPos = Shader.PropertyToID("_WorldSpaceCameraPos");

        private readonly ShaderTagId[] m_ShaderTagIds =
        {
            new ShaderTagId("SRPDefaultUnlit"),
            new ShaderTagId("UniversalForward"),
            new ShaderTagId("LightweightForward"),
        };

        public float Scale;
        public LayerMask mask;

        private static SkyboxSystem system;

        private class PassData
        {
            public RendererListHandle rendererList;
            public Matrix4x4 scaledViewMatrix;
            public Matrix4x4 projectionMatrix;
            public Matrix4x4 restoreViewMatrix;
            public Matrix4x4 restoreProjectionMatrix;
            public Vector3 cameraPositionScaled;
            public Vector3 cameraPosition;
        }

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            if (system == null)
                system = Object.FindFirstObjectByType<SkyboxSystem>();

            var cameraData = frameData.Get<UniversalCameraData>();
            var renderingData = frameData.Get<UniversalRenderingData>();
            var resourceData = frameData.Get<UniversalResourceData>();

            // Skip on depth-only / offscreen cameras with no active colour attachment
            // (e.g. WaterSystem's CaptureDepthMap camera).
            if (!resourceData.activeColorTexture.IsValid())
                return;

            var cam = cameraData.camera;
            var originalView = cameraData.GetViewMatrix();
            var renderIntoTexture = cameraData.IsRenderTargetProjectionMatrixFlipped(
                resourceData.activeColorTexture, resourceData.activeDepthTexture);
            var projection = GL.GetGPUProjectionMatrix(cameraData.GetProjectionMatrix(), renderIntoTexture);

            var cameraPosition = cam.transform.position;
            var camPositionView = originalView.GetColumn(3);
            var camScale = camPositionView * Scale;
            var scaledView = originalView;
            scaledView.SetColumn(3, new Vector4(camScale.x, camScale.y, camScale.z, camPositionView.w));

            var stencilState = StencilState.defaultValue;
            stencilState.enabled = true;
            stencilState.SetCompareFunction(CompareFunction.Equal);

            var stateBlock = new RenderStateBlock(RenderStateMask.Stencil | RenderStateMask.Depth)
            {
                stencilReference = 0,
                stencilState = stencilState,
            };

            using (var builder = renderGraph.AddRasterRenderPass<PassData>(ProfilerTag, out var passData))
            {
                passData.rendererList = renderGraph.CreateRendererList(
                    new RendererListDesc(m_ShaderTagIds, renderingData.cullResults, cam)
                    {
                        sortingCriteria = SortingCriteria.CommonTransparent,
                        renderQueueRange = RenderQueueRange.transparent,
                        layerMask = mask,
                        stateBlock = stateBlock,
                    });

                passData.scaledViewMatrix = scaledView;
                passData.projectionMatrix = projection;
                passData.restoreViewMatrix = originalView;
                passData.restoreProjectionMatrix = projection;
                passData.cameraPositionScaled = cameraPosition * Scale;
                passData.cameraPosition = cameraPosition;

                builder.SetRenderAttachment(resourceData.activeColorTexture, 0, AccessFlags.Write);
                builder.SetRenderAttachmentDepth(resourceData.activeDepthTexture, AccessFlags.ReadWrite);
                builder.UseRendererList(passData.rendererList);
                builder.AllowPassCulling(false);

                builder.SetRenderFunc(static (PassData data, RasterGraphContext context) =>
                {
                    // Scale the camera for the 3D skybox draw
                    context.cmd.SetViewProjectionMatrices(data.scaledViewMatrix, data.projectionMatrix);
                    context.cmd.SetGlobalVector(s_WorldSpaceCameraPos, data.cameraPositionScaled);

                    context.cmd.DrawRendererList(data.rendererList);

                    // Restore matrices/camera position for subsequent passes
                    context.cmd.SetViewProjectionMatrices(data.restoreViewMatrix, data.restoreProjectionMatrix);
                    context.cmd.SetGlobalVector(s_WorldSpaceCameraPos, data.cameraPosition);
                });
            }
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
