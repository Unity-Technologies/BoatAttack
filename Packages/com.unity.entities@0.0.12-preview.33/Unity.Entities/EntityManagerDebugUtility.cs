using Unity.Assertions;

namespace Unity.Entities
{
    /// <summary>
    /// Utilities which work on EntityManager data (for CreateDestroyEntities)
    /// Which require more than one of of these, in this order, as last parameters:
    ///     EntityComponentStore* entityComponentStore
    ///     SharedComponentDataManager sharedComponentDataManager
    /// </summary>
    internal static unsafe class EntityManagerDebugUtility
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        public static int CheckInternalConsistency(
            EntityComponentStore* entityComponentStore)
        {
            var totalCount = 0;
            for (var i = entityComponentStore->m_Archetypes.Count - 1; i >= 0; --i)
            {
                var archetype = entityComponentStore->m_Archetypes.p[i];

                var countInArchetype = 0;
                for (var j = 0; j < archetype->Chunks.Count; ++j)
                {
                    var chunk = archetype->Chunks.p[j];
                    Assert.IsTrue(chunk->Archetype == archetype);
                    Assert.IsTrue(chunk->Capacity >= chunk->Count);
                    Assert.AreEqual(chunk->Count, archetype->Chunks.GetChunkEntityCount(j));

                    var chunkEntities = (Entity*) chunk->Buffer;
                    entityComponentStore->AssertEntitiesExist(chunkEntities, chunk->Count);

                    if (!chunk->Locked)
                    {
                        if (chunk->Count < chunk->Capacity)
                            if (archetype->NumSharedComponents == 0)
                            {
                                Assert.IsTrue(chunk->ListWithEmptySlotsIndex >= 0 && chunk->ListWithEmptySlotsIndex <
                                              archetype->ChunksWithEmptySlots.Count);
                                Assert.IsTrue(
                                    chunk == archetype->ChunksWithEmptySlots.p[chunk->ListWithEmptySlotsIndex]);
                            }
                            else
                                Assert.IsTrue(archetype->FreeChunksBySharedComponents.Contains(chunk));
                    }

                    countInArchetype += chunk->Count;

                    if (chunk->Archetype->HasChunkHeader) // Chunk entities with chunk components are not supported
                    {
                        Assert.IsFalse(chunk->Archetype->HasChunkComponents);
                    }

                    Assert.AreEqual(chunk->Archetype->HasChunkComponents, chunk->metaChunkEntity != Entity.Null);
                    if (chunk->metaChunkEntity != Entity.Null)
                    {
                        var chunkHeaderTypeIndex = TypeManager.GetTypeIndex<ChunkHeader>();
                        entityComponentStore->AssertEntitiesExist(&chunk->metaChunkEntity, 1);
                        entityComponentStore->AssertEntityHasComponent(chunk->metaChunkEntity, chunkHeaderTypeIndex);
                        var chunkHeader =
                            *(ChunkHeader*) entityComponentStore->GetComponentDataWithTypeRO(chunk->metaChunkEntity,
                                chunkHeaderTypeIndex);
                        Assert.IsTrue(chunk == chunkHeader.ArchetypeChunk.m_Chunk);
                        var metaChunk = entityComponentStore->GetChunk(chunk->metaChunkEntity);
                        Assert.IsTrue(metaChunk->Archetype == chunk->Archetype->MetaChunkArchetype);
                    }
                }

                Assert.AreEqual(countInArchetype, archetype->EntityCount);

                totalCount += countInArchetype;
            }

            return totalCount;
        }
#endif

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
    }
}
