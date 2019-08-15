using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

/* **************
   COPY AND PASTE
   **************
 * PostRotationEuler.cs and RotationEuler.cs are copy-and-paste.
 * Any changes to one must be copied to the other.
 * The only differences are:
 *   s/PostRotation/Rotation/g
*/

namespace Unity.Transforms
{
    [Serializable]
    [WriteGroup(typeof(Rotation))]
    public struct RotationEulerXYZ : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(Rotation))]
    public struct RotationEulerXZY : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(Rotation))]
    public struct RotationEulerYXZ : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(Rotation))]
    public struct RotationEulerYZX : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(Rotation))]
    public struct RotationEulerZXY : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(Rotation))]
    public struct RotationEulerZYX : IComponentData
    {
        public float3 Value;
    }

    // Rotation = RotationEulerXYZ
    // (or) Rotation = RotationEulerXZY
    // (or) Rotation = RotationEulerYXZ
    // (or) Rotation = RotationEulerYZX
    // (or) Rotation = RotationEulerZXY
    // (or) Rotation = RotationEulerZYX
    public abstract class RotationEulerSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(Rotation)
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<RotationEulerXYZ>(),
                    ComponentType.ReadOnly<RotationEulerXZY>(),
                    ComponentType.ReadOnly<RotationEulerYXZ>(),
                    ComponentType.ReadOnly<RotationEulerYZX>(),
                    ComponentType.ReadOnly<RotationEulerZXY>(),
                    ComponentType.ReadOnly<RotationEulerZYX>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        [BurstCompile]
        struct RotationEulerToRotation : IJobChunk
        {
            public ArchetypeChunkComponentType<Rotation> RotationType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationEulerXYZ> RotationEulerXYZType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationEulerXZY> RotationEulerXZYType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationEulerYXZ> RotationEulerYXZType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationEulerYZX> RotationEulerYZXType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationEulerZXY> RotationEulerZXYType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationEulerZYX> RotationEulerZYXType;
            public uint LastSystemVersion;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                if (chunk.Has(RotationEulerXYZType))
                {
                    if (!chunk.DidChange(RotationEulerXYZType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(RotationType);
                    var chunkRotationEulerXYZs = chunk.GetNativeArray(RotationEulerXYZType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new Rotation
                        {
                            Value = quaternion.EulerXYZ(chunkRotationEulerXYZs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(RotationEulerXZYType))
                {
                    if (!chunk.DidChange(RotationEulerXZYType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(RotationType);
                    var chunkRotationEulerXZYs = chunk.GetNativeArray(RotationEulerXZYType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new Rotation
                        {
                            Value = quaternion.EulerXZY(chunkRotationEulerXZYs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(RotationEulerYXZType))
                {
                    if (!chunk.DidChange(RotationEulerYXZType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(RotationType);
                    var chunkRotationEulerYXZs = chunk.GetNativeArray(RotationEulerYXZType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new Rotation
                        {
                            Value = quaternion.EulerYXZ(chunkRotationEulerYXZs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(RotationEulerYZXType))
                {
                    if (!chunk.DidChange(RotationEulerYZXType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(RotationType);
                    var chunkRotationEulerYZXs = chunk.GetNativeArray(RotationEulerYZXType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new Rotation
                        {
                            Value = quaternion.EulerYZX(chunkRotationEulerYZXs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(RotationEulerZXYType))
                {
                    if (!chunk.DidChange(RotationEulerZXYType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(RotationType);
                    var chunkRotationEulerZXYs = chunk.GetNativeArray(RotationEulerZXYType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new Rotation
                        {
                            Value = quaternion.EulerZXY(chunkRotationEulerZXYs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(RotationEulerZYXType))
                {
                    if (!chunk.DidChange(RotationEulerZYXType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(RotationType);
                    var chunkRotationEulerZYXs = chunk.GetNativeArray(RotationEulerZYXType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new Rotation
                        {
                            Value = quaternion.EulerZYX(chunkRotationEulerZYXs[i].Value)
                        };
                    }
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new RotationEulerToRotation()
            {
                RotationType = GetArchetypeChunkComponentType<Rotation>(false),
                RotationEulerXYZType = GetArchetypeChunkComponentType<RotationEulerXYZ>(true),
                RotationEulerXZYType = GetArchetypeChunkComponentType<RotationEulerXZY>(true),
                RotationEulerYXZType = GetArchetypeChunkComponentType<RotationEulerYXZ>(true),
                RotationEulerYZXType = GetArchetypeChunkComponentType<RotationEulerYZX>(true),
                RotationEulerZXYType = GetArchetypeChunkComponentType<RotationEulerZXY>(true),
                RotationEulerZYXType = GetArchetypeChunkComponentType<RotationEulerZYX>(true),
                LastSystemVersion = LastSystemVersion
            };
            return job.Schedule(m_Group, inputDependencies);
        }
    }
}
