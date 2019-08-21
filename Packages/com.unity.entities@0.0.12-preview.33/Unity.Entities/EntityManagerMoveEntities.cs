using System;
using Unity.Collections;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Moves all entities managed by the specified EntityManager to the <see cref="World"/> of this EntityManager and fills
        /// an array with their <see cref="Entity"/> objects.
        /// </summary>
        /// <remarks>
        /// After the move, the entities are managed by this EntityManager. Use the `output` array to make post-move
        /// changes to the transferred entities.
        ///
        /// Each world has one EntityManager, which manages all the entities in that world. This function
        /// allows you to transfer entities from one World to another.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before moving the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="output">An array to receive the Entity objects of the transferred entities.</param>
        /// <param name="srcEntities">The EntityManager whose entities are appropriated.</param>
        /// <param name="entityRemapping">A set of entity transformations to make during the transfer.</param>
        /// <exception cref="ArgumentException"></exception>
        public void MoveEntitiesFrom(out NativeArray<Entity> output, EntityManager srcEntities,
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (srcEntities == this)
                throw new ArgumentException("srcEntities must not be the same as this EntityManager.");

            if (!srcEntities.m_ManagedComponentStore.AllSharedComponentReferencesAreFromChunks(srcEntities
                .EntityComponentStore))
                throw new ArgumentException(
                    "EntityManager.MoveEntitiesFrom failed - All ISharedComponentData references must be from EntityManager. (For example EntityQuery.SetFilter with a shared component type is not allowed during EntityManager.MoveEntitiesFrom)");
#endif

            BeforeStructuralChange();
            srcEntities.BeforeStructuralChange();
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            EntityManagerMoveEntitiesUtility.MoveChunks(entityRemapping,
                srcEntities.EntityComponentStore, srcEntities.ManagedComponentStore,
                EntityComponentStore, ManagedComponentStore);

            EntityRemapUtility.GetTargets(out output, entityRemapping);
            
            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);

            //@TODO: Need to increment the component versions based the moved chunks...
        }

        /// <summary>
        /// Moves a selection of the entities managed by the specified EntityManager to the <see cref="World"/> of this EntityManager
        /// and fills an array with their <see cref="Entity"/> objects.
        /// </summary>
        /// <remarks>
        /// After the move, the entities are managed by this EntityManager. Use the `output` array to make post-move
        /// changes to the transferred entities.
        ///
        /// Each world has one EntityManager, which manages all the entities in that world. This function
        /// allows you to transfer entities from one World to another.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before moving the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="output">An array to receive the Entity objects of the transferred entities.</param>
        /// <param name="srcEntities">The EntityManager whose entities are appropriated.</param>
        /// <param name="filter">A EntityQuery that defines the entities to move. Must be part of the source
        /// World.</param>
        /// <param name="entityRemapping">A set of entity transformations to make during the transfer.</param>
        /// <exception cref="ArgumentException"></exception>
        public void MoveEntitiesFrom(out NativeArray<Entity> output, EntityManager srcEntities, EntityQuery filter,
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (filter.EntityComponentStore != srcEntities.EntityComponentStore)
                throw new ArgumentException(
                    "EntityManager.MoveEntitiesFrom failed - srcEntities and filter must belong to the same World)");
#endif
            using (var chunks = filter.CreateArchetypeChunkArray(Allocator.TempJob))
            {
                MoveEntitiesFrom(out output, srcEntities, chunks, entityRemapping);
            }
        }

        /// <summary>
        /// Moves all entities managed by the specified EntityManager to the <see cref="World"/> of this EntityManager and fills
        /// an array with their Entity objects.
        /// </summary>
        /// <remarks>
        /// After the move, the entities are managed by this EntityManager. Use the `output` array to make post-move
        /// changes to the transferred entities.
        ///
        /// Each world has one EntityManager, which manages all the entities in that world. This function
        /// allows you to transfer entities from one World to another.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before moving the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="output">An array to receive the Entity objects of the transferred entities.</param>
        /// <param name="srcEntities">The EntityManager whose entities are appropriated.</param>
        public void MoveEntitiesFrom(out NativeArray<Entity> output, EntityManager srcEntities)
        {
            var entityRemapping = srcEntities.CreateEntityRemapArray(Allocator.TempJob);
            try
            {
                MoveEntitiesFrom(out output, srcEntities, entityRemapping);
            }
            finally
            {
                entityRemapping.Dispose();
            }
        }

        /// <summary>
        /// Moves a selection of the entities managed by the specified EntityManager to the <see cref="World"/> of this EntityManager.
        /// </summary>
        /// <remarks>
        /// After the move, the entities are managed by this EntityManager.
        ///
        /// Each world has one EntityManager, which manages all the entities in that world. This function
        /// allows you to transfer entities from one World to another.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before moving the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="srcEntities">The EntityManager whose entities are appropriated.</param>
        /// <param name="filter">A EntityQuery that defines the entities to move. Must be part of the source
        /// World.</param>
        /// <param name="entityRemapping">A set of entity transformations to make during the transfer.</param>
        /// <exception cref="ArgumentException">Thrown if the EntityQuery object used as the `filter` comes
        /// from a different world than the `srcEntities` EntityManager.</exception>
        public void MoveEntitiesFrom(EntityManager srcEntities, EntityQuery filter,
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (filter.EntityComponentStore != srcEntities.EntityComponentStore)
                throw new ArgumentException(
                    "EntityManager.MoveEntitiesFrom failed - srcEntities and filter must belong to the same World)");
#endif
            using (var chunks = filter.CreateArchetypeChunkArray(Allocator.TempJob))
            {
                MoveEntitiesFrom(srcEntities, chunks, entityRemapping);
            }
        }

        /// <summary>
        /// Creates a remapping array with one element for each entity in the <see cref="World"/>.
        /// </summary>
        /// <param name="allocator">The type of memory allocation to use when creating the array.</param>
        /// <returns>An array containing a no-op identity transformation for each entity.</returns>
        public NativeArray<EntityRemapUtility.EntityRemapInfo> CreateEntityRemapArray(Allocator allocator)
        {
            return new NativeArray<EntityRemapUtility.EntityRemapInfo>(m_EntityComponentStore->EntitiesCapacity, allocator);
        }

        // @TODO Proper description of remap utility.
        /// <summary>
        /// Moves all entities managed by the specified EntityManager to the <see cref="World"/> of this EntityManager.
        /// </summary>
        /// <remarks>
        /// After the move, the entities are managed by this EntityManager.
        ///
        /// Each World has one EntityManager, which manages all the entities in that world. This function
        /// allows you to transfer entities from one world to another.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before moving the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="srcEntities">The EntityManager whose entities are appropriated.</param>
        /// <param name="entityRemapping">A set of entity transformations to make during the transfer.</param>
        /// <exception cref="ArgumentException">Thrown if you attempt to transfer entities to the EntityManager
        /// that already owns them.</exception>
        public void MoveEntitiesFrom(EntityManager srcEntities,
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (srcEntities == this)
                throw new ArgumentException("srcEntities must not be the same as this EntityManager.");

            if (entityRemapping.Length < srcEntities.m_EntityComponentStore->EntitiesCapacity)
                throw new ArgumentException(
                    "entityRemapping.Length isn't large enough, use srcEntities.CreateEntityRemapArray");

            if (!srcEntities.m_ManagedComponentStore.AllSharedComponentReferencesAreFromChunks(srcEntities
                .EntityComponentStore))
                throw new ArgumentException(
                    "EntityManager.MoveEntitiesFrom failed - All ISharedComponentData references must be from EntityManager. (For example EntityQuery.SetFilter with a shared component type is not allowed during EntityManager.MoveEntitiesFrom)");
#endif

            BeforeStructuralChange();
            srcEntities.BeforeStructuralChange();
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            EntityManagerMoveEntitiesUtility.MoveChunks(entityRemapping,
                srcEntities.EntityComponentStore, srcEntities.ManagedComponentStore,
                EntityComponentStore, ManagedComponentStore);

            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);

            //@TODO: Need to increment the component versions based the moved chunks...
        }

        /// <summary>
        /// Moves all entities managed by the specified EntityManager to the world of this EntityManager.
        /// </summary>
        /// <remarks>
        /// The entities moved are owned by this EntityManager.
        ///
        /// Each <see cref="World"/> has one EntityManager, which manages all the entities in that world. This function
        /// allows you to transfer entities from one World to another.
        ///
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before moving the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="srcEntities">The EntityManager whose entities are appropriated.</param>
        public void MoveEntitiesFrom(EntityManager srcEntities)
        {
            var entityRemapping = srcEntities.CreateEntityRemapArray(Allocator.TempJob);
            try
            {
                MoveEntitiesFrom(srcEntities, entityRemapping);
            }
            finally
            {
                entityRemapping.Dispose();
            }
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        void MoveEntitiesFrom(out NativeArray<Entity> output, EntityManager srcEntities,
            NativeArray<ArchetypeChunk> chunks, NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (srcEntities == this)
                throw new ArgumentException("srcEntities must not be the same as this EntityManager.");
            for (int i = 0; i < chunks.Length; ++i)
                if (chunks[i].m_Chunk->Archetype->HasChunkHeader)
                    throw new ArgumentException(
                        "MoveEntitiesFrom can not move chunks that contain ChunkHeader components.");
#endif

            BeforeStructuralChange();
            srcEntities.BeforeStructuralChange();
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            EntityManagerMoveEntitiesUtility.MoveChunks(chunks, entityRemapping,
                srcEntities.EntityComponentStore, srcEntities.ManagedComponentStore,
                EntityComponentStore, ManagedComponentStore);

            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);

            EntityRemapUtility.GetTargets(out output, entityRemapping);
        }

        void MoveEntitiesFrom(EntityManager srcEntities, NativeArray<ArchetypeChunk> chunks,
            NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapping)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (srcEntities == this)
                throw new ArgumentException("srcEntities must not be the same as this EntityManager.");

            if (entityRemapping.Length < srcEntities.m_EntityComponentStore->EntitiesCapacity)
                throw new ArgumentException(
                    "entityRemapping.Length isn't large enough, use srcEntities.CreateEntityRemapArray");

            for (int i = 0; i < chunks.Length; ++i)
                if (chunks[i].m_Chunk->Archetype->HasChunkHeader)
                    throw new ArgumentException(
                        "MoveEntitiesFrom can not move chunks that contain ChunkHeader components.");
#endif

            BeforeStructuralChange();
            srcEntities.BeforeStructuralChange();
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();
          
            EntityManagerMoveEntitiesUtility.MoveChunks(chunks, entityRemapping,
                srcEntities.EntityComponentStore, srcEntities.ManagedComponentStore,
                EntityComponentStore, ManagedComponentStore);
            
            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
        }
    }
}
