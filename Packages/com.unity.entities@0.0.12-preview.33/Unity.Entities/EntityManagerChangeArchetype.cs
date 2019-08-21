using System;
using Unity.Collections;
using Unity.Jobs;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager 
    { 
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Adds a component to an entity.
        /// </summary>
        /// <remarks>
        /// Adding a component changes the entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// The added component has the default values for the type.
        ///
        /// If the <see cref="Entity"/> object refers to an entity that has been destroyed, this function throws an ArgumentError
        /// exception.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding thes component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The Entity object.</param>
        /// <param name="componentType">The type of component to add.</param>
        public void AddComponent(Entity entity, ComponentType componentType)
        {
            AddComponent(entity, componentType, true);
        }
        
        /// <summary>
        /// Adds a component to a set of entities defined by a EntityQuery.
        /// </summary>
        /// <remarks>
        /// Adding a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// The added components have the default values for the type.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entityQuery">The EntityQuery defining the entities to modify.</param>
        /// <param name="componentType">The type of component to add.</param>
        public void AddComponent(EntityQuery entityQuery, ComponentType componentType)
        {
            var iterator = entityQuery.GetComponentChunkIterator();
            AddComponent(iterator.m_MatchingArchetypeList, iterator.m_Filter, componentType);
        }
        
        /// <summary>
        /// Adds a component to a set of entities.
        /// </summary>
        /// <remarks>
        /// Adding a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// The added components have the default values for the type.
        ///
        /// If an <see cref="Entity"/> object in the `entities` array refers to an entity that has been destroyed, this function
        /// throws an ArgumentError exception.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before creating these chunks and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entities">An array of Entity objects.</param>
        /// <param name="componentType">The type of component to add.</param>
        public void AddComponent(NativeArray<Entity> entities, ComponentType componentType)
        {
            if (entities.Length == 0)
                return;

            for (int i = 0; i != entities.Length; i++)
                AddComponent(entities[i], componentType);
        }
        
        /// <summary>
        /// Adds a set of component to an entity.
        /// </summary>
        /// <remarks>
        /// Adding components changes the entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// The added components have the default values for the type.
        ///
        /// If the <see cref="Entity"/> object refers to an entity that has been destroyed, this function throws an ArgumentError
        /// exception.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding these components and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity to modify.</param>
        /// <param name="types">The types of components to add.</param>
        public void AddComponents(Entity entity, ComponentTypes types)
        {
            BeforeStructuralChange();
            var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

            EntityComponentStore->AssertCanAddComponents(entity, types);
            EntityManagerChangeArchetypeUtility.AddComponents(entity, types, EntityComponentStore, ManagedComponentStore);

            var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }
        
        /// <summary>
        /// Removes a component from an entity.
        /// </summary>
        /// <remarks>
        /// Removing a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity to modify.</param>
        /// <param name="type">The type of component to remove.</param>
        public void RemoveComponent(Entity entity, ComponentType type)
        {
            BeforeStructuralChange();
            var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

            EntityManagerChangeArchetypeUtility.RemoveComponent(entity, type, EntityComponentStore, ManagedComponentStore);

            var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }
        
        /// <summary>
        /// Removes a component from a set of entities defined by a EntityQuery.
        /// </summary>
        /// <remarks>
        /// Removing a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entityQuery">The EntityQuery defining the entities to modify.</param>
        /// <param name="componentType">The type of component to remove.</param>
        public void RemoveComponent(EntityQuery entityQuery, ComponentType componentType)
        {
            var iterator = entityQuery.GetComponentChunkIterator();
            RemoveComponent(iterator.m_MatchingArchetypeList, iterator.m_Filter, componentType);
        }

        public void RemoveComponent(EntityQuery entityQuery, ComponentTypes types)
        {
            if (entityQuery.CalculateLength() == 0)
                return;

            // @TODO: Opportunity to do all components in batch on a per chunk basis.
            for (int i = 0; i != types.Length; i++)
                RemoveComponent(entityQuery, types.GetComponentType(i));
        }

        //@TODO: optimize for batch
        /// <summary>
        /// Removes a component from a set of entities.
        /// </summary>
        /// <remarks>
        /// Removing a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entities">An array identifying the entities to modify.</param>
        /// <param name="type">The type of component to remove.</param>
        public void RemoveComponent(NativeArray<Entity> entities, ComponentType type)
        {
            for (int i = 0; i != entities.Length; i++)
                RemoveComponent(entities[i], type);
        }
        
        /// <summary>
        /// Removes a component from an entity.
        /// </summary>
        /// <remarks>
        /// Removing a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        public void RemoveComponent<T>(Entity entity)
        {
            RemoveComponent(entity, ComponentType.ReadWrite<T>());
        }
        
        /// <summary>
        /// Removes a component from a set of entities defined by a EntityQuery.
        /// </summary>
        /// <remarks>
        /// Removing a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entityQuery">The EntityQuery defining the entities to modify.</param>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        public void RemoveComponent<T>(EntityQuery entityQuery)
        {
            RemoveComponent(entityQuery, ComponentType.ReadWrite<T>());
        }

        /// <summary>
        /// Removes a component from a set of entities.
        /// </summary>
        /// <remarks>
        /// Removing a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entities">An array identifying the entities to modify.</param>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        public void RemoveComponent<T>(NativeArray<Entity> entities)
        {
            RemoveComponent(entities, ComponentType.ReadWrite<T>());
        }

        
        /// <summary>
        /// Adds a component to an entity and set the value of that component.
        /// </summary>
        /// <remarks>
        /// Adding a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity.</param>
        /// <param name="componentData">The data to set.</param>
        /// <typeparam name="T">The type of component.</typeparam>
        public void AddComponentData<T>(Entity entity, T componentData) where T : struct, IComponentData
        {
            var type = ComponentType.ReadWrite<T>();
            AddComponent(entity, type, type.IgnoreDuplicateAdd);
            if (!type.IsZeroSized)
                SetComponentData(entity, componentData);
        }

        /// <summary>
        /// Removes a chunk component from the specified entity.
        /// </summary>
        /// <remarks>
        /// A chunk component is common to all entities in a chunk. Removing the chunk component from an entity changes
        /// that entity's archetype and results in the entity being moved to a different chunk (that does not have the
        /// removed component).
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        public void RemoveChunkComponent<T>(Entity entity)
        {
            RemoveComponent(entity, ComponentType.ChunkComponent<T>());
        }

        /// <summary>
        /// Adds a chunk component to the specified entity.
        /// </summary>
        /// <remarks>
        /// Adding a chunk component to an entity changes that entity's archetype and results in the entity being moved
        /// to a different chunk, either one that already has an archetype containing the chunk component or a new
        /// chunk.
        ///
        /// A chunk component is common to all entities in a chunk. You can access a chunk <see cref="IComponentData"/>
        /// instance through either the chunk itself or through an entity stored in that chunk. In either case, getting
        /// or setting the component reads or writes the same data.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="T">The type of component, which must implement IComponentData.</typeparam>
        public void AddChunkComponentData<T>(Entity entity) where T : struct, IComponentData
        {
            AddComponent(entity, ComponentType.ChunkComponent<T>());
        }

        /// <summary>
        /// Adds a component to each of the chunks identified by a EntityQuery and set the component values.
        /// </summary>
        /// <remarks>
        /// This function finds all chunks whose archetype satisfies the EntityQuery and adds the specified
        /// component to them.
        ///
        /// A chunk component is common to all entities in a chunk. You can access a chunk <see cref="IComponentData"/>
        /// instance through either the chunk itself or through an entity stored in that chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entityQuery">The EntityQuery identifying the chunks to modify.</param>
        /// <param name="componentData">The data to set.</param>
        /// <typeparam name="T">The type of component, which must implement IComponentData.</typeparam>
        public void AddChunkComponentData<T>(EntityQuery entityQuery, T componentData) where T : struct, IComponentData
        {
            using (var chunks = entityQuery.CreateArchetypeChunkArray(Allocator.TempJob))
            {
                if (chunks.Length == 0)
                    return;
                BeforeStructuralChange();    
                var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

                EntityComponentStore->AssertCanAddChunkComponent(chunks, ComponentType.ChunkComponent<T>());
                
                var type = ComponentType.ReadWrite<T>();
                var chunkType = ComponentType.FromTypeIndex(TypeManager.MakeChunkComponentTypeIndex(type.TypeIndex));

                using (var entityBatchList = m_EntityComponentStore->CreateEntityBatchList(chunks))
                {
                    EntityManagerChangeArchetypeUtility.AddComponentFromMainThread(entityBatchList, chunkType, 0, 
                        EntityComponentStore, ManagedComponentStore);
                    m_EntityComponentStore->SetChunkComponent<T>(entityBatchList, componentData);
                }
                
                var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
        }

        /// <summary>
        /// Removes a component from the chunks identified by a EntityQuery.
        /// </summary>
        /// <remarks>
        /// A chunk component is common to all entities in a chunk. You can access a chunk <see cref="IComponentData"/>
        /// instance through either the chunk itself or through an entity stored in that chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before removing the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entityQuery">The EntityQuery identifying the chunks to modify.</param>
        /// <typeparam name="T">The type of component to remove.</typeparam>
        public void RemoveChunkComponentData<T>(EntityQuery entityQuery)
        {
            using (var chunks = entityQuery.CreateArchetypeChunkArray(Allocator.TempJob))
            {
                if (chunks.Length == 0)
                    return;
                BeforeStructuralChange();
                var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

                EntityManagerChangeArchetypeUtility.RemoveComponent(chunks, ComponentType.ChunkComponent<T>(), 
                    EntityComponentStore, ManagedComponentStore);
                
                var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
        }

        /// <summary>
        /// Adds a dynamic buffer component to an entity.
        /// </summary>
        /// <remarks>
        /// A buffer component stores the number of elements inside the chunk defined by the [InternalBufferCapacity]
        /// attribute applied to the buffer element type declaration. Any additional elements are stored in a separate memory
        /// block that is managed by the EntityManager.
        ///
        /// Adding a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the buffer and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="T">The type of buffer element. Must implement IBufferElementData.</typeparam>
        /// <returns>The buffer.</returns>
        /// <seealso cref="InternalBufferCapacityAttribute"/>
        public DynamicBuffer<T> AddBuffer<T>(Entity entity) where T : struct, IBufferElementData
        {
            AddComponent(entity, ComponentType.ReadWrite<T>());
            return GetBuffer<T>(entity);
        }
        
        /// <summary>
        /// Adds a managed [UnityEngine.Component](https://docs.unity3d.com/ScriptReference/Component.html)
        /// object to an entity.
        /// </summary>
        /// <remarks>
        /// Accessing data in a managed object forfeits many opportunities for increased performance. Adding
        /// managed objects to an entity should be avoided or used sparingly.
        ///
        /// Adding a component changes an entity's archetype and results in the entity being moved to a different
        /// chunk.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the object and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity to modify.</param>
        /// <param name="componentData">An object inheriting UnityEngine.Component.</param>
        /// <exception cref="ArgumentNullException">If the componentData object is not an instance of
        /// UnityEngine.Component.</exception>
        public void AddComponentObject(Entity entity, object componentData)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (componentData == null)
                throw new ArgumentNullException(nameof(componentData));
#endif

            ComponentType type = componentData.GetType();

            AddComponent(entity, type);
            SetComponentObject(entity, type, componentData);
        }        

        /// <summary>
        /// Adds a shared component to an entity.
        /// </summary>
        /// <remarks>
        /// The fields of the `componentData` parameter are assigned to the added shared component.
        ///
        /// Adding a component to an entity changes its archetype and results in the entity being moved to a
        /// different chunk. The entity moves to a chunk with other entities that have the same shared component values.
        /// A new chunk is created if no chunk with the same archetype and shared component values currently exists.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entity">The entity.</param>
        /// <param name="componentData">An instance of the shared component having the values to set.</param>
        /// <typeparam name="T">The shared component type.</typeparam>
        public void AddSharedComponentData<T>(Entity entity, T componentData) where T : struct, ISharedComponentData
        {
            //TODO: optimize this (no need to move the entity to a new chunk twice)
            AddComponent(entity, ComponentType.ReadWrite<T>(), false);
            SetSharedComponentData(entity, componentData);
        }

        /// <summary>
        /// Adds a shared component to a set of entities defined by a EntityQuery.
        /// </summary>
        /// <remarks>
        /// The fields of the `componentData` parameter are assigned to all of the added shared components.
        ///
        /// Adding a component to an entity changes its archetype and results in the entity being moved to a
        /// different chunk. The entity moves to a chunk with other entities that have the same shared component values.
        /// A new chunk is created if no chunk with the same archetype and shared component values currently exists.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before adding the component and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="entityQuery">The EntityQuery defining a set of entities to modify.</param>
        /// <param name="componentData">The data to set.</param>
        /// <typeparam name="T">The data type of the shared component.</typeparam>
        public void AddSharedComponentData<T>(EntityQuery entityQuery, T componentData)
            where T : struct, ISharedComponentData
        {
            var componentType = ComponentType.ReadWrite<T>();
            using (var chunks = entityQuery.CreateArchetypeChunkArray(Allocator.TempJob))
            {
                if (chunks.Length == 0)
                    return;
                BeforeStructuralChange();
                var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

                var newSharedComponentDataIndex = m_ManagedComponentStore.InsertSharedComponent(componentData);
                EntityComponentStore->AssertCanAddComponent(chunks, componentType);
                EntityManagerChangeArchetypeUtility.AddSharedComponent(chunks, componentType, newSharedComponentDataIndex, EntityComponentStore, ManagedComponentStore);
                m_ManagedComponentStore.RemoveReference(newSharedComponentDataIndex);

                var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
        }    

        /// <summary>
        /// Enabled entities are processed by systems, disabled entities are not.
        /// Adds or removes the <see cref="Disabled"/> component. By default EntityQuery does not include entities containing the Disabled component.
        ///
        /// If the entity was converted from a prefab and thus has a <see cref="LinkedEntityGroup"/> component, the entire group will enabled or disabled.
        /// </summary>
        /// <param name="entity">The entity to enable or disable</param>
        /// <param name="enabled">True if the entity should be enabled</param>
        public void SetEnabled(Entity entity, bool enabled)
        {
            if (GetEnabled(entity) == enabled)
                return;

            var disabledType = ComponentType.ReadWrite<Disabled>();
            if (HasComponent<LinkedEntityGroup>(entity))
            {
                //@TODO: AddComponent / Remove component should support Allocator.Temp
                using (var linkedEntities = GetBuffer<LinkedEntityGroup>(entity).Reinterpret<Entity>().ToNativeArray(Allocator.TempJob))
                {
                    if (enabled)
                        RemoveComponent(linkedEntities, disabledType);
                    else
                        AddComponent(linkedEntities, disabledType);
                }
            }
            else
            {
                if (!enabled)
                    AddComponent(entity, disabledType);
                else
                    RemoveComponent(entity, disabledType);
            }
        }

        public bool GetEnabled(Entity entity)
        {
            return !HasComponent<Disabled>(entity);
        }    
        
        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
        
        internal void AddComponent(Entity entity, ComponentType componentType, bool ignoreDuplicateAdd)
        {
            if (ignoreDuplicateAdd && HasComponent(entity, componentType))
                return;

            BeforeStructuralChange();
            var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

            EntityComponentStore->AssertCanAddComponent(entity, componentType);
            EntityManagerChangeArchetypeUtility.AddComponent(entity, componentType, EntityComponentStore, ManagedComponentStore);

            var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }
        
        internal void AddComponent(MatchingArchetypeList archetypeList, EntityQueryFilter filter,
            ComponentType componentType)
        {
            var jobHandle = new JobHandle();
            using (var chunks = ComponentChunkIterator.CreateArchetypeChunkArray(archetypeList, Allocator.TempJob, out jobHandle, ref filter))
            {
                jobHandle.Complete();
                if (chunks.Length == 0)
                    return;
                
                BeforeStructuralChange();
                var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

                EntityComponentStore->AssertCanAddComponent(chunks, componentType);

                using (var entityBatchList = m_EntityComponentStore->CreateEntityBatchList(chunks))
                {
                    EntityManagerChangeArchetypeUtility.AddComponentFromMainThread(entityBatchList, componentType, 0,
                        EntityComponentStore,
                        ManagedComponentStore);
                }
                
                var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
        }
        
        internal void AddSharedComponentDataBoxed(Entity entity, int typeIndex, int hashCode, object componentData)
        {
            //TODO: optimize this (no need to move the entity to a new chunk twice)
            AddComponent(entity, ComponentType.FromTypeIndex(typeIndex));
            SetSharedComponentDataBoxed(entity, typeIndex, hashCode, componentData);
        }
        
        internal void AddSharedComponentDataBoxed(MatchingArchetypeList archetypeList, EntityQueryFilter filter, int typeIndex, int hashCode, object componentData)
        {
            //TODO: optimize this (no need to move the entity to a new chunk twice)

            var newSharedComponentDataIndex = 0;
            if (componentData != null) // null means default
                newSharedComponentDataIndex = ManagedComponentStore.InsertSharedComponentAssumeNonDefault(typeIndex,
                    hashCode, componentData);
            
            AddSharedComponentData(archetypeList, filter, newSharedComponentDataIndex, ComponentType.FromTypeIndex(typeIndex));
        }
        
        internal void AddSharedComponentData(MatchingArchetypeList archetypeList, EntityQueryFilter filter, int sharedComponentIndex, ComponentType componentType)
        {
            var jobHandle = new JobHandle();
            using (var chunks = ComponentChunkIterator.CreateArchetypeChunkArray(archetypeList, Allocator.TempJob, out jobHandle, ref filter))
            {
                jobHandle.Complete();
                if (chunks.Length == 0)
                    return;
                BeforeStructuralChange();
                var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

                EntityComponentStore->AssertCanAddComponent(chunks, componentType);
                EntityManagerChangeArchetypeUtility.AddSharedComponent(chunks, componentType, sharedComponentIndex, EntityComponentStore, ManagedComponentStore);
                ManagedComponentStore.RemoveReference(sharedComponentIndex);

                var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
        } 
        
        internal void AddComponentRaw(Entity entity, int typeIndex)
        {
            AddComponent(entity, ComponentType.FromTypeIndex(typeIndex));
        }

        internal void RemoveComponentRaw(Entity entity, int typeIndex)
        {
            RemoveComponent(entity, ComponentType.FromTypeIndex(typeIndex));
        }
        
        internal void RemoveComponent(MatchingArchetypeList archetypeList, EntityQueryFilter filter,
            ComponentType componentType)
        {
            var jobHandle = new JobHandle();
            using (var chunks = ComponentChunkIterator.CreateArchetypeChunkArray(archetypeList, Allocator.TempJob, out jobHandle, ref filter))
            {
                jobHandle.Complete();
                if (chunks.Length == 0)
                    return;
                
                BeforeStructuralChange();
                var archetypeChanges =  EntityComponentStore->BeginArchetypeChangeTracking();

                EntityComponentStore->AssertCanRemoveComponent(chunks, componentType);
                EntityManagerChangeArchetypeUtility.RemoveComponent(chunks, componentType,
                    EntityComponentStore,
                    ManagedComponentStore);
                
                var changedArchetypes =  EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }
        }
    }
}
