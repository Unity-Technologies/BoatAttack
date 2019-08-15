using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[WorldSystemFilter(WorldSystemFilterFlags.GameObjectConversion)]
public abstract class GameObjectConversionSystem : ComponentSystem
{
    public World DstWorld;
    public EntityManager DstEntityManager;

    GameObjectConversionMappingSystem m_MappingSystem;

    protected override void OnCreate()
    {
        base.OnCreate();

        m_MappingSystem = World.GetOrCreateSystem<GameObjectConversionMappingSystem>();
        DstWorld = m_MappingSystem.DstWorld;
        DstEntityManager = DstWorld.EntityManager;
    }
    
    public Entity GetPrimaryEntity(Component component)
    {
        return m_MappingSystem.GetPrimaryEntity(component != null ? component.gameObject : null);
    }
    
    public Entity CreateAdditionalEntity(Component component)
    {
        return m_MappingSystem.CreateAdditionalEntity(component != null ? component.gameObject : null);
    }
    
    public EntitiesEnumerator GetEntities(Component component)
    {
        return m_MappingSystem.GetEntities(component != null ? component.gameObject : null);
    }
    
    public Entity GetPrimaryEntity(GameObject gameObject)
    {
        return m_MappingSystem.GetPrimaryEntity(gameObject);
    }

    /// <summary>
    /// Is the game object included in the set of converted objects.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool HasPrimaryEntity(GameObject gameObject)
    {
        return m_MappingSystem.HasPrimaryEntity(gameObject);
    }
    /// <summary>
    /// Is the game object included in the set of converted objects.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public bool HasPrimaryEntity(Component component)
    {
        return m_MappingSystem.HasPrimaryEntity(component != null ? component.gameObject : null);
    }
    
    public Entity CreateAdditionalEntity(GameObject gameObject)
    {
        return m_MappingSystem.CreateAdditionalEntity(gameObject);
    }
    
    public EntitiesEnumerator GetEntities(GameObject gameObject)
    {
        return m_MappingSystem.GetEntities(gameObject);
    }
    
    /// <summary>
    /// DeclareReferencedPrefab includes the referenced prefab in the conversion process.
    /// Once it has been declared you can use GetPrimaryEntity to find the entity for the game object.
    /// All entities in the Prefab will be made part of the LinkedEntityGroup, thus Instantiate will clone the whole group.
    /// All entities in the prefab will be tagged with the Prefab component thus will not be picked up EntityQuery's by default.
    /// </summary>
    /// <param name="prefab"></param>
    public void DeclareReferencedPrefab(GameObject gameObject)
    {
        m_MappingSystem.DeclareReferencedPrefab(gameObject);
    }

    /// <summary>
    /// Adds a LinkedEntityGroup to the primary entity of this gam eobject, for all entities that are created from this and all child game object.
    /// As a result EntityManager.Instantiate & EntityManager.SetEnabled will work on those entities as a group.
    /// </summary>
    public void AddLinkedEntityGroup(GameObject gameObject)
    {
        m_MappingSystem.AddLinkedEntityGroup(gameObject);
    }
    
    [Obsolete("AddReferencedPrefab has been renamed. Use DeclareReferencedPrefab instead (UnityUpgradable) -> DeclareReferencedPrefab(*)", true)]
    public void AddReferencedPrefab(GameObject gameObject)
    {
        DeclareReferencedPrefab(gameObject);
    }
}
