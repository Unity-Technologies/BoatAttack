using UnityEngine;
using System.Collections;
using WaterSystem;
using Unity.Mathematics;

namespace BoatAttack.Boat
{
    public class Engine : MonoBehaviour
    {
        public Rigidbody RB; // The rigid body attatched to the boat
        public float vel; // Boats velocity

        public AudioSource engineSound; // Engine sound clip
        public AudioSource waterSound; // Water sound clip


        private float turnVel = 0f;
        //engine stats
        public float horsePower = 15f;
        public float turnAngle = 45f;
        private float3[] point = new float3[1]; // engine submerged check
        private float3[] heights = new float3[1]; // engine submerged check
        private int _guid;
        private float yHeight;

        public Vector3 enginePosition;
        private Vector3 engineDir;

        void Awake()
        {
            engineSound.time = UnityEngine.Random.Range(0f, engineSound.clip.length); // randomly start the engine sound
            waterSound.time = UnityEngine.Random.Range(0f, waterSound.clip.length); // randomly start the water sound

            _guid = this.GetInstanceID(); // Get the engines GUID for the buoyancy system
        }

        void FixedUpdate()
        {
            vel = RB.velocity.sqrMagnitude; // get the sqr mag
            engineSound.pitch = Mathf.Max(vel * 0.01f, 0.3f); // use some magice numbers to control the pitch of the engine sound

            // Get the water level from the engines position and store it
            point[0] = transform.TransformPoint(enginePosition);
            GerstnerWavesJobs.UpdateSamplePoints(point, _guid, false);
            GerstnerWavesJobs.GetData(_guid, ref heights);
            yHeight = heights[0].y - point[0].y;
        }

        /// <summary>
        /// Controls the acceleration of the boat
        /// </summary>
        /// <param name="modifier">Acceleration modifier, adds force in the 0-1 range</param>
        public void Accel(float modifier)
        {
            if (yHeight > -0.2f) // if the engine is deeper than 0.1
            {
                Vector3 forward = Vector3.Slerp(RB.transform.forward, transform.forward, 0.2f);
                //forward.y = 0f;
                //forward.Normalize();
                RB.AddForceAtPosition(forward * modifier * horsePower, point[0], ForceMode.Acceleration); // add force forward based on input and horsepower
                RB.AddRelativeTorque(-Vector3.right * modifier, ForceMode.Acceleration);
            }
        }

        /// <summary>
        /// Controls the turning of the boat
        /// </summary>
        /// <param name="modifier">Steering modifier, positive for right, negative for negative</param>
        public void Turn(float modifier)
        {
            var curAngle = transform.localEulerAngles.y;

            var angle = Mathf.SmoothDampAngle(curAngle, -modifier * turnAngle, ref turnVel, 0.2f);
            
            transform.localEulerAngles = new Vector3(0f, angle, 0f);
            
            //RB.AddRelativeTorque(vel * -0.001f * new Vector3(0f, angle > 180 ? angle - 360 : angle, 0f), ForceMode.Acceleration); // add torque based on input and torque amount
        }

        // Draw some helper gizmos
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(enginePosition, new Vector3(0.1f, 0.2f, 0.3f)); // Draw teh engine position with sphere
        }
    }
}
