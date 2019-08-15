using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Unity.Scenes.Editor
{
    [InitializeOnLoad]
    class SubSceneTransformHierarchyHook
    {
        static SubSceneTransformHierarchyHook( )
        {
            SceneHierarchyHooks.provideSubScenes = ProvideSubScenes;
            SceneHierarchyHooks.addItemsToGameObjectContextMenu += SubSceneContextMenu.AddExtraGameObjectContextMenuItems;
        }

        static string GetSceneName(SceneAsset sceneAsset, Scene scene)
        {
            if (sceneAsset == null)
                return "Missing SubScene";
                
            var name = sceneAsset.name;
            
            if (scene.isDirty)
                name += "*";
            
            return name;
        }

        static SceneHierarchyHooks.SubSceneInfo[] ProvideSubScenes()
        {
            var scenes = new SceneHierarchyHooks.SubSceneInfo[SubScene.AllSubScenes.Count()];
            var loadedScenes = new HashSet<Scene>();

            int index = 0;
            foreach (var subScene in SubScene.AllSubScenes)
            {
                var loadedScene = default(Scene);
                var candidateScene = subScene.LoadedScene;
                if (candidateScene.IsValid() && candidateScene.isSubScene)
                {
                    if (loadedScenes.Add(candidateScene))
                        loadedScene = candidateScene;
                }

                scenes[index].transform = subScene.transform;
                scenes[index].scene = loadedScene;
                scenes[index].sceneAsset = subScene.SceneAsset;
                scenes[index].color = subScene.HierarchyColor;
                scenes[index].sceneName = GetSceneName(subScene.SceneAsset, loadedScene);
                index++;
            }

            return scenes;
        }
    }
}
