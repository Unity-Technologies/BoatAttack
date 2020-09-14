using System;
using System.Collections;
using BoatAttack;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
#endif

[ExecuteAlways]
public class DefaultVolume : MonoBehaviour
{
    public static DefaultVolume Instance;
    public Volume volBaseComponent;
    public Volume volQualityComponent;
    public AssetReference[] qualityVolumes;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
            if(Application.isPlaying)
                DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log($"Extra Volume Manager cleaned up. GUID:{gameObject.GetInstanceID()}");
            SafeDestroy();
        }
        Utility.QualityLevelChange += UpdateVolume;
    }

    public static void SafeDestroy()
    {
#if UNITY_EDITOR
        DestroyImmediate(Instance);
        return;
#else
        Destroy(Instance);
        return;
#endif
    }

    private void OnDestroy()
    {
        Utility.QualityLevelChange -= UpdateVolume;
    }

    public void UpdateVolume(int from, int to)
    {
        //Setup Quality Vol if needed
        if (qualityVolumes?.Length > to && qualityVolumes[to] != null)
        {
            StartCoroutine(LoadAndApplyQualityVolume(to));
        }
        else
        {
            volQualityComponent.sharedProfile = null;
        }

        if (UniversalRenderPipeline.asset.debugLevel == PipelineDebugLevel.Disabled) return;
        if (volBaseComponent.sharedProfile && volQualityComponent.sharedProfile)
        {
            Debug.Log(message: "Updated volumes:\n" +
                               $"    Base Volume : {volBaseComponent.sharedProfile.name}\n" +
                               $"    Quality Volume : {volQualityComponent.sharedProfile.name}\n" +
                               "Total Volume Stack is now:\n");
        }
    }

#if UNITY_EDITOR
    private void LoadVolEditor(int index)
    {
        if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
            Debug.Log("Loading volumes in editor.");
        var assetRef = qualityVolumes[index];
        var obj = assetRef.editorAsset;
        volQualityComponent.sharedProfile = obj as VolumeProfile;
    }
#endif
    private IEnumerator LoadAndApplyQualityVolume(int index)
    {
        var volLoading = qualityVolumes[index].LoadAssetAsync<VolumeProfile>();
        yield return volLoading;
        volQualityComponent.sharedProfile = volLoading.Result;
    }
}

#if UNITY_EDITOR

[InitializeOnLoad]
internal class InjectDefaultVolume : IProcessSceneWithReport
{
    public int callbackOrder => 1;
    private static GameObject _vol;

    static InjectDefaultVolume()
    {
        var vols = GameObject.FindGameObjectsWithTag("volume_manager");
        foreach (var vol in vols)
        {
            Object.DestroyImmediate(vol);
        }

        EditorApplication.delayCall += () => { CreateVolumeManager(HideFlags.HideAndDontSave); };
        EditorApplication.playModeStateChanged += StateChange;
    }

    private static void StateChange(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                if(DefaultVolume.Instance == null)
                    CreateVolumeManager(HideFlags.HideAndDontSave);
                break;
            case PlayModeStateChange.ExitingEditMode:
                if (DefaultVolume.Instance != null)
                    DefaultVolume.SafeDestroy();
                break;
            case PlayModeStateChange.EnteredPlayMode:
                break;
            case PlayModeStateChange.ExitingPlayMode:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
        }
    }

    public void OnProcessScene(Scene scene, BuildReport report)
    {
        if(scene.buildIndex != 0)
            return;
        
        Debug.Log($"Injecting Default volume into scene:{scene.name}");
        CreateVolumeManager();
    }

    private static void CreateVolumeManager(HideFlags flags = HideFlags.None)
    {
        var obj =
            AssetDatabase.LoadAssetAtPath("Assets/objects/misc/DefaultVolume.prefab", typeof(GameObject)) as
                GameObject;
        if (obj == null) return;
        if (UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
            Debug.Log($"Creating Volume Manager");
        _vol = Object.Instantiate(obj);
        _vol.hideFlags = flags;
    }
}

#endif