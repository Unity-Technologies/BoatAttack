using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Transforms
{
    [Serializable]
    [WriteGroup(typeof(LocalToParent))]
    public struct ParentScaleInverse : IComponentData
    {
        public float4x4 Value;

        public float3 Right => new float3(Value.c0.x, Value.c0.y, Value.c0.z);
        public float3 Up => new float3(Value.c1.x, Value.c1.y, Value.c1.z);
        public float3 Forward => new float3(Value.c2.x, Value.c2.y, Value.c2.z);
        public float3 Position => new float3(Value.c3.x, Value.c3.y, Value.c3.z);
    }

    // ParentScaleInverse = Parent.CompositeScale^-1
    // (or) ParentScaleInverse = Parent.Scale^-1
    // (or) ParentScaleInverse = Parent.NonUniformScale^-1
    public abstract class ParentScaleInverseSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        [BurstCompile]
        struct ToChildParentScaleInverse : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<Scale> ScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<NonUniformScale> NonUniformScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<CompositeScale> CompositeScaleType;
            [ReadOnly] public ArchetypeChunkBufferType<Child> ChildType;
            [NativeDisableContainerSafetyRestriction] public ComponentDataFromEntity<ParentScaleInverse> ParentScaleInverseFromEntity;
            public uint LastSystemVersion;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var hasScale = chunk.Has(ScaleType);
                var hasNonUniformScale = chunk.Has(NonUniformScaleType);
                var hasCompositeScale = chunk.Has(CompositeScaleType);

                if (hasCompositeScale)
                {
                    var didChange = chunk.DidChange(CompositeScaleType, LastSystemVersion) ||
                                    chunk.DidChange(ChildType, LastSystemVersion);
                    if (!didChange)
                        return;

                    var chunkCompositeScales = chunk.GetNativeArray(CompositeScaleType);
                    var chunkChildren = chunk.GetBufferAccessor(ChildType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        var inverseScale = math.inverse(chunkCompositeScales[i].Value);
                        var children = chunkChildren[i];
                        for (var j = 0; j < children.Length; j++)
                        {
                            var childEntity = children[j].Value;
                            if (!ParentScaleInverseFromEntity.Exists(childEntity))
                                continue;

                            ParentScaleInverseFromEntity[childEntity] = new ParentScaleInverse {Value = inverseScale};
                        }
                    }
                }
                else if (hasScale)
                {
                    var didChange = chunk.DidChange(ScaleType, LastSystemVersion) ||
                                    chunk.DidChange(ChildType, LastSystemVersion);
                    if (!didChange)
                        return;

                    var chunkScales = chunk.GetNativeArray(ScaleType);
                    var chunkChildren = chunk.GetBufferAccessor(ChildType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        var inverseScale = float4x4.Scale(1.0f / chunkScales[i].Value);
                        var children = chunkChildren[i];
                        for (var j = 0; j < children.Length; j++)
                        {
                            var childEntity = children[j].Value;
                            if (!ParentScaleInverseFromEntity.Exists(childEntity))
                                continue;

                            ParentScaleInverseFromEntity[childEntity] = new ParentScaleInverse {Value = inverseScale};
                        }
                    }
                }
                else // if (hasNonUniformScale)
                {
                    var didChange = chunk.DidChange(NonUniformScaleType, LastSystemVersion) ||
                                    chunk.DidChange(ChildType, LastSystemVersion);
                    if (!didChange)
                        return;

                    var chunkNonUniformScales = chunk.GetNativeArray(NonUniformScaleType);
                    var chunkChildren = chunk.GetBufferAccessor(ChildType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        var inverseScale = float4x4.Scale(1.0f / chunkNonUniformScales[i].Value);
                        var children = chunkChildren[i];
                        for (var j = 0; j < children.Length; j++)
                        {
                            var childEntity = children[j].Value;
                            if (!ParentScaleInverseFromEntity.Exists(childEntity))
                                continue;

                            ParentScaleInverseFromEntity[childEntity] = new ParentScaleInverse {Value = inverseScale};
                        }
                    }
                }
            }
        }

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    ComponentType.ReadOnly<Child>(),
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<Scale>(),
                    ComponentType.ReadOnly<NonUniformScale>(),
                    ComponentType.ReadOnly<CompositeScale>(),
                },                
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var toParentScaleInverseJob = new ToChildParentScaleInverse
            {
                ScaleType = GetArchetypeChunkComponentType<Scale>(true),
                NonUniformScaleType = GetArchetypeChunkComponentType<NonUniformScale>(true),
                CompositeScaleType = GetArchetypeChunkComponentType<CompositeScale>(true),
                ChildType = GetArchetypeChunkBufferType<Child>(true),
                ParentScaleInverseFromEntity = GetComponentDataFromEntity<ParentScaleInverse>(),
                LastSystemVersion = LastSystemVersion
            };
            var toParentScaleInverseJobHandle = toParentScaleInverseJob.Schedule(m_Group, inputDeps);
            return toParentScaleInverseJobHandle;
        }
    }
}
