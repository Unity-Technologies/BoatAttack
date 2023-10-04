using System;
using UnityEngine;
using WaterSystem;
using Unity.Mathematics;
using Unity.Collections;
using WaterSystem.Physics;

namespace BoatAttack
{
    /// <summary>
    /// This controls the logic for the wind surfer
    /// </summary>
    public class WindsurferManager : WaterQuery
    {
        public Transform[] surfers;
        private NativeArray<Data.WaterSample> _points; // point to sample wave height
        private Data.WaterSurface[] _results; // height sameple from water system
        private float3[] _smoothPositions; // the smoothed position

        // Use this for initialization
        private void Start()
        {
            QueryCount = surfers.Length;
            _results = new Data.WaterSurface[surfers.Length];
            _smoothPositions = new float3[surfers.Length];

            for (var i = 0; i < surfers.Length; i++)
            {
                _smoothPositions[i] = surfers[i].position;
            }
            _points = new NativeArray<Data.WaterSample>(surfers.Length, Allocator.Persistent);
        }

        private void OnDisable()
        {
            _points.Dispose();
        }

        public override void SetQueryPositions(ref NativeSlice<Data.WaterSample> samplePositions)
        {
            for (var index = 0; index < samplePositions.Length; index++)
            {
                var samplePosition = samplePositions[index];
                samplePosition.Position = _smoothPositions[index];
                samplePositions[index] = samplePosition;
            }
        }

        public override void GetQueryResults(NativeSlice<Data.WaterSurface> surfaceResults)
        {
            _results = surfaceResults.ToArray();
        }

        // TODO - need to validate logic here (not smooth at all in demo)
        private void Update()
        {
            //GerstnerWavesJobs.UpdateSamplePoints(ref _points, _guid);
            //GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);

            for (int i = 0; i < surfers.Length; i++)
            {
                _smoothPositions[i] = surfers[i].position;
                // Sample the water height at the current position
                if (_results[i].Position.y > _smoothPositions[i].y)
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
