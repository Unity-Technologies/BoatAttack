using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[ExecuteAlways]
public class CloudRenderer : MonoBehaviour
{
    public Mesh[] cloudMeshes;
    public Material cloudMaterial;
    public ParticleSystem ps;

    private NativeArray<ParticleSystem.Particle> particles;
    private ParticleSystem.Particle[] parts;

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += RenderPipelineManagerOnbeginCameraRendering;
        RenderPipelineManager.beginFrameRendering += RenderPipelineManagerOnbeginFrameRendering;

        var main = ps.main;
        particles = new NativeArray<ParticleSystem.Particle>(main.maxParticles, Allocator.Persistent);
        parts = new ParticleSystem.Particle[main.maxParticles];
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= RenderPipelineManagerOnbeginCameraRendering;
        RenderPipelineManager.beginFrameRendering -= RenderPipelineManagerOnbeginFrameRendering;

        particles.Dispose();
    }

    private void RenderPipelineManagerOnbeginFrameRendering(ScriptableRenderContext arg1, Camera[] arg2)
    {
        if (Camera.main != null)
        {
            var camPos = Camera.main.transform.position;
            ps.GetParticles(parts);
            var l = parts.ToList().OrderByDescending(x => Vector3.Distance(x.position * 64f, camPos));
            parts = l.ToArray();
        }
    }

    private void RenderPipelineManagerOnbeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        if (!cloudMaterial || cloudMeshes == null || cloudMeshes.Length == 0) return;

        var camPos = camera.transform.position * (1f / 64f);

        foreach (var particle in parts)
        {
            var q = Quaternion.LookRotation(particle.position - camPos);
            Random.InitState((int)particle.randomSeed);
            var mesh = cloudMeshes[Random.Range(0, cloudMeshes.Length)];
            /*var m = Instantiate(mesh);
            var colors = new Color[mesh.vertexCount];
            var col = particle.GetCurrentColor(ps);
            for (var index = 0; index < colors.Length; index++)
            {
                colors[index] = col;
            }

            m.SetColors(colors);
            m.UploadMeshData(true);*/

            Graphics.DrawMesh(mesh, Matrix4x4.TRS(particle.position, q, particle.startSize3D), cloudMaterial, LayerMask.NameToLayer("3DSkybox"), camera);
        }
    }
}
