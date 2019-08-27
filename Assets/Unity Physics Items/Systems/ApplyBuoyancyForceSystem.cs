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
using Unity.Collections.LowLevel.Unsafe;

[UpdateAfter(typeof(GertsnerSystem)), UpdateAfter(typeof(ExportPhysicsWorld))]
public class ApplyBuoyancyForceSystem : JobComponentSystem
{
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var offsets = GetBufferFromEntity<VoxelOffset>(false);
		var heights = GetBufferFromEntity<VoxelHeight>(false);

		var simpleQuery = GetEntityQuery(typeof(Translation), typeof(Rotation), typeof(BuoyancyNormal), typeof(SimpleBuoyantTag));
		var simpleEntities = simpleQuery.ToEntityArray(Allocator.TempJob);

		var simpleJob = new SimpleForceJob()
		{
			dt = Time.fixedDeltaTime,
			entities = simpleEntities,
			translations = GetComponentDataFromEntity<Translation>(false),
			rotations = GetComponentDataFromEntity<Rotation>(false),
			normals = GetComponentDataFromEntity<BuoyancyNormal>(true),
			heightBuffer = heights
		};
		var simpleHandle = simpleJob.Schedule(simpleEntities.Length, 32, inputDeps);


		var physicsQuery = GetEntityQuery(typeof(Translation), typeof(Rotation), typeof(PhysicsVelocity), typeof(PhysicsMass), typeof(PhysicsDamping), typeof(BuoyantData));
		var physicalEntities = physicsQuery.ToEntityArray(Allocator.TempJob);

		var forceJob = new ForceJob()
		{
			dt = Time.fixedDeltaTime,
			entities = physicalEntities,
			translations = GetComponentDataFromEntity<Translation>(true),
			rotations = GetComponentDataFromEntity<Rotation>(true),
			velocities = GetComponentDataFromEntity<PhysicsVelocity>(false),
			masses = GetComponentDataFromEntity<PhysicsMass>(true),
			dampings = GetComponentDataFromEntity<PhysicsDamping>(true),
			datas = GetComponentDataFromEntity<BuoyantData>(true),
			offsetBuffer = offsets,
			heightBuffer = heights
		};
		var forceJobHandle = forceJob.Schedule(physicalEntities.Length, 1, simpleHandle);

		return forceJobHandle;
		//return JobHandle.CombineDependencies(forceJobHandle, simpleHandle);
	}

	[BurstCompile]
	public struct ForceJob : IJobParallelFor//<Translation, Rotation, PhysicsVelocity, PhysicsMass, PhysicsDamping, BuoyantData>
	{
		[ReadOnly] public float dt;

        [DeallocateOnJobCompletion]
		[ReadOnly] public NativeArray<Entity> entities;
		[ReadOnly] public ComponentDataFromEntity<Translation> translations;
		[ReadOnly] public ComponentDataFromEntity<Rotation> rotations;
		[ReadOnly] public ComponentDataFromEntity<PhysicsMass> masses;
		[ReadOnly] public ComponentDataFromEntity<PhysicsDamping> dampings;
		[ReadOnly] public ComponentDataFromEntity<BuoyantData> datas;

		[ReadOnly] public BufferFromEntity<VoxelOffset> offsetBuffer;
		[ReadOnly] public BufferFromEntity<VoxelHeight> heightBuffer;

		[NativeDisableParallelForRestriction]
		public ComponentDataFromEntity<PhysicsVelocity> velocities;

		public void Execute(int index)
		{
			var entity = entities[index];
			var pos = translations[entity];
			var rot = rotations[entity];
			var vel = velocities[entity];
			var mass = masses[entity];
			var damping = dampings[entity];
			var data = datas[entity];


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

			velocities[entity] = vel;

			//Apply drag
			//data.percentSubmerged = Mathf.Lerp(data.percentSubmerged, submergedAmount, 0.25f);
			//damping.Linear = data.baseDrag + (data.baseDrag * (data.percentSubmerged * 10f));
			//damping.Angular = data.baseAngularDrag + (data.percentSubmerged * 0.5f);
		}
	}

	[BurstCompile]
	public struct SimpleForceJob : IJobParallelFor
	{
		public float dt;

        [DeallocateOnJobCompletion]
        [ReadOnly] public NativeArray<Entity> entities;
		[ReadOnly] public ComponentDataFromEntity<BuoyancyNormal> normals;
		[ReadOnly] public BufferFromEntity<VoxelHeight> heightBuffer;

		[NativeDisableParallelForRestriction]
		public ComponentDataFromEntity<Translation> translations;

		[NativeDisableParallelForRestriction]
		public ComponentDataFromEntity<Rotation> rotations;

		public void Execute(int index)
		{
			var entity = entities[index];
			var pos = translations[entity];
			var rot = rotations[entity];
			var normal = normals[entity];

			DynamicBuffer<VoxelHeight> heights = heightBuffer[entity];

			var entityTransform = new RigidTransform(rot.Value, pos.Value);

			pos.Value.y = heights[0].Value.y;
			rot.Value = quaternion.LookRotation(math.forward(rot.Value), normal.Value);

			translations[entity] = pos;
			rotations[entity] = rot;
		}
	}
}
