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
    [WriteGroup(typeof(ParentScaleInverse))]
    public struct CompositeScale : IComponentData
    {
        public float4x4 Value;
    }


    [Serializable]
    [WriteGroup(typeof(CompositeScale))]
    public struct ScalePivot : IComponentData
    {
        public float3 Value;
    }

    [Serializable]
    [WriteGroup(typeof(CompositeScale))]
    public struct ScalePivotTranslation : IComponentData
    {
        public float3 Value;
    }

    // CompositeScale = ScalePivotTranslation * ScalePivot * Scale * ScalePivot^-1
    // (or) CompositeScale = ScalePivotTranslation * ScalePivot * NonUniformScale * ScalePivot^-1
    public abstract class CompositeScaleSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        [BurstCompile]
        struct ToCompositeScale : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<Scale> ScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<NonUniformScale> NonUniformScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<ScalePivot> ScalePivotType;
            [ReadOnly] public ArchetypeChunkComponentType<ScalePivotTranslation> ScalePivotTranslationType;
            public ArchetypeChunkComponentType<CompositeScale> CompositeScaleType;
            public uint LastSystemVersion;

            public void Execute(ArchetypeChunk chunk, int index, int entityOffset)
            {
                var chunkScalePivotTranslations = chunk.GetNativeArray(ScalePivotTranslationType);
                var chunkScales = chunk.GetNativeArray(ScaleType);
                var chunkNonUniformScale = chunk.GetNativeArray(NonUniformScaleType);
                var chunkScalePivots = chunk.GetNativeArray(ScalePivotType);
                var chunkCompositeScales = chunk.GetNativeArray(CompositeScaleType);

                var hasScalePivotTranslation = chunk.Has(ScalePivotTranslationType);
                var hasScale = chunk.Has(ScaleType);
                var hasNonUniformScale = chunk.Has(NonUniformScaleType);
                var hasScalePivot = chunk.Has(ScalePivotType);
                var count = chunk.Count;

                var hasAnyScale = hasScale || hasNonUniformScale;

                // 000 - Invalid. Must have at least one.
                // 001 
                if (!hasAnyScale && !hasScalePivotTranslation && hasScalePivot)
                {
                    var didChange = chunk.DidChange(ScalePivotType, LastSystemVersion);
                    if (!didChange)
                        return;

                    // Only pivot? Doesn't do anything.
                    for (int i = 0; i < count; i++)
                        chunkCompositeScales[i] = new CompositeScale {Value = float4x4.identity};
                }
                // 010
                else if (!hasAnyScale && hasScalePivotTranslation && !hasScalePivot)
                {
                    var didChange = chunk.DidChange(ScalePivotTranslationType, LastSystemVersion);
                    if (!didChange)
                        return;

                    for (int i = 0; i < count; i++)
                    {
                        var translation = chunkScalePivotTranslations[i].Value;

                        chunkCompositeScales[i] = new CompositeScale
                            {Value = float4x4.Translate(translation)};
                    }
                }
                // 011
                else if (!hasAnyScale && hasScalePivotTranslation && hasScalePivot)
                {
                    var didChange = chunk.DidChange(ScalePivotTranslationType, LastSystemVersion);
                    if (!didChange)
                        return;

                    // Pivot without scale doesn't affect anything. Only translation.
                    for (int i = 0; i < count; i++)
                    {
                        var translation = chunkScalePivotTranslations[i].Value;

                        chunkCompositeScales[i] = new CompositeScale
                            {Value = float4x4.Translate(translation)};
                    }
                }
                // 100
                else if (hasAnyScale && !hasScalePivotTranslation && !hasScalePivot)
                {
                    // Has both valid input, but Scale overwrites.
                    if (hasScale)
                    {
                        var didChange = chunk.DidChange(ScaleType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var scale = chunkScales[i].Value;
                            chunkCompositeScales[i] = new CompositeScale {Value = float4x4.Scale(scale)};
                        }
                    }
                    else // if (hasNonUniformScale)
                    {
                        var didChange = chunk.DidChange(NonUniformScaleType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var scale = chunkNonUniformScale[i].Value;
                            chunkCompositeScales[i] = new CompositeScale {Value = float4x4.Scale(scale)};
                        }
                    }
                }
                // 101
                else if (hasAnyScale && !hasScalePivotTranslation && hasScalePivot)
                {
                    // Has both valid input, but Scale overwrites.
                    if (hasScale)
                    {
                        var didChange = chunk.DidChange(ScaleType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var scale = chunkScales[i].Value;
                            var pivot = chunkScalePivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeScales[i] = new CompositeScale
                            {
                                Value = math.mul(math.mul(float4x4.Translate(pivot), float4x4.Scale(scale)),
                                    float4x4.Translate(inversePivot))
                            };
                        }
                    }
                    else // if (hasNonUniformScalee)
                    {
                        var didChange = chunk.DidChange(NonUniformScaleType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var scale = chunkNonUniformScale[i].Value;
                            var pivot = chunkScalePivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeScales[i] = new CompositeScale
                            {
                                Value = math.mul(math.mul(float4x4.Translate(pivot), float4x4.Scale(scale)),
                                    float4x4.Translate(inversePivot))
                            };
                        }
                    }
                }

                // 110
                else if (hasAnyScale && hasScalePivotTranslation && !hasScalePivot)
                {
                    // Has both valid input, but Scale overwrites.
                    if (hasScale)
                    {
                        var didChange = chunk.DidChange(ScaleType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotTranslationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkScalePivotTranslations[i].Value;
                            var scale = chunkScales[i].Value;

                            chunkCompositeScales[i] = new CompositeScale
                                {Value = math.mul(float4x4.Translate(translation), float4x4.Scale(scale))};
                        }
                    }
                    else // if (hasNonUniformScale)
                    {
                        var didChange = chunk.DidChange(NonUniformScaleType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotTranslationType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkScalePivotTranslations[i].Value;
                            var scale = chunkNonUniformScale[i].Value;

                            chunkCompositeScales[i] = new CompositeScale
                                {Value = math.mul(float4x4.Translate(translation), float4x4.Scale(scale))};
                        }
                    }
                }
                // 111
                else if (hasAnyScale && hasScalePivotTranslation && hasScalePivot)
                {
                    // Has both valid input, but Scale overwrites.
                    if (hasScale)
                    {
                        var didChange = chunk.DidChange(ScaleType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotTranslationType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkScalePivotTranslations[i].Value;
                            var scale = chunkScales[i].Value;
                            var pivot = chunkScalePivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeScales[i] = new CompositeScale
                            {
                                Value = math.mul(float4x4.Translate(translation),
                                    math.mul(math.mul(float4x4.Translate(pivot), float4x4.Scale(scale)),
                                        float4x4.Translate(inversePivot)))
                            };
                        }
                    }
                    else // if (hasNonUniformScale)
                    {
                        var didChange = chunk.DidChange(NonUniformScaleType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotTranslationType, LastSystemVersion) ||
                                        chunk.DidChange(ScalePivotType, LastSystemVersion);
                        if (!didChange)
                            return;

                        for (int i = 0; i < count; i++)
                        {
                            var translation = chunkScalePivotTranslations[i].Value;
                            var scale = chunkNonUniformScale[i].Value;
                            var pivot = chunkScalePivots[i].Value;
                            var inversePivot = -1.0f * pivot;

                            chunkCompositeScales[i] = new CompositeScale
                            {
                                Value = math.mul(float4x4.Translate(translation),
                                    math.mul(math.mul(float4x4.Translate(pivot), float4x4.Scale(scale)),
                                        float4x4.Translate(inversePivot)))
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
                    typeof(CompositeScale)
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<Scale>(),
                    ComponentType.ReadOnly<NonUniformScale>(),
                    ComponentType.ReadOnly<ScalePivot>(),
                    ComponentType.ReadOnly<ScalePivotTranslation>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var compositeScaleType = GetArchetypeChunkComponentType<CompositeScale>(false);
            var scaleType = GetArchetypeChunkComponentType<Scale>(true);
            var scaleAxisType = GetArchetypeChunkComponentType<NonUniformScale>(true);
            var scalePivotTranslationType = GetArchetypeChunkComponentType<ScalePivotTranslation>(true);
            var scalePivotType = GetArchetypeChunkComponentType<ScalePivot>(true);

            var toCompositeScaleJob = new ToCompositeScale
            {
                CompositeScaleType = compositeScaleType,
                NonUniformScaleType = scaleAxisType,
                ScaleType = scaleType,
                ScalePivotType = scalePivotType,
                ScalePivotTranslationType = scalePivotTranslationType,
                LastSystemVersion = LastSystemVersion
            };
            var toCompositeScaleJobHandle = toCompositeScaleJob.Schedule(m_Group, inputDeps);
            return toCompositeScaleJobHandle;
        }
    }
}
