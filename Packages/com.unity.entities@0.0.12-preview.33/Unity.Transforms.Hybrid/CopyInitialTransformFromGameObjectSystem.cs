using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Unity.Transforms
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class CopyInitialTransformFromGameObjectSystem : JobComponentSystem
    {
        struct TransformStash
        {
            public float3 position;
            public quaternion rotation;
        }

        [BurstCompile]
        struct StashTransforms : IJobParallelForTransform
        {
            public NativeArray<TransformStash> transformStashes;

            public void Execute(int index, TransformAccess transform)
            {
                transformStashes[index] = new TransformStash
                {
                    rotation       = transform.rotation,
                    position       = transform.position,
                };
            }
        }

        [BurstCompile]
        struct CopyTransforms : IJobForEachWithEntity<LocalToWorld>
        {
            [DeallocateOnJobCompletion] public NativeArray<TransformStash> transformStashes;

            public void Execute(Entity entity, int index, ref LocalToWorld localToWorld)
            {
                var transformStash = transformStashes[index];

                var position = localToWorld.Position;

                localToWorld = new LocalToWorld
                {
                    Value = float4x4.TRS(
                        transformStash.position,
                        transformStash.rotation,
                        new float3(1.0f, 1.0f, 1.0f))
                };
            }
        }

        struct RemoveCopyInitialTransformFromGameObjectComponent : IJob
        {
            [DeallocateOnJobCompletion][ReadOnly] public NativeArray<Entity> entities;
            public EntityCommandBuffer entityCommandBuffer;

            public void Execute()
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    entityCommandBuffer.RemoveComponent<CopyInitialTransformFromGameObject>(entities[i]);
                }
            }
        }

        EndInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

        EntityQuery m_InitialTransformGroup;

        protected override void OnCreate()
        {
            m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
            m_InitialTransformGroup = GetEntityQuery(
                    ComponentType.ReadOnly(typeof(CopyInitialTransformFromGameObject)),
                    typeof(UnityEngine.Transform),
                    ComponentType.ReadWrite<LocalToWorld>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var transforms = m_InitialTransformGroup.GetTransformAccessArray();
            var entities = m_InitialTransformGroup.ToEntityArray(Allocator.TempJob);

            var transformStashes = new NativeArray<TransformStash>(transforms.length, Allocator.TempJob);
            var stashTransformsJob = new StashTransforms
            {
                transformStashes = transformStashes
            };

            var stashTransformsJobHandle = stashTransformsJob.Schedule(transforms, inputDeps);

            var copyTransformsJob = new CopyTransforms
            {
                transformStashes = transformStashes,
            };

            var copyTransformsJobHandle = copyTransformsJob.Schedule(m_InitialTransformGroup, stashTransformsJobHandle);

            var removeComponentsJob = new RemoveCopyInitialTransformFromGameObjectComponent
            {
                entities = entities,
                entityCommandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer()
            };
            var removeComponentsJobHandle = removeComponentsJob.Schedule(copyTransformsJobHandle);
            m_EntityCommandBufferSystem.AddJobHandleForProducer(removeComponentsJobHandle);
            return removeComponentsJobHandle;
        }
    }
}
