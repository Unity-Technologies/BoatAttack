using System;
using System.Diagnostics;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Profiling;
using Unity.Assertions;
using Unity.Mathematics;

// Notes on upcoming changes to EntityComponentStore:
//
// Checklist @macton Where is entityComponentStore and the EntityBatch interface going?
// [ ] Replace all internal interfaces to entityComponentStore to work with EntityBatch via entityComponentStore
//   [x] Convert AddComponent NativeArray<Entity> 
//   [x] Convert AddComponent NativeArray<ArchetypeChunk> 
//   [x] Convert AddSharedComponent NativeArray<ArchetypeChunk> 
//   [x] Convert AddChunkComponent NativeArray<ArchetypeChunk> 
//   [x] Move AddComponents(entity)
//   [ ] Need AddComponents for NativeList<EntityBatch>
//   [ ] Convert DestroyEntities
//   [ ] Convert RemoveComponent NativeArray<ArchetypeChunk>
//   [ ] Convert RemoveComponent Entity
// [x] EntityDataManager just becomes thin shim on top of EntityComponentStore
// [x] Remove EntityDataManager
// [ ] Rework internal storage so that structural changes are blittable (and burst job)
// [ ] Expose EntityBatch interface public via EntityManager
// [ ] Other structural interfaces (e.g. NativeArray<Entity>) are then (optional) utility functions.
//
// 1. Ideally EntityComponentStore is the internal interface that EntityCommandBuffer can use (fast).
// 2. That would be the only access point for JobComponentSystem.
// 3. "Easy Mode" can have (the equivalent) of EntityManager as utility functions on EntityComponentStore.
// 4. EntityDataManager goes away.
//
// Input data protocol to support for structural changes:
//    1. NativeList<EntityBatch>
//    2. NativeArray<ArchetypeChunk>
//    3. Entity
//
// Expected public (internal) API:
//
// ** Add Component **
//
// IComponentData and ISharedComponentData can be added via:
//    AddComponent NativeList<EntityBatch>
//    AddComponent Entity
//    AddComponents NativeList<EntityBatch>
//    AddComponents Entity
//
// Chunk Components can only be added via;
//    AddChunkComponent NativeArray<ArchetypeChunk>
//
// Alternative to add ISharedComponeentData when changing whole chunks.
//    AddSharedComponent NativeArray<ArchetypeChunk>
//
// ** Remove Component **
//
// Any component type can be removed via:
//    RemoveComponent NativeList<EntityBatch>
//    RemoveComponent Entity
//    RemoveComponent NativeArray<ArchetypeChunk>
//    RemoveComponents NativeList<EntityBatch>
//    RemoveComponents Entity
//    RemoveComponents NativeArray<ArchetypeChunk>


namespace Unity.Entities
{
    internal unsafe struct EntityComponentStore
    {
        [NativeDisableUnsafePtrRestriction]
        int* m_VersionByEntity;

        [NativeDisableUnsafePtrRestriction]
        Archetype** m_ArchetypeByEntity;
        
        [NativeDisableUnsafePtrRestriction]
        EntityInChunk* m_EntityInChunkByEntity;
        
#if UNITY_EDITOR
        [NativeDisableUnsafePtrRestriction]
        NumberedWords* m_NameByEntity;
#endif
        [NativeDisableUnsafePtrRestriction]
        int* m_ComponentTypeOrderVersion;

        ChunkAllocator m_ArchetypeChunkAllocator;

        internal ChunkList m_EmptyChunks;
        internal ArchetypeList m_Archetypes;

        ArchetypeListMap m_TypeLookup;
        
        ulong m_NextChunkSequenceNumber;
        
        int m_NextFreeEntityIndex;
        uint m_GlobalSystemVersion;
        int m_EntitiesCapacity; 
        uint m_ArchetypeTrackingVersion;

        const int kMaximumEmptyChunksInPool = 16; // can't alloc forever
        const int kDefaultCapacity = 1024;

        public int EntityOrderVersion => GetComponentTypeOrderVersion(TypeManager.GetTypeIndex<Entity>());
        public int EntitiesCapacity => m_EntitiesCapacity;
        public uint GlobalSystemVersion => m_GlobalSystemVersion;

        public void SetGlobalSystemVersion(uint value)
        {
            m_GlobalSystemVersion = value;
        }

        void IncreaseCapacity()
        {
            ReallocCapacity(m_EntitiesCapacity * 2);
        }

		// Capacity can never be decreased since entity lookups would start failing as a result
        internal void ReallocCapacity(int value)
        {
            if (value <= m_EntitiesCapacity)
                return;

            var versionBytes = (value * sizeof(int) + 63) & ~63;
            var archetypeBytes = (value * sizeof(Archetype*) + 63) & ~63;
            var chunkDataBytes = (value * sizeof(EntityInChunk) + 63) & ~63;
            var bytesToAllocate = versionBytes + archetypeBytes + chunkDataBytes;
#if UNITY_EDITOR
            var nameBytes = (value * sizeof(NumberedWords) + 63) & ~63;
            bytesToAllocate += nameBytes;
#endif

            var bytes = (byte*) UnsafeUtility.Malloc(bytesToAllocate, 64, Allocator.Persistent);

            var version = (int*) (bytes);
            var archetype = (Archetype**) (bytes + versionBytes);
            var chunkData = (EntityInChunk*) (bytes + versionBytes + archetypeBytes);
#if UNITY_EDITOR
            var name = (NumberedWords*) (bytes + versionBytes + archetypeBytes + chunkDataBytes);
#endif

            var startNdx = 0;
            if (m_EntitiesCapacity > 0)
            {
                UnsafeUtility.MemCpy(version, m_VersionByEntity, m_EntitiesCapacity * sizeof(int));
                UnsafeUtility.MemCpy(archetype, m_ArchetypeByEntity, m_EntitiesCapacity * sizeof(Archetype*));
                UnsafeUtility.MemCpy(chunkData, m_EntityInChunkByEntity, m_EntitiesCapacity * sizeof(EntityInChunk));
#if UNITY_EDITOR
                UnsafeUtility.MemCpy(name, m_NameByEntity, m_EntitiesCapacity * sizeof(NumberedWords));
#endif
                UnsafeUtility.Free(m_VersionByEntity, Allocator.Persistent);
                startNdx = m_EntitiesCapacity - 1;
            }

            m_VersionByEntity = version;
            m_ArchetypeByEntity = archetype;
            m_EntityInChunkByEntity = chunkData;
#if UNITY_EDITOR
            m_NameByEntity = name;
#endif

            m_EntitiesCapacity = value;
            InitializeAdditionalCapacity(startNdx);
        }
        
        private void InitializeAdditionalCapacity(int start)
        {
            for (var i = start; i != EntitiesCapacity; i++)
            {
                m_EntityInChunkByEntity[i].IndexInChunk = i + 1;
                m_VersionByEntity[i] = 1;
                m_EntityInChunkByEntity[i].Chunk = null;
#if UNITY_EDITOR
                m_NameByEntity[i] = new NumberedWords();
#endif
            }

            // Last entity indexInChunk identifies that we ran out of space...
            m_EntityInChunkByEntity[EntitiesCapacity - 1].IndexInChunk = -1;
        }

        public static EntityComponentStore* Create(ulong startChunkSequenceNumber, int newCapacity = kDefaultCapacity)
        {
            var entities = (EntityComponentStore*) UnsafeUtility.Malloc(sizeof(EntityComponentStore), 64, Allocator.Persistent);
            UnsafeUtility.MemClear(entities, sizeof(EntityComponentStore));

            entities->ReallocCapacity(newCapacity);
            entities->m_GlobalSystemVersion = ChangeVersionUtility.InitialGlobalSystemVersion;

            const int componentTypeOrderVersionSize = sizeof(int) * TypeManager.MaximumTypesCount;
            entities->m_ComponentTypeOrderVersion = (int*) UnsafeUtility.Malloc(componentTypeOrderVersionSize,
                UnsafeUtility.AlignOf<int>(), Allocator.Persistent);
            UnsafeUtility.MemClear(entities->m_ComponentTypeOrderVersion, componentTypeOrderVersionSize);
            
            entities->m_ArchetypeChunkAllocator = new ChunkAllocator();
            entities-> m_TypeLookup = new ArchetypeListMap();
            entities->m_TypeLookup.Init(16);
            entities->m_NextChunkSequenceNumber = startChunkSequenceNumber;
            entities->m_EmptyChunks = new ChunkList();
            entities->m_Archetypes = new ArchetypeList();

            // Sanity check a few alignments
#if UNITY_ASSERTIONS
            // Buffer should be 16 byte aligned to ensure component data layout itself can gurantee being aligned
            var offset = UnsafeUtility.GetFieldOffset(typeof(Chunk).GetField("Buffer"));
            Assert.IsTrue(offset % TypeManager.MaximumSupportedAlignment == 0, $"Chunk buffer must be {TypeManager.MaximumSupportedAlignment} byte aligned (buffer offset at {offset})");
            Assert.IsTrue(sizeof(Entity) == 8, $"Unity.Entities.Entity is expected to be 8 bytes in size (is {sizeof(Entity)}); if this changes, update Chunk explicit layout");
#endif
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var bufHeaderSize = UnsafeUtility.SizeOf<BufferHeader>();
            Assert.IsTrue(bufHeaderSize % TypeManager.MaximumSupportedAlignment == 0,
                $"BufferHeader total struct size must be a multiple of the max supported alignment ({TypeManager.MaximumSupportedAlignment})");
#endif

            return entities;
        }

        public static void Destroy(EntityComponentStore* entityComponentStore)
        {
            entityComponentStore->Dispose();
            UnsafeUtility.Free(entityComponentStore, Allocator.Persistent);
        }

        void Dispose()
        {
            if (m_EntitiesCapacity > 0)
            {
                UnsafeUtility.Free(m_VersionByEntity, Allocator.Persistent);

                m_VersionByEntity = null;
                m_ArchetypeByEntity = null;
                m_EntityInChunkByEntity = null;
#if UNITY_EDITOR
                m_NameByEntity = null;
#endif

                m_EntitiesCapacity = 0;
            }

            if (m_ComponentTypeOrderVersion != null)
            {
                UnsafeUtility.Free(m_ComponentTypeOrderVersion, Allocator.Persistent);
                m_ComponentTypeOrderVersion = null;
            }
            
            // Move all chunks to become pooled chunks
            for (var i = 0; i < m_Archetypes.Count; i++)
            {
                var archetype = m_Archetypes.p[i];

                for (int c = 0; c != archetype->Chunks.Count; c++)
                {
                    var chunk = archetype->Chunks.p[c];

                    ChunkDataUtility.DeallocateBuffers(chunk);
                    UnsafeUtility.Free(archetype->Chunks.p[c], Allocator.Persistent);
                }

                archetype->Chunks.Dispose();
                archetype->ChunksWithEmptySlotsUnsafePtrList.Dispose();
                archetype->FreeChunksBySharedComponents.Dispose();
            }

            ArchetypeUnsafePtrList.Dispose();

            // And all pooled chunks
            for (var i = 0; i != m_EmptyChunks.Count; ++i)
            {
                var chunk = m_EmptyChunks.p[i];
                UnsafeUtility.Free(chunk, Allocator.Persistent);
            }
            EmptyChunksUnsafePtrList.Dispose();

            m_TypeLookup.Dispose();
            m_ArchetypeChunkAllocator.Dispose();
        }
        
        public void FreeAllEntities()
        {
            for (var i = 0; i != EntitiesCapacity; i++)
            {
                m_EntityInChunkByEntity[i].IndexInChunk = i + 1;
                m_VersionByEntity[i] += 1;
                m_EntityInChunkByEntity[i].Chunk = null;
#if UNITY_EDITOR
                m_NameByEntity[i] = new NumberedWords();
#endif
            }

            // Last entity indexInChunk identifies that we ran out of space...
            m_EntityInChunkByEntity[EntitiesCapacity - 1].IndexInChunk = -1;
            m_NextFreeEntityIndex = 0;
        }

        public void FreeEntities(Chunk* chunk)
        {
            var count = chunk->Count;
            var entities = (Entity*) chunk->Buffer;
            int freeIndex = m_NextFreeEntityIndex;
            for (var i = 0; i != count; i++)
            {
                int index = entities[i].Index;
                m_VersionByEntity[index] += 1;
                m_EntityInChunkByEntity[index].Chunk = null;
                m_EntityInChunkByEntity[index].IndexInChunk = freeIndex;
#if UNITY_EDITOR
                m_NameByEntity[index] = new NumberedWords();
#endif
                freeIndex = index;
            }

            m_NextFreeEntityIndex = freeIndex;
        }

#if UNITY_EDITOR
        public string GetName(Entity entity)
        {
            return m_NameByEntity[entity.Index].ToString();
        }

        public void SetName(Entity entity, string name)
        {
            m_NameByEntity[entity.Index].SetString(name);
        }
#endif

        public Archetype* GetArchetype(Entity entity)
        {
            return m_ArchetypeByEntity[entity.Index];
        }
        
        public void SetArchetype(Entity entity, Archetype* archetype)
        {
            m_ArchetypeByEntity[entity.Index] = archetype;
        }

        public void SetArchetype(Chunk* chunk, Archetype* archetype)
        {
            var entities = (Entity*) chunk->Buffer;
            var count = chunk->Count;
            for (int i = 0; i < count; ++i)
            {
                m_ArchetypeByEntity[entities[i].Index] = archetype;
            }
        }

        public Chunk* GetChunk(Entity entity)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;

            return entityChunk;
        }
        
        public void SetEntityInChunk(Entity entity, EntityInChunk entityInChunk)
        {
            m_EntityInChunkByEntity[entity.Index] = entityInChunk;
        }
        
        public EntityInChunk GetEntityInChunk(Entity entity)
        {
            return m_EntityInChunkByEntity[entity.Index];
        }
        
        public void IncrementComponentTypeOrderVersion(Archetype* archetype)
        {
            // Increment type component version
            for (var t = 0; t < archetype->TypesCount; ++t)
            {
                var typeIndex = archetype->Types[t].TypeIndex;
                m_ComponentTypeOrderVersion[typeIndex & TypeManager.ClearFlagsMask]++;
            }
        }
        
        public bool Exists(Entity entity)
        {
            int index = entity.Index;

            ValidateEntity(entity);

            var versionMatches = m_VersionByEntity[index] == entity.Version;
            var hasChunk = m_EntityInChunkByEntity[index].Chunk != null;

            return versionMatches && hasChunk;
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void ValidateEntity(Entity entity)
        {
            if (entity.Index < 0)
                throw new ArgumentException(
                    $"All entities created using EntityCommandBuffer.CreateEntity must be realized via playback(). One of the entities is still deferred (Index: {entity.Index}).");
            if ((uint) entity.Index >= (uint) EntitiesCapacity)
                throw new ArgumentException("An Entity index is larger than the capacity of the EntityManager. This means the entity was created by a different world or the entity.Index got corrupted or incorrectly assigned and it may not be used on this EntityManager.");
        }
        
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public static void AssertArchetypeComponents(ComponentTypeInArchetype* types, int count)
        {
            if (count < 1)
                throw new ArgumentException($"Invalid component count");
            if (types[0].TypeIndex == 0)
                throw new ArgumentException($"Component type may not be null");
            if (types[0].TypeIndex != TypeManager.GetTypeIndex<Entity>())
                throw new ArgumentException($"The Entity ID must always be the first component");

            for (var i = 1; i < count; i++)
            {
                if (types[i - 1].TypeIndex == types[i].TypeIndex)
                    throw new ArgumentException(
                        $"It is not allowed to have two components of the same type on the same entity. ({types[i - 1]} and {types[i]})");
            }
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        public int CheckInternalConsistency()
        {
            var aliveEntities = 0;
            var entityType = TypeManager.GetTypeIndex<Entity>();

            for (var i = 0; i != EntitiesCapacity; i++)
            {
                var chunk = m_EntityInChunkByEntity[i].Chunk;
                if (chunk == null)
                    continue;

                aliveEntities++;
                var archetype = m_ArchetypeByEntity[i];
                Assert.AreEqual((IntPtr) archetype, (IntPtr) chunk->Archetype);
                Assert.AreEqual(entityType, archetype->Types[0].TypeIndex);
                var entity =
                    *(Entity*) ChunkDataUtility.GetComponentDataRO(m_EntityInChunkByEntity[i].Chunk,
                        m_EntityInChunkByEntity[i].IndexInChunk, 0);
                Assert.AreEqual(i, entity.Index);
                Assert.AreEqual(m_VersionByEntity[i], entity.Version);

                Assert.IsTrue(Exists(entity));
            }

            return aliveEntities;
        }
#endif

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertEntitiesExist(Entity* entities, int count)
        {
            for (var i = 0; i != count; i++)
            {
                var entity = entities + i;

                ValidateEntity(*entity);

                int index = entity->Index;
                var exists = m_VersionByEntity[index] == entity->Version && m_EntityInChunkByEntity[index].Chunk != null;
                if (!exists)
                    throw new ArgumentException(
                        "All entities passed to EntityManager must exist. One of the entities has already been destroyed or was never created.");
            }
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanDestroy(Entity* entities, int count)
        {
            for (var i = 0; i != count; i++)
            {
                var entity = entities + i;
                if (!Exists(*entity))
                    continue;

                int index = entity->Index;
                var chunk = m_EntityInChunkByEntity[index].Chunk;
                if (chunk->Locked || chunk->LockedEntityOrder)
                {
                    throw new InvalidOperationException(
                        "Cannot destroy entities in locked Chunks. Unlock Chunk first.");
                }
            }
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertEntityHasComponent(Entity entity, ComponentType componentType)
        {
            if (HasComponent(entity, componentType))
                return;

            if (!Exists(entity))
                throw new ArgumentException("The entity does not exist");

            throw new ArgumentException($"A component with type:{componentType} has not been added to the entity.");
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertEntityHasComponent(Entity entity, int componentType)
        {
            AssertEntityHasComponent(entity, ComponentType.FromTypeIndex(componentType));
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanAddComponent(Entity entity, ComponentType componentType)
        {
            if (!Exists(entity))
                throw new ArgumentException("The entity does not exist");

            if (!componentType.IgnoreDuplicateAdd && HasComponent(entity, componentType))
                throw new ArgumentException(
                    $"The component of type:{componentType} has already been added to the entity.");

            var chunk = GetChunk(entity);
            if (chunk->Locked || chunk->LockedEntityOrder)
                throw new InvalidOperationException("Cannot add components to locked Chunks. Unlock Chunk first.");
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanRemoveComponent(Entity entity, ComponentType componentType)
        {
            if (HasComponent(entity, componentType))
            {
                var chunk = GetChunk(entity);
                if (chunk->Locked || chunk->LockedEntityOrder)
                    throw new ArgumentException(
                        $"The component of type:{componentType} has already been added to the entity.");
            }
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanAddComponent(Entity entity, int componentType)
        {
            AssertCanAddComponent(entity, ComponentType.FromTypeIndex(componentType));
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanAddComponents(Entity entity, ComponentTypes types)
        {
            for (int i = 0; i < types.Length; ++i)
                AssertCanAddComponent(entity, ComponentType.FromTypeIndex(types.GetTypeIndex(i)));
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanRemoveComponents(Entity entity, ComponentTypes types)
        {
            for (int i = 0; i < types.Length; ++i)
                AssertCanRemoveComponent(entity, ComponentType.FromTypeIndex(types.GetTypeIndex(i)));
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanAddComponent(NativeArray<ArchetypeChunk> chunkArray, ComponentType componentType)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            for (int i = 0; i < chunkArray.Length; ++i)
            {
                var chunk = chunks[i].m_Chunk;
                if (ChunkDataUtility.GetIndexInTypeArray(chunk->Archetype, componentType.TypeIndex) != -1)
                    throw new ArgumentException(
                        $"A component with type:{componentType} has already been added to the chunk.");
                if (chunk->Locked)
                    throw new InvalidOperationException("Cannot add components to locked Chunks. Unlock Chunk first.");
                if (chunk->LockedEntityOrder && !componentType.IsZeroSized)
                    throw new InvalidOperationException(
                        "Cannot add non-zero sized components to LockedEntityOrder Chunks. Unlock Chunk first.");
            }
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanRemoveComponent(NativeArray<ArchetypeChunk> chunkArray, ComponentType componentType)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            for (int i = 0; i < chunkArray.Length; ++i)
            {
                var chunk = chunks[i].m_Chunk;
                if (ChunkDataUtility.GetIndexInTypeArray(chunk->Archetype, componentType.TypeIndex) != -1)
                {
                    if (chunk->Locked)
                        throw new InvalidOperationException(
                            "Cannot remove components from locked Chunks. Unlock Chunk first.");
                    if (chunk->LockedEntityOrder && !componentType.IsZeroSized)
                        throw new InvalidOperationException(
                            "Cannot remove non-zero sized components to LockedEntityOrder Chunks. Unlock Chunk first.");
                }
            }
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanDestroy(NativeArray<ArchetypeChunk> chunkArray)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            for (int i = 0; i < chunkArray.Length; ++i)
            {
                var chunk = chunks[i].m_Chunk;
                if (chunk->Locked)
                    throw new InvalidOperationException(
                        "Cannot destroy entities from locked Chunks. Unlock Chunk first.");
            }
        }


        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertWillDestroyAllInLinkedEntityGroup(NativeArray<ArchetypeChunk> chunkArray, ArchetypeChunkBufferType<LinkedEntityGroup> linkedGroupType)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            var chunksCount = chunkArray.Length;

            var tempChunkStateFlag = (uint) ChunkFlags.TempAssertWillDestroyAllInLinkedEntityGroup;
            for (int i = 0; i != chunksCount; i++)
            {
                var chunk = chunks[i].m_Chunk;
                Assert.IsTrue((chunk->Flags & tempChunkStateFlag) == 0);
                chunk->Flags |= tempChunkStateFlag;
            }

            string error = null;

            for (int i = 0; i < chunkArray.Length; ++i)
            {
                if (!chunks[i].Has(linkedGroupType))
                    continue;

                var chunk = chunks[i];
                var buffers = chunk.GetBufferAccessor(linkedGroupType);

                for (int b = 0; b != buffers.Length; b++)
                {
                    var buffer = buffers[b];
                    int entityCount = buffer.Length;
                    var entities = (Entity*) buffer.GetUnsafePtr();
                    for (int e = 0; e != entityCount; e++)
                    {
                        var referencedEntity = entities[e];
                        if (Exists(referencedEntity))
                        {
                            var referencedChunk = GetChunk(referencedEntity);

                            if ((referencedChunk->Flags & tempChunkStateFlag) == 0)
                                error = $"DestroyEntity(EntityQuery query) is destroying entity {entities[0]} which contains a LinkedEntityGroup and the entity {entities[e]} in that group is not included in the query. If you want to destroy entities using a query all linked entities must be contained in the query..";
                        }
                    }
                }
            }

            for (int i = 0; i != chunksCount; i++)
            {
                var chunk = chunks[i].m_Chunk;
                Assert.IsTrue((chunk->Flags & tempChunkStateFlag) != 0);
                chunk->Flags &= ~tempChunkStateFlag;
            }

            if (error != null)
                throw new ArgumentException(error);
        }
        
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void AssertCanAddChunkComponent(NativeArray<ArchetypeChunk> chunkArray, ComponentType componentType)
        {
            var chunks = (ArchetypeChunk*) chunkArray.GetUnsafeReadOnlyPtr();
            for (int i = 0; i < chunkArray.Length; ++i)
            {
                var chunk = chunks[i].m_Chunk;
                if (ChunkDataUtility.GetIndexInTypeArray(chunk->Archetype, componentType.TypeIndex) != -1)
                    throw new ArgumentException(
                        $"A chunk component with type:{componentType} has already been added to the chunk.");
                if (chunk->Locked)
                    throw new InvalidOperationException(
                        "Cannot add chunk components to locked Chunks. Unlock Chunk first.");
                if ((chunk->metaChunkEntity != Entity.Null) && GetChunk(chunk->metaChunkEntity)->Locked)
                    throw new InvalidOperationException(
                        "Cannot add chunk components if Meta Chunk is locked. Unlock Meta Chunk first.");
                if ((chunk->metaChunkEntity != Entity.Null) &&
                    GetChunk(chunk->metaChunkEntity)->LockedEntityOrder)
                    throw new InvalidOperationException(
                        "Cannot add chunk components if Meta Chunk is LockedEntityOrder. Unlock Meta Chunk first.");
            }
        }

        public int GetComponentTypeOrderVersion(int typeIndex)
        {
            return m_ComponentTypeOrderVersion[typeIndex & TypeManager.ClearFlagsMask];
        }

        public void IncrementGlobalSystemVersion()
        {
            ChangeVersionUtility.IncrementGlobalSystemVersion(ref m_GlobalSystemVersion);
        }

        public bool HasComponent(Entity entity, int type)
        {
            if (!Exists(entity))
                return false;

            var archetype = m_ArchetypeByEntity[entity.Index];
            return ChunkDataUtility.GetIndexInTypeArray(archetype, type) != -1;
        }

        public bool HasComponent(Entity entity, ComponentType type)
        {
            if (!Exists(entity))
                return false;

            var archetype = m_ArchetypeByEntity[entity.Index];
            return ChunkDataUtility.GetIndexInTypeArray(archetype, type.TypeIndex) != -1;
        }

        public int GetSizeInChunk(Entity entity, int typeIndex, ref int typeLookupCache)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            return ChunkDataUtility.GetSizeInChunk(entityChunk, typeIndex, ref typeLookupCache);
        }

        public void SetChunkComponent<T>(NativeList<EntityBatchInChunk> entityBatchList, T componentData)
            where T : struct, IComponentData
        {
            var type = ComponentType.ReadWrite<T>();
            if (type.IsZeroSized)
                return;

            for (int i = 0; i < entityBatchList.Length; i++)
            {
                var srcEntityBatch = entityBatchList[i];
                var srcChunk = srcEntityBatch.Chunk;
                if (!type.IsZeroSized)
                {
                    var ptr = GetComponentDataWithTypeRW(srcChunk->metaChunkEntity,
                        TypeManager.GetTypeIndex<T>(),
                        m_GlobalSystemVersion);
                    UnsafeUtility.CopyStructureToPtr(ref componentData, ptr);
                }
            }
        }

        public void AllocateEntities(Archetype* arch, Chunk* chunk, int baseIndex, int count, Entity* outputEntities)
        {
            Assert.AreEqual(chunk->Archetype->Offsets[0], 0);
            Assert.AreEqual(chunk->Archetype->SizeOfs[0], sizeof(Entity));

            var entityInChunkStart = (Entity*) chunk->Buffer + baseIndex;

            for (var i = 0; i != count; i++)
            {
                var entityIndexInChunk = m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk;
                if (entityIndexInChunk == -1)
                {
                    IncreaseCapacity();
                    entityIndexInChunk = m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk;
                }

                var entityVersion = m_VersionByEntity[m_NextFreeEntityIndex];

                if (outputEntities != null)
                {
                    outputEntities[i].Index = m_NextFreeEntityIndex;
                    outputEntities[i].Version = entityVersion;
                }

                var entityInChunk = entityInChunkStart + i;

                entityInChunk->Index = m_NextFreeEntityIndex;
                entityInChunk->Version = entityVersion;

                m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk = baseIndex + i;
                m_ArchetypeByEntity[m_NextFreeEntityIndex] = arch;
                m_EntityInChunkByEntity[m_NextFreeEntityIndex].Chunk = chunk;
#if UNITY_EDITOR
                m_NameByEntity[m_NextFreeEntityIndex] = new NumberedWords();
#endif

                m_NextFreeEntityIndex = entityIndexInChunk;
            }
        }

        public void GetChunk(Entity entity, out Chunk* chunk, out int chunkIndex)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            var entityIndexInChunk = m_EntityInChunkByEntity[entity.Index].IndexInChunk;

            chunk = entityChunk;
            chunkIndex = entityIndexInChunk;
        }

        public byte* GetComponentDataWithTypeRO(Entity entity, int typeIndex)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            var entityIndexInChunk = m_EntityInChunkByEntity[entity.Index].IndexInChunk;

            return ChunkDataUtility.GetComponentDataWithTypeRO(entityChunk, entityIndexInChunk, typeIndex);
        }

        public byte* GetComponentDataWithTypeRW(Entity entity, int typeIndex, uint globalVersion)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            var entityIndexInChunk = m_EntityInChunkByEntity[entity.Index].IndexInChunk;

            return ChunkDataUtility.GetComponentDataWithTypeRW(entityChunk, entityIndexInChunk, typeIndex,
                globalVersion);
        }

        public byte* GetComponentDataWithTypeRO(Entity entity, int typeIndex, ref int typeLookupCache)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            var entityIndexInChunk = m_EntityInChunkByEntity[entity.Index].IndexInChunk;

            return ChunkDataUtility.GetComponentDataWithTypeRO(entityChunk, entityIndexInChunk, typeIndex,
                ref typeLookupCache);
        }

        public byte* GetComponentDataWithTypeRW(Entity entity, int typeIndex, uint globalVersion,
            ref int typeLookupCache)
        {
            var entityChunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            var entityIndexInChunk = m_EntityInChunkByEntity[entity.Index].IndexInChunk;

            return ChunkDataUtility.GetComponentDataWithTypeRW(entityChunk, entityIndexInChunk, typeIndex,
                globalVersion, ref typeLookupCache);
        }
        
        public int GetSharedComponentDataIndex(Entity entity, int typeIndex)
        {
            var archetype = m_ArchetypeByEntity[entity.Index];
            var indexInTypeArray = ChunkDataUtility.GetIndexInTypeArray(archetype, typeIndex);
            var chunk = m_EntityInChunkByEntity[entity.Index].Chunk;
            var sharedComponentValueArray = chunk->SharedComponentValues;
            var sharedComponentOffset = indexInTypeArray - archetype->FirstSharedComponent;
            return sharedComponentValueArray[sharedComponentOffset];
        }

        public void DeallocateDataEntitiesInChunk(Entity* entities, Chunk* chunk,
            int indexInChunk, int batchCount)
        {
            DeallocateBuffers(entities, chunk, batchCount);

            var freeIndex = m_NextFreeEntityIndex;

            for (var i = batchCount - 1; i >= 0; --i)
            {
                var entityIndex = entities[i].Index;

                m_EntityInChunkByEntity[entityIndex].Chunk = null;
                m_VersionByEntity[entityIndex]++;
                m_EntityInChunkByEntity[entityIndex].IndexInChunk = freeIndex;
#if UNITY_EDITOR
                m_NameByEntity[entityIndex] = new NumberedWords();
#endif
                freeIndex = entityIndex;
            }

            m_NextFreeEntityIndex = freeIndex;

            // Compute the number of things that need to moved and patched.
            int patchCount = Math.Min(batchCount, chunk->Count - indexInChunk - batchCount);

            if (0 == patchCount)
                return;

            // updates indexInChunk to point to where the components will be moved to
            //Assert.IsTrue(chunk->archetype->sizeOfs[0] == sizeof(Entity) && chunk->archetype->offsets[0] == 0);
            var movedEntities = (Entity*) chunk->Buffer + (chunk->Count - patchCount);
            for (var i = 0; i != patchCount; i++)
                m_EntityInChunkByEntity[movedEntities[i].Index].IndexInChunk = indexInChunk + i;

            // Move component data from the end to where we deleted components
            ChunkDataUtility.Copy(chunk, chunk->Count - patchCount, chunk, indexInChunk, patchCount);
        }
 
        public void DeallocateBuffers(Entity* entities, Chunk* chunk, int batchCount)
        {
            var archetype = chunk->Archetype;

            for (var ti = 0; ti < archetype->TypesCount; ++ti)
            {
                var type = archetype->Types[ti];

                if (!type.IsBuffer)
                    continue;

                var basePtr = chunk->Buffer + archetype->Offsets[ti];
                var stride = archetype->SizeOfs[ti];

                for (int i = 0; i < batchCount; ++i)
                {
                    Entity e = entities[i];
                    int indexInChunk = m_EntityInChunkByEntity[e.Index].IndexInChunk;
                    byte* bufferPtr = basePtr + stride * indexInChunk;
                    BufferHeader.Destroy((BufferHeader*) bufferPtr);
                }
            }
        }

        public EntityBatchInChunk GetFirstEntityBatchInChunk(Entity* entities, int count)
        {
            // This is optimized for the case where the array of entities are allocated contigously in the chunk
            // Thus the compacting of other elements can be batched

            // Calculate baseEntityIndex & chunk
            var baseEntityIndex = entities[0].Index;

            var versions = m_VersionByEntity;
            var chunkData = m_EntityInChunkByEntity;

            var chunk = versions[baseEntityIndex] == entities[0].Version
                ? m_EntityInChunkByEntity[baseEntityIndex].Chunk
                : null;
            var indexInChunk = chunkData[baseEntityIndex].IndexInChunk;
            var batchCount = 0;

            while (batchCount < count)
            {
                var entityIndex = entities[batchCount].Index;
                var curChunk = chunkData[entityIndex].Chunk;
                var curIndexInChunk = chunkData[entityIndex].IndexInChunk;

                if (versions[entityIndex] == entities[batchCount].Version)
                {
                    if (curChunk != chunk || curIndexInChunk != indexInChunk + batchCount)
                        break;
                }
                else
                {
                    if (chunk != null)
                        break;
                }

                batchCount++;
            }

            return new EntityBatchInChunk
            {
                Chunk = chunk,
                Count = batchCount,
                StartIndex = indexInChunk
            };
        }

        public void LockChunks(ArchetypeChunk* archetypeChunks, int count, ChunkFlags flags)
        {
            for (int i = 0; i < count; i++)
            {
                var chunk = archetypeChunks[i].m_Chunk;

                Assert.IsFalse(chunk->Locked);

                chunk->Flags |= (uint) flags;
                if (chunk->Count < chunk->Capacity && (flags & ChunkFlags.Locked) != 0)
                    chunk->Archetype->EmptySlotTrackingRemoveChunk(chunk);
            }
        }

        public void UnlockChunks(ArchetypeChunk* archetypeChunks, int count, ChunkFlags flags)
        {
            for (int i = 0; i < count; i++)
            {
                var chunk = archetypeChunks[i].m_Chunk;

                Assert.IsTrue(chunk->Locked);

                chunk->Flags &= ~(uint) flags;
                if (chunk->Count < chunk->Capacity && (flags & ChunkFlags.Locked) != 0)
                    chunk->Archetype->EmptySlotTrackingAddChunk(chunk);
            }
        }

        public void AllocateConsecutiveEntitiesForLoading(int count)
        {
            int newCapacity = count + 1; // make room for Entity.Null
            ReallocCapacity(newCapacity + 1); // the last entity is used to indicate we ran out of space
            m_NextFreeEntityIndex = newCapacity;
            for (int i = 1; i < newCapacity; ++i)
            {
                if (m_EntityInChunkByEntity[i].Chunk != null)
                {
                    throw new ArgumentException("loading into non-empty entity manager is not supported");
                }

                m_EntityInChunkByEntity[i].IndexInChunk = 0;
                m_VersionByEntity[i] = 0;
#if UNITY_EDITOR
                m_NameByEntity[i] = new NumberedWords();
#endif
            }
        }

        public void AddExistingEntitiesInChunk(Chunk* chunk)
        {
            for (int iEntity = 0; iEntity < chunk->Count; ++iEntity)
            {
                var entity = (Entity*) ChunkDataUtility.GetComponentDataRO(chunk, iEntity, 0);

                m_EntityInChunkByEntity[entity->Index].Chunk = chunk;
                m_EntityInChunkByEntity[entity->Index].IndexInChunk = iEntity;
                m_ArchetypeByEntity[entity->Index] = chunk->Archetype;
                m_VersionByEntity[entity->Index] = entity->Version;
            }
        }

        public void AllocateEntitiesForRemapping(EntityComponentStore* srcEntityComponentStore,
            ref NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
            var count = srcEntityComponentStore->EntitiesCapacity;
            for (var i = 0; i != count; i++)
            {
                if (srcEntityComponentStore->m_EntityInChunkByEntity[i].Chunk != null)
                {
                    var entityIndexInChunk = m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk;
                    if (entityIndexInChunk == -1)
                    {
                        IncreaseCapacity();
                        entityIndexInChunk = m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk;
                    }

                    var entityVersion = m_VersionByEntity[m_NextFreeEntityIndex];

                    EntityRemapUtility.AddEntityRemapping(ref entityRemapping,
                        new Entity {Version = srcEntityComponentStore->m_VersionByEntity[i], Index = i},
                        new Entity {Version = entityVersion, Index = m_NextFreeEntityIndex});
                    m_NextFreeEntityIndex = entityIndexInChunk;
                }
            }
        }

        public void AllocateEntitiesForRemapping(Chunk* chunk,
            ref NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
            var count = chunk->Count;
            var entities = (Entity*) chunk->Buffer;
            for (var i = 0; i != count; i++)
            {
                var entityIndexInChunk = m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk;
                if (entityIndexInChunk == -1)
                {
                    IncreaseCapacity();
                    entityIndexInChunk = m_EntityInChunkByEntity[m_NextFreeEntityIndex].IndexInChunk;
                }

                var entityVersion = m_VersionByEntity[m_NextFreeEntityIndex];

                EntityRemapUtility.AddEntityRemapping(ref entityRemapping,
                    new Entity {Version = entities[i].Version, Index = entities[i].Index},
                    new Entity {Version = entityVersion, Index = m_NextFreeEntityIndex});
                m_NextFreeEntityIndex = entityIndexInChunk;
            }
        }

        public void RemapChunk(Archetype* arch, Chunk* chunk, int baseIndex, int count,
            ref NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
            Assert.AreEqual(chunk->Archetype->Offsets[0], 0);
            Assert.AreEqual(chunk->Archetype->SizeOfs[0], sizeof(Entity));

            var entityInChunkStart = (Entity*) (chunk->Buffer) + baseIndex;

            for (var i = 0; i != count; i++)
            {
                var entityInChunk = entityInChunkStart + i;
                var target = EntityRemapUtility.RemapEntity(ref entityRemapping, *entityInChunk);
                var entityVersion = m_VersionByEntity[target.Index];

                Assert.AreEqual(entityVersion, target.Version);

                entityInChunk->Index = target.Index;
                entityInChunk->Version = entityVersion;
                m_EntityInChunkByEntity[target.Index].IndexInChunk = baseIndex + i;
                m_ArchetypeByEntity[target.Index] = arch;
                m_EntityInChunkByEntity[target.Index].Chunk = chunk;
            }

            if (chunk->metaChunkEntity != Entity.Null)
            {
                chunk->metaChunkEntity = EntityRemapUtility.RemapEntity(ref entityRemapping, chunk->metaChunkEntity);
            }
        }

        [BurstCompile]
        struct EntityBatchFromArchetypeChunks : IJob
        {
            [ReadOnly] public NativeArray<ArchetypeChunk> ArchetypeChunks;
            public NativeList<EntityBatchInChunk> EntityBatchList;

            public void Execute()
            {
                for (int i = 0; i < ArchetypeChunks.Length; i++)
                {
                    var entityBatch = new EntityBatchInChunk
                    {
                        Chunk = ArchetypeChunks[i].m_Chunk,
                        StartIndex = 0,
                        Count = ArchetypeChunks[i].Count
                    };
                    EntityBatchList.Add(entityBatch);
                }
            }
        }
          
        [BurstCompile]
        struct EntityBatchFromEntityChunkDataShared : IJob
        {
            [ReadOnly] public NativeArraySharedValues<EntityInChunk> EntityChunkDataShared;
            public NativeList<EntityBatchInChunk> EntityBatchList;

            public void Execute()
            {
                var entityChunkData = EntityChunkDataShared.SourceBuffer;
                var sortedEntityInChunks = EntityChunkDataShared.GetSortedIndices();

                var sortedEntityIndex = 0;
                var entityIndex = sortedEntityInChunks[sortedEntityIndex];
                var entityBatch = new EntityBatchInChunk
                {
                    Chunk = entityChunkData[entityIndex].Chunk,
                    StartIndex = entityChunkData[entityIndex].IndexInChunk,
                    Count = 1
                };
                sortedEntityIndex++;
                while (sortedEntityIndex < sortedEntityInChunks.Length)
                {
                    entityIndex = sortedEntityInChunks[sortedEntityIndex];
                    var chunk = entityChunkData[entityIndex].Chunk;
                    var indexInChunk = entityChunkData[entityIndex].IndexInChunk;
                    var chunkBreak = (chunk != entityBatch.Chunk);
                    var indexBreak = (indexInChunk != (entityBatch.StartIndex + entityBatch.Count));
                    var runBreak = chunkBreak || indexBreak;
                    if (runBreak)
                    {
                        EntityBatchList.Add(entityBatch);
                        entityBatch = new EntityBatchInChunk
                        {
                            Chunk = chunk,
                            StartIndex = indexInChunk,
                            Count = 1
                        };
                    }
                    else
                    {
                        entityBatch = new EntityBatchInChunk
                        {
                            Chunk = entityBatch.Chunk,
                            StartIndex = entityBatch.StartIndex,
                            Count = entityBatch.Count + 1
                        };
                    }

                    sortedEntityIndex++;
                }

                EntityBatchList.Add(entityBatch);
            }
        }

        public NativeList<EntityBatchInChunk> CreateEntityBatchList(NativeArray<Entity> entities)
        {
            if (entities.Length == 0)
            {
                return new NativeList<EntityBatchInChunk>(Allocator.Persistent);
            }

            var entityChunkData = new NativeArray<EntityInChunk>(entities.Length, Allocator.TempJob,
                NativeArrayOptions.UninitializedMemory);
                var gatherEntityChunkDataForEntitiesJobHandle =
                GatherEntityInChunkForEntitiesJob(entities, entityChunkData);

            var entityChunkDataShared = new NativeArraySharedValues<EntityInChunk>(entityChunkData, Allocator.TempJob);
            var entityChunkDataSharedJobHandle =
                entityChunkDataShared.Schedule(gatherEntityChunkDataForEntitiesJobHandle);

            var entityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent);
            var entityBatchFromEntityInChunksSharedJob = new EntityBatchFromEntityChunkDataShared
            {
                EntityChunkDataShared = entityChunkDataShared,
                EntityBatchList = entityBatchList
            };
            var entityBatchFromEntityInChunksSharedJobHandle =
                entityBatchFromEntityInChunksSharedJob.Schedule(entityChunkDataSharedJobHandle);
            entityBatchFromEntityInChunksSharedJobHandle.Complete();

            entityChunkData.Dispose();
            entityChunkDataShared.Dispose();

            return entityBatchList;
        }

        public NativeList<EntityBatchInChunk> CreateEntityBatchList(NativeArray<ArchetypeChunk> archetypeChunks)
        {
            var entityBatchList = new NativeList<EntityBatchInChunk>(Allocator.Persistent);
            var entityBatchFromArchetypeChunksJob = new EntityBatchFromArchetypeChunks
            {
                ArchetypeChunks = archetypeChunks,
                EntityBatchList = entityBatchList
            };
            var entityBatchFromArchetypeChunksJobHandle =
                entityBatchFromArchetypeChunksJob.Schedule();
            entityBatchFromArchetypeChunksJobHandle.Complete();

            return entityBatchList;
        }

        [BurstCompile]
        struct GatherEntityInChunkForEntities : IJobParallelFor
        {
            [ReadOnly] public NativeArray<Entity> Entities;

            [ReadOnly] [NativeDisableUnsafePtrRestriction]
            public EntityInChunk* globalEntityInChunk;

            public NativeArray<EntityInChunk> EntityChunkData;

            public void Execute(int index)
            {
                var entity = Entities[index];
                EntityChunkData[index] = new EntityInChunk
                {
                    Chunk = globalEntityInChunk[entity.Index].Chunk,
                    IndexInChunk = globalEntityInChunk[entity.Index].IndexInChunk
                };
            }
        }

        JobHandle GatherEntityInChunkForEntitiesJob(NativeArray<Entity> entities,
            NativeArray<EntityInChunk> entityChunkData, JobHandle inputDeps = new JobHandle())
        {
            var gatherEntityInChunkForEntitiesJob = new GatherEntityInChunkForEntities
            {
                Entities = entities,
                globalEntityInChunk = m_EntityInChunkByEntity,
                EntityChunkData = entityChunkData
            };
            var gatherEntityInChunkForEntitiesJobHandle =
                gatherEntityInChunkForEntitiesJob.Schedule(entities.Length, 32, inputDeps);
            return gatherEntityInChunkForEntitiesJobHandle;
        }
        
        ref UnsafePtrList EmptyChunksUnsafePtrList
        {
            get { return ref *(UnsafePtrList*)UnsafeUtility.AddressOf(ref m_EmptyChunks); }
        }

        ref UnsafePtrList ArchetypeUnsafePtrList
        {
            get { return ref *(UnsafePtrList*)UnsafeUtility.AddressOf(ref m_Archetypes); }
        }
        
        public ulong AssignSequenceNumber(Chunk* chunk)
        {
            var sequenceNumber = m_NextChunkSequenceNumber;
            m_NextChunkSequenceNumber++;
            return sequenceNumber;
        }

        public Chunk* AllocateChunk()
        {
            Chunk* newChunk;
            // Try empty chunk pool
            if (m_EmptyChunks.Count == 0)
            {
                // Allocate new chunk
                newChunk = (Chunk*)UnsafeUtility.Malloc(Chunk.kChunkSize, 64, Allocator.Persistent);
            }
            else
            {
                Assert.IsTrue(m_EmptyChunks.Count > 0);
                var back = m_EmptyChunks.Count - 1;
                newChunk = m_EmptyChunks.p[back];
                EmptyChunksUnsafePtrList.Resize(back);
            }

            return newChunk;
        }
        
        public void FreeChunk(Chunk* chunk)
        {
            if (m_EmptyChunks.Count == kMaximumEmptyChunksInPool)
                UnsafeUtility.Free(chunk, Allocator.Persistent);
            else
            {
                EmptyChunksUnsafePtrList.Add(chunk);
                chunk->Count = 0;
            }
        }

        public Archetype* GetExistingArchetype(ComponentTypeInArchetype* typesSorted, int count)
        {
            return m_TypeLookup.TryGet(typesSorted, count);
        }

        void ChunkAllocate<T>(void* pointer, int count = 1) where T : struct
        {
            void** pointerToPointer = (void**)pointer;
            *pointerToPointer =
                m_ArchetypeChunkAllocator.Allocate(UnsafeUtility.SizeOf<T>() * count, UnsafeUtility.AlignOf<T>());
        }

        public Archetype* CreateArchetype(ComponentTypeInArchetype* types, int count)
        {
            AssertArchetypeComponents(types, count);

            // Compute how many IComponentData types store Entities and need to be patched.
            // Types can have more than one entity, which means that this count is not necessarily
            // the same as the type count.
            var scalarEntityPatchCount = 0;
            var bufferEntityPatchCount = 0;
            var NumManagedArrays = 0;
            var NumSharedComponents = 0;
            for (var i = 0; i < count; ++i)
            {
                var ct = TypeManager.GetTypeInfo(types[i].TypeIndex);
                switch (ct.Category)
                {
                    case TypeManager.TypeCategory.ISharedComponentData:
                        ++NumSharedComponents;
                        break;
                    case TypeManager.TypeCategory.Class:
                        ++NumManagedArrays;
                        break;
                }
                var entityOffsets = ct.EntityOffsets;
                if (entityOffsets == null)
                    continue;
                if (ct.BufferCapacity >= 0)
                    bufferEntityPatchCount += ct.EntityOffsetCount;
                else if (ct.SizeInChunk > 0)
                    scalarEntityPatchCount += ct.EntityOffsetCount;
            }

            Archetype* type = null;
            ChunkAllocate<Archetype>(&type);
            ChunkAllocate<ComponentTypeInArchetype>(&type->Types, count);
            ChunkAllocate<int>(&type->Offsets, count);
            ChunkAllocate<int>(&type->SizeOfs, count);
            ChunkAllocate<int>(&type->BufferCapacities, count);
            ChunkAllocate<int>(&type->TypeMemoryOrder, count);
            ChunkAllocate<EntityRemapUtility.EntityPatchInfo>(&type->ScalarEntityPatches, scalarEntityPatchCount);
            ChunkAllocate<EntityRemapUtility.BufferEntityPatchInfo>(&type->BufferEntityPatches, bufferEntityPatchCount);
            type->ManagedArrayOffset = null;
            if (NumManagedArrays > 0)
                ChunkAllocate<int>(&type->ManagedArrayOffset, count);

            type->TypesCount = count;
            UnsafeUtility.MemCpy(type->Types, types, sizeof(ComponentTypeInArchetype) * count);
            type->EntityCount = 0;
            type->Chunks = new ArchetypeChunkData(count, NumSharedComponents);
            type->ChunksWithEmptySlots = new ChunkList();
            type->InstantiableArchetype = null;
            type->MetaChunkArchetype = null;
            type->SystemStateResidueArchetype = null;
            type->NumSharedComponents = 0;

            var disabledTypeIndex = TypeManager.GetTypeIndex<Disabled>();
            var prefabTypeIndex = TypeManager.GetTypeIndex<Prefab>();
            var chunkHeaderTypeIndex = TypeManager.GetTypeIndex<ChunkHeader>();
            type->Disabled = false;
            type->Prefab = false;
            type->HasChunkHeader = false;
            type->HasChunkComponents = false;
            type->ContainsBlobAssetRefs = false;
            type->NonZeroSizedTypesCount = 0;
            for (var i = 0; i < count; ++i)
            {
                if (!types[i].IsZeroSized)
                    type->NonZeroSizedTypesCount++;
                if (types[i].IsSharedComponent)
                    ++type->NumSharedComponents;
                if (types[i].TypeIndex == disabledTypeIndex)
                    type->Disabled = true;
                if (types[i].TypeIndex == prefabTypeIndex)
                    type->Prefab = true;
                if (types[i].TypeIndex == chunkHeaderTypeIndex)
                    type->HasChunkHeader = true;
                if (types[i].IsChunkComponent)
                    type->HasChunkComponents = true;
                if (TypeManager.GetTypeInfo(types[i].TypeIndex).BlobAssetRefOffsetCount > 0)
                    type->ContainsBlobAssetRefs = true;
            }

            var chunkDataSize = Chunk.GetChunkBufferSize();

            type->ScalarEntityPatchCount = scalarEntityPatchCount;
            type->BufferEntityPatchCount = bufferEntityPatchCount;

            type->BytesPerInstance = 0;

            // number of bytes we'll reserve for potential alignment
            int alignExtraSpace = 0;
            var alignments = stackalloc int[count];

            int maxCapacity = TypeManager.MaximumChunkCapacity;
            for (var i = 0; i < count; ++i)
            {
                var cType = TypeManager.GetTypeInfo(types[i].TypeIndex);
                var sizeOf = cType.SizeInChunk; // Note that this includes internal capacity and header overhead for buffers.
                if (types[i].IsChunkComponent)
                {
                    sizeOf = 0;
                }
                type->SizeOfs[i] = sizeOf;
                type->BufferCapacities[i] = cType.BufferCapacity;

                type->BytesPerInstance += sizeOf;
                maxCapacity = math.min(cType.MaximumChunkCapacity, maxCapacity);

                // explicitly 0 here for sizeof == 0, so that the usedBytes
                // calculation below properly ignores 0-sized components
                alignments[i] = sizeOf == 0 ? 0 : cType.AlignmentInChunkInBytes;
                alignExtraSpace += alignments[i];
            }

            Assert.IsTrue(maxCapacity >= 1, "MaximumChunkCapacity must be larger than 1");

            type->ChunkCapacity = math.min((chunkDataSize - alignExtraSpace) / type->BytesPerInstance, maxCapacity);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (type->BytesPerInstance > chunkDataSize)
                throw new ArgumentException(
                    $"Entity archetype component data is too large. The maximum component data is {chunkDataSize} but the component data is {type->BytesPerInstance}");

            Assert.IsTrue(Chunk.kMaximumEntitiesPerChunk >= type->ChunkCapacity);
#endif

            // For serialization a stable ordering of the components in the
            // chunk is desired. The type index is not stable, since it depends
            // on the order in which types are added to the TypeManager.
            // A permutation of the types ordered by a TypeManager-generated
            // memory ordering is used instead.
            var memoryOrderings = stackalloc UInt64[count];
            for (int i = 0; i < count; ++i)
                memoryOrderings[i] = TypeManager.GetTypeInfo(types[i].TypeIndex).MemoryOrdering;
            for (int i = 0; i < count; ++i)
            {
                int index = i;
                while (index > 1 && memoryOrderings[i] < memoryOrderings[type->TypeMemoryOrder[index - 1]])
                {
                    type->TypeMemoryOrder[index] = type->TypeMemoryOrder[index - 1];
                    --index;
                }
                type->TypeMemoryOrder[index] = i;
            }

            var usedBytes = 0;
            for (var i = 0; i < count; ++i)
            {
                var index = type->TypeMemoryOrder[i];
                var sizeOf = type->SizeOfs[index];

                // align usedBytes upwards (eating into alignExtraSpace) so that
                // this component actually starts at its required alignment.
                // Assumption is that the start of the entire data segment is at the
                // maximum possible alignment.
                usedBytes = TypeManager.AlignUp(usedBytes, alignments[index]);
                type->Offsets[index] = usedBytes;

                usedBytes += sizeOf * type->ChunkCapacity;
            }

            type->NumManagedArrays = NumManagedArrays;
            if (type->NumManagedArrays > 0)
            {
                var mi = 0;
                for (var i = 0; i < count; ++i)
                {
                    var index = type->TypeMemoryOrder[i];
                    var cType = TypeManager.GetTypeInfo(types[index].TypeIndex);
                    if (cType.Category == TypeManager.TypeCategory.Class)
                        type->ManagedArrayOffset[index] = mi++;
                    else
                        type->ManagedArrayOffset[index] = -1;
                }
            }

            type->NumSharedComponents = NumSharedComponents;

            type->FirstSharedComponent = -1;
            if (type->NumSharedComponents > 0)
            {
                int firstSharedComponent = 0;
                while (!types[++firstSharedComponent].IsSharedComponent);
                type->FirstSharedComponent = firstSharedComponent;
            }

            // Fill in arrays of scalar and buffer entity patches
            var scalarPatchInfo = type->ScalarEntityPatches;
            var bufferPatchInfo = type->BufferEntityPatches;
            for (var i = 0; i != count; i++)
            {
                var ct = TypeManager.GetTypeInfo(types[i].TypeIndex);
                #if !NET_DOTS
                    ulong handle = ~0UL;
                    var offsets = ct.EntityOffsets == null ? null : (TypeManager.EntityOffsetInfo*) UnsafeUtility.PinGCArrayAndGetDataAddress(ct.EntityOffsets, out handle);
                    var offsetCount = ct.EntityOffsetCount;
                #else
                    var offsets = ct.EntityOffsets;
                    var offsetCount = ct.EntityOffsetCount;
                #endif

                if (ct.BufferCapacity >= 0)
                {
                    bufferPatchInfo = EntityRemapUtility.AppendBufferEntityPatches(bufferPatchInfo, offsets, offsetCount, type->Offsets[i], type->SizeOfs[i], ct.ElementSize);
                }
                else if (ct.SizeInChunk > 0)
                {
                    scalarPatchInfo = EntityRemapUtility.AppendEntityPatches(scalarPatchInfo, offsets, offsetCount, type->Offsets[i], type->SizeOfs[i]);
                }

                #if !NET_DOTS
                    if(offsets != null)
                        UnsafeUtility.ReleaseGCObject(handle);
                #endif
            }
            Assert.AreEqual(scalarPatchInfo - type->ScalarEntityPatches, scalarEntityPatchCount);

            type->ScalarEntityPatchCount = scalarEntityPatchCount;
            type->BufferEntityPatchCount = bufferEntityPatchCount;

            // Update the list of all created archetypes
            ArchetypeUnsafePtrList.Add(type);

            type->FreeChunksBySharedComponents = new ChunkListMap();
            type->FreeChunksBySharedComponents.Init(16);

            m_TypeLookup.Add(type);

            type->SystemStateCleanupComplete = ArchetypeSystemStateCleanupComplete(type);
            type->SystemStateCleanupNeeded = ArchetypeSystemStateCleanupNeeded(type);

            return type;
        }

        private bool ArchetypeSystemStateCleanupComplete(Archetype* archetype)
        {
            if (archetype->TypesCount == 2 && archetype->Types[1].TypeIndex == TypeManager.GetTypeIndex<CleanupEntity>()) return true;
            return false;
        }

        private bool ArchetypeSystemStateCleanupNeeded(Archetype* archetype)
        {
            for (var t = 1; t < archetype->TypesCount; ++t)
            {
                var type = archetype->Types[t];
                if (type.IsSystemStateComponent)
                {
                    return true;
                }
            }

            return false;
        }

        public int CountEntities()
        {
            int entityCount = 0;
            for (var i = m_Archetypes.Count - 1; i >= 0; --i)
            {
                var archetype = m_Archetypes.p[i];
                entityCount += archetype->EntityCount;
            }

            return entityCount;
        }

        public struct ArchetypeChanges
        {
            public int StartIndex;
            public uint ArchetypeTrackingVersion;
        }

        public ArchetypeChanges BeginArchetypeChangeTracking()
        {
            m_ArchetypeTrackingVersion++;
            return new ArchetypeChanges
            {
                StartIndex = m_Archetypes.Count,
                ArchetypeTrackingVersion = m_ArchetypeTrackingVersion
            };
        }
        
        public ArchetypeList EndArchetypeChangeTracking(ArchetypeChanges changes)
        {
            Assert.AreEqual(m_ArchetypeTrackingVersion, changes.ArchetypeTrackingVersion);
            return new ArchetypeList
            {
                p = m_Archetypes.p + changes.StartIndex,
                Count = m_Archetypes.Count - changes.StartIndex,
                Capacity = m_Archetypes.Count - changes.StartIndex,
            };
        }
    }
}
