using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using WaterSystem.Rendering;

[ExecuteAlways]
public class CloudRenderer : MonoBehaviour
{
    public Mesh[] cloudMeshes;
    public Material cloudMaterial;
    public ParticleSystem ps;

    private ParticleSystem.Particle[] particles;
    private MaterialPropertyBlock[] mpbs;
    private Vector3 cameraPosition;
    
    private static readonly int BaCloudData = Shader.PropertyToID("_BA_CloudData");

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += RenderPipelineManagerOnbeginCameraRendering;
        PlanarReflections.BeginPlanarReflections += RenderPipelineManagerOnbeginCameraRendering;
        
        var main = ps.main;
        particles = new ParticleSystem.Particle[main.maxParticles];
        mpbs = new MaterialPropertyBlock[main.maxParticles];
        for (var index = 0; index < mpbs.Length; index++)
        {
            mpbs[index] = new MaterialPropertyBlock();
        }
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= RenderPipelineManagerOnbeginCameraRendering;
        PlanarReflections.BeginPlanarReflections -= RenderPipelineManagerOnbeginCameraRendering;
    }

    private void RenderPipelineManagerOnbeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        DrawClouds(camera);
    }
    
    public void DrawClouds(Camera camera)
    {
        if (!cloudMaterial || cloudMeshes == null || cloudMeshes.Length == 0) return;
        
        var aliveCount = ps.GetParticles(particles);
        
        Profiler.BeginSample("Sort Clouds");
        cameraPosition = camera.transform.position;
        // order the array of particles by distance to camera
        System.Array.Sort(particles, DistanceSort);
        Profiler.EndSample();

        Profiler.BeginSample("Draw Clouds");
        for (var index = 0; index < aliveCount; index++)
        {
            var particle = particles[index];
            if (particle.remainingLifetime <= 0.001f) continue;

            var pos = particle.position * SkyboxSystem.SkyboxScale + camera.transform.position * (1 - SkyboxSystem.SkyboxScale);

            var q = Quaternion.LookRotation(particle.position - camera.transform.position);
            Random.InitState((int)particle.randomSeed);
            var mesh = cloudMeshes[Random.Range(0, cloudMeshes.Length)];

            var scale = particle.startSize3D;
            scale.x *= Random.value > 0.5f ? 1f : -1f;

            var data = Vector4.zero;
            data.x = scale.x;
            data.w = particle.GetCurrentColor(ps).a / 255f;
            
            mpbs[index].SetVector(BaCloudData, data);
            
            Graphics.DrawMesh(mesh, Matrix4x4.TRS(pos, q, scale * SkyboxSystem.SkyboxScale),
                cloudMaterial, LayerMask.NameToLayer("3DSkybox"), camera, 0, mpbs[index], false, false, false);
        }
        Profiler.EndSample();
    }

    private int DistanceSort(ParticleSystem.Particle a, ParticleSystem.Particle b)
    {
        return Vector3.Distance(a.position, cameraPosition)
            .CompareTo(Vector3.Distance(b.position, cameraPosition));
    }
}
