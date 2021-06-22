using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class SkyboxSystem : MonoBehaviour
{
    public int scalefactor = 64;

    public static float SkyboxScale { get; set; }

    public Renderer[] renderList;

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += OnCamera;
        RenderPipelineManager.endCameraRendering += OnCameraFinish;
        
        CollectRenderers();
    }

    private void CollectRenderers()
    {
        renderList = GetComponentsInChildren<Renderer>();
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnCamera;
        RenderPipelineManager.endCameraRendering -= OnCameraFinish;
    }

    private void OnCamera(ScriptableRenderContext context, Camera camera)
    {
        var scaleRatio = 1.0f / scalefactor;
        SkyboxScale = scaleRatio;
        transform.position = camera.transform.position * (1 - scaleRatio);
        transform.localScale = Vector3.one * scaleRatio;
    }

    private void OnCameraFinish(ScriptableRenderContext context, Camera camera)
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one;
    }
}
