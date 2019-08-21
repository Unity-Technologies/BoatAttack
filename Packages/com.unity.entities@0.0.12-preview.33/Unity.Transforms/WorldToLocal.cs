using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Transforms
{
    [Serializable]
    public struct WorldToLocal : IComponentData
    {
        public float4x4 Value;
        
        public float3 Right => new float3(Value.c0.x, Value.c0.y, Value.c0.z);
        public float3 Up => new float3(Value.c1.x, Value.c1.y, Value.c1.z);
        public float3 Forward => new float3(Value.c2.x, Value.c2.y, Value.c2.z);
        public float3 Position => new float3(Value.c3.x, Value.c3.y, Value.c3.z);
    }

    public abstract class WorldToLocalSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        struct ToWorldToLocal : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<LocalToWorld> LocalToWorldType;
            public ArchetypeChunkComponentType<WorldToLocal> WorldToLocalType;
            public uint LastSystemVersion;
            
            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                if (!chunk.DidChange(LocalToWorldType, LastSystemVersion))
                    return;

                var chunkLocalToWorld = chunk.GetNativeArray(LocalToWorldType);
                var chunkWorldToLocal = chunk.GetNativeArray(WorldToLocalType);
                
                for (int i = 0; i < chunk.Count; i++)
                {
                    var localToWorld = chunkLocalToWorld[i].Value;
                    chunkWorldToLocal[i] = new WorldToLocal {Value = math.inverse(localToWorld)};
                }
            }
        }

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(WorldToLocal),
                    ComponentType.ReadOnly<LocalToWorld>(),
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var toWorldToLocalJob = new ToWorldToLocal
            {
                LocalToWorldType = GetArchetypeChunkComponentType<LocalToWorld>(true),
                WorldToLocalType = GetArchetypeChunkComponentType<WorldToLocal>(),
                LastSystemVersion = LastSystemVersion
            };
            var toWorldToLocalJobHandle = toWorldToLocalJob.Schedule(m_Group, inputDeps);
            return toWorldToLocalJobHandle;
        }
    }
}
