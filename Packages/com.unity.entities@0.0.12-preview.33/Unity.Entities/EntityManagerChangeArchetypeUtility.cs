using System;
using System.Diagnostics;
using Unity.Assertions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Profiling;

namespace Unity.Entities
{
    /// <summary>
    /// Utilities which work on EntityManager data (for ChangeArchetype)
    /// Which require more than one of of these, in this order, as last parameters:
    ///     EntityComponentStore* entityComponentStore
    ///     SharedComponentDataManager sharedComponentDataManager
    /// </summary>
    internal static unsafe class EntityManagerChangeArchetypeUtility
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        public static void AddComponent(Entity entity, ComponentType type,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var archetype = entityComponentStore->GetArchetype(entity);
            int indexInTypeArray = 0;
            var newType =
                EntityManagerCreateArchetypeUtility.GetArchetypeWithAddedComponentType(archetype, type,
                    entityComponentStore, &indexInTypeArray);
            if (newType == null)
            {
                // This can happen if we are adding a tag component to an entity that already has it.
                return;
            }

            var sharedComponentValues = entityComponentStore->GetChunk(entity)->SharedComponentValues;
            if (type.IsSharedComponent)
            {
                int* temp = stackalloc int[newType->NumSharedComponents];
                int indexOfNewSharedComponent = indexInTypeArray - newType->FirstSharedComponent;
                BuildSharedComponentIndicesWithAddedComponent(indexOfNewSharedComponent, 0,
                    newType->NumSharedComponents, sharedComponentValues, temp);
                sharedComponentValues = temp;
            }

            SetArchetype(entity, newType, sharedComponentValues,
                entityComponentStore, managedComponentStore);
        }

        public static void AddSharedComponent(NativeArray<ArchetypeChunk> chunkArray, ComponentType componentType,
            int sharedComponentIndex,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {            
            Assert.IsTrue(componentType.IsSharedComponent);
            
            for (int i = 0; i < chunkArray.Length; i++)
            {
                var chunk = chunkArray[i];
                var archetype = chunk.Archetype.Archetype;
                int indexInTypeArray = 0;
                var newType = EntityManagerCreateArchetypeUtility.GetArchetypeWithAddedComponentType(archetype, componentType, entityComponentStore, &indexInTypeArray);
                if (newType == null)
                {
                    // This can happen if we are adding a tag component to an entity that already has it.
                    Assert.AreEqual(0, sharedComponentIndex);
                    continue;
                }
                
                var sharedComponentValues = chunk.m_Chunk->SharedComponentValues;

                int* temp = stackalloc int[newType->NumSharedComponents];
                int indexOfNewSharedComponent = indexInTypeArray - newType->FirstSharedComponent;
                BuildSharedComponentIndicesWithAddedComponent(indexOfNewSharedComponent, sharedComponentIndex, newType->NumSharedComponents, sharedComponentValues, temp);
                sharedComponentValues = temp;

                MoveChunkToNewArchetype(chunk.m_Chunk, newType, sharedComponentValues, entityComponentStore, managedComponentStore);
            }
            
            managedComponentStore.AddReference(sharedComponentIndex, chunkArray.Length);
        }

        public static void SetArchetype(Entity entity, Archetype* archetype,
            SharedComponentValues sharedComponentValues,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var oldArchetype = entityComponentStore->GetArchetype(entity);
            var oldEntityInChunk = entityComponentStore->GetEntityInChunk(entity);
            var oldChunk = oldEntityInChunk.Chunk;
            var oldChunkIndex = oldEntityInChunk.IndexInChunk;
            if (oldArchetype == archetype)
                return;

            var chunk = EntityManagerCreateDestroyEntitiesUtility.GetChunkWithEmptySlots(archetype,
                sharedComponentValues,
                entityComponentStore, managedComponentStore);
            var chunkIndex = EntityManagerCreateDestroyEntitiesUtility.AllocateIntoChunk(chunk,
                entityComponentStore, managedComponentStore);

            ChunkDataUtility.Convert(oldChunk, oldChunkIndex, chunk, chunkIndex);
            if (chunk->ManagedArrayIndex >= 0 && oldChunk->ManagedArrayIndex >= 0)
                managedComponentStore.CopyManagedObjects(oldChunk, oldChunkIndex, chunk, chunkIndex, 1);

            entityComponentStore->SetArchetype(entity, archetype);
            entityComponentStore->SetEntityInChunk(entity,
                new EntityInChunk {Chunk = chunk, IndexInChunk = chunkIndex});

            var lastIndex = oldChunk->Count - 1;
            // No need to replace with ourselves
            if (lastIndex != oldChunkIndex)
            {
                var lastEntity = *(Entity*) ChunkDataUtility.GetComponentDataRO(oldChunk, lastIndex, 0);
                var lastEntityInChunk = new EntityInChunk
                {
                    Chunk = oldChunk,
                    IndexInChunk = oldChunkIndex
                };
                entityComponentStore->SetEntityInChunk(lastEntity, lastEntityInChunk);

                ChunkDataUtility.Copy(oldChunk, lastIndex, oldChunk, oldChunkIndex, 1);
                if (oldChunk->ManagedArrayIndex >= 0)
                    managedComponentStore.CopyManagedObjects(oldChunk, lastIndex, oldChunk, oldChunkIndex,
                        1);
            }

            if (oldChunk->ManagedArrayIndex >= 0)
                managedComponentStore.ClearManagedObjects(oldChunk, lastIndex, 1);

            --oldArchetype->EntityCount;

            chunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);
            oldChunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);

            managedComponentStore.IncrementComponentOrderVersion(oldArchetype, oldChunk->SharedComponentValues);
            entityComponentStore->IncrementComponentTypeOrderVersion(oldArchetype);

            EntityManagerCreateDestroyEntitiesUtility.SetChunkCount(oldChunk, lastIndex, entityComponentStore,
                managedComponentStore);

            managedComponentStore.IncrementComponentOrderVersion(archetype, chunk->SharedComponentValues);
            entityComponentStore->IncrementComponentTypeOrderVersion(archetype);
        }

        public static void SetArchetype(Chunk* chunk, Archetype* archetype,
            SharedComponentValues sharedComponentValues,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var srcChunk = chunk;
            var srcArchetype = srcChunk->Archetype;
            if (srcArchetype == archetype)
                return;

            var srcEntities = (Entity*) srcChunk->Buffer;
            var srcEntitiesCount = srcChunk->Count;
            var srcRemainingCount = srcEntitiesCount;
            var srcOffset = 0;

            var dstArchetype = archetype;

            while (srcRemainingCount > 0)
            {
                var dstChunk = EntityManagerCreateDestroyEntitiesUtility.GetChunkWithEmptySlots(archetype,
                    sharedComponentValues,
                    entityComponentStore, managedComponentStore);
                int dstIndexBase;
                var dstCount = EntityManagerCreateDestroyEntitiesUtility.AllocateIntoChunk(dstChunk, srcRemainingCount,
                    out dstIndexBase,
                    entityComponentStore, managedComponentStore);

                ChunkDataUtility.Convert(srcChunk, srcOffset, dstChunk, dstIndexBase, dstCount);

                managedComponentStore.IncrementComponentOrderVersion(archetype, dstChunk->SharedComponentValues);
                entityComponentStore->IncrementComponentTypeOrderVersion(archetype);

                for (int i = 0; i < dstCount; i++)
                {
                    var entity = srcEntities[srcOffset + i];

                    entityComponentStore->SetArchetype(entity, dstArchetype);
                    entityComponentStore->SetEntityInChunk(entity,
                        new EntityInChunk {Chunk = dstChunk, IndexInChunk = dstIndexBase + i});
                }

                if (srcChunk->ManagedArrayIndex >= 0 && dstChunk->ManagedArrayIndex >= 0)
                    managedComponentStore.CopyManagedObjects(srcChunk, srcOffset, dstChunk, dstIndexBase,
                        dstCount);

                srcRemainingCount -= dstCount;
                srcOffset += dstCount;
            }

            srcArchetype->EntityCount -= srcEntitiesCount;

            if (srcChunk->ManagedArrayIndex >= 0)
                managedComponentStore.ClearManagedObjects(srcChunk, 0, srcEntitiesCount);
            EntityManagerCreateDestroyEntitiesUtility.SetChunkCount(srcChunk, 0, entityComponentStore,
                managedComponentStore);
        }

        public static void AddComponentFromMainThread(NativeList<EntityBatchInChunk> entityBatchList, ComponentType type,
            int existingSharedComponentIndex,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            using (var sourceBlittableEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var destinationBlittableEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var sourceManagedEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var destinationManagedEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var packBlittableEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var packManagedEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var sourceCountEntityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            using (var moveChunkList = new NativeList<EntityBatchInChunk>(Allocator.Persistent))
            {
                AllocateChunksForAddComponent(entityBatchList, type, existingSharedComponentIndex,
                    sourceCountEntityBatchList, packBlittableEntityBatchList, packManagedEntityBatchList,
                    sourceBlittableEntityBatchList, destinationBlittableEntityBatchList, sourceManagedEntityBatchList,
                    destinationManagedEntityBatchList, moveChunkList,
                    entityComponentStore,
                    managedComponentStore);

                var copyBlittableChunkDataJobHandle = CopyBlittableChunkDataJob(sourceBlittableEntityBatchList,
                    destinationBlittableEntityBatchList, entityComponentStore);
                var packBlittableChunkDataJobHandle =
                    PackBlittableChunkDataJob(packBlittableEntityBatchList, entityComponentStore,
                        copyBlittableChunkDataJobHandle);
                packBlittableChunkDataJobHandle.Complete();

                CopyManagedChunkData(sourceManagedEntityBatchList, destinationManagedEntityBatchList,
                    managedComponentStore);
                PackManagedChunkData(packManagedEntityBatchList, managedComponentStore);

                UpdateDestinationVersions(destinationBlittableEntityBatchList, entityComponentStore,
                    managedComponentStore);
                UpdateSourceCountsAndVersions(sourceCountEntityBatchList, entityComponentStore,
                    managedComponentStore);
                MoveChunksForAddComponent(moveChunkList, type, existingSharedComponentIndex, entityComponentStore,
                    managedComponentStore);
            }
        }

        public static void AddComponents(Entity entity, ComponentTypes types,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var oldArchetype = entityComponentStore->GetArchetype(entity);
            var oldTypes = oldArchetype->Types;

            var newTypesCount = oldArchetype->TypesCount + types.Length;
            ComponentTypeInArchetype* newTypes = stackalloc ComponentTypeInArchetype[newTypesCount];

            var indexOfNewTypeInNewArchetype = stackalloc int[types.Length];

            // zipper the two sorted arrays "type" and "componentTypeInArchetype" into "componentTypeInArchetype"
            // because this is done in-place, it must be done backwards so as not to disturb the existing contents.

            var unusedIndices = 0;
            {
                var oldThings = oldArchetype->TypesCount;
                var newThings = types.Length;
                var mixedThings = oldThings + newThings;
                while (oldThings > 0 && newThings > 0) // while both are still zippering,
                {
                    var oldThing = oldTypes[oldThings - 1];
                    var newThing = types.GetComponentType(newThings - 1);
                    if (oldThing.TypeIndex > newThing.TypeIndex) // put whichever is bigger at the end of the array
                    {
                        newTypes[--mixedThings] = oldThing;
                        --oldThings;
                    }
                    else
                    {
                        if (oldThing.TypeIndex == newThing.TypeIndex && newThing.IgnoreDuplicateAdd)
                            --oldThings;

                        var componentTypeInArchetype = new ComponentTypeInArchetype(newThing);
                        newTypes[--mixedThings] = componentTypeInArchetype;
                        --newThings;
                        indexOfNewTypeInNewArchetype[newThings] = mixedThings; // "this new thing ended up HERE"
                    }
                }

                Assert.AreEqual(0, newThings); // must not be any new things to copy remaining, oldThings contain entity

                while (oldThings > 0) // if there are remaining old things, copy them here
                {
                    newTypes[--mixedThings] = oldTypes[--oldThings];
                }

                unusedIndices = mixedThings; // In case we ignored duplicated types, this will be > 0
            }

            var newArchetype =
                EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(newTypes + unusedIndices, newTypesCount,
                    entityComponentStore);

            var sharedComponentValues = entityComponentStore->GetChunk(entity)->SharedComponentValues;
            if (types.m_masks.m_SharedComponentMask != 0)
            {
                int* alloc2 = stackalloc int[newArchetype->NumSharedComponents];
                var oldSharedComponentValues = sharedComponentValues;
                sharedComponentValues = alloc2;
                BuildSharedComponentIndicesWithAddedComponents(oldArchetype, newArchetype,
                    oldSharedComponentValues, alloc2);
            }

            SetArchetype(entity, newArchetype, sharedComponentValues, entityComponentStore,
                managedComponentStore);
        }

        public static void RemoveComponent(NativeArray<ArchetypeChunk> chunkArray, ComponentType type,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            if (type.IsZeroSized)
            {
                Archetype* prevOldArchetype = null;
                Archetype* newArchetype = null;
                int indexInOldTypeArray = 0;
                for (int i = 0; i < chunkArray.Length; ++i)
                {
                    var chunk = chunks[i].m_Chunk;
                    var oldArchetype = chunk->Archetype;
                    if (oldArchetype != prevOldArchetype)
                    {
                        if (ChunkDataUtility.GetIndexInTypeArray(oldArchetype, type.TypeIndex) != -1)
                            newArchetype = EntityManagerCreateArchetypeUtility.GetArchetypeWithRemovedComponentType(
                                oldArchetype, type,
                                entityComponentStore, &indexInOldTypeArray);
                        else
                            newArchetype = null;
                        prevOldArchetype = oldArchetype;
                    }

                    if (newArchetype == null)
                        continue;

                    if (newArchetype->SystemStateCleanupComplete)
                    {
                        EntityManagerCreateDestroyEntitiesUtility.DeleteChunk(chunk,
                            entityComponentStore, managedComponentStore);
                        continue;
                    }

                    var sharedComponentValues = chunk->SharedComponentValues;
                    if (type.IsSharedComponent)
                    {
                        int* temp = stackalloc int[newArchetype->NumSharedComponents];
                        int indexOfRemovedSharedComponent = indexInOldTypeArray - oldArchetype->FirstSharedComponent;
                        var sharedComponentDataIndex = chunk->GetSharedComponentValue(indexOfRemovedSharedComponent);
                        managedComponentStore.RemoveReference(sharedComponentDataIndex);
                        BuildSharedComponentIndicesWithRemovedComponent(indexOfRemovedSharedComponent,
                            newArchetype->NumSharedComponents, sharedComponentValues, temp);
                        sharedComponentValues = temp;
                    }

                    MoveChunkToNewArchetype(chunk, newArchetype, sharedComponentValues,
                        entityComponentStore, managedComponentStore);
                }
            }
            else
            {
                Archetype* prevOldArchetype = null;
                Archetype* newArchetype = null;
                for (int i = 0; i < chunkArray.Length; ++i)
                {
                    var chunk = chunks[i].m_Chunk;
                    var oldArchetype = chunk->Archetype;
                    if (oldArchetype != prevOldArchetype)
                    {
                        if (ChunkDataUtility.GetIndexInTypeArray(oldArchetype, type.TypeIndex) != -1)
                            newArchetype =
                                EntityManagerCreateArchetypeUtility.GetArchetypeWithRemovedComponentType(oldArchetype,
                                    type, entityComponentStore);
                        else
                            newArchetype = null;
                        prevOldArchetype = oldArchetype;
                    }

                    if (newArchetype != null)
                        if (newArchetype->SystemStateCleanupComplete)
                        {
                            EntityManagerCreateDestroyEntitiesUtility.DeleteChunk(chunk,
                                entityComponentStore, managedComponentStore);
                        }
                        else
                        {
                            SetArchetype(chunk, newArchetype, chunk->SharedComponentValues,
                                entityComponentStore, managedComponentStore);
                        }
                }
            }
        }

        public static void RemoveComponent(Entity entity, ComponentType type,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            if (!entityComponentStore->HasComponent(entity, type))
                return;

            var archetype = entityComponentStore->GetArchetype(entity);
            var chunk = entityComponentStore->GetChunk(entity);

            if (chunk->Locked || chunk->LockedEntityOrder)
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                throw new InvalidOperationException(
                    "Cannot remove components in locked Chunks. Unlock Chunk first.");
#else
                return;
#endif
            }

            int indexInOldTypeArray = -1;
            var newType =
                EntityManagerCreateArchetypeUtility.GetArchetypeWithRemovedComponentType(archetype, type,
                    entityComponentStore,
                    &indexInOldTypeArray);

            var sharedComponentValues = chunk->SharedComponentValues;

            if (type.IsSharedComponent)
            {
                int* temp = stackalloc int[newType->NumSharedComponents];
                int indexOfRemovedSharedComponent = indexInOldTypeArray - archetype->FirstSharedComponent;
                BuildSharedComponentIndicesWithRemovedComponent(indexOfRemovedSharedComponent,
                    newType->NumSharedComponents, sharedComponentValues, temp);
                sharedComponentValues = temp;
            }

            SetArchetype(entity, newType, sharedComponentValues,
                entityComponentStore, managedComponentStore);

            // Cleanup residue component
            if (newType->SystemStateCleanupComplete)
                EntityManagerCreateDestroyEntitiesUtility.DestroyEntities(&entity, 1,
                    entityComponentStore, managedComponentStore);
        }

        public static void SetSharedComponentDataIndex(Entity entity, int typeIndex, int newSharedComponentDataIndex,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var archetype = entityComponentStore->GetArchetype(entity);
            var indexInTypeArray = ChunkDataUtility.GetIndexInTypeArray(archetype, typeIndex);
            var srcChunk = entityComponentStore->GetChunk(entity);
            var srcSharedComponentValueArray = srcChunk->SharedComponentValues;
            var sharedComponentOffset = indexInTypeArray - archetype->FirstSharedComponent;
            var oldSharedComponentDataIndex = srcSharedComponentValueArray[sharedComponentOffset];

            if (newSharedComponentDataIndex == oldSharedComponentDataIndex)
                return;

            var sharedComponentIndices = stackalloc int[archetype->NumSharedComponents];

            srcSharedComponentValueArray.CopyTo(sharedComponentIndices, 0, archetype->NumSharedComponents);

            sharedComponentIndices[sharedComponentOffset] = newSharedComponentDataIndex;

            var newChunk = EntityManagerCreateDestroyEntitiesUtility.GetChunkWithEmptySlots(archetype,
                sharedComponentIndices,
                entityComponentStore, managedComponentStore);

            var newChunkIndex = EntityManagerCreateDestroyEntitiesUtility.AllocateIntoChunk(newChunk,
                entityComponentStore, managedComponentStore);

            managedComponentStore.IncrementComponentOrderVersion(archetype, srcChunk->SharedComponentValues);
            entityComponentStore->IncrementComponentTypeOrderVersion(archetype);

            MoveEntityToChunk(entity, newChunk, newChunkIndex, entityComponentStore,
                managedComponentStore);
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        static void BuildSharedComponentIndicesWithAddedComponent(int indexOfNewSharedComponent, int value,
            int newCount, SharedComponentValues srcSharedComponentValues, int* dstSharedComponentValues)
        {
            srcSharedComponentValues.CopyTo(dstSharedComponentValues, 0, indexOfNewSharedComponent);
            dstSharedComponentValues[indexOfNewSharedComponent] = value;
            srcSharedComponentValues.CopyTo(dstSharedComponentValues + indexOfNewSharedComponent + 1,
                indexOfNewSharedComponent, newCount - indexOfNewSharedComponent - 1);
        }

        static void BuildSharedComponentIndicesWithRemovedComponent(int indexOfRemovedSharedComponent,
            int newCount, SharedComponentValues srcSharedComponentValues, int* dstSharedComponentValues)
        {
            srcSharedComponentValues.CopyTo(dstSharedComponentValues, 0, indexOfRemovedSharedComponent);
            srcSharedComponentValues.CopyTo(dstSharedComponentValues + indexOfRemovedSharedComponent,
                indexOfRemovedSharedComponent + 1, newCount - indexOfRemovedSharedComponent);
        }

        static void BuildSharedComponentIndicesWithAddedComponents(Archetype* srcArchetype,
            Archetype* dstArchetype, SharedComponentValues srcSharedComponentValues, int* dstSharedComponentValues)
        {
            int oldFirstShared = srcArchetype->FirstSharedComponent;
            int newFirstShared = dstArchetype->FirstSharedComponent;
            int oldCount = srcArchetype->NumSharedComponents;
            int newCount = dstArchetype->NumSharedComponents;

            for (int oldIndex = oldCount - 1, newIndex = newCount - 1; newIndex >= 0; --newIndex)
            {
                // oldIndex might become -1 which is ok since oldFirstShared is always at least 1. The comparison will then always be false
                if (dstArchetype->Types[newIndex + newFirstShared] == srcArchetype->Types[oldIndex + oldFirstShared])
                    dstSharedComponentValues[newIndex] = srcSharedComponentValues[oldIndex--];
                else
                    dstSharedComponentValues[newIndex] = 0;
            }
        }

        static void AllocateChunksForAddComponent(NativeList<EntityBatchInChunk> entityBatchList, ComponentType type,
            int existingSharedComponentIndex,
            NativeList<EntityBatchInChunk> sourceCountEntityBatchList,
            NativeList<EntityBatchInChunk> packBlittableEntityBatchList,
            NativeList<EntityBatchInChunk> packManagedEntityBatchList,
            NativeList<EntityBatchInChunk> sourceBlittableEntityBatchList,
            NativeList<EntityBatchInChunk> destinationBlittableEntityBatchList,
            NativeList<EntityBatchInChunk> sourceManagedEntityBatchList,
            NativeList<EntityBatchInChunk> destinationManagedEntityBatchList,
            NativeList<EntityBatchInChunk> moveChunkList,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            Profiler.BeginSample("Allocate Chunks");

            Archetype* prevSrcArchetype = null;
            Archetype* dstArchetype = null;
            int indexInTypeArray = 0;
            var layoutCompatible = false;

            for (int i = 0; i < entityBatchList.Length; i++)
            {
                var srcEntityBatch = entityBatchList[i];
                var srcRemainingCount = srcEntityBatch.Count;
                var srcChunk = srcEntityBatch.Chunk;
                var srcArchetype = srcChunk->Archetype;
                var srcStartIndex = srcEntityBatch.StartIndex;
                var srcTail = (srcStartIndex + srcRemainingCount) == srcChunk->Count;
                var srcChunkManagedData = srcChunk->ManagedArrayIndex >= 0;

                if (prevSrcArchetype != srcArchetype)
                {
                    dstArchetype = EntityManagerCreateArchetypeUtility.GetArchetypeWithAddedComponentType(srcArchetype,
                        type,
                        entityComponentStore, &indexInTypeArray);
                    layoutCompatible = ChunkDataUtility.AreLayoutCompatible(srcArchetype, dstArchetype);
                    prevSrcArchetype = srcArchetype;
                }

                if (dstArchetype == null)
                    continue;

                var srcWholeChunk = srcEntityBatch.Count == srcChunk->Count;
                if (srcWholeChunk && layoutCompatible)
                {
                    moveChunkList.Add(srcEntityBatch);
                    continue;
                }

                var sharedComponentValues = srcChunk->SharedComponentValues;
                if (type.IsSharedComponent)
                {
                    int* temp = stackalloc int[dstArchetype->NumSharedComponents];
                    int indexOfNewSharedComponent = indexInTypeArray - dstArchetype->FirstSharedComponent;
                    BuildSharedComponentIndicesWithAddedComponent(indexOfNewSharedComponent,
                        existingSharedComponentIndex,
                        dstArchetype->NumSharedComponents, sharedComponentValues, temp);

                    sharedComponentValues = temp;
                }

                sourceCountEntityBatchList.Add(srcEntityBatch);
                if (!srcTail)
                {
                    packBlittableEntityBatchList.Add(srcEntityBatch);
                    if (srcChunkManagedData)
                    {
                        packManagedEntityBatchList.Add(srcEntityBatch);
                    }
                }

                var srcOffset = 0;
                while (srcRemainingCount > 0)
                {
                    var dstChunk = EntityManagerCreateDestroyEntitiesUtility.GetChunkWithEmptySlots(dstArchetype,
                        sharedComponentValues,
                        entityComponentStore, managedComponentStore);

                    int dstIndexBase;
                    var dstCount =
                        EntityManagerCreateDestroyEntitiesUtility.AllocateIntoChunk(dstChunk, srcRemainingCount,
                            out dstIndexBase,
                            entityComponentStore, managedComponentStore);

                    var partialSrcEntityBatch = new EntityBatchInChunk
                    {
                        Chunk = srcChunk,
                        Count = dstCount,
                        StartIndex = srcStartIndex + srcOffset
                    };
                    var partialDstEntityBatch = new EntityBatchInChunk
                    {
                        Chunk = dstChunk,
                        Count = dstCount,
                        StartIndex = dstIndexBase
                    };

                    sourceBlittableEntityBatchList.Add(partialSrcEntityBatch);
                    destinationBlittableEntityBatchList.Add(partialDstEntityBatch);

                    if (srcChunkManagedData)
                    {
                        sourceManagedEntityBatchList.Add(partialSrcEntityBatch);
                        destinationManagedEntityBatchList.Add(partialDstEntityBatch);
                    }

                    srcOffset += dstCount;
                    srcRemainingCount -= dstCount;
                }
            }

            Profiler.EndSample();
        }

        [BurstCompile]
        struct CopyBlittableChunkData : IJobParallelFor
        {
            [ReadOnly] public NativeList<EntityBatchInChunk> DestinationEntityBatchList;
            [ReadOnly] public NativeList<EntityBatchInChunk> SourceEntityBatchList;
            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* entityComponentStore;

            public void Execute(int i)
            {
                var srcEntityBatch = SourceEntityBatchList[i];
                var dstEntityBatch = DestinationEntityBatchList[i];

                var srcChunk = srcEntityBatch.Chunk;
                var srcOffset = srcEntityBatch.StartIndex;
                var dstChunk = dstEntityBatch.Chunk;
                var dstIndexBase = dstEntityBatch.StartIndex;
                var dstCount = dstEntityBatch.Count;
                var srcEntities = (Entity*) srcChunk->Buffer;
                var dstEntities = (Entity*) dstChunk->Buffer;
                var dstArchetype = dstChunk->Archetype;

                ChunkDataUtility.Convert(srcChunk, srcOffset, dstChunk, dstIndexBase, dstCount);

                for (int entityIndex = 0; entityIndex < dstCount; entityIndex++)
                {
                    var entity = dstEntities[dstIndexBase + entityIndex];
                    srcEntities[srcOffset + entityIndex] = Entity.Null;

                    entityComponentStore->SetArchetype(entity, dstArchetype);
                    entityComponentStore->SetEntityInChunk(entity,
                        new EntityInChunk {Chunk = dstChunk, IndexInChunk = dstIndexBase + entityIndex});
                }
            }
        }

        static JobHandle CopyBlittableChunkDataJob(NativeList<EntityBatchInChunk> sourceEntityBatchList,
            NativeList<EntityBatchInChunk> destinationEntityBatchList,
            EntityComponentStore* entityComponentStore,
            JobHandle inputDeps = new JobHandle())
        {
            Profiler.BeginSample("Copy Blittable Chunk Data");
            var copyBlittableChunkDataJob = new CopyBlittableChunkData
            {
                DestinationEntityBatchList = destinationEntityBatchList,
                SourceEntityBatchList = sourceEntityBatchList,
                entityComponentStore = entityComponentStore
            };
            var copyBlittableChunkDataJobHandle =
                copyBlittableChunkDataJob.Schedule(sourceEntityBatchList.Length, 64, inputDeps);
            Profiler.EndSample();
            return copyBlittableChunkDataJobHandle;
        }

        struct PackBlittableChunkData : IJob
        {
            [ReadOnly] public NativeList<EntityBatchInChunk> PackBlittableEntityBatchList;
            [NativeDisableUnsafePtrRestriction] public EntityComponentStore* entityComponentStore;

            public void Execute()
            {
                // Packing is done in reverse (sorted) so that order is preserved of to-be packed batches in same chunk
                for (int i = PackBlittableEntityBatchList.Length - 1; i >= 0; i--)
                {
                    var srcEntityBatch = PackBlittableEntityBatchList[i];
                    var srcChunk = srcEntityBatch.Chunk;
                    var srcArchetype = srcChunk->Archetype;
                    var dstIndexBase = srcEntityBatch.StartIndex;
                    var dstCount = srcEntityBatch.Count;
                    var srcOffset = dstIndexBase + dstCount;
                    var srcCount = srcChunk->Count - srcOffset;
                    var srcEntities = (Entity*) srcChunk->Buffer;

                    ChunkDataUtility.Convert(srcChunk, srcOffset, srcChunk, dstIndexBase, srcCount);
                    for (int entityIndex = 0; entityIndex < srcCount; entityIndex++)
                    {
                        var entity = srcEntities[dstIndexBase + entityIndex];
                        if (entity == Entity.Null)
                            continue;

                        entityComponentStore->SetArchetype(entity, srcArchetype);
                        entityComponentStore->SetEntityInChunk(entity,
                            new EntityInChunk {Chunk = srcChunk, IndexInChunk = dstIndexBase + entityIndex});
                    }
                }
            }
        }

        static JobHandle PackBlittableChunkDataJob(NativeList<EntityBatchInChunk> packBlittableEntityBatchList,
            EntityComponentStore* entityComponentStore,
            JobHandle inputDeps = new JobHandle())
        {
            var packBlittableChunkDataJob = new PackBlittableChunkData
            {
                PackBlittableEntityBatchList = packBlittableEntityBatchList,
                entityComponentStore = entityComponentStore
            };
            var packBlittableChunkDataJobHandle = packBlittableChunkDataJob.Schedule(inputDeps);
            return packBlittableChunkDataJobHandle;
        }

        static void CopyManagedChunkData(NativeList<EntityBatchInChunk> sourceEntityBatchList,
            NativeList<EntityBatchInChunk> destinationEntityBatchList,
            ManagedComponentStore managedComponentStore)
        {
            Profiler.BeginSample("Copy Managed Chunk Data");
            for (int i = 0; i < sourceEntityBatchList.Length; i++)
            {
                var srcEntityBatch = sourceEntityBatchList[i];
                var dstEntityBatch = destinationEntityBatchList[i];

                var srcChunk = srcEntityBatch.Chunk;
                var srcOffset = srcEntityBatch.StartIndex;
                var dstChunk = dstEntityBatch.Chunk;
                var dstIndexBase = dstEntityBatch.StartIndex;
                var dstCount = dstEntityBatch.Count;

                if (srcChunk->ManagedArrayIndex >= 0 && dstChunk->ManagedArrayIndex >= 0)
                    managedComponentStore.CopyManagedObjects(srcChunk, srcOffset,
                        dstChunk, dstIndexBase, dstCount);

                if (srcChunk->ManagedArrayIndex >= 0)
                    managedComponentStore.ClearManagedObjects(srcChunk, srcOffset, dstCount);
            }

            Profiler.EndSample();
        }

        static void PackManagedChunkData(NativeList<EntityBatchInChunk> packManagedEntityBatchList,
            ManagedComponentStore managedComponentStore)
        {
            Profiler.BeginSample("Pack Managed Chunk Data");
            // Packing is done in reverse (sorted) so that order is preserved of to-be packed batches in same chunk
            for (int i = packManagedEntityBatchList.Length - 1; i >= 0; i--)
            {
                var srcEntityBatch = packManagedEntityBatchList[i];
                var srcChunk = srcEntityBatch.Chunk;
                var dstIndexBase = srcEntityBatch.StartIndex;
                var dstCount = srcEntityBatch.Count;
                var srcOffset = dstIndexBase + dstCount;
                var srcCount = srcChunk->Count - srcOffset;

                managedComponentStore.CopyManagedObjects(srcChunk, srcOffset,
                    srcChunk, dstIndexBase, srcCount);
            }

            Profiler.EndSample();
        }

        static void UpdateDestinationVersions(NativeList<EntityBatchInChunk> destinationBlittableEntityBatchList,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            Profiler.BeginSample("Update Destination Versions");
            for (int i = 0; i < destinationBlittableEntityBatchList.Length; i++)
            {
                var dstEntityBatch = destinationBlittableEntityBatchList[i];
                var dstChunk = dstEntityBatch.Chunk;
                var dstSharedComponentValues = dstChunk->SharedComponentValues;
                var dstArchetype = dstChunk->Archetype;

                dstChunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);
                managedComponentStore.IncrementComponentOrderVersion(dstArchetype, dstSharedComponentValues);
                entityComponentStore->IncrementComponentTypeOrderVersion(dstArchetype);
            }

            Profiler.EndSample();
        }

        static void UpdateSourceCountsAndVersions(NativeList<EntityBatchInChunk> sourceCountEntityBatchList,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            Profiler.BeginSample("Update Source Counts and Versions");
            for (int i = 0; i < sourceCountEntityBatchList.Length; i++)
            {
                var srcEntityBatch = sourceCountEntityBatchList[i];
                var srcChunk = srcEntityBatch.Chunk;
                var srcCount = srcEntityBatch.Count;
                var srcArchetype = srcChunk->Archetype;
                var srcSharedComponentValues = srcChunk->SharedComponentValues;

                srcArchetype->EntityCount -= srcCount;

                srcChunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);
                EntityManagerCreateDestroyEntitiesUtility.SetChunkCount(srcChunk, srcChunk->Count - srcCount,
                    entityComponentStore, managedComponentStore);
                managedComponentStore.IncrementComponentOrderVersion(srcArchetype, srcSharedComponentValues);
                entityComponentStore->IncrementComponentTypeOrderVersion(srcArchetype);
            }

            Profiler.EndSample();
        }

        static void MoveChunksForAddComponent(NativeList<EntityBatchInChunk> entityBatchList, ComponentType type,
            int existingSharedComponentIndex,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            Archetype* prevSrcArchetype = null;
            Archetype* dstArchetype = null;
            int indexInTypeArray = 0;

            for (int i = 0; i < entityBatchList.Length; i++)
            {
                var srcEntityBatch = entityBatchList[i];
                var srcChunk = srcEntityBatch.Chunk;
                var srcArchetype = srcChunk->Archetype;
                if (srcArchetype != prevSrcArchetype)
                {
                    dstArchetype =
                        EntityManagerCreateArchetypeUtility.GetArchetypeWithAddedComponentType(srcArchetype, type,
                            entityComponentStore,
                            &indexInTypeArray);
                    prevSrcArchetype = srcArchetype;
                }

                var sharedComponentValues = srcChunk->SharedComponentValues;
                if (type.IsSharedComponent)
                {
                    int* temp = stackalloc int[dstArchetype->NumSharedComponents];
                    int indexOfNewSharedComponent = indexInTypeArray - dstArchetype->FirstSharedComponent;
                    BuildSharedComponentIndicesWithAddedComponent(indexOfNewSharedComponent,
                        existingSharedComponentIndex,
                        dstArchetype->NumSharedComponents, sharedComponentValues, temp);
                    sharedComponentValues = temp;
                }

                MoveChunkToNewArchetype(srcChunk, dstArchetype, sharedComponentValues,
                    entityComponentStore, managedComponentStore);
            }

            managedComponentStore.AddReference(existingSharedComponentIndex, entityBatchList.Length);
        }

        static void MoveChunkToNewArchetype(Chunk* chunk, Archetype* newArchetype,
            SharedComponentValues sharedComponentValues,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var oldArchetype = chunk->Archetype;
            ChunkDataUtility.AssertAreLayoutCompatible(oldArchetype, newArchetype);
            var count = chunk->Count;
            bool hasEmptySlots = count < chunk->Capacity;

            if (hasEmptySlots)
                oldArchetype->EmptySlotTrackingRemoveChunk(chunk);

            int chunkIndexInOldArchetype = chunk->ListIndex;

            var newTypes = newArchetype->Types;
            var oldTypes = oldArchetype->Types;

            chunk->Archetype = newArchetype;

            //Change version is overriden below
            newArchetype->AddToChunkList(chunk, sharedComponentValues, 0);
            int chunkIndexInNewArchetype = chunk->ListIndex;

            //Copy change versions from old to new archetype
            for (int iOldType = oldArchetype->TypesCount - 1, iNewType = newArchetype->TypesCount - 1;
                iNewType >= 0;
                --iNewType)
            {
                var newType = newTypes[iNewType];
                while (oldTypes[iOldType] > newType)
                    --iOldType;
                var version = oldTypes[iOldType] == newType
                    ? oldArchetype->Chunks.GetChangeVersion(iOldType, chunkIndexInOldArchetype)
                    : entityComponentStore->GlobalSystemVersion;
                newArchetype->Chunks.SetChangeVersion(iNewType, chunkIndexInNewArchetype, version);
            }
            
            chunk->ListIndex = chunkIndexInOldArchetype;
            oldArchetype->RemoveFromChunkList(chunk);
            chunk->ListIndex = chunkIndexInNewArchetype;

            if (hasEmptySlots)
                newArchetype->EmptySlotTrackingAddChunk(chunk);

            entityComponentStore->SetArchetype(chunk, newArchetype);

            oldArchetype->EntityCount -= count;
            newArchetype->EntityCount += count;

            if (oldArchetype->MetaChunkArchetype != newArchetype->MetaChunkArchetype)
            {
                if (oldArchetype->MetaChunkArchetype == null)
                {
                    EntityManagerCreateDestroyEntitiesUtility.CreateMetaEntityForChunk(chunk, entityComponentStore, managedComponentStore);
                }
                else if (newArchetype->MetaChunkArchetype == null)
                {
                    EntityManagerCreateDestroyEntitiesUtility.DestroyMetaChunkEntity(chunk->metaChunkEntity, entityComponentStore, managedComponentStore);
                    chunk->metaChunkEntity = Entity.Null;
                }
                else
                {
                    var metaChunk = entityComponentStore->GetChunk(chunk->metaChunkEntity);
                    var sharedComponentDataIndices = metaChunk->SharedComponentValues;
                    SetArchetype(chunk->metaChunkEntity, newArchetype->MetaChunkArchetype, sharedComponentDataIndices, entityComponentStore, managedComponentStore);
                }
            }
        }

        static void MoveEntityToChunk(Entity entity, Chunk* newChunk, int newChunkIndex,
            EntityComponentStore* entityComponentStore,
            ManagedComponentStore managedComponentStore)
        {
            var oldEntityInChunk = entityComponentStore->GetEntityInChunk(entity);
            var oldChunk = oldEntityInChunk.Chunk;
            var oldChunkIndex = oldEntityInChunk.IndexInChunk;

            Assert.IsTrue(oldChunk->Archetype == newChunk->Archetype);

            ChunkDataUtility.Copy(oldChunk, oldChunkIndex, newChunk, newChunkIndex, 1);

            if (oldChunk->ManagedArrayIndex >= 0)
                managedComponentStore.CopyManagedObjects(oldChunk, oldChunkIndex, newChunk, newChunkIndex, 1);

            entityComponentStore->SetEntityInChunk(entity, new EntityInChunk
            {
                Chunk = newChunk,
                IndexInChunk = newChunkIndex
            });

            var lastIndex = oldChunk->Count - 1;
            // No need to replace with ourselves
            if (lastIndex != oldChunkIndex)
            {
                var lastEntity = *(Entity*) ChunkDataUtility.GetComponentDataRO(oldChunk, lastIndex, 0);
                entityComponentStore->SetEntityInChunk(lastEntity, new EntityInChunk
                {
                    Chunk = oldChunk,
                    IndexInChunk = oldChunkIndex
                });
                ChunkDataUtility.Copy(oldChunk, lastIndex, oldChunk, oldChunkIndex, 1);
                if (oldChunk->ManagedArrayIndex >= 0)
                    managedComponentStore.CopyManagedObjects(oldChunk, lastIndex, oldChunk, oldChunkIndex, 1);
            }

            if (oldChunk->ManagedArrayIndex >= 0)
                managedComponentStore.ClearManagedObjects(oldChunk, lastIndex, 1);

            newChunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);
            oldChunk->SetAllChangeVersions(entityComponentStore->GlobalSystemVersion);

            newChunk->Archetype->EntityCount--;
            EntityManagerCreateDestroyEntitiesUtility.SetChunkCount(oldChunk, oldChunk->Count - 1, entityComponentStore,
                managedComponentStore);
        }
    }
}
