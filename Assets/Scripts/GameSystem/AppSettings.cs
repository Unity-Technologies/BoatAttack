using System;
using GameplayIngredients;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace BoatAttack
{
    [ExecuteAlways]
    public class AppSettings : Manager
    {
        public enum RenderRes
        {
            _Native,
            _1440p,
            _1080p,
            _720p
        }

        public enum Framerate
        {
            _30,
            _60,
            _120
        }

        [Header("Resolution Settings")]
        public RenderRes maxRenderSize = RenderRes._720p;
        public bool variableResolution = false;
        [Range(0f, 1f)]
        public float axisBias = 0.5f;
        public float minScale = 0.5f;
        public Framerate targetFramerate = Framerate._30;
        private float currentDynamicScale = 1.0f;
        private float maxScale = 1.0f;

        [Header("Quality Level Settings")] 
        public Volume qualityVolume;

        public VolumeProfile[] qualityVolumeProfiles = new VolumeProfile[3];
        private int qualityLevel;
        
        // Use this for initialization
        void OnEnable()
        {
            Initialize();
            RenderPipelineManager.beginCameraRendering += SetRenderScale;
        }

        void Initialize()
        {
            Application.targetFrameRate = 300;
            qualityLevel = QualitySettings.GetQualityLevel();
            qualityVolume.profile = qualityVolumeProfiles[qualityLevel];
        }

        private void Start()
        {
            var obj = GameObject.Find("[Debug Updater]");
            if(obj != null)
                Destroy(obj);
        }

        private void OnDisable()
        {
            RenderPipelineManager.beginCameraRendering -= SetRenderScale;
        }

        void SetRenderScale(ScriptableRenderContext context, Camera camera)
        {
            float res;
            switch (maxRenderSize)
            {
                case RenderRes._720p:
                    res = 1280f;
                    break;
                case RenderRes._1080p:
                    res = 1920f;
                    break;
                case RenderRes._1440p:
                    res = 2560f;
                    break;
                default:
                    res = camera.pixelWidth;
                    break;
            }

            var renderScale = Mathf.Clamp(res / camera.pixelWidth, 0.1f, 1.0f);
            maxScale = renderScale;
            UniversalRenderPipeline.asset.renderScale = renderScale;
        }

        void UpdateQualitySettings(int level)
        {
            qualityLevel = level;
            qualityVolume.profile = qualityVolumeProfiles[level];
        }

        private void Update()
        {
            var level = QualitySettings.GetQualityLevel();
            if(level != qualityLevel)
                UpdateQualitySettings(level);

            if (Camera.main)
            {
                if (variableResolution)
                {
                    Camera.main.allowDynamicResolution = true;

                    var offset = 0f;
                    var currentFrametime = Time.deltaTime;
                    var rate = 0.1f;

                    switch (targetFramerate)
                    {
                        case Framerate._30:
                            offset = currentFrametime > (1000f / 30f) ? -rate : rate;
                            break;
                        case Framerate._60:
                            offset = currentFrametime > (1000f / 30f) ? -rate : rate;
                            break;
                        case Framerate._120:
                            offset = currentFrametime > (1000f / 120f) ? -rate : rate;
                            break;
                    }

                    currentDynamicScale = Mathf.Clamp(currentDynamicScale + offset, minScale, 1f);

                    var offsetVec = new Vector2(Mathf.Lerp(1, currentDynamicScale, Mathf.Clamp01((1 - axisBias) * 2f)),
                        Mathf.Lerp(1, currentDynamicScale, Mathf.Clamp01(axisBias * 2f)));

                    ScalableBufferManager.ResizeBuffers(offsetVec.x, offsetVec.y);
                }
                else
                {
                    Camera.main.allowDynamicResolution = false;
                }
            }
            else
            {
                Debug.LogWarning("No Main Camera found, for Variabel Resolution to work you must have a 'Main Camera'.");
            }
        }

        public void ToggleSRPBatcher(bool enabled)
        {
            UniversalRenderPipeline.asset.useSRPBatcher = enabled;
        }
    }
}
