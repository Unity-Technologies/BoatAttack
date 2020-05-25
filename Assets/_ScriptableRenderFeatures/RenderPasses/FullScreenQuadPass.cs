using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace UnityEngine.Experimental.Rendering.Universal
{
    public class FullScreenQuadPass : ScriptableRenderPass
    {
        string m_ProfilerTag = "DrawFullScreenPass";

        FullScreenQuad.FullScreenQuadSettings m_Settings;

        public FullScreenQuadPass(FullScreenQuad.FullScreenQuadSettings settings)
        {
            renderPassEvent = settings.renderPassEvent;
            m_Settings = settings;
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            Camera camera = renderingData.cameraData.camera;

            var cmd = CommandBufferPool.Get(m_ProfilerTag);
            cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
            cmd.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, m_Settings.material);
            cmd.SetViewProjectionMatrices(camera.worldToCameraMatrix, camera.projectionMatrix);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
}
