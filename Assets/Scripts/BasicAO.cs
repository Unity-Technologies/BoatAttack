using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
 
[Serializable]
[PostProcess(typeof(BasicAORenderer), PostProcessEvent.BeforeStack, "Custom/BasicAO")]
public sealed class BasicAO : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Effect intensity.")]
    public FloatParameter intensity = new FloatParameter { value = 1.0f };
    
    public TextureParameter noiseTexture = new TextureParameter{ value = null};
}
 
public sealed class BasicAORenderer : PostProcessEffectRenderer<BasicAO>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Post/BasicAO"));
        
        var noiseTexture = settings.noiseTexture.value == null
            ? RuntimeUtilities.whiteTexture
            : settings.noiseTexture.value;
        
        sheet.properties.SetTexture("_NoiseTex", noiseTexture);
        sheet.properties.SetFloat("_Intensity", settings.intensity);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
