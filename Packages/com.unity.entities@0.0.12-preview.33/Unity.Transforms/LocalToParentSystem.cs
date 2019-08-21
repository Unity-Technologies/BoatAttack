using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Transforms
{
    public abstract class LocalToParentSystem : JobComponentSystem
    {
        private EntityQuery m_RootsGroup;

        // LocalToWorld = Parent.LocalToWorld * LocalToParent
        [BurstCompile]
        struct UpdateHierarchy : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<LocalToWorld> LocalToWorldType;
            [ReadOnly] public ArchetypeChunkBufferType<Child> ChildType;
            [ReadOnly] public BufferFromEntity<Child> ChildFromEntity;
            [ReadOnly] public ComponentDataFromEntity<LocalToParent> LocalToParentFromEntity;

            [NativeDisableContainerSafetyRestriction]
            public ComponentDataFromEntity<LocalToWorld> LocalToWorldFromEntity;

            void ChildLocalToWorld(float4x4 parentLocalToWorld, Entity entity)
            {
                var localToParent = LocalToParentFromEntity[entity];
                var localToWorldMatrix = math.mul(parentLocalToWorld, localToParent.Value);
                LocalToWorldFromEntity[entity] = new LocalToWorld {Value = localToWorldMatrix};

                if (ChildFromEntity.Exists(entity))
                {
                    var children = ChildFromEntity[entity];
                    for (int i = 0; i < children.Length; i++)
                    {
                        ChildLocalToWorld(localToWorldMatrix, children[i].Value);
                    }
                }
            }

            public void Execute(ArchetypeChunk chunk, int index, int entityOffset)
            {
                var chunkLocalToWorld = chunk.GetNativeArray(LocalToWorldType);
                var chunkChildren = chunk.GetBufferAccessor(ChildType);
                for (int i = 0; i < chunk.Count; i++)
                {
                    var localToWorldMatrix = chunkLocalToWorld[i].Value;
                    var children = chunkChildren[i];
                    for (int j = 0; j < children.Length; j++)
                    {
                        ChildLocalToWorld(localToWorldMatrix, children[j].Value);
                    }
                }
            }
        }

        protected override void OnCreate()
        {
            m_RootsGroup = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadOnly<LocalToWorld>(), 
                    ComponentType.ReadOnly<Child>()
                },
                None = new ComponentType[]
                {
                    typeof(Parent)
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var localToWorldType = GetArchetypeChunkComponentType<LocalToWorld>(true);
            var childType = GetArchetypeChunkBufferType<Child>(true);
            var childFromEntity = GetBufferFromEntity<Child>(true);
            var localToParentFromEntity = GetComponentDataFromEntity<LocalToParent>(true);
            var localToWorldFromEntity = GetComponentDataFromEntity<LocalToWorld>();

            var updateHierarchyJob = new UpdateHierarchy
            {
                LocalToWorldType = localToWorldType,
                ChildType = childType,
                ChildFromEntity = childFromEntity,
                LocalToParentFromEntity = localToParentFromEntity,
                LocalToWorldFromEntity = localToWorldFromEntity
            };
            var updateHierarchyJobHandle = updateHierarchyJob.Schedule(m_RootsGroup, inputDeps);
            return updateHierarchyJobHandle;
        }
    }
}
