using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using MonoBehaviour = UnityEngine.MonoBehaviour;
using GameObject = UnityEngine.GameObject;
using Component = UnityEngine.Component;

namespace Unity.Entities
{
    [DisallowMultipleComponent]
    [ExecuteAlways]
    public class GameObjectEntity : MonoBehaviour
    {
        public EntityManager EntityManager
        {
            get
            {
                if (enabled && gameObject.activeInHierarchy)
                    ReInitializeEntityManagerAndEntityIfNecessary();
                return m_EntityManager;
            }
        }
        EntityManager m_EntityManager;

        public Entity Entity
        {
            get
            {
                if (enabled && gameObject.activeInHierarchy)
                    ReInitializeEntityManagerAndEntityIfNecessary();
                return m_Entity;
            }
        }
        Entity m_Entity;

        void ReInitializeEntityManagerAndEntityIfNecessary()
        {
            // in case e.g., on a prefab that was open for edit when domain was unloaded
            // existing m_EntityManager lost all its data, so simply create a new one
            if (m_EntityManager != null && !m_EntityManager.IsCreated && !m_Entity.Equals(default(Entity)))
                Initialize();
        }

        // TODO: Very wrong error messages when creating entity with empty ComponentType array?
        public static Entity AddToEntityManager(EntityManager entityManager, GameObject gameObject)
        {
            ComponentType[] types;
            Component[] components;
            GetComponents(gameObject, true, out types, out components);

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
                        Debug.LogWarning($"GameObject '{gameObject}' has multiple {types[i]} components and cannot be converted, skipping.");
                        return Entity.Null;
                    }
                }

                throw e;
            }

            var entity = CreateEntity(entityManager, archetype, components, types);

            return entity;
        }
        
        public static void AddToEntity(EntityManager entityManager, GameObject gameObject, Entity entity)
        {
            var components = gameObject.GetComponents<Component>();

            for (var i = 0; i != components.Length; i++)
            {
                var com = components[i];
                var proxy = com as ComponentDataProxyBase;
                var behaviour = com as Behaviour;
                if (behaviour != null && !behaviour.enabled)
                    continue;
                                        
                if (!(com is GameObjectEntity) && com != null && proxy == null)
                {
                    
                    entityManager.AddComponentObject(entity, com);
                }
            }
        }

        static void GetComponents(GameObject gameObject, bool includeGameObjectComponents, out ComponentType[] types, out Component[] components)
        {            
            components = gameObject.GetComponents<Component>();

            var componentCount = 0;
            for (var i = 0; i != components.Length; i++)
            {
                var com = components[i];
                var componentData = com as ComponentDataProxyBase;

                if (com == null)
                    UnityEngine.Debug.LogWarning($"The referenced script is missing on {gameObject.name}", gameObject);
                else if (componentData != null)
                    componentCount++;
                else if (includeGameObjectComponents && !(com is GameObjectEntity))
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
                else if (includeGameObjectComponents && !(com is GameObjectEntity) && com != null)
                    types[t++] = com.GetType();
            }
        }

        static Entity CreateEntity(EntityManager entityManager, EntityArchetype archetype, IReadOnlyList<Component> components, IReadOnlyList<ComponentType> types)
        {
            var entity = entityManager.CreateEntity(archetype);
            var t = 0;
            for (var i = 0; i != components.Count; i++)
            {
                var com = components[i];
                var componentDataProxy = com as ComponentDataProxyBase;

                if (componentDataProxy != null)
                {
                    componentDataProxy.UpdateComponentData(entityManager, entity);
                    t++;
                }
                else if (!(com is GameObjectEntity) && com != null)
                {
                    entityManager.SetComponentObject(entity, types[t], com);
                    t++;
                }
            }
            return entity;
        }

        void Initialize()
        {
            DefaultWorldInitialization.DefaultLazyEditModeInitialize();
            if (World.Active != null)
            {
                m_EntityManager = World.Active.EntityManager;
                m_Entity = AddToEntityManager(m_EntityManager, gameObject);
            }
        }

        protected virtual void OnEnable()
        {
            Initialize();
        }

        protected virtual void OnDisable()
        {
            if (EntityManager != null && EntityManager.IsCreated && EntityManager.Exists(Entity))
                EntityManager.DestroyEntity(Entity);

            m_EntityManager = null;
            m_Entity = Entity.Null;
        }

        public static void CopyAllComponentsToEntity(GameObject gameObject, EntityManager entityManager, Entity entity)
        {
            foreach (var proxy in gameObject.GetComponents<ComponentDataProxyBase>())
            {
                // TODO: handle shared components and tag components
                var type = proxy.GetComponentType();
                entityManager.AddComponent(entity, type);
                proxy.UpdateComponentData(entityManager, entity);
            }
        }
    }
}
