using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static WaterSystem.BuoyantObject_DOTS;
using Unity.Physics.Extensions;
using Unity.Physics.Systems;
using Unity.Physics;

[UpdateAfter(typeof(GertsnerSystem)), UpdateAfter(typeof(ExportPhysicsWorld))]
public class ApplyBuoyancyForceSystem : JobComponentSystem
{

	float lastTime = 0;

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var offsets = GetBufferFromEntity<VoxelOffset>(false);
		var heights = GetBufferFromEntity<VoxelHeight>(false);


		var forceJob = new ForceJob()
		{
			dt = Time.fixedDeltaTime,
			offsetBuffer = offsets,
			heightBuffer = heights
		};

		var forceJobHandle = forceJob.Schedule(this, inputDeps);

		var simpleJob = new SimpleForceJob()
		{
			dt = Time.fixedDeltaTime,
			heightBuffer = heights
		};

		return simpleJob.Schedule(this, forceJobHandle);
	}

	//[BurstCompile]
	public struct ForceJob : IJobForEachWithEntity<Translation, Rotation, PhysicsVelocity, PhysicsMass, PhysicsDamping, BuoyantData>
	{
		public float dt;

		[ReadOnly]
		public BufferFromEntity<VoxelOffset> offsetBuffer;

		[ReadOnly]
		public BufferFromEntity<VoxelHeight> heightBuffer;
		
		public void Execute(Entity entity, int index, [ReadOnly] ref Translation pos, [ReadOnly] ref Rotation rot, ref PhysicsVelocity vel, ref PhysicsMass mass, ref PhysicsDamping damping, [ReadOnly] ref BuoyantData data)
		{
			DynamicBuffer<VoxelOffset> offsets = offsetBuffer[entity];
			DynamicBuffer<VoxelHeight> heights = heightBuffer[entity];

			var entityTransform = new RigidTransform(rot.Value, pos.Value);

            //Apply buoyant force
            float submergedAmount = 0f;
            for (var i = 0; i < offsets.Length; i++)
			{
				var wp = math.transform(entityTransform, offsets[i].Value);
				float waterLevel = heights[i].Value.y;
				
				if (wp.y - data.voxelResolution < waterLevel)
				{
					float subFactor = Mathf.Clamp01((waterLevel - (wp.y - data.voxelResolution)) / (data.voxelResolution * 2f));

                    submergedAmount += subFactor / offsets.Length;

					var velocity = vel.GetLinearVelocity(mass, pos, rot, wp);
					velocity.y *= 2f;
					var localDampingForce = .005f * math.rcp(mass.InverseMass) * -velocity;
					var force = localDampingForce + math.sqrt(subFactor) * data.localArchimedesForce;
					vel.ApplyImpulse(mass, pos, rot, force * dt, wp);
				}
			}

			//Apply drag
			//data.percentSubmerged = Mathf.Lerp(data.percentSubmerged, submergedAmount, 0.25f);
			//damping.Linear = data.baseDrag + (data.baseDrag * (data.percentSubmerged * 10f));
			//damping.Angular = data.baseAngularDrag + (data.percentSubmerged * 0.5f);
		}
	}

	[BurstCompile]
	[RequireComponentTag(typeof(SimpleBuoyantTag))]
	public struct SimpleForceJob : IJobForEachWithEntity<Translation, Rotation, BuoyancyNormal>
	{
		public float dt;

		[ReadOnly]
		public BufferFromEntity<VoxelHeight> heightBuffer;

		public void Execute(Entity entity, int index, [ReadOnly] ref Translation pos, [ReadOnly] ref Rotation rot, [ReadOnly] ref BuoyancyNormal normal)
		{
			DynamicBuffer<VoxelHeight> heights = heightBuffer[entity];

			var entityTransform = new RigidTransform(rot.Value, pos.Value);

			pos.Value.y = heights[0].Value.y;
			//var position = pos.Value;
			//position.y = heights[0].Value.y;
			//pos.Value = position;

			rot.Value = quaternion.LookRotation(math.forward(rot.Value), normal.Value);

			
			//transform.up = Vector3.Slerp(transform.up, normals[0], Time.deltaTime);
		}
	}
}
