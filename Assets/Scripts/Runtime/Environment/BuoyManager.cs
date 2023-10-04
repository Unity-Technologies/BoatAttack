using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using WaterSystem;
using WaterSystem.Physics;

[ExecuteAlways]
public class BuoyManager : WaterQuery
{
    private Vector3[] _vertices;
    private Transform[] _buoys;
    private NativeArray<Data.WaterSample> _samplePoints; // sample points for height calc
    private Data.WaterSurface[] _results; // water height array(only size of 1 when simple or non-physical)

    [SerializeField, HideInInspector] private List<BuoyPoint> points = new List<BuoyPoint>();
    [SerializeField] private Vector3[] buoyPoints;
    
    // User Controls
    public float spacing = 2.0f;
    public float angleThreshold = 25.0f;
    
    // Objects
    public CinemachinePath[] paths;
    [SerializeField]private float[] pathLengths;
    public Mesh buoyMesh;
    public Material buoyMaterial;
    public AssetReference arrow;
    private AsyncOperationHandle arrowHandle;
    private List<GameObject> arrows = new List<GameObject>();

    private int _guid;
    
    // Validate, updates when changed in the editor
    private void OnValidate()
    {
        if (paths?.Length > 0 && spacing > 0.1f)
        {
            var updated = false;
            if (pathLengths.Length != paths.Length)
                pathLengths = new float[paths.Length];

            for (var i = 0; i < paths.Length; i++)
            {
                if(paths[i] == null) continue;
                var l = paths[i].PathLength;
                if (Math.Abs(l - pathLengths[i]) > 0.05f)
                {
                    updated = true;
                    pathLengths[i] = l;
                }
            }
            if(updated)
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
        _samplePoints.Dispose();
        CleanupArrows();
    }

    public override void SetQueryPositions(ref NativeSlice<Data.WaterSample> samplePositions)
    {
       samplePositions = _samplePoints;
    }

    public override void GetQueryResults(NativeSlice<Data.WaterSurface> surfaceResults)
    {
        _results = surfaceResults.ToArray();
    }

    private void UpdateSystem()
    {
        if(buoyPoints == null || buoyPoints.Length == 0) return;
        
        points.Clear();
        foreach (var path in paths)
        {
            points.AddRange(GeneratePoints(spacing, angleThreshold, path));
        }
        buoyPoints = SplitBuoys(ref points);
        QueryCount = buoyPoints.Length;
        SetupArrays();
        RefreshArrows();
    }

    private void SetupArrays()
    {
        if(_samplePoints.IsCreated)
            _samplePoints.Dispose();
        _samplePoints = new NativeArray<Data.WaterSample>(buoyPoints.Length, Allocator.Persistent);
        _results = new Data.WaterSurface[buoyPoints.Length];
        
        for (var i = 0; i < buoyPoints.Length; i++)
        {
            var samplePoint = new Data.WaterSample();
            samplePoint.Position = buoyPoints[i];
            _samplePoints[i] = samplePoint;
        }
    }
    

    // Update is called once per frame
    private void LateUpdate()
    {
        if(buoyPoints == null || buoyPoints.Length == 0) return;
        
        
        var buoys = new Matrix4x4[buoyPoints.Length];

        for (var i = 0; i < buoyPoints.Length; i++)
        {
            var pos = buoyPoints[i];
            pos.y = _results[i].Position.y - 0.25f;
            buoys[i] = Matrix4x4.TRS(pos, Quaternion.LookRotation(Vector3.forward, -_results[i].Normal), Vector3.one);
        }

        if (buoyMesh && buoyMaterial)
        {
            Graphics.DrawMeshInstanced(buoyMesh, 0, buoyMaterial, buoys);
        }
    }

    static Vector3[] SplitBuoys(ref List<BuoyPoint> buoys)
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
            var dir = path.EvaluateTangent(i / pointCount);
            
            var pos = path.EvaluatePosition(i / pointCount);
            pos.y = 0f;

            if (i > 0 && i < pointCount)
            {
                //var posA = path.EvaluatePositionAtUnit(i / (pointCount - 1), CinemachinePathBase.PositionUnits.Normalized);
                var posA = path.EvaluatePosition(i / (pointCount - 1));
                //var posB = path.EvaluatePositionAtUnit(i / (pointCount + 1), CinemachinePathBase.PositionUnits.Normalized);
                var posB = path.EvaluatePosition(i / (pointCount + 1));

                var v1 = math.normalizesafe(pos - posA);
                v1.y = 0f;
                var v2 = math.normalizesafe(pos - posB);
                v2.y = 0f;

                var angle = Vector3.Angle(v1, v2);

                bp.Arrow = angle < 180f - angleThreshold;
            }
            bp.position = pos;
            bp.rotation = Quaternion.LookRotation(dir, Vector3.up);
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
        public Vector3 position;
        public Quaternion rotation;
        public bool Arrow;
    }

    private void OnDrawGizmosSelected()
    {
        if (points != null && points.Count > 0)
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
