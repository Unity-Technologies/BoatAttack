namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------
        
        // @TODO Point to documentation for multithreaded way to check Entity validity.
        /// <summary>
        /// Reports whether an Entity object is still valid.
        /// </summary>
        /// <remarks>
        /// An Entity object does not contain a reference to its entity. Instead, the Entity struct contains an index
        /// and a generational version number. When an entity is destroyed, the EntityManager increments the version
        /// of the entity within the internal array of entities. The index of a destroyed entity is recycled when a
        /// new entity is created.
        ///
        /// After an entity is destroyed, any existing Entity objects will still contain the
        /// older version number. This function compares the version numbers of the specified Entity object and the
        /// current version of the entity recorded in the entities array. If the versions are different, the Entity
        /// object no longer refers to an existing entity and cannot be used.
        /// </remarks>
        /// <param name="entity">The Entity object to check.</param>
        /// <returns>True, if <see cref="Entity.Version"/> matches the version of the current entity at
        /// <see cref="Entity.Index"/> in the entities array.</returns>
        public bool Exists(Entity entity)
        {
            return EntityComponentStore->Exists(entity);
        }

        /// <summary>
        /// Checks whether an entity has a specific type of component.
        /// </summary>
        /// <remarks>Always returns false for an entity that has been destroyed.</remarks>
        /// <param name="entity">The Entity object.</param>
        /// <typeparam name="T">The data type of the component.</typeparam>
        /// <returns>True, if the specified entity has the component.</returns>
        public bool HasComponent<T>(Entity entity)
        {
            return EntityComponentStore->HasComponent(entity, ComponentType.ReadWrite<T>());
        }

        /// <summary>
        /// Checks whether an entity has a specific type of component.
        /// </summary>
        /// <remarks>Always returns false for an entity that has been destroyed.</remarks>
        /// <param name="entity">The Entity object.</param>
        /// <param name="type">The data type of the component.</param>
        /// <returns>True, if the specified entity has the component.</returns>
        public bool HasComponent(Entity entity, ComponentType type)
        {
            return EntityComponentStore->HasComponent(entity, type);
        }

        /// <summary>
        /// Checks whether the chunk containing an entity has a specific type of component.
        /// </summary>
        /// <remarks>Always returns false for an entity that has been destroyed.</remarks>
        /// <param name="entity">The Entity object.</param>
        /// <typeparam name="T">The data type of the chunk component.</typeparam>
        /// <returns>True, if the chunk containing the specified entity has the component.</returns>
        public bool HasChunkComponent<T>(Entity entity)
        {
            return EntityComponentStore->HasComponent(entity, ComponentType.ChunkComponent<T>());
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        internal bool HasComponentRaw(Entity entity, int typeIndex)
        {
            return EntityComponentStore->HasComponent(entity, typeIndex);
        }    
    }
}
