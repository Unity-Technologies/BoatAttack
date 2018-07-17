using UnityEngine;
using WaterSystem;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// This controls the logic for the wind surfer
    /// </summary>
    public class WindsurferLogic : MonoBehaviour
    {
        private float3[] point = new float3[1]; // point to sample wave height
        private float3[] heights = new float3[1]; // height sameple from water system
        private Vector3 smoothPosition; // the smoothed position
        private int _guid; // the objects GUID for wave height lookup

        // Use this for initialization
        void Start()
        {
            _guid = gameObject.GetInstanceID();
            smoothPosition = transform.position;
        }

        // Update is called once per frame - TODO - need to validate logic here (not smooth at all in demo)
        void Update()
        {
            smoothPosition = transform.position;
            // Sample the water height at the current position
            point[0] = transform.position;
            GerstnerWavesJobs.UpdateSamplePoints(point, _guid, false);
            GerstnerWavesJobs.GetData(_guid, ref heights);
            if (heights[0].y > smoothPosition.y)
                smoothPosition.y += Time.deltaTime;
            else
                smoothPosition.y -= Time.deltaTime * 0.25f;
            transform.position = smoothPosition;
        }
    }
}
