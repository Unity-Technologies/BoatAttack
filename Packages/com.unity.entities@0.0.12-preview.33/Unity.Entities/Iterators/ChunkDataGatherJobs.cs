using System;
using Unity.Assertions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace Unity.Entities
{
    [BurstCompile]
    unsafe struct GatherChunks : IJobParallelFor
    {
        [NativeDisableUnsafePtrRestriction] public EntityComponentStore* entityComponentStore;
        [NativeDisableUnsafePtrRestriction] public MatchingArchetype** MatchingArchetypes;
        [DeallocateOnJobCompletion] [ReadOnly] public NativeArray<int> Offsets;
        [NativeDisableParallelForRestriction] public NativeArray<ArchetypeChunk> Chunks;

        public void Execute(int index)
        {
            var archetype = MatchingArchetypes[index]->Archetype;
            var chunkCount = archetype->Chunks.Count;
            var offset = Offsets[index];
            for (int i = 0; i < chunkCount; i++)
            {
                var srcChunk = archetype->Chunks.p[i];
                Chunks[offset+i] = new ArchetypeChunk(srcChunk,entityComponentStore);
            }
        }
    }

    [BurstCompile]
    internal unsafe struct GatherChunksAndOffsetsJob : IJob
    {
        public MatchingArchetypeList Archetypes;
        [NativeDisableUnsafePtrRestriction] public EntityComponentStore* entityComponentStore;

        [NativeDisableUnsafePtrRestriction]
        public void* PrefilterData;
        public int   UnfilteredChunkCount;

        public void Execute()
        {
            var chunks = (ArchetypeChunk*) PrefilterData;
            var entityIndices = (int*) (chunks + UnfilteredChunkCount);

            var chunkCounter = 0;
            var entityOffsetPrefixSum = 0;

            for (var m = Archetypes.Count - 1; m >= 0; --m)
            {
                var match = Archetypes.p[m];
                if (match->Archetype->EntityCount <= 0)
                    continue;

                var archetype = match->Archetype;
                int chunkCount = archetype->Chunks.Count;
                var chunkEntityCountArray = archetype->Chunks.GetChunkEntityCountArray();

                for (int chunkIndex = 0; chunkIndex < chunkCount; ++chunkIndex)
                {
                    chunks[chunkCounter] = new ArchetypeChunk(archetype->Chunks.p[chunkIndex], entityComponentStore);
                    entityIndices[chunkCounter++] = entityOffsetPrefixSum;
                    entityOffsetPrefixSum += chunkEntityCountArray[chunkIndex];
                }
            }

            var outChunkCounter = entityIndices + UnfilteredChunkCount;
            *outChunkCounter = chunkCounter;
        }
    }

    [BurstCompile]
    unsafe struct GatherChunksWithFiltering : IJobParallelFor
    {
        [NativeDisableUnsafePtrRestriction] public EntityComponentStore* entityComponentStore;
        [NativeDisableUnsafePtrRestriction] public MatchingArchetype** MatchingArchetypes;
        public EntityQueryFilter Filter;

        [ReadOnly] public NativeArray<int> Offsets;
        public NativeArray<int> FilteredCounts;

        [NativeDisableParallelForRestriction] public NativeArray<ArchetypeChunk> SparseChunks;

        public void Execute(int index)
        {
            var filter = Filter;
            int filteredCount = 0;
            var match = MatchingArchetypes[index];
            var archetype = match->Archetype;
            int chunkCount = archetype->Chunks.Count;
            var writeIndex = Offsets[index];
            var archetypeChunks = archetype->Chunks.p;

            if (filter.Type == FilterType.SharedComponent)
            {
                var indexInEntityQuery1 = filter.Shared.IndexInEntityQuery[0];
                var sharedComponentIndex1 = filter.Shared.SharedComponentIndex[0];
                var componentIndexInChunk1 = match->IndexInArchetype[indexInEntityQuery1] - archetype->FirstSharedComponent;
                var sharedComponents1 = archetype->Chunks.GetSharedComponentValueArrayForType(componentIndexInChunk1);

                if (filter.Shared.Count == 1)
                {
                    for (var i = 0; i < chunkCount; ++i)
                    {
                        if (sharedComponents1[i] == sharedComponentIndex1)
                            SparseChunks[writeIndex + filteredCount++] =
                                new ArchetypeChunk(archetypeChunks[i], entityComponentStore);
                    }
                }
                else
                {
                    var indexInEntityQuery2 = filter.Shared.IndexInEntityQuery[1];
                    var sharedComponentIndex2 = filter.Shared.SharedComponentIndex[1];
                    var componentIndexInChunk2 = match->IndexInArchetype[indexInEntityQuery2] - archetype->FirstSharedComponent;
                    var sharedComponents2 = archetype->Chunks.GetSharedComponentValueArrayForType(componentIndexInChunk2);

                    for (var i = 0; i < chunkCount; ++i)
                    {

                        if (sharedComponents1[i] == sharedComponentIndex1 &&
                            sharedComponents2[i] == sharedComponentIndex2)
                            SparseChunks[writeIndex + filteredCount++] =
                                new ArchetypeChunk(archetypeChunks[i], entityComponentStore);
                    }
                }
            }
            else
            {
                var indexInEntityQuery1 = filter.Changed.IndexInEntityQuery[0];
                var componentIndexInChunk1 = match->IndexInArchetype[indexInEntityQuery1];
                var changeVersions1 = archetype->Chunks.GetChangeVersionArrayForType(componentIndexInChunk1);

                var requiredVersion = filter.RequiredChangeVersion;
                if (filter.Changed.Count == 1)
                {
                    for (var i = 0; i < chunkCount; ++i)
                    {
                        if (ChangeVersionUtility.DidChange(changeVersions1[i], requiredVersion))
                            SparseChunks[writeIndex + filteredCount++] =
                                new ArchetypeChunk(archetypeChunks[i], entityComponentStore);
                    }
                }
                else
                {
                    var indexInEntityQuery2 = filter.Changed.IndexInEntityQuery[1];
                    var componentIndexInChunk2 = match->IndexInArchetype[indexInEntityQuery2];
                    var changeVersions2 = archetype->Chunks.GetChangeVersionArrayForType(componentIndexInChunk2);

                    for (var i = 0; i < chunkCount; ++i)
                    {

                        if (ChangeVersionUtility.DidChange(changeVersions1[i], requiredVersion) ||
                            ChangeVersionUtility.DidChange(changeVersions2[i], requiredVersion))
                            SparseChunks[writeIndex + filteredCount++] =
                                new ArchetypeChunk(archetypeChunks[i], entityComponentStore);
                    }
                }
            }

            FilteredCounts[index] = filteredCount;
        }
    }

    [BurstCompile]
    internal unsafe struct GatherChunksAndOffsetsWithFilteringJob : IJob
    {
        public MatchingArchetypeList Archetypes;
        public EntityQueryFilter Filter;

        [NativeDisableUnsafePtrRestriction]
        public void* PrefilterData;
        public int   UnfilteredChunkCount;

        public void Execute()
        {
            var chunks = (ArchetypeChunk*) PrefilterData;
            var entityIndices = (int*) (chunks + UnfilteredChunkCount);

            var filter = Filter;
            var filteredChunkCount = 0;
            var filteredEntityOffset = 0;

            for (var m = Archetypes.Count - 1; m >= 0; --m)
            {
                var match = Archetypes.p[m];
                if (match->Archetype->EntityCount <= 0)
                    continue;

                var archetype = match->Archetype;
                int chunkCount = archetype->Chunks.Count;
                var chunkEntityCountArray = archetype->Chunks.GetChunkEntityCountArray();

                if (filter.Type == FilterType.SharedComponent)
                {
                    var indexInEntityQuery0 = filter.Shared.IndexInEntityQuery[0];
                    var sharedComponentIndex0 = filter.Shared.SharedComponentIndex[0];
                    var componentIndexInChunk0 =
                        match->IndexInArchetype[indexInEntityQuery0] - archetype->FirstSharedComponent;
                    var sharedComponents0 =
                        archetype->Chunks.GetSharedComponentValueArrayForType(componentIndexInChunk0);

                    if (filter.Shared.Count == 1)
                    {
                        for (var i = 0; i < chunkCount; ++i)
                        {
                            if (sharedComponents0[i] == sharedComponentIndex0)
                            {
                                chunks[filteredChunkCount] =
                                    new ArchetypeChunk(archetype->Chunks.p[i], Archetypes.entityComponentStore);
                                entityIndices[filteredChunkCount++] = filteredEntityOffset;
                                filteredEntityOffset += chunkEntityCountArray[i];
                            }
                        }
                    }
                    else
                    {
                        var indexInEntityQuery1 = filter.Shared.IndexInEntityQuery[1];
                        var sharedComponentIndex1 = filter.Shared.SharedComponentIndex[1];
                        var componentIndexInChunk1 =
                            match->IndexInArchetype[indexInEntityQuery1] - archetype->FirstSharedComponent;
                        var sharedComponents1 =
                            archetype->Chunks.GetSharedComponentValueArrayForType(componentIndexInChunk1);

                        for (var i = 0; i < chunkCount; ++i)
                        {
                            if (sharedComponents0[i] == sharedComponentIndex0 &&
                                sharedComponents1[i] == sharedComponentIndex1)
                            {
                                chunks[filteredChunkCount] =
                                    new ArchetypeChunk(archetype->Chunks.p[i], Archetypes.entityComponentStore);
                                entityIndices[filteredChunkCount++] = filteredEntityOffset;
                                filteredEntityOffset += chunkEntityCountArray[i];
                            }
                        }
                    }
                }
                else
                {
                    var indexInEntityQuery0 = filter.Changed.IndexInEntityQuery[0];
                    var componentIndexInChunk0 = match->IndexInArchetype[indexInEntityQuery0];
                    var changeVersions0 = archetype->Chunks.GetChangeVersionArrayForType(componentIndexInChunk0);

                    var requiredVersion = filter.RequiredChangeVersion;
                    if (filter.Changed.Count == 1)
                    {
                        for (var i = 0; i < chunkCount; ++i)
                        {
                            if (ChangeVersionUtility.DidChange(changeVersions0[i], requiredVersion))
                            {
                                chunks[filteredChunkCount] =
                                    new ArchetypeChunk(archetype->Chunks.p[i], Archetypes.entityComponentStore);
                                entityIndices[filteredChunkCount++] = filteredEntityOffset;
                                filteredEntityOffset += chunkEntityCountArray[i];
                            }
                        }
                    }
                    else
                    {
                        var indexInEntityQuery1 = filter.Changed.IndexInEntityQuery[1];
                        var componentIndexInChunk1 = match->IndexInArchetype[indexInEntityQuery1];
                        var changeVersions1 =
                            archetype->Chunks.GetChangeVersionArrayForType(componentIndexInChunk1);

                        for (var i = 0; i < chunkCount; ++i)
                        {
                            if (ChangeVersionUtility.DidChange(changeVersions0[i], requiredVersion) ||
                                ChangeVersionUtility.DidChange(changeVersions1[i], requiredVersion))
                            {
                                chunks[filteredChunkCount] =
                                    new ArchetypeChunk(archetype->Chunks.p[i], Archetypes.entityComponentStore);
                                entityIndices[filteredChunkCount++] = filteredEntityOffset;
                                filteredEntityOffset += chunkEntityCountArray[i];
                            }
                        }
                    }
                }
            }

            UnsafeUtility.MemMove(chunks + filteredChunkCount, chunks + UnfilteredChunkCount, filteredChunkCount * sizeof(int));

            var chunkCounter = entityIndices + UnfilteredChunkCount;
            *chunkCounter = filteredChunkCount;
        }
    }

    unsafe struct JoinChunksJob : IJobParallelFor
    {
        [DeallocateOnJobCompletion] [NativeDisableParallelForRestriction] public NativeArray<int> DestinationOffsets;
        [DeallocateOnJobCompletion] [NativeDisableParallelForRestriction] public NativeArray<ArchetypeChunk> SparseChunks;
        [DeallocateOnJobCompletion] [ReadOnly] public NativeArray<int> Offsets;
        [NativeDisableParallelForRestriction] public NativeArray<ArchetypeChunk> JoinedChunks;

        public void Execute(int index)
        {
            int destOffset = DestinationOffsets[index];
            int count = DestinationOffsets[index+1]-destOffset;
            if(count != 0)
                NativeArray<ArchetypeChunk>.Copy(SparseChunks, Offsets[index], JoinedChunks, destOffset, count);
        }
    }

    [BurstCompile]
    unsafe struct GatherEntitiesJob : IJobChunk
    {
        public NativeArray<Entity> Entities;
        [ReadOnly]public ArchetypeChunkEntityType EntityType;

        public void Execute(ArchetypeChunk chunk, int chunkIndex, int entityOffset)
        {
            var destinationPtr = (Entity*)Entities.GetUnsafePtr() + entityOffset;
            var sourcePtr = chunk.GetNativeArray(EntityType).GetUnsafeReadOnlyPtr();
            var copySizeInBytes = sizeof(Entity) * chunk.Count;

            UnsafeUtility.MemCpy(destinationPtr, sourcePtr, copySizeInBytes);
        }
    }

    [BurstCompile]
    unsafe struct GatherComponentDataJob<T> : IJobChunk
        where T : struct,IComponentData
    {
        public NativeArray<T> ComponentData;
        [ReadOnly]public ArchetypeChunkComponentType<T> ComponentType;

        public void Execute(ArchetypeChunk chunk, int chunkIndex, int entityOffset)
        {
            var sourcePtr = chunk.GetNativeArray(ComponentType).GetUnsafeReadOnlyPtr();
            var destinationPtr = (byte*) ComponentData.GetUnsafePtr() + UnsafeUtility.SizeOf<T>() * entityOffset;
            var copySizeInBytes = UnsafeUtility.SizeOf<T>() * chunk.Count;

            UnsafeUtility.MemCpy(destinationPtr, sourcePtr, copySizeInBytes);
        }
    }

    [BurstCompile]
    unsafe struct CopyComponentArrayToChunks<T> : IJobChunk
        where T : struct,IComponentData
    {
        [ReadOnly]
        public NativeArray<T> ComponentData;
        public ArchetypeChunkComponentType<T> ComponentType;

        public void Execute(ArchetypeChunk chunk, int chunkIndex, int entityOffset)
        {
            var destinationPtr = chunk.GetNativeArray(ComponentType).GetUnsafePtr();
            var srcPtr = (byte*) ComponentData.GetUnsafeReadOnlyPtr() + UnsafeUtility.SizeOf<T>() * entityOffset;
            var copySizeInBytes = UnsafeUtility.SizeOf<T>() * chunk.Count;

            UnsafeUtility.MemCpy(destinationPtr, srcPtr, copySizeInBytes);
        }
    }

}
