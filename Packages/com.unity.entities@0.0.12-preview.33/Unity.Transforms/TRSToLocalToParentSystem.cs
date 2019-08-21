using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

/* **************
   COPY AND PASTE
   **************
 * TRSLocalToWorldSystem and TRSLocalToParentSystem are copy-and-paste.
 * Any changes to one must be copied to the other.
 * The only differences are:
 *   - s/LocalToWorld/LocalToParent/g
 *   - Add variation for ParentScaleInverse
*/

namespace Unity.Transforms
{
    // LocalToParent = Translation * Rotation * NonUniformScale
    // (or) LocalToParent = Translation * CompositeRotation * NonUniformScale
    // (or) LocalToParent = Translation * Rotation * Scale
    // (or) LocalToParent = Translation * CompositeRotation * Scale
    // (or) LocalToParent = Translation * Rotation * CompositeScale
    // (or) LocalToParent = Translation * CompositeRotation * CompositeScale
    // (or) LocalToParent = Translation * ParentScaleInverse * Rotation * NonUniformScale
    // (or) LocalToParent = Translation * ParentScaleInverse * CompositeRotation * NonUniformScale
    // (or) LocalToParent = Translation * ParentScaleInverse * Rotation * Scale
    // (or) LocalToParent = Translation * ParentScaleInverse * CompositeRotation * Scale
    // (or) LocalToParent = Translation * ParentScaleInverse * Rotation * CompositeScale
    // (or) LocalToParent = Translation * ParentScaleInverse * CompositeRotation * CompositeScale

    public abstract class TRSToLocalToParentSystem : JobComponentSystem
    {
        private EntityQuery m_Group;

        [BurstCompile]
        struct TRSToLocalToParent : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<Rotation> RotationType;
            [ReadOnly] public ArchetypeChunkComponentType<CompositeRotation> CompositeRotationType;
            [ReadOnly] public ArchetypeChunkComponentType<Translation> TranslationType;
            [ReadOnly] public ArchetypeChunkComponentType<NonUniformScale> NonUniformScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<Scale> ScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<CompositeScale> CompositeScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<ParentScaleInverse> ParentScaleInverseType;
            public ArchetypeChunkComponentType<LocalToParent> LocalToParentType;

            public void Execute(ArchetypeChunk chunk, int chunkIndex, int entityOffset)
            {
                var chunkTranslations = chunk.GetNativeArray(TranslationType);
                var chunkNonUniformScales = chunk.GetNativeArray(NonUniformScaleType);
                var chunkScales = chunk.GetNativeArray(ScaleType);
                var chunkCompositeScales = chunk.GetNativeArray(CompositeScaleType);
                var chunkRotations = chunk.GetNativeArray(RotationType);
                var chunkCompositeRotations = chunk.GetNativeArray(CompositeRotationType);
                var chunkLocalToParent = chunk.GetNativeArray(LocalToParentType);
                var chunkParentScaleInverses = chunk.GetNativeArray(ParentScaleInverseType);
                var hasTranslation = chunk.Has(TranslationType);
                var hasCompositeRotation = chunk.Has(CompositeRotationType);
                var hasRotation = chunk.Has(RotationType);
                var hasAnyRotation = hasCompositeRotation || hasRotation;
                var hasNonUniformScale = chunk.Has(NonUniformScaleType);
                var hasScale = chunk.Has(ScaleType);
                var hasCompositeScale = chunk.Has(CompositeScaleType);
                var hasAnyScale = hasScale || hasNonUniformScale || hasCompositeScale;
                var hasParentScaleInverse = chunk.Has(ParentScaleInverseType);
                var count = chunk.Count;

                // #todo jump table when burst supports function pointers

                if (hasParentScaleInverse)
                {
                    if (!hasAnyRotation)
                    {
                        // 00 = invalid (must have at least one)
                        // 01
                        if (!hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(parentScaleInverse, scale)
                                };
                            }
                        }
                        // 10
                        else if (hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(float4x4.Translate(translation), parentScaleInverse)
                                };
                            }
                        }
                        // 11
                        else if (hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(math.mul(float4x4.Translate(translation), parentScaleInverse),
                                        scale)
                                };
                            }
                        }
                    }
                    else if (hasCompositeRotation)
                    {
                        // 00
                        if (!hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkCompositeRotations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(parentScaleInverse, rotation)
                                };
                            }
                        }
                        // 01
                        else if (!hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkCompositeRotations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(parentScaleInverse, math.mul(rotation, scale))
                                };
                            }
                        }
                        // 10
                        else if (hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkCompositeRotations[i].Value;
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(math.mul(float4x4.Translate(translation), parentScaleInverse),
                                        rotation)
                                };
                            }
                        }
                        // 11
                        else if (hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkCompositeRotations[i].Value;
                                var translation = chunkTranslations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(
                                        math.mul(math.mul(float4x4.Translate(translation), parentScaleInverse),
                                            rotation), scale)
                                };
                            }
                        }
                    }
                    else // if (hasRotation) -- Only in same WriteGroup if !hasCompositeRotation
                    {
                        // 00
                        if (!hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkRotations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(parentScaleInverse, new float4x4(rotation, float3.zero))
                                };
                            }
                        }
                        // 01
                        else if (!hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkRotations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(parentScaleInverse,
                                        math.mul(new float4x4(rotation, float3.zero), scale))
                                };
                            }
                        }
                        // 10
                        else if (hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkRotations[i].Value;
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(math.mul(float4x4.Translate(translation), parentScaleInverse),
                                        new float4x4(rotation, new float3(0.0f)))
                                };
                            }
                        }
                        // 11
                        else if (hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var parentScaleInverse = chunkParentScaleInverses[i].Value;
                                var rotation = chunkRotations[i].Value;
                                var translation = chunkTranslations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(
                                        math.mul(math.mul(float4x4.Translate(translation), parentScaleInverse),
                                            new float4x4(rotation, new float3(0.0f))), scale)
                                };
                            }
                        }
                    }
                }
                else // (!hasParentScaleInverse)
                {
                    if (!hasAnyRotation)
                    {
                        // 00 = invalid (must have at least one)
                        // 01
                        if (!hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = scale
                                };
                            }
                        }
                        // 10
                        else if (hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = float4x4.Translate(translation)
                                };
                            }
                        }
                        // 11
                        else if (hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(float4x4.Translate(translation), scale)
                                };
                            }
                        }
                    }
                    else if (hasCompositeRotation)
                    {
                        // 00
                        if (!hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkCompositeRotations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = rotation
                                };
                            }
                        }
                        // 01
                        else if (!hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkCompositeRotations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(rotation, scale)
                                };
                            }
                        }
                        // 10
                        else if (hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkCompositeRotations[i].Value;
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(float4x4.Translate(translation), rotation)
                                };
                            }
                        }
                        // 11
                        else if (hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkCompositeRotations[i].Value;
                                var translation = chunkTranslations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(math.mul(float4x4.Translate(translation), rotation), scale)
                                };
                            }
                        }
                    }
                    else // if (hasRotation) -- Only in same WriteGroup if !hasCompositeRotation
                    {
                        // 00
                        if (!hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkRotations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = new float4x4(rotation, float3.zero)
                                };
                            }
                        }
                        // 01
                        else if (!hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkRotations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(new float4x4(rotation, float3.zero), scale)
                                };
                            }
                        }
                        // 10
                        else if (hasTranslation && !hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkRotations[i].Value;
                                var translation = chunkTranslations[i].Value;

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = new float4x4(rotation, translation)
                                };
                            }
                        }
                        // 11
                        else if (hasTranslation && hasAnyScale)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                var rotation = chunkRotations[i].Value;
                                var translation = chunkTranslations[i].Value;
                                var scale = hasNonUniformScale
                                    ? float4x4.Scale(chunkNonUniformScales[i].Value)
                                    : (hasScale
                                        ? float4x4.Scale(new float3(chunkScales[i].Value))
                                        : chunkCompositeScales[i].Value);

                                chunkLocalToParent[i] = new LocalToParent
                                {
                                    Value = math.mul(new float4x4(rotation, translation), scale)
                                };
                            }
                        }
                    }
                }
            }
        }

        protected override void OnCreate()
        {
            m_Group = GetEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[]
                {
                    typeof(LocalToParent)
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<NonUniformScale>(),
                    ComponentType.ReadOnly<Scale>(),
                    ComponentType.ReadOnly<Rotation>(),
                    ComponentType.ReadOnly<CompositeRotation>(),
                    ComponentType.ReadOnly<CompositeScale>(),
                    ComponentType.ReadOnly<Translation>(),
                    ComponentType.ReadOnly<ParentScaleInverse>()
                },
                Options = EntityQueryOptions.FilterWriteGroup
            });
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var rotationType = GetArchetypeChunkComponentType<Rotation>(true);
            var compositeRotationTyoe = GetArchetypeChunkComponentType<CompositeRotation>(true);
            var translationType = GetArchetypeChunkComponentType<Translation>(true);
            var nonUniformScaleType = GetArchetypeChunkComponentType<NonUniformScale>(true);
            var scaleType = GetArchetypeChunkComponentType<Scale>(true);
            var compositeScaleType = GetArchetypeChunkComponentType<CompositeScale>(true);
            var parentScaleInverseType = GetArchetypeChunkComponentType<ParentScaleInverse>(true);
            var localToWorldType = GetArchetypeChunkComponentType<LocalToParent>(false);
            var trsToLocalToParentJob = new TRSToLocalToParent()
            {
                RotationType = rotationType,
                CompositeRotationType = compositeRotationTyoe,
                TranslationType = translationType,
                ScaleType = scaleType,
                NonUniformScaleType = nonUniformScaleType,
                CompositeScaleType = compositeScaleType,
                ParentScaleInverseType = parentScaleInverseType,
                LocalToParentType = localToWorldType
            };
            var trsToLocalToParentJobHandle = trsToLocalToParentJob.Schedule(m_Group, inputDeps);
            return trsToLocalToParentJobHandle;
        }
    }
}
