using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Entities.Streaming;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEditor.VersionControl;
using static Unity.Entities.GameObjectConversionUtility;
using Hash128 = Unity.Entities.Hash128;
using Object = UnityEngine.Object;

namespace Unity.Scenes.Editor
{
    //@TODO: Public
    public class EditorEntityScenes
    {
        static readonly ProfilerMarker k_ProfileEntitiesSceneSave = new ProfilerMarker("EntitiesScene.Save");
        static readonly ProfilerMarker k_ProfileEntitiesSceneCreatePrefab = new ProfilerMarker("EntitiesScene.CreatePrefab");
        static readonly ProfilerMarker k_ProfileEntitiesSceneSaveHeader = new ProfilerMarker("EntitiesScene.WriteHeader");


        public static bool IsEntitySubScene(Scene scene)
        {
            return scene.isSubScene;
        }


        public static void WriteEntityScene(SubScene scene)
        {
            Entities.Hash128 guid = new GUID(AssetDatabase.AssetPathToGUID(scene.EditableScenePath));
            WriteEntityScene(scene.LoadedScene, guid, 0);
        }

        public static bool HasEntitySceneCache(Hash128 sceneGUID)
        {
            string headerPath = EntityScenesPaths.GetPathAndCreateDirectory(sceneGUID, EntityScenesPaths.PathType.EntitiesHeader, "");
            return File.Exists(headerPath);
        }

        static AABB GetBoundsAndDestroy(EntityManager entityManager, EntityQuery query)
        {
            var bounds = MinMaxAABB.Empty;
            using (var allBounds = query.ToComponentDataArray<SceneBoundingVolume>(Allocator.TempJob))
            {
                foreach(var b in allBounds)
                    bounds.Encapsulate(b.Value);
            }

            entityManager.DestroyEntity(query);
            
            return bounds;
        }

        public static SceneData[] WriteEntityScene(Scene scene, Hash128 sceneGUID, ConversionFlags conversionFlags)
        {
            var world = new World("ConversionWorld");
            var entityManager = world.EntityManager;
            
            ConvertScene(scene, sceneGUID, world, conversionFlags);
            EntitySceneOptimization.Optimize(world);

            var sceneSections = new List<SceneData>();

            var subSectionList = new List<SceneSection>();
            entityManager.GetAllUniqueSharedComponentData(subSectionList);
            var extRefInfoEntities = new NativeArray<Entity>(subSectionList.Count, Allocator.Temp);

            NativeArray<Entity> entitiesInMainSection;
            
            var sectionQuery = entityManager.CreateEntityQuery(
                new EntityQueryDesc
                {
                    All = new[] {ComponentType.ReadWrite<SceneSection>()},
                    Options = EntityQueryOptions.IncludePrefab | EntityQueryOptions.IncludeDisabled
                }
            );

            var sectionBoundsQuery = entityManager.CreateEntityQuery(
                new EntityQueryDesc
                {
                    All = new[] {ComponentType.ReadWrite<SceneBoundingVolume>(), ComponentType.ReadWrite<SceneSection>()},
                    Options = EntityQueryOptions.IncludePrefab | EntityQueryOptions.IncludeDisabled
                }
            );
            
            {
                var section = new SceneSection {SceneGUID = sceneGUID, Section = 0};
                sectionQuery.SetFilter(new SceneSection { SceneGUID = sceneGUID, Section = 0 });
                sectionBoundsQuery.SetFilter(new SceneSection { SceneGUID = sceneGUID, Section = 0 });
                entitiesInMainSection = sectionQuery.ToEntityArray(Allocator.TempJob);


                var bounds = GetBoundsAndDestroy(entityManager, sectionBoundsQuery);
                
                // Each section will be serialized in its own world, entities that don't have a section are part of the main scene.
                // An entity that holds the array of external references to the main scene is required for each section.
                // We need to create them all before we start moving entities to section scenes,
                // otherwise they would reuse entities that have been moved and mess up the remapping tables.
                for(int sectionIndex = 1; sectionIndex < subSectionList.Count; ++sectionIndex)
                {
                    if (subSectionList[sectionIndex].Section == 0)
                        // Main section, the only one that doesn't need an external ref array
                        continue;

                    var extRefInfoEntity = entityManager.CreateEntity();
                    entityManager.AddSharedComponentData(extRefInfoEntity, subSectionList[sectionIndex]);
                    extRefInfoEntities[sectionIndex] = extRefInfoEntity;
                }

                // Public references array, only on the main section.
                var refInfoEntity = entityManager.CreateEntity();
                entityManager.AddBuffer<PublicEntityRef>(refInfoEntity);
                entityManager.AddSharedComponentData(refInfoEntity, section);
                var publicRefs = entityManager.GetBuffer<PublicEntityRef>(refInfoEntity);

//                entityManager.Debug.CheckInternalConsistency();

                //@TODO do we need to keep this index? doesn't carry any additional info
                for (int i = 0; i < entitiesInMainSection.Length; ++i)
                {
                    PublicEntityRef.Add(ref publicRefs,
                        new PublicEntityRef {entityIndex = i, targetEntity = entitiesInMainSection[i]});
                }

                Debug.Assert(publicRefs.Length == entitiesInMainSection.Length);

                // Save main section
                var sectionWorld = new World("SectionWorld");
                var sectionManager = sectionWorld.EntityManager;

                var entityRemapping = entityManager.CreateEntityRemapArray(Allocator.TempJob);
                sectionManager.MoveEntitiesFrom(entityManager, sectionQuery, entityRemapping);

                // The section component is only there to break the conversion world into different sections
                // We don't want to store that on the disk
                //@TODO: Component should be removed but currently leads to corrupt data file. Figure out why.
                //sectionManager.RemoveComponent(sectionManager.UniversalQuery, typeof(SceneSection));

                var sectionFileSize = WriteEntityScene(sectionManager, sceneGUID, "0");
                sceneSections.Add(new SceneData
                {
                    FileSize = sectionFileSize,
                    SceneGUID = sceneGUID,
                    SharedComponentCount = sectionManager.GetSharedComponentCount() - 1,
                    SubSectionIndex = 0,
                    BoundingVolume = bounds
                });

                entityRemapping.Dispose();
                sectionWorld.Dispose();
            }

            {
                // Index 0 is the default value of the shared component, not an actual section
                for(int subSectionIndex = 0; subSectionIndex < subSectionList.Count; ++subSectionIndex)
                {
                    var subSection = subSectionList[subSectionIndex];
                    if (subSection.Section == 0)
                        continue;

                    sectionQuery.SetFilter(subSection);
                    sectionBoundsQuery.SetFilter(subSection);

                    var bounds = GetBoundsAndDestroy(entityManager, sectionBoundsQuery);
                    
                    var entitiesInSection = sectionQuery.ToEntityArray(Allocator.TempJob);

                    if (entitiesInSection.Length > 0)
                    {
                        // Fetch back the external reference entity we created earlier to not disturb the mapping
                        var refInfoEntity = extRefInfoEntities[subSectionIndex];
                        entityManager.AddBuffer<ExternalEntityRef>(refInfoEntity);
                        var externRefs = entityManager.GetBuffer<ExternalEntityRef>(refInfoEntity);

                        // Store the mapping to everything in the main section
                        //@TODO maybe we don't need all that? is this worth worrying about?
                        for (int i = 0; i < entitiesInMainSection.Length; ++i)
                        {
                            ExternalEntityRef.Add(ref externRefs, new ExternalEntityRef{entityIndex = i});
                        }

                        var entityRemapping = entityManager.CreateEntityRemapArray(Allocator.TempJob);

                        // Entities will be remapped to a contiguous range in the section world, but they will
                        // also come with an unpredictable amount of meta entities. We have the guarantee that
                        // the entities in the main section won't be moved over, so there's a free range of that
                        // size at the end of the remapping table. So we use that range for external references.
                        var externEntityIndexStart = entityRemapping.Length - entitiesInMainSection.Length;

                        entityManager.AddComponentData(refInfoEntity,
                            new ExternalEntityRefInfo
                            {
                                SceneGUID = sceneGUID,
                                EntityIndexStart = externEntityIndexStart
                            });

                        var sectionWorld = new World("SectionWorld");
                        var sectionManager = sectionWorld.EntityManager;

                        // Insert mapping for external references, conversion world entity to virtual index in section
                        for (int i = 0; i < entitiesInMainSection.Length; ++i)
                        {
                            EntityRemapUtility.AddEntityRemapping(ref entityRemapping, entitiesInMainSection[i],
                                new Entity {Index = i + externEntityIndexStart, Version = 1});
                        }

                        sectionManager.MoveEntitiesFrom(entityManager, sectionQuery, entityRemapping);

                        // Now that all the required entities have been moved over, we can get rid of the gap between
                        // real entities and external references. This allows remapping during load to deal with a
                        // smaller remap table, containing only useful entries.

                        int highestEntityIndexInUse = 0;
                        for (int i = 0; i < externEntityIndexStart; ++i)
                        {
                            var targetIndex = entityRemapping[i].Target.Index;
                            if (targetIndex < externEntityIndexStart && targetIndex > highestEntityIndexInUse)
                                highestEntityIndexInUse = targetIndex;
                        }

                        var oldExternEntityIndexStart = externEntityIndexStart;
                        externEntityIndexStart = highestEntityIndexInUse + 1;

                        sectionManager.SetComponentData
                        (
                            EntityRemapUtility.RemapEntity(ref entityRemapping, refInfoEntity),
                            new ExternalEntityRefInfo
                            {
                                SceneGUID = sceneGUID,
                                EntityIndexStart = externEntityIndexStart
                            }
                        );

                        // When writing the scene, references to missing entities are set to Entity.Null by default
                        // (but only if they have been used, otherwise they remain untouched)
                        // We obviously don't want that to happen to our external references, so we add explicit mapping
                        // And at the same time, we put them back at the end of the effective range of real entities.
                        for (int i = 0; i < entitiesInMainSection.Length; ++i)
                        {
                            var src = new Entity {Index = i + oldExternEntityIndexStart, Version = 1};
                            var dst = new Entity {Index = i + externEntityIndexStart, Version = 1};
                            EntityRemapUtility.AddEntityRemapping(ref entityRemapping, src, dst);
                        }

                        // The section component is only there to break the conversion world into different sections
                        // We don't want to store that on the disk
                        //@TODO: Component should be removed but currently leads to corrupt data file. Figure out why.
                        //sectionManager.RemoveComponent(sectionManager.UniversalQuery, typeof(SceneSection));

                        var fileSize = WriteEntityScene(sectionManager, sceneGUID, subSection.Section.ToString(), entityRemapping);
                        sceneSections.Add(new SceneData
                        {
                            FileSize = fileSize,
                            SceneGUID = sceneGUID,
                            SharedComponentCount = sectionManager.GetSharedComponentCount() - 1,
                            SubSectionIndex = subSection.Section,
                            BoundingVolume = bounds
                        });

                        entityRemapping.Dispose();
                        sectionWorld.Dispose();
                    }

                    entitiesInSection.Dispose();
                }
            }

            {
                var noSectionQuery = entityManager.CreateEntityQuery(
                    new EntityQueryDesc
                    {
                        None = new[] {ComponentType.ReadWrite<SceneSection>()},
                        Options = EntityQueryOptions.IncludePrefab | EntityQueryOptions.IncludeDisabled
                    }
                );
                if (noSectionQuery.CalculateLength() != 0)
                    Debug.LogWarning($"{noSectionQuery.CalculateLength()} entities in the scene '{scene.path}' had no SceneSection and as a result were not serialized at all.");
            }
            
            sectionQuery.Dispose();
            sectionBoundsQuery.Dispose();
            entitiesInMainSection.Dispose();
            world.Dispose();
            
            // Save the new header
            var header = ScriptableObject.CreateInstance<SubSceneHeader>();
            header.Sections = sceneSections.ToArray();

            WriteHeader(sceneGUID, header);

            return sceneSections.ToArray();
        }
        
        static int WriteEntityScene(EntityManager scene, Entities.Hash128 sceneGUID, string subsection, NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapInfos = default(NativeArray<EntityRemapUtility.EntityRemapInfo>))
        {
            k_ProfileEntitiesSceneSave.Begin();
            
            var entitiesBinaryPath = EntityScenesPaths.GetPathAndCreateDirectory(sceneGUID, EntityScenesPaths.PathType.EntitiesBinary, subsection);
            var sharedDataPath = EntityScenesPaths.GetPathAndCreateDirectory(sceneGUID, EntityScenesPaths.PathType.EntitiesSharedComponents, subsection);

            GameObject sharedComponents;

            // We're going to do file writing manually, so make sure to do version control dance if needed
            if (Provider.isActive && !AssetDatabase.IsOpenForEdit(entitiesBinaryPath, StatusQueryOptions.UseCachedIfPossible))
            {
                var task = Provider.Checkout(entitiesBinaryPath, CheckoutMode.Asset);
                task.Wait();
                if (!task.success)
                    throw new System.Exception($"Failed to checkout entity cache file {entitiesBinaryPath}");
            }
    
            // Write binary entity file
            int entitySceneFileSize = 0;
            using (var writer = new StreamBinaryWriter(entitiesBinaryPath))
            {
                if (entityRemapInfos.IsCreated)
                    SerializeUtilityHybrid.Serialize(scene, writer, out sharedComponents, entityRemapInfos);
                else
                    SerializeUtilityHybrid.Serialize(scene, writer, out sharedComponents);
                entitySceneFileSize = (int)writer.Length;
            }
            
            // Write shared component data prefab
            k_ProfileEntitiesSceneCreatePrefab.Begin();
            //var oldPrefab = AssetDatabase.LoadMainAssetAtPath(sharedDataPath);
            //if (oldPrefab == null)
                //        PrefabUtility.CreatePrefab(sharedDataPath, sharedComponents, ReplacePrefabOptions.ReplaceNameBased);

            if(sharedComponents != null)
                PrefabUtility.SaveAsPrefabAsset(sharedComponents, sharedDataPath);

            //else
            //    PrefabUtility.Save
                //PrefabUtility.ReplacePrefab(sharedComponents, oldPrefab, ReplacePrefabOptions.ReplaceNameBased);
    
            Object.DestroyImmediate(sharedComponents);
            k_ProfileEntitiesSceneCreatePrefab.End();
            
            
            k_ProfileEntitiesSceneSave.End();
            return entitySceneFileSize;
        }
        
        static void WriteHeader(Entities.Hash128 sceneGUID, SubSceneHeader header)
        {
            k_ProfileEntitiesSceneSaveHeader.Begin();
    
            string headerPath = EntityScenesPaths.GetPathAndCreateDirectory(sceneGUID, EntityScenesPaths.PathType.EntitiesHeader, "");
            AssetDatabase.CreateAsset(header, headerPath);
    
            //subscene.CacheSceneInformation();
    
            k_ProfileEntitiesSceneSaveHeader.End();
        }
    }    
}

