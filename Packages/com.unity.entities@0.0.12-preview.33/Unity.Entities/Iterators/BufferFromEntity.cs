using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    [NativeContainer]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BufferFromEntity<T> where T : struct, IBufferElementData
    {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        private readonly AtomicSafetyHandle m_Safety0;
        private readonly AtomicSafetyHandle m_ArrayInvalidationSafety;
        private int m_SafetyReadOnlyCount;
        private int m_SafetyReadWriteCount;
#endif
        [NativeDisableUnsafePtrRestriction] private readonly EntityComponentStore* m_EntityComponentStore;
        private readonly int m_TypeIndex;
        private readonly bool m_IsReadOnly;
        readonly uint                    m_GlobalSystemVersion;
        int                              m_TypeLookupCache;
        int                              m_InternalCapacity;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        internal BufferFromEntity(int typeIndex, EntityComponentStore* entityComponentStoreComponentStore, bool isReadOnly,
            AtomicSafetyHandle safety, AtomicSafetyHandle arrayInvalidationSafety)
        {
            m_Safety0 = safety;
            m_ArrayInvalidationSafety = arrayInvalidationSafety;
            m_SafetyReadOnlyCount = isReadOnly ? 2 : 0;
            m_SafetyReadWriteCount = isReadOnly ? 0 : 2;
            m_TypeIndex = typeIndex;
            m_EntityComponentStore = entityComponentStoreComponentStore;
            m_IsReadOnly = isReadOnly;
            m_TypeLookupCache = 0;
            m_GlobalSystemVersion = entityComponentStoreComponentStore->GlobalSystemVersion;

            if (!TypeManager.IsBuffer(m_TypeIndex))
                throw new ArgumentException(
                    $"GetComponentBufferArray<{typeof(T)}> must be IBufferElementData");

            m_InternalCapacity = TypeManager.GetTypeInfo<T>().BufferCapacity;
        }
#else
        internal BufferFromEntity(int typeIndex, EntityComponentStore* entityComponentStoreComponentStore, bool isReadOnly)
        {
            m_TypeIndex = typeIndex;
            m_EntityComponentStore = entityComponentStoreComponentStore;
            m_IsReadOnly = isReadOnly;
            m_TypeLookupCache = 0;
            m_GlobalSystemVersion = entityComponentStoreComponentStore->GlobalSystemVersion;
            m_InternalCapacity = TypeManager.GetTypeInfo<T>().BufferCapacity;
        }
#endif

        public bool Exists(Entity entity)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.CheckReadAndThrow(m_Safety0);
#endif
            //@TODO: out of bounds index checks...

            return m_EntityComponentStore->HasComponent(entity, m_TypeIndex);
        }

        public DynamicBuffer<T> this[Entity entity]
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                // Note that this check is only for the lookup table into the entity manager
                // The native array performs the actual read only / write only checks
                AtomicSafetyHandle.CheckReadAndThrow(m_Safety0);

                m_EntityComponentStore->AssertEntityHasComponent(entity, m_TypeIndex);
#endif

                // TODO(dep): We don't really have a way to mark the native array as read only.
                BufferHeader* header = (BufferHeader*) m_EntityComponentStore->GetComponentDataWithTypeRW(entity, m_TypeIndex, m_GlobalSystemVersion, ref m_TypeLookupCache);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
                return new DynamicBuffer<T>(header, m_Safety0, m_ArrayInvalidationSafety, m_IsReadOnly, m_InternalCapacity);
#else
                return new DynamicBuffer<T>(header, m_InternalCapacity);
#endif
            }
        }
    }
}
