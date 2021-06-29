using System.Collections;
using BoatAttack;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class DefaultVolume : MonoBehaviour
{
    public static DefaultVolume Instance { get; private set; }

    public Volume volBaseComponent;
    public Volume volQualityComponent;
    public AssetReference[] qualityVolumes;
    private static bool _loading;

    private void Awake()
    {
        if (volBaseComponent && volQualityComponent)
        {
            Init();
        }
        else
        {
            Utility.SafeDestroy(gameObject);
        }
    }

    private void Init()
    {
#if UNITY_EDITOR
        gameObject.hideFlags = HideFlags.HideAndDontSave;
#else
        DontDestroyOnLoad(gameObject);
#endif

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
            if (UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
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
        while (_loading) { yield return null; }
        _loading = true;
        var vol = qualityVolumes[index];
        if (!vol.OperationHandle.IsValid() || !vol.OperationHandle.IsDone)
        {
            qualityVolumes[index].LoadAssetAsync<VolumeProfile>();
        }
        yield return vol.OperationHandle;
        volQualityComponent.sharedProfile = vol.OperationHandle.Result as VolumeProfile;
        _loading = false;

        if (UniversalRenderPipeline.asset.debugLevel == PipelineDebugLevel.Disabled) yield break;
        Debug.Log(message: "Updated volumes:\n" +
                           $"    Base Volume : {(volBaseComponent.sharedProfile ? volBaseComponent.sharedProfile.name : "none")}\n" +
                           $"    Quality Volume : {(volQualityComponent.sharedProfile ? volQualityComponent.sharedProfile.name : "none")}\n" +
                           "Total Volume Stack is now:\n");
    }

#if UNITY_EDITOR
    [InitializeOnLoadMethod]
#else
    [RuntimeInitializeOnLoadMethod]
#endif
    private static void LoadMe()
    {
        if (!(Resources.FindObjectsOfTypeAll(typeof(DefaultVolume)) is DefaultVolume[] vols)) return;

        if (vols.Length != 0 || Instance != null)
        {
            foreach (var vol in vols)
            {
                if (vol.gameObject.activeSelf && vol.gameObject.activeInHierarchy) vol.Init();
            }
        }
        else
        {
            Addressables.InstantiateAsync("volume_manager");
        }
    }
}