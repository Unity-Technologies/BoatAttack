using System;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;
using WaterSystem;
using WaterSystem.New;

namespace BoatAttack
{
    public class Engine : WaterQuery
    {
        [NonSerialized] public Rigidbody RB; // The rigid body attatched to the boat
        [NonSerialized] public float VelocityMag; // Boats velocity

        public AudioSource engineSound; // Engine sound clip
        public AudioSource waterSound; // Water sound clip

        //engine stats
        public float steeringTorque = 5f;
        public float horsePower = 18f;
        private NativeArray<Data.WaterSample> _point; // engine submerged check
        private NativeArray<Data.WaterSurface> _results; // engine submerged check

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
            
            QueryCount = 1; // set the query count to 1
            _point = new NativeArray<Data.WaterSample>(1, Allocator.Persistent);
        }

        private void Update()
        {
            VelocityMag = RB.velocity.magnitude; // get the sqr mag
            engineSound.pitch = Mathf.Max(VelocityMag * 0.01f, 0.3f); // use some magice numbers to control the pitch of the engine sound
        }

        private void FixedUpdate()
        {
            // Get the water level from the engines position and store it
            var point = _point[0];
            point.Position = transform.TransformPoint(enginePosition);
            _point[0] = point;
        }

        private void OnDisable()
        {
            _point.Dispose();
        }

        public override void SetQueryPositions(ref NativeSlice<Data.WaterSample> samplePositions)
        {
            samplePositions[0] = _point[0];
        }

        public override void GetQueryResults(NativeSlice<Data.WaterSurface> surfaceResults)
        {
            _results[0] = surfaceResults[0];
        }

        /// <summary>
        /// Controls the acceleration of the boat
        /// </summary>
        /// <param name="modifier">Acceleration modifier, adds force in the 0-1 range</param>
        public void Accelerate(float modifier)
        {
            if (transform.position.y - _point[0].Position.y > -0.1f) // if the engine is deeper than 0.1
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
            if (transform.position.y - _point[0].Position.y > -0.1f) // if the engine is deeper than 0.1
            {
                modifier = Mathf.Clamp(modifier, -1f, 1f); // clamp for reasonable values
                RB.AddRelativeTorque(new Vector3(steeringTorque * 0.1f, steeringTorque, -steeringTorque * 0.25f) * modifier, ForceMode.Acceleration); // add torque based on input and torque amount
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
