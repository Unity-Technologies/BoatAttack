using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static WaterSystem.BuoyantObject2;
using Unity.Physics.Extensions;
using Unity.Physics.Systems;
using Unity.Physics;

[UpdateAfter(typeof(GertsnerSystem)), UpdateAfter(typeof(ExportPhysicsWorld))]
public class ApplyBuoyancyForceSystem : JobComponentSystem
{

	float lastTime = 0;

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		Debug.Log(string.Format("DeltaTime: {0}, Time.time {1}, Calc Delta: {2}", Time.deltaTime, Time.time, Time.time - lastTime));
		lastTime = Time.time;
		var job = new ForceJob()
		{
			dt = Time.deltaTime,
			offsetBuffer = GetBufferFromEntity<VoxelOffset>(false),
			heightBuffer = GetBufferFromEntity<VoxelHeight>(false)
		};

		return job.Schedule(this, inputDeps);
	}

	//[BurstCompile]
	public struct ForceJob : IJobForEachWithEntity<Translation, Rotation, PhysicsVelocity, PhysicsMass, PhysicsDamping, BuoyantData>
	{
		public float dt;

		[ReadOnly]
		public BufferFromEntity<VoxelOffset> offsetBuffer;

		[ReadOnly]
		public BufferFromEntity<VoxelHeight> heightBuffer;

		public void Execute(Entity entity, int index, ref Translation pos, ref Rotation rot, ref PhysicsVelocity vel, ref PhysicsMass mass, ref PhysicsDamping damping, ref BuoyantData data)
		{
			DynamicBuffer<VoxelOffset> offsets = offsetBuffer[entity];
			DynamicBuffer<VoxelHeight> heights = heightBuffer[entity];

			var vel2 = vel;

			float submergedAmount = 0f;
			Debug.Log("new pass: " + entity.ToString());

			//Apply buoyant force
			for (var i = 0; i < offsets.Length; i++)
			{
				var wp = pos.Value + offsets[i].Value;
				float waterLevel = heights[i].Value.y;

				if (wp.y - data.voxelResolution < waterLevel)
				{
					//float depth = waterLevel - wp.y + (data.voxelResolution * 2f);
					float subFactor = Mathf.Clamp01((waterLevel - (wp.y - data.voxelResolution)) / (data.voxelResolution * 2f));//depth / data.voxelResolution);

					submergedAmount += subFactor;//(math.clamp(waterLevel - (wp.y - voxelResolution), 0f, voxelResolution * 2f) / (voxelResolution * 2f)) / voxels.Count;

					//var force2 = data.localArchimedesForce * subFactor;
					
					
					var velocity = ComponentExtensions.GetLinearVelocity(vel2, mass, pos, rot, wp);
					velocity.y *= 2f;
					var localDampingForce = .005f * math.rcp(mass.InverseMass) * -velocity;
					var force = localDampingForce + math.sqrt(subFactor) * data.localArchimedesForce;//\
					ComponentExtensions.ApplyImpulse(ref vel, mass, pos, rot, force * dt, wp);
					//entity.ApplyImpulse(force, wp);//RB.AddForceAtPosition(force, wp);
					
					Debug.Log(string.Format("Position: {0:f1} -- Force: {1:f2} -- Height: {2:f2}\nVelocty: {3:f2} -- Damp: {4:f2} -- Mass: {5:f1} -- K: {6:f2}", wp, force, waterLevel, velocity, localDampingForce, math.rcp(mass.InverseMass), dt));
				}
				
			}
			//Update drag

			//submergedAmount /= offsets.Length;
			//damping.Linear = Mathf.Lerp(data.baseDrag, 1f, submergedAmount);
			//damping.Angular = Mathf.Lerp(data.baseAngularDrag, 1f, submergedAmount);

			data.percentSubmerged = Mathf.Lerp(data.percentSubmerged, submergedAmount, 0.25f);
			damping.Linear = data.baseDrag + (data.baseDrag * (data.percentSubmerged * 10f));
			damping.Angular = data.baseAngularDrag + (data.percentSubmerged * 0.5f);

		}
	}
}
