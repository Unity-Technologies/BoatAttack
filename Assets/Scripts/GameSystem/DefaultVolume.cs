using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DefaultVolume : MonoBehaviour
{
    public static DefaultVolume instance;
    private Volume volBaseComponent;
    private Volume volQualityComponent;
    private VolumeHolder volHolder;
    
    private void OnEnable()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        if (!instance)
            instance = this;
        gameObject.hideFlags = HideFlags.HideAndDontSave;
        if(!volBaseComponent)
            volBaseComponent = gameObject.AddComponent<Volume>();
        volBaseComponent.priority = -100;
        if(!volQualityComponent)
            volQualityComponent = gameObject.AddComponent<Volume>();
        volQualityComponent.priority = 100;
        if(!volHolder)
            volHolder = Resources.Load<VolumeHolder>("VolumeHolder");

        UpdateVolume();
    }

    public void UpdateVolume()
    {
        if (volHolder)
        {
            //Setup Base Vol if needed
            var baseVolIndex = volHolder.GetValue(0);
            if (baseVolIndex >= 0)
            {
                var vol = volHolder._Volumes[baseVolIndex];
                volBaseComponent.sharedProfile = vol;
            }
            else
            {
                volBaseComponent.sharedProfile = null;
            }

            //Setup Quality Vol if needed
            var qualityVolIndex = volHolder.GetValue(QualitySettings.GetQualityLevel() + 1);
            if (qualityVolIndex >= 0)
            {
                var vol = volHolder._Volumes[qualityVolIndex];
                volQualityComponent.sharedProfile = vol;
            }
            else
            {
                volQualityComponent.sharedProfile = null;
            }
        }

        if (UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
        {
            string vols = "";
            foreach (var vol in VolumeManager.instance.stack.components)
            {
                vols += $"{vol.Key.Name}\n";
            }
            Debug.Log($"Updated volumes:\n" +
                      $"    Base Volume : {volBaseComponent.sharedProfile?.name}\n" +
                      $"    Quality Volume : {volQualityComponent.sharedProfile?.name}\n" +
                      $"Total Volume Stack is now:\n" +
                      $"{vols}");
        }
    }
}

#if UNITY_EDITOR
[InitializeOnLoad]
public class StartupVolume
{
    private const string goName = "[Volume Manager]";

    static StartupVolume()
    {
        var obj = GameObject.Find(goName)?.GetComponent<DefaultVolume>();
        if (obj != null)
        {
            return;
        }

        var go = new GameObject { name = goName };
        var volMan = go.AddComponent<DefaultVolume>();
        obj = volMan;
    }
}
#endif