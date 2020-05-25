using UnityEngine.Rendering.Universal;

namespace UnityEngine.Experimental.Rendering.Universal
{
    public class FullScreenQuad : ScriptableRendererFeature
    {
        [System.Serializable]
        public struct FullScreenQuadSettings
        {
            public RenderPassEvent renderPassEvent;
            public Material material;
        }

        public FullScreenQuadSettings m_Settings;
        FullScreenQuadPass m_RenderQuadPass;

        public override void Create()
        {
            m_RenderQuadPass = new FullScreenQuadPass(m_Settings);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (m_Settings.material != null)
                renderer.EnqueuePass(m_RenderQuadPass);
        }
    }
}
