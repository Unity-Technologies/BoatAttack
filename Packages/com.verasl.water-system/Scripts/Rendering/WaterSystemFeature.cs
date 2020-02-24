using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace WaterSystem
{
    public class WaterSystemFeature : ScriptableRendererFeature
    {

        #region Water Effects Pass

        class WaterFxPass : ScriptableRenderPass
        {
            private const string k_RenderWaterFXTag = "Render Water FX";
            private ProfilingSampler m_WaterFX_Profile = new ProfilingSampler(k_RenderWaterFXTag);
            private readonly ShaderTagId m_WaterFXShaderTag = new ShaderTagId("WaterFX");
            private readonly Color m_ClearColor = new Color(0.0f, 0.5f, 0.5f, 0.5f); //r = foam mask, g = normal.x, b = normal.z, a = displacement
            private FilteringSettings m_FilteringSettings;
            private RenderTargetHandle m_WaterFX = RenderTargetHandle.CameraTarget;

            public WaterFxPass()
            {
                m_WaterFX.Init("_WaterFXMap");
                // only wanting to render transparent objects
                m_FilteringSettings = new FilteringSettings(RenderQueueRange.transparent);
            }

            // Calling Configure since we are wanting to render into a RenderTexture and control cleat
            public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
            {
                // no need for a depth buffer
                cameraTextureDescriptor.depthBufferBits = 0;
                // Half resolution
                cameraTextureDescriptor.width /= 2;
                cameraTextureDescriptor.height /= 2;
                // default format TODO research usefulness of HDR format
                cameraTextureDescriptor.colorFormat = RenderTextureFormat.Default;
                // get a temp RT for rendering into
                cmd.GetTemporaryRT(m_WaterFX.id, cameraTextureDescriptor, FilterMode.Bilinear);
                ConfigureTarget(m_WaterFX.Identifier());
                // clear the screen with a specific color for the packed data
                ConfigureClear(ClearFlag.Color, m_ClearColor);
            }

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterFXTag);
                using (new ProfilingScope(cmd, m_WaterFX_Profile)) // makes sure we have profiling ability
                {
                    context.ExecuteCommandBuffer(cmd);
                    cmd.Clear();

                    // here we choose renderers based off the "WaterFX" shader pass and also sort back to front
                    var drawSettings = CreateDrawingSettings(m_WaterFXShaderTag, ref renderingData,
                        SortingCriteria.CommonTransparent);

                    // draw all the renderers matching the rules we setup
                    context.DrawRenderers(renderingData.cullResults, ref drawSettings, ref m_FilteringSettings);
                }
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }

            public override void FrameCleanup(CommandBuffer cmd)
            {
                // since the texture is used within the single cameras use we need to cleanup the RT afterwards
                cmd.ReleaseTemporaryRT(m_WaterFX.id);
            }
        }

        #endregion

        #region Caustics Pass

        class WaterCausticsPass : ScriptableRenderPass
        {
            private const string k_RenderWaterCausticsTag = "Render Water Caustics";
            private ProfilingSampler m_WaterCaustics_Profile = new ProfilingSampler(k_RenderWaterCausticsTag);
            public Material WaterCausticMaterial;
            private static Mesh m_mesh;

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                var cam = renderingData.cameraData.camera;
                // Stop the pass rendering in the preview or material missing
                if (cam.cameraType == CameraType.Preview || !WaterCausticMaterial)
                    return;

                CommandBuffer cmd = CommandBufferPool.Get(k_RenderWaterCausticsTag);
                using (new ProfilingScope(cmd, m_WaterCaustics_Profile))
                {
                    // Create mesh if needed
                    if (!m_mesh)
                        m_mesh = GenerateCausticsMesh(1000f);

                    // Create the matrix to position the caustics mesh.
                    var position = cam.transform.position;
                    position.y = 0; // TODO should read a global 'water height' variable.
                    var matrix = Matrix4x4.TRS(position, Quaternion.identity, Vector3.one);

                    // Setup the CommandBuffer and draw the mesh with the caustic material and matrix
                    cmd.DrawMesh(m_mesh, matrix, WaterCausticMaterial, 0, 0);
                }

                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }
        }

        #endregion

        WaterFxPass m_WaterFxPass;
        WaterCausticsPass m_CausticsPass;

        public WaterSystemSettings settings = new WaterSystemSettings();
        [SerializeField] private Shader causticShader;

        private Material _causticMaterial;

        private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
        private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
        private static readonly int Size = Shader.PropertyToID("_Size");

        public override void Create()
        {
            // WaterFX Pass
            m_WaterFxPass = new WaterFxPass {renderPassEvent = RenderPassEvent.BeforeRenderingOpaques};

            // Caustic Pass
            m_CausticsPass = new WaterCausticsPass();

            causticShader = causticShader ? causticShader : Shader.Find("Hidden/BoatAttack/Caustics");
            if (causticShader == null) return;
            _causticMaterial = _causticMaterial ? _causticMaterial : new Material(causticShader);

            switch (settings.debug)
            {
                case WaterSystemSettings.DebugMode.Caustics:
                    _causticMaterial.SetFloat(SrcBlend, 1f);
                    _causticMaterial.SetFloat(DstBlend, 0f);
                    _causticMaterial.EnableKeyword("_DEBUG");
                    m_CausticsPass.renderPassEvent = RenderPassEvent.AfterRenderingPostProcessing;
                    break;
                case WaterSystemSettings.DebugMode.WaterEffects:
                    break;
                case WaterSystemSettings.DebugMode.Disabled:
                    // Caustics
                    _causticMaterial.SetFloat(SrcBlend, 2f);
                    _causticMaterial.SetFloat(DstBlend, 0f);
                    _causticMaterial.DisableKeyword("_DEBUG");
                    m_CausticsPass.renderPassEvent = RenderPassEvent.AfterRenderingSkybox + 1;
                    // WaterEffects
                    break;
            }

            _causticMaterial.SetFloat(Size, settings.causticScale);
            m_CausticsPass.WaterCausticMaterial = _causticMaterial;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(m_WaterFxPass);
            if(_causticMaterial == null)
                renderer.EnqueuePass(m_CausticsPass);
        }

        /// <summary>
        /// This function Generates a flat quad for use with the caustics pass.
        /// </summary>
        /// <param name="size">The length of the quad.</param>
        /// <returns></returns>
        private static Mesh GenerateCausticsMesh(float size)
        {
            var m = new Mesh();
            size *= 0.5f;

            var verts = new[]
            {
                new Vector3(-size, 0f, -size),
                new Vector3(size, 0f, -size),
                new Vector3(-size, 0f, size),
                new Vector3(size, 0f, size)
            };
            m.vertices = verts;

            var tris = new[]
            {
                0, 2, 1,
                2, 3, 1
            };
            m.triangles = tris;

            return m;
        }

        [System.Serializable]
        public class WaterSystemSettings
        {
            [Header("Caustics Settings")] [Range(0.1f, 1f)]
            public float causticScale = 0.25f;

            [Header("Advanced Settings")] public DebugMode debug = DebugMode.Disabled;

            public enum DebugMode
            {
                Disabled,
                WaterEffects,
                Caustics
            }
        }
    }
}