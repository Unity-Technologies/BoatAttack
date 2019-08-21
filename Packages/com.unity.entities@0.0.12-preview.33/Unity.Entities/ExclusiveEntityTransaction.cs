using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    [NativeContainer]
    public unsafe struct ExclusiveEntityTransaction
    {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        private AtomicSafetyHandle m_Safety;
#endif
        [NativeDisableUnsafePtrRestriction] private GCHandle m_EntityGroupManager;

        [NativeDisableUnsafePtrRestriction] private GCHandle m_ManagedComponentStore;

        [NativeDisableUnsafePtrRestriction] private EntityComponentStore* m_EntityComponentStore;

        internal ManagedComponentStore ManagedComponentStore =>
            (ManagedComponentStore) m_ManagedComponentStore.Target;
        internal EntityGroupManager EntityGroupManager => (EntityGroupManager) m_EntityGroupManager.Target;
        internal EntityComponentStore* EntityComponentStore => m_EntityComponentStore;

        internal ExclusiveEntityTransaction(EntityGroupManager entityGroupManager,
            ManagedComponentStore managedComponentStore, EntityComponentStore* componentStore)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_Safety = new AtomicSafetyHandle();
#endif
            m_EntityComponentStore = componentStore;
            m_EntityGroupManager = GCHandle.Alloc(entityGroupManager, GCHandleType.Weak);
            m_ManagedComponentStore = GCHandle.Alloc(managedComponentStore, GCHandleType.Weak);
        }

        internal void OnDestroy()
        {
            m_EntityGroupManager.Free();
            m_ManagedComponentStore.Free();
            m_EntityComponentStore = null;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        internal void SetAtomicSafetyHandle(AtomicSafetyHandle safety)
        {
            m_Safety = safety;
        }
#endif

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void CheckAccess()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.CheckWriteAndThrow(m_Safety);
#endif
        }

        internal EntityArchetype CreateArchetype(ComponentType* types, int count)
        {
            CheckAccess();

            ComponentTypeInArchetype* typesInArchetype = stackalloc ComponentTypeInArchetype[count + 1];
            var componentCount = EntityManager.FillSortedArchetypeArray(typesInArchetype, types, count);

            EntityArchetype type;
            type.Archetype = EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(typesInArchetype, componentCount, EntityComponentStore);

            return type;
        }

        public EntityArchetype CreateArchetype(params ComponentType[] types)
        {
            fixed (ComponentType* typesPtr = types)
            {
                return CreateArchetype(typesPtr, types.Length);
            }
        }

        public Entity CreateEntity(EntityArchetype archetype)
        {
            CheckAccess();

            Entity entity;
            EntityManagerCreateDestroyEntitiesUtility.CreateEntities(archetype.Archetype,  &entity, 1, EntityComponentStore, ManagedComponentStore);
            return entity;
        }

        public void CreateEntity(EntityArchetype archetype, NativeArray<Entity> entities)
        {
            CheckAccess();
            EntityManagerCreateDestroyEntitiesUtility.CreateEntities(archetype.Archetype, (Entity*) entities.GetUnsafePtr(), entities.Length, EntityComponentStore, ManagedComponentStore);
        }

        public Entity CreateEntity(params ComponentType[] types)
        {
            return CreateEntity(CreateArchetype(types));
        }

        public Entity Instantiate(Entity srcEntity)
        {
            Entity entity;
            InstantiateInternal(srcEntity, &entity, 1);
            return entity;
        }

        public void Instantiate(Entity srcEntity, NativeArray<Entity> outputEntities)
        {
            InstantiateInternal(srcEntity, (Entity*) outputEntities.GetUnsafePtr(), outputEntities.Length);
        }

        private void InstantiateInternal(Entity srcEntity, Entity* outputEntities, int count)
        {
            CheckAccess();
            EntityManagerCreateDestroyEntitiesUtility.InstantiateEntities(srcEntity, outputEntities, count, 
                EntityComponentStore, ManagedComponentStore);
        }

        public void DestroyEntity(NativeArray<Entity> entities)
        {
            DestroyEntityInternal((Entity*) entities.GetUnsafeReadOnlyPtr(), entities.Length);
        }

        public void DestroyEntity(NativeSlice<Entity> entities)
        {
            DestroyEntityInternal((Entity*) entities.GetUnsafeReadOnlyPtr(), entities.Length);
        }

        public void DestroyEntity(Entity entity)
        {
            DestroyEntityInternal(&entity, 1);
        }

        private void DestroyEntityInternal(Entity* entities, int count)
        {
            CheckAccess();
            m_EntityComponentStore->AssertCanDestroy(entities, count);
            EntityManagerCreateDestroyEntitiesUtility.DestroyEntities(entities, count, EntityComponentStore, ManagedComponentStore);
        }

        public void AddComponent(Entity entity, ComponentType componentType)
        {
            CheckAccess();
            m_EntityComponentStore->AssertCanAddComponent(entity, componentType);
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            EntityManagerChangeArchetypeUtility.AddComponent(entity, componentType, EntityComponentStore, ManagedComponentStore); 
           
            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }

        public DynamicBuffer<T> AddBuffer<T>(Entity entity) where T : struct, IBufferElementData
        {
            AddComponent(entity, ComponentType.ReadWrite<T>());
            return GetBuffer<T>(entity);
        }

        public void RemoveComponent(Entity entity, ComponentType type)
        {
            CheckAccess();
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            EntityManagerChangeArchetypeUtility.RemoveComponent(entity, type, 
                EntityComponentStore, ManagedComponentStore);

            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }

        public bool Exists(Entity entity)
        {
            CheckAccess();

            return m_EntityComponentStore->Exists(entity);
        }

        public bool HasComponent(Entity entity, ComponentType type)
        {
            CheckAccess();

            return m_EntityComponentStore->HasComponent(entity, type);
        }

        public T GetComponentData<T>(Entity entity) where T : struct, IComponentData
        {
            CheckAccess();

            var typeIndex = TypeManager.GetTypeIndex<T>();
            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

            var ptr = m_EntityComponentStore->GetComponentDataWithTypeRO(entity, typeIndex);

            T data;
            UnsafeUtility.CopyPtrToStructure(ptr, out data);
            return data;
        }

        internal void* GetComponentDataRawRW(Entity entity, int typeIndex)
        {
            CheckAccess();

            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

            return m_EntityComponentStore->GetComponentDataWithTypeRW(entity, typeIndex, m_EntityComponentStore->GlobalSystemVersion);
        }

        public void SetComponentData<T>(Entity entity, T componentData) where T : struct, IComponentData
        {
            CheckAccess();

            var typeIndex = TypeManager.GetTypeIndex<T>();
            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

            var ptr = m_EntityComponentStore->GetComponentDataWithTypeRW(entity, typeIndex, m_EntityComponentStore->GlobalSystemVersion);
            UnsafeUtility.CopyStructureToPtr(ref componentData, ptr);
        }

        public T GetSharedComponentData<T>(Entity entity) where T : struct, ISharedComponentData
        {
            var typeIndex = TypeManager.GetTypeIndex<T>();
            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

            var sharedComponentIndex = m_EntityComponentStore->GetSharedComponentDataIndex(entity, typeIndex);
            return ManagedComponentStore.GetSharedComponentData<T>(sharedComponentIndex);
        }

        internal object GetSharedComponentData(Entity entity, int typeIndex)
        {
            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

            var sharedComponentIndex = m_EntityComponentStore->GetSharedComponentDataIndex(entity, typeIndex);
            return ManagedComponentStore.GetSharedComponentDataBoxed(sharedComponentIndex, typeIndex);
        }

        public void SetSharedComponentData<T>(Entity entity, T componentData) where T : struct, ISharedComponentData
        {
            CheckAccess();

            var typeIndex = TypeManager.GetTypeIndex<T>();
            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

            var newSharedComponentDataIndex = ManagedComponentStore.InsertSharedComponent(componentData);

            EntityManagerChangeArchetypeUtility.SetSharedComponentDataIndex(entity, typeIndex, newSharedComponentDataIndex,
                EntityComponentStore, ManagedComponentStore);
            
            ManagedComponentStore.RemoveReference(newSharedComponentDataIndex);
        }

        internal void AddSharedComponent<T>(NativeArray<ArchetypeChunk> chunks, T componentData) where T : struct, ISharedComponentData
        {
            CheckAccess();

            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            var componentType = ComponentType.ReadWrite<T>();
            var newSharedComponentDataIndex = ManagedComponentStore.InsertSharedComponent(componentData);
            EntityComponentStore->AssertCanAddComponent(chunks, componentType);
            
            EntityManagerChangeArchetypeUtility.AddSharedComponent(chunks, componentType, newSharedComponentDataIndex, EntityComponentStore, ManagedComponentStore);
            ManagedComponentStore.RemoveReference(newSharedComponentDataIndex);

            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }
        
        public DynamicBuffer<T> GetBuffer<T>(Entity entity) where T : struct, IBufferElementData
        {
            CheckAccess();

            var typeIndex = TypeManager.GetTypeIndex<T>();

            m_EntityComponentStore->AssertEntityHasComponent(entity, typeIndex);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (!TypeManager.IsBuffer(typeIndex))
                throw new ArgumentException(
                    $"GetBuffer<{typeof(T)}> may not be IComponentData or ISharedComponentData; currently {TypeManager.GetTypeInfo<T>().Category}");
#endif

            BufferHeader* header = (BufferHeader*) m_EntityComponentStore->GetComponentDataWithTypeRW(entity, typeIndex, m_EntityComponentStore->GlobalSystemVersion);

            int internalCapacity = TypeManager.GetTypeInfo(typeIndex).BufferCapacity;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            return new DynamicBuffer<T>(header, m_Safety, m_Safety, false, internalCapacity);
#else
            return new DynamicBuffer<T>(header, internalCapacity);
#endif
        }

        internal void AllocateConsecutiveEntitiesForLoading(int count)
        {
            m_EntityComponentStore->AllocateConsecutiveEntitiesForLoading(count);
        }

        public void SwapComponents(ArchetypeChunk leftChunk, int leftIndex, ArchetypeChunk rightChunk, int rightIndex)
        {
            CheckAccess();
            var globalVersion = m_EntityComponentStore->GlobalSystemVersion;
            ChunkDataUtility.SwapComponents(leftChunk.m_Chunk,leftIndex,rightChunk.m_Chunk,rightIndex,1, globalVersion, globalVersion);
        }
    }
}
