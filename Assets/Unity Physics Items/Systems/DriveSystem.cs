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
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var job = new DriveWithInputJob()
		{
			dt = Time.deltaTime,
		};

		return job.Schedule(this, inputDeps);
	}

	[BurstCompile]
	public struct DriveWithInputJob : IJobForEachWithEntity<Translation, Rotation, PhysicsVelocity, PhysicsMass, DrivingData, InputData>
	{
		public float dt;


		public void Execute(Entity entity, int index, [ReadOnly] ref Translation pos, [ReadOnly] ref Rotation rot, ref PhysicsVelocity vel, [ReadOnly] ref PhysicsMass mass, ref DrivingData driveData, ref InputData inputData)
		{
			float velMag = math.dot(vel.Linear, vel.Linear);

            var entityTransform = new RigidTransform(rot.Value, pos.Value);
			var wp = math.transform(entityTransform, driveData.engineOffset);// + mass.CenterOfMass);
			
			//if (wp.y <= -0.1f) // if the engine is deeper than 0.1 
			//{
				inputData.throttle = Mathf.Clamp(inputData.throttle, 0f, 1f); // clamp for reasonable values
                float3 forward = math.forward(rot.Value);
                forward.y = 0f;
                forward = math.normalize(forward);

                //accel
                var force = (forward * inputData.throttle * driveData.horsePower) / mass.InverseMass; //divide by iMass to counteract mass in impulse method
				float3 up = math.mul(rot.Value, math.up());
				vel.ApplyLinearImpulse(mass, force * dt);

				//Lift the nose up
				var upTorque = (inputData.throttle * new float3(-1, 0, 0) * driveData.upwardTorque) / mass.InverseInertia;
				vel.ApplyAngularImpulse(mass, upTorque * dt);

				//Turning
				// var torque = (data.throttle * new float3(-1, 0, 0)) / mass.InverseInertia;
				inputData.steering = Mathf.Clamp(inputData.steering, -1f, 1f); // clamp for reasonable values
			    var sTorque = new float3(0f, driveData.steeringTorque, -driveData.steeringTorque * .5f) * inputData.steering / mass.InverseInertia;
				vel.ApplyAngularImpulse(mass, sTorque * dt);
			//}
		}
	}
}
