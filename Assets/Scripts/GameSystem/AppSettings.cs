using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;

namespace BoatAttack
{
    public class AppSettings : MonoBehaviour
    {
        public enum RenderRes
        {
            _Native,
            _2440p,
            _1080p,
            _720p
        }

        public enum Framerate
        {
            _30,
            _60,
            _120
        }

        public RenderRes maxRenderSize = RenderRes._720p;
        public bool variableResolution = false;
        [Range(0f, 1f)]
        public float axisBias = 0.5f;
        public float minScale = 0.5f;
        public Framerate targetFramerate = Framerate._30;
        private float currentDynamicScale = 1.0f;
        private float maxScale = 1.0f;

        public Material seaMat;

        private Shader seaShader;
        // Use this for initialization
        void Start()
        {
            Application.targetFrameRate = 300;

            float res;
            
            switch (maxRenderSize)
            {
                case RenderRes._720p:
                    res = 720f;
                    break;
                case RenderRes._1080p:
                    res = 1080f;
                    break;
                case RenderRes._2440p:
                    res = 2440f;
                    break;
                default:
                    res = Camera.main.pixelHeight;
                    break;
            }
            var renderScale = Mathf.Clamp(res / Camera.main.pixelHeight, 0.1f, 1.0f);
            maxScale = renderScale;
            LightweightRenderPipeline.asset.renderScale = renderScale;
        }

        private void Update()
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

                currentDynamicScale = Mathf.Clamp(currentFrametime + offset, minScale, 1f);
                
                var offsetVec = new Vector2(Mathf.Lerp(1, currentDynamicScale, Mathf.Clamp01((1 - axisBias) * 2f)),
                    Mathf.Lerp(1, currentDynamicScale, Mathf.Clamp01(axisBias * 2f)));

                ScalableBufferManager.ResizeBuffers(offsetVec.x, offsetVec.y);
            }
            else
            {
                Camera.main.allowDynamicResolution = false;
            }
        }

        public void ToggleWaterShader(bool detailed)
        {
            if (detailed == false)
            {
                seaShader = seaMat.shader;
                seaMat.shader = Shader.Find("Unlit/Color");
            }
            else
            {
                seaMat.shader = seaShader;
            }
        }
        
        public void ToggleSRPBatcher(bool enabled)
        {
            LightweightRenderPipeline.asset.useSRPBatcher = enabled;
        }
    }
}
