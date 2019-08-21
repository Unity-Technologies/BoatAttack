#define DETAIL_MARKERS
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using Hash128 = Unity.Entities.Hash128;
using ConversionFlags = Unity.Entities.GameObjectConversionUtility.ConversionFlags;


public struct EntitiesEnumerator : IEnumerable<Entity>, IEnumerator<Entity>
{
    Entity[]                         m_Entities;
    int[]                            m_Next;
    int m_FirstIndex;
    int m_CurIndex;


    internal EntitiesEnumerator(Entity[] entities, int[] next, int index)
    {
        m_Entities = entities;
        m_Next = next;
        m_FirstIndex = index;
        m_CurIndex = -1;
    }

    public EntitiesEnumerator GetEnumerator()
    {
        return this;
    }

    IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
    {
        return this;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this;
    }


    public bool MoveNext()
    {
        if (m_CurIndex == -1)
            m_CurIndex = m_FirstIndex;
        else
            m_CurIndex = m_Next[m_CurIndex];

        return m_CurIndex != -1;
    }

    public void Reset()
    {
        m_CurIndex = -1;
    }

    public Entity Current
    {
        get
        {
            return m_Entities[m_CurIndex];
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
}

[DisableAutoCreation]
class GameObjectConversionMappingSystem : ComponentSystem
{
    NativeHashMap<int, int>       m_GameObjectToEntity = new NativeHashMap<int, int>(100 * 1000, Allocator.Persistent);

    int                              m_EntitiesCount;
    Entity[]                         m_Entities;
    int[]                            m_Next;

    const int StaticMask = 1;
    const int EntityGUIDMask = 2;
    const int DisabledMask = 4;
    const int AllMask = 7;
    EntityArchetype[]                     m_Archetypes;

    HashSet<GameObject>                   m_ReferencedPrefabs = new HashSet<GameObject>();
    HashSet<GameObject>                   m_LinkedEntityGroup = new HashSet<GameObject>();

    World                                 m_DstWorld;
    EntityManager                         m_DstManager;
    ConversionFlags                       m_ConversionFlags;
    Hash128                               m_SceneGUID;
    internal bool                         AllowAddingMoreConversionObjects = true;


    public World DstWorld { get { return m_DstWorld; } }
    public bool AddEntityGUID { get { return (m_ConversionFlags & ConversionFlags.AddEntityGUID) != 0; } }
    public bool ForceStaticOptimization { get { return (m_ConversionFlags & ConversionFlags.ForceStaticOptimization) != 0; } }
    public bool AssignName { get { return (m_ConversionFlags & ConversionFlags.AssignName) != 0; } }

    public GameObjectConversionMappingSystem(World DstWorld, Hash128 sceneGUID, ConversionFlags conversionFlags)
    {
        m_DstWorld = DstWorld;
        m_SceneGUID = sceneGUID;
        m_ConversionFlags = conversionFlags;
        m_DstManager = DstWorld.EntityManager;

        m_Entities = new Entity[128];
        m_Next = new int[128];
        m_EntitiesCount = 0;

        InitArchetypes();
    }

    protected override void OnDestroy()
    {
        m_GameObjectToEntity.Dispose();
    }


    void InitArchetypes()
    {
        m_Archetypes = new EntityArchetype[AllMask + 1];
        var types = new List<ComponentType>();
        for (int i = 0; i <= AllMask; i++)
        {
            types.Clear();
            if ((i & StaticMask) != 0)
                types.Add(typeof(Static));
            if ((i & EntityGUIDMask) != 0)
                types.Add(typeof(EntityGuid));
            if ((i & DisabledMask) != 0)
                types.Add(typeof(Disabled));

            m_Archetypes[i] = m_DstManager.CreateArchetype(types.ToArray());
        }
    }

    static bool IsActive(GameObject go)
    {
        if (!IsPrefab(go))
        {
            return go.activeInHierarchy;
        }
        else
        {
            Transform parent = go.transform;
            while (parent != null)
            {
                if (!parent.gameObject.activeSelf)
                    return false;

                parent = parent.parent;
            }

            return true;
        }
    }

    unsafe public static EntityGuid GetEntityGuid(GameObject go, int index)
    {
#if false
        var id = GlobalObjectId.GetGlobalObjectId(go);
        // For the time being use InstanceID until we support GlobalObjectID API
        //Debug.Log(id);
        var hash = Hash128.Compute($"{id}:{index}");

        EntityGuid entityGuid;
        Assert.AreEqual(sizeof(EntityGuid), sizeof(Hash128));
        UnsafeUtility.MemCpy(&entityGuid, &hash, sizeof(Hash128));
        return entityGuid;
#else
        EntityGuid entityGuid;
        entityGuid.a = (ulong)go.GetInstanceID();
        entityGuid.b = (ulong)index;

        return entityGuid;
#endif
    }

    #if DETAIL_MARKERS
    ProfilerMarker m_CreateEntity = new ProfilerMarker("GameObjectConversion.CreateEntity");
    ProfilerMarker m_CreatePrimaryEntity = new ProfilerMarker("GameObjectConversion.CreatePrimaryEntities");
    ProfilerMarker m_CreateAdditional = new ProfilerMarker("GameObjectConversionCreateAdditionalEntity");
    #endif

    Entity CreateEntity(GameObject go, int index)
    {
#if DETAIL_MARKERS
        using (m_CreateEntity.Auto())
#endif
        {
            int flags = 0;
            if (AddEntityGUID)
                flags |= EntityGUIDMask;
            if (ForceStaticOptimization || go.GetComponentInParent<StaticOptimizeEntity>() != null)
                flags |= StaticMask;
            if (!IsActive(go))
                flags |= DisabledMask;
            
            var entity = m_DstManager.CreateEntity(m_Archetypes[flags]);

            if ((flags & EntityGUIDMask) != 0)
                m_DstManager.SetComponentData(entity, GetEntityGuid(go, index));
            
            var section = go.GetComponentInParent<SceneSectionComponent>();
            if (m_SceneGUID != default(Hash128))
                m_DstManager.AddSharedComponentData(entity, new SceneSection { SceneGUID = m_SceneGUID, Section = section != null ? section.SectionIndex : 0});

#if UNITY_EDITOR
            if (AssignName)
                m_DstManager.SetName(entity, go.name);
#endif

            return entity;
        }
    }

    internal void CreatePrimaryEntity(GameObject gameObject)
    {
        var entity = CreateEntity(gameObject, 0);

        if (!m_GameObjectToEntity.TryAdd(gameObject.GetInstanceID(), m_EntitiesCount))
            throw new InvalidOperationException();
        AddFirst(entity);
    }

    internal void CreatePrimaryEntities()
    {
        AllowAddingMoreConversionObjects = false;

        using (m_CreatePrimaryEntity.Auto())
        {
            Entities.With(EntityManager.UniversalQuery).ForEach((Transform transform) =>
            {
                CreatePrimaryEntity(transform.gameObject);
            });
        }
    }

    public void LogWarning(string warning, UnityEngine.Object context)
    {
        Debug.LogWarning(warning, context);
    }

    static bool IsPrefab(GameObject go)
    {
        return !go.scene.IsValid();
    }

    public Entity GetPrimaryEntity(GameObject go)
    {
        if (go == null)
            return new Entity();

        var instanceID = go.GetInstanceID();
        int index;
        if (m_GameObjectToEntity.TryGetValue(instanceID, out index))
        {
            return m_Entities[index];
        }
        else
        {
            if (IsPrefab(go))
                LogWarning("GetPrimaryEntity(GameObject go) is a prefab that was not declared for conversion. Did you forget to declare it using IDeclarePrefabReferences or a [UpdateInGroup(typeof(GameObjectConversionDeclarePrefabsGroup))] system. It will be ignored.", go);
            else
                LogWarning("GetPrimaryEntity(GameObject go) is a game object that was not included in the conversion. It will be ignored.", go);

            return Entity.Null;
        }
    }
    int Count(int index)
    {
        int count = 1;
        while ((index = m_Next[index]) != -1)
            count++;

        return count;
    }

    void AddFirst(Entity entity)
    {
        if (m_EntitiesCount == m_Entities.Length)
        {
            Array.Resize(ref m_Entities, m_EntitiesCount * 2);
            Array.Resize(ref m_Next, m_EntitiesCount * 2);
        }

        m_Entities[m_EntitiesCount] = entity;
        m_Next[m_EntitiesCount] = -1;
        m_EntitiesCount++;
    }

    void AddAdditional(int index, Entity entity)
    {
        if (m_EntitiesCount == m_Entities.Length)
        {
            Array.Resize(ref m_Entities, m_EntitiesCount * 2);
            Array.Resize(ref m_Next, m_EntitiesCount * 2);
        }

        int lastIndex = index;
        while ((index = m_Next[index]) != -1)
            lastIndex = index;

        m_Entities[m_EntitiesCount] = entity;
        m_Next[m_EntitiesCount] = -1;
        m_Next[lastIndex] = m_EntitiesCount;
        m_EntitiesCount++;
    }

    public Entity CreateAdditionalEntity(GameObject go)
    {
        #if DETAIL_MARKERS
        using (m_CreateAdditional.Auto())
        #endif
        {
            if (go == null)
                throw new System.ArgumentException("CreateAdditionalEntity must be called with a valid game object");

            var instanceID = go.GetInstanceID();
            int index;
            if (!m_GameObjectToEntity.TryGetValue(instanceID, out index))
                throw new System.ArgumentException("CreateAdditionalEntity can't be called before GetPrimaryEntity is called for that game object");

            int count = Count(index);
            var entity = CreateEntity(go, count);
            AddAdditional(index, entity);

            return entity;
        }
    }

    /// <summary>
    /// Is the game object included in the set of converted objects.
    /// </summary>
    public bool HasPrimaryEntity(GameObject gameObject)
    {
        if (gameObject == null)
            return false;

        var instanceID = gameObject.GetInstanceID();
        int index;
        return m_GameObjectToEntity.TryGetValue(instanceID, out index);
    }


    public EntitiesEnumerator GetEntities(GameObject go)
    {
        var instanceID = go != null ? go.GetInstanceID() : 0;
        int index;
        if (go != null)
        {
            if (m_GameObjectToEntity.TryGetValue(instanceID, out index))
                return new EntitiesEnumerator(m_Entities, m_Next, index);
        }

        return new EntitiesEnumerator(m_Entities, m_Next, -1);
    }

    internal void AddGameObjectOrPrefab(GameObject prefab)
    {
        if (!AllowAddingMoreConversionObjects)
            throw new ArgumentException("AddGameObjectOrPrefab can only be called from a System using [UpdateInGroup(typeof(GameObjectConversionDeclarePrefabsGroup))].");

        if (prefab == null)
            return;
        if (m_ReferencedPrefabs.Contains(prefab))
            return;

        m_LinkedEntityGroup.Add(prefab);

        var isPrefab = !prefab.scene.IsValid();
        if (isPrefab)
            CreateEntitiesForGameObjectsRecurse(prefab.transform, EntityManager, m_ReferencedPrefabs);
        else
            CreateEntitiesForGameObjectsRecurse(prefab.transform, EntityManager, null);
    }

    /// <summary>
    /// Adds a LinkedEntityGroup to the primary entity of this gam eobject, for all entities that are created from this and all child game object.
    /// As a result EntityManager.Instantiate & EntityManager.SetEnabled will work on those entities as a group.
    /// </summary>
    public void AddLinkedEntityGroup(GameObject gameObject)
    {
        m_LinkedEntityGroup.Add(gameObject);
    }

    /// <summary>
    /// DeclareReferencedPrefab includes the referenced prefab in the conversion process.
    /// Once it has been declared you can use GetPrimaryEntity to find the entity for the game object.
    /// All entities in the Prefab will be made part of the LinkedEntityGroup, thus Instantiate will clone the whole group.
    /// All entities in the prefab will be tagged with the Prefab component thus will not be picked up EntityQuery's by default.
    /// </summary>
    public void DeclareReferencedPrefab(GameObject prefab)
    {
        if (!AllowAddingMoreConversionObjects)
            throw new ArgumentException("DeclareReferencedPrefab can only be called from a System using [UpdateInGroup(typeof(GameObjectConversionDeclarePrefabsGroup))].");

        if (prefab == null)
            return;

        if (m_ReferencedPrefabs.Contains(prefab))
            return;

        if (!IsPrefab(prefab))
            return;

        m_LinkedEntityGroup.Add(prefab);
        CreateEntitiesForGameObjectsRecurse(prefab.transform, EntityManager, m_ReferencedPrefabs);
    }

    internal void AddPrefabComponentDataTag()
    {
        // Add prefab tag to all entities that were converted from a prefab game object source
        foreach (var prefab in m_ReferencedPrefabs)
        {
            foreach(var e in GetEntities(prefab))
                m_DstManager.AddComponentData(e, new Prefab());
        }

        // Create LinkedEntityGroup for each root prefab entity
        // Instantiate & Destroy will destroy the entity as a group.
        foreach (var i in m_LinkedEntityGroup)
        {
            var allChildren = i.GetComponentsInChildren<Transform>(true);

            var linkedRoot = GetPrimaryEntity(i);
            if (m_DstManager.HasComponent<LinkedEntityGroup>(linkedRoot))
                continue;
            
            var buffer = m_DstManager.AddBuffer<LinkedEntityGroup>(linkedRoot);
            foreach (Transform t in allChildren)
            {
                foreach (var e in GetEntities(t.gameObject))
                    buffer.Add(e);
            }
            
            Assert.AreEqual(buffer[0], linkedRoot);
            
            // This optimization caused breakage on terrains.
            // No need for linked root if it ends up being just one entity...
            //if (buffer.Length == 1)
            //    m_DstManager.RemoveComponent<LinkedEntityGroup>(linkedRoot);
        }
    }

    static bool IsComponentDisabled(Component component)
    {
        {
            var r = component as Renderer;
            if (r != null)
                return !r.enabled;
        }

        {
            var c = component as Collider;
            if (c != null)
                return !c.enabled;
        }

        {
            var l = component as LODGroup;
            if (l != null)
                return !l.enabled;
        }
        
        {
            var b = component as Behaviour;
            if (b != null)
                return !b.enabled;
        }

        return false;
    }

    static void GetComponents(GameObject gameObject, out ComponentType[] types, out Component[] components, GameObjectConversionMappingSystem system)
    {
        components = gameObject.GetComponents<Component>();

        var componentCount = 0;
        for (var i = 0; i != components.Length; i++)
        {
            var com = components[i];
            
            if (com == null)
                system.LogWarning($"The referenced script is missing on {gameObject.name}", gameObject);
            else if (IsComponentDisabled(com))
                components[i] = null;
            else if (com is GameObjectEntity)
                components[i] = null;
            else
                componentCount++;
        }

        types = new ComponentType[componentCount];

        var t = 0;
        for (var i = 0; i != components.Length; i++)
        {
            var com = components[i];
            var componentData = com as ComponentDataProxyBase;

            if (componentData != null)
                types[t++] = componentData.GetComponentType();
            else if (com != null)
                types[t++] = com.GetType();
        }
    }

    internal static void CopyComponentDataProxyToEntity(EntityManager entityManager, GameObject gameObject, Entity entity)
    {
        foreach (var proxy in gameObject.GetComponents<ComponentDataProxyBase>())
        {
            Behaviour behaviour = proxy as Behaviour;
            if (behaviour != null && !behaviour.enabled)
                continue;
            
            var type = proxy.GetComponentType();
            entityManager.AddComponent(entity, type);
            proxy.UpdateComponentData(entityManager, entity);
        }
    }


    static void AddToEntityManager(EntityManager entityManager, GameObject gameObject, GameObjectConversionMappingSystem system)
    {
        ComponentType[] types;
        Component[] components;
        GetComponents(gameObject, out types, out components, system);

        EntityArchetype archetype;
        try
        {
            archetype = entityManager.CreateArchetype(types);
        }
        catch (Exception e)
        {
            for (int i = 0; i < types.Length; ++i)
            {
                if (Array.IndexOf(types, types[i]) != i)
                {
                    system.LogWarning($"GameObject '{gameObject}' has multiple {types[i]} components and cannot be converted, skipping.", null);
                    return;
                }
            }

            throw e;
        }

        var entity = entityManager.CreateEntity(archetype);
        var t = 0;
        for (var i = 0; i != components.Length; i++)
        {
            var com = components[i];
            var componentDataProxy = com as ComponentDataProxyBase;

            if (componentDataProxy != null)
            {
                componentDataProxy.UpdateComponentData(entityManager, entity);
                t++;
            }
            else if (com != null)
            {
                entityManager.SetComponentObject(entity, types[t], com);
                t++;
            }
        }
    }

    internal void CreateEntitiesForGameObjectsRecurse(Transform transform, EntityManager gameObjectEntityManager, HashSet<GameObject> gameObjects)
    {
        // If a game object is disabled, we add a linked entity group so that EntityManager.SetEnabled() on the primary entity will result in the whole hierarchy becoming enabled.
        if (!transform.gameObject.activeSelf)
            AddLinkedEntityGroup(transform.gameObject);

        AddToEntityManager(gameObjectEntityManager, transform.gameObject, this);
        if (gameObjects != null)
            gameObjects.Add(transform.gameObject);

        int childCount = transform.childCount;
        for (int i = 0; i != childCount;i++)
            CreateEntitiesForGameObjectsRecurse(transform.GetChild(i), gameObjectEntityManager, gameObjects);
    }

    internal void CreateEntitiesForGameObjects(Scene scene, World gameObjectWorld)
    {
        var gameObjectEntityManager = gameObjectWorld.EntityManager;
        var gameObjects = scene.GetRootGameObjects();

        foreach (var go in gameObjects)
            CreateEntitiesForGameObjectsRecurse(go.transform, gameObjectEntityManager, null);
    }

    protected override void OnUpdate()
    {

    }
}
