using System;
using Unity.Assertions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Entities
{
    [Flags]
    internal enum FilterType
    {
        None,
        SharedComponent,
        Changed
    }

    //@TODO: Use field offset / union here... There seems to be an issue in mono preventing it...
    internal unsafe struct EntityQueryFilter
    {
        public struct SharedComponentData
        {
            public int Count;
            public fixed int IndexInEntityQuery[2];
            public fixed int SharedComponentIndex[2];
        }

        // Saves the index of ComponentTypes in this group that have changed.
        public struct ChangedFilter
        {
            public const int Capacity = 2;

            public int Count;
            public fixed int IndexInEntityQuery[2];
        }

        public FilterType Type;
        public uint RequiredChangeVersion;

        public SharedComponentData Shared;
        public ChangedFilter Changed;

        public bool RequiresMatchesFilter
        {
            get { return Type != FilterType.None; }
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        public void AssertValid()
        {
            if ((Type & FilterType.SharedComponent) != 0)
                Assert.IsTrue(Shared.Count <= 2 && Shared.Count > 0);
            else if ((Type & FilterType.Changed) != 0)
                Assert.IsTrue(Changed.Count <= 2 && Changed.Count > 0);
        }
#endif
    }

    internal unsafe struct ComponentChunkCache
    {
        [NativeDisableUnsafePtrRestriction] public void* CachedPtr;
        public int CachedBeginIndex;
        public int CachedEndIndex;
        public int CachedSizeOf;
        public bool IsWriting;
    }

    /// <summary>
    ///     Enables iteration over chunks belonging to a set of archetypes.
    /// </summary>
    internal unsafe struct ComponentChunkIterator
    {
        internal readonly MatchingArchetypeList m_MatchingArchetypeList;
        private int m_CurrentMatchingArchetypeIndex;

        private int m_CurrentMatchingArchetypeIndexNext => m_CurrentMatchingArchetypeIndex - 1;

        private int m_FirstMatchingArchetypeIndex => m_MatchingArchetypeList.Count - 1;

        private MatchingArchetype* m_CurrentMatchingArchetype =>
            m_MatchingArchetypeList.p[m_CurrentMatchingArchetypeIndex];

        [NativeDisableUnsafePtrRestriction] private Chunk** m_CurrentChunk;

        private int m_CurrentArchetypeEntityIndex;
        private int m_CurrentChunkEntityIndex;

        private int m_CurrentArchetypeIndex;
        private int m_CurrentChunkIndex;

        internal EntityQueryFilter m_Filter;

        internal readonly uint m_GlobalSystemVersion;

        public int IndexInEntityQuery;

        internal int GetSharedComponentFromCurrentChunk(int sharedComponentIndex)
        {
            var archetype = m_CurrentMatchingArchetype->Archetype;
            var indexInArchetype = m_CurrentMatchingArchetype->IndexInArchetype[sharedComponentIndex];
            var sharedComponentOffset = indexInArchetype - archetype->FirstSharedComponent;
            return (*m_CurrentChunk)->GetSharedComponentValue(sharedComponentOffset);
        }

        public ComponentChunkIterator(MatchingArchetypeList match, uint globalSystemVersion,
            ref EntityQueryFilter filter)
        {
            m_MatchingArchetypeList = match;
            m_CurrentMatchingArchetypeIndex = match.Count - 1;
            IndexInEntityQuery = -1;
            m_CurrentChunk = null;
            m_CurrentArchetypeIndex =
                m_CurrentArchetypeEntityIndex =
                    int.MaxValue; // This will trigger UpdateCacheResolvedIndex to update the cache on first access
            m_CurrentChunkIndex = m_CurrentChunkEntityIndex = 0;
            m_GlobalSystemVersion = globalSystemVersion;
            m_Filter = filter;
        }

        public object GetManagedObject(ManagedComponentStore managedComponentStore, int typeIndexInArchetype, int cachedBeginIndex,
            int index)
        {
            return managedComponentStore.GetManagedObject(*m_CurrentChunk, typeIndexInArchetype, index - cachedBeginIndex);
        }

        public object GetManagedObject(ManagedComponentStore managedComponentStore, int cachedBeginIndex, int index)
        {
            return managedComponentStore.GetManagedObject(*m_CurrentChunk,
                m_CurrentMatchingArchetype->IndexInArchetype[IndexInEntityQuery], index - cachedBeginIndex);
        }

        public object[] GetManagedObjectRange(ManagedComponentStore managedComponentStore, int cachedBeginIndex, int index,
            out int rangeStart, out int rangeLength)
        {
            var objs = managedComponentStore.GetManagedObjectRange(*m_CurrentChunk,
                m_CurrentMatchingArchetype->IndexInArchetype[IndexInEntityQuery], out rangeStart,
                out rangeLength);
            rangeStart += index - cachedBeginIndex;
            rangeLength -= index - cachedBeginIndex;
            return objs;
        }

        /// <summary>
        ///     Total number of chunks in a given MatchingArchetype list.
        /// </summary>
        /// <param name="matchingArchetypes">List of matching archetypes.</param>
        /// <returns>Number of chunks in a list of archetypes.</returns>
        internal static int CalculateNumberOfChunksWithoutFiltering(MatchingArchetypeList matchingArchetypes)
        {
            var chunkCount = 0;

            for (var m = matchingArchetypes.Count - 1; m >= 0; --m)
            {
                var match = matchingArchetypes.p[m];
                chunkCount += match->Archetype->Chunks.Count;
            }

            return chunkCount;
        }

        /// <summary>
        ///     Creates a NativeArray with all the chunks in a given archetype.
        /// </summary>
        /// <param name="matchingArchetypes">List of matching archetypes.</param>
        /// <param name="allocator">Allocator to use for the array.</param>
        /// <param name="jobHandle">Handle to the GatherChunks job used to fill the output array.</param>
        /// <returns>NativeArray of all the chunks in the matchingArchetypes list.</returns>
        public static NativeArray<ArchetypeChunk> CreateArchetypeChunkArray(MatchingArchetypeList matchingArchetypes,
            Allocator allocator, out JobHandle jobHandle, ref EntityQueryFilter filter,
            JobHandle dependsOn = default(JobHandle))
        {
            var archetypeCount = matchingArchetypes.Count;

            var offsets =
                new NativeArray<int>(archetypeCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
            var chunkCount = 0;
            {
                for (int i = 0; i < matchingArchetypes.Count; ++i)
                {
                    var archetype = matchingArchetypes.p[i]->Archetype;
                    offsets[i] = chunkCount;
                    chunkCount += archetype->Chunks.Count;
                }
            }

            if (filter.Type == FilterType.None)
            {
                var chunks = new NativeArray<ArchetypeChunk>(chunkCount, allocator, NativeArrayOptions.UninitializedMemory);
                var gatherChunksJob = new GatherChunks
                {
                    MatchingArchetypes = matchingArchetypes.p,
                    entityComponentStore = matchingArchetypes.entityComponentStore,
                    Offsets = offsets,
                    Chunks = chunks
                };
                var gatherChunksJobHandle = gatherChunksJob.Schedule(archetypeCount,1, dependsOn);
                jobHandle = gatherChunksJobHandle;

                return chunks;
            }
            else
            {
                var filteredCounts =  new NativeArray<int>(archetypeCount+1, Allocator.TempJob);
                var sparseChunks = new NativeArray<ArchetypeChunk>(chunkCount, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
                var gatherChunksJob = new GatherChunksWithFiltering
                {
                    MatchingArchetypes = matchingArchetypes.p,
                    Filter = filter,
                    Offsets = offsets,
                    FilteredCounts = filteredCounts,
                    SparseChunks = sparseChunks,
                    entityComponentStore = matchingArchetypes.entityComponentStore
                };
                gatherChunksJob.Schedule(archetypeCount,1, dependsOn).Complete();

                // accumulated filtered counts: filteredCounts[i] becomes the destination offset
                int totalChunks = 0;
                for (int i = 0; i < archetypeCount; ++i)
                {
                    int currentCount = filteredCounts[i];
                    filteredCounts[i] = totalChunks;
                    totalChunks += currentCount;
                }
                filteredCounts[archetypeCount] = totalChunks;

                var joinedChunks = new NativeArray<ArchetypeChunk>(totalChunks, allocator, NativeArrayOptions.UninitializedMemory);

                jobHandle = new JoinChunksJob
                {
                    DestinationOffsets = filteredCounts,
                    SparseChunks = sparseChunks,
                    Offsets = offsets,
                    JoinedChunks = joinedChunks
                }.Schedule(archetypeCount, 1);

                return joinedChunks;
            }
        }

        /// <summary>
        ///     Creates a NativeArray containing the entities in a given EntityQuery.
        /// </summary>
        /// <param name="matchingArchetypes">List of matching archetypes.</param>
        /// <param name="allocator">Allocator to use for the array.</param>
        /// <param name="type">An atomic safety handle required by GatherEntitiesJob so it can call GetNativeArray() on chunks.</param>
        /// <param name="entityQuery">EntityQuery to gather entities from.</param>
        /// <param name="filter">EntityQueryFilter for calculating the length of the output array.</param>
        /// <param name="jobHandle">Handle to the GatherEntitiesJob job used to fill the output array.</param>
        /// <param name="dependsOn">Handle to a job this GatherEntitiesJob must wait on.</param>
        /// <returns>NativeArray of the entities in a given EntityQuery.</returns>
        public static NativeArray<Entity> CreateEntityArray(MatchingArchetypeList matchingArchetypes,
            Allocator allocator,
            ArchetypeChunkEntityType type,
            EntityQuery entityQuery,
            ref EntityQueryFilter filter,
            out JobHandle jobHandle,
            JobHandle dependsOn)

        {
            var entityCount = CalculateLength(matchingArchetypes, ref filter);

            var job = new GatherEntitiesJob
            {
                EntityType = type,
                Entities = new NativeArray<Entity>(entityCount, allocator)
            };
            jobHandle = job.Schedule(entityQuery, dependsOn);

            return job.Entities;
        }

        public static NativeArray<T> CreateComponentDataArray<T>(MatchingArchetypeList matchingArchetypes,
            Allocator allocator,
            ArchetypeChunkComponentType<T> type,
            EntityQuery entityQuery,
            ref EntityQueryFilter filter,
            out JobHandle jobHandle,
            JobHandle dependsOn)
            where T :struct, IComponentData
        {
            var entityCount = CalculateLength(matchingArchetypes, ref filter);

            var job = new GatherComponentDataJob<T>
            {
                ComponentData = new NativeArray<T>(entityCount, allocator),
                ComponentType = type
            };
            jobHandle = job.Schedule(entityQuery, dependsOn);

            return job.ComponentData;
        }

        public static void CopyFromComponentDataArray<T>(MatchingArchetypeList matchingArchetypes,
            NativeArray<T> componentDataArray,
            ArchetypeChunkComponentType<T> type,
            EntityQuery entityQuery,
            ref EntityQueryFilter filter,
            out JobHandle jobHandle,
            JobHandle dependsOn)
            where T :struct, IComponentData
        {
            var job = new CopyComponentArrayToChunks<T>
            {
                ComponentData = componentDataArray,
                ComponentType = type
            };
            jobHandle = job.Schedule(entityQuery, dependsOn);
        }

        /// <summary>
        ///     Total number of entities contained in a given MatchingArchetype list.
        /// </summary>
        /// <param name="matchingArchetypes">List of matching archetypes.</param>
        /// <param name="filter">EntityQueryFilter to use when calculating total number of entities.</param>
        /// <returns>Number of entities</returns>
        public static int CalculateLength(MatchingArchetypeList matchingArchetypes, ref EntityQueryFilter filter)
        {
            var filterCopy = filter; // Necessary to avoid a nasty compiler error cause by fixed buffer types

            var length = 0;
            if (!filter.RequiresMatchesFilter)
            {
                for (var m = matchingArchetypes.Count - 1; m >= 0; --m)
                {
                    var match = matchingArchetypes.p[m];
                    length += match->Archetype->EntityCount;
                }
            }
            else
            {
                for (var m = matchingArchetypes.Count - 1; m >= 0; --m)
                {
                    var match = matchingArchetypes.p[m];
                    if (match->Archetype->EntityCount <= 0)
                        continue;

                    int filteredCount = 0;
                    var archetype = match->Archetype;
                    int chunkCount = archetype->Chunks.Count;
                    var chunkEntityCountArray = archetype->Chunks.GetChunkEntityCountArray();

                    if (filter.Type == FilterType.SharedComponent)
                    {
                        var indexInEntityQuery0 = filterCopy.Shared.IndexInEntityQuery[0];
                        var sharedComponentIndex0 = filterCopy.Shared.SharedComponentIndex[0];
                        var componentIndexInChunk0 =
                            match->IndexInArchetype[indexInEntityQuery0] - archetype->FirstSharedComponent;
                        var sharedComponents0 =
                            archetype->Chunks.GetSharedComponentValueArrayForType(componentIndexInChunk0);

                        if (filter.Shared.Count == 1)
                        {
                            for (var i = 0; i < chunkCount; ++i)
                            {
                                if (sharedComponents0[i] == sharedComponentIndex0)
                                    filteredCount += chunkEntityCountArray[i];
                            }
                        }
                        else
                        {
                            var indexInEntityQuery1 = filterCopy.Shared.IndexInEntityQuery[1];
                            var sharedComponentIndex1 = filterCopy.Shared.SharedComponentIndex[1];
                            var componentIndexInChunk1 =
                                match->IndexInArchetype[indexInEntityQuery1] - archetype->FirstSharedComponent;
                            var sharedComponents1 =
                                archetype->Chunks.GetSharedComponentValueArrayForType(componentIndexInChunk1);

                            for (var i = 0; i < chunkCount; ++i)
                            {
                                if (sharedComponents0[i] == sharedComponentIndex0 &&
                                    sharedComponents1[i] == sharedComponentIndex1)
                                    filteredCount += chunkEntityCountArray[i];
                            }
                        }
                    }
                    else
                    {
                        var indexInEntityQuery0 = filterCopy.Changed.IndexInEntityQuery[0];
                        var componentIndexInChunk0 = match->IndexInArchetype[indexInEntityQuery0];
                        var changeVersions0 = archetype->Chunks.GetChangeVersionArrayForType(componentIndexInChunk0);

                        var requiredVersion = filter.RequiredChangeVersion;
                        if (filter.Changed.Count == 1)
                        {
                            for (var i = 0; i < chunkCount; ++i)
                            {
                                if (ChangeVersionUtility.DidChange(changeVersions0[i], requiredVersion))
                                    filteredCount += chunkEntityCountArray[i];
                            }
                        }
                        else
                        {
                            var indexInEntityQuery1 = filterCopy.Changed.IndexInEntityQuery[1];
                            var componentIndexInChunk1 = match->IndexInArchetype[indexInEntityQuery1];
                            var changeVersions1 =
                                archetype->Chunks.GetChangeVersionArrayForType(componentIndexInChunk1);

                            for (var i = 0; i < chunkCount; ++i)
                            {
                                if (ChangeVersionUtility.DidChange(changeVersions0[i], requiredVersion) ||
                                    ChangeVersionUtility.DidChange(changeVersions1[i], requiredVersion))
                                    filteredCount += chunkEntityCountArray[i];
                            }
                        }
                    }

                    length += filteredCount;
                }
            }

            return length;
        }

        private void MoveToNextMatchingChunk()
        {
            var m = m_CurrentMatchingArchetypeIndex;
            var c = m_CurrentChunk;
            var e = m_MatchingArchetypeList.p[m]->Archetype->Chunks.p + m_MatchingArchetypeList.p[m]->Archetype->Chunks.Count;

            do
            {
                c = c + 1;
                while (c == e)
                {
                    m_CurrentArchetypeEntityIndex += m_CurrentChunkEntityIndex;
                    m_CurrentChunkEntityIndex = 0;
                    m = m - 1;
                    if (m < 0)
                    {
                        m_CurrentMatchingArchetypeIndex = m;
                        m_CurrentChunk = null;
                        return;
                    }

                    c = m_MatchingArchetypeList.p[m]->Archetype->Chunks.p;
                    e = m_MatchingArchetypeList.p[m]->Archetype->Chunks.p + m_MatchingArchetypeList.p[m]->Archetype->Chunks.Count;
                }
            } while (!((*c)->MatchesFilter(m_MatchingArchetypeList.p[m], ref m_Filter) && (*c)->Capacity > 0));

            m_CurrentMatchingArchetypeIndex = m;
            m_CurrentChunk = c;
        }

        public void MoveToEntityIndex(int index)
        {
            if (!m_Filter.RequiresMatchesFilter)
            {
                if (index < m_CurrentArchetypeEntityIndex)
                {
                    m_CurrentMatchingArchetypeIndex = m_FirstMatchingArchetypeIndex;
                    m_CurrentArchetypeEntityIndex = 0;
                    m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p;
                    // m_CurrentChunk might point to an invalid chunk if the first matching archetype has no chunks
                    // the while loop below will move to the first archetype that has any entities
                    m_CurrentChunkEntityIndex = 0;
                }

                while (index >= m_CurrentArchetypeEntityIndex + m_CurrentMatchingArchetype->Archetype->EntityCount)
                {
                    m_CurrentArchetypeEntityIndex += m_CurrentMatchingArchetype->Archetype->EntityCount;
                    m_CurrentMatchingArchetypeIndex = m_CurrentMatchingArchetypeIndexNext;
                    m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p;
                    m_CurrentChunkEntityIndex = 0;
                }

                index -= m_CurrentArchetypeEntityIndex;
                if (index < m_CurrentChunkEntityIndex)
                {
                    m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p;
                    m_CurrentChunkEntityIndex = 0;
                }

                while (index >= m_CurrentChunkEntityIndex + (*m_CurrentChunk)->Count)
                {
                    m_CurrentChunkEntityIndex += (*m_CurrentChunk)->Count;
                    m_CurrentChunk = m_CurrentChunk + 1;
                }
            }
            else
            {
                if (index < m_CurrentArchetypeEntityIndex + m_CurrentChunkEntityIndex)
                {
                    if (index < m_CurrentArchetypeEntityIndex)
                    {
                        m_CurrentMatchingArchetypeIndex = m_FirstMatchingArchetypeIndex;
                        m_CurrentArchetypeEntityIndex = 0;
                    }

                    m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p - 1;
                    // m_CurrentChunk now points to an invalid chunk but since the chunk list is circular
                    // it effectively points to the chunk before the first
                    // MoveToNextMatchingChunk will move it to a valid chunk if any exists
                    m_CurrentChunkEntityIndex = 0;
                    MoveToNextMatchingChunk();
                }

                while (index >= m_CurrentArchetypeEntityIndex + m_CurrentChunkEntityIndex + (*m_CurrentChunk)->Count)
                {
                    m_CurrentChunkEntityIndex += (*m_CurrentChunk)->Count;
                    MoveToNextMatchingChunk();
                }
            }
        }

        public void MoveToChunkWithoutFiltering(int index)
        {
            if (index < m_CurrentArchetypeIndex)
            {
                m_CurrentMatchingArchetypeIndex = m_FirstMatchingArchetypeIndex;
                m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p;
                m_CurrentArchetypeIndex = m_CurrentArchetypeEntityIndex = 0;
                m_CurrentChunkIndex = m_CurrentChunkEntityIndex = 0;
            }

            while (index >= m_CurrentArchetypeIndex + m_CurrentMatchingArchetype->Archetype->Chunks.Count)
            {
                m_CurrentArchetypeEntityIndex += m_CurrentMatchingArchetype->Archetype->EntityCount;
                m_CurrentArchetypeIndex += m_CurrentMatchingArchetype->Archetype->Chunks.Count;

                m_CurrentMatchingArchetypeIndex = m_CurrentMatchingArchetypeIndexNext;
                m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p;

                m_CurrentChunkIndex = m_CurrentChunkEntityIndex = 0;
            }

            index -= m_CurrentArchetypeIndex;
            if (index < m_CurrentChunkIndex)
            {
                m_CurrentChunk = m_CurrentMatchingArchetype->Archetype->Chunks.p;
                m_CurrentChunkIndex = m_CurrentChunkEntityIndex = 0;
            }

            while (index >= m_CurrentChunkIndex + 1)
            {
                m_CurrentChunkEntityIndex += (*m_CurrentChunk)->Count;
                m_CurrentChunkIndex += 1;

                m_CurrentChunk = m_CurrentChunk + 1;
            }
        }

        public bool MatchesFilter()
        {
            return (*m_CurrentChunk)->MatchesFilter(m_CurrentMatchingArchetype, ref m_Filter);
        }

        public bool RequiresFilter()
        {
            return m_Filter.RequiresMatchesFilter;
        }

        public int GetIndexInArchetypeFromCurrentChunk(int indexInEntityQuery)
        {
            return m_CurrentMatchingArchetype->IndexInArchetype[indexInEntityQuery];
        }

        public void UpdateCacheToCurrentChunk(out ComponentChunkCache cache, bool isWriting, int indexInEntityQuery)
        {
            var archetype = m_CurrentMatchingArchetype->Archetype;

            int indexInArchetype = m_CurrentMatchingArchetype->IndexInArchetype[indexInEntityQuery];

            cache.CachedBeginIndex = m_CurrentChunkEntityIndex + m_CurrentArchetypeEntityIndex;
            cache.CachedEndIndex = cache.CachedBeginIndex + (*m_CurrentChunk)->Count;
            cache.CachedSizeOf = archetype->SizeOfs[indexInArchetype];
            cache.CachedPtr = (*m_CurrentChunk)->Buffer + archetype->Offsets[indexInArchetype] -
                              cache.CachedBeginIndex * cache.CachedSizeOf;

            cache.IsWriting = isWriting;
            if (isWriting)
                (*m_CurrentChunk)->SetChangeVersion(indexInArchetype, m_GlobalSystemVersion);
        }

        public int GetCurrentChunkCount()
        {
            return (*m_CurrentChunk)->Count;
        }

        public void GetCurrentChunkRange(out int beginIndex, out int endIndex)
        {
            if (m_Filter.RequiresMatchesFilter)
            {
                beginIndex = GetIndexOfFirstEntityInCurrentChunk();
            }
            else
            {
                beginIndex = m_CurrentChunkEntityIndex + m_CurrentArchetypeEntityIndex;
            }

            endIndex = beginIndex + (*m_CurrentChunk)->Count;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        internal static BufferAccessor<T> GetChunkBufferAccessor<T>(Chunk* chunk, bool isWriting, int typeIndexInArchetype, uint systemVersion, AtomicSafetyHandle safety0, AtomicSafetyHandle safety1)
#else
        internal static BufferAccessor<T> GetChunkBufferAccessor<T>(Chunk* chunk, bool isWriting, int typeIndexInArchetype, uint systemVersion)
#endif
            where T : struct, IBufferElementData
        {
            var archetype = chunk->Archetype;
            int internalCapacity = archetype->BufferCapacities[typeIndexInArchetype];

            if (isWriting)
                chunk->SetChangeVersion(typeIndexInArchetype, systemVersion);

            var buffer = chunk->Buffer;
            var length = chunk->Count;
            var startOffset = archetype->Offsets[typeIndexInArchetype];
            int stride = archetype->SizeOfs[typeIndexInArchetype];
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            return new BufferAccessor<T>(buffer + startOffset, length, stride, !isWriting, safety0, safety1, internalCapacity);
#else
            return new BufferAccessor<T>(buffer + startOffset, length, stride, internalCapacity);
#endif
        }

        internal static void* GetChunkComponentDataPtr(Chunk* chunk, bool isWriting, int indexInArchetype, uint systemVersion)
        {
            var archetype = chunk->Archetype;

            if (isWriting)
                chunk->SetChangeVersion(indexInArchetype, systemVersion);

            return chunk->Buffer + archetype->Offsets[indexInArchetype];
        }

        public void* GetCurrentChunkComponentDataPtr(bool isWriting, int indexInEntityQuery)
        {
            int indexInArchetype = m_CurrentMatchingArchetype->IndexInArchetype[indexInEntityQuery];
            return GetChunkComponentDataPtr(*m_CurrentChunk, isWriting, indexInArchetype, m_GlobalSystemVersion);
        }

        public void UpdateChangeVersion()
        {
            int indexInArchetype = m_CurrentMatchingArchetype->IndexInArchetype[IndexInEntityQuery];
            (*m_CurrentChunk)->SetChangeVersion(indexInArchetype, m_GlobalSystemVersion);
        }

        public void MoveToEntityIndexAndUpdateCache(int index, out ComponentChunkCache cache, bool isWriting)
        {
            Assert.IsTrue(-1 != IndexInEntityQuery);
            MoveToEntityIndex(index);
            UpdateCacheToCurrentChunk(out cache, isWriting, IndexInEntityQuery);
        }

        internal ArchetypeChunk GetCurrentChunk()
        {
            return new ArchetypeChunk(*m_CurrentChunk, m_MatchingArchetypeList.entityComponentStore);
        }

        // Determines how many chunks of a particular archetype we must iterate through while filtering
        // If the chunk is in the current archetype, we can calculate # of iterations
        // If the chunk is not in the current archetype, just loop over all chunks in the current archetype
        private int CalculateFilteredIterationChunkCount(MatchingArchetype* match)
        {
            var archetype = match->Archetype;
            var chunkCount = match == m_CurrentMatchingArchetype ? m_CurrentChunkIndex : archetype->Chunks.Count;
            return chunkCount;
        }

        // todo: shouldn't be recalculating this for every chunk. Find a way to cache this.
        internal void GetFilteredChunkAndEntityIndices(out int chunkIndex, out int entityIndex)
        {
            if (!RequiresFilter())
            {
                chunkIndex = m_CurrentArchetypeIndex + m_CurrentChunkIndex;
                entityIndex = m_CurrentArchetypeEntityIndex + m_CurrentChunkEntityIndex;
                return;
            }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!(*m_CurrentChunk)->MatchesFilter(m_CurrentMatchingArchetype, ref m_Filter))
            {
                throw new InvalidOperationException("Trying to get chunk index and entity offset on a chunk that doesn't match the current filter");
            }
#endif

            chunkIndex = 0;
            entityIndex = 0;

            for(var m = m_FirstMatchingArchetypeIndex; m != m_CurrentMatchingArchetypeIndexNext; --m)
            {
                var match = m_MatchingArchetypeList.p[m];
                if (match->Archetype->EntityCount <= 0)
                    continue;

                var chunkCount = CalculateFilteredIterationChunkCount(match);
                var archetype = match->Archetype;

                for (var chunkIndexInArchetype = 0; chunkIndexInArchetype < chunkCount; ++chunkIndexInArchetype)
                {
                    var chunk = archetype->Chunks.p[chunkIndexInArchetype];
                    if (!chunk->MatchesFilter(match, ref m_Filter))
                        continue;

                    entityIndex += chunk->Count;
                    chunkIndex++;
                }
            }
        }

        internal int GetIndexOfFirstEntityInCurrentChunk()
        {
            var index = 0;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!(*m_CurrentChunk)->MatchesFilter(m_CurrentMatchingArchetype, ref m_Filter))
            {
                throw new InvalidOperationException("Trying to get chunk index and entity offset on a chunk that doesn't match the current filter");
            }
#endif

            for(var m = m_FirstMatchingArchetypeIndex; m != m_CurrentMatchingArchetypeIndexNext; --m)
            {
                var match = m_MatchingArchetypeList.p[m];
                if (match->Archetype->EntityCount <= 0)
                    continue;

                var chunkCount = CalculateFilteredIterationChunkCount(match);
                var archetype = match->Archetype;

                for (var chunkIndex = 0; chunkIndex < chunkCount; ++chunkIndex)
                {
                    var chunk = archetype->Chunks.p[chunkIndex];
                    if (!chunk->MatchesFilter(match, ref m_Filter))
                        continue;

                    index += chunk->Count;
                }
            }

            return index;
        }

        internal static JobHandle PreparePrefilteredChunkLists(int unfilteredChunkCount, MatchingArchetypeList archetypes, EntityQueryFilter filter, JobHandle dependsOn, ScheduleMode mode, out NativeArray<byte> prefilterDataArray, out void* deferredCountData)
        {
            // Allocate one buffer for all prefilter data and distribute it
            // We keep the full buffer as a "dummy array" so we can deallocate it later with [DeallocateOnJobCompletion]
            var sizeofChunkArray = sizeof(ArchetypeChunk) * unfilteredChunkCount;
            var sizeofIndexArray = sizeof(int) * unfilteredChunkCount;
            var prefilterDataSize = sizeofChunkArray + sizeofIndexArray + sizeof(int);

            var prefilterData = (byte*) UnsafeUtility.Malloc(prefilterDataSize, 64, Allocator.TempJob);
            prefilterDataArray =NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(prefilterData, prefilterDataSize, Allocator.TempJob);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref prefilterDataArray, AtomicSafetyHandle.Create());
#endif

            JobHandle prefilterHandle = default(JobHandle);

            if (filter.RequiresMatchesFilter)
            {
                var prefilteringJob = new GatherChunksAndOffsetsWithFilteringJob
                {
                    Archetypes = archetypes,
                    Filter = filter,
                    PrefilterData = prefilterData,
                    UnfilteredChunkCount = unfilteredChunkCount
                };
                if (mode == ScheduleMode.Batched)
                    prefilterHandle = prefilteringJob.Schedule(dependsOn);
                else
                    prefilteringJob.Run();
            }
            else
            {
                var gatherJob = new GatherChunksAndOffsetsJob
                {
                    Archetypes = archetypes,
                    PrefilterData = prefilterData,
                    UnfilteredChunkCount = unfilteredChunkCount,
                    entityComponentStore = archetypes.entityComponentStore
                };
                if (mode == ScheduleMode.Batched)
                    prefilterHandle = gatherJob.Schedule(dependsOn);
                else
                    gatherJob.Run();
            }

            // ScheduleParallelForDeferArraySize expects a ptr to a structure with a void* and a count.
            // It only uses the count, so this is safe to fudge
            deferredCountData = prefilterData + sizeofChunkArray + sizeofIndexArray;
            deferredCountData = (byte*)deferredCountData - sizeof(void*);

            return prefilterHandle;
        }
        
        internal static void UnpackPrefilterData(NativeArray<byte> prefilterData, out ArchetypeChunk* chunks, out int* entityOffsets, out int filteredChunkCount)
        {
            chunks = (ArchetypeChunk*) prefilterData.GetUnsafePtr();

            filteredChunkCount = *(int*)((byte*) prefilterData.GetUnsafePtr() + prefilterData.Length - sizeof(int));
            entityOffsets = (int*) (chunks + filteredChunkCount);
        }
    }
}
