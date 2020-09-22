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
            if (Application.isPlaying)
                DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            if (UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log($"Extra Volume Manager cleaned up. GUID:{gameObject.GetInstanceID()}");
            StopAllCoroutines();
            Utility.SafeDestroy(this);
        }

        Utility.QualityLevelChange += UpdateVolume;
        UpdateVolume(0, Utility.GetTrueQualityLevel()); // First time set
    }

    private void OnDestroy()
    {
        Utility.QualityLevelChange -= UpdateVolume;
        StopAllCoroutines();
    }

    private void UpdateVolume(int level, int realLevel)
    {
        //Setup Quality Vol if needed
        if (qualityVolumes?.Length > realLevel && qualityVolumes[realLevel] != null)
        {
            StartCoroutine(LoadAndApplyQualityVolume(realLevel));
        }
        else
        {
            volQualityComponent.sharedProfile = null;
        }
    }

    private IEnumerator LoadAndApplyQualityVolume(int index)
    {
        var volLoading = qualityVolumes[index].LoadAssetAsync<VolumeProfile>();
        yield return volLoading;
        volQualityComponent.sharedProfile = volLoading.Result;

        if (UniversalRenderPipeline.asset.debugLevel == PipelineDebugLevel.Disabled) yield break;
        if (volBaseComponent.sharedProfile && volQualityComponent.sharedProfile)
        {
            Debug.Log(message: "Updated volumes:\n" +
                               $"    Base Volume : {volBaseComponent.sharedProfile.name}\n" +
                               $"    Quality Volume : {volQualityComponent.sharedProfile.name}\n" +
                               "Total Volume Stack is now:\n");
        }
    }
}

/// <summary>
/// Editor Injection
/// </summary>

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
        CreateVolumeManager(HideFlags.HideAndDontSave);
        //EditorApplication.delayCall += () => { CreateVolumeManager(HideFlags.HideAndDontSave); };
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
                Utility.SafeDestroy(DefaultVolume.Instance);
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
        if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
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