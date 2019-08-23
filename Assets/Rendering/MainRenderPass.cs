using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MainRenderPass : ScriptableRenderPass
{
    FilteringSettings m_OpaqueFilteringSettings;
    FilteringSettings m_TransparentFilteringSettings;
    ShaderTagId m_UniversalForwardPass = new ShaderTagId("UniversalForward");

    public MainRenderPass(RenderPassEvent renderPassEvent)
    {
        this.renderPassEvent = renderPassEvent;
        m_OpaqueFilteringSettings = new FilteringSettings(RenderQueueRange.opaque);
        m_TransparentFilteringSettings = new FilteringSettings(RenderQueueRange.transparent);
    }

    //public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
    //{
    //    ConfigureTarget(BuiltinRenderTextureType.CurrentActive, BuiltinRenderTextureType.CurrentActive);
    //}

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var opaqueDrawingSettings = CreateDrawingSettings(m_UniversalForwardPass, ref renderingData, SortingCriteria.CommonOpaque);
        var transparentDrawingSettings = CreateDrawingSettings(m_UniversalForwardPass, ref renderingData, SortingCriteria.CommonTransparent);

        context.DrawRenderers(renderingData.cullResults, ref opaqueDrawingSettings, ref m_OpaqueFilteringSettings);
        context.DrawSkybox(renderingData.cameraData.camera);
        context.DrawRenderers(renderingData.cullResults, ref transparentDrawingSettings, ref m_TransparentFilteringSettings);
    }
}
