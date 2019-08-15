using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;

namespace Unity.Entities
{
    /// <summary>
    /// Utilities which work on EntityManager data (for CreateDestroyEntities)
    /// Which require more than one of of these, in this order, as last parameters:
    ///     EntityComponentStore* entityComponentStore
    ///     SharedComponentDataManager sharedComponentDataManager
    /// </summary>
    internal static unsafe class EntityManagerMoveEntitiesUtility
    {
        static readonly ProfilerMarker k_ProfileMoveSharedComponents = new ProfilerMarker("MoveSharedComponents");

        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        public static void AddExistingChunk(Chunk* chunk, int* sharedComponentIndices,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var archetype = chunk->Archetype;
            archetype->AddToChunkList(chunk, sharedComponentIndices, entityComponentStore->GlobalSystemVersion);
            archetype->EntityCount += chunk->Count;

            for (var i = 0; i < archetype->NumSharedComponents; ++i)
                managedComponentStore.AddReference(sharedComponentIndices[i]);

            if (chunk->Count < chunk->Capacity)
                archetype->EmptySlotTrackingAddChunk(chunk);

            entityComponentStore->AddExistingEntitiesInChunk(chunk);
        }

        public static void MoveChunks(
            NativeArray<ArchetypeChunk> chunks,
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping,
            EntityComponentStore* srcEntityComponentStore,
            ManagedComponentStore srcManagedComponentStore,
            EntityComponentStore* dstEntityComponentStore,
            ManagedComponentStore dstManagedComponentStore)
        {
            new MoveChunksJob
            {
                srcEntityComponentStore = srcEntityComponentStore,
                dstEntityComponentStore = dstEntityComponentStore,
                entityRemapping = entityRemapping,
                chunks = chunks
            }.Run();

            int chunkCount = chunks.Length;
            var remapChunks = new NativeArray<RemapChunk>(chunkCount, Allocator.TempJob);
            for (int i = 0; i < chunkCount; ++i)
            {
                var chunk = chunks[i].m_Chunk;
                var archetype = chunk->Archetype;

                //TODO: this should not be done more than once for each archetype
                var dstArchetype =
                    EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(archetype->Types, archetype->TypesCount,
                        dstEntityComponentStore);

                remapChunks[i] = new RemapChunk {chunk = chunk, dstArchetype = dstArchetype};
                chunk->SequenceNumber = dstEntityComponentStore->AssignSequenceNumber(chunk);

                if (archetype->MetaChunkArchetype != null)
                {
                    Entity srcEntity = chunk->metaChunkEntity;
                    Entity dstEntity;

                    EntityManagerCreateDestroyEntitiesUtility.CreateEntities(dstArchetype->MetaChunkArchetype,
                        &dstEntity, 1,
                        dstEntityComponentStore, dstManagedComponentStore);

                    srcEntityComponentStore->GetChunk(srcEntity, out var srcChunk, out var srcIndex);
                    dstEntityComponentStore->GetChunk(dstEntity, out var dstChunk, out var dstIndex);

                    ChunkDataUtility.SwapComponents(srcChunk, srcIndex, dstChunk, dstIndex, 1,
                        srcEntityComponentStore->GlobalSystemVersion, dstEntityComponentStore->GlobalSystemVersion);
                    EntityRemapUtility.AddEntityRemapping(ref entityRemapping, srcEntity, dstEntity);

                    EntityManagerCreateDestroyEntitiesUtility.DestroyEntities(&srcEntity, 1,
                        srcEntityComponentStore, srcManagedComponentStore);
                }
            }

            k_ProfileMoveSharedComponents.Begin();
            var remapShared =
                dstManagedComponentStore.MoveSharedComponents(srcManagedComponentStore, chunks,
                    entityRemapping,
                    Allocator.TempJob);
            k_ProfileMoveSharedComponents.End();

            var remapChunksJob = new RemapChunksJob
            {
                dstEntityComponentStore = dstEntityComponentStore,
                remapChunks = remapChunks,
                entityRemapping = entityRemapping
            }.Schedule(remapChunks.Length, 1);

            var moveChunksBetweenArchetypeJob = new MoveChunksBetweenArchetypeJob
            {
                remapChunks = remapChunks,
                remapShared = remapShared,
                globalSystemVersion = dstEntityComponentStore->GlobalSystemVersion
            }.Schedule(remapChunksJob);

            moveChunksBetweenArchetypeJob.Complete();

            remapShared.Dispose();
            remapChunks.Dispose();
        }

        public static void MoveChunks(
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping,
            EntityComponentStore* srcEntityComponentStore,
            ManagedComponentStore srcManagedComponentStore,
            EntityComponentStore* dstEntityComponentStore,
            ManagedComponentStore dstManagedComponentStore)
        {
            var moveChunksJob = new MoveAllChunksJob
            {
                srcEntityComponentStore = srcEntityComponentStore,
                dstEntityComponentStore = dstEntityComponentStore,
                entityRemapping = entityRemapping
            }.Schedule();

            JobHandle.ScheduleBatchedJobs();

            int chunkCount = 0;
            for (var i = srcEntityComponentStore->m_Archetypes.Count - 1; i >= 0; --i)
            {
                var srcArchetype = srcEntityComponentStore->m_Archetypes.p[i];
                chunkCount += srcArchetype->Chunks.Count;
            }

            var remapChunks = new NativeArray<RemapChunk>(chunkCount, Allocator.TempJob);
            var remapArchetypes =
                new NativeArray<RemapArchetype>(srcEntityComponentStore->m_Archetypes.Count, Allocator.TempJob);

            int chunkIndex = 0;
            int archetypeIndex = 0;
            for (var i = srcEntityComponentStore->m_Archetypes.Count - 1; i >= 0; --i)
            {
                var srcArchetype = srcEntityComponentStore->m_Archetypes.p[i];
                if (srcArchetype->Chunks.Count != 0)
                {
                    if (srcArchetype->NumManagedArrays != 0)
                        throw new ArgumentException("MoveEntitiesFrom is not supported with managed arrays");

                    var dstArchetype = EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(srcArchetype->Types,
                        srcArchetype->TypesCount, dstEntityComponentStore);

                    remapArchetypes[archetypeIndex] = new RemapArchetype
                        {srcArchetype = srcArchetype, dstArchetype = dstArchetype};

                    for (var j = 0; j < srcArchetype->Chunks.Count; ++j)
                    {
                        var srcChunk = srcArchetype->Chunks.p[j];
                        remapChunks[chunkIndex] = new RemapChunk {chunk = srcChunk, dstArchetype = dstArchetype};
                        chunkIndex++;
                    }

                    archetypeIndex++;

                    dstEntityComponentStore->IncrementComponentTypeOrderVersion(dstArchetype);
                }
            }

            moveChunksJob.Complete();

            k_ProfileMoveSharedComponents.Begin();
            var remapShared =
                dstManagedComponentStore.MoveAllSharedComponents(srcManagedComponentStore, Allocator.TempJob);
            k_ProfileMoveSharedComponents.End();

            var remapAllChunksJob = new RemapAllChunksJob
            {
                dstEntityComponentStore = dstEntityComponentStore,
                remapChunks = remapChunks,
                entityRemapping = entityRemapping
            }.Schedule(remapChunks.Length, 1);

            var remapArchetypesJob = new RemapArchetypesJob
            {
                remapArchetypes = remapArchetypes,
                remapShared = remapShared,
                dstEntityComponentStore = dstEntityComponentStore,
                chunkHeaderType = TypeManager.GetTypeIndex<ChunkHeader>()
            }.Schedule(archetypeIndex, 1, remapAllChunksJob);

            remapArchetypesJob.Complete();
            remapShared.Dispose();
            remapChunks.Dispose();
        }

        public static void MoveChunks(
            EntityComponentStore* srcEntityComponentStore,
            ManagedComponentStore srcManagedComponentStore,
            EntityComponentStore* dstEntityComponentStore,
            ManagedComponentStore dstManagedComponentStore)
        {
            var entityRemapping =
                new NativeArray<EntityRemapUtility.EntityRemapInfo>(srcEntityComponentStore->EntitiesCapacity,
                    Allocator.TempJob);

            MoveChunks(entityRemapping,
                srcEntityComponentStore, srcManagedComponentStore,
                dstEntityComponentStore, dstManagedComponentStore);

            entityRemapping.Dispose();
        }

        public static Chunk* CloneChunkForDiffing(Chunk* chunk,
            ManagedComponentStore srcManagedManager,
            EntityComponentStore* dstEntityComponentStore,
            ManagedComponentStore dstManagedComponentStore)
        {
            int* sharedIndices = stackalloc int[chunk->Archetype->NumSharedComponents];
            chunk->SharedComponentValues.CopyTo(sharedIndices, 0, chunk->Archetype->NumSharedComponents);

            dstManagedComponentStore.CopySharedComponents(srcManagedManager, sharedIndices,
                chunk->Archetype->NumSharedComponents);

            // Allocate a new chunk
            Archetype* arch = EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(chunk->Archetype->Types,
                chunk->Archetype->TypesCount, dstEntityComponentStore);

            Chunk* targetChunk = EntityManagerCreateDestroyEntitiesUtility.GetCleanChunk(arch, sharedIndices,
                dstEntityComponentStore, dstManagedComponentStore);

            // GetCleanChunk & CopySharedComponents both acquire a ref, once chunk owns, release CopySharedComponents ref
            for (int i = 0; i < chunk->Archetype->NumSharedComponents; ++i)
                dstManagedComponentStore.RemoveReference(sharedIndices[i]);

            UnityEngine.Assertions.Assert.AreEqual(0, targetChunk->Count);
            UnityEngine.Assertions.Assert.IsTrue(targetChunk->Capacity >= chunk->Count);

            int copySize = Chunk.GetChunkBufferSize();
            UnsafeUtility.MemCpy(targetChunk->Buffer, chunk->Buffer, copySize);

            EntityManagerCreateDestroyEntitiesUtility.SetChunkCount(targetChunk, chunk->Count,
                dstEntityComponentStore, dstManagedComponentStore);

            targetChunk->Archetype->EntityCount += chunk->Count;

            BufferHeader.PatchAfterCloningChunk(targetChunk);

            var tempEntities = new NativeArray<Entity>(targetChunk->Count, Allocator.Temp);

            dstEntityComponentStore->AllocateEntities(targetChunk->Archetype, targetChunk, 0, targetChunk->Count,
                (Entity*) tempEntities.GetUnsafePtr());

            tempEntities.Dispose();

            return targetChunk;
        }

        public static void DestroyChunkForDiffing(Chunk* chunk,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            chunk->Archetype->EntityCount -= chunk->Count;
            entityComponentStore->FreeEntities(chunk);

            EntityManagerCreateDestroyEntitiesUtility.SetChunkCount(chunk, 0,
                entityComponentStore, managedComponentStore);
        }


        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        struct RemapChunk
        {
            public Chunk* chunk;
            public Archetype* dstArchetype;
        }

        struct RemapArchetype
        {
            public Archetype* srcArchetype;
            public Archetype* dstArchetype;
        }

        [BurstCompile]
        struct MoveChunksJob : IJob
        {
            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* srcEntityComponentStore;
            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* dstEntityComponentStore;
            public NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping;
            [ReadOnly] public NativeArray<ArchetypeChunk> chunks;

            public void Execute()
            {
                int chunkCount = chunks.Length;
                for (int i = 0; i < chunkCount; ++i)
                {
                    var chunk = chunks[i].m_Chunk;
                    dstEntityComponentStore->AllocateEntitiesForRemapping(chunk, ref entityRemapping);
                    srcEntityComponentStore->FreeEntities(chunk);
                }
            }
        }

        [BurstCompile]
        struct RemapChunksJob : IJobParallelFor
        {
            [ReadOnly] public NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping;
            [ReadOnly] public NativeArray<RemapChunk> remapChunks;

            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* dstEntityComponentStore;

            public void Execute(int index)
            {
                Chunk* chunk = remapChunks[index].chunk;
                Archetype* dstArchetype = remapChunks[index].dstArchetype;

                dstEntityComponentStore->RemapChunk(dstArchetype, chunk, 0, chunk->Count, ref entityRemapping);
                EntityRemapUtility.PatchEntities(dstArchetype->ScalarEntityPatches + 1,
                    dstArchetype->ScalarEntityPatchCount - 1, dstArchetype->BufferEntityPatches,
                    dstArchetype->BufferEntityPatchCount, chunk->Buffer, chunk->Count, ref entityRemapping);
            }
        }

        [BurstCompile]
        struct MoveChunksBetweenArchetypeJob : IJob
        {
            [ReadOnly] public NativeArray<RemapChunk> remapChunks;
            [ReadOnly] public NativeArray<int> remapShared;
            public uint globalSystemVersion;

            public void Execute()
            {
                int chunkCount = remapChunks.Length;
                for (int iChunk = 0; iChunk < chunkCount; ++iChunk)
                {
                    var chunk = remapChunks[iChunk].chunk;
                    var dstArchetype = remapChunks[iChunk].dstArchetype;
                    var srcArchetype = chunk->Archetype;

                    int numSharedComponents = dstArchetype->NumSharedComponents;

                    var sharedComponentValues = chunk->SharedComponentValues;

                    if (numSharedComponents != 0)
                    {
                        var alloc = stackalloc int[numSharedComponents];
                        for (int i = 0; i < numSharedComponents; ++i)
                            alloc[i] = remapShared[sharedComponentValues[i]];
                        sharedComponentValues = alloc;
                    }

                    if (chunk->Count < chunk->Capacity)
                        srcArchetype->EmptySlotTrackingRemoveChunk(chunk);
                    srcArchetype->RemoveFromChunkList(chunk);
                    srcArchetype->EntityCount -= chunk->Count;

                    chunk->Archetype = dstArchetype;

                    dstArchetype->EntityCount += chunk->Count;
                    dstArchetype->AddToChunkList(chunk, sharedComponentValues, globalSystemVersion);
                    if (chunk->Count < chunk->Capacity)
                        dstArchetype->EmptySlotTrackingAddChunk(chunk);
                }
            }
        }

        [BurstCompile]
        struct RemapAllChunksJob : IJobParallelFor
        {
            [ReadOnly] public NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping;
            [ReadOnly] public NativeArray<RemapChunk> remapChunks;

            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* dstEntityComponentStore;

            public void Execute(int index)
            {
                Chunk* chunk = remapChunks[index].chunk;
                Archetype* dstArchetype = remapChunks[index].dstArchetype;

                dstEntityComponentStore->RemapChunk(dstArchetype, chunk, 0, chunk->Count, ref entityRemapping);
                EntityRemapUtility.PatchEntities(dstArchetype->ScalarEntityPatches + 1,
                    dstArchetype->ScalarEntityPatchCount - 1, dstArchetype->BufferEntityPatches,
                    dstArchetype->BufferEntityPatchCount, chunk->Buffer, chunk->Count, ref entityRemapping);
                chunk->Archetype = dstArchetype;
                chunk->ListIndex += dstArchetype->Chunks.Count;
                chunk->ListWithEmptySlotsIndex += dstArchetype->ChunksWithEmptySlots.Count;
            }
        }

        [BurstCompile]
        struct RemapArchetypesJob : IJobParallelFor
        {
            [DeallocateOnJobCompletion] [ReadOnly] public NativeArray<RemapArchetype> remapArchetypes;

            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* dstEntityComponentStore;

            [ReadOnly] public NativeArray<int> remapShared;

            public int chunkHeaderType;

            // This must be run after chunks have been remapped since FreeChunksBySharedComponents needs the shared component
            // indices in the chunks to be remapped
            public void Execute(int index)
            {
                var srcArchetype = remapArchetypes[index].srcArchetype;
                int srcChunkCount = srcArchetype->Chunks.Count;

                var dstArchetype = remapArchetypes[index].dstArchetype;
                int dstChunkCount = dstArchetype->Chunks.Count;

                if (dstArchetype->Chunks.Capacity < srcChunkCount + dstChunkCount)
                    dstArchetype->Chunks.Grow(srcChunkCount + dstChunkCount);

                UnsafeUtility.MemCpy(dstArchetype->Chunks.p + dstChunkCount, srcArchetype->Chunks.p,
                    sizeof(Chunk*) * srcChunkCount);

                if (srcArchetype->NumSharedComponents == 0)
                {
                    if (srcArchetype->ChunksWithEmptySlots.Count != 0)
                    {
                        dstArchetype->ChunksWithEmptySlotsUnsafePtrList.SetCapacity(
                            srcArchetype->ChunksWithEmptySlots.Count + dstArchetype->ChunksWithEmptySlots.Count);
                        dstArchetype->ChunksWithEmptySlotsUnsafePtrList.Append(
                            srcArchetype->ChunksWithEmptySlotsUnsafePtrList);
                        srcArchetype->ChunksWithEmptySlotsUnsafePtrList.Resize(0);
                    }
                }
                else
                {
                    for (int i = 0; i < dstArchetype->NumSharedComponents; ++i)
                    {
                        var srcArray = srcArchetype->Chunks.GetSharedComponentValueArrayForType(i);
                        var dstArray = dstArchetype->Chunks.GetSharedComponentValueArrayForType(i) + dstChunkCount;
                        for (int j = 0; j < srcChunkCount; ++j)
                        {
                            int srcIndex = srcArray[j];
                            int remapped = remapShared[srcIndex];
                            dstArray[j] = remapped;
                        }
                    }

                    for (int i = 0; i < srcChunkCount; ++i)
                    {
                        var chunk = dstArchetype->Chunks.p[i + dstChunkCount];
                        if (chunk->Count < chunk->Capacity)
                            dstArchetype->FreeChunksBySharedComponents.Add(dstArchetype->Chunks.p[i + dstChunkCount]);
                    }

                    srcArchetype->FreeChunksBySharedComponents.Init(16);
                }

                var globalSystemVersion = dstEntityComponentStore->GlobalSystemVersion;
                // Set change versions to GlobalSystemVersion
                for (int iType = 0; iType < dstArchetype->TypesCount; ++iType)
                {
                    var dstArray = dstArchetype->Chunks.GetChangeVersionArrayForType(iType) + dstChunkCount;
                    for (int i = 0; i < srcChunkCount; ++i)
                    {
                        dstArray[i] = globalSystemVersion;
                    }
                }

                // Copy chunk count array
                var dstCountArray = dstArchetype->Chunks.GetChunkEntityCountArray() + dstChunkCount;
                UnsafeUtility.MemCpy(dstCountArray, srcArchetype->Chunks.GetChunkEntityCountArray(),
                    sizeof(int) * srcChunkCount);

                // Fix up chunk pointers in ChunkHeaders
                if (dstArchetype->HasChunkComponents)
                {
                    var metaArchetype = dstArchetype->MetaChunkArchetype;
                    var indexInTypeArray = ChunkDataUtility.GetIndexInTypeArray(metaArchetype, chunkHeaderType);
                    var offset = metaArchetype->Offsets[indexInTypeArray];
                    var sizeOf = metaArchetype->SizeOfs[indexInTypeArray];

                    for (int i = 0; i < srcChunkCount; ++i)
                    {
                        // Set chunk header without bumping change versions since they are zeroed when processing meta chunk
                        // modifying them here would be a race condition
                        var chunk = dstArchetype->Chunks.p[i + dstChunkCount];
                        var metaChunkEntity = chunk->metaChunkEntity;
                        dstEntityComponentStore->GetChunk(metaChunkEntity, out var metaChunk, out var indexInMetaChunk);
                        var chunkHeader = (ChunkHeader*) (metaChunk->Buffer + (offset + sizeOf * indexInMetaChunk));
                        chunkHeader->ArchetypeChunk = new ArchetypeChunk(chunk, dstEntityComponentStore);
                    }
                }

                dstArchetype->EntityCount += srcArchetype->EntityCount;
                dstArchetype->Chunks.Count += srcChunkCount;
                srcArchetype->Chunks.Dispose();
                srcArchetype->EntityCount = 0;
            }
        }

        [BurstCompile]
        struct MoveAllChunksJob : IJob
        {
            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* srcEntityComponentStore;
            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* dstEntityComponentStore;
            public NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping;

            public void Execute()
            {
                dstEntityComponentStore->AllocateEntitiesForRemapping(srcEntityComponentStore, ref entityRemapping);
                srcEntityComponentStore->FreeAllEntities();
            }
        }
    }
}
