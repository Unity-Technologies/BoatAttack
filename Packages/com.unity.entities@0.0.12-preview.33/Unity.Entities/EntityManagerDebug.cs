using System;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

#if UNITY_EDITOR
        /// <summary>
        /// Gets the name assigned to an entity.
        /// </summary>
        /// <remarks>For performance, entity names only exist when running in the Unity Editor.</remarks>
        /// <param name="entity">The Entity object of the entity of interest.</param>
        /// <returns>The entity name.</returns>
        public string GetName(Entity entity)
        {
            return EntityComponentStore->GetName(entity);
        }

        /// <summary>
        /// Sets the name of an entity.
        /// </summary>
        /// <remarks>For performance, entity names only exist when running in the Unity Editor.</remarks>
        /// <param name="entity">The Entity object of the entity to name.</param>
        /// <param name="name">The name to assign.</param>
        public void SetName(Entity entity, string name)
        {
            EntityComponentStore->SetName(entity, name);
        }
#endif

        /// <summary>
        /// Gets all the entities managed by this EntityManager.
        /// </summary>
        /// <remarks>
        /// **Important:** This function creates a sync point, which means that the EntityManager waits for all
        /// currently running Jobs to complete before getting the entities and no additional Jobs can start before
        /// the function is finished. A sync point can cause a drop in performance because the ECS framework may not
        /// be able to make use of the processing power of all available cores.
        /// </remarks>
        /// <param name="allocator">The type of allocation for creating the NativeArray to hold the Entity objects.</param>
        /// <returns>An array of Entity objects referring to all the entities in the World.</returns>
        public NativeArray<Entity> GetAllEntities(Allocator allocator = Allocator.Temp)
        {
            BeforeStructuralChange();

            var chunks = GetAllChunks();
            var count = ArchetypeChunkArray.CalculateEntityCount(chunks);
            var array = new NativeArray<Entity>(count, allocator);
            var entityType = GetArchetypeChunkEntityType();
            var offset = 0;

            for (int i = 0; i < chunks.Length; i++)
            {
                var chunk = chunks[i];
                var entities = chunk.GetNativeArray(entityType);
                array.Slice(offset, entities.Length).CopyFrom(entities);
                offset += entities.Length;
            }

            chunks.Dispose();
            return array;
        }

        // @TODO document EntityManagerDebug
        /// <summary>
        /// Provides information and utility functions for debugging.
        /// </summary>
        public class EntityManagerDebug
        {
            private readonly EntityManager m_Manager;

            public EntityManagerDebug(EntityManager entityManager)
            {
                m_Manager = entityManager;
            }

            public void PoisonUnusedDataInAllChunks(EntityArchetype archetype, byte value)
            {
                for (var i = 0; i < archetype.Archetype->Chunks.Count; ++i)
                {
                    var chunk = archetype.Archetype->Chunks.p[i];
                    ChunkDataUtility.MemsetUnusedChunkData(chunk, value);
                }
            }

            public void SetGlobalSystemVersion(uint version)
            {
                m_Manager.EntityComponentStore->SetGlobalSystemVersion(version);
            }

            public bool IsSharedComponentManagerEmpty()
            {
                return m_Manager.m_ManagedComponentStore.IsEmpty();
            }

#if !NET_DOTS
            internal static string GetArchetypeDebugString(Archetype* a)
            {
                var buf = new System.Text.StringBuilder();
                buf.Append("(");

                for (var i = 0; i < a->TypesCount; i++)
                {
                    var componentTypeInArchetype = a->Types[i];
                    if (i > 0)
                        buf.Append(", ");
                    buf.Append(componentTypeInArchetype.ToString());
                }

                buf.Append(")");
                return buf.ToString();
            }
#endif

            public int EntityCount
            {
                get
                {
                    var allEntities = m_Manager.GetAllEntities();
                    var count = allEntities.Length;
                    allEntities.Dispose();
                    return count;
                }
            }

            internal Entity GetMetaChunkEntity(Entity entity)
            {
                return m_Manager.GetChunk(entity).m_Chunk->metaChunkEntity;
            }

            public void LogEntityInfo(Entity entity)
            {
                Unity.Debug.Log(GetEntityInfo(entity));
            }

            public string GetEntityInfo(Entity entity)
            {
                var archetype = m_Manager.EntityComponentStore->GetArchetype(entity);
#if !NET_DOTS
                var str = new System.Text.StringBuilder();
                str.Append(entity.ToString());
#if UNITY_EDITOR
                {
                    var name = m_Manager.GetName(entity);
                    if (!string.IsNullOrEmpty(name))
                        str.Append($" (name '{name}')");
                }
#endif
                for (var i = 0; i < archetype->TypesCount; i++)
                {
                    var componentTypeInArchetype = archetype->Types[i];
                    str.AppendFormat("  - {0}", componentTypeInArchetype.ToString());
                }

                return str.ToString();
#else
                    // @TODO Tiny really needs a proper string/stringutils implementation
                    string str = $"Entity {entity.Index}.{entity.Version}";
                    for (var i = 0; i < archetype->TypesCount; i++)
                    {
                        var componentTypeInArchetype = archetype->Types[i];
                        str += "  - {0}" + componentTypeInArchetype.ToString();
                    }

                    return str;
#endif
            }

#if !NET_DOTS
            public object GetComponentBoxed(Entity entity, ComponentType type)
            {
                m_Manager.EntityComponentStore->AssertEntityHasComponent(entity, type);

                var typeInfo = TypeManager.GetTypeInfo(type.TypeIndex);
                if (typeInfo.Category == TypeManager.TypeCategory.ComponentData)
                {
                    var obj = Activator.CreateInstance(TypeManager.GetType(type.TypeIndex));
                    if (!typeInfo.IsZeroSized)
                    {
                        ulong handle;
                        var ptr = (byte*) UnsafeUtility.PinGCObjectAndGetAddress(obj, out handle);
                        ptr += TypeManager.ObjectOffset;
                        var src = m_Manager.EntityComponentStore->GetComponentDataWithTypeRO(entity, type.TypeIndex);
                        UnsafeUtility.MemCpy(ptr, src, TypeManager.GetTypeInfo(type.TypeIndex).SizeInChunk);

                        UnsafeUtility.ReleaseGCObject(handle);
                    }

                    return obj;
                }
                else if (typeInfo.Category == TypeManager.TypeCategory.ISharedComponentData)
                {
                    return m_Manager.GetSharedComponentData(entity, type.TypeIndex);
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
            
            public object GetComponentBoxed(Entity entity, Type type)
            {
                m_Manager.EntityComponentStore->AssertEntitiesExist(&entity, 1);
                
                var archetype = m_Manager.m_EntityComponentStore->GetArchetype(entity);
                var typeIndex = ChunkDataUtility.GetTypeIndexFromType(archetype, type);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (typeIndex == -1)
                    throw new ArgumentException($"A component with type:{type} has not been added to the entity.");
#endif

                return GetComponentBoxed(entity, ComponentType.FromTypeIndex(typeIndex));
            }
#else
            public object GetComponentBoxed(Entity entity, Type type)
            {
                throw new System.NotImplementedException();
            }

            public object GetComponentBoxed(Entity entity, ComponentType type)
            {
                throw new System.NotImplementedException();
            }
#endif

            public void CheckInternalConsistency()
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                //@TODO: Validate from perspective of chunkquery...
                var entityCountByEntity = m_Manager.EntityComponentStore->CheckInternalConsistency();
                var entityCountByArchetype = EntityManagerDebugUtility.CheckInternalConsistency(m_Manager.EntityComponentStore);
                Assert.AreEqual(entityCountByEntity, entityCountByArchetype);
                Assert.IsTrue(m_Manager.ManagedComponentStore.AllSharedComponentReferencesAreFromChunks(m_Manager.EntityComponentStore));
                m_Manager.ManagedComponentStore.CheckInternalConsistency();

                var chunkQuery = m_Manager.CreateEntityQuery(new EntityQueryDesc { All = new ComponentType[] { typeof(ChunkHeader) } });
                int totalEntitiesFromQuery = m_Manager.UniversalQuery.CalculateLength() + chunkQuery.CalculateLength();
                Assert.AreEqual(entityCountByEntity, totalEntitiesFromQuery);
                chunkQuery.Dispose();
#endif
            }
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
    }
}
