using System;

namespace Unity.Entities
{
    public interface IComponentData
    {
    }

    public interface IBufferElementData
    {
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class InternalBufferCapacityAttribute : Attribute
    {
        public readonly int Capacity;

        public InternalBufferCapacityAttribute(int capacity)
        {
            Capacity = capacity;
        }
    }
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class MaximumChunkCapacityAttribute : Attribute
    {
        public readonly int Capacity;

        public MaximumChunkCapacityAttribute(int capacity)
        {
            Capacity = capacity;
        }
        
    }

    /// <summary>
    /// Attribute signifying the given type is acceptable for serializing into Chunk storage. 
    /// Data in Chunk storage is treated as blittable with no special pre or post processing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ChunkSerializableAttribute : Attribute
    {
    }

    public interface ISharedComponentData
    {
    }

    public interface ISystemStateComponentData : IComponentData
    {
    }

    public interface ISystemStateBufferElementData : IBufferElementData
    {
    }

    public interface ISystemStateSharedComponentData : ISharedComponentData
    {
    }

    /// <summary>
    /// Disables the entity. By default EntityQuery does not include entities containing the Disabled component.
    /// </summary>
    public struct Disabled : IComponentData
    {
    }
    
    /// <summary>
    /// Marks the entity as a prefab, which implicitly disables the entity. By default EntityQuery does not include entities containing the Prefab component.
    /// </summary>
    public struct Prefab : IComponentData
    {
    }
    
    /// <summary>
    /// The LinkedEntityGroup buffer makes the entity be the root of a set of connected entities.
    /// Referenced Prefabs automatically add a LinkedEntityGroup with the complete child hierarchy. 
    /// EntityManager.Instantiate uses LinkedEntityGroup to instantiate the whole set of entities automatically.
    /// EntityManager.SetEnabled uses LinkedEntityGroup to enable the whole set of entities. 
    /// </summary>
    public struct LinkedEntityGroup : IBufferElementData
    {
        public Entity Value;
        
        public static implicit operator LinkedEntityGroup(Entity e)
        {
            return new LinkedEntityGroup {Value = e};
        }
    }
    
    [Serializable]
    public struct SceneTag : ISharedComponentData, IEquatable<SceneTag>
    {
        public Entity  SceneEntity;

        public override int GetHashCode()
        {
            return SceneEntity.GetHashCode();
        }

        public bool Equals(SceneTag other)
        {
            return SceneEntity == other.SceneEntity;
        }

        public override string ToString()
        {
            return $"SubSceneTag: {SceneEntity}";
        }
    }
}

