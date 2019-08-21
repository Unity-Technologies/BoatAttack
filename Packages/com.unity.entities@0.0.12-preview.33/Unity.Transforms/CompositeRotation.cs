using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Transforms
{
    [Serializable]
    [WriteGroup(typeof(LocalToWorld))]
    [WriteGroup(typeof(LocalToParent))]
    public struct CompositeRotation : IComponentData
    {
        public float4x4 Value;
    }
    
    [Serializable]
    [WriteGroup(typeof(CompositeRotation))]
    public struct PostRotation : IComponentData
    {
        public quaternion Value;
    }
    
    [Serializable]
    [WriteGroup(typeof(CompositeRotation))]
    public struct RotationPivot : IComponentData
    {
        public float3 Value;
    }
    
    [Serializable]
    [WriteGroup(typeof(CompositeRotation))]
    public struct RotationPivotTranslation : IComponentData
    {
        public float3 Value;
    }

    // CompositeRotation = RotationPivotTranslation * RotationPivot * Rotation * PostRotation * RotationPivot^-1
    public abstract class CompositeRotationSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        [BurstCompile]
        struct ToCompositeRotation : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<PostRotation> PostRotationType;
            [ReadOnly] public ArchetypeChunkComponentType<Rotation> RotationType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationPivot> RotationPivotType;
            [ReadOnly] public ArchetypeChunkComponentType<RotationPivotTranslation> RotationPivotTranslationType;
            public ArchetypeChunkComponentType<CompositeRotation> CompositeRotationType;
            public uint LastSystemVersion;

            public void Execute(ArchetypeChunk chunk, int index, int entityOffset)
            {
                var chunkRotationPivotTranslations = chunk.GetNativeArray(RotationPivotTranslationType);
                var chunkRotations = chunk.GetNativeArray(RotationType);
                var chunkPostRotation = chunk.GetNativeArray(PostRotationType);
                var chunkRotationPivots = chunk.GetNativeArray(RotationPivotType);
                var chunkCompositeRotations = chunk.GetNativeArray(CompositeRotationType);

                var hasRotationPivotTranslation = chunk.Has(RotationPivotTranslationType);
                var hasRotation = chunk.Has(RotationType);
                var hasPostRotation = chunk.Has(PostRotationType);
                var hasRotationPivot = chunk.Has(RotationPivotType);
                var count = chunk.Count;

                var hasAnyRotation = hasRotation || hasPostRotation;

                // 000 - Invalid. Must have at least one.
                // 001 
                if (!hasAnyRotation && !hasRotationPivotTranslation && hasRotationPivot)
                {
                    var didChange = chunk.DidChange(RotationPivotType, LastSystemVersion);
                    if (!didChange)
                        return;

                    // Only pivot? Doesn't do anything.
                    for (int i = 0; i < count; i++)
                        chunkCompositeRotations[i] = new CompositeRotation {Value = float4x4.identity};
                }
                // 010
                else if (!hasAnyRotation && hasRotationPivotTranslation && !hasRotationPivot)
                {
                    var didChange = chunk.DidChange(RotationPivotTranslationType, LastSystemVersion);
                    if (!didChange)
                        return;

                    for (int i = 0; i < count; i++)
                    {
                        var translation = chunkRotationPivotTranslations[i].Value;

                        chunkCompositeRotations[i] = new CompositeRotation
                            {Value = float4x4.Translate(translation)};
                    }
                }
                // 011
                else if (!hasAnyRotation && hasRotationPivotTranslation && hasRotationPivot)
                {
                    var didChange = chunk.DidChange(RotationPivotTranslationType, LastSystemVersion);
                    if (!didChange)
                        return;

                    // Pivot without rotation doesn't affect anything. Only translation.
                    for (int i = 0; i < count; i++)
                    {
                        var translation = chunkRotationPivotTranslations[i].Value;

                        chunkCompositeRotations[i] = new CompositeRotation
                            {Value = float4x4.Translate(translation)};
                    }
                }
                // 100
                else if (hasAnyRotation && !hasRotationPivotTranslation && !hasRotationPivot)
                {
                    // 00 - Not valid
                    // 01
                    if (!hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(RotationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var rotation = chunkRotations[i].Value;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = new float4x4(rotation, float3.zero)};
                        }
                    }
                    // 10
                    else if (hasPostRotation && !hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var rotation = chunkPostRotation[i].Value;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = new float4x4(rotation, float3.zero)};
                        }
                    }
                    // 11
                    else if (hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var rotation = math.mul(chunkRotations[i].Value, chunkPostRotation[i].Value);

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = new float4x4(rotation, float3.zero)};
                        }
                    }
                }
                // 101
                else if (hasAnyRotation && !hasRotationPivotTranslation && hasRotationPivot)
                {
                    // 00 - Not valid
                    // 01
                    if (!hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(RotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var rotation = chunkRotations[i].Value;
                            var pivot = chunkRotationPivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = math.mul(new float4x4(rotation, pivot), float4x4.Translate(inversePivot))};
                        }
                    }
                    // 10
                    else if (hasPostRotation && !hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var rotation = chunkPostRotation[i].Value;
                            var pivot = chunkRotationPivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = math.mul(new float4x4(rotation, pivot), float4x4.Translate(inversePivot))};
                        }
                    }
                    // 11
                    else if (hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var rotation = chunkPostRotation[i].Value;
                            var pivot = chunkRotationPivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = math.mul(new float4x4(rotation, pivot), float4x4.Translate(inversePivot))};
                        }
                    }
                }

                // 110
                else if (hasAnyRotation && hasRotationPivotTranslation && !hasRotationPivot)
                {
                    // 00 - Not valid
                    // 01
                    if (!hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(RotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotTranslationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkRotationPivotTranslations[i].Value;
                            var rotation = chunkRotations[i].Value;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = new float4x4(rotation, translation)};
                        }
                    }
                    // 10
                    else if (hasPostRotation && !hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotTranslationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkRotationPivotTranslations[i].Value;
                            var rotation = chunkRotations[i].Value;

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = new float4x4(rotation, translation)};
                        }
                    }
                    // 11
                    else if (hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotTranslationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkRotationPivotTranslations[i].Value;
                            var rotation = math.mul(chunkRotations[i].Value, chunkPostRotation[i].Value);

                            chunkCompositeRotations[i] = new CompositeRotation
                                {Value = new float4x4(rotation, translation)};
                        }
                    }
                }
                // 111
                else if (hasAnyRotation && hasRotationPivotTranslation && hasRotationPivot)
                {
                    // 00 - Not valid
                    // 01
                    if (!hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(RotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotTranslationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkRotationPivotTranslations[i].Value;
                            var rotation = chunkRotations[i].Value;
                            var pivot = chunkRotationPivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeRotations[i] = new CompositeRotation
                            {
                                Value = math.mul(float4x4.Translate(translation),
                                    math.mul(new float4x4(rotation, pivot), float4x4.Translate(inversePivot)))
                            };
                        }
                    }
                    // 10
                    else if (hasPostRotation && !hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotTranslationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkRotationPivotTranslations[i].Value;
                            var rotation = chunkPostRotation[i].Value;
                            var pivot = chunkRotationPivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeRotations[i] = new CompositeRotation
                            {
                                Value = math.mul(float4x4.Translate(translation),
                                    math.mul(new float4x4(rotation, pivot), float4x4.Translate(inversePivot)))
                            };
                        }
                    }
                    // 11
                    else if (hasPostRotation && hasRotation)
                    {
                        var didChange = chunk.DidChange(PostRotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotTranslationType, LastSystemVersion) ||
                                        chunk.DidChange(RotationPivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkRotationPivotTranslations[i].Value;
                            var rotation = math.mul(chunkRotations[i].Value, chunkPostRotation[i].Value);
                            var pivot = chunkRotationPivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeRotations[i] = new CompositeRotation
                            {
                                Value = math.mul(float4x4.Translate(translation),
                                    math.mul(new float4x4(rotation, pivot), float4x4.Translate(inversePivot)))
                            };
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
                    typeof(CompositeRotation)
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<Rotation>(),
                    ComponentType.ReadOnly<PostRotation>(),
                    ComponentType.ReadOnly<RotationPivot>(),
                    ComponentType.ReadOnly<RotationPivotTranslation>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var compositeRotationType = GetArchetypeChunkComponentType<CompositeRotation>(false);
            var rotationType = GetArchetypeChunkComponentType<Rotation>(true);
            var preRotationType = GetArchetypeChunkComponentType<PostRotation>(true);
            var rotationPivotTranslationType = GetArchetypeChunkComponentType<RotationPivotTranslation>(true);
            var rotationPivotType = GetArchetypeChunkComponentType<RotationPivot>(true);

            var toCompositeRotationJob = new ToCompositeRotation
            {
                CompositeRotationType = compositeRotationType,
                PostRotationType = preRotationType,
                RotationType = rotationType,
                RotationPivotType = rotationPivotType,
                RotationPivotTranslationType = rotationPivotTranslationType,
                LastSystemVersion = LastSystemVersion
            };
            var toCompositeRotationJobHandle = toCompositeRotationJob.Schedule(m_Group, inputDeps);
            return toCompositeRotationJobHandle;
        }
    }
}
