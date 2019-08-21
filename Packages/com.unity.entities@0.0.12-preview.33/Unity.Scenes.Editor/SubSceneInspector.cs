using Unity.Entities;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unity.Scenes.Editor
{
    [CustomEditor(typeof(SubScene))]
    [CanEditMultipleObjects]
    class SubSceneInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var subScene = target as SubScene;
    
            var prevSceneAsset = subScene.SceneAsset;
            var prevColor = subScene.HierarchyColor;
    
            base.OnInspectorGUI();
    
            if (subScene.SceneAsset != prevSceneAsset || subScene.HierarchyColor != prevColor)
                SceneHierarchyHooks.ReloadAllSceneHierarchies();
    
            var targetsArray = targets;
            var subscenes = new SubScene[targetsArray.Length];
            targetsArray.CopyTo(subscenes, 0);
           
            
            EditorGUILayout.TextArea("",GUI.skin.horizontalSlider);
            
            GUILayout.BeginHorizontal();
            if (!SubSceneInspectorUtility.IsEditingAll(subscenes))
            {
                GUI.enabled = SubSceneInspectorUtility.CanEditScene(subscenes);
                if (GUILayout.Button("Edit"))
                {
                    SubSceneInspectorUtility.EditScene(subscenes);
                }
            }
            else
            {
                GUI.enabled = true;
                if (GUILayout.Button("Close"))
                {
                    SubSceneInspectorUtility.CloseAndAskSaveIfUserWantsTo(subscenes);
                }
            }
    
    
            GUI.enabled = SubSceneInspectorUtility.IsDirty(subscenes);
            if (GUILayout.Button("Save"))
            {
                SubSceneInspectorUtility.SaveScene(subscenes);
            }
    
            GUILayout.EndHorizontal();
    
            GUI.enabled = true;
            if (SubSceneInspectorUtility.IsEditingAnyConvertedEntityScenes(subscenes))
            {
                GUILayout.BeginHorizontal();
    
                GUILayout.Space(16);
                EditorGUI.BeginChangeCheck();
                SubSceneInspectorUtility.LiveLinkEnabled = GUILayout.Toggle(SubSceneInspectorUtility.LiveLinkEnabled, "LiveLink (Experimental)");
                if (EditorGUI.EndChangeCheck())
                    EditorUpdateUtility.EditModeQueuePlayerLoopUpdate();

                GUILayout.EndHorizontal();
            }
            
            var scenes = SubSceneInspectorUtility.GetLoadableScenes(subscenes);

            EditorGUILayout.TextArea("",GUI.skin.horizontalSlider);
    
            bool requireRebuild;
            var warning = SubSceneInspectorUtility.GetEntitySceneWarning(subscenes, out requireRebuild);
    
            if (warning != null)
            {
                EditorGUILayout.HelpBox(warning, MessageType.Warning, true);
            }
            if (GUILayout.Button("Rebuild Entity Cache"))
                SubSceneInspectorUtility.RebuildEntityCache(subscenes);
    
            GUILayout.Space(10);
            
            if (World.Active != null)
            {
                var entityManager = World.Active.EntityManager;

                foreach (var scene in scenes)
                {
                    if (!entityManager.HasComponent<RequestSceneLoaded>(scene.Scene))
                    {
                        if (GUILayout.Button($"Load '{scene.Name}'"))
                        {
                            entityManager.AddComponentData(scene.Scene, new RequestSceneLoaded());
                            EditorUpdateUtility.EditModeQueuePlayerLoopUpdate();
                        }
                    }
                    else
                    {
                        if (GUILayout.Button($"Unload '{scene.Name}'"))
                        {
                            entityManager.RemoveComponent<RequestSceneLoaded>(scene.Scene);
                            EditorUpdateUtility.EditModeQueuePlayerLoopUpdate();
                        }
                    }
                }
            }
       
            
    #if false        
            // @TODO: TEMP for debugging
            if (GUILayout.Button("ClearWorld"))
            {
                World.DisposeAllWorlds();
                DefaultWorldInitialization.Initialize("Default World", !Application.isPlaying);
    
                var scenes = FindObjectsOfType<SubScene>();
                foreach (var scene in scenes)
                {
                    var oldEnabled = scene.enabled; 
                    scene.enabled = false;
                    scene.enabled = oldEnabled;
                }
                
                EditorUpdateUtility.EditModeQueuePlayerLoopUpdate();
            }
    #endif
            
            var uncleanHierarchyObject = SubSceneInspectorUtility.GetUncleanHierarchyObject(subscenes);
            if (uncleanHierarchyObject != null)
            {
                EditorGUILayout.HelpBox($"Scene transform values are not applied to scenes child transforms. But {uncleanHierarchyObject.name} has an offset Transform.", MessageType.Warning, true);
                if (GUILayout.Button("Clear"))
                {
                    foreach (var scene in subscenes)
                    {
                        scene.transform.localPosition = Vector3.zero;
                        scene.transform.localRotation = Quaternion.identity;
                        scene.transform.localScale = Vector3.one;
                    }
                }
            }
            if (SubSceneInspectorUtility.HasChildren(subscenes))
            {
                EditorGUILayout.HelpBox($"SubScenes can not have child game objects. Close the scene and delete the child game objects.", MessageType.Warning, true);
            }
        }

        MinMaxAABB GetMinMax()
        {
            MinMaxAABB bounds = MinMaxAABB.Empty;
            foreach (SubScene subScene in targets)
                bounds.Encapsulate(subScene.SceneBoundingVolume);
            
            return bounds;
        }


        // Invoked by Unity magically for FrameSelect command.
        // Frames the whole sub scene in scene view
        bool HasFrameBounds()     { return !GetMinMax().Equals(MinMaxAABB.Empty); }
        Bounds OnGetFrameBounds() { AABB aabb = GetMinMax(); return new Bounds(aabb.Center, aabb.Size); }
        
        
        // Visualize SubScene using bounding volume when it is selected.
        [DrawGizmo(GizmoType.Selected)]
        static void DrawSubsceneBounds(SubScene scene, GizmoType gizmoType)
        {
            var isEditing = scene.IsLoaded;

            if (scene.SceneData == null)
                return;
                
            foreach (var sceneData in scene.SceneData)
            {
                if (sceneData.BoundingVolume.IsEmpty)
                    continue;

                if (isEditing)
                    Gizmos.color = Color.green;
                else
                    Gizmos.color = Color.gray;
                
                AABB aabb = sceneData.BoundingVolume;
                Gizmos.DrawWireCube(aabb.Center, aabb.Size);
            }
        }
    }
}

