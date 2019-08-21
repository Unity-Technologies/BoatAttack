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
    [WriteGroup(typeof(PostRotation))]
    public struct PostRotationEulerXYZ : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(PostRotation))]
    public struct PostRotationEulerXZY : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(PostRotation))]
    public struct PostRotationEulerYXZ : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(PostRotation))]
    public struct PostRotationEulerYZX : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(PostRotation))]
    public struct PostRotationEulerZXY : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(PostRotation))]
    public struct PostRotationEulerZYX : IComponentData
    {
        public float3 Value;
    }

    // PostRotation = PostRotationEulerXYZ
    // (or) PostRotation = PostRotationEulerXZY
    // (or) PostRotation = PostRotationEulerYXZ
    // (or) PostRotation = PostRotationEulerYZX
    // (or) PostRotation = PostRotationEulerZXY
    // (or) PostRotation = PostRotationEulerZYX
    public abstract class PostRotationEulerSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc
            {
                All = new ComponentType[]
                {
                    typeof(PostRotation)
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<PostRotationEulerXYZ>(),
                    ComponentType.ReadOnly<PostRotationEulerXZY>(),
                    ComponentType.ReadOnly<PostRotationEulerYXZ>(),
                    ComponentType.ReadOnly<PostRotationEulerYZX>(),
                    ComponentType.ReadOnly<PostRotationEulerZXY>(),
                    ComponentType.ReadOnly<PostRotationEulerZYX>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        [BurstCompile]
        struct PostRotationEulerToPostRotation : IJobChunk
        {
            public ArchetypeChunkComponentType<PostRotation> PostRotationType;
            [ReadOnly] public ArchetypeChunkComponentType<PostRotationEulerXYZ> PostRotationEulerXYZType;
            [ReadOnly] public ArchetypeChunkComponentType<PostRotationEulerXZY> PostRotationEulerXZYType;
            [ReadOnly] public ArchetypeChunkComponentType<PostRotationEulerYXZ> PostRotationEulerYXZType;
            [ReadOnly] public ArchetypeChunkComponentType<PostRotationEulerYZX> PostRotationEulerYZXType;
            [ReadOnly] public ArchetypeChunkComponentType<PostRotationEulerZXY> PostRotationEulerZXYType;
            [ReadOnly] public ArchetypeChunkComponentType<PostRotationEulerZYX> PostRotationEulerZYXType;
            public uint LastSystemVersion;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                if (chunk.Has(PostRotationEulerXYZType))
                {
                    if (!chunk.DidChange(PostRotationEulerXYZType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(PostRotationType);
                    var chunkPostRotationEulerXYZs = chunk.GetNativeArray(PostRotationEulerXYZType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new PostRotation
                        {
                            Value = quaternion.EulerXYZ(chunkPostRotationEulerXYZs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(PostRotationEulerXZYType))
                {
                    if (!chunk.DidChange(PostRotationEulerXZYType, LastSystemVersion))
                        return;
                        
                    var chunkRotations = chunk.GetNativeArray(PostRotationType);
                    var chunkPostRotationEulerXZYs = chunk.GetNativeArray(PostRotationEulerXZYType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new PostRotation
                        {
                            Value = quaternion.EulerXZY(chunkPostRotationEulerXZYs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(PostRotationEulerYXZType))
                {
                    if (!chunk.DidChange(PostRotationEulerYXZType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(PostRotationType);
                    var chunkPostRotationEulerYXZs = chunk.GetNativeArray(PostRotationEulerYXZType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new PostRotation
                        {
                            Value = quaternion.EulerYXZ(chunkPostRotationEulerYXZs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(PostRotationEulerYZXType))
                {
                    if (!chunk.DidChange(PostRotationEulerYZXType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(PostRotationType);
                    var chunkPostRotationEulerYZXs = chunk.GetNativeArray(PostRotationEulerYZXType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new PostRotation
                        {
                            Value = quaternion.EulerYZX(chunkPostRotationEulerYZXs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(PostRotationEulerZXYType))
                {
                    if (!chunk.DidChange(PostRotationEulerZXYType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(PostRotationType);
                    var chunkPostRotationEulerZXYs = chunk.GetNativeArray(PostRotationEulerZXYType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new PostRotation
                        {
                            Value = quaternion.EulerZXY(chunkPostRotationEulerZXYs[i].Value)
                        };
                    }
                }
                else if (chunk.Has(PostRotationEulerZYXType))
                {
                    if (!chunk.DidChange(PostRotationEulerZYXType, LastSystemVersion))
                        return;

                    var chunkRotations = chunk.GetNativeArray(PostRotationType);
                    var chunkPostRotationEulerZYXs = chunk.GetNativeArray(PostRotationEulerZYXType);
                    for (var i = 0; i < chunk.Count; i++)
                    {
                        chunkRotations[i] = new PostRotation
                        {
                            Value = quaternion.EulerZYX(chunkPostRotationEulerZYXs[i].Value)
                        };
                    }
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new PostRotationEulerToPostRotation()
            {
                PostRotationType = GetArchetypeChunkComponentType<PostRotation>(false),
                PostRotationEulerXYZType = GetArchetypeChunkComponentType<PostRotationEulerXYZ>(true),
                PostRotationEulerXZYType = GetArchetypeChunkComponentType<PostRotationEulerXZY>(true),
                PostRotationEulerYXZType = GetArchetypeChunkComponentType<PostRotationEulerYXZ>(true),
                PostRotationEulerYZXType = GetArchetypeChunkComponentType<PostRotationEulerYZX>(true),
                PostRotationEulerZXYType = GetArchetypeChunkComponentType<PostRotationEulerZXY>(true),
                PostRotationEulerZYXType = GetArchetypeChunkComponentType<PostRotationEulerZYX>(true),
                LastSystemVersion = LastSystemVersion
            };
            return job.Schedule(m_Group, inputDependencies);
        }
    }
}
