namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager 
    { 
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Creates an archetype from a set of component types.
        /// </summary>
        /// <remarks>
        /// Creates a new archetype in the ECS framework's internal type registry, unless the archetype already exists.
        /// </remarks>
        /// <param name="types">The component types to include as part of the archetype.</param>
        /// <returns>The EntityArchetype object for the archetype.</returns>
        public EntityArchetype CreateArchetype(params ComponentType[] types)
        {
            fixed (ComponentType* typesPtr = types)
            {
                return CreateArchetype(typesPtr, types.Length);
            }
        }
        
        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
        
        internal EntityArchetype CreateArchetype(ComponentType* types, int count)
        {
            ComponentTypeInArchetype* typesInArchetype = stackalloc ComponentTypeInArchetype[count + 1];
            var cachedComponentCount = FillSortedArchetypeArray(typesInArchetype, types, count);

            // Lookup existing archetype (cheap)
            EntityArchetype entityArchetype;
            entityArchetype.Archetype = EntityComponentStore->GetExistingArchetype(typesInArchetype, cachedComponentCount);
            if (entityArchetype.Archetype != null)
                return entityArchetype;

            // Creating an archetype invalidates all iterators / jobs etc
            // because it affects the live iteration linked lists...
            BeforeStructuralChange();
            var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();

            entityArchetype.Archetype = EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(typesInArchetype,
                cachedComponentCount, EntityComponentStore);

            var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            
            return entityArchetype;
        }
        
        internal static int FillSortedArchetypeArray(ComponentTypeInArchetype* dst, ComponentType* requiredComponents,
            int count)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (count + 1 > 1024)
                throw new System.ArgumentException($"Archetypes can't hold more than 1024 components");
#endif

            dst[0] = new ComponentTypeInArchetype(ComponentType.ReadWrite<Entity>());
            for (var i = 0; i < count; ++i)
                SortingUtilities.InsertSorted(dst, i + 1, requiredComponents[i]);
            return count + 1;
        }
        
        internal EntityArchetype CreateArchetypeRaw(int* typeIndices, int count)
        {
            // TODO fix this up
            ComponentType* ct = stackalloc ComponentType[count];
            for (int i = 0; i < count; ++i)
                ct[i] = ComponentType.FromTypeIndex(typeIndices[i]);
            return CreateArchetype(ct, count);
        }
    }
}
