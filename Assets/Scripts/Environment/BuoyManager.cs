using UnityEngine;
using UnityEngine.Serialization;
using Unity.Collections;
using Unity.Mathematics;
using WaterSystem;

public class BuoyManager : MonoBehaviour
{
    [FormerlySerializedAs("particleSystem")] public ParticleSystem ps;
    private ParticleSystem.ShapeModule _particleShape;
    private Mesh _mesh;
    private Vector3[] _vertices;
    private Transform[] _buoys;
    private NativeArray<float3> _samplePoints; // sample points for height calc
    private float3[] _heights; // water height array(only size of 1 when simple or non-physical)
    private float3[] _normals; // water normal array(only used when non-physical and size of 1 also when simple)

    private int _guid;
    // Start is called before the first frame update
    private void Start()
    {
        _guid = gameObject.GetInstanceID();

        _buoys = new Transform[transform.childCount - 1];
        _mesh = new Mesh();
        var triangles = new int[_buoys.Length * 3];
        _vertices = new Vector3[_buoys.Length];
        _samplePoints = new NativeArray<float3>(_buoys.Length, Allocator.Persistent);
        _heights = new float3[_buoys.Length];
        _normals = new float3[_buoys.Length];

        for (var i = 0; i < _buoys.Length; i++)
        {
            _buoys[i] = transform.GetChild(i);
            _samplePoints[i] = _buoys[i].position;
            _vertices[i] = _samplePoints[i];
            triangles[3 * i] = i;
            triangles[3 * i + 1] = (int)Mathf.Repeat(i + 1, _buoys.Length);
            triangles[3 * i + 2] = (int)Mathf.Repeat(i + 2, _buoys.Length);
        }

        _mesh.vertices = _vertices;
        _mesh.triangles = triangles;

        if (ps)
        {
            _particleShape = ps.shape;
            _particleShape.mesh = _mesh;
        }
    }

    private void OnDisable()
    {
        _samplePoints.Dispose();
    }

    // Update is called once per frame
    private void Update()
    {
        GerstnerWavesJobs.UpdateSamplePoints(ref _samplePoints, _guid);
        GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);
        
        for (var i = 0; i < _buoys.Length; i++)
        {
            var vec  = _buoys[i].position;
            vec.y = _heights[i].y;
            _buoys[i].position = vec;
            _vertices[i] = vec;
            _buoys[i].up = Vector3.Slerp(_buoys[i].up, _normals[i], Time.deltaTime);
        }

        _mesh.vertices = _vertices;
    }
}
