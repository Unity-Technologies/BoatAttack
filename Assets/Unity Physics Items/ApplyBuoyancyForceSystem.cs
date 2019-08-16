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
	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		var job = new ForceJob()
		{
			dt = Time.deltaTime,
			offsetBuffer = GetBufferFromEntity<VoxelOffset>(false),
			heightBuffer = GetBufferFromEntity<VoxelHeight>(false)
		};

		return job.Schedule(this, inputDeps);
	}

	
	public struct ForceJob : IJobForEachWithEntity<Translation, Rotation, PhysicsVelocity, PhysicsMass, BuoyantData>
	{
		public float dt;

		[ReadOnly]
		public BufferFromEntity<VoxelOffset> offsetBuffer;

		[ReadOnly]
		public BufferFromEntity<VoxelHeight> heightBuffer;

		public void Execute(Entity entity, int index, ref Translation pos, ref Rotation rot, ref PhysicsVelocity vel, ref PhysicsMass mass, ref BuoyantData data)
		{
			DynamicBuffer<VoxelOffset> offsets = offsetBuffer[entity];
			DynamicBuffer<VoxelHeight> heights = heightBuffer[entity];

			float submergedAmount = 0f;
			Debug.Log("new pass: " + entity.ToString());
			
			//Apply buoyant force
			for (var i = 0; i < offsets.Length; i++)
			{
				var wp = pos.Value + offsets[i].Value;
				float waterLevel = heights[i].Value.y;

				if (wp.y - data.voxelResolution < waterLevel)
				{
					float k = Mathf.Clamp01(waterLevel - (wp.y - data.voxelResolution)) / (data.voxelResolution * 2f);

					submergedAmount += k / data.voxelResolution;//(math.clamp(waterLevel - (wp.y - voxelResolution), 0f, voxelResolution * 2f) / (voxelResolution * 2f)) / voxels.Count;

					var velocity = ComponentExtensions.GetLinearVelocity(vel, mass, pos, rot, wp);
					velocity.y *= 2f;
					var localDampingForce = .005f * math.rcp(mass.InverseMass) * -velocity;
					var force = localDampingForce + math.sqrt(k) * data.localArchimedesForce;//\
					ComponentExtensions.ApplyImpulse(ref vel, mass, pos, rot, force * dt * dt, wp);
					//entity.ApplyImpulse(force, wp);//RB.AddForceAtPosition(force, wp);
					//Debug.Log(string.Format("B Position: {0} -- Force: {1}", wp.ToString(), force.ToString()));
					Debug.Log(string.Format("Position: {0:f1} -- Force: {1:f2} -- Height: {2:f2}\nVelocty: {3:f2} -- Damp: {4:f2} -- Mass: {5:f1} -- K: {6:f2}", wp, force, waterLevel, velocity, localDampingForce, math.rcp(mass.InverseMass), data.localArchimedesForce));
				}
			}

			//Update drag
			//data.percentSubmerged = Mathf.Lerp(data.percentSubmerged, submergedAmount, 0.25f);
			//RB.drag = data.baseDrag + (data.baseDrag * (data.percentSubmerged * 10f));
			//RB.angularDrag = data.baseAngularDrag + (data.percentSubmerged * 0.5f);

		}
	}
}
