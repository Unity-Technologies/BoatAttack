using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu]
public class BoatRendererData : ScriptableRendererData
{
    [ReloadGroup]
    public sealed class ShaderResources
    {
        [Reload("Shaders/Utils/Blit.shader")]
        public Shader blitPS;

        [Reload("Shaders/Utils/CopyDepth.shader")]
        public Shader copyDepthPS;

        [Reload("Shaders/Utils/ScreenSpaceShadows.shader")]
        public Shader screenSpaceShadowPS;

        [Reload("Shaders/Utils/Sampling.shader")]
        public Shader samplingPS;
    }

    [Reload("Runtime/Data/PostProcessData.asset")]
    public PostProcessData postProcessData = null;
    public ShaderResources shaders = null;

    protected override ScriptableRenderer Create()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            ResourceReloader.ReloadAllNullIn(this, UniversalRenderPipelineAsset.packagePath);
            ResourceReloader.ReloadAllNullIn(postProcessData, UniversalRenderPipelineAsset.packagePath);
        }
#endif

        return new BoatRenderer(this);
    }
}
