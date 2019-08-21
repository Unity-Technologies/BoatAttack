using System;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Entities
{
    /// <summary>
    /// Utilities which work on EntityManager data (for CreateDestroyEntities)
    /// Which require more than one of of these, in this order, as last parameters:
    ///     EntityComponentStore* entityComponentStore
    ///     SharedComponentDataManager sharedComponentDataManager
    /// </summary>
    internal static unsafe class EntityManagerCreateDestroyEntitiesUtility
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        public static void CreateMetaEntityForChunk(Chunk* chunk,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            CreateEntities(chunk->Archetype->MetaChunkArchetype, &chunk->metaChunkEntity, 1,
                entityComponentStore, managedComponentStore);
            
            var typeIndex = TypeManager.GetTypeIndex<ChunkHeader>();
            var chunkHeader =
                (ChunkHeader*) entityComponentStore->GetComponentDataWithTypeRW(chunk->metaChunkEntity, typeIndex,
                    entityComponentStore->GlobalSystemVersion);
            chunkHeader->ArchetypeChunk = new ArchetypeChunk(chunk, entityComponentStore);
        }

        public static void CreateEntities(Archetype* archetype, Entity* entities, int count,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var sharedComponentValues = stackalloc int[archetype->NumSharedComponents];
            UnsafeUtility.MemClear(sharedComponentValues, archetype->NumSharedComponents * sizeof(int));

            while (count != 0)
            {
                var chunk = GetChunkWithEmptySlots(archetype, sharedComponentValues,
                    entityComponentStore, managedComponentStore);
                
                int allocatedIndex;
                var allocatedCount = AllocateIntoChunk(chunk, count, out allocatedIndex,
                    entityComponentStore, managedComponentStore);
                entityComponentStore->AllocateEntities(archetype, chunk, allocatedIndex, allocatedCount, entities);
                ChunkDataUtility.InitializeComponents(chunk, allocatedIndex, allocatedCount);
                chunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);
                entities += allocatedCount;
                count -= allocatedCount;
            }

            entityComponentStore->IncrementComponentTypeOrderVersion(archetype);
        }
        
        public static void DestroyEntities(NativeArray<ArchetypeChunk> chunkArray,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            for (int i = 0; i != chunkArray.Length; i++)
            {
                var chunk = chunks[i].m_Chunk;
                DestroyBatch((Entity*) chunk->Buffer, chunk, 0, chunk->Count, 
                    entityComponentStore, managedComponentStore);
            }
        }

        public static void DestroyEntities(Entity* entities, int count,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var entityIndex = 0;

            var additionalDestroyList = new UnsafeList();
            int minDestroyStride = int.MaxValue;
            int maxDestroyStride = 0;

            while (entityIndex != count)
            {
                var entityBatchInChunk =
                    entityComponentStore->GetFirstEntityBatchInChunk(entities + entityIndex, count - entityIndex);
                var chunk = entityBatchInChunk.Chunk;
                var batchCount = entityBatchInChunk.Count;
                var indexInChunk = entityBatchInChunk.StartIndex;

                if (chunk == null)
                {
                    entityIndex += batchCount;
                    continue;
                }

                AddToDestroyList(chunk, indexInChunk, batchCount, count, ref additionalDestroyList,
                    ref minDestroyStride, ref maxDestroyStride);

                DestroyBatch(entities + entityIndex, chunk, indexInChunk, batchCount,
                    entityComponentStore, managedComponentStore);

                entityIndex += batchCount;
            }

            // Apply additional destroys from any LinkedEntityGroup
            if (additionalDestroyList.m_pointer != null)
            {
                var additionalDestroyPtr = (Entity*) additionalDestroyList.m_pointer;
                // Optimal for destruction speed is if entities with same archetype/chunk are followed one after another.
                // So we lay out the to be destroyed objects assuming that the destroyed entities are "similar":
                // Reorder destruction by index in entityGroupArray...

                //@TODO: This is a very specialized fastpath that is likely only going to give benefits in the stress test.
                ///      Figure out how to make this more general purpose.
                if (minDestroyStride == maxDestroyStride)
                {
                    var reordered = (Entity*) UnsafeUtility.Malloc(additionalDestroyList.m_size * sizeof(Entity), 16,
                        Allocator.TempJob);
                    int batchCount = additionalDestroyList.m_size / minDestroyStride;
                    for (int i = 0; i != batchCount; i++)
                    {
                        for (int j = 0; j != minDestroyStride; j++)
                            reordered[j * batchCount + i] = additionalDestroyPtr[i * minDestroyStride + j];
                    }

                    DestroyEntities(reordered, additionalDestroyList.m_size,
                        entityComponentStore, managedComponentStore);
                    UnsafeUtility.Free(reordered, Allocator.TempJob);
                }
                else
                {
                    DestroyEntities(additionalDestroyPtr, additionalDestroyList.m_size,
                        entityComponentStore, managedComponentStore);
                }

                UnsafeUtility.Free(additionalDestroyPtr, Allocator.TempJob);
            }
        }

        public static void DeleteChunk(Chunk* chunk,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var entityCount = chunk->Count;
            entityComponentStore->DeallocateDataEntitiesInChunk((Entity*) chunk->Buffer, chunk, 0, chunk->Count);
            managedComponentStore.IncrementComponentOrderVersion(chunk->Archetype, chunk->SharedComponentValues);
            entityComponentStore->IncrementComponentTypeOrderVersion(chunk->Archetype);
            chunk->Archetype->EntityCount -= entityCount;
            SetChunkCount(chunk, 0, entityComponentStore, managedComponentStore);
        }

        public static void DestroyMetaChunkEntity(Entity entity,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            EntityManagerChangeArchetypeUtility.RemoveComponent(entity, ComponentType.ReadWrite<ChunkHeader>(),
                entityComponentStore, managedComponentStore);
            DestroyEntities(&entity, 1, entityComponentStore, managedComponentStore);
        }

        public static void SetChunkCount(Chunk* chunk, int newCount,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            Assert.AreNotEqual(newCount, chunk->Count);
            Assert.IsFalse(chunk->Locked);
            Assert.IsTrue(!chunk->LockedEntityOrder || newCount == 0);

            // Chunk released to empty chunk pool
            if (newCount == 0)
            {
                ReleaseChunk(chunk, entityComponentStore, managedComponentStore);
                return;
            }

            var capacity = chunk->Capacity;

            // Chunk is now full
            if (newCount == capacity)
            {
                // this chunk no longer has empty slots, so it shouldn't be in the empty slot list.
                chunk->Archetype->EmptySlotTrackingRemoveChunk(chunk);
            }
            // Chunk is no longer full
            else if (chunk->Count == capacity)
            {
                Assert.IsTrue(newCount < chunk->Count);
                chunk->Archetype->EmptySlotTrackingAddChunk(chunk);
            }

            chunk->Count = newCount;
            chunk->Archetype->Chunks.SetChunkEntityCount(chunk->ListIndex, newCount);
        }
        
        public static void CreateChunks(Archetype* archetype, ArchetypeChunk* chunks, int entityCount,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            int* sharedComponentValues = stackalloc int[archetype->NumSharedComponents];
            UnsafeUtility.MemClear(sharedComponentValues, archetype->NumSharedComponents * sizeof(int));

            Chunk* lastChunk = null;
            int chunkIndex = 0;
            while (entityCount != 0)
            {
                var chunk = GetCleanChunk(archetype, sharedComponentValues,
                    entityComponentStore, managedComponentStore);
                int allocatedIndex;
                
                var allocatedCount = AllocateIntoChunk(chunk, entityCount, out allocatedIndex,
                    entityComponentStore, managedComponentStore);
                
                entityComponentStore->AllocateEntities(archetype, chunk, allocatedIndex, allocatedCount, null);
                ChunkDataUtility.InitializeComponents(chunk, allocatedIndex, allocatedCount);
                chunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);
                chunks[chunkIndex] = new ArchetypeChunk(chunk, entityComponentStore);
                lastChunk = chunk;

                entityCount -= allocatedCount;
                chunkIndex++;
            }

            entityComponentStore->IncrementComponentTypeOrderVersion(archetype);
        }
        
        public static Chunk* GetChunkWithEmptySlots(Archetype* archetype, SharedComponentValues sharedComponentValues,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var chunk = archetype->GetExistingChunkWithEmptySlots(sharedComponentValues);
            if (chunk == null)
            {
                chunk = GetCleanChunk(archetype, sharedComponentValues,
                    entityComponentStore, managedComponentStore);
            }

            return chunk;
        }
        
        public static Chunk* GetCleanChunk(Archetype* archetype, SharedComponentValues sharedComponentValues,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            Chunk* newChunk = entityComponentStore->AllocateChunk();
            
            ConstructChunk(archetype, newChunk, sharedComponentValues,
                entityComponentStore, managedComponentStore);

            return newChunk;
        }
  
        public static void InstantiateEntities(Entity srcEntity, Entity* outputEntities, int instanceCount,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var linkedType = TypeManager.GetTypeIndex<LinkedEntityGroup>();

            if (entityComponentStore->HasComponent(srcEntity, linkedType))
            {
                var header = (BufferHeader*) entityComponentStore->GetComponentDataWithTypeRO(srcEntity, linkedType);
                var entityPtr = (Entity*) BufferHeader.GetElementPointer(header);
                var entityCount = header->Length;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (entityCount == 0 || entityPtr[0] != srcEntity)
                    throw new ArgumentException("LinkedEntityGroup[0] must always be the Entity itself.");
                for (int i = 0; i < entityCount; i++)
                {
                    if (!entityComponentStore->Exists(entityPtr[i]))
                        throw new ArgumentException(
                            "The srcEntity's LinkedEntityGroup references an entity that is invalid. (Entity at index {i} on the LinkedEntityGroup.)");

                    var archetype = entityComponentStore->GetArchetype(entityPtr[i]);
                    if (archetype->InstantiableArchetype == null)
                        throw new ArgumentException(
                            "The srcEntity's LinkedEntityGroup references an entity that has already been destroyed. (Entity at index {i} on the LinkedEntityGroup. Only system state components are left on the entity)");
                }
#endif
                InstantiateEntitiesGroup(entityPtr, entityCount, outputEntities, instanceCount,
                    entityComponentStore, managedComponentStore);
            }
            else
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (!entityComponentStore->Exists(srcEntity))
                    throw new ArgumentException("srcEntity is not a valid entity");

                var srcArchetype = entityComponentStore->GetArchetype(srcEntity);
                if (srcArchetype->InstantiableArchetype == null)
                    throw new ArgumentException(
                        "srcEntity is not instantiable because it has already been destroyed. (Only system state components are left on it)");
#endif
                InstantiateEntitiesOne(srcEntity, outputEntities, instanceCount, null, 0,
                    entityComponentStore, managedComponentStore);
            }
        }
        
        public static int AllocateIntoChunk(Chunk* chunk,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            int outIndex;
            var res = AllocateIntoChunk(chunk, 1, out outIndex,
                entityComponentStore, managedComponentStore);
            Assert.AreEqual(1, res);
            return outIndex;
        }

        public static int AllocateIntoChunk(Chunk* chunk, int count, out int outIndex,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var allocatedCount = Math.Min(chunk->Capacity - chunk->Count, count);
            outIndex = chunk->Count;
            SetChunkCount(chunk, chunk->Count + allocatedCount,
                entityComponentStore, managedComponentStore);
            chunk->Archetype->EntityCount += allocatedCount;
            return allocatedCount;
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        struct InstantiateRemapChunk
        {
            public Chunk* Chunk;
            public int IndexInChunk;
            public int AllocatedCount;
            public int InstanceBeginIndex;
        }
        
        static void AddToDestroyList(Chunk* chunk, int indexInChunk, int batchCount, int inputDestroyCount,
            ref UnsafeList entitiesList, ref int minBufferLength, ref int maxBufferLength)
        {
            var linkedGroupType = TypeManager.GetTypeIndex<LinkedEntityGroup>();
            int indexInArchetype = ChunkDataUtility.GetIndexInTypeArray(chunk->Archetype, linkedGroupType);
            if (indexInArchetype != -1)
            {
                var baseHeader = ChunkDataUtility.GetComponentDataWithTypeRO(chunk, indexInChunk, linkedGroupType);
                var stride = chunk->Archetype->SizeOfs[indexInArchetype];
                for (int i = 0; i != batchCount; i++)
                {
                    var header = (BufferHeader*) (baseHeader + stride * i);

                    var entityGroupCount = header->Length - 1;
                    if (entityGroupCount == 0)
                        continue;

                    var entityGroupArray = (Entity*) BufferHeader.GetElementPointer(header) + 1;

                    if (entitiesList.m_capacity == 0)
                        entitiesList.SetCapacity<Entity>(inputDestroyCount * entityGroupCount, Allocator.TempJob);
                    entitiesList.AddRange<Entity>(entityGroupArray, entityGroupCount, Allocator.TempJob);

                    minBufferLength = math.min(minBufferLength, entityGroupCount);
                    maxBufferLength = math.max(maxBufferLength, entityGroupCount);
                }
            }
        }

        static void DestroyBatch(Entity* entities, Chunk* chunk, int indexInChunk, int batchCount,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var archetype = chunk->Archetype;
            if (!archetype->SystemStateCleanupNeeded)
            {
                entityComponentStore->DeallocateDataEntitiesInChunk(entities, chunk, indexInChunk, batchCount);
                managedComponentStore.IncrementComponentOrderVersion(archetype, chunk->SharedComponentValues);
                entityComponentStore->IncrementComponentTypeOrderVersion(archetype);

                if (chunk->ManagedArrayIndex >= 0)
                {
                    // We can just chop-off the end, no need to copy anything
                    if (chunk->Count != indexInChunk + batchCount)
                        managedComponentStore.CopyManagedObjects(chunk, chunk->Count - batchCount, chunk,
                            indexInChunk, batchCount);

                    managedComponentStore.ClearManagedObjects(chunk, chunk->Count - batchCount,
                        batchCount);
                }

                chunk->Archetype->EntityCount -= batchCount;
                SetChunkCount(chunk, chunk->Count - batchCount, entityComponentStore, managedComponentStore);
            }
            else
            {
                var newType = archetype->SystemStateResidueArchetype;

                var sharedComponentValues = chunk->SharedComponentValues;

                if (RequiresBuildingResidueSharedComponentIndices(archetype, newType))
                {
                    var tempAlloc = stackalloc int[newType->NumSharedComponents];
                    BuildResidueSharedComponentIndices(archetype, newType, sharedComponentValues, tempAlloc);
                    sharedComponentValues = tempAlloc;
                }

                // See: https://github.com/Unity-Technologies/dots/issues/1387
                // For Locked Order Chunks specfically, need to make sure that structural changes are always done per-chunk.
                // If trying to muutate structure in a way that is not per chunk, will hit an exception in the else clause anyway.
                // This ultimately needs to be replaced by entity batch interface.

                if (batchCount == chunk->Count)
                {
                    managedComponentStore.IncrementComponentOrderVersion(archetype, chunk->SharedComponentValues);
                    entityComponentStore->IncrementComponentTypeOrderVersion(archetype);

                    EntityManagerChangeArchetypeUtility.SetArchetype(chunk, newType, sharedComponentValues,
                        entityComponentStore, managedComponentStore);
                }
                else
                {
                    for (var i = 0; i < batchCount; i++)
                    {
                        var entity = entities[i];
                        managedComponentStore.IncrementComponentOrderVersion(archetype,
                            entityComponentStore->GetChunk(entity)->SharedComponentValues);
                        entityComponentStore->IncrementComponentTypeOrderVersion(archetype);
                        EntityManagerChangeArchetypeUtility.SetArchetype(entity, newType, sharedComponentValues,
                            entityComponentStore, managedComponentStore);
                    }
                }
            }
        }

        static bool RequiresBuildingResidueSharedComponentIndices(Archetype* srcArchetype,
            Archetype* dstArchetype)
        {
            return dstArchetype->NumSharedComponents > 0 &&
                   dstArchetype->NumSharedComponents != srcArchetype->NumSharedComponents;
        }

        static void BuildResidueSharedComponentIndices(Archetype* srcArchetype, Archetype* dstArchetype,
            SharedComponentValues srcSharedComponentValues, int* dstSharedComponentValues)
        {
            int oldFirstShared = srcArchetype->FirstSharedComponent;
            int newFirstShared = dstArchetype->FirstSharedComponent;
            int newCount = dstArchetype->NumSharedComponents;

            for (int oldIndex = 0, newIndex = 0; newIndex < newCount; ++newIndex, ++oldIndex)
            {
                var t = dstArchetype->Types[newIndex + newFirstShared];
                while (t != srcArchetype->Types[oldIndex + oldFirstShared])
                    ++oldIndex;
                dstSharedComponentValues[newIndex] = srcSharedComponentValues[oldIndex];
            }
        }

        static void ReleaseChunk(Chunk* chunk,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            // Remove references to shared components
            if (chunk->Archetype->NumSharedComponents > 0)
            {
                var sharedComponentValueArray = chunk->SharedComponentValues;

                for (var i = 0; i < chunk->Archetype->NumSharedComponents; ++i)
                    managedComponentStore.RemoveReference(sharedComponentValueArray[i]);
            }

            if (chunk->ManagedArrayIndex != -1)
            {
                managedComponentStore.DeallocateManagedArrayStorage(chunk->ManagedArrayIndex);
                chunk->ManagedArrayIndex = -1;
            }

            if (chunk->metaChunkEntity != Entity.Null)
                DestroyMetaChunkEntity(chunk->metaChunkEntity,
                    entityComponentStore, managedComponentStore);

            // this chunk is going away, so it shouldn't be in the empty slot list.
            if (chunk->Count < chunk->Capacity)
                chunk->Archetype->EmptySlotTrackingRemoveChunk(chunk);

            chunk->Archetype->RemoveFromChunkList(chunk);
            chunk->Archetype = null;

            entityComponentStore->FreeChunk(chunk);
        }
        
        static int InstantiateEntitiesOne(Entity srcEntity, Entity* outputEntities,
            int instanceCount, InstantiateRemapChunk* remapChunks, int remapChunksCount,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var src = entityComponentStore->GetEntityInChunk(srcEntity);
            var srcArchetype = src.Chunk->Archetype;
            var dstArchetype = srcArchetype->InstantiableArchetype;

            var temp = stackalloc int[dstArchetype->NumSharedComponents];
            if (RequiresBuildingResidueSharedComponentIndices(srcArchetype, dstArchetype))
            {
                BuildResidueSharedComponentIndices(srcArchetype, dstArchetype,
                    src.Chunk->SharedComponentValues, temp);
            }
            else
            {
                // Always copy shared component indices since GetChunkWithEmptySlots might reallocate the storage of SharedComponentValues
                src.Chunk->SharedComponentValues.CopyTo(temp, 0, dstArchetype->NumSharedComponents);
            }

            SharedComponentValues sharedComponentValues = temp;

            Chunk* chunk = null;

            int instanceBeginIndex = 0;
            while (instanceBeginIndex != instanceCount)
            {
                chunk = GetChunkWithEmptySlots(dstArchetype, sharedComponentValues,
                    entityComponentStore, managedComponentStore);
                
                int indexInChunk;
                var allocatedCount = AllocateIntoChunk(chunk, instanceCount - instanceBeginIndex, out indexInChunk,
                    entityComponentStore, managedComponentStore);
                
                ChunkDataUtility.ReplicateComponents(src.Chunk, src.IndexInChunk, chunk, indexInChunk, allocatedCount);
                entityComponentStore->AllocateEntities(dstArchetype, chunk, indexInChunk, allocatedCount,
                    outputEntities + instanceBeginIndex);
                chunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);

#if UNITY_EDITOR
                for (var i = 0; i < allocatedCount; ++i)
                    entityComponentStore->SetName(outputEntities[i + instanceBeginIndex], entityComponentStore->GetName(srcEntity));
#endif

                if (remapChunks != null)
                {
                    remapChunks[remapChunksCount].Chunk = chunk;
                    remapChunks[remapChunksCount].IndexInChunk = indexInChunk;
                    remapChunks[remapChunksCount].AllocatedCount = allocatedCount;
                    remapChunks[remapChunksCount].InstanceBeginIndex = instanceBeginIndex;
                    remapChunksCount++;
                }


                instanceBeginIndex += allocatedCount;
            }

            if (chunk != null)
            {
                managedComponentStore.IncrementComponentOrderVersion(dstArchetype, chunk->SharedComponentValues);
                entityComponentStore->IncrementComponentTypeOrderVersion(dstArchetype);
            }

            return remapChunksCount;
        }

        static void InstantiateEntitiesGroup(Entity* srcEntities, int srcEntityCount,
            Entity* outputRootEntities, int instanceCount,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            int totalCount = srcEntityCount * instanceCount;

            var tempAllocSize = sizeof(EntityRemapUtility.SparseEntityRemapInfo) * totalCount +
                                sizeof(InstantiateRemapChunk) * totalCount + sizeof(Entity) * instanceCount;
            byte* allocation;
            const int kMaxStackAllocSize = 16 * 1024;

            if (tempAllocSize > kMaxStackAllocSize)
            {
                allocation = (byte*) UnsafeUtility.Malloc(tempAllocSize, 16, Allocator.Temp);
            }
            else
            {
                var temp = stackalloc byte[tempAllocSize];
                allocation = temp;
            }

            var entityRemap = (EntityRemapUtility.SparseEntityRemapInfo*) allocation;
            var remapChunks = (InstantiateRemapChunk*) (entityRemap + totalCount);
            var outputEntities = (Entity*) (remapChunks + totalCount);

            var remapChunksCount = 0;

            for (int i = 0; i != srcEntityCount; i++)
            {
                var srcEntity = srcEntities[i];
                
                remapChunksCount = InstantiateEntitiesOne(srcEntity,
                    outputEntities, instanceCount, remapChunks, remapChunksCount,
                    entityComponentStore, managedComponentStore);

                for (int r = 0; r != instanceCount; r++)
                {
                    var ptr = entityRemap + (r * srcEntityCount + i);
                    ptr->Src = srcEntity;
                    ptr->Target = outputEntities[r];
                }

                if (i == 0)
                {
                    for (int r = 0; r != instanceCount; r++)
                        outputRootEntities[r] = outputEntities[r];
                }
            }

            for (int i = 0; i != remapChunksCount; i++)
            {
                var chunk = remapChunks[i].Chunk;
                var dstArchetype = chunk->Archetype;
                var allocatedCount = remapChunks[i].AllocatedCount;
                var indexInChunk = remapChunks[i].IndexInChunk;
                var instanceBeginIndex = remapChunks[i].InstanceBeginIndex;

                var localRemap = entityRemap + instanceBeginIndex * srcEntityCount;
             
                EntityRemapUtility.PatchEntitiesForPrefab(dstArchetype->ScalarEntityPatches + 1,
                    dstArchetype->ScalarEntityPatchCount - 1, dstArchetype->BufferEntityPatches,
                    dstArchetype->BufferEntityPatchCount, chunk->Buffer, indexInChunk, allocatedCount, localRemap,
                    srcEntityCount);
            }

            if (tempAllocSize > kMaxStackAllocSize)
                UnsafeUtility.Free(allocation, Allocator.Temp);
        }
        
        static void ConstructChunk(Archetype* archetype, Chunk* chunk,
            SharedComponentValues sharedComponentValues,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            chunk->Archetype = archetype;
            chunk->Count = 0;
            chunk->Capacity = archetype->ChunkCapacity;
            chunk->SequenceNumber = entityComponentStore->AssignSequenceNumber(chunk);
            chunk->metaChunkEntity = Entity.Null;

            var numSharedComponents = archetype->NumSharedComponents;

            if (numSharedComponents > 0)
            {
                for (var i = 0; i < archetype->NumSharedComponents; ++i)
                {
                    var sharedComponentIndex = sharedComponentValues[i];
                    managedComponentStore.AddReference(sharedComponentIndex);
                }
            }

            archetype->AddToChunkList(chunk, sharedComponentValues, entityComponentStore->GlobalSystemVersion);

            Assert.IsTrue(archetype->Chunks.Count != 0);

            // Chunk can't be locked at at construction time
            archetype->EmptySlotTrackingAddChunk(chunk);

            if (numSharedComponents == 0)
            {
                Assert.IsTrue(archetype->ChunksWithEmptySlots.Count != 0);
            }
            else
            {
                Assert.IsTrue(archetype->FreeChunksBySharedComponents.TryGet(chunk->SharedComponentValues,
                                  archetype->NumSharedComponents) != null);
            }

            if (archetype->NumManagedArrays > 0)
                chunk->ManagedArrayIndex =
                    managedComponentStore.AllocateManagedArrayStorage(archetype->NumManagedArrays * chunk->Capacity);
            else
                chunk->ManagedArrayIndex = -1;

            chunk->Flags = 0;

            if (archetype->MetaChunkArchetype != null)
            {
                CreateMetaEntityForChunk(chunk, entityComponentStore, managedComponentStore);
            }
        }
    }
}
