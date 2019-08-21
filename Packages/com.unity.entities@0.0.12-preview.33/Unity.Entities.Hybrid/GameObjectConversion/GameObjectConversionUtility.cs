using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

#pragma warning disable 162

namespace Unity.Entities
{
    [DisableAutoCreation]
    [WorldSystemFilter(WorldSystemFilterFlags.GameObjectConversion)]
    public class GameObjectConversionDeclarePrefabsGroup : ComponentSystemGroup
    {

    }

    [DisableAutoCreation]
    [WorldSystemFilter(WorldSystemFilterFlags.GameObjectConversion)]
    public class GameObjectBeforeConversionGroup : ComponentSystemGroup
    {

    }

    [DisableAutoCreation]
    [WorldSystemFilter(WorldSystemFilterFlags.GameObjectConversion)]
    public class GameObjectConversionGroup : ComponentSystemGroup
    {

    }

    [DisableAutoCreation]
    [WorldSystemFilter(WorldSystemFilterFlags.GameObjectConversion)]
    public class GameObjectAfterConversionGroup : ComponentSystemGroup
    {

    }

    public static class GameObjectConversionUtility
    {
        static ProfilerMarker m_ConvertScene = new ProfilerMarker("GameObjectConversionUtility.ConvertScene");
        static ProfilerMarker m_CreateConversionWorld = new ProfilerMarker("Create World & Systems");
        static ProfilerMarker m_DestroyConversionWorld = new ProfilerMarker("DestroyWorld");
        static ProfilerMarker m_CreateEntitiesForGameObjects = new ProfilerMarker("CreateEntitiesForGameObjects");
        static ProfilerMarker m_UpdateSystems = new ProfilerMarker("UpdateConversionSystems");
        static ProfilerMarker m_AddPrefabComponentDataTag = new ProfilerMarker("AddPrefabComponentDataTag");

        [Flags]
        public enum ConversionFlags : uint
        {
            None = 0,
            AddEntityGUID = 1 << 0,
            ForceStaticOptimization = 1 << 1,
            AssignName = 1 << 2,
        }

        unsafe public static EntityGuid GetEntityGuid(GameObject gameObject, int index)
        {
            return GameObjectConversionMappingSystem.GetEntityGuid(gameObject, index);
        }

        internal  static World CreateConversionWorld(World dstEntityWorld, Hash128 sceneGUID, ConversionFlags conversionFlags)
        {
            m_CreateConversionWorld.Begin();

            var gameObjectWorld = new World("GameObject World");
            gameObjectWorld.CreateSystem<GameObjectConversionMappingSystem>(dstEntityWorld, sceneGUID, conversionFlags);

            AddConversionSystems(gameObjectWorld);

            m_CreateConversionWorld.End();

            return gameObjectWorld;
        }

        struct DeclaredReferencePrefabsTag : IComponentData { }

        static void DeclareReferencesPrefabs(World gameObjectWorld, GameObjectConversionMappingSystem mappingSystem)
        {
            var newEntitiesQuery = mappingSystem.Entities
                .WithNone<DeclaredReferencePrefabsTag>()
                .WithAll<Transform>()
                .ToEntityQuery();

            var declares = new List<IDeclareReferencedPrefabs>();
            var prefabs = new List<GameObject>();

            // we loop until there's nothing more to do (i.e. no new entities created during prefab declaration system updates)
            while (!newEntitiesQuery.IsEmptyIgnoreFilter)
            {
                using (var newEntities = newEntitiesQuery.ToEntityArray(Allocator.TempJob))
                {
                    // fetch components that know how to declare ref'd prefabs
                    foreach (var newEntity in newEntities)
                    {
                        gameObjectWorld.EntityManager.GetComponentObject<Transform>(newEntity).GetComponents(declares);

                        // discover and declare by component
                        foreach (var declare in declares)
                            declare.DeclareReferencedPrefabs(prefabs);
                        
                        declares.Clear();
                    }
                }

                // mark as seen for next loop
                gameObjectWorld.EntityManager.AddComponent(newEntitiesQuery, typeof(DeclaredReferencePrefabsTag));

                foreach (var prefab in prefabs)
                    mappingSystem.DeclareReferencedPrefab(prefab);
                prefabs.Clear();

                // discover and declare by system

                gameObjectWorld.GetExistingSystem<GameObjectConversionDeclarePrefabsGroup>().Update();
            }

            // clean up the markers
            gameObjectWorld.EntityManager.RemoveComponent<DeclaredReferencePrefabsTag>(gameObjectWorld.EntityManager.UniversalQuery);
        }


        
        internal static void Convert(World gameObjectWorld, World dstEntityWorld)
        {
            var mappingSystem = gameObjectWorld.GetExistingSystem<GameObjectConversionMappingSystem>();

            using (m_UpdateSystems.Auto())
            {

                DeclareReferencesPrefabs(gameObjectWorld, mappingSystem);

                // Convert all the data into dstEntityWorld
                mappingSystem.CreatePrimaryEntities();

                gameObjectWorld.GetExistingSystem<GameObjectBeforeConversionGroup>().Update();
                gameObjectWorld.GetExistingSystem<GameObjectConversionGroup>().Update();
                gameObjectWorld.GetExistingSystem<GameObjectAfterConversionGroup>().Update();
            }

            using (m_AddPrefabComponentDataTag.Auto())
            {
                mappingSystem.AddPrefabComponentDataTag();
            }
        }

        internal static Entity GameObjectToConvertedEntity(World gameObjectWorld, GameObject gameObject)
        {
            var mappingSystem = gameObjectWorld.GetExistingSystem<GameObjectConversionMappingSystem>();
            return mappingSystem.GetPrimaryEntity(gameObject);
        }


        public static Entity ConvertGameObjectHierarchy(GameObject root, World dstEntityWorld)
        {
            m_ConvertScene.Begin();

            Entity convertedEntity;
            using (var gameObjectWorld = CreateConversionWorld(dstEntityWorld, default(Hash128), 0))
            {
                var mappingSystem = gameObjectWorld.GetExistingSystem<GameObjectConversionMappingSystem>();

                using (m_CreateEntitiesForGameObjects.Auto())
                {
                    mappingSystem.AddGameObjectOrPrefab(root);
                }

                Convert(gameObjectWorld, dstEntityWorld);

                convertedEntity = mappingSystem.GetPrimaryEntity(root);
                m_DestroyConversionWorld.Begin();
            }
            m_DestroyConversionWorld.End();

            m_ConvertScene.End();

            return convertedEntity;
        }

        public static void ConvertScene(Scene scene, Hash128 sceneHash, World dstEntityWorld, ConversionFlags conversionFlags = 0)
        {
            m_ConvertScene.Begin();

            using (var gameObjectWorld = CreateConversionWorld(dstEntityWorld, sceneHash, conversionFlags))
            {
                using (m_CreateEntitiesForGameObjects.Auto())
                {
                    gameObjectWorld.GetExistingSystem<GameObjectConversionMappingSystem>().CreateEntitiesForGameObjects(scene, gameObjectWorld);
                }

                Convert(gameObjectWorld, dstEntityWorld);

                m_DestroyConversionWorld.Begin();
            }
            m_DestroyConversionWorld.End();

            m_ConvertScene.End();
        }

        static void AddConversionSystems(World gameObjectWorld)
        {
            var declareConvert = gameObjectWorld.GetOrCreateSystem<GameObjectConversionDeclarePrefabsGroup>();
            var earlyConvert = gameObjectWorld.GetOrCreateSystem<GameObjectBeforeConversionGroup>();
            var convert = gameObjectWorld.GetOrCreateSystem<GameObjectConversionGroup>();
            var lateConvert = gameObjectWorld.GetOrCreateSystem<GameObjectAfterConversionGroup>();

            var systems = DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.GameObjectConversion);

            foreach (var system in systems)
            {
                var attributes = system.GetCustomAttributes(typeof(UpdateInGroupAttribute), true);
                if (attributes.Length == 0)
                {
                    AddSystemAndLogException(gameObjectWorld, convert, system);
                }
                else
                {
                    foreach (var attribute in attributes)
                    {
                        var groupType = (attribute as UpdateInGroupAttribute)?.GroupType;

                        if (groupType == declareConvert.GetType())
                        {
                            AddSystemAndLogException(gameObjectWorld, declareConvert, system);
                        }
                        else if (groupType == earlyConvert.GetType())
                        {
                            AddSystemAndLogException(gameObjectWorld, earlyConvert, system);
                        }
                        else if (groupType == convert.GetType())
                        {
                            AddSystemAndLogException(gameObjectWorld, convert, system);
                        }
                        else if (groupType == lateConvert.GetType())
                        {
                            AddSystemAndLogException(gameObjectWorld, lateConvert, system);
                        }
                        else
                        {
                            Debug.LogWarning($"{system} has invalid UpdateInGroup[typeof({groupType}]");
                        }
                    }
                }
            }

            declareConvert.SortSystemUpdateList();
            earlyConvert.SortSystemUpdateList();
            convert.SortSystemUpdateList();
            lateConvert.SortSystemUpdateList();
        }

        static void AddSystemAndLogException(World world, ComponentSystemGroup group, Type type)
        {
            try
            {
                group.AddSystemToUpdateList(world.GetOrCreateSystem(type) as ComponentSystemBase);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
