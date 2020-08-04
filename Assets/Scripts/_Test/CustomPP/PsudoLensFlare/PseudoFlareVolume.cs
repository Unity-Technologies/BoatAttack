using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable, VolumeComponentMenu("Custom/Pseudo Lensflare")]
public class PseudoFlareVolume : VolumeComponent
{

    public BoolParameter enabled = new BoolParameter(false);
    [Range(-10f, 10f), Tooltip("Grayscale effect intensity")]
    public FloatParameter offset = new FloatParameter(0.0f);
    [Range(0f, 10f), Tooltip("Grayscale effect intensity")]
    public FloatParameter power = new FloatParameter(1.0f);

    public FloatParameter ghostSpacing = new FloatParameter(0.25f);
    public IntParameter ghostCount = new IntParameter(3);
    public FloatParameter haloWidth = new FloatParameter(1.0f);

    protected override void OnEnable()
    {
        base.OnEnable();

        //RenderPipelineManager.beginCameraRendering += Inject;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        //RenderPipelineManager.beginCameraRendering -= Inject;
    }

    private void Inject(ScriptableRenderContext context, Camera camera)
    {
        PseudoFlareVolume component = VolumeManager.instance.stack.GetComponent(typeof(PseudoFlareVolume)) as PseudoFlareVolume;
        if (component == null || !component.enabled.value)
        {
            Debug.Log($"no volume component in camera {camera.name}");
            return;
        }

        var renderer = camera.GetUniversalAdditionalCameraData().scriptableRenderer;

        Debug.Log($"effect volume {renderer}");
        PseudoLensflareFeature.InjectPass(renderer, new PseudoLensflareFeature.PseudoLensflarePass(new Material(Shader.Find("Hidden/PostFX/PseudoLensFlare"))));
    }
}
