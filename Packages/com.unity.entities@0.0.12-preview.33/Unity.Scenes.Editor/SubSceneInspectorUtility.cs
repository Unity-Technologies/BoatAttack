using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

namespace Unity.Scenes.Editor
{
    static class SubSceneInspectorUtility
    {
        public static Transform GetUncleanHierarchyObject(SubScene[] subscenes)
        {
            foreach (var scene in subscenes)
            {
                var res = GetUncleanHierarchyObject(scene.transform);
                if (res != null)
                    return res;
            }
    
            return null;
        }
    
        public static Transform GetUncleanHierarchyObject(Transform child)
        {
            while (child)
            {
                if (child.localPosition != Vector3.zero)
                    return child;
                if (child.localRotation != Quaternion.identity)
                    return child;
                if (child.localScale!= Vector3.one)
                    return child;
                
                child = child.parent;
            }
    
            return null;
        }
        
        public static bool HasChildren(SubScene[] scenes)
        {
            foreach (var scene in scenes)
            {
                if (scene.transform.childCount != 0)
                    return true;
            }
    
            return false;
        }
    
        public static void CloseSceneWithoutSaving(params SubScene[] scenes)
        {
            foreach(var scene in scenes)
                EditorSceneManager.CloseScene(scene.LoadedScene, true);
        }
    
        public struct LoadableScene
        {
            public Entity Scene;
            public string Name;
        }
    
        public static LoadableScene[] GetLoadableScenes(SubScene[] scenes)
        {
            var loadables = new List<LoadableScene>();
            
            foreach (var scene in scenes)
            {
                var sceneHeaderPath = EntityScenesPaths.GetLoadPath(scene.SceneGUID, EntityScenesPaths.PathType.EntitiesHeader, -1);
                var sceneHeader = AssetDatabase.LoadAssetAtPath<SubSceneHeader>(sceneHeaderPath);
    
                if (sceneHeader != null && sceneHeader.Sections != null && scene._SceneEntities.Count == sceneHeader.Sections.Length)
                {
                    for (int i = 0; i != sceneHeader.Sections.Length;i++)
                    {
                        var name = scene.SceneAsset.name;
                        var sectionIndex = sceneHeader.Sections[i].SubSectionIndex;
                        if (sectionIndex != 0)
                            name += $" Section: {sectionIndex}";
                        
                        loadables.Add(new LoadableScene
                        {
                            Scene = scene._SceneEntities[i],
                            Name = name
                        });
                    }
                }
            }
    
            return loadables.ToArray();
        }
        
        public static bool IsEditingAll(SubScene[] scenes)
        {
            foreach (var scene in scenes)
            {
                if (!scene.IsLoaded)
                    return false;
            }
    
            return true;
        }
        
        public static bool CanEditScene(SubScene scene)
        {
#if UNITY_EDITOR
            // Disallow editing when in prefab edit mode
            if (PrefabStageUtility.GetPrefabStage(scene.gameObject) != null)
                return false;
            if (!scene.isActiveAndEnabled)
                return false;
#endif
    
            return !scene.IsLoaded;
        }
    
        public static bool IsLoaded(SubScene[] scenes)
        {
            foreach (var subScene in scenes)
            {
                if (subScene.IsLoaded)
                    return true;
            }
    
            return false;
        }
        
        public static bool CanEditScene(SubScene[] scenes)
        {
            foreach (var subScene in scenes)
            {
                if (CanEditScene(subScene))
                    return true;
            }
    
            return false;
        }
    
        public static void EditScene(params SubScene[] scenes)
        {
            foreach (var subScene in scenes)
            {
                if (CanEditScene(subScene))
                {
                    Scene scene;
                    if (Application.isPlaying)
                        scene = EditorSceneManager.LoadSceneInPlayMode(subScene.EditableScenePath, new LoadSceneParameters(LoadSceneMode.Additive));
                    else
                        scene = EditorSceneManager.OpenScene(subScene.EditableScenePath, OpenSceneMode.Additive);
                    scene.isSubScene = true;
                }
            }
        }
    
        
        public static void CloseAndAskSaveIfUserWantsTo(SubScene[] subScenes)
        {
            if (!Application.isPlaying)
            {
                var dirtyScenes = new List<Scene>();
                foreach (var scene in subScenes)
                {
                    if (scene.LoadedScene.isLoaded && scene.LoadedScene.isDirty)
                    {
                        dirtyScenes.Add(scene.LoadedScene);
                    }
                }
    
                if (dirtyScenes.Count != 0)
                {
                    if (!EditorSceneManager.SaveModifiedScenesIfUserWantsTo(dirtyScenes.ToArray()))
                        return;
                }
            
                CloseSceneWithoutSaving(subScenes);
            }
            else
            {
                foreach (var scene in subScenes)
                {
                    if (scene.LoadedScene.isLoaded)
                        EditorSceneManager.UnloadSceneAsync(scene.LoadedScene);
                }
            }
        }
        
        public static void SaveScene(SubScene[] subScenes)
        {
            foreach (var scene in subScenes)
            {
                if (scene.LoadedScene.isLoaded && scene.LoadedScene.isDirty)
                {
                    EditorSceneManager.SaveScene(scene.LoadedScene);
                }
            }
        }
        public static bool IsDirty(SubScene[] scenes)
        {
            foreach (var scene in scenes)
            {
                if (scene.LoadedScene.isLoaded && scene.LoadedScene.isDirty)
                    return true;
            }
    
            return false;
        }
    
        public static bool IsEditingAnyConvertedEntityScenes(SubScene[] scenes)
        {
            foreach (var scene in scenes)
            {
                if (scene.LoadedScene.isLoaded)
                    return true;
            }
    
            return false;    
        }

        public static void RebuildEntityCache(params SubScene[] scenes)
        {
            try
            {
                Profiler.BeginSample("AssetDatabase.StartAssetEditing");
                AssetDatabase.StartAssetEditing();
                Profiler.EndSample();
                
                for (int i = 0; i != scenes.Length; i++)
                {
                    var scene = scenes[i];
                    EditorUtility.DisplayProgressBar("Rebuilding Entity Cache", scene.SceneName, (float) i / scenes.Length);

                    var isLoaded = scene.IsLoaded;
                    if (!isLoaded)
                        EditScene(scene);

                    try
                    {
                        EditorEntityScenes.WriteEntityScene(scene);
                        scene.UpdateSceneEntities();
                    }
                    catch (Exception exception)
                    {
                        Debug.LogException(exception);
                    }


                    if (!isLoaded)
                        CloseSceneWithoutSaving(scene);
                }
            }
            finally
            {
                Profiler.BeginSample("AssetDatabase.StopAssetEditing");
                AssetDatabase.StopAssetEditing();
                Profiler.EndSample();

                EditorUtility.ClearProgressBar();
            }
        }
    
        public static string GetEntitySceneWarning(SubScene[] scenes, out bool requireCacheRebuild)
        {
            requireCacheRebuild = false;
            foreach (var scene in scenes)
            {
                if (scene.SceneAsset == null)
                    return $"Please assign a valid Scene Asset";
                
                var sceneHeaderPath = EntityScenesPaths.GetLoadPath(scene.SceneGUID, EntityScenesPaths.PathType.EntitiesHeader, -1);
                var sceneHeader = AssetDatabase.LoadAssetAtPath<SubSceneHeader>(sceneHeaderPath);
    
                if (sceneHeader == null)
                {
                    requireCacheRebuild = true;
                    return $"The entity binary file header couldn't be found. Please Rebuild Entity Cache.";
                }
                
                //@TODO: validate header against wrong types?
                //@TODO: validate actual errors when loading
                //@TODO: validate against dependency chain being out of date
            }
    
            return null;
        }
        
        public static bool LiveLinkEnabled
        {
            get { return EditorPrefs.GetBool("Unity.Entities.Streaming.SubScene.LiveLinkEnabled2", false); }
            set { EditorPrefs.SetBool("Unity.Entities.Streaming.SubScene.LiveLinkEnabled2", value); }
        }
    }
}
