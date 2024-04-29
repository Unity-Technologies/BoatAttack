using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

//[DisallowMultipleRendererFeature] // once not internal, this needs to be here
public class GlobalVolumeFeature : ScriptableRendererFeature
{
    class GlobalVolumePass : ScriptableRenderPass
    {
        public VolumeProfile _baseProfile;
        public List<VolumeProfile> _qualityProfiles;
        public LayerMask _layerMask;

        private Volume vol;
        private Volume qualityVol;
        public static GameObject volumeHolder;

        [ObsoleteAttribute] public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            Setup();
        }
        
        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            Setup();
        }

        public void Setup()
        {
            if(volumeHolder == null)
            {
                volumeHolder = new GameObject("[DefaultVolume]");
                vol = volumeHolder.AddComponent<Volume>();
                vol.isGlobal = true;
                qualityVol = volumeHolder.AddComponent<Volume>();
                qualityVol.isGlobal = true;
                volumeHolder.hideFlags = HideFlags.HideAndDontSave;
            }

            if (vol && _baseProfile)
            {
                vol.sharedProfile = _baseProfile;
            }

            if(qualityVol && _qualityProfiles != null)
            {
                var index = QualitySettings.GetQualityLevel();

                if(_qualityProfiles.Count >= index && _qualityProfiles[index] != null)
                    qualityVol.sharedProfile = _qualityProfiles?[index];
            }
        }

        [ObsoleteAttribute] public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
        }
    }

    GlobalVolumePass m_ScriptablePass;

    public LayerMask _layerMask;
    public VolumeProfile _baseProfile;
    public List<VolumeProfile> _qualityProfiles = new List<VolumeProfile>();

    /// <inheritdoc/>
    public override void Create()
    {
        m_ScriptablePass = new GlobalVolumePass
        {
            // Configures where the render pass should be injected.
            renderPassEvent = RenderPassEvent.AfterRenderingTransparents,
            _baseProfile = this._baseProfile,
            _layerMask = this._layerMask,
            _qualityProfiles = this._qualityProfiles,
        };
    }

    // Here you can inject one or multiple render passes in the renderer.
    // This method is called when setting up the renderer once per-camera.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if(GlobalVolumePass.volumeHolder == null)
        {
            var old = GameObject.Find("[DefaultVolume]");
            if (Application.isPlaying)
            {
                Destroy(old);
            }
            else
            {
                DestroyImmediate(old);
            }
        }
        renderer.EnqueuePass(m_ScriptablePass);
    }
}


