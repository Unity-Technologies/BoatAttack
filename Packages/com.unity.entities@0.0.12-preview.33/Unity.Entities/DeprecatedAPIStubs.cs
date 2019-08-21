using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Unity.Entities
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("ComponentDataArray is deprecated. Use IJobForEach or EntityQuery ToComponentDataArray/CopyFromComponentDataArray APIs instead. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public unsafe struct ComponentDataArray<T> where T : struct, IComponentData { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("SharedComponentDataArray is deprecated. Use ArchetypeChunk.GetSharedComponentData. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public struct SharedComponentDataArray<T> where T : struct, ISharedComponentData { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("BufferArray is deprecated. Use ArchetypeChunk.GetBufferAccessor() instead. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public unsafe struct BufferArray<T> where T : struct, IBufferElementData { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("EntityArray is deprecated. Use IJobForEachWithEntity or EntityQuery.ToEntityArray(...) instead. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public unsafe struct EntityArray { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("ComponentGroupArray has been deprecated. Use Entities.ForEach instead to access managed components. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public struct ComponentGroupArray<T> where T : struct { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [AttributeUsage(AttributeTargets.Field)]
    [Obsolete("Injection API is deprecated. For struct injection, use the EntityQuery API instead. For ComponentDataFromEntity injection use (Job)ComponentSystem.GetComponentDataFromEntity. For system injection, use World.GetOrCreateManager(). More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public class InjectAttribute : Attribute { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CopyComponentData is deprecated. Use EntityQuery.ToComponentDataArray instead. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public struct CopyComponentData<T>
        where T : struct, IComponentData { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CopyEntities is deprecated. Use EntityQuery.ToEntityArray instead. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public struct CopyEntities { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("GameObjectArray has been deprecated. Use ComponentSystem.ForEach or ToTransformArray()[index].gameObject to access entity GameObjects. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public struct GameObjectArray { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("ComponentArray has been deprecated. Use ComponentSystem.ForEach to access managed components. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
    public struct ComponentArray<T> where T: UnityEngine.Component { }

    public static class ComponentGroupExtensionsForGameObjectArray
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetGameObjectArray has been deprecated. Use ComponentSystem.ForEach or ToTransformArray()[index].gameObject to access entity GameObjects. More information: https://forum.unity.com/threads/api-deprecation-faq-0-0-23.636994/", true)]
        public static void GetGameObjectArray(this ComponentGroup group) { }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface EntityManagerBaseInterfaceForObsolete
    {
    }

    public partial class World
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("BehaviourManagers have been renamed to Systems. (UnityUpgradable) -> Systems", true)]
        public IEnumerable<ComponentSystemBase> BehaviourManagers => null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("CreateManager has been renamed to CreateSystem. (UnityUpgradable) -> CreateSystem(*)", true)]
        public ComponentSystemBase CreateManager(Type type, params object[] constructorArgumnents)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetOrCreateManager has been renamed to GetOrCreateSystem. (UnityUpgradable) -> GetOrCreateSystem(*)", true)]
        public ComponentSystemBase GetOrCreateManager(Type type)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("AddManager has been renamed to AddSystem. (UnityUpgradable) -> AddSystem(*)", true)]
        public T AddManager<T>(T manager) where T : ComponentSystemBase
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetExistingManager has been renamed to GetExistingSystem. (UnityUpgradable) -> GetExistingSystem(*)", true)]
        public ComponentSystemBase GetExistingManager(Type type)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("DestroyManager has been renamed to DestroySystem. (UnityUpgradable) -> DestroySystem(*)", true)]
        public void DestroyManager(ComponentSystemBase manager)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("CreateManager has been renamed to CreateSystem. (UnityUpgradable) -> CreateSystem<T>(*)", true)]
        public T CreateManager<T>(params object[] constructorArgumnents) where T : ComponentSystemBase
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetOrCreateManager has been renamed to GetOrCreateSystem. (UnityUpgradable) -> GetOrCreateSystem<T>()", true)]
        public T GetOrCreateManager<T>() where T : ComponentSystemBase
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetExistingManager has been renamed to GetExistingSystem. (UnityUpgradable) -> GetExistingSystem<T>()", true)]
        public T GetExistingManager<T>() where T : ComponentSystemBase
        {
            throw new NotImplementedException();
        }
    }

    public static class WorldObsoleteExtensions {
        // special handling to handle EntityManager rename.  I can't get the script updater to rewrite this automatically via
        // (UnityUpgradable) -> EntityManager
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetExistingManager<EntityManager>() has been renamed to an EntityManager property.")]
        public static EntityManager GetExistingManager<T>(this World world) where T : EntityManagerBaseInterfaceForObsolete
        {
            return world.EntityManager;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetOrCreateManager<EntityManager>() has been renamed to an EntityManager property.")]
        public static EntityManager GetOrCreateManager<T>(this World world) where T : EntityManagerBaseInterfaceForObsolete
        {
            return world.EntityManager;
        }

        // Include System API name variants, even though we never had this API -- the script updater will likely
        // aggressively update *Manager to *System
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetExistingSystem<EntityManager>() has been renamed to an EntityManager property.")]
        public static EntityManager GetExistingSystem<T>(this World world) where T : EntityManagerBaseInterfaceForObsolete
        {
            return world.EntityManager;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetOrCreateSystem<EntityManager>() has been renamed to an EntityManager property.")]
        public static EntityManager GetOrCreateSystem<T>(this World world) where T : EntityManagerBaseInterfaceForObsolete
        {
            return world.EntityManager;
        }
    }

}
