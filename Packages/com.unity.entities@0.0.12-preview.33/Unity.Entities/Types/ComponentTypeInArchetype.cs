namespace Unity.Entities
{
    internal struct ComponentTypeInArchetype
    {
        public readonly int TypeIndex;

        public bool IsBuffer => (TypeIndex & TypeManager.BufferComponentTypeFlag) != 0;
        public bool IsSystemStateComponent => (TypeIndex & TypeManager.SystemStateTypeFlag) != 0;
        public bool IsSystemStateSharedComponent => (TypeIndex & TypeManager.SystemStateSharedComponentTypeFlag) == TypeManager.SystemStateSharedComponentTypeFlag;
        public bool IsSharedComponent => (TypeIndex & TypeManager.SharedComponentTypeFlag) != 0;
        public bool IsZeroSized => (TypeIndex & TypeManager.ZeroSizeInChunkTypeFlag) != 0;
        public bool IsChunkComponent => (TypeIndex & TypeManager.ChunkComponentTypeFlag) != 0;
        public bool HasEntityReferences => (TypeIndex & TypeManager.HasNoEntityReferencesFlag) == 0;

        public ComponentTypeInArchetype(ComponentType type)
        {
            TypeIndex = type.TypeIndex;
        }

        public static bool operator == (ComponentTypeInArchetype lhs, ComponentTypeInArchetype rhs)
        {
            return lhs.TypeIndex == rhs.TypeIndex;
        }

        public static bool operator != (ComponentTypeInArchetype lhs, ComponentTypeInArchetype rhs)
        {
            return lhs.TypeIndex != rhs.TypeIndex;
        }

        // The comparison of ComponentTypeInArchetype is used to sort the type arrays in Archetypes
        // The type flags in the upper bits of the type index force the component types into the following order:
        // 1. Entity (Always has type index = 1)
        // 2. Non zero sized IComponentData
        // 3. Non zero sized ISystemStateComponentData
        // 4. Dynamic buffer components (IBufferElementData)
        // 5. System state dynamic buffer components (ISystemStateBufferElementData)
        // 6. Zero sized IComponentData
        // 7. Zero sized ISystemStateComponentData
        // 8. Shared components (ISharedComponentData)
        // 9. Shared system state components (ISystemStateSharedComponentData)
        //10. Chunk IComponentData
        //11. Chunk ISystemStateComponentData
        //12. Chunk Dynamic buffer components (IBufferElementData)
        //13. Chunk System state dynamic buffer components (ISystemStateBufferElementData)

        public static bool operator < (ComponentTypeInArchetype lhs, ComponentTypeInArchetype rhs)
        {
            return lhs.TypeIndex < rhs.TypeIndex;
        }

        public static bool operator > (ComponentTypeInArchetype lhs, ComponentTypeInArchetype rhs)
        {
            return lhs.TypeIndex > rhs.TypeIndex;
        }

        public static bool operator <= (ComponentTypeInArchetype lhs, ComponentTypeInArchetype rhs)
        {
            return !(lhs > rhs);
        }

        public static bool operator >= (ComponentTypeInArchetype lhs, ComponentTypeInArchetype rhs)
        {
            return !(lhs < rhs);
        }

        public static unsafe bool CompareArray(ComponentTypeInArchetype* type1, int typeCount1,
            ComponentTypeInArchetype* type2, int typeCount2)
        {
            if (typeCount1 != typeCount2)
                return false;
            for (var i = 0; i < typeCount1; ++i)
                if (type1[i] != type2[i])
                    return false;
            return true;
        }

        public ComponentType ToComponentType()
        {
            ComponentType type;
            type.TypeIndex = TypeIndex;
            type.AccessModeType = ComponentType.AccessMode.ReadWrite;
            return type;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        public override string ToString()
        {
            return ToComponentType().ToString();
        }
#endif
        public override bool Equals(object obj)
        {
            if (obj is ComponentTypeInArchetype) return (ComponentTypeInArchetype) obj == this;

            return false;
        }

        public override int GetHashCode()
        {
            return (TypeIndex * 5819);
        }
    }
}
