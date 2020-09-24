using System;using System.Collections;
using BoatAttack;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.ResourceManagement.AsyncOperations;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.AddressableAssets;
#endif

[ExecuteAlways]
public class DefaultVolume : MonoBehaviour
{
    public static DefaultVolume Instance { get; private set; }

    public Volume volBaseComponent;
    public Volume volQualityComponent;
    public AssetReference[] qualityVolumes;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        gameObject.hideFlags = HideFlags.HideAndDontSave;

        if (Instance != null && Instance != this)
        {
            if (UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log($"Extra Volume Manager cleaned up. GUID:{gameObject.GetInstanceID()}");
            StopAllCoroutines();
            Utility.SafeDestroy(gameObject);
        }
        else
        {
            Instance = this;
            gameObject.name = "[DefaultVolume]";
            Debug.Log($"Default Volume is {gameObject.GetInstanceID()}");
            Utility.QualityLevelChange += UpdateVolume;
            UpdateVolume(0, Utility.GetTrueQualityLevel()); // First time set
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        if (Instance == this)
            Instance = null;
        Utility.QualityLevelChange -= UpdateVolume;
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
        var vol = qualityVolumes[index];
        if (!vol.OperationHandle.IsValid() || vol.OperationHandle.Status != AsyncOperationStatus.Succeeded)
        {
            qualityVolumes[index].LoadAssetAsync<VolumeProfile>();
        }
        yield return vol.OperationHandle;
        volQualityComponent.sharedProfile = vol.OperationHandle.Result as VolumeProfile;

        if (UniversalRenderPipeline.asset.debugLevel == PipelineDebugLevel.Disabled) yield break;
        if (volBaseComponent.sharedProfile && volQualityComponent.sharedProfile)
        {
            Debug.Log(message: "Updated volumes:\n" +
                               $"    Base Volume : {volBaseComponent.sharedProfile.name}\n" +
                               $"    Quality Volume : {volQualityComponent.sharedProfile.name}\n" +
                               "Total Volume Stack is now:\n");
        }
    }

#if UNITY_EDITOR
    [InitializeOnLoadMethod]
#else
    [RuntimeInitializeOnLoadMethod]
#endif
    static void LoadMe()
    {
        Debug.Log("runtime loading");
        var vols = Resources.FindObjectsOfTypeAll(typeof(DefaultVolume)) as DefaultVolume[];
        if (vols == null) return;

        if (vols.Length == 0 && Instance == null)
        {
            var goHandle = Addressables.InstantiateAsync("volume_manager");
        }
        else
        {
            foreach (var vol in vols)
            {
                if(vol.gameObject.activeSelf && vol.gameObject.activeInHierarchy)
                    vol.Init();
            }
        }
    }
}

/// <summary>
/// Editor Injection
/// </summary>
/*
#if UNITY_EDITOR
[InitializeOnLoad]
internal class DefaultVolumeEditor : IProcessSceneWithReport
{
    public int callbackOrder => 1;
    private static GameObject _vol;

    static DefaultVolumeEditor()
    {
        //EditorApplication.delayCall += InjectDefaultVolume;
        //EditorApplication.playModeStateChanged += StateChange;
    }

    private static void InjectDefaultVolume()
    {
        if (DefaultVolume.Instance != null) return;

        var vols = GameObject.FindGameObjectsWithTag("volume_manager");
        foreach (var vol in vols)
        {
            Object.DestroyImmediate(vol);
        }

        CreateVolumeManager(HideFlags.DontSaveInEditor);
    }

    private static void StateChange(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                if(DefaultVolume.Instance == null)
                    CreateVolumeManager(HideFlags.DontSaveInEditor);
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
        //Addressables
        //var asset = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(entry.guid);


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
*/