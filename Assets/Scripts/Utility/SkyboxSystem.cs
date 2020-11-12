using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class SkyboxSystem : MonoBehaviour
{
    public int scalefactor = 64;

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += OnCamera;
        RenderPipelineManager.endCameraRendering += OnCameraFinish;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnCamera;
        RenderPipelineManager.endCameraRendering -= OnCameraFinish;
    }

    private void OnCamera(ScriptableRenderContext context, Camera camera)
    {
        transform.position = Vector3.Lerp(camera.transform.position, Vector3.zero, 1f / scalefactor);
    }

    private void OnCameraFinish(ScriptableRenderContext context, Camera camera)
    {
        transform.position = Vector3.zero;
    }
}
