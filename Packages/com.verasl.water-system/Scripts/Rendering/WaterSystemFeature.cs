using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterSystemFeature : ScriptableRendererFeature
{

    #region Water Effects Pass

    public class WaterFXPass : ScriptableRenderPass
    {
        const string k_RenderWaterFXTag = "Render Water FX";
        public bool debug;
        ShaderTagId m_WaterFXShaderTag = new ShaderTagId("WaterFX");
        Color m_ClearColor = new Color(0.0f, 0.5f, 0.5f, 0.5f);
        RenderTargetHandle m_WaterFX = RenderTargetHandle.CameraTarget;

        private FilteringSettings transparentFilterSettings { get; set; }

        public WaterFXPass()
        {
            m_WaterFX.Init("_WaterFXMap");
            transparentFilterSettings = new FilteringSettings(RenderQueueRange.transparent);
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            cameraTextureDescriptor.depthBufferBits = 0;
            cameraTextureDescriptor.width = cameraTextureDescriptor.width / 2;
            cameraTextureDescriptor.height = cameraTextureDescriptor.height / 2;
            cameraTextureDescriptor.colorFormat = RenderTextureFormat.Default;
            cmd.GetTemporaryRT(m_WaterFX.id, cameraTextureDescriptor, FilterMode.Bilinear);
            ConfigureTarget(m_WaterFX.Identifier());
            ConfigureClear(ClearFlag.Color, m_ClearColor);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterFXTag);

            using (new ProfilingSample(cmd, k_RenderWaterFXTag))
            {
                context.ExecuteCommandBuffer(cmd);
                cmd.Clear();

                var drawSettings = CreateDrawingSettings(m_WaterFXShaderTag, ref renderingData, SortingCriteria.CommonTransparent);
                var filteringSettings = transparentFilterSettings;

                context.DrawRenderers(renderingData.cullResults, ref drawSettings, ref filteringSettings);
            }
            
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void FrameCleanup(CommandBuffer cmd)
        {
            if(!debug)
                cmd.ReleaseTemporaryRT(m_WaterFX.id);
        }
    }

    #endregion

    #region Caustics Pass
    
    public class WaterCausticsPass : ScriptableRenderPass
    {
        const string k_RenderWaterCausticsTag = "Render Water Caustics";
        public Material m_WaterCausticMaterial;
        public Mesh m_mesh;

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (m_WaterCausticMaterial == null || m_mesh == null)
            {
                Debug.LogErrorFormat(
                    "Missing caustic material. {0} render pass will not execute. Check for missing reference in the renderer resources.",
                    GetType().Name);
                return;
            }

            var camType = renderingData.cameraData.camera.cameraType;
            if(camType != CameraType.Game && camType != CameraType.SceneView)
                return;

            Vector3 position = renderingData.cameraData.camera.transform.position;
            position.y = 0;
            Matrix4x4 matrix = Matrix4x4.TRS(position, Quaternion.identity, Vector3.one * 100f);

            CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterCausticsTag);
            cmd.DrawMesh(m_mesh, matrix	, m_WaterCausticMaterial, 0, 0);
            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }
    }
    
    #endregion


    WaterFXPass m_WaterFxPass;
    WaterCausticsPass m_CausticsPass;

    public WaterSystemSettings settings = new WaterSystemSettings();
    
    public override void Create()
    {
        // WaterFX Pass
        m_WaterFxPass = new WaterFXPass();
        m_WaterFxPass.renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;

        // Caustic Pass
        m_CausticsPass = new WaterCausticsPass();
        if (settings.debug == WaterSystemSettings.DebugMode.Caustics && settings.causticMaterial)
        {
            settings.causticMaterial.SetFloat("_SrcBlend", 1f);
            settings.causticMaterial.SetFloat("_DstBlend", 0f);
            settings.causticMaterial.EnableKeyword("_DEBUG");
            m_CausticsPass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
        }
        else
        {
            settings.causticMaterial.SetFloat("_SrcBlend", 2f);
            settings.causticMaterial.SetFloat("_DstBlend", 0f);
            settings.causticMaterial.DisableKeyword("_DEBUG");
            m_CausticsPass.renderPassEvent = RenderPassEvent.AfterRenderingSkybox + 1;
        }
        m_CausticsPass.m_WaterCausticMaterial = settings.causticMaterial;
        m_CausticsPass.m_mesh = settings.mesh;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_WaterFxPass);
        renderer.EnqueuePass(m_CausticsPass);
    }
    
    [System.Serializable]
    public class WaterSystemSettings
    {
        [Header("Water Effects Settings")]
        
        [Header("Caustics Settings")]
        public Material causticMaterial;
        public Mesh mesh;
        [Header("Advanced Settings")]
        public DebugMode debug = DebugMode.Disabled;

        public enum DebugMode
        {
            Disabled,
            WaterEffects,
            Caustics
        }
    }
}


