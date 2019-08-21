using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace Unity.Scenes
{
    [ExecuteAlways]
    public class SubScene : MonoBehaviour
    {
    #if UNITY_EDITOR
        [FormerlySerializedAs("sceneAsset")]
        [SerializeField] SceneAsset _SceneAsset;
        [SerializeField] Color _HierarchyColor = Color.gray;
    
        static List<SubScene> m_AllSubScenes = new List<SubScene>();
        public static IReadOnlyCollection<SubScene> AllSubScenes { get { return m_AllSubScenes; } }
    
        [NonSerialized] public int LiveLinkDirtyID = -1;
        [NonSerialized] public World LiveLinkShadowWorld;
    
    #endif
        
        public bool AutoLoadScene = true;
        
    
        [NonSerialized] EntityManager _SceneEntityManager;
        [NonSerialized] public List<Entity> _SceneEntities = new List<Entity>();
    
        [SerializeField]
        [HideInInspector]
        SubSceneHeader m_SubSceneHeader = null;
        
    #if UNITY_EDITOR

        public MinMaxAABB SceneBoundingVolume
        {
            get
            {
                var bounds = MinMaxAABB.Empty;

                if (m_SubSceneHeader != null && m_SubSceneHeader.Sections != null)
                {
                    foreach (var sceneData in m_SubSceneHeader.Sections)
                        bounds.Encapsulate(sceneData.BoundingVolume);
                }

                return bounds;
            }
        }
        
        public SceneData[] SceneData
        {
            get
            {
                if (m_SubSceneHeader != null && m_SubSceneHeader.Sections != null)
                    return m_SubSceneHeader.Sections;
                else
                    return null;
            }
        }

        public SceneAsset SceneAsset
        {
            get { return _SceneAsset; }
            set
            {
                _SceneAsset = value;
            }
        }

        public string SceneName
        {
            get { return SceneAsset.name; }
        }

        public GUID SceneGUID
        {
            get
            {
                if (_SceneAsset != null)
                    return new GUID(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(_SceneAsset)));
                else
                    return new GUID();
            }
        }
        public Color HierarchyColor
        {
            get { return _HierarchyColor; }
            set { _HierarchyColor = value; }
        }
    
    
        public string EditableScenePath
        {
            get 
            { 
                return _SceneAsset != null ? AssetDatabase.GetAssetPath(_SceneAsset) : "";    
            }
        }
        
        public Scene LoadedScene
        {
            get
            {
                if (_SceneAsset == null)
                    return default(Scene);
                
                return EditorSceneManager.GetSceneByPath(AssetDatabase.GetAssetPath(_SceneAsset));
            }
        }
        
        public bool IsLoaded
        {
            get { return LoadedScene.isLoaded; }
        }
    
    #endif
    
    
        void OnEnable()
        {
    #if UNITY_EDITOR
            if (UnityEditor.Experimental.SceneManagement.PrefabStageUtility.GetPrefabStage(gameObject) != null)
                return;
    
            m_SubSceneHeader = null;
            if (SceneAsset == null)
                return;
            
            foreach (var subscene in m_AllSubScenes)
            {
                if (subscene.SceneAsset == SceneAsset)
                {
                    Debug.LogWarning($"A sub-scene can not include the same scene ('{EditableScenePath}') multiple times.", this);
                    return;
                }
            }
                 
            m_AllSubScenes.Add(this);

            var sceneHeaderPath = EntityScenesPaths.GetLoadPath(SceneGUID, EntityScenesPaths.PathType.EntitiesHeader, -1);
            m_SubSceneHeader = AssetDatabase.LoadAssetAtPath<SubSceneHeader>(sceneHeaderPath);
    
            if (m_SubSceneHeader == null)
            {
                Debug.LogWarning($"Sub-scene '{EditableScenePath}' has no valid header at '{sceneHeaderPath}'. Please rebuild the Entity Cache.", this);
                return;
            }
    #endif
            
            UpdateSceneEntities();
        }

        public void UpdateSceneEntities()
        {
#if UNITY_EDITOR
            var sceneHeaderPath = EntityScenesPaths.GetLoadPath(SceneGUID, EntityScenesPaths.PathType.EntitiesHeader, -1);
            m_SubSceneHeader = AssetDatabase.LoadAssetAtPath<SubSceneHeader>(sceneHeaderPath);
#endif

            if (_SceneEntityManager != null && _SceneEntityManager.IsCreated)
            {
                foreach (var sceneEntity in _SceneEntities)
                {
                    _SceneEntityManager.DestroyEntity(sceneEntity);
                }
            }
            _SceneEntities.Clear();
            _SceneEntityManager = null;

            DefaultWorldInitialization.DefaultLazyEditModeInitialize();
            if (World.Active != null && m_SubSceneHeader != null)
            {
                _SceneEntityManager = World.Active.EntityManager;

                for (int i = 0; i < m_SubSceneHeader.Sections.Length; ++i)
                {
                    var sceneEntity = _SceneEntityManager.CreateEntity();
                    #if UNITY_EDITOR
                    _SceneEntityManager.SetName(sceneEntity, i == 0 ? $"Scene: {SceneName}" : $"Scene: {SceneName} ({i})");
                    #endif

                    _SceneEntities.Add(sceneEntity);
                    _SceneEntityManager.AddComponentObject(sceneEntity, this);
    
                    if (AutoLoadScene)
                        _SceneEntityManager.AddComponentData(sceneEntity, new RequestSceneLoaded());
    
                    _SceneEntityManager.AddComponentData(sceneEntity, m_SubSceneHeader.Sections[i]);
                    _SceneEntityManager.AddComponentData(sceneEntity, new SceneBoundingVolume { Value = m_SubSceneHeader.Sections[i].BoundingVolume });
                }
            }
        }
        
        void OnDisable()
        {
    #if UNITY_EDITOR
            m_AllSubScenes.Remove(this);
    #endif
            
            if (_SceneEntityManager != null && _SceneEntityManager.IsCreated)
            {
                foreach (var sceneEntity in _SceneEntities)
                {
                    _SceneEntityManager.DestroyEntity(sceneEntity);
                }
    
                _SceneEntityManager = null;
            }
    
            _SceneEntities.Clear();
            CleanupLiveLink();
        }
    
        //@TODO: Move this into SceneManager
        void UnloadScene()
        {
    #if UNITY_EDITOR
            var scene = LoadedScene;
            if (scene.IsValid())
            {
                // If there is only one scene left in the editor, we create a new empty scene
                // before unloading this sub scene
                if (EditorSceneManager.loadedSceneCount == 1)
                {
                    Debug.Log("Creating new scene");
                    EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Additive);
                }
    
                EditorSceneManager.UnloadSceneAsync(scene);    
            }
    #endif
        }
    
        public void CleanupLiveLink()
        {
    #if UNITY_EDITOR
            if (LiveLinkShadowWorld != null && LiveLinkShadowWorld.IsCreated)
                LiveLinkShadowWorld.Dispose();
            LiveLinkShadowWorld = null;
            LiveLinkDirtyID = -1;
    #endif
        }
    
        private void OnDestroy()
        {
            UnloadScene();
        }
    }
}
