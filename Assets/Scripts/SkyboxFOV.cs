/*using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

namespace UnityEngine.Experimental.Rendering.LightweightPipeline
{
    [ImageEffectAllowedInSceneView]
    public class SkyboxFOV : MonoBehaviour, IAfterSkyboxPass
    {
        public float m_FOVOverride = 70;

        private DrawSkyboxFOVPass m_SkyboxFOVPass;

        DrawSkyboxFOVPass SkyboxFovPass
        {
            get
            {
                if (m_SkyboxFOVPass == null)
                    m_SkyboxFOVPass = new DrawSkyboxFOVPass();

                return m_SkyboxFOVPass;
            }
        }

        public ScriptableRenderPass GetPassToEnqueue(RenderTextureDescriptor baseDescriptor,
            RenderTargetHandle colorHandle, RenderTargetHandle depthHandle)
        {
            SkyboxFovPass.Setup(colorHandle, depthHandle, m_FOVOverride);
            
            return SkyboxFovPass;
        }
    }

    public class DrawSkyboxFOVPass : ScriptableRenderPass
    {
        public float fov = 70;

        private RenderTargetHandle colorAttachmentHandle { get; set; }
        private RenderTargetHandle depthAttachmentHandle { get; set; }

        public void Setup(RenderTargetHandle colorHandle, RenderTargetHandle depthHandle, float fov)
        {
            this.colorAttachmentHandle = colorHandle;
            this.depthAttachmentHandle = depthHandle;
            this.fov = fov;
        }

        public override void Execute(ScriptableRenderer renderer, ScriptableRenderContext context, ref RenderingData renderingData)
        {

            CommandBuffer cmd = CommandBufferPool.Get("Draw Skybox (Set RT's)");
            if (renderingData.cameraData.isStereoEnabled &&
                XRGraphicsConfig.eyeTextureDesc.dimension == TextureDimension.Tex2DArray)
            {
                cmd.SetRenderTarget(colorAttachmentHandle.Identifier(), depthAttachmentHandle.Identifier(), 0,
                    CubemapFace.Unknown, -1);
            }
            else
            {
                cmd.SetRenderTarget(colorAttachmentHandle.Identifier(), depthAttachmentHandle.Identifier());
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);

            var baseFOV = renderingData.cameraData.camera.fieldOfView; // save the current FOV

            renderingData.cameraData.camera.fieldOfView = fov; // set the new FOV

            context.DrawSkybox(renderingData.cameraData.camera); // render the Skybox

            renderingData.cameraData.camera.fieldOfView = baseFOV; // return the FOV
        }

    }
}*/