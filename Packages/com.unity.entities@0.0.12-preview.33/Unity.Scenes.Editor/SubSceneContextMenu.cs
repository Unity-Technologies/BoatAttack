using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace Unity.Scenes.Editor
{
    class SubSceneContextMenu
    {
        public static void AddExtraGameObjectContextMenuItems(GenericMenu menu, GameObject target)
        {
            menu.AddSeparator("");
            var addSubSceneContent = EditorGUIUtility.TrTextContent("New SubScene From Selection");
            if (!EditorApplication.isPlaying && GetValidGameObjectForSubSceneCreation(target) != null)
                menu.AddItem(addSubSceneContent, false, CreateSubSceneAndAddSelection, target);
            else
                menu.AddDisabledItem(addSubSceneContent);
        }
    
        static GameObject[] GetValidGameObjectForSubSceneCreation(GameObject target)
        {
            if (target == null)
                return null;
            if (!target.scene.IsValid())
                return null;
            if (string.IsNullOrEmpty(target.scene.path))
                return null;
    
            var selection = Selection.GetFiltered<GameObject>(SelectionMode.TopLevel);
            if (selection.Any(x => EditorUtility.IsPersistent(x)))
                return null;
    
            if (!selection.Contains(target))
                return null;
            return selection;
        }
    
        static void CreateSubSceneAndAddSelection(object target)
        {
            GameObject gameObjectTarget = (GameObject)target;
            var validSelection = GetValidGameObjectForSubSceneCreation(gameObjectTarget);
            if (validSelection == null)
                return;
    
            CreateSubSceneAndMoveObjectInside(gameObjectTarget.scene, gameObjectTarget.transform.parent, validSelection, gameObjectTarget.name);
        }
        
        static void CreateSubSceneAndMoveObjectInside(Scene parentScene, Transform parent, GameObject[] objects, string name)
        {
            EditorSceneManager.MarkSceneDirty(parentScene);

            var srcPath = parentScene.path;
            var dstDirectory = Path.Combine(Path.GetDirectoryName(srcPath), Path.GetFileNameWithoutExtension(parentScene.path));
            var dstPath = Path.Combine(dstDirectory, name + ".unity");
    
            Directory.CreateDirectory(dstDirectory);
    
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            scene.isSubScene = true;
            foreach (var go in objects)
            {
                go.transform.SetParent(null, true);
                SceneManager.MoveGameObjectToScene(go, scene);
            }
                
            
            EditorSceneManager.SaveScene(scene, dstPath);

            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(dstPath);

            
            var gameObject = new GameObject(name, typeof(SubScene));
            gameObject.SetActive(false);
            var subScene = gameObject.GetComponent<SubScene>();
            subScene.SceneAsset = sceneAsset;
            
            if (parent)
                gameObject.transform.parent = parent;
            else
                SceneManager.MoveGameObjectToScene(gameObject, parentScene);
            
            EditorEntityScenes.WriteEntityScene(subScene);
            gameObject.SetActive(true);
                        
            Selection.activeObject = gameObject;        
        }
    }
}