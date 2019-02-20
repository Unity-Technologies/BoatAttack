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

        public RenderRes maxRenderSize = RenderRes._720p;

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
            
            LightweightRenderPipeline.asset.renderScale = renderScale;
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
    }
}
