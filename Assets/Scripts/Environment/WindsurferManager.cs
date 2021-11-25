using UnityEngine;
using WaterSystem;
using Unity.Mathematics;
using Unity.Collections;

namespace BoatAttack
{
    /// <summary>
    /// This controls the logic for the wind surfer
    /// </summary>
    public class WindsurferManager : MonoBehaviour
    {
        public Transform[] surfers;
        private NativeArray<float3> _points; // point to sample wave height
        private float3[] _heights; // height sameple from water system
        private float3[] _normals; // height sameple from water system
        private Vector3[] _smoothPositions; // the smoothed position
        private int _guid; // the objects GUID for wave height lookup

        // Use this for initialization
        private void Start()
        {
            _guid = gameObject.GetInstanceID();

            _heights = new float3[surfers.Length];
            _normals = new float3[surfers.Length];
            _smoothPositions = new Vector3[surfers.Length];

            for (var i = 0; i < surfers.Length; i++)
            {
                _smoothPositions[i] = surfers[i].position;
            }
            _points = new NativeArray<float3>(surfers.Length, Allocator.Persistent);
        }

        private void OnDisable()
        {
            _points.Dispose();
        }

        // TODO - need to validate logic here (not smooth at all in demo)
        private void Update()
        {
            GerstnerWavesJobs.UpdateSamplePoints(ref _points, _guid);
            GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);

            for (int i = 0; i < surfers.Length; i++)
            {
                _smoothPositions[i] = surfers[i].position;
                // Sample the water height at the current position
                _points[0] = _smoothPositions[i];
                if (_heights[0].y > _smoothPositions[i].y)
                    _smoothPositions[i].y += Time.deltaTime;
                else
                    _smoothPositions[i].y -= Time.deltaTime * 0.25f;
#if !STATIC_EVERYTHING
                surfers[i].position = _smoothPositions[i];
#endif
            }
        }
    }
}
