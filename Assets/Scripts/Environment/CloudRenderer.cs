using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.Collections;
using Random = UnityEngine.Random;

public class CloudRenderer : MonoBehaviour
{
    public Sprite[] sprites;
    private Mesh[] cloudMeshes;
    public Material cloudMaterial;
    public ParticleSystem ps;

    private NativeArray<ParticleSystem.Particle> particles;
    private ParticleSystem.Particle[] parts;

    private void Start()
    {
        cloudMeshes = new Mesh[sprites.Length];
        int i = 0;
        foreach (var sprite in sprites)
        {
            // verts
            var verts = new List<Vector3>();
            sprite.vertices.ToList().ForEach(x => verts.Add(new Vector3(x.x, x.y, 0.0f)));
            // triangles
            var tris = new List<int>();
            sprite.triangles.ToList().ForEach(x => tris.Add(x));
            // normals
            var normals = new Vector3[verts.Count];
            for (var index = 0; index < normals.Length; index++)
            {
                normals[index] = Vector3.forward;
            }

            var mesh = new Mesh
            {
                name = sprite.name,
                vertices = verts.ToArray(),
                triangles = tris.ToArray(),
                normals = normals.ToArray(),
                uv = sprite.uv,
                bounds = new Bounds(Vector3.zero, Vector3.one * 1000f)
            };

            cloudMeshes[i] = mesh;
            i++;
        }
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += RenderPipelineManagerOnbeginCameraRendering;
        RenderPipelineManager.beginFrameRendering += RenderPipelineManagerOnbeginFrameRendering;

        particles = new NativeArray<ParticleSystem.Particle>(ps.main.maxParticles, Allocator.Persistent);
        parts = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= RenderPipelineManagerOnbeginCameraRendering;
        RenderPipelineManager.beginFrameRendering -= RenderPipelineManagerOnbeginFrameRendering;

        particles.Dispose();
    }

    private void RenderPipelineManagerOnbeginFrameRendering(ScriptableRenderContext arg1, Camera[] arg2)
    {
        var camPos = Camera.main.transform.position;
        ps.GetParticles(parts);
        var l = parts.ToList().OrderByDescending(x => Vector3.Distance(x.position * 64f, camPos));
        parts = l.ToArray();
    }

    private void RenderPipelineManagerOnbeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        if (!cloudMaterial) return;

        var camPos = camera.transform.position * (1f / 64f);

        foreach (var particle in parts)
        {
            var q = Quaternion.LookRotation(particle.position - camPos);
            Random.InitState((int)particle.randomSeed);
            Graphics.DrawMesh(cloudMeshes[Random.Range(0, cloudMeshes.Length)], Matrix4x4.TRS(particle.position, q, particle.startSize3D), cloudMaterial, LayerMask.NameToLayer("3DSkybox"), camera);
        }
    }
}
