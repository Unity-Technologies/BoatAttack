//#define LOG_DIFF_ALL
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;

namespace Unity.Entities
{
    public static class HashMapUtility
    {
        public static bool TryRemove<K, V>(this NativeMultiHashMap<K, V> h, K k, V v) where K : struct, IEquatable<K> where V : struct, IEquatable<V>
        {
            if (!h.TryGetFirstValue(k, out var candidate, out var iterator))
                return false;
            do
            {
                if (candidate.Equals(v))
                {
                    h.Remove(iterator);
                    return true;
                }
            } while (h.TryGetNextValue(out candidate, ref iterator));
            return false;
        }
    }

    public struct ComponentDiff
    {
        public int EntityIndex;
        public int TypeHashIndex;
    }

    [Serializable]
    public struct EntityGuid : IComponentData, IEquatable<EntityGuid>, IComparable<EntityGuid>
    {
        public ulong a;
        public ulong b;

        public static readonly EntityGuid Null = new EntityGuid();

        public static bool operator ==(EntityGuid lhs, EntityGuid rhs)
        {
            return lhs.a == rhs.a && lhs.b == rhs.b;
        }

        public static bool operator !=(EntityGuid lhs, EntityGuid rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            return obj is EntityGuid entityGuid ? Equals(entityGuid) : false;
        }

        public bool Equals(EntityGuid other)
        {
            return a == other.a && b == other.b;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (a.GetHashCode() * 397) ^ b.GetHashCode();
            }
        }

        public int CompareTo(EntityGuid other)
        {
            if (a != other.a)
                return a > other.a ? 1 : -1;

            if (b != other.b)
                return b > other.b ? 1 : -1;

            return 0;
        }

        public override string ToString()
        {
            return $"{a:x16}{b:x16}";
        }
    }

    public struct DataDiff
    {
        public int EntityIndex;
        public int TypeHashIndex;
        public int Offset;
        public int SizeBytes;

        public override string ToString()
        {
            return $"{EntityIndex} {TypeHashIndex} {Offset} {SizeBytes}";
        }
    }

    public struct LinkedEntityGroupAddition
    {
        public EntityGuid RootGuid;
        public EntityGuid ChildGuid;
    }

    public struct LinkedEntityGroupRemoval
    {
        public EntityGuid RootGuid;
        public EntityGuid ChildGuid;
    }

    public struct DiffEntityPatch
    {
        public int EntityIndex;
        public int TypeHashIndex;
        public EntityGuid Guid;
        public int Offset;
    }

    public struct SetSharedComponentDiff
    {
        public int EntityIndex;
        public int TypeHashIndex;
        public object BoxedSharedValue;
    }

    public static class DiffUtil
    {
        public static EntityQuery CreateAllChunksQuery(EntityManager manager)
        {
            var guidQuery = new[]
            {
                new EntityQueryDesc
                {
                    All = new ComponentType[] {typeof(EntityGuid)},
                    Options = EntityQueryOptions.IncludePrefab | EntityQueryOptions.IncludeDisabled
                }
            };

            return manager.CreateEntityQuery(guidQuery);
        }
        public static NativeArray<ArchetypeChunk> GetAllChunks(EntityManager manager)
        {
            var query = CreateAllChunksQuery(manager);

            var chunks = query.CreateArchetypeChunkArray(Allocator.TempJob);

            query.Dispose();

            return chunks;
        }
    }

    public struct WorldDiff : IDisposable
    {
        public NativeArray<ulong> TypeHashes;
        public NativeArray<EntityGuid> Entities;
        public NativeArray<NativeString64> EntityNames;
        public NativeArray<byte> ComponentPayload;

        // As consecutive counts in Entities
        public int NewEntityCount;
        public int DeletedEntityCount;

        public NativeArray<ComponentDiff> AddComponents;
        public NativeArray<ComponentDiff> RemoveComponents;
        public NativeArray<DataDiff> SetCommands;
        public NativeArray<DiffEntityPatch> EntityPatches;
        public SetSharedComponentDiff[] SharedSetCommands;

        public NativeArray<LinkedEntityGroupAddition> LinkedEntityGroupAdditions;
        public NativeArray<LinkedEntityGroupRemoval> LinkedEntityGroupRemovals;

        public void Dispose()
        {
            TypeHashes.Dispose();
            Entities.Dispose();
            EntityNames.Dispose();
            ComponentPayload.Dispose();
            AddComponents.Dispose();
            RemoveComponents.Dispose();
            SetCommands.Dispose();
            EntityPatches.Dispose();
            LinkedEntityGroupAdditions.Dispose();
            LinkedEntityGroupRemovals.Dispose();
        }


        public bool HasChanges
        {
            get
            {
                return NewEntityCount != 0 || DeletedEntityCount != 0 || AddComponents.Length != 0 || RemoveComponents.Length != 0
                       || SetCommands.Length != 0 || EntityPatches.Length != 0 || SharedSetCommands.Length != 0 || LinkedEntityGroupAdditions.Length != 0
                       || LinkedEntityGroupRemovals.Length != 0;
            }
        }
    }

    internal unsafe struct DiffEntityData
    {
        public Chunk* Chunk;
        public int Index;
    }

    internal unsafe struct DiffCreationData
    {
        public EntityGuid Guid;
        public Chunk* Chunk;
        public int Index;
    }

    internal unsafe struct DiffModificationData
    {
        public EntityGuid Guid;
        public Chunk* BeforeChunk;
        public int BeforeIndex;
        public Chunk* AfterChunk;
        public int AfterIndex;
    }

    public static unsafe class WorldDiffer
    {
        static ProfilerMarker m_Diff = new ProfilerMarker("Diff");
        static ProfilerMarker m_ApplyDiff = new ProfilerMarker("ApplyDiff");

        /// <summary>
        /// Calculate differences between previousStateShadowWorld and newState, and apply them to dstEntityWorld.
        /// All entities to be considered for diffing must have an EntityGuid component with a unique GUID.
        /// </summary>
        /// <remarks>
        /// previousShadowWorld must be a direct ancestor to the newState world, and must only be updated
        /// using this call or similar WorldDifffer methods.  No direct changes to previousStateShadowWorld are
        /// allowed.  After this call, previousShadowWorld will be updated to exactly match newState.
        /// </remarks>
        /// <param name="newState">The state to be updated to.</param>
        /// <param name="previousStateShadowWorld">The shadow world (previous state) of the current state world.</param>
        /// <param name="dstEntityWorld">The world to which to apply the updates to.</param>
        public static void DiffAndApply(World newState, World previousStateShadowWorld, World dstEntityWorld)
        {
            m_Diff.Begin();
            using (var diff = WorldDiffer.UpdateDiff(newState, previousStateShadowWorld, Allocator.TempJob))
            {
                m_Diff.End();

                m_ApplyDiff.Begin();
                ApplyDiff(dstEntityWorld, diff);
                m_ApplyDiff.End();
            }
        }

        /// <summary>
        /// Create a diff of changes between beforeWorld and afterWorld.  All entities to be considered for diffing
        /// must have an EntityGuid component with a unique GUID so that they can be matched between worlds.  The
        /// resulting WorldDiff must be Disposed when no longer needed.
        /// </summary>
        /// <param name="afterWorld">The world containing the new state.</param>
        /// <param name="beforeWorld">The world containing the old state.</param>
        /// <param name="resultAllocator">The allocator to use when allocating WorldDiff data.</param>
        /// <returns>A WorldDiff containing the differences between the two worlds.</returns>
        public static WorldDiff CreateDiff(World afterWorld, World beforeWorld, Allocator resultAllocator)
        {
            return CreateDiffAndMaybeUpdate(afterWorld, beforeWorld, calculateDiff: true, updateBeforeWorld: false, resultAllocator);
        }

        /// <summary>
        /// Create a diff of changes between beforeWorld and afterWorld, and efficiently update beforeWorld to
        /// match afterWorld.
        /// </summary>
        /// <remarks>
        /// UpdateDiff is only valid if beforeWorld was only ever updated via one of the WorldDiffer
        /// methods that updates the "before" world and no other changes have been done to it. All entities to be
        /// considered for diffing must have an EntityGuid component with a unique GUID so that they can be matched
        /// between worlds.  The resulting WorldDiff must be Disposed when no longer needed.
        /// </remarks>
        /// <param name="afterWorld">The world containing the new state.</param>
        /// <param name="beforeWorld">The world containing the old state.</param>
        /// <param name="resultAllocator">The allocator to use when allocating WorldDiff data.</param>
        /// <returns>A WorldDiff containing the differences between the two worlds.</returns>
        public static WorldDiff UpdateDiff(World afterWorld, World beforeWorld, Allocator resultAllocator)
        {
            return CreateDiffAndMaybeUpdate(afterWorld, beforeWorld, true, updateBeforeWorld: true, resultAllocator);
        }

        // Compute a diff between beforeWorld and afterWorld  (afterWorld == Source, beforeWorld == ShadowWorld/dest)
        // If updateBeforeWorld is true, beforeWorld must have only ever been updated via UpdateDiff or FastForward.
        internal static WorldDiff CreateDiffAndMaybeUpdate(World afterWorld, World beforeWorld, bool calculateDiff,
            bool updateBeforeWorld, Allocator resultAllocator)
        {
            if (afterWorld == null)
                throw new ArgumentNullException("afterWorld");

            if (beforeWorld == null)
                throw new ArgumentNullException("beforeWorld");

            if (resultAllocator == Allocator.Temp)
                throw new ArgumentException("Allocator can not be Allocator.Temp. Use Allocator.TempJob instead.");

            var afterEM = afterWorld.EntityManager;
            var beforeEM = beforeWorld.EntityManager;

            var afterChunks = DiffUtil.GetAllChunks(afterEM);
            var beforeChunks = DiffUtil.GetAllChunks(beforeEM);

            var visited = new NativeHashMap<ulong, byte>(afterChunks.Length * 3, Allocator.TempJob);
            var cloneList = new NativeList<IntPtr>(afterChunks.Length, Allocator.TempJob);
            var dropList = new NativeList<IntPtr>(afterChunks.Length, Allocator.TempJob);

            var afterState = new NativeHashMap<EntityGuid, DiffEntityData>(4096, Allocator.TempJob);
            var beforeState = new NativeHashMap<EntityGuid, DiffEntityData>(4096, Allocator.TempJob);

            var afterEntityToGuid = new NativeHashMap<Entity, EntityGuid>(4096, Allocator.TempJob);
            var afterGuidToEntity = new NativeHashMap<EntityGuid, Entity>(4096, Allocator.TempJob);

            var beforeEntityToGuid = new NativeHashMap<Entity, EntityGuid>(4096, Allocator.TempJob);
            var beforeChunkBySequenceNumber = new NativeHashMap<ulong, ArchetypeChunk>(4096, Allocator.TempJob);

            for (int i = 0; i < beforeChunks.Length; ++i)
            {
                beforeChunkBySequenceNumber.TryAdd(beforeChunks[i].m_Chunk->SequenceNumber, beforeChunks[i]);
            }

            for (int i = 0; i < afterChunks.Length; ++i)
            {
                Chunk* afterChunk = afterChunks[i].m_Chunk;
                
                ArchetypeChunk beforeArchetypeChunk;
                beforeChunkBySequenceNumber.TryGetValue(afterChunk->SequenceNumber, out beforeArchetypeChunk);
                Chunk* beforeChunk = beforeArchetypeChunk.m_Chunk;

                bool b = visited.TryAdd(afterChunk->SequenceNumber, 1);
                UnityEngine.Assertions.Assert.IsTrue(b);

                if (calculateDiff)
                {
                    CreateEntityToGuidLookup(afterChunk, afterEntityToGuid);
                    CreateGuidToEntityLookup(afterChunk, afterGuidToEntity);
                }

                if (beforeChunk == null)
                {
                    cloneList.Add((IntPtr) afterChunk);
                    if (calculateDiff)
                    {
                        AddChunkEntitiesToState(afterChunk, afterState);
                    }
                }
                else if (ChunkChanged(afterChunk, beforeChunk))
                {
                    cloneList.Add((IntPtr) afterChunk);
                    dropList.Add((IntPtr) beforeChunk);
                    if (calculateDiff)
                    {
                        AddChunkEntitiesToState(afterChunk, afterState);
                        AddChunkEntitiesToState(beforeChunk, beforeState);
                    }
                }
            }
            
            beforeChunkBySequenceNumber.Dispose();

            for (int i = 0; i < beforeChunks.Length; ++i)
            {
                Chunk* beforeChunk = beforeChunks[i].m_Chunk;

                if (calculateDiff)
                {
                    CreateEntityToGuidLookup(beforeChunk, beforeEntityToGuid);
                }

                byte ignored;
                if (!visited.TryGetValue(beforeChunk->SequenceNumber, out ignored))
                {
                    dropList.Add((IntPtr) beforeChunk);
                    if (calculateDiff)
                    {
                        AddChunkEntitiesToState(beforeChunk, beforeState);
                    }
                }
            }

            WorldDiff result = default;

            if (calculateDiff)
            {
                var removedEntities = new NativeList<EntityGuid>(1, Allocator.TempJob);
                var createdEntities = new NativeList<DiffCreationData>(1, Allocator.TempJob);
                var modifiedEntities = new NativeList<DiffModificationData>(1, Allocator.TempJob);

                ComputeEntityDiff(beforeState, afterState, removedEntities, createdEntities, modifiedEntities);

                var typeHashes = new NativeList<ulong>(1, Allocator.TempJob);
                var typeHashLookup = new NativeHashMap<int, int>(1, Allocator.TempJob);

                var entityList = new NativeList<EntityGuid>(1, Allocator.TempJob);
                var entityNameList = new NativeList<NativeString64>(1, Allocator.TempJob);
                var entityLookup = new NativeHashMap<EntityGuid, int>(1, Allocator.TempJob);

                var removeComponents = new NativeList<ComponentDiff>(1, Allocator.TempJob);
                var addComponents = new NativeList<ComponentDiff>(1, Allocator.TempJob);
                var dataDiffs = new NativeList<DataDiff>(1, Allocator.TempJob);
                var byteDiffs = new NativeList<byte>(1, Allocator.TempJob);
                var sharedDiffs = new List<SetSharedComponentDiff>();
                var entityPatches = new NativeList<DiffEntityPatch>(1, Allocator.TempJob);
                using (var linkedEntityGroupAdds = new NativeList<LinkedEntityGroupAddition>(1, Allocator.TempJob))
                using (var linkedEntityGroupRemoves = new NativeList<LinkedEntityGroupRemoval>(1, Allocator.TempJob))
                {

                    BuildAddComponents(createdEntities, typeHashes, typeHashLookup, addComponents, dataDiffs, byteDiffs,
                        entityList, entityLookup, sharedDiffs, afterEM.ManagedComponentStore, entityPatches,
                        afterEntityToGuid, linkedEntityGroupAdds);

                    BuildComponentDiff(modifiedEntities, typeHashes, typeHashLookup, removeComponents, addComponents,
                        linkedEntityGroupAdds, linkedEntityGroupRemoves, dataDiffs, sharedDiffs, byteDiffs, entityList,
                        entityLookup, afterEM.ManagedComponentStore, beforeEM.ManagedComponentStore,
                        entityPatches,
                        afterEntityToGuid, beforeEntityToGuid);

                    // Add removed entities to back of entity list
                    entityList.AddRange(removedEntities);

                    for (var i = 0; i < entityList.Length; ++i)
                    {
                        afterGuidToEntity.TryGetValue(entityList[i], out var entity);
                        var truncatedName = new NativeString64();
#if UNITY_EDITOR
                        var untruncatedName = afterEM.GetName(entity);
                        truncatedName.CopyFrom(untruncatedName);
#endif
                        entityNameList.Add(truncatedName);
                    }

                    // Build output data
                    result.TypeHashes = typeHashes.ToArray(resultAllocator);
                    result.Entities = entityList.ToArray(resultAllocator);
                    result.EntityNames = entityNameList.ToArray(resultAllocator);
                    result.NewEntityCount = createdEntities.Length;
                    result.DeletedEntityCount = removedEntities.Length;
                    result.AddComponents = addComponents.ToArray(resultAllocator);
                    result.RemoveComponents = removeComponents.ToArray(resultAllocator);
                    result.SetCommands = dataDiffs.ToArray(resultAllocator);
                    result.EntityPatches = entityPatches.ToArray(resultAllocator);
                    result.ComponentPayload = byteDiffs.ToArray(resultAllocator);
                    result.SharedSetCommands = sharedDiffs.ToArray();
                    result.LinkedEntityGroupAdditions = linkedEntityGroupAdds.ToArray(resultAllocator);
                    result.LinkedEntityGroupRemovals = linkedEntityGroupRemoves.ToArray(resultAllocator);

                    entityPatches.Dispose();
                    entityLookup.Dispose();
                    entityNameList.Dispose();
                    entityList.Dispose();
                    byteDiffs.Dispose();
                    dataDiffs.Dispose();
                    addComponents.Dispose();
                    removeComponents.Dispose();
                    typeHashLookup.Dispose();
                    typeHashes.Dispose();
                    modifiedEntities.Dispose();
                    createdEntities.Dispose();
                    removedEntities.Dispose();
                }
            }

            // If we're supposed to do the efficient update of the before world, perform
            // the chunk-level operations to do so.
            if (updateBeforeWorld)
            {
                var archetypeChanges =  beforeEM.EntityComponentStore->BeginArchetypeChangeTracking();

                // Drop all unused and modified chunks
                for (int i = 0; i < dropList.Length; ++i)
                {
                    EntityManagerMoveEntitiesUtility.DestroyChunkForDiffing((Chunk*) dropList[i],
                        beforeEM.EntityComponentStore, beforeEM.ManagedComponentStore);
                }

                // Clone all new and modified chunks
                for (int i = 0; i < cloneList.Length; ++i)
                {
                    EntityManagerMoveEntitiesUtility.CloneChunkForDiffing((Chunk*) cloneList[i],
                        afterEM.ManagedComponentStore,
                        beforeEM.EntityComponentStore, beforeEM.ManagedComponentStore);
                }
                
                var changedArchetypes =  beforeEM.EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                beforeEM.EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
            
            afterGuidToEntity.Dispose();
            afterEntityToGuid.Dispose();
            beforeEntityToGuid.Dispose();
            afterState.Dispose();
            beforeState.Dispose();
            visited.Dispose();
            dropList.Dispose();
            cloneList.Dispose();
            beforeChunks.Dispose();
            afterChunks.Dispose();

            return result;
        }

        public static UInt64 Ordinal(Entity e)
        {
            UInt64 result = 0;
            result |= (UInt32)e.Version;
            result <<= 32;
            result |= (UInt32)e.Index;
            return result;
        }

        struct EntitySorter : IComparer<Entity>
        {
            public int Compare(Entity x, Entity y)
            {
                if(Ordinal(x) < Ordinal(y))
                    return -1;
                if(Ordinal(x) > Ordinal(y))
                    return 1;
                return 0;
            }
        }

        static void BuildComponentDiff(NativeList<DiffModificationData> modifiedEntities,
            NativeList<ulong> typeHashes,
            NativeHashMap<int, int> typeHashLookup,
            NativeList<ComponentDiff> removeComponents,
            NativeList<ComponentDiff> addComponents,
            NativeList<LinkedEntityGroupAddition> linkedEntityGroupAdds,
            NativeList<LinkedEntityGroupRemoval> linkedEntityGroupRemoves,
            NativeList<DataDiff> dataDiffs,
            List<SetSharedComponentDiff> sharedComponentDiffs,
            NativeList<byte> byteDiffs,
            NativeList<EntityGuid> guidList,
            NativeHashMap<EntityGuid, int> guidToIndex,
            ManagedComponentStore ssharedComponentStore,
            ManagedComponentStore dsharedComponentStore,
            NativeList<DiffEntityPatch> entityPatches,
            NativeHashMap<Entity, EntityGuid> SrcWorldEntityToGuid,
            NativeHashMap<Entity, EntityGuid> DstWorldEntityToGuid)
        {
            var LinkedEntityGroupTypeIndex = TypeManager.GetTypeIndex<LinkedEntityGroup>();
            for (int i = 0; i < modifiedEntities.Length; ++i)
            {
                var mod = modifiedEntities[i];

                var beforeArch = mod.BeforeChunk->Archetype;
                var afterArch = mod.AfterChunk->Archetype;


                var entityIndex = GetExternalIndex(mod.Guid, guidList, guidToIndex);

                for (int afterType = 1; afterType < afterArch->TypesCount; ++afterType)
                {
                    var at = afterArch->Types[afterType];

                    int targetTypeIndex = at.TypeIndex;
                    var typeHashIndex = GetTypeHashIndex(targetTypeIndex, typeHashes, typeHashLookup);
                    int beforeType = ChunkDataUtility.GetIndexInTypeArray(beforeArch, afterArch->Types[afterType].TypeIndex);
                    if (-1 == beforeType)
                    {
                        addComponents.Add(new ComponentDiff {EntityIndex = entityIndex, TypeHashIndex = typeHashIndex});

                        if (at.IsSharedComponent)
                        {
                            // Also push through initial data wholesale.
                            object afterObject = GetSharedComponentObject(ssharedComponentStore, mod.AfterChunk, afterType, targetTypeIndex);
                            sharedComponentDiffs.Add(new SetSharedComponentDiff
                            {
                                BoxedSharedValue = afterObject,
                                EntityIndex = entityIndex,
                                TypeHashIndex = typeHashIndex,
                            });
                        }
                        else if (at.IsBuffer)
                        {
                            // Also push through initial data wholesale.
                            var afterHeader = (BufferHeader*)(mod.AfterChunk->Buffer + afterArch->Offsets[afterType] + afterArch->SizeOfs[afterType] * mod.AfterIndex);
                            var afterElements = afterHeader->Length;
                            var bytesPerElement = TypeManager.GetTypeInfo(at.TypeIndex).ElementSize;
                            var afterBytes = bytesPerElement * afterElements;
                            var afterElementPointer = BufferHeader.GetElementPointer(afterHeader);
                            if (at.TypeIndex == LinkedEntityGroupTypeIndex)
                            {
                                // magic in addcomponent already put a self-reference at the top of the buffer, so there's no need for us to add it.
                                // the rest of the elements should be interpreted as LinkedEntityGroupAdditions.
                                for(var a = 1; a < afterElements; ++a)
                                {
                                    var childEntity = ((Entity*)afterElementPointer)[a];
                                    var childEntityHasGuid = SrcWorldEntityToGuid.TryGetValue(childEntity, out var childEntityGuid);
                                    // if the child entity doesn't have a guid, there's no way for us to communicate its identity to the destination world.
                                    Assert.IsTrue(childEntityHasGuid);
                                    linkedEntityGroupAdds.Add(new LinkedEntityGroupAddition{RootGuid = mod.Guid, ChildGuid = childEntityGuid});
                                }
                            }
                            else
                            {
                                dataDiffs.Add(new DataDiff
                                {
                                    EntityIndex = entityIndex,
                                    Offset = 0,
                                    SizeBytes = afterBytes,
                                    TypeHashIndex = typeHashIndex
                                });
                                byteDiffs.AddRange(afterElementPointer, afterBytes);
                                ExtractGuidPatches(entityPatches, SrcWorldEntityToGuid, at, afterElementPointer, afterElements, entityIndex, typeHashIndex);
                            }
                        }
                        else
                        {
                            // Also push through initial data wholesale.
                            dataDiffs.Add(new DataDiff
                            {
                                EntityIndex = entityIndex,
                                Offset = 0,
                                SizeBytes = afterArch->SizeOfs[afterType],
                                TypeHashIndex = typeHashIndex
                            });
                            byte* afterAddress = mod.AfterChunk->Buffer + afterArch->Offsets[afterType] + afterArch->SizeOfs[afterType] * mod.AfterIndex;
                            byteDiffs.AddRange(afterAddress, afterArch->SizeOfs[afterType]);

                            ExtractGuidPatches(entityPatches, SrcWorldEntityToGuid, at, afterAddress, 1, entityIndex, typeHashIndex);
                        }

                        // Also check value
                        continue;
                    }

                    if (!at.IsSharedComponent && !at.IsBuffer && !at.IsZeroSized && !at.IsSystemStateComponent)
                    {
                        Assert.AreEqual(beforeArch->SizeOfs[beforeType], afterArch->SizeOfs[afterType]);

                        byte* beforeAddress = mod.BeforeChunk->Buffer + beforeArch->Offsets[beforeType] + beforeArch->SizeOfs[beforeType] * mod.BeforeIndex;
                        byte* afterAddress = mod.AfterChunk->Buffer + afterArch->Offsets[afterType] + afterArch->SizeOfs[afterType] * mod.AfterIndex;

                        var equals = ComponentEqualsWithEntityGuids(afterAddress, beforeAddress, targetTypeIndex, SrcWorldEntityToGuid, DstWorldEntityToGuid);

                        if (!equals)
                        {
                            // For now do full component replacement, because we need to dig into field information to make this work.
                            dataDiffs.Add(new DataDiff
                            {
                                EntityIndex = entityIndex,
                                Offset = 0,
                                SizeBytes = afterArch->SizeOfs[afterType],
                                TypeHashIndex = typeHashIndex
                            });

                            byteDiffs.AddRange(afterAddress, afterArch->SizeOfs[afterType]);

                            ExtractGuidPatches(entityPatches, SrcWorldEntityToGuid, at, afterAddress, 1, entityIndex, typeHashIndex);
                        }

                        continue;
                    }

                    if (at.IsSharedComponent)
                    {
                        object beforeObject = GetSharedComponentObject(dsharedComponentStore, mod.BeforeChunk, beforeType, targetTypeIndex);
                        object afterObject = GetSharedComponentObject(ssharedComponentStore, mod.AfterChunk, afterType, targetTypeIndex);

                        if (!TypeManager.Equals(beforeObject, afterObject, targetTypeIndex))
                        {
                            sharedComponentDiffs.Add(new SetSharedComponentDiff
                            {
                                BoxedSharedValue = afterObject,
                                EntityIndex = entityIndex,
                                TypeHashIndex = typeHashIndex,
                            });
                        }

                        continue;
                    }

                    if (at.IsBuffer)
                    {
                        Assert.AreEqual(beforeArch->SizeOfs[beforeType], afterArch->SizeOfs[afterType]);
                        var beforeHeader = (BufferHeader*) (mod.BeforeChunk->Buffer + beforeArch->Offsets[beforeType] + beforeArch->SizeOfs[beforeType] * mod.BeforeIndex);
                        var afterHeader = (BufferHeader*) (mod.AfterChunk->Buffer + afterArch->Offsets[afterType] + afterArch->SizeOfs[afterType] * mod.AfterIndex);
                        byte* beforeElementPointer = BufferHeader.GetElementPointer(beforeHeader);
                        byte* afterElementPointer = BufferHeader.GetElementPointer(afterHeader);
                        var beforeElements = beforeHeader->Length;
                        var afterElements = afterHeader->Length;
                        if (at.TypeIndex == LinkedEntityGroupTypeIndex)
                        {
                            using(var befores = new NativeArray<Entity>(beforeElements, Allocator.TempJob))
                            using (var afters = new NativeArray<Entity>(afterElements, Allocator.TempJob))
                            {
                                UnsafeUtility.MemCpy(befores.GetUnsafePtr(), beforeElementPointer, beforeElements * sizeof(Entity));
                                UnsafeUtility.MemCpy(afters.GetUnsafePtr(), afterElementPointer,afterElements * sizeof(Entity));
                                befores.Sort(new EntitySorter());
                                afters.Sort(new EntitySorter());
                                int b = 0;
                                int a = 0;
                                while (b < befores.Length && a < afters.Length)
                                {
                                    if (Ordinal(befores[b]) == Ordinal(afters[a])) // if Entity is in both "before" and "after", it's not added or deleted
                                    {
                                        ++a;
                                        ++b;
                                    }
                                    else if (Ordinal(befores[b]) < Ordinal(afters[a])) // if Entity is in "before" but not "after", it's been removed
                                    {
                                        var childHasGuid = SrcWorldEntityToGuid.TryGetValue(befores[b++], out var childGuid);
                                        Assert.IsTrue(childHasGuid);
                                        linkedEntityGroupRemoves.Add(new LinkedEntityGroupRemoval{RootGuid = mod.Guid, ChildGuid = childGuid});
                                    }
                                    else // if Entity is in "after" but not "before", it's been added
                                    {
                                        var childHasGuid = SrcWorldEntityToGuid.TryGetValue(afters[a++], out var childGuid);
                                        Assert.IsTrue(childHasGuid);
                                        linkedEntityGroupAdds.Add(new LinkedEntityGroupAddition{RootGuid = mod.Guid, ChildGuid = childGuid});
                                    }
                                }
                                while (b < befores.Length) // if Entity is in "before" but not "after", it's been removed
                                {
                                    var childHasGuid = SrcWorldEntityToGuid.TryGetValue(befores[b++], out var childGuid);
                                    Assert.IsTrue(childHasGuid);
                                    linkedEntityGroupRemoves.Add(new LinkedEntityGroupRemoval{RootGuid = mod.Guid, ChildGuid = childGuid});
                                }
                                while (a < afters.Length) // if Entity is in "after" but not "before", it's been added
                                {
                                    var childHasGuid = SrcWorldEntityToGuid.TryGetValue(afters[a++], out var childGuid);
                                    Assert.IsTrue(childHasGuid);
                                    linkedEntityGroupAdds.Add(new LinkedEntityGroupAddition{RootGuid = mod.Guid, ChildGuid = childGuid});
                                }
                            }
                        }
                        else
                        {
                            var bytesPerElement = TypeManager.GetTypeInfo(at.TypeIndex).ElementSize;
                            var afterElementBytes = afterElements * bytesPerElement;
                            if (beforeElements != afterElements ||
                                !ManagedComponentStore.FastEquality_CompareElements(beforeElementPointer,
                                    afterElementPointer, afterElements, at.TypeIndex))
                            {
                                dataDiffs.Add(new DataDiff
                                {
                                    EntityIndex = entityIndex,
                                    Offset = 0,
                                    SizeBytes = afterElementBytes,
                                    TypeHashIndex = typeHashIndex
                                });
                                byteDiffs.AddRange(afterElementPointer, afterElementBytes);
                                ExtractGuidPatches(entityPatches, SrcWorldEntityToGuid, at, afterElementPointer,
                                    afterElements,
                                    entityIndex, typeHashIndex);
                            }
                        }
                        continue;
                    }
                }

                for (int beforeType = 1; beforeType < beforeArch->TypesCount; ++beforeType)
                {
                    int targetTypeIndex = beforeArch->Types[beforeType].TypeIndex;
                    if (-1 == ChunkDataUtility.GetIndexInTypeArray(afterArch, targetTypeIndex))
                    {
                        var typeHashIndex = GetTypeHashIndex(targetTypeIndex, typeHashes, typeHashLookup);
                        removeComponents.Add(new ComponentDiff {EntityIndex = entityIndex, TypeHashIndex = typeHashIndex});
                    }
                }
            }
        }

        // Compare two component instances; if they have internal Entity fields,
        // compare those by GUID to see if they point to the same entity or not.
        private static bool ComponentEqualsWithEntityGuids(
            byte* afterCompPtr, byte* beforeCompPtr, int typeIndex,
            NativeHashMap<Entity, EntityGuid> AfterWorldEntityToGuid,
            NativeHashMap<Entity, EntityGuid> BeforeWorldEntityToGuid)
        {
            // if the type has no entity references, then this is simple
            if (!TypeManager.HasEntityReferences(typeIndex))
            {
                return TypeManager.Equals(afterCompPtr, beforeCompPtr, typeIndex);
            }

            // If it does have entity references, first compare the data by ignoring the Entity fields.
            // This is done by saving them to savedEntities and temporarily setting them to null,
            // then redoing the comparison.
            var ft = TypeManager.GetTypeInfo(typeIndex);
            int AfterOffset = 0;
            int BeforeOffset = ft.EntityOffsetCount;

            var savedEntitiesArray = stackalloc Entity[ft.EntityOffsetCount * 2];
            {
                Entity* savedEntities = (Entity*) savedEntitiesArray;
                int runOffset = 0;
                int lastEntityOffset = 0;
                int sizeLeft = ft.SizeInChunk;
                byte* aptr = afterCompPtr;
                byte* bptr = beforeCompPtr;

                for (int ei = 0; ei < ft.EntityOffsetCount; ++ei)
                {
                    var entityOffset = ft.EntityOffsets[ei].Offset;
                    Assert.IsTrue(entityOffset >= lastEntityOffset);

                    int runSize = entityOffset - runOffset;
                    if (runSize > 0)
                    {
                        if (UnsafeUtility.MemCmp(afterCompPtr + runOffset, beforeCompPtr + runOffset, runSize) != 0)
                            return false;
                    }

                    savedEntities[AfterOffset + ei] = *(Entity*) (afterCompPtr + entityOffset);
                    savedEntities[BeforeOffset + ei] = *(Entity*) (beforeCompPtr + entityOffset);

                    // we just compared a run, plus skip the entity
                    sizeLeft -= (runSize + sizeof(Entity));
                    // next run start is just past the Entity field
                    runOffset = entityOffset + sizeof(Entity);
                }

                if (sizeLeft > 0)
                {
                    if (UnsafeUtility.MemCmp(afterCompPtr + runOffset, beforeCompPtr + runOffset, sizeLeft) != 0)
                        return false;
                }

                // everything is equal other than the entities.  Compare guids to see if they actually changed.
                for (int ei = 0; ei < ft.EntityOffsetCount; ++ei)
                {
                    EntityGuid afterGuid = EntityGuid.Null;
                    EntityGuid beforeGuid = EntityGuid.Null;
                    var afterEntity = savedEntities[AfterOffset + ei];
                    var beforeEntity = savedEntities[BeforeOffset + ei];

                    if (afterEntity != Entity.Null)
                    {
                        bool srcHasEntity = AfterWorldEntityToGuid.TryGetValue(afterEntity, out afterGuid);
                        // Bogus internal entity reference.  Return false to indicate a difference.
                        if (!srcHasEntity)
                            return false;
                    }

                    if (beforeEntity != Entity.Null)
                    {
                        bool dstHasEntity = BeforeWorldEntityToGuid.TryGetValue(beforeEntity, out beforeGuid);
                        // Bogus internal entity reference.  Return false to indicate a difference.
                        if (!dstHasEntity)
                            return false;
                    }

                    if (!afterGuid.Equals(beforeGuid))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void ExtractGuidPatches(NativeList<DiffEntityPatch> entityPatches, NativeHashMap<Entity, EntityGuid> allEntities, ComponentTypeInArchetype at, byte* afterAddress, int elementCount, int entityIndex, int typeHashIndex)
        {
            var ft = TypeManager.GetTypeInfo(at.TypeIndex);

            if(at.TypeIndex == TypeManager.GetTypeIndex<LinkedEntityGroup>())
                Debug.LogWarning("We should never attempt to extract guid patches from a LinkedEntityGroup.");

            if (ft.EntityOffsets == null)
                return;

            int elementOffset = 0;
            for (var element = 0; element < elementCount; ++element)
            {
            #if !NET_DOTS
                foreach (var eo in ft.EntityOffsets)
                {
            #else
                for(int i = 0; i < ft.EntityOffsetCount; ++i)
                {
                    var eo = UnsafeUtility.ReadArrayElement<TypeManager.EntityOffsetInfo>(ft.EntityOffsets, i);
            #endif

                    var offset = elementOffset + eo.Offset;
                    Entity* e = (Entity*) (afterAddress + offset);
                    EntityGuid guid;

                    if (!allEntities.TryGetValue(*e, out guid)) // if *e has no guid, then guid will be null (desired)
                        guid = EntityGuid.Null;
                    entityPatches.Add(new DiffEntityPatch
                    {
                        EntityIndex = entityIndex,
                        TypeHashIndex = typeHashIndex,
                        Offset = offset,
                        Guid = guid
                    });
                }

                elementOffset += ft.ElementSize;
            }
        }


#if !NET_DOTS
        static object GetSharedComponentObject(ManagedComponentStore managedComponentStore, Chunk* chunk, int typeIndexInArchetype, int targetTypeIndex)
        {
            int off = typeIndexInArchetype - chunk->Archetype->FirstSharedComponent;
            Assert.IsTrue((0 <= off) && (off < chunk->Archetype->NumSharedComponents));
            int sharedComponentIndex = chunk->GetSharedComponentValue(off);
            return managedComponentStore.GetSharedComponentDataBoxed(sharedComponentIndex, targetTypeIndex);
        }
#else
        static object GetSharedComponentObject(ManagedComponentStore managedComponentStore, Chunk* chunk, int typeIndexInArchetype, int targetTypeIndex)
        {
            return null;
        }
#endif

        static private void BuildAddComponents(NativeList<DiffCreationData> newEntities,
            NativeList<ulong> typeHashes,
            NativeHashMap<int, int> typeHashLookup,
            NativeList<ComponentDiff> addComponents,
            NativeList<DataDiff> dataDiffs,
            NativeList<byte> byteDiffs,
            NativeList<EntityGuid> guidList,
            NativeHashMap<EntityGuid, int> guidToIndex,
            List<SetSharedComponentDiff> sharedDiffs,
            ManagedComponentStore managedComponentStore,
            NativeList<DiffEntityPatch> entityPatches,
            NativeHashMap<Entity, EntityGuid> SrcWorldEntityToGuid,
            NativeList<LinkedEntityGroupAddition> LinkedEntityGroupAdds)
        {
            var LinkedEntityGroupTypeIndex = TypeManager.GetTypeIndex<LinkedEntityGroup>();
            for (int i = 0; i < newEntities.Length; ++i)
            {
                var ent = newEntities[i];

                var afterArch = ent.Chunk->Archetype;
                var entityIndex = GetExternalIndex(ent.Guid, guidList, guidToIndex);

                for (int afterType = 1; afterType < afterArch->TypesCount; ++afterType)
                {
                    var at = afterArch->Types[afterType];

                    if (at.IsSystemStateComponent)
                        continue;

                    int targetTypeIndex = at.TypeIndex;
                    var typeHashIndex = GetTypeHashIndex(targetTypeIndex, typeHashes, typeHashLookup);
                    addComponents.Add(new ComponentDiff {EntityIndex = entityIndex, TypeHashIndex = typeHashIndex});

                    //@TODO: BuildComponentDiff is copy pasta..
                    if (!at.IsBuffer && !at.IsSharedComponent && !at.IsZeroSized)
                    {
                        // Also push through initial data wholesale.
                        dataDiffs.Add(new DataDiff
                        {
                            EntityIndex = entityIndex,
                            Offset = 0,
                            SizeBytes = afterArch->SizeOfs[afterType],
                            TypeHashIndex = typeHashIndex
                        });

                        byte* src = ent.Chunk->Buffer + afterArch->Offsets[afterType] + ent.Index * afterArch->SizeOfs[afterType];
                        byteDiffs.AddRange(src, afterArch->SizeOfs[afterType]);

                        ExtractGuidPatches(entityPatches, SrcWorldEntityToGuid, at, src, 1, entityIndex, typeHashIndex);
                    }
                    else if (at.IsSharedComponent)
                    {
                        object o = GetSharedComponentObject(managedComponentStore, ent.Chunk, afterType, targetTypeIndex);
                        sharedDiffs.Add(new SetSharedComponentDiff
                        {
                            EntityIndex = entityIndex,
                            TypeHashIndex = typeHashIndex,
                            BoxedSharedValue = o
                        });
                    }
                    else if (at.IsBuffer)
                    {
                        BufferHeader* afterHeader = (BufferHeader*)(ent.Chunk->Buffer + afterArch->Offsets[afterType] + ent.Index * afterArch->SizeOfs[afterType]);
                        var bytesPerElement = TypeManager.GetTypeInfo(at.TypeIndex).ElementSize;
                        var afterElements = afterHeader->Length;
                        var afterElementBytes = bytesPerElement * afterElements;
                        byte* afterElementPointer = BufferHeader.GetElementPointer(afterHeader);
                        if (at.TypeIndex == LinkedEntityGroupTypeIndex)
                        {
                            // magic in addcomponent already put a self-reference at the top of the buffer, so there's no need for us to add it.
                            // the rest of the elements should be interpreted as LinkedEntityGroupAdditions.
                            for(var a = 1; a < afterElements; ++a)
                            {
                                var childEntity = ((Entity*)afterElementPointer)[a];
                                var childEntityHasGuid = SrcWorldEntityToGuid.TryGetValue(childEntity, out var childEntityGuid);
                                // if the child entity doesn't have a guid, there's no way for us to communicate its identity to the destination world.
                                Assert.IsTrue(childEntityHasGuid);
                                LinkedEntityGroupAdds.Add(new LinkedEntityGroupAddition{RootGuid = ent.Guid, ChildGuid = childEntityGuid});
                            }
                        }
                        else
                        {
                            dataDiffs.Add(new DataDiff
                            {
                                EntityIndex = entityIndex,
                                Offset = 0,
                                SizeBytes = afterElementBytes,
                                TypeHashIndex = typeHashIndex
                            });
                            byteDiffs.AddRange(afterElementPointer, afterElementBytes);
                            ExtractGuidPatches(entityPatches, SrcWorldEntityToGuid, at, afterElementPointer,
                                afterElements, entityIndex, typeHashIndex);
                        }
                    }
                }
            }
        }

        static int GetTypeHashIndex(int targetTypeIndex, NativeList<ulong> typeHashes, NativeHashMap<int, int> typeHashLookup)
        {
            int result;
            if (!typeHashLookup.TryGetValue(targetTypeIndex, out result))
            {
                result = typeHashes.Length;
                typeHashes.Add(TypeManager.GetTypeInfo(targetTypeIndex).StableTypeHash);
                typeHashLookup.TryAdd(targetTypeIndex, result);
            }
            return result;
        }

        static int GetExternalIndex(EntityGuid guid, NativeList<EntityGuid> guidList, NativeHashMap<EntityGuid, int> guidToIndex)
        {
            int result;
            if (!guidToIndex.TryGetValue(guid, out result))
            {
                result = guidList.Length;
                guidList.Add(guid);
                guidToIndex.TryAdd(guid, result);
            }
            return result;
        }

        static void ComputeEntityDiff(
            NativeHashMap<EntityGuid, DiffEntityData> beforeState,
            NativeHashMap<EntityGuid, DiffEntityData> afterState,
            NativeList<EntityGuid> removedEntities,
            NativeList<DiffCreationData> createdEntities,
            NativeList<DiffModificationData> modifiedEntities)
        {
            NativeArray<EntityGuid> beforeGuids = beforeState.GetKeyArray(Allocator.Temp);
            NativeArray<EntityGuid> afterGuids = afterState.GetKeyArray(Allocator.Temp);

            Assert.AreEqual(beforeGuids.Length, beforeState.Length);
            Assert.AreEqual(afterGuids.Length, afterState.Length);

            beforeGuids.Sort();
            afterGuids.Sort();

            int ai = 0;
            int bi = 0;

            while (ai < afterGuids.Length && bi < beforeGuids.Length)
            {
                EntityGuid aguid = afterGuids[ai];
                EntityGuid bguid = beforeGuids[bi];

                int c = bguid.CompareTo(aguid);
                if (c < 0)
                {
                    removedEntities.Add(bguid);
                    ++bi;
                }
                else if (c == 0)
                {
                    DiffEntityData afterData;
                    DiffEntityData beforeData;
                    bool b = afterState.TryGetValue(aguid, out afterData);
                    Assert.IsTrue(b);
                    b = beforeState.TryGetValue(bguid, out beforeData);
                    Assert.IsTrue(b);

                    modifiedEntities.Add(new DiffModificationData
                    {
                        Guid = bguid,
                        AfterChunk = afterData.Chunk,
                        AfterIndex = afterData.Index,
                        BeforeChunk = beforeData.Chunk,
                        BeforeIndex = beforeData.Index,
                    });
                    ++ai;
                    ++bi;
                }
                else
                {
                    DiffEntityData d;
                    bool b = afterState.TryGetValue(aguid, out d);
                    Assert.IsTrue(b);
                    createdEntities.Add(new DiffCreationData {Chunk = d.Chunk, Guid = aguid, Index = d.Index});
                    ++ai;
                }
            }

            while (bi < beforeGuids.Length)
            {
                removedEntities.Add(beforeGuids[bi]);
                ++bi;
            }

            while (ai < afterGuids.Length)
            {
                DiffEntityData d;
                bool b = afterState.TryGetValue(afterGuids[ai], out d);
                Assert.IsTrue(b);
                createdEntities.Add(new DiffCreationData {Chunk = d.Chunk, Guid = afterGuids[ai], Index = d.Index});
                ++ai;
            }

            afterGuids.Dispose();
            beforeGuids.Dispose();
        }

        static void CreateEntityToGuidLookup(Chunk* c, NativeHashMap<Entity, EntityGuid> lookup)
        {
            var arch = c->Archetype;
            Entity* entities = (Entity*) (c->Buffer + arch->Offsets[0]);

            // Find EntityGuid type index
            int guidTypeIndex = TypeManager.GetTypeIndex<EntityGuid>();
            int guidIndex = 0;

            for (int i = 1; i < arch->TypesCount; ++i)
            {
                if (arch->Types[i].TypeIndex == guidTypeIndex)
                {
                    guidIndex = i;
                    break;
                }
            }

            Assert.IsTrue(guidIndex > 0);
            EntityGuid* guids = (EntityGuid*) (c->Buffer + arch->Offsets[guidIndex]);

            for (int i = 0; i < c->Count; ++i)
            {
                lookup.TryAdd(entities[i], guids[i]);
            }
        }

        static void CreateGuidToEntityLookup(Chunk* c, NativeHashMap<EntityGuid, Entity> lookup)
        {
            var arch = c->Archetype;
            Entity* entities = (Entity*) (c->Buffer + arch->Offsets[0]);

            // Find EntityGuid type index
            int guidTypeIndex = TypeManager.GetTypeIndex<EntityGuid>();
            int guidIndex = 0;

            for (int i = 1; i < arch->TypesCount; ++i)
            {
                if (arch->Types[i].TypeIndex == guidTypeIndex)
                {
                    guidIndex = i;
                    break;
                }
            }

            Assert.IsTrue(guidIndex > 0);
            EntityGuid* guids = (EntityGuid*) (c->Buffer + arch->Offsets[guidIndex]);

            for (int i = 0; i < c->Count; ++i)
            {
                lookup.TryAdd(guids[i], entities[i]);
            }
        }

        static void AddChunkEntitiesToState(Chunk* c, NativeHashMap<EntityGuid, DiffEntityData> state)
        {
            var arch = c->Archetype;

            // Find EntityGuid type index
            int guidTypeIndex = TypeManager.GetTypeIndex<EntityGuid>();
            int guidIndex = 0;

            for (int i = 1; i < arch->TypesCount; ++i)
            {
                if (arch->Types[i].TypeIndex == guidTypeIndex)
                {
                    guidIndex = i;
                    break;
                }
            }

            Assert.IsTrue(guidIndex > 0);

            EntityGuid* ptr = (EntityGuid*) (c->Buffer + arch->Offsets[guidIndex]);

            for (int i = 0; i < c->Count; ++i)
            {
                var item = new DiffEntityData { Chunk = c, Index = i };
                state.TryAdd(ptr[i], item);
            }
        }

        static bool ChunkChanged(Chunk* sourceChunk, Chunk* destChunk)
        {
            int archCount = sourceChunk->Archetype->TypesCount;

            for (int ti = 0; ti < archCount; ++ti)
            {
                if (sourceChunk->GetChangeVersion(ti) != destChunk->GetChangeVersion(ti))
                {
                    return true;
                }
            }

            return false;
        }

        [BurstCompile]
        struct BuildDestWorldGuidLookups : IJobChunk
        {
            public NativeMultiHashMap<EntityGuid, Entity>.Concurrent GuidToDestWorldEntity;
            public NativeHashMap<Entity,EntityGuid>.Concurrent DestWorldEntityToGuid;

            [ReadOnly] public ArchetypeChunkComponentType<EntityGuid> EntityGUID;
            [ReadOnly] public ArchetypeChunkEntityType                Entity;

            public void Execute(ArchetypeChunk chunk, int entityIndex, int chunkIndex)
            {
                var guids = chunk.GetNativeArray(EntityGUID);
                var entities = chunk.GetNativeArray(Entity);
                for (int i = 0; i != entities.Length; i++)
                {
                    GuidToDestWorldEntity.Add(guids[i], entities[i]);
                    DestWorldEntityToGuid.TryAdd(entities[i], guids[i]);
                }
            }
        }

        [BurstCompile]
        struct BuildDestWorldPrefabLookups : IJobChunk
        {
            public NativeHashMap<EntityGuid, Entity>.Concurrent GuidToDestWorldPrefabEntity;

            [ReadOnly] public ArchetypeChunkComponentType<EntityGuid> EntityGUID;
            [ReadOnly] public ArchetypeChunkEntityType                Entity;

            public void Execute(ArchetypeChunk chunk, int entityIndex, int chunkIndex)
            {
                var guids = chunk.GetNativeArray(EntityGUID);
                var entities = chunk.GetNativeArray(Entity);
                for (int i = 0; i != entities.Length; i++)
                    GuidToDestWorldPrefabEntity.TryAdd(guids[i], entities[i]);
            }
        }

        struct BuildEntityToRootEntityLookup : IJobChunk
        {
            public NativeHashMap<Entity,Entity>.Concurrent EntityToRootEntity;

            [ReadOnly] public ArchetypeChunkBufferType<LinkedEntityGroup> LinkedEntityGroup;
            public void Execute(ArchetypeChunk chunk, int entityIndex, int chunkIndex)
            {
                var linkedEntityGroups = chunk.GetBufferAccessor(LinkedEntityGroup);
                for (int i = 0; i != linkedEntityGroups.Length; i++)
                {
                    var linkedEntityGroup = linkedEntityGroups[i];
                    for (int j = 0; j != linkedEntityGroup.Length; ++j)
                        EntityToRootEntity.TryAdd(linkedEntityGroup[j].Value, linkedEntityGroup[0].Value);
                }
            }
        }

#if !UNITY_DOTSPLAYER
        [DebuggerTypeProxy(typeof(DiffApplierDebugView))]
#endif
        internal struct DiffApplier : IDisposable
        {
            static ProfilerMarker s_AllocateLookups = new ProfilerMarker("DiffApplier.AllocateLookups");
            static ProfilerMarker s_BuildDestWorldLookups = new ProfilerMarker("DiffApplier.BuildDestWorldLookups");
            static ProfilerMarker s_BuildDiffToDestWorldLookups = new ProfilerMarker("DiffApplier.BuildDiffToDestWorldLookups");
            static ProfilerMarker s_CreateEntities = new ProfilerMarker("DiffApplier.CreateEntities");
            static ProfilerMarker s_DestroyEntities = new ProfilerMarker("DiffApplier.DestroyEntities");
            static ProfilerMarker s_AddComponents = new ProfilerMarker("DiffApplier.AddComponents");
            static ProfilerMarker s_RemoveComponents = new ProfilerMarker("DiffApplier.RemoveComponents");
            static ProfilerMarker s_SetSharedComponents = new ProfilerMarker("DiffApplier.SetSharedComponents");
            static ProfilerMarker s_SetComponents = new ProfilerMarker("DiffApplier.SetComponents");
            static ProfilerMarker s_ApplyLinkedEntityGroupAdds = new ProfilerMarker("DiffApplier.ApplyLinkedEntityGroupAdds");
            static ProfilerMarker s_ApplyLinkedEntityGroupRemoves = new ProfilerMarker("DiffApplier.ApplyLinkedEntityGroupRemoves");
            static ProfilerMarker s_PatchEntities = new ProfilerMarker("DiffApplier.PatchEntities");

            // World to which we apply the diff
            internal World destWorld;

            // Diff which we apply to World dest
            internal WorldDiff diff;

            // EntityManager for the dest World
            internal EntityManager DestWorldManager;

            // For each diff entity index, which entities in the dest world have the same guid?
            internal NativeMultiHashMap<int, Entity> DiffIndexToDestWorldEntities;

            // For each diff type index, which dest world component type corresponds to it?
            internal NativeArray<ComponentType> DiffIndexToDestWorldTypes;

            // For each dest world entity that has a guid, which guid does it have?
            internal NativeHashMap<Entity, EntityGuid> DestWorldEntityToGuid;

            // For each guid in the dest world, which entities have that guid (there may be many!)?
            internal NativeMultiHashMap<EntityGuid, Entity> GuidToDestWorldEntity;

            // For each dest world entity, what is its root entity?
            internal NativeHashMap<Entity, Entity> DestWorldEntityToRootEntity;

            // For a given GUID, what is the Prefab in the dest world, if any, that corresponds to it?
            internal NativeHashMap<EntityGuid, Entity> GuidToDestWorldPrefabEntity;

            internal int DestWorldEntitiesWithGuids;
            internal int DestWorldEntitiesWithLinkedEntityGroups;

            public void Dispose()
            {
                DiffIndexToDestWorldEntities.Dispose();
                DiffIndexToDestWorldTypes.Dispose();
                GuidToDestWorldEntity.Dispose();
                DestWorldEntityToGuid.Dispose();
                DestWorldEntityToRootEntity.Dispose();
                GuidToDestWorldPrefabEntity.Dispose();
            }

            public DiffApplier(World dest_, WorldDiff diff_)
            {
                destWorld = dest_;
                diff = diff_;
                DestWorldManager = destWorld.EntityManager;
                DestWorldManager.CompleteAllJobs();
                DiffIndexToDestWorldEntities = default;
                DiffIndexToDestWorldTypes = default;
                DestWorldEntityToGuid = default;
                GuidToDestWorldEntity = default;
                GuidToDestWorldPrefabEntity = default;
                DestWorldEntityToRootEntity = default;
                DestWorldEntitiesWithGuids = 0;
                DestWorldEntitiesWithLinkedEntityGroups = 0;
            }

            public void Apply()
            {
                AllocateLookups();
                BuildDestWorldLookups();
                BuildDiffToDestWorldLookups();
                CreateEntities();
                SetDebugNames();
                DestroyEntities();
                AddComponents();
                RemoveComponents();
                SetSharedComponents();
                SetComponents();
                BuildDestWorldLookups();
                ApplyLinkedEntityGroupAdds();
                ApplyLinkedEntityGroupRemoves();
                PatchEntities();
            }

            void AllocateLookups()
            {
                s_AllocateLookups.Begin();
                var factor = 4;
                DiffIndexToDestWorldEntities = new NativeMultiHashMap<int, Entity>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);
                DiffIndexToDestWorldTypes = new NativeArray<ComponentType>(diff.TypeHashes.Length, Allocator.TempJob);

                DestWorldEntityToGuid = new NativeHashMap<Entity, EntityGuid>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);
                GuidToDestWorldEntity = new NativeMultiHashMap<EntityGuid, Entity>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);

                GuidToDestWorldPrefabEntity = new NativeHashMap<EntityGuid, Entity>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);
                DestWorldEntityToRootEntity = new NativeHashMap<Entity, Entity>(DestWorldEntitiesWithLinkedEntityGroups * factor, Allocator.TempJob);
                s_AllocateLookups.End();
            }

            // we need O(1) lookup for entity->guid and guid->entity in the dest world,
            // and for now this insanely expensive lookup table generator is how we get it.
            // no matter how small the diff is, this thing has a cost proportional to the
            // number of entities in the dest world that have guids.
            void BuildDestWorldLookups()
            {
                s_BuildDestWorldLookups.Begin();
                var guidQuery = new EntityQueryDesc
                {
                    All = new ComponentType[] {typeof(EntityGuid)},
                    Options = EntityQueryOptions.IncludeDisabled | EntityQueryOptions.IncludePrefab
                };
                
                var linkedEntityGroupQuery = new EntityQueryDesc
                {
                    All = new ComponentType[] {typeof(EntityGuid), typeof(LinkedEntityGroup)},
                    Options = EntityQueryOptions.IncludeDisabled | EntityQueryOptions.IncludePrefab
                };

                var guidPrefabQuery = new EntityQueryDesc
                {
                    All = new ComponentType[] {typeof(EntityGuid), typeof(Prefab)},
                    Options = EntityQueryOptions.IncludeDisabled | EntityQueryOptions.IncludePrefab
                };
                
                using (EntityQuery destChunksWithGuids = DestWorldManager.CreateEntityQuery(guidQuery))
                using (EntityQuery destChunksWithLinkedEntityGroups = DestWorldManager.CreateEntityQuery(linkedEntityGroupQuery))
                using (EntityQuery destchunksWithGuidAndPrefab = DestWorldManager.CreateEntityQuery(guidPrefabQuery))
                {
                    DestWorldEntitiesWithGuids = destChunksWithGuids.CalculateLength();
                    DestWorldEntitiesWithLinkedEntityGroups = destChunksWithLinkedEntityGroups.CalculateLength();

                    DestWorldEntityToGuid.Dispose();
                    GuidToDestWorldEntity.Dispose();
                    GuidToDestWorldPrefabEntity.Dispose();
                    DestWorldEntityToRootEntity.Dispose();
                    var factor = 4;
                    DestWorldEntityToGuid = new NativeHashMap<Entity, EntityGuid>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);
                    GuidToDestWorldEntity = new NativeMultiHashMap<EntityGuid, Entity>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);
                    GuidToDestWorldPrefabEntity = new NativeHashMap<EntityGuid, Entity>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);
                    DestWorldEntityToRootEntity = new NativeHashMap<Entity, Entity>(DestWorldEntitiesWithGuids * factor, Allocator.TempJob);

                    var buildDestWorldGuidLookups = new BuildDestWorldGuidLookups
                    {
                        GuidToDestWorldEntity = GuidToDestWorldEntity.ToConcurrent(),
                        DestWorldEntityToGuid = DestWorldEntityToGuid.ToConcurrent(),
                        Entity = DestWorldManager.GetArchetypeChunkEntityType(),
                        EntityGUID = DestWorldManager.GetArchetypeChunkComponentType<EntityGuid>(true)
                    };
                    var handle0 = buildDestWorldGuidLookups.Schedule(destChunksWithGuids);
                    var buildDestWorldGuidPrefabLookups = new BuildDestWorldPrefabLookups
                    {
                        GuidToDestWorldPrefabEntity = GuidToDestWorldPrefabEntity.ToConcurrent(),
                        Entity = DestWorldManager.GetArchetypeChunkEntityType(),
                        EntityGUID = DestWorldManager.GetArchetypeChunkComponentType<EntityGuid>(true)
                    };
                    var handle1 = buildDestWorldGuidPrefabLookups.Schedule(destchunksWithGuidAndPrefab);
                    var buildEntityToRootEntityLookup = new BuildEntityToRootEntityLookup
                    {
                        EntityToRootEntity = DestWorldEntityToRootEntity.ToConcurrent(),
                        LinkedEntityGroup = DestWorldManager.GetArchetypeChunkBufferType<LinkedEntityGroup>(true)
                    };
                    var handle2 = buildEntityToRootEntityLookup.Schedule(destChunksWithLinkedEntityGroups);

                    handle0.Complete();
                    handle1.Complete();
                    handle2.Complete();
                }
                DiffIndexToDestWorldEntities.Clear();
                for(var i = 0; i < diff.Entities.Length; ++i)
                {
                    var guid = diff.Entities[i];
                    if (GuidToDestWorldEntity.TryGetFirstValue(guid, out var destWorldEntity, out var iterator))
                    {
                        do
                        {
                            DiffIndexToDestWorldEntities.Add(i, destWorldEntity);
                        } while (GuidToDestWorldEntity.TryGetNextValue(out destWorldEntity, ref iterator));
                    }
                }
                s_BuildDestWorldLookups.End();
            }

            // here we build lookups to go from diff index, to dest world thing.
            // first, a lookup to go from diff guid index to dest world entities with that guid,
            // and then a lookup to go from diff type index to dest world componenttype.
            void BuildDiffToDestWorldLookups()
            {
                s_BuildDiffToDestWorldLookups.Begin();
                for (var i = 0; i < diff.TypeHashes.Length; ++i)
                {
                    var stableTypeHash = diff.TypeHashes[i];
                    var typeIndex = TypeManager.GetTypeIndexFromStableTypeHash(stableTypeHash);
                    var type = TypeManager.GetType(typeIndex);
                    DiffIndexToDestWorldTypes[i] = new ComponentType(type);
                }
                s_BuildDiffToDestWorldLookups.End();
            }

            void CreateEntities()
            {
                s_CreateEntities.Begin();
                var EntityGuidArchetype = DestWorldManager.CreateArchetype();
                using (var NewEntities = new NativeArray<Entity>(diff.NewEntityCount, Allocator.Temp))
                {
                    DestWorldManager.CreateEntity(EntityGuidArchetype, NewEntities);
                    for (var i = 0; i < diff.NewEntityCount; ++i)
                    {
                        DiffIndexToDestWorldEntities.Add(i, NewEntities[i]);
#if LOG_DIFF_ALL
                        Debug.Log($"CreateEntity({diff.Entities[i]}) -> {NewEntities[i]}");
#endif
                    }
                }
                s_CreateEntities.End();
            }

            void SetDebugNames()
            {
                for (var i = 0; i < diff.Entities.Length; ++i)
                {
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(i, out var entity, out var it))
                    {
                        do
                        {
#if UNITY_EDITOR
                            DestWorldManager.SetName(entity, diff.EntityNames[i].ToString());
#endif
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entity, ref it));
                    }
                }
            }

            void DestroyEntities()
            {
                s_DestroyEntities.Begin();
                int firstIndex = diff.Entities.Length - diff.DeletedEntityCount;
                for (var i = 0; i < diff.DeletedEntityCount; ++i)
                {
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(firstIndex + i, out var entity, out var iterator))
                    {
                        do
                        {
                            if (DestWorldManager.EntityComponentStore->Exists(entity))
                            {
#if LOG_DIFF_ALL
                                Debug.Log($"DestroyEntity({diff.Entities[firstIndex + i]})");
#endif
                                DestWorldManager.DestroyEntity(entity);
                            }
                            else
                            {
                                Debug.LogWarning($"DestroyEntity({diff.Entities[firstIndex + i]}) but it does not exist.");
                            }
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entity, ref iterator));
                    }
                }
                s_DestroyEntities.End();
            }

            void AddComponents()
            {
                s_AddComponents.Begin();
                var linkedEntityGroupTypeIndex = TypeManager.GetTypeIndex<LinkedEntityGroup>();

                foreach (var addition in diff.AddComponents)
                {
                    var componentType = DiffIndexToDestWorldTypes[addition.TypeHashIndex];
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(addition.EntityIndex, out var entity, out var iterator))
                    {
                        do
                        {
                            if (!DestWorldManager.EntityComponentStore->HasComponent(entity, componentType))
                            {
                                DestWorldManager.AddComponent(entity, componentType);
                                // magic is required to force the first entity in the LinkedEntityGroup to be the entity
                                // that owns the component. this magic doesn't seem to exist at a lower level, so let's
                                // shim it in here. we'll probably need to move the magic lower someday.
                                if (componentType.TypeIndex == linkedEntityGroupTypeIndex)
                                {
                                    var buffer = DestWorldManager.GetBuffer<LinkedEntityGroup>(entity);
                                    buffer.Add(entity);
                                }
                            }
                            else
                                Debug.LogWarning($"AddComponent({diff.Entities[addition.EntityIndex]}, {componentType}) but the component already exists.");
#if LOG_DIFF_ALL
                            Debug.Log($"AddComponent<{componentType}>({diff.Entities[addition.EntityIndex]}, {DestWorldManager.Debug.GetComponentBoxed(entity, componentType)})");
#endif
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entity, ref iterator));
                    }
                }
                s_AddComponents.End();
            }

            void RemoveComponents()
            {
                s_RemoveComponents.Begin();
                foreach (var removal in diff.RemoveComponents)
                {
                    var componentType = DiffIndexToDestWorldTypes[removal.TypeHashIndex];
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(removal.EntityIndex, out var entity, out var iterator))
                    {
                        do
                        {
                            DestWorldManager.RemoveComponent(entity, componentType);
#if LOG_DIFF_ALL
                            Debug.Log($"AddComponent<{componentType}>({diff.Entities[removal.EntityIndex]}).");
#endif
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entity, ref iterator));
                    }
                }
                s_RemoveComponents.End();
            }

            void SetSharedComponents()
            {
                s_SetSharedComponents.Begin();
                foreach (var shared in diff.SharedSetCommands)
                {
                    var componentType = DiffIndexToDestWorldTypes[shared.TypeHashIndex];
                    var componentData = shared.BoxedSharedValue;
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(shared.EntityIndex, out var entity, out var iterator))
                    {
                        do
                        {
                            if (!DestWorldManager.Exists(entity))
                                Debug.LogWarning($"SetComponent<{componentType}>({diff.Entities[shared.EntityIndex]}) but entity does not exist.");
                            else if (!DestWorldManager.HasComponent(entity, componentType))
                                Debug.LogWarning($"SetComponent<{componentType}>({diff.Entities[shared.EntityIndex]}) but component does not exist.");
                            else
                            {
                                DestWorldManager.SetSharedComponentDataBoxed(entity, componentType.TypeIndex, componentData);
#if LOG_DIFF_ALL
                                Debug.Log($"SetComponent<{componentType}>({diff.Entities[shared.EntityIndex]}, {componentData})");
#endif
                            }
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entity, ref iterator));
                    }
                }
                s_SetSharedComponents.End();
            }

            void SetComponents()
            {
                s_SetComponents.Begin();
                long readOffset = 0;
                foreach (var setting in diff.SetCommands)
                {
                    var data = (byte*) diff.ComponentPayload.GetUnsafePtr() + readOffset;
                    var size = setting.SizeBytes;
                    var componentType = DiffIndexToDestWorldTypes[setting.TypeHashIndex];
                    ComponentTypeInArchetype ctia = new ComponentTypeInArchetype(componentType);
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(setting.EntityIndex, out var entity, out var iterator))
                    {
                        do
                        {
                            if (!DestWorldManager.Exists(entity))
                                Debug.LogWarning($"SetComponent<{componentType}>({diff.Entities[setting.EntityIndex]}) but entity does not exist.");
                            else if (!DestWorldManager.HasComponent(entity, componentType))
                                Debug.LogWarning($"SetComponent<{componentType}>({diff.Entities[setting.EntityIndex]}) but component does not exist.");
                            else
                            {
                                if (ctia.IsZeroSized)
                                {
                                    // Nothing to set.
                                }
                                else if (!ctia.IsBuffer)
                                {
                                    var target = (byte*)DestWorldManager.GetComponentDataRawRW(entity, componentType.TypeIndex);
                                    UnsafeUtility.MemCpy(target + setting.Offset, data, size);
                                }
                                else
                                {
                                    var typeInfo = TypeManager.GetTypeInfo(ctia.TypeIndex);
                                    var elementSize = typeInfo.ElementSize;
                                    var lengthInElements = size / elementSize;
                                    var header = (BufferHeader*)DestWorldManager.GetComponentDataRawRW(entity, componentType.TypeIndex);
                                    BufferHeader.Assign(header, data, lengthInElements, elementSize, 16);
                                }
#if LOG_DIFF_ALL
                                Debug.Log($"SetComponent<{componentType}>({diff.Entities[setting.EntityIndex]}, {DestWorldManager.Debug.GetComponentBoxed(entity, componentType)})");
#endif
                            }
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entity, ref iterator));
                    }
                    readOffset += size;
                }
                s_SetComponents.End();
            }

            void PatchEntities()
            {
                s_PatchEntities.Begin();
                foreach (var patch in diff.EntityPatches)
                {
                    var typeOfComponentToPatch = DiffIndexToDestWorldTypes[patch.TypeHashIndex];
                    var guidToPatchTo = patch.Guid;
                    var byteOffsetInComponent = patch.Offset;
                    Entity entityToPatchTo;
                    var multipleEntitiesWithGuidToPatchToExistInDest = false;
                    if (guidToPatchTo.Equals(EntityGuid.Null))
                        entityToPatchTo = Entity.Null;
                    else
                    {
                        var guidToPatchToExistsInDestWorld = GuidToDestWorldEntity.TryGetFirstValue(guidToPatchTo, out entityToPatchTo, out var patchSourceIterator);
                        if (!guidToPatchToExistsInDestWorld)
                        {
                            Debug.LogWarning($"PatchEntities<{typeOfComponentToPatch}>({diff.Entities[patch.EntityIndex]}) but entity with guid-to-patch-to does not exist.");
                            continue;
                        }
                        multipleEntitiesWithGuidToPatchToExistInDest = GuidToDestWorldEntity.TryGetNextValue(out _, ref patchSourceIterator);
                    }
                    if (DiffIndexToDestWorldEntities.TryGetFirstValue(patch.EntityIndex, out var entityWhereComponentToPatchIs, out var patchDestinationIterator))
                    {
                        do
                        {
                            if (!DestWorldManager.Exists(entityWhereComponentToPatchIs))
                                Debug.LogWarning($"PatchEntities<{typeOfComponentToPatch}>({diff.Entities[patch.EntityIndex]}) but entity to patch does not exist.");
                            else if (!DestWorldManager.HasComponent(entityWhereComponentToPatchIs, typeOfComponentToPatch))
                                Debug.LogWarning($"PatchEntities<{typeOfComponentToPatch}>({diff.Entities[patch.EntityIndex]}) but component in entity to patch does not exist.");
                            else
                            {
                                // if just one entity has the GUID we're patching to, we can just use that entity.
                                // but if multiple entities have that GUID, we need to patch to the (one) entity that's in the destination entity's "group."
                                // that group is defined by a LinkedEntityGroup component on the destination entity's "root entity," which contains an array of entity references.
                                // the destination entity's "root entity" is defined by whatever entity owns the (one) LinkedEntityGroup that refers to the destination entity.
                                // so, we had to build a lookup table earlier, to take us from "destination entity" to "root entity of my group," so we can find this LinkedEntityGroup
                                // component, and riffle through it to find the (one) entity with the GUID we're looking for.
                                if (multipleEntitiesWithGuidToPatchToExistInDest)
                                {
                                    var entityWhereComponentToPatchIsHasARoot = DestWorldEntityToRootEntity.TryGetValue(entityWhereComponentToPatchIs, out var rootOfEntityWhereComponentToPatchIs);
                                    if (!entityWhereComponentToPatchIsHasARoot)
                                    {
                                        Debug.LogWarning(
                                            $"PatchEntities<{typeOfComponentToPatch}>({diff.Entities[patch.EntityIndex]}) but 2+ entities for GUID of entity-to-patch-to, and no root for entity-to-patch is, so we can't disambiguate.");
                                        continue;
                                    }
                                    var groupOfRootOfEntityWhereComponentToPatchIs = DestWorldManager.GetBuffer<LinkedEntityGroup>(rootOfEntityWhereComponentToPatchIs);
                                    for (var g = 0; g < groupOfRootOfEntityWhereComponentToPatchIs.Length; ++g)
                                        if(DestWorldEntityToGuid.TryGetValue(groupOfRootOfEntityWhereComponentToPatchIs[g].Value, out var guidOfEntityInRootGroup))
                                            if (guidOfEntityInRootGroup.Equals(guidToPatchTo))
                                            {
                                                entityToPatchTo = groupOfRootOfEntityWhereComponentToPatchIs[g].Value;
                                                break;
                                            }
                                }
                                if (typeOfComponentToPatch.IsBuffer)
                                {
                                    byte* pointer = (byte*) DestWorldManager.GetBufferRawRW(entityWhereComponentToPatchIs, typeOfComponentToPatch.TypeIndex);
                                    UnsafeUtility.MemCpy(pointer + byteOffsetInComponent, &entityToPatchTo, sizeof(Entity));
                                }
                                else
                                {
                                    byte* pointer = (byte*) DestWorldManager.GetComponentDataRawRW(entityWhereComponentToPatchIs, typeOfComponentToPatch.TypeIndex);
                                    UnsafeUtility.MemCpy(pointer + byteOffsetInComponent, &entityToPatchTo, sizeof(Entity));
                                }
#if LOG_DIFF_ALL
                                Debug.Log($"SetComponent_EntityPatch<{typeOfComponentToPatch}>({diff.Entities[patch.EntityIndex]}, {DestWorldManager.Debug.GetComponentBoxed(entityWhereComponentToPatchIs, typeOfComponentToPatch)})");
#endif
                            }
                        } while (DiffIndexToDestWorldEntities.TryGetNextValue(out entityWhereComponentToPatchIs, ref patchDestinationIterator));
                    }
                }
                s_PatchEntities.End();
            }

            struct Child
            {
                public Entity childEntity;
                public Entity rootEntity;
                public EntityGuid rootGuid;
                public EntityGuid childGuid;
            }

            void AddInstanceChildToTables(Child addition)
            {
                for(var i = 0; i < diff.Entities.Length; ++i)
                    if (diff.Entities[i].Equals(addition.childGuid))
                    {
                        DiffIndexToDestWorldEntities.Add(i, addition.childEntity);
                        break;
                    }
                DestWorldEntityToGuid.TryAdd(addition.childEntity,addition.childGuid);
                GuidToDestWorldEntity.Add(addition.childGuid, addition.childEntity);
                DestWorldEntityToRootEntity.TryAdd(addition.childEntity, addition.rootEntity);
            }

            void AddPrefabChildToTables(Child addition)
            {
                DestWorldEntityToRootEntity.TryAdd(addition.childEntity, addition.rootEntity);
            }

            void RemoveChildFromTables(Child removal)
            {
                for(var i = 0; i < diff.Entities.Length; ++i)
                    if (diff.Entities[i].Equals(removal.childGuid))
                    {
                        DiffIndexToDestWorldEntities.TryRemove(i, removal.childEntity);
                        break;
                    }
                DestWorldEntityToGuid.Remove(removal.childEntity);
                GuidToDestWorldEntity.TryRemove(removal.childGuid, removal.childEntity);
                DestWorldEntityToRootEntity.Remove(removal.childEntity);
            }

            void ApplyLinkedEntityGroupAdds()
            {
                s_ApplyLinkedEntityGroupAdds.Begin();
                using (var prefabChildren = new NativeList<Child>(Allocator.TempJob))
                using (var instanceChildren = new NativeList<Child>(Allocator.TempJob))
                {
                    for (var a = 0; a < diff.LinkedEntityGroupAdditions.Length; ++a)
                    {
                        var add = diff.LinkedEntityGroupAdditions[a];
                        // If we are asked to add a child to a linked entity group, then that child's guid must correspond to
                        // exactly one entity in the destination world that also has a Prefab component. Since we made a lookup
                        // from GUID to Prefab entity before, we can use it to find the specific entity we want.
                        if (GuidToDestWorldPrefabEntity.TryGetValue(add.ChildGuid, out var prefabEntityToInstantiate))
                        {
                            if (GuidToDestWorldEntity.TryGetFirstValue(add.RootGuid, out var rootEntity, out var iterator))
                            {
                                do
                                {
                                    if (rootEntity == prefabEntityToInstantiate)
                                    {
                                        Debug.LogWarning($"Trying to instantiate self as child???");
                                        continue;
                                    }
                                    if (DestWorldManager.HasComponent<Prefab>(rootEntity))
                                    {
                                        prefabChildren.Add(new Child{childEntity = prefabEntityToInstantiate, rootEntity = rootEntity, childGuid = add.ChildGuid, rootGuid = add.RootGuid});
                                        var group = DestWorldManager.GetBuffer<LinkedEntityGroup>(rootEntity);
                                        group.Add(prefabEntityToInstantiate);
                                    }
                                    else
                                    {
                                        var instantiatedEntity = DestWorldManager.Instantiate(prefabEntityToInstantiate);
                                        instanceChildren.Add(new Child{childEntity = instantiatedEntity, rootEntity = rootEntity, childGuid = add.ChildGuid, rootGuid = add.RootGuid});
                                        var group = DestWorldManager.GetBuffer<LinkedEntityGroup>(rootEntity);
                                        group.Add(instantiatedEntity);
                                    }
                                } while (GuidToDestWorldEntity.TryGetNextValue(out rootEntity, ref iterator));
                            }
                            else
                            {
                                Debug.LogWarning($"Tried to add a child to a linked entity group, but root entity didn't exist in destination world.");
                            }
                        }
                        else
                        {
                            Debug.LogWarning($"Tried to add a child to a linked entity group, but no such prefab exists in destination world.");
                        }
                    }
                    for (var a = 0; a < instanceChildren.Length; ++a)
                        AddInstanceChildToTables(instanceChildren[a]);
                    for (var a = 0; a < prefabChildren.Length; ++a)
                        AddPrefabChildToTables(prefabChildren[a]);
                }
                s_ApplyLinkedEntityGroupAdds.End();
            }

            void ApplyLinkedEntityGroupRemoves()
            {
                s_ApplyLinkedEntityGroupRemoves.Begin();
                using (var pending = new NativeList<Child>(Allocator.TempJob))
                {
                    for (var r = 0; r < diff.LinkedEntityGroupRemovals.Length; ++r)
                    {
                        var remove = diff.LinkedEntityGroupRemovals[r];
                        if (GuidToDestWorldEntity.TryGetFirstValue(remove.RootGuid, out var rootEntity, out var iterator))
                        {
                            do
                            {
                                var group = DestWorldManager.GetBuffer<LinkedEntityGroup>(rootEntity);
                                for (var g = 0; g < group.Length; ++g)
                                {
                                    var childEntity = group[g].Value;
                                    if (DestWorldEntityToGuid.TryGetValue(childEntity, out var childGuid) &&
                                        childGuid.Equals(remove.ChildGuid))
                                    {
                                        group.RemoveAt(g);
                                        pending.Add(new Child {childEntity = childEntity, rootEntity = rootEntity, childGuid = remove.ChildGuid, rootGuid = remove.RootGuid});
                                        DestWorldManager.DestroyEntity(childEntity);
                                        break;
                                    }
                                }

                                // if we got here without destroying an entity, then maybe the destination world destroyed it before we synced?
                                // not sure if that is a fatal error, or what.
                            } while (GuidToDestWorldEntity.TryGetNextValue(out rootEntity, ref iterator));
                        }
                    }
                    for (var a = 0; a < pending.Length; ++a)
                        RemoveChildFromTables(pending[a]);
                }
                s_ApplyLinkedEntityGroupRemoves.End();
            }
        }

        public static void ApplyDiff(World dest, WorldDiff diff)
        {
#if LOG_DIFF_ALL
            Debug.Log("--- Begin Apply diff ---- ");
#endif
            using(var applier = new DiffApplier(dest, diff))
                applier.Apply();
#if LOG_DIFF_ALL
            Debug.Log("--- End Apply diff ---- ");
#endif
        }
    }
}

