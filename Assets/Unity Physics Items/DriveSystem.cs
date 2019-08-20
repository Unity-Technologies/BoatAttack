using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Transforms;
using UnityEngine;

[UpdateAfter(typeof(ApplyBuoyancyForceSystem))]
public class DriveSystem : JobComponentSystem
{
	InputControls controls;

	float throttle;
	float steering;

	protected override void OnCreate()
	{
		controls = new InputControls();

		controls.BoatControls.Trottle.performed += context => throttle = context.ReadValue<float>();
		controls.BoatControls.Trottle.canceled += context => throttle = 0f;

		controls.BoatControls.Steering.performed += context => steering = context.ReadValue<float>();
		controls.BoatControls.Steering.canceled += context => steering = 0f;

		controls.BoatControls.Enable();

		base.OnCreate();
	}

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var job = new DriveWithInputJob()
		{
			dt = Time.deltaTime,
			throttle = throttle,
			steering = steering
		};

		return job.Schedule(this, inputDeps);
	}

	[BurstCompile]
	[RequireComponentTag(typeof(MoveWithInputTag))]
	public struct DriveWithInputJob : IJobForEachWithEntity<Translation, Rotation, PhysicsVelocity, PhysicsMass, DrivingData>
	{
		public float dt;

		public float throttle;
		public float steering;

		public void Execute(Entity entity, int index, ref Translation pos, ref Rotation rot, ref PhysicsVelocity vel, ref PhysicsMass mass, ref DrivingData data)
		{
			
			float velMag = math.dot(vel.Linear, vel.Linear);

			var wp = pos.Value + data.engineOffset;

			//if (wp.y <= -0.1f) // if the engine is deeper than 0.1
			//{
				//accel
				throttle = Mathf.Clamp(throttle, 0f, 1f); // clamp for reasonable values
				float3 forward = math.forward(rot.Value);
				forward.y = 0f;
				forward = math.normalize(forward);
				var force = (forward * throttle * data.horsePower) / mass.InverseMass; //divide by iMass to counteract mass in impulse method
				var torque = (throttle * new float3(-1, 0, 0)) / mass.InverseInertia;

				ComponentExtensions.ApplyLinearImpulse(ref vel, mass, force * dt);
				ComponentExtensions.ApplyAngularImpulse(ref vel, mass, torque * dt);
				//RB.AddForce(forward * modifier * horsePower, ForceMode.Acceleration); // add force forward based on input and horsepower
				//RB.AddRelativeTorque(-Vector3.right * modifier, ForceMode.Acceleration);



				//Turning
				steering = Mathf.Clamp(steering, -1f, 1f); // clamp for reasonable values
				var sTorque = new float3(0f, data.torque, -data.torque * .5f) * steering / mass.InverseInertia;
				ComponentExtensions.ApplyAngularImpulse(ref vel, mass, sTorque * dt);
				//Debug.Log(string.Format("Force: {0}, Torque: {1} Throttle: {2}", force, sTorque, throttle));
				//RB.AddRelativeTorque(new Vector3(0f, torque, -torque * 0.5f) * modifier, ForceMode.Acceleration); // add torque based on input and torque amount
			//}
		}
	}
}
