using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
/// <summary>
/// This feature adds a global volume to scene and chooses volume depending on the quality settings; 
/// </summary>
[DisallowMultipleRendererFeature]
public class GlobalVolumeFeature : ScriptableRendererFeature
{
    [SerializeField] public VolumeProfile _baseProfile;
    [SerializeField] public List<VolumeProfile> _qualityProfiles = new List<VolumeProfile>();
    
    private static string k_DefaultVolume = "[DefaultVolume]";
    private static GameObject volumeHolder;
    private Volume vol;
    private Volume qualityVol;

    public override void Create()
    {
        QualitySettings.activeQualityLevelChanged += OnQualitySettingsChange;
        DoVolumeUpdate();
    }

    protected override void Dispose(bool disposing)
    {
        Debug.Log("[GlobalVolumePass] Disposing");
        if (volumeHolder != null)
        {
            if (Application.isPlaying)
            {
                Destroy(volumeHolder);
            }
            else
            {
                DestroyImmediate(volumeHolder);
            }
        }
        QualitySettings.activeQualityLevelChanged -= OnQualitySettingsChange;
        base.Dispose(disposing);
    }

    private void OnQualitySettingsChange(int prev, int curr)
    {
        Debug.Log("quality changed from " + prev + " to " + curr);
        DoVolumeUpdate();
    }
        private void DoVolumeUpdate()
        {
            if(volumeHolder == null)
            {
                //TODO: rm Find once better lifecycle management is in place;
                //cleanup 
                var old = GameObject.Find(k_DefaultVolume);
                if (old)
                {
                    if (Application.isPlaying)
                    {
                        Destroy(old);
                    }
                    else
                    {
                        DestroyImmediate(old);
                    }
                }
                //init
                volumeHolder = new GameObject(k_DefaultVolume);
                vol = volumeHolder.AddComponent<Volume>();
                vol.isGlobal = true;
                qualityVol = volumeHolder.AddComponent<Volume>();
                qualityVol.isGlobal = true;
            }

            if (vol && _baseProfile)
            {
                vol.sharedProfile = _baseProfile;
            }

            if(qualityVol && _qualityProfiles != null)
            {
                var index = QualitySettings.GetQualityLevel();
                if(_qualityProfiles.Count > index && _qualityProfiles[index] != null)
                    qualityVol.sharedProfile = _qualityProfiles?[index];
            }
        }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        //It's not an actual Renderer Pass driven feature; 
    }
}