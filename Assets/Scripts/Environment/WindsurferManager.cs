using System;
using UnityEngine;
using WaterSystem;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;

namespace BoatAttack
{
    /// <summary>
    /// This controls the logic for the wind surfer
    /// </summary>
    public class WindsurferManager : MonoBehaviour
    {
        public Transform[] surfers;
        private NativeArray<float3> points; // point to sample wave height
        private float3[] heights; // height sameple from water system
        private float3[] normals; // height sameple from water system
        private Vector3[] smoothPositions; // the smoothed position
        private int _guid; // the objects GUID for wave height lookup

        // Use this for initialization
        void Start()
        {
            _guid = gameObject.GetInstanceID();

            heights = new float3[surfers.Length];
            normals = new float3[surfers.Length];
            smoothPositions = new Vector3[surfers.Length];
            
            for (int i = 0; i < surfers.Length; i++)
            {
                smoothPositions[i] = surfers[i].position;
            }
            points = new NativeArray<float3>(surfers.Length, Allocator.Persistent);
        }

        private void OnDisable()
        {
            points.Dispose();
        }
        
        // Update is called once per frame - TODO - need to validate logic here (not smooth at all in demo)
        void Update()
        {
            GerstnerWavesJobs.UpdateSamplePoints(ref points, _guid);
            GerstnerWavesJobs.GetData(_guid, ref heights, ref normals);
            
            for (int i = 0; i < surfers.Length; i++)
            {
                smoothPositions[i] = surfers[i].position;
                // Sample the water height at the current position
                points[0] = smoothPositions[i];
                if (heights[0].y > smoothPositions[i].y)
                    smoothPositions[i].y += Time.deltaTime;
                else
                    smoothPositions[i].y -= Time.deltaTime * 0.25f;
                surfers[i].position = smoothPositions[i];
            }
        }
    }
}
