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
    // LocalToWorld = Translation * Rotation * NonUniformScale
    // (or) LocalToWorld = Translation * CompositeRotation * NonUniformScale
    // (or) LocalToWorld = Translation * Rotation * Scale
    // (or) LocalToWorld = Translation * CompositeRotation * Scale
    // (or) LocalToWorld = Translation * Rotation * CompositeScale
    // (or) LocalToWorld = Translation * CompositeRotation * CompositeScale
    public abstract class TRSToLocalToWorldSystem : JobComponentSystem
    {
        private EntityQuery m_Group;
        
        [BurstCompile]
        struct TRSToLocalToWorld : IJobChunk
        {
            [ReadOnly] public ArchetypeChunkComponentType<Rotation> RotationType;
            [ReadOnly] public ArchetypeChunkComponentType<CompositeRotation> CompositeRotationType;
            [ReadOnly] public ArchetypeChunkComponentType<Translation> TranslationType;
            [ReadOnly] public ArchetypeChunkComponentType<NonUniformScale> NonUniformScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<Scale> ScaleType;
            [ReadOnly] public ArchetypeChunkComponentType<CompositeScale> CompositeScaleType;
            public ArchetypeChunkComponentType<LocalToWorld> LocalToWorldType;
            
            public void Execute(ArchetypeChunk chunk, int chunkIndex, int entityOffset)
            {
                var chunkTranslations = chunk.GetNativeArray(TranslationType);
                var chunkNonUniformScales = chunk.GetNativeArray(NonUniformScaleType);
                var chunkScales = chunk.GetNativeArray(ScaleType);
                var chunkCompositeScales = chunk.GetNativeArray(CompositeScaleType);
                var chunkRotations = chunk.GetNativeArray(RotationType);
                var chunkCompositeRotations = chunk.GetNativeArray(CompositeRotationType);
                var chunkLocalToWorld = chunk.GetNativeArray(LocalToWorldType);
                var hasTranslation = chunk.Has(TranslationType);
                var hasCompositeRotation = chunk.Has(CompositeRotationType);
                var hasRotation = chunk.Has(RotationType);
                var hasAnyRotation = hasCompositeRotation || hasRotation;
                var hasNonUniformScale = chunk.Has(NonUniformScaleType);
                var hasScale = chunk.Has(ScaleType);
                var hasCompositeScale = chunk.Has(CompositeScaleType);
                var hasAnyScale = hasScale || hasNonUniformScale || hasCompositeScale;
                var count = chunk.Count;

                // #todo jump table when burst supports function pointers

                if (!hasAnyRotation)
                {
                    // 00 = invalid (must have at least one)
                    // 01
                    if (!hasTranslation && hasAnyScale)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            var scale = hasNonUniformScale ? float4x4.Scale(chunkNonUniformScales[i].Value) : ( hasScale ? float4x4.Scale(new float3(chunkScales[i].Value)) : chunkCompositeScales[i].Value );
                            
                            chunkLocalToWorld[i] = new LocalToWorld
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
                           
                            chunkLocalToWorld[i] = new LocalToWorld
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
                            var scale = hasNonUniformScale ? float4x4.Scale(chunkNonUniformScales[i].Value) : ( hasScale ? float4x4.Scale(new float3(chunkScales[i].Value)) : chunkCompositeScales[i].Value );
                            var translation = chunkTranslations[i].Value;

                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = math.mul(float4x4.Translate(translation),scale)
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
                            
                            chunkLocalToWorld[i] = new LocalToWorld
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
                            var scale = hasNonUniformScale ? float4x4.Scale(chunkNonUniformScales[i].Value) : ( hasScale ? float4x4.Scale(new float3(chunkScales[i].Value)) : chunkCompositeScales[i].Value );

                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = math.mul( rotation, scale)
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
                        
                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = math.mul( float4x4.Translate(translation), rotation ) 
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
                            var scale = hasNonUniformScale ? float4x4.Scale(chunkNonUniformScales[i].Value) : ( hasScale ? float4x4.Scale(new float3(chunkScales[i].Value)) : chunkCompositeScales[i].Value );

                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = math.mul( math.mul( float4x4.Translate(translation), rotation ) , scale)
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
                            
                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = new float4x4(rotation,float3.zero)
                            };
                        }
                    }
                    // 01
                    else if (!hasTranslation && hasAnyScale)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            var rotation = chunkRotations[i].Value;
                            var scale = hasNonUniformScale ? float4x4.Scale(chunkNonUniformScales[i].Value) : ( hasScale ? float4x4.Scale(new float3(chunkScales[i].Value)) : chunkCompositeScales[i].Value );

                            chunkLocalToWorld[i] = new LocalToWorld
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
                        
                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = new float4x4(rotation,translation)
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
                            var scale = hasNonUniformScale ? float4x4.Scale(chunkNonUniformScales[i].Value) : ( hasScale ? float4x4.Scale(new float3(chunkScales[i].Value)) : chunkCompositeScales[i].Value );
                            
                            chunkLocalToWorld[i] = new LocalToWorld
                            {
                                Value = math.mul(new float4x4(rotation, translation),scale)
                            };
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
                    typeof(LocalToWorld)                    
                },
                Any = new ComponentType[]
                {
                    ComponentType.ReadOnly<NonUniformScale>(),
                    ComponentType.ReadOnly<Scale>(), 
                    ComponentType.ReadOnly<Rotation>(), 
                    ComponentType.ReadOnly<CompositeRotation>(), 
                    ComponentType.ReadOnly<CompositeScale>(),
                    ComponentType.ReadOnly<Translation>()
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
            var localToWorldType = GetArchetypeChunkComponentType<LocalToWorld>(false);
            var trsToLocalToWorldJob = new TRSToLocalToWorld()
            {
                RotationType = rotationType,
                CompositeRotationType = compositeRotationTyoe,
                TranslationType = translationType,
                ScaleType = scaleType,
                NonUniformScaleType = nonUniformScaleType,
                CompositeScaleType = compositeScaleType,
                LocalToWorldType = localToWorldType
            };
            var trsToLocalToWorldJobHandle = trsToLocalToWorldJob.Schedule(m_Group, inputDeps);
            return trsToLocalToWorldJobHandle;
        }
    }
}
