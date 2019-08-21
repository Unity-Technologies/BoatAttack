using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities
{
    public class ConvertToEntity : MonoBehaviour
    {
        public enum Mode
        {
            ConvertAndDestroy,
            ConvertAndInjectGameObject
        }

        public Mode ConversionMode;
        
        void Awake()
        {
            if (World.Active != null)
            {
                // Root ConvertToEntity is responsible for converting the whole hierarchy
                if (transform.parent != null && transform.parent.GetComponentInParent<ConvertToEntity>() != null)
                    return;
                
                if (ConversionMode == Mode.ConvertAndDestroy)
                    ConvertHierarchy(gameObject);
                else
                    ConvertAndInjectOriginal(gameObject);
            }
            else
            {
                UnityEngine.Debug.LogWarning("ConvertEntity failed because there was no Active World", this);
            }
        }
        
        static void InjectOriginalComponents(EntityManager entityManager, Entity entity, Transform transform)
        {
            foreach (var com in transform.GetComponents<Component>())
            {
                if (com is GameObjectEntity || com is ConvertToEntity || com is ComponentDataProxyBase)
                    continue;
                
                entityManager.AddComponentObject(entity, com);
            }
        }

        public static void AddRecurse(EntityManager manager, Transform transform)
        {
            GameObjectEntity.AddToEntityManager(manager, transform.gameObject);
            
            var convert = transform.GetComponent<ConvertToEntity>();
            if (convert != null && convert.ConversionMode == Mode.ConvertAndInjectGameObject)
                return;
                
            foreach (Transform child in transform)
                AddRecurse(manager, child);
        }

        public static bool InjectOriginalComponents(World srcGameObjectWorld, EntityManager simulationWorld, Transform transform)
        {
            var convert = transform.GetComponent<ConvertToEntity>();

            if (convert != null && convert.ConversionMode == Mode.ConvertAndInjectGameObject)
            {
                var entity = GameObjectConversionUtility.GameObjectToConvertedEntity(srcGameObjectWorld, transform.gameObject);
                InjectOriginalComponents(simulationWorld, entity, transform);
                transform.parent = null;
                return true;
            }
            
            for (int i = 0; i < transform.childCount;)
            {
                if (!InjectOriginalComponents(srcGameObjectWorld, simulationWorld, transform.GetChild(i)))
                    i++;
            }

            return false;
        }

        public static void ConvertHierarchy(GameObject root)
        {
            var gameObjectWorld = GameObjectConversionUtility.CreateConversionWorld(World.Active, default(Hash128), GameObjectConversionUtility.ConversionFlags.AssignName);

            AddRecurse(gameObjectWorld.EntityManager, root.transform);

            GameObjectConversionUtility.Convert(gameObjectWorld, World.Active);

            InjectOriginalComponents(gameObjectWorld, World.Active.EntityManager, root.transform);

            GameObject.Destroy(root);

            gameObjectWorld.Dispose();
        }


        public static void ConvertAndInjectOriginal(GameObject root)
        {
            var gameObjectWorld = GameObjectConversionUtility.CreateConversionWorld(World.Active, default(Hash128), GameObjectConversionUtility.ConversionFlags.AssignName);

            GameObjectEntity.AddToEntityManager(gameObjectWorld.EntityManager, root);

            GameObjectConversionUtility.Convert(gameObjectWorld, World.Active);

            var entity =GameObjectConversionUtility.GameObjectToConvertedEntity(gameObjectWorld, root);
            InjectOriginalComponents(World.Active.EntityManager, entity, root.transform);

            gameObjectWorld.Dispose();
        }
    }
}
