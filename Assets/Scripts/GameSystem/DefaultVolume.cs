using System.Collections;
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
    public static DefaultVolume Instance;
    public Volume volBaseComponent;
    public Volume volQualityComponent;
    public AssetReference[] qualityVolumes;
    private int _currentQualityLevel;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
            if(Application.isPlaying)
                DontDestroyOnLoad(gameObject);
            _currentQualityLevel = QualitySettings.GetQualityLevel();
            UpdateVolume();
        }
        else if(Instance != this)
        {
            if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log($"Extra Volume Manager cleaned up. GUID:{gameObject.GetInstanceID()}");
#if UNITY_EDITOR
            DestroyImmediate(gameObject);
            return;
#else
            Destroy(gameObject);
            return;
#endif
        }
    }

    private void LateUpdate()
    {
        if (_currentQualityLevel != QualitySettings.GetQualityLevel())
        {
            _currentQualityLevel = QualitySettings.GetQualityLevel();
            UpdateVolume();
        }
    }

    public void UpdateVolume()
    {
        //Setup Quality Vol if needed
        if (qualityVolumes?.Length > _currentQualityLevel && qualityVolumes[_currentQualityLevel] != null)
        {
#if UNITY_EDITOR
            LoadVolEditor(_currentQualityLevel);
#else
            StartCoroutine(LoadAndApplyQualityVolume(_currentQualityLevel));
#endif
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
#else
    private IEnumerator LoadAndApplyQualityVolume(int index)
    {
        var volLoading = qualityVolumes[index].LoadAssetAsync<VolumeProfile>();
        yield return volLoading;
        volQualityComponent.sharedProfile = volLoading.Result;
    }
#endif
}

#if UNITY_EDITOR
[InitializeOnLoad]
public class StartupVolume
{
    private static GameObject _vol;

    static StartupVolume()
    {
        EditorApplication.delayCall += () =>
        {
            var obj = AssetDatabase.LoadAssetAtPath("Assets/objects/misc/DefaultVolume.prefab", typeof(GameObject)) as GameObject;
            if (obj == null) return;
            if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log($"Creating Volume Manager");
            _vol = Object.Instantiate(obj);
            _vol.hideFlags = HideFlags.HideAndDontSave;
        };
    }
}
#endif