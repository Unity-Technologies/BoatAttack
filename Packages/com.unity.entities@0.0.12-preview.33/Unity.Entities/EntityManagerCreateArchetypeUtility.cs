using Unity.Assertions;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    /// <summary>
    /// Utilities which work on EntityManager data (for CreateArchetype)
    /// Which require more than one of of these, in this order, as last parameters:
    ///     EntityComponentStore* entityComponentStore
    ///     SharedComponentDataManager sharedComponentDataManager
    /// </summary>
    internal static unsafe class EntityManagerCreateArchetypeUtility
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        public static Archetype* GetOrCreateArchetype(ComponentTypeInArchetype* inTypesSorted, int count,
            EntityComponentStore* entityComponentStore)
        {
            var srcArchetype = entityComponentStore->GetExistingArchetype(inTypesSorted, count);
            if (srcArchetype != null)
                return srcArchetype;

            srcArchetype = entityComponentStore->CreateArchetype(inTypesSorted, count);
            var types = stackalloc ComponentTypeInArchetype[count + 1];

            // Setup Instantiable archetype
            {
                UnsafeUtility.MemCpy(types, inTypesSorted, sizeof(ComponentTypeInArchetype) * count);

                var hasCleanup = false;
                var removedTypes = 0;
                var prefabTypeIndex = TypeManager.GetTypeIndex<Prefab>();
                var cleanupTypeIndex = TypeManager.GetTypeIndex<CleanupEntity>();
                for (var t = 0; t < srcArchetype->TypesCount; ++t)
                {
                    var type = srcArchetype->Types[t];

                    hasCleanup |= type.TypeIndex == cleanupTypeIndex;

                    var skip = type.IsSystemStateComponent || type.TypeIndex == prefabTypeIndex;
                    if (skip)
                        ++removedTypes;
                    else
                        types[t - removedTypes] = srcArchetype->Types[t];
                }

                // Entity has already been destroyed, so it shouldn't be instantiated anymore
                if (hasCleanup)
                {
                    srcArchetype->InstantiableArchetype = null;
                }
                else if (removedTypes > 0)
                {
                    var instantiableArchetype = GetOrCreateArchetype(types, count - removedTypes, entityComponentStore);

                    srcArchetype->InstantiableArchetype = instantiableArchetype;
                    Assert.IsTrue(instantiableArchetype->InstantiableArchetype == instantiableArchetype);
                    Assert.IsTrue(instantiableArchetype->SystemStateResidueArchetype == null);
                }
                else
                {
                    srcArchetype->InstantiableArchetype = srcArchetype;
                }
            }
            
            
            // Setup System state cleanup archetype
            if (srcArchetype->SystemStateCleanupNeeded)
            {
                var cleanupEntityType = new ComponentTypeInArchetype(ComponentType.ReadWrite<CleanupEntity>());
                bool cleanupAdded = false;

                types[0] = inTypesSorted[0];
                var newTypeCount = 1;

                for (var t = 1; t < srcArchetype->TypesCount; ++t)
                {
                    var type = srcArchetype->Types[t];

                    if (type.IsSystemStateComponent)
                    {
                        if (!cleanupAdded && (cleanupEntityType < srcArchetype->Types[t]))
                        {
                            types[newTypeCount++] = cleanupEntityType;
                            cleanupAdded = true;
                        }

                        types[newTypeCount++] = srcArchetype->Types[t];
                    }
                }

                if (!cleanupAdded)
                {
                    types[newTypeCount++] = cleanupEntityType;
                }

                var systemStateResidueArchetype = GetOrCreateArchetype(types, newTypeCount, entityComponentStore);
                srcArchetype->SystemStateResidueArchetype = systemStateResidueArchetype;

                Assert.IsTrue(systemStateResidueArchetype->SystemStateResidueArchetype == systemStateResidueArchetype);
                Assert.IsTrue(systemStateResidueArchetype->InstantiableArchetype == null);
            }

            // Setup meta chunk archetype
            if (count > 1)
            {
                types[0] = new ComponentTypeInArchetype(typeof(Entity));
                int metaArchetypeTypeCount = 1;
                for (int i = 1; i < count; ++i)
                {
                    var t = inTypesSorted[i];
                    ComponentType typeToInsert;
                    if (inTypesSorted[i].IsChunkComponent)
                    {
                        typeToInsert = new ComponentType
                        {
                            TypeIndex = TypeManager.ChunkComponentToNormalTypeIndex(t.TypeIndex)
                        };
                        SortingUtilities.InsertSorted(types, metaArchetypeTypeCount++, typeToInsert);
                    }
                }

                if (metaArchetypeTypeCount > 1)
                {
                    SortingUtilities.InsertSorted(types, metaArchetypeTypeCount++, new ComponentType(typeof(ChunkHeader)));
                    srcArchetype->MetaChunkArchetype = GetOrCreateArchetype(types, metaArchetypeTypeCount, entityComponentStore);
                }
            }
            
            return srcArchetype;
        }

        public static Archetype* GetArchetypeWithAddedComponentType(Archetype* archetype, ComponentType addedComponentType, EntityComponentStore* entityComponentStore, int* indexInTypeArray = null)
        {
            var componentType = new ComponentTypeInArchetype(addedComponentType);
            ComponentTypeInArchetype* newTypes = stackalloc ComponentTypeInArchetype[archetype->TypesCount + 1];

            var t = 0;
            while (t < archetype->TypesCount && archetype->Types[t] < componentType)
            {
                newTypes[t] = archetype->Types[t];
                ++t;
            }

            if(indexInTypeArray != null)
                *indexInTypeArray = t;

            if(archetype->Types[t] == componentType)
            {
                Assert.IsTrue(addedComponentType.IgnoreDuplicateAdd, $"{addedComponentType} is already part of the archetype.");
                // Tag component type is already there, no new archetype required.
                return null;
            }

            newTypes[t] = componentType;
            while (t < archetype->TypesCount)
            {
                newTypes[t + 1] = archetype->Types[t];
                ++t;
            }

            return GetOrCreateArchetype(newTypes,archetype->TypesCount + 1, entityComponentStore);
        }

        public static Archetype* GetArchetypeWithRemovedComponentType(Archetype* archetype, ComponentType addedComponentType, EntityComponentStore* entityComponentStore, int* indexInOldTypeArray = null)
        {
            var componentType = new ComponentTypeInArchetype(addedComponentType);
            ComponentTypeInArchetype* newTypes = stackalloc ComponentTypeInArchetype[archetype->TypesCount];

            var removedTypes = 0;
            for (var t = 0; t < archetype->TypesCount; ++t)
                if (archetype->Types[t].TypeIndex == componentType.TypeIndex)
                {
                    if(indexInOldTypeArray != null)
                        *indexInOldTypeArray = t;
                    ++removedTypes;
                }
                else
                    newTypes[t - removedTypes] = archetype->Types[t];

            return GetOrCreateArchetype(newTypes,archetype->TypesCount - removedTypes, entityComponentStore);
        }
        
        
        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------

    }
}
