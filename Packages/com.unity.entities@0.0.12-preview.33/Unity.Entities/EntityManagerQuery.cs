using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Creates a EntityQuery from an array of component types.
        /// </summary>
        /// <param name="requiredComponents">An array containing the component types.</param>
        /// <returns>The EntityQuery derived from the specified array of component types.</returns>
        /// <seealso cref="EntityQueryDesc"/>
        public EntityQuery CreateEntityQuery(params ComponentType[] requiredComponents)
        {
            fixed (ComponentType* requiredComponentsPtr = requiredComponents)
            {
                return m_EntityGroupManager.CreateEntityGroup(EntityComponentStore,
                    ManagedComponentStore, requiredComponentsPtr,
                    requiredComponents.Length);
            }
        }

        /// <summary>
        /// Creates a EntityQuery from an EntityQueryDesc.
        /// </summary>
        /// <param name="queriesDesc">A queryDesc identifying a set of component types.</param>
        /// <returns>The EntityQuery corresponding to the queryDesc.</returns>
        public EntityQuery CreateEntityQuery(params EntityQueryDesc[] queriesDesc)
        {
            return m_EntityGroupManager.CreateEntityGroup(EntityComponentStore,
                ManagedComponentStore, queriesDesc);
        }

        /// <summary>
        /// Gets all the chunks managed by this EntityManager.
        /// </summary>
        /// <remarks>
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before getting these chunks and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="allocator">The type of allocation for creating the NativeArray to hold the ArchetypeChunk
        /// objects.</param>
        /// <returns>An array of ArchetypeChunk objects referring to all the chunks in the <see cref="World"/>.</returns>
        public NativeArray<ArchetypeChunk> GetAllChunks(Allocator allocator = Allocator.TempJob)
        {
            BeforeStructuralChange();

            return m_UniversalQuery.CreateArchetypeChunkArray(allocator);
        }

        /// <summary>
        /// Gets all the archetypes.
        /// </summary>
        /// <remarks>The function adds the archetype objects to the existing contents of the list.
        /// The list is not cleared.</remarks>
        /// <param name="allArchetypes">A native list to receive the EntityArchetype objects.</param>
        public void GetAllArchetypes(NativeList<EntityArchetype> allArchetypes)
        {
            for (var i = EntityComponentStore->m_Archetypes.Count - 1; i >= 0; --i)
            {
                var archetype = EntityComponentStore->m_Archetypes.p[i];
                var entityArchetype = new EntityArchetype() {Archetype = archetype};
                allArchetypes.Add(entityArchetype);
            }
        }

        [Obsolete("Please use EntityQuery APIs instead.")]
        public NativeArray<ArchetypeChunk> CreateArchetypeChunkArray(NativeList<EntityArchetype> archetypes,
            Allocator allocator)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var safetyHandle = AtomicSafetyHandle.Create();
            return ArchetypeChunkArray.Create(archetypes, EntityComponentStore, allocator, safetyHandle);
#else
            return ArchetypeChunkArray.Create(archetypes, EntityComponentStore, allocator);
#endif
        }

        [Obsolete("Please use EntityQuery APIs instead.")]
        public NativeArray<ArchetypeChunk> CreateArchetypeChunkArray(EntityQueryDesc queryDesc, Allocator allocator)
        {
            var foundArchetypes = new NativeList<EntityArchetype>(Allocator.TempJob);
            AddMatchingArchetypes(queryDesc, foundArchetypes);
            var chunkStream = CreateArchetypeChunkArray(foundArchetypes, allocator);
            foundArchetypes.Dispose();
            return chunkStream;
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

        internal EntityQuery CreateEntityQuery(ComponentType* requiredComponents, int count)
        {
            return m_EntityGroupManager.CreateEntityGroup(EntityComponentStore,
                ManagedComponentStore, requiredComponents, count);
        }

        bool TestMatchingArchetypeAny(Archetype* archetype, ComponentType* anyTypes, int anyCount)
        {
            if (anyCount == 0) return true;

            var componentTypes = archetype->Types;
            var componentTypesCount = archetype->TypesCount;
            for (var i = 0; i < componentTypesCount; i++)
            {
                var componentTypeIndex = componentTypes[i].TypeIndex;
                for (var j = 0; j < anyCount; j++)
                {
                    var anyTypeIndex = anyTypes[j].TypeIndex;
                    if (componentTypeIndex == anyTypeIndex) return true;
                }
            }

            return false;
        }

        bool TestMatchingArchetypeNone(Archetype* archetype, ComponentType* noneTypes, int noneCount)
        {
            var componentTypes = archetype->Types;
            var componentTypesCount = archetype->TypesCount;
            for (var i = 0; i < componentTypesCount; i++)
            {
                var componentTypeIndex = componentTypes[i].TypeIndex;
                for (var j = 0; j < noneCount; j++)
                {
                    var noneTypeIndex = noneTypes[j].TypeIndex;
                    if (componentTypeIndex == noneTypeIndex) return false;
                }
            }

            return true;
        }

        bool TestMatchingArchetypeAll(Archetype* archetype, ComponentType* allTypes, int allCount)
        {
            var componentTypes = archetype->Types;
            var componentTypesCount = archetype->TypesCount;
            var foundCount = 0;
            var disabledTypeIndex = TypeManager.GetTypeIndex<Disabled>();
            var prefabTypeIndex = TypeManager.GetTypeIndex<Prefab>();
            var requestedDisabled = false;
            var requestedPrefab = false;
            for (var i = 0; i < componentTypesCount; i++)
            {
                var componentTypeIndex = componentTypes[i].TypeIndex;
                for (var j = 0; j < allCount; j++)
                {
                    var allTypeIndex = allTypes[j].TypeIndex;
                    if (allTypeIndex == disabledTypeIndex)
                        requestedDisabled = true;
                    if (allTypeIndex == prefabTypeIndex)
                        requestedPrefab = true;
                    if (componentTypeIndex == allTypeIndex) foundCount++;
                }
            }

            if (archetype->Disabled && (!requestedDisabled))
                return false;
            if (archetype->Prefab && (!requestedPrefab))
                return false;

            return foundCount == allCount;
        }

        [Obsolete("This function is deprecated and will be removed in a future release.")]
        public void AddMatchingArchetypes(EntityQueryDesc queryDesc, NativeList<EntityArchetype> foundArchetypes)
        {
            var anyCount = queryDesc.Any.Length;
            var noneCount = queryDesc.None.Length;
            var allCount = queryDesc.All.Length;

            fixed (ComponentType* any = queryDesc.Any)
            {
                fixed (ComponentType* none = queryDesc.None)
                {
                    fixed (ComponentType* all = queryDesc.All)
                    {
                        for (var i = EntityComponentStore->m_Archetypes.Count - 1; i >= 0; --i)
                        {
                            var archetype = EntityComponentStore->m_Archetypes.p[i];
                            if (archetype->EntityCount == 0)
                                continue;
                            if (!TestMatchingArchetypeAny(archetype, any, anyCount))
                                continue;
                            if (!TestMatchingArchetypeNone(archetype, none, noneCount))
                                continue;
                            if (!TestMatchingArchetypeAll(archetype, all, allCount))
                                continue;

                            var entityArchetype = new EntityArchetype {Archetype = archetype};
                            var found = foundArchetypes.Contains(entityArchetype);
                            if (!found)
                                foundArchetypes.Add(entityArchetype);
                        }
                    }
                }
            }
        }

        NativeArray<Entity> GetTempEntityArray(EntityQuery query)
        {
            var entityArray = query.ToEntityArray(Allocator.TempJob);
            return entityArray;
        }

        public EntityArchetype GetEntityOnlyArchetype()
        {
            if (!m_EntityOnlyArchetype.Valid)
            {
                var archetypeChanges = EntityComponentStore->BeginArchetypeChangeTracking();
                ComponentTypeInArchetype entityType = new ComponentTypeInArchetype(ComponentType.ReadWrite<Entity>());
                var archetype = EntityManagerCreateArchetypeUtility.GetOrCreateArchetype(&entityType,
                    1, EntityComponentStore);
                m_EntityOnlyArchetype = new EntityArchetype {Archetype = archetype};
                var changedArchetypes = EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
                EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);
            }

            return m_EntityOnlyArchetype;
        }
    }
}
