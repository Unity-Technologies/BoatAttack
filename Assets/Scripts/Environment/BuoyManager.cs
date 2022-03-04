using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using WaterSystem;
using Object = UnityEngine.Object;

[ExecuteAlways]
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

    [SerializeField, HideInInspector] private BuoyPoint[] points;
    [SerializeField] private Vector3[] buoyPoints;
    
    // User Controls
    public float spacing = 2.0f;
    public float angleThreshold = 25.0f;
    
    // Objects
    public CinemachinePath cmPath;
    public Mesh buoyMesh;
    public Material buoyMaterial;
    public AssetReference arrow;
    private AsyncOperationHandle arrowHandle;
    private List<GameObject> arrows = new List<GameObject>();

    private int _guid;
    
    // Validate, updates when changed in the editor
    private void OnValidate()
    {
        if (cmPath && spacing > 0.1f)
        {
            UpdateSystem();
        }
    }

    private void OnEnable()
    {
        if(buoyPoints == null || buoyPoints.Length == 0) return;
        SetupArrays();
        _guid = gameObject.GetInstanceID();
        RefreshArrows();
    }

    private void OnDisable()
    {
        if(buoyPoints == null || buoyPoints.Length == 0) return;
        GerstnerWavesJobs.RemoveSamplePoints(_guid);
        _samplePoints.Dispose();
        CleanupArrows();
    }
    
    private void UpdateSystem()
    {
        if(buoyPoints == null || buoyPoints.Length == 0) return;
        
        GerstnerWavesJobs.RemoveSamplePoints(_guid);
        points = GeneratePoints(spacing, angleThreshold, cmPath);
        buoyPoints = SplitBuoys(points);
        SetupArrays();
        RefreshArrows();
    }

    private void SetupArrays()
    {
        if(_samplePoints.IsCreated)
            _samplePoints.Dispose();
        _samplePoints = new NativeArray<float3>(buoyPoints.Length, Allocator.Persistent);
        _heights = new float3[buoyPoints.Length];
        _normals = new float3[buoyPoints.Length];
        
        for (var i = 0; i < buoyPoints.Length; i++)
        {
            _samplePoints[i] = buoyPoints[i];
        }
    }
    

    // Update is called once per frame
    private void LateUpdate()
    {
        if(buoyPoints == null || buoyPoints.Length == 0) return;
        
        GerstnerWavesJobs.UpdateSamplePoints(ref _samplePoints, _guid);
        GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);
        
        var buoys = new Matrix4x4[buoyPoints.Length];

        for (var i = 0; i < buoyPoints.Length; i++)
        {
            var pos = buoyPoints[i];
            pos.y = _heights[i].y - 0.25f;
            buoys[i] = Matrix4x4.TRS(pos, Quaternion.LookRotation(Vector3.forward, -_normals[i]), Vector3.one);
        }

        if (buoyMesh && buoyMaterial)
        {
            Graphics.DrawMeshInstanced(buoyMesh, 0, buoyMaterial, buoys);
        }
    }

    static Vector3[] SplitBuoys(BuoyPoint[] buoys)
    {
        return (from point in buoys where !point.Arrow select point.position).Select(dummy => (Vector3)dummy).ToArray();
    }

    static BuoyPoint[] GeneratePoints(float spacing, float angleThreshold, CinemachinePath path)
    {
        List<BuoyPoint> points = new List<BuoyPoint>();

        var pathLength = path.PathLength;
        var pointCount = pathLength / spacing;

        for (var i = 0; i < pointCount; i++)
        {
            BuoyPoint bp = new BuoyPoint();
            var dir = path.EvaluateOrientationAtUnit(i / pointCount, CinemachinePathBase.PositionUnits.Normalized);
            
            var pos = path.EvaluatePositionAtUnit(i / pointCount, CinemachinePathBase.PositionUnits.Normalized);

            if (i > 0 && i < pointCount)
            {
                var posA = path.EvaluatePositionAtUnit(i / (pointCount - 1), CinemachinePathBase.PositionUnits.Normalized);
                var posB = path.EvaluatePositionAtUnit(i / (pointCount + 1), CinemachinePathBase.PositionUnits.Normalized);

                var v1 = pos - posA;
                var v2 = pos - posB;

                var angle = Vector3.Angle(v1.normalized, v2.normalized);

                bp.Arrow = angle < 180f - angleThreshold;
            }
            bp.position = pos;
            bp.rotation = dir;
            points.Add(bp);
        }
        return points.ToArray();
    }

    private void CleanupArrows()
    {
        foreach (var t in arrows)
        {
#if UNITY_EDITOR
            DestroyImmediate(t);
#else
            Destroy(t);
#endif
        }
        
        arrows.Clear();
    }
    
    private IEnumerator RefreshArrows()
    {
        if (!arrowHandle.IsValid())
        {
            arrowHandle = arrow.LoadAssetAsync<GameObject>();
        }
        if (arrowHandle.Status != AsyncOperationStatus.Succeeded)
        {
            while (!arrowHandle.IsDone)
            {
                return null;
            }
        }
        
        var isolatedArrows = points.Where(point => point.Arrow).ToList();
        var currentCount = arrows.Count;

        if (isolatedArrows.Count > currentCount)
        {
            for (int x = 0; x < currentCount; x++)
            {
                arrows[x].transform.SetPositionAndRotation(isolatedArrows[x].position, isolatedArrows[x].rotation);
            }
            // add more
            for (int i = currentCount; i < isolatedArrows.Count; i++)
            {
                arrows.Add(Instantiate(arrowHandle.Result as GameObject));
                arrows.Last().hideFlags = HideFlags.DontSave;
                arrows.Last().transform.SetPositionAndRotation(isolatedArrows[i].position, isolatedArrows[i].rotation);
            }
        }
        else
        {
            for (int x = 0; x < isolatedArrows.Count; x++)
            {
                arrows[x].transform.SetPositionAndRotation(isolatedArrows[x].position, isolatedArrows[x].rotation);
            }
            // need to remove
            for (int i = isolatedArrows.Count; i < currentCount; i++)
            {
                Utility.SafeDestroy(arrows[i]);
            }
            arrows.RemoveRange(isolatedArrows.Count, currentCount - isolatedArrows.Count);
        }

        return null;
    }

    [Serializable]
    private class BuoyPoint
    {
        //public Matrix4x4 Tranform;
        public Vector3 position;
        public Quaternion rotation;
        public bool Arrow;
    }

    private void OnDrawGizmosSelected()
    {
        if (points != null && points.Length > 0)
        {
            foreach (var point in points)
            {
                if (point.Arrow)
                {
                    Gizmos.color = Color.gray;
                    Gizmos.DrawCube(point.position, Vector3.one);
                }
                else
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(point.position, 0.25f);
                }
            }
        }
    }
}
