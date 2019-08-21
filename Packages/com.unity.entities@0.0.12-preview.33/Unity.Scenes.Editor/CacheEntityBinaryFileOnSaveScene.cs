using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using static Unity.Entities.GameObjectConversionUtility;

namespace Unity.Scenes.Editor
{
    [InitializeOnLoad]
    static class CacheEntityBinaryFileOnSaveScene
    {
        static CacheEntityBinaryFileOnSaveScene()
        {
            EditorSceneManager.sceneSaving += SceneSavingCallback;
        }

        public static void SceneSavingCallback(Scene scene, string scenePath)
        {
            var sceneGUID = new GUID(AssetDatabase.AssetPathToGUID(scenePath));

            if (EditorEntityScenes.HasEntitySceneCache(sceneGUID))
            {
                EditorEntityScenes.WriteEntityScene(scene, sceneGUID, 0);
            }
        }
    }    
}
