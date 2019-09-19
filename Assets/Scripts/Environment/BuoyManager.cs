using Unity.Collections;
using UnityEngine;
using Unity.Mathematics;
using WaterSystem;

public class BuoyManager : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public ParticleSystem.ShapeModule particleShape;
    private Mesh _mesh;
    private Vector3[] verts;
    private Transform[] buoys;
    private NativeArray<float3> samplePoints; // sample points for height calc
    private float3[] heights; // water height array(only size of 1 when simple or non-physical)
    private float3[] normals; // water normal array(only used when non-physical and size of 1 also when simple)

    private int _guid;
    // Start is called before the first frame update
    void Start()
    {
        _guid = gameObject.GetInstanceID();

        buoys = new Transform[transform.childCount];
        _mesh = new Mesh();
        int[] triangles = new int[buoys.Length * 3];
        verts = new Vector3[buoys.Length];
        samplePoints = new NativeArray<float3>(buoys.Length, Allocator.Persistent);
        heights = new float3[buoys.Length];
        normals = new float3[buoys.Length];

        for (int i = 0; i < buoys.Length; i++)
        {
            buoys[i] = transform.GetChild(i);
            samplePoints[i] = buoys[i].position;
            verts[i] = samplePoints[i];
            triangles[3 * i] = i;
            triangles[3 * i + 1] = (int)Mathf.Repeat(i + 1, buoys.Length);
            triangles[3 * i + 2] = (int)Mathf.Repeat(i + 2, buoys.Length);
        }

        _mesh.vertices = verts;
        _mesh.triangles = triangles;

        if (particleSystem)
        {
            particleShape = particleSystem.shape;
            particleShape.mesh = _mesh;
        }
    }

    private void OnDisable()
    {
        samplePoints.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        GerstnerWavesJobs.UpdateSamplePoints(ref samplePoints, _guid);
        GerstnerWavesJobs.GetData(_guid, ref heights, ref normals);
        
        for (int i = 0; i < buoys.Length; i++)
        {
            Vector3 vec  = buoys[i].position;
            vec.y = heights[i].y;
            buoys[i].position = vec;
            verts[i] = vec;
            buoys[i].up = Vector3.Slerp(buoys[i].up, normals[i], Time.deltaTime);
        }

        _mesh.vertices = verts;
    }
}
