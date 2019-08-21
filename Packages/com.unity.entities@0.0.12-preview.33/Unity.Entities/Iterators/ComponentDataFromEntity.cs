using Unity.Collections.LowLevel.Unsafe;

/*    

///*/

namespace Unity.Entities

{
    /// <summary>
    /// A [NativeContainer](https://docs.unity3d.com/ScriptReference/Unity.Collections.LowLevel.Unsafe.NativeContainerAttribute)
    /// that provides access to all instances of components of type T, indexed by <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IComponentData"/> to access.</typeparam>
    /// <remarks>
    /// ComponentDataFromEntity is a native container that provides array-like access to components of a specific
    /// type. You can use ComponentDataFromEntity to look up data associated with one entity while iterating over a 
    /// different set of entities. For example, Unity.Transforms stores the <see cref="Entity"/> object of parent entities 
    /// in a Parent component and looks up the parent's LocalToWorld matrix using 
    /// `ComponentDataFromEntity&lt;LocalToWorld&gt;` when calculating the world positions of child entities.
    ///
    /// To get a ComponentDataFromEntity, call <see cref="ComponentSystemBase.GetComponentDataFromEntity"/>.
    ///
    /// Pass a ComponentDataFromEntity container to a Job by defining a public field of the appropriate type
    /// in your IJob implementation. You can safely read from ComponentDataFromEntity in any Job, but by
    /// default, you cannot write to components in the container in parallel Jobs (including 
    /// <see cref="IJobForEach{T0}"/> and <see cref="IJobChunk"/>). If you know that two instances of a parallel
    /// Job can never write to the same index in the container, you can disable the restriction on parallel writing
    /// by adding
    /// [NativeDisableParallelForRestrictionAttribute] (https://docs.unity3d.com/ScriptReference/Unity.Collections.NativeDisableParallelForRestrictionAttribute.html) 
    /// to the ComponentDataFromEntity field definition in the Job struct.
    ///
    /// If you would like to access an entity's components outside of a job, consider using the <see cref="EntityManager"/> methods
    /// <see cref="EntityManager.GetComponentData"/> and <see cref="EntityManager.SetComponentData"/>
    /// instead, to avoid the overhead of creating a ComponentDataFromEntity object.
    /// </remarks>
    [NativeContainer]
    public unsafe struct ComponentDataFromEntity<T> where T : struct, IComponentData
    {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        readonly AtomicSafetyHandle      m_Safety;
#endif
        [NativeDisableUnsafePtrRestriction]
        readonly EntityComponentStore*             m_EntityComponentStore;
        readonly int                     m_TypeIndex;
        readonly uint                    m_GlobalSystemVersion;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        readonly bool                    m_IsZeroSized;          // cache of whether T is zero-sized
#endif
        int                              m_TypeLookupCache;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        internal ComponentDataFromEntity(int typeIndex, EntityComponentStore* entityComponentStoreComponentStore, AtomicSafetyHandle safety)
        {
            m_Safety = safety;
            m_TypeIndex = typeIndex;
            m_EntityComponentStore = entityComponentStoreComponentStore;
            m_TypeLookupCache = 0;
            m_GlobalSystemVersion = entityComponentStoreComponentStore->GlobalSystemVersion;
            m_IsZeroSized = ComponentType.FromTypeIndex(typeIndex).IsZeroSized;
        }
#else
        internal ComponentDataFromEntity(int typeIndex, EntityComponentStore* entityComponentStoreComponentStore)
        {
            m_TypeIndex = typeIndex;
            m_EntityComponentStore = entityComponentStoreComponentStore;
            m_TypeLookupCache = 0;
            m_GlobalSystemVersion = entityComponentStoreComponentStore->GlobalSystemVersion;
        }
#endif

        /// <summary>
        /// Reports whether the specified <see cref="Entity"/> instance still refers to a valid entity and that it has a
        /// component of type T.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>True if the entity has a component of type T, and false if it does not. Also returns false if 
        /// the Entity instance refers to an entity that has been destroyed.</returns>
        /// <remarks>To report if the provided entity has a component of type T, this function confirms
        /// whether the <see cref="EntityArchetype"/> of the provided entity includes components of type T.
        /// </remarks>
        public bool Exists(Entity entity)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.CheckReadAndThrow(m_Safety);
#endif
            //@TODO: out of bounds index checks...

            return m_EntityComponentStore->HasComponent(entity, m_TypeIndex);
        }

        /// <summary>
        /// Gets the <see cref="IComponentData"/> instance of type T for the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>An <see cref="IComponentData"/> type.</returns>
        /// <remarks>You cannot use ComponentDataFromEntity to get zero-sized <see cref="IComponentData"/>.
        /// Use <see cref="Exists"/> to check whether an entity has the zero-sized component instead.
        ///
        /// Normally, you cannot write to components accessed using a ComponentDataFromEntity instance
        /// in a parallel Job. This restriction is in place because multiple threads could write to the same component,
        /// leading to a race condition and nondeterministic results. However, when you are certain that your algorithm
        /// cannot write to the same component from different threads, you can manually disable this safety check 
        /// by putting the 
        /// [NativeDisableParallelForRestrictions](https://docs.unity3d.com/ScriptReference/Unity.Collections.NativeDisableParallelForRestrictionAttribute.html)
        /// attribute on the ComponentDataFromEntity field in the Job.
        /// </remarks>
        /// <exception cref="System.ArgumentException">Thrown if T is zero-size.</exception>
        public T this[Entity entity]
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                AtomicSafetyHandle.CheckReadAndThrow(m_Safety);
#endif
                m_EntityComponentStore->AssertEntityHasComponent(entity, m_TypeIndex);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (m_IsZeroSized)
                   throw new System.ArgumentException($"ComponentDataFromEntity<{typeof(T)}> indexer can not get the component because it is zero sized, you can use Exists instead.");
#endif
                
                T data;
                void* ptr = m_EntityComponentStore->GetComponentDataWithTypeRO(entity, m_TypeIndex, ref m_TypeLookupCache);
                UnsafeUtility.CopyPtrToStructure(ptr, out data);

                return data;
            }
			set
			{
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                AtomicSafetyHandle.CheckWriteAndThrow(m_Safety);
#endif
                m_EntityComponentStore->AssertEntityHasComponent(entity, m_TypeIndex);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
			    if (m_IsZeroSized)
			        throw new System.ArgumentException($"ComponentDataFromEntity<{typeof(T)}> indexer can not set the component because it is zero sized, you can use Exists instead.");
#endif

                void* ptr = m_EntityComponentStore->GetComponentDataWithTypeRW(entity, m_TypeIndex, m_GlobalSystemVersion, ref m_TypeLookupCache);
                UnsafeUtility.CopyStructureToPtr(ref value, ptr);
			}
		}
	}
}
