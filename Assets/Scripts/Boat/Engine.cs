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
        public float horsePower = 5800f;
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
            // ⚠️ RB null 체크
            if (RB == null)
            {
                return;
            }
            
            // ⚠️ NaN 방지: Rigidbody rotation 체크 및 리셋
            if (RB != null)
            {
                Quaternion rbRotation = RB.rotation;
                if (float.IsNaN(rbRotation.x) || float.IsNaN(rbRotation.y) || 
                    float.IsNaN(rbRotation.z) || float.IsNaN(rbRotation.w))
                {
                    Debug.LogError($"[Engine] ⚠️ Rigidbody rotation이 NaN입니다! 리셋합니다. {gameObject.name}");
                    RB.rotation = Quaternion.identity;
                    RB.angularVelocity = Vector3.zero;
                    transform.rotation = Quaternion.identity;
                    _currentAngle = 0f;
                    _turnVel = 0f;
                }
                
                // ⚠️ NaN 방지: Rigidbody position 체크
                Vector3 rbPosition = RB.position;
                if (float.IsNaN(rbPosition.x) || float.IsNaN(rbPosition.y) || float.IsNaN(rbPosition.z))
                {
                    Debug.LogError($"[Engine] ⚠️ Rigidbody position이 NaN입니다! 리셋합니다. {gameObject.name}");
                    RB.position = transform.position;
                    RB.velocity = Vector3.zero;
                }
                
                // ⚠️ NaN 방지: Rigidbody velocity 체크
                Vector3 rbVelocity = RB.velocity;
                if (float.IsNaN(rbVelocity.x) || float.IsNaN(rbVelocity.y) || float.IsNaN(rbVelocity.z))
                {
                    Debug.LogWarning($"[Engine] ⚠️ Rigidbody velocity가 NaN입니다! 리셋합니다. {gameObject.name}");
                    RB.velocity = Vector3.zero;
                }
            }
            
            VelocityMag = RB != null ? RB.velocity.sqrMagnitude : 0f; // get the sqr mag
            if (engineSound != null)
            {
                engineSound.pitch = Mathf.Max(VelocityMag * 0.01f, 0.3f); // use some magice numbers to control the pitch of the engine sound
            }

            // Get the water level from the engines position and store it
            // ⚠️ NativeArray가 생성되어 있는지 확인 (메모리 에러 방지)
            if (!_point.IsCreated)
            {
                return;
            }
            
            _point[0] = transform.TransformPoint(enginePosition);
            GerstnerWavesJobs.UpdateSamplePoints(ref _point, _guid);
            GerstnerWavesJobs.GetData(_guid, ref _heights, ref _normals);
            _yHeight = _heights[0].y - _point[0].y;
            
            // ⚠️ NaN 방지: _yHeight 체크
            if (float.IsNaN(_yHeight) || float.IsInfinity(_yHeight))
            {
                _yHeight = 0f;
            }
        }

        private void OnDisable()
        {
            // ⚠️ NativeArray가 생성되어 있는지 확인 후 Dispose (중복 해제 방지)
            if (_point.IsCreated)
            {
                _point.Dispose();
            }
        }
        
        private void OnDestroy()
        {
            // ⚠️ OnDestroy에서도 안전하게 Dispose (이중 안전장치)
            if (_point.IsCreated)
            {
                _point.Dispose();
            }
        }
        
        /// <summary>
        /// Controls the acceleration of the boat
        /// </summary>
        /// <param name="modifier">Acceleration modifier, adds force in the 0-1 range</param>
        public void Accelerate(float modifier)
        {
            // ⚠️ NaN 방지: modifier 값 검증
            if (float.IsNaN(modifier) || float.IsInfinity(modifier))
            {
                modifier = 0f;
            }
            
            modifier = Mathf.Clamp(modifier, 0f, 1f); // clamp for reasonable values
            
            if (_yHeight > -0.1f && RB != null) // if the engine is deeper than 0.1
            {
                var forward = RB.transform.forward;
                forward.y = 0f;
                forward.Normalize();
                
                // ⚠️ NaN 방지: 벡터 검증
                if (float.IsNaN(forward.x) || float.IsNaN(forward.y) || float.IsNaN(forward.z))
                {
                    forward = Vector3.forward;
                }
                
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
            // ⚠️ NaN 방지: modifier 값 검증
            if (float.IsNaN(modifier) || float.IsInfinity(modifier))
            {
                modifier = 0f;
            }
            
            modifier = Mathf.Clamp(modifier, -1f, 1f); // clamp for reasonable values
            
            if (_yHeight > -0.1f && RB != null) // if the engine is deeper than 0.1
            {
                // ⚠️ NaN 방지: torque 벡터 검증
                // Z축 Roll 제거: 선회 시 기울어지지 않아 직진 성능 유지
                Vector3 torque = new Vector3(0f, steeringTorque, 0f) * modifier;
                if (float.IsNaN(torque.x) || float.IsNaN(torque.y) || float.IsNaN(torque.z))
                {
                    torque = Vector3.zero;
                }
                RB.AddRelativeTorque(torque, ForceMode.Acceleration); // add torque based on input and torque amount
            }

            // ⚠️ NaN 방지: _currentAngle과 _turnVel 검증
            if (float.IsNaN(_currentAngle) || float.IsInfinity(_currentAngle))
            {
                _currentAngle = 0f;
            }
            if (float.IsNaN(_turnVel) || float.IsInfinity(_turnVel))
            {
                _turnVel = 0f;
            }
            
            // ⚠️ NaN 방지: Time.fixedDeltaTime 사용 (Time.fixedTime 대신)
            float deltaTime = Time.fixedDeltaTime;
            if (deltaTime <= 0f || float.IsNaN(deltaTime) || float.IsInfinity(deltaTime))
            {
                deltaTime = 0.02f; // 기본값
            }
            
            float targetAngle = 60f * -modifier;
            if (float.IsNaN(targetAngle) || float.IsInfinity(targetAngle))
            {
                targetAngle = 0f;
            }
            
            _currentAngle = Mathf.SmoothDampAngle(_currentAngle, 
                targetAngle, 
                ref _turnVel, 
                0.5f, 
                10f,
                deltaTime);
            
            // ⚠️ 최종 NaN 체크
            if (float.IsNaN(_currentAngle) || float.IsInfinity(_currentAngle))
            {
                _currentAngle = 0f;
            }
            
            // ⚠️ 각도 범위 제한
            _currentAngle = Mathf.Clamp(_currentAngle, -180f, 180f);
            
            // ⚠️ 최종 NaN 체크 후 transform 설정
            if (float.IsNaN(_currentAngle) || float.IsInfinity(_currentAngle))
            {
                _currentAngle = 0f;
            }
            
            Vector3 eulerAngles = new Vector3(0f, _currentAngle, 0f);
            
            // ⚠️ NaN 방지: eulerAngles 검증
            if (float.IsNaN(eulerAngles.x) || float.IsNaN(eulerAngles.y) || float.IsNaN(eulerAngles.z))
            {
                eulerAngles = Vector3.zero;
                _currentAngle = 0f;
            }
            
            transform.localEulerAngles = eulerAngles;
            
            // ⚠️ NaN 방지: transform.rotation도 체크
            Quaternion currentRotation = transform.rotation;
            if (float.IsNaN(currentRotation.x) || float.IsNaN(currentRotation.y) || 
                float.IsNaN(currentRotation.z) || float.IsNaN(currentRotation.w))
            {
                Debug.LogError($"[Engine] ⚠️ transform.rotation이 NaN입니다! 리셋합니다. {gameObject.name}");
                transform.rotation = Quaternion.identity;
                _currentAngle = 0f;
                if (RB != null)
                {
                    RB.rotation = Quaternion.identity;
                    RB.angularVelocity = Vector3.zero;
                }
            }
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
