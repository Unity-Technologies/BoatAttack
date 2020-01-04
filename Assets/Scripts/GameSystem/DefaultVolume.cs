using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DefaultVolume : MonoBehaviour
{
    public static DefaultVolume Instance;
    private Volume _volBaseComponent;
    private Volume _volQualityComponent;
    private VolumeHolder _volHolder;
    
    private void OnEnable()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        if (!Instance)
            Instance = this;
        gameObject.hideFlags = HideFlags.HideAndDontSave;
        if(!_volBaseComponent)
            _volBaseComponent = gameObject.AddComponent<Volume>();
        _volBaseComponent.priority = -100;
        if(!_volQualityComponent)
            _volQualityComponent = gameObject.AddComponent<Volume>();
        _volQualityComponent.priority = 100;
        if(!_volHolder)
            _volHolder = Resources.Load<VolumeHolder>("VolumeHolder");

        UpdateVolume();
    }

    public void UpdateVolume()
    {
        if (_volHolder)
        {
            //Setup Base Vol if needed
            var baseVolIndex = _volHolder.GetValue(0);
            if (baseVolIndex >= 0)
            {
                var vol = _volHolder._Volumes[baseVolIndex];
                _volBaseComponent.sharedProfile = vol;
            }
            else
            {
                _volBaseComponent.sharedProfile = null;
            }

            //Setup Quality Vol if needed
            var qualityVolIndex = _volHolder.GetValue(QualitySettings.GetQualityLevel() + 1);
            if (qualityVolIndex >= 0)
            {
                var vol = _volHolder._Volumes[qualityVolIndex];
                _volQualityComponent.sharedProfile = vol;
            }
            else
            {
                _volQualityComponent.sharedProfile = null;
            }
        }

        if (UniversalRenderPipeline.asset.debugLevel == PipelineDebugLevel.Disabled) return;
        if (_volBaseComponent.sharedProfile != null && _volQualityComponent.sharedProfile != null)
        {
            Debug.Log(message: $"Updated volumes:\n" +
                               $"    Base Volume : {_volBaseComponent.sharedProfile.name}\n" +
                               $"    Quality Volume : {_volQualityComponent.sharedProfile.name}\n" +
                               $"Total Volume Stack is now:\n");
        }
    }
}

#if UNITY_EDITOR
[InitializeOnLoad]
public class StartupVolume
{
    private const string GoName = "[Volume Manager]";

    static StartupVolume()
    {
        var obj = GameObject.Find(GoName)?.GetComponent<DefaultVolume>();
        if (obj != null)
        {
            return;
        }

        var go = new GameObject { name = GoName };
        go.AddComponent<DefaultVolume>();
    }
}
#endif