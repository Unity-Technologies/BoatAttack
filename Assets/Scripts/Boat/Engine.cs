using System;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;
using WaterSystem;

namespace BoatAttack
{
    public class Engine : MonoBehaviour
    {
        [NonSerialized] public Rigidbody RB; // The rigid body attatched to the boat
        [NonSerialized] public float VelocityMag; // Boats velocity

        public AudioSource engineSound; // Engine sound clip
        public AudioSource waterSound; // Water sound clip

        //engine stats
        public float steeringTorque = 5f;
        public float horsePower = 18f;
        private NativeArray<float3> _point; // engine submerged check
        private float3[] _heights = new float3[1]; // engine submerged check
        private float3[] _normals = new float3[1]; // engine submerged check
        private int _guid;
        private float _yHeight;

        public Vector3 enginePosition;
        private Vector3 _engineDir;
        private float _turnVel;
        private float _currentAngle;

        private void Awake()
        {
			if(engineSound)
				engineSound.time = UnityEngine.Random.Range(0f, engineSound.clip.length); // randomly start the engine sound

			if(waterSound)
				waterSound.time = UnityEngine.Random.Range(0f, waterSound.clip.length); // randomly start the water sound

            _guid = GetInstanceID(); // Get the engines GUID for the buoyancy system
            _point = new NativeArray<float3>(1, Allocator.Persistent);
        }

        private void FixedUpdate()
        {
            VelocityMag = RB.velocity.sqrMagnitude; // get the sqr mag
            engineSound.pitch = Mathf.Max(VelocityMag * 0.01f, 0.3f); // use some magice numbers to control the pitch of the engine sound

            // Get the water level from the engines position and store it
            _point[0] = transform.TransformPoint(enginePosition);
            GerstnerWavesJobs.UpdateSamplePoints(ref _point, _guid);
            GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);
            _yHeight = _heights[0].y - _point[0].y;
        }

        private void OnDisable()
        {
            _point.Dispose();
        }
        
        /// <summary>
        /// Controls the acceleration of the boat
        /// </summary>
        /// <param name="modifier">Acceleration modifier, adds force in the 0-1 range</param>
        public void Accelerate(float modifier)
        {
            if (_yHeight > -0.1f) // if the engine is deeper than 0.1
            {
                modifier = Mathf.Clamp(modifier, 0f, 1f); // clamp for reasonable values
                var forward = RB.transform.forward;
                forward.y = 0f;
                forward.Normalize();
                RB.AddForce(horsePower * modifier * forward, ForceMode.Acceleration); // add force forward based on input and horsepower
                RB.AddRelativeTorque(-Vector3.right * modifier, ForceMode.Acceleration);
            }
        }

        /// <summary>
        /// Controls the turning of the boat
        /// </summary>
        /// <param name="modifier">Steering modifier, positive for right, negative for negative</param>
        public void Turn(float modifier)
        {
            if (_yHeight > -0.1f) // if the engine is deeper than 0.1
            {
                modifier = Mathf.Clamp(modifier, -1f, 1f); // clamp for reasonable values
                RB.AddRelativeTorque(new Vector3(0f, steeringTorque, -steeringTorque * 0.5f) * modifier, ForceMode.Acceleration); // add torque based on input and torque amount
            }

            _currentAngle = Mathf.SmoothDampAngle(_currentAngle, 
                60f * -modifier, 
                ref _turnVel, 
                0.5f, 
                10f,
                Time.fixedTime);
            transform.localEulerAngles = new Vector3(0f, _currentAngle, 0f);
        }

        // Draw some helper gizmos
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(enginePosition, new Vector3(0.1f, 0.2f, 0.3f)); // Draw teh engine position with sphere
        }
	}
}
