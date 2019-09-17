using System;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class CloudManager : MonoBehaviour
{
    public float scale = 0.1f;
    public Material material;
    public LayerMask layer;

    [NonSerialized] private Cloud[] clouds;
    
    private void OnValidate()
    {
        Init();
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += CloudAlign;
        //PlanarReflections.beginPlanarReflections += CloudAlign;
        Init();
    }

    void Init()
    {
        transform.localScale = Vector3.one * scale;
        
        clouds = new Cloud[transform.childCount];

        for (int i = 0; i < clouds.Length; i++)
        {
            var cloud = new Cloud();
            cloud.t = transform.GetChild(i);
            cloud.matrix = cloud.t.localToWorldMatrix;
            cloud.mesh = cloud.t.GetComponent<MeshFilter>().sharedMesh;
            cloud.t.GetComponent<Renderer>().enabled = false;
            clouds[i] = cloud;
        }
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= CloudAlign;
        //PlanarReflections.beginPlanarReflections -= CloudAlign;
    }

    void CloudAlign(ScriptableRenderContext context, Camera camera)
    {
        if (camera.cameraType != CameraType.Preview)
        {
            var t = camera.transform;
            var position = t.position;
            position -= position * scale;
            transform.position = position;

            //var cmd = CommandBufferPool.Get("clouds");
            
            Debug.Log($"Rendering {clouds.Length} clouds for camera:{camera.name}");
            foreach (var cloud in clouds)
            {
                //cmd.DrawMesh(cloud.mesh, cloud.t.localToWorldMatrix, material);
                Graphics.DrawMesh(cloud.mesh, cloud.t.localToWorldMatrix, material, 8);
            }
            
            //context.ExecuteCommandBuffer(cmd);
            //context.Submit();
            //CommandBufferPool.Release(cmd);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 750f);
    }

    public class Cloud
    {
        public Transform t;
        public Matrix4x4 matrix;
        public Mesh mesh;
    }
}
