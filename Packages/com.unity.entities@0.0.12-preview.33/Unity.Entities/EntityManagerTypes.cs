using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        // ----------------------------------------------------------------------------------------------------------
        // PUBLIC
        // ----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets the dynamic type object required to access a chunk component of type T.
        /// </summary>
        /// <remarks>
        /// To access a component stored in a chunk, you must have the type registry information for the component.
        /// This function provides that information. Use the returned <see cref="ArchetypeChunkComponentType{T}"/>
        /// object with the functions of an <see cref="ArchetypeChunk"/> object to get information about the components
        /// in that chunk and to access the component values.
        /// </remarks>
        /// <param name="isReadOnly">Specify whether the access to the component through this object is read only
        /// or read and write. </param>
        /// <typeparam name="T">The compile-time type of the component.</typeparam>
        /// <returns>The run-time type information of the component.</returns>
        public ArchetypeChunkComponentType<T> GetArchetypeChunkComponentType<T>(bool isReadOnly)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var typeIndex = TypeManager.GetTypeIndex<T>();
            return new ArchetypeChunkComponentType<T>(
                ComponentJobSafetyManager->GetSafetyHandle(typeIndex, isReadOnly), isReadOnly,
                GlobalSystemVersion);
#else
            return new ArchetypeChunkComponentType<T>(isReadOnly, GlobalSystemVersion);
#endif
        }

        /// <summary>
        /// Gets the dynamic type object required to access a chunk buffer containing elements of type T.
        /// </summary>
        /// <remarks>
        /// To access a component stored in a chunk, you must have the type registry information for the component.
        /// This function provides that information for buffer components. Use the returned
        /// <see cref="ArchetypeChunkComponentType{T}"/> object with the functions of an <see cref="ArchetypeChunk"/>
        /// object to get information about the components in that chunk and to access the component values.
        /// </remarks>
        /// <param name="isReadOnly">Specify whether the access to the component through this object is read only
        /// or read and write. </param>
        /// <typeparam name="T">The compile-time type of the buffer elements.</typeparam>
        /// <returns>The run-time type information of the buffer component.</returns>
        public ArchetypeChunkBufferType<T> GetArchetypeChunkBufferType<T>(bool isReadOnly)
            where T : struct, IBufferElementData
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var typeIndex = TypeManager.GetTypeIndex<T>();
            return new ArchetypeChunkBufferType<T>(
                ComponentJobSafetyManager->GetSafetyHandle(typeIndex, isReadOnly),
                ComponentJobSafetyManager->GetBufferSafetyHandle(typeIndex),
                isReadOnly, GlobalSystemVersion);
#else
            return new ArchetypeChunkBufferType<T>(isReadOnly,GlobalSystemVersion);
#endif
        }
        
        /// <summary>
        /// Gets the dynamic type object required to access a shared component of type T.
        /// </summary>
        /// <remarks>
        /// To access a component stored in a chunk, you must have the type registry information for the component.
        /// This function provides that information for shared components. Use the returned
        /// <see cref="ArchetypeChunkComponentType{T}"/> object with the functions of an <see cref="ArchetypeChunk"/>
        /// object to get information about the components in that chunk and to access the component values.
        /// </remarks>
        /// <typeparam name="T">The compile-time type of the shared component.</typeparam>
        /// <returns>The run-time type information of the shared component.</returns>
        public ArchetypeChunkSharedComponentType<T> GetArchetypeChunkSharedComponentType<T>()
            where T : struct, ISharedComponentData
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            return new ArchetypeChunkSharedComponentType<T>(
                ComponentJobSafetyManager->GetEntityManagerSafetyHandle());
#else
            return new ArchetypeChunkSharedComponentType<T>(false);
#endif
        }
        
        /// <summary>
        /// Gets the dynamic type object required to access the <see cref="Entity"/> component of a chunk.
        /// </summary>
        /// <remarks>
        /// All chunks have an implicit <see cref="Entity"/> component referring to the entities in that chunk.
        ///
        /// To access any component stored in a chunk, you must have the type registry information for the component.
        /// This function provides that information for the implicit <see cref="Entity"/> component. Use the returned
        /// <see cref="ArchetypeChunkComponentType{T}"/> object with the functions of an <see cref="ArchetypeChunk"/>
        /// object to access the component values.
        /// </remarks>
        /// <returns>The run-time type information of the Entity component.</returns>
        public ArchetypeChunkEntityType GetArchetypeChunkEntityType()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            return new ArchetypeChunkEntityType(
                ComponentJobSafetyManager->GetSafetyHandle(TypeManager.GetTypeIndex<Entity>(), true));
#else
            return new ArchetypeChunkEntityType(false);
#endif
        }
        
        /// <summary>
        /// Gets an entity's component types.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="allocator">The type of allocation for creating the NativeArray to hold the ComponentType
        /// objects.</param>
        /// <returns>An array of ComponentType containing all the types of components associated with the entity.</returns>
        public NativeArray<ComponentType> GetComponentTypes(Entity entity, Allocator allocator = Allocator.Temp)
        {
            EntityComponentStore->AssertEntitiesExist(&entity, 1);

            var archetype = EntityComponentStore->GetArchetype(entity);

            var components = new NativeArray<ComponentType>(archetype->TypesCount - 1, allocator);

            for (var i = 1; i < archetype->TypesCount; i++)
                components[i - 1] = archetype->Types[i].ToComponentType();

            return components;
        }
        
        /// <summary>
        /// Gets a list of the types of components that can be assigned to the specified component.
        /// </summary>
        /// <remarks>Assignable components include those with the same compile-time type and those that
        /// inherit from the same compile-time type.</remarks>
        /// <param name="interfaceType">The type to check.</param>
        /// <returns>A new List object containing the System.Types that can be assigned to `interfaceType`.</returns>
        public List<Type> GetAssignableComponentTypes(Type interfaceType)
        {
            // #todo Cache this. It only can change when TypeManager.GetTypeCount() changes
            var componentTypeCount = TypeManager.GetTypeCount();
            var assignableTypes = new List<Type>();
            for (var i = 0; i < componentTypeCount; i++)
            {
                var type = TypeManager.GetType(i);
                if (interfaceType.IsAssignableFrom(type)) assignableTypes.Add(type);
            }

            return assignableTypes;
        }

        // ----------------------------------------------------------------------------------------------------------
        // INTERNAL
        // ----------------------------------------------------------------------------------------------------------
        
        internal int GetComponentTypeIndex(Entity entity, int index)
        {
            EntityComponentStore->AssertEntitiesExist(&entity, 1);
            var archetype = EntityComponentStore->GetArchetype(entity);

            if ((uint) index >= archetype->TypesCount) return -1;

            return archetype->Types[index + 1].TypeIndex;
        }
    }
}
