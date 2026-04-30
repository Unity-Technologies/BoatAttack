using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;

namespace WaterSystem
{
    public class WaterSystemFeature : ScriptableRendererFeature
    {

        #region Water Effects Pass

        class WaterFxPass : ScriptableRenderPass
        {
            private const string k_RenderWaterFXTag = "Render Water FX";
            private readonly ShaderTagId m_WaterFXShaderTag = new ShaderTagId("WaterFX");
            private readonly Color m_ClearColor = new Color(0.0f, 0.5f, 0.5f, 0.5f); //r = foam mask, g = normal.x, b = normal.z, a = displacement
            private static readonly int s_WaterFXMap = Shader.PropertyToID("_WaterFXMap");
            private RTHandle m_WaterFX;

            private class PassData
            {
                public RendererListHandle rendererList;
                public Color clearColor;
            }

            public WaterFxPass()
            {
                renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;
            }

            public void Dispose()
            {
                m_WaterFX?.Release();
                m_WaterFX = null;
            }

            public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
            {
                var cameraData = frameData.Get<UniversalCameraData>();
                var resourceData = frameData.Get<UniversalResourceData>();

                // Skip on depth-only / offscreen cameras that have no active colour attachment
                // (e.g. WaterSystem's CaptureDepthMap camera).
                if (!resourceData.activeColorTexture.IsValid())
                    return;

                var renderingData = frameData.Get<UniversalRenderingData>();
                var lightData = frameData.Get<UniversalLightData>();

                // Build a half-res, depth-free descriptor for the water FX map
                var desc = cameraData.cameraTargetDescriptor;
                desc.depthBufferBits = 0;
                desc.msaaSamples = 1;
                desc.width /= 2;
                desc.height /= 2;
                desc.colorFormat = RenderTextureFormat.Default;

                // Allocate (or re-use) a persistent RTHandle, then import into the render graph
                RenderingUtils.ReAllocateIfNeeded(ref m_WaterFX, in desc, FilterMode.Bilinear,
                    TextureWrapMode.Clamp, false, 1, 0f, "_WaterFXMap");
                TextureHandle waterFXHandle = renderGraph.ImportTexture(m_WaterFX);

                using (var builder = renderGraph.AddRasterRenderPass<PassData>(k_RenderWaterFXTag, out var passData))
                {
                    // Build the renderer list for all objects that use the "WaterFX" pass
                    passData.rendererList = renderGraph.CreateRendererList(
                        new RendererListDesc(m_WaterFXShaderTag, renderingData.cullResults, cameraData.camera)
                        {
                            sortingCriteria = SortingCriteria.CommonTransparent,
                            renderQueueRange = RenderQueueRange.transparent,
                        });
                    passData.clearColor = m_ClearColor;

                    builder.SetRenderAttachment(waterFXHandle, 0, AccessFlags.Write);
                    builder.UseRendererList(passData.rendererList);
                    builder.SetGlobalTextureAfterPass(waterFXHandle, s_WaterFXMap);
                    builder.AllowPassCulling(false);

                    builder.SetRenderFunc(static (PassData data, RasterGraphContext context) =>
                    {
                        context.cmd.ClearRenderTarget(false, true, data.clearColor);
                        context.cmd.DrawRendererList(data.rendererList);
                    });
                }
            }
        }

        #endregion

        #region Caustics Pass

        class WaterCausticsPass : ScriptableRenderPass
        {
            private const string k_RenderWaterCausticsTag = "Render Water Caustics";
            public Material WaterCausticMaterial;
            private static Mesh m_mesh;

            private class PassData
            {
                public Mesh mesh;
                public Matrix4x4 drawMatrix;
                public Material material;
                public Matrix4x4 sunMatrix;
            }

            public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
            {
                var cameraData = frameData.Get<UniversalCameraData>();
                var cam = cameraData.camera;

                if (cam.cameraType == CameraType.Preview || !WaterCausticMaterial)
                    return;

                var resourceData = frameData.Get<UniversalResourceData>();

                // Skip on depth-only / offscreen cameras with no active colour attachment.
                if (!resourceData.activeColorTexture.IsValid())
                    return;

                if (!m_mesh)
                    m_mesh = GenerateCausticsMesh(1000f);

                var sunMatrix = RenderSettings.sun != null
                    ? RenderSettings.sun.transform.localToWorldMatrix
                    : Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(-45f, 45f, 0f), Vector3.one);

                var position = cam.transform.position;
                position.y = 0; // TODO should read a global 'water height' variable.

                using (var builder = renderGraph.AddRasterRenderPass<PassData>(k_RenderWaterCausticsTag, out var passData))
                {
                    passData.mesh = m_mesh;
                    passData.drawMatrix = Matrix4x4.TRS(position, Quaternion.identity, Vector3.one);
                    passData.material = WaterCausticMaterial;
                    passData.sunMatrix = sunMatrix;

                    builder.SetRenderAttachment(resourceData.activeColorTexture, 0, AccessFlags.Write);
                    builder.AllowPassCulling(false);

                    builder.SetRenderFunc(static (PassData data, RasterGraphContext context) =>
                    {
                        data.material.SetMatrix("_MainLightDir", data.sunMatrix);
                        context.cmd.DrawMesh(data.mesh, data.drawMatrix, data.material, 0, 0);
                    });
                }
            }
        }

        #endregion

        WaterFxPass m_WaterFxPass;
        WaterCausticsPass m_CausticsPass;

        public WaterSystemSettings settings = new WaterSystemSettings();
        [HideInInspector][SerializeField] private Shader causticShader;
        [HideInInspector][SerializeField] private Texture2D causticTexture;

        private Material _causticMaterial;

        private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
        private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
        private static readonly int Size = Shader.PropertyToID("_Size");
        private static readonly int CausticTexture = Shader.PropertyToID("_CausticMap");

        public override void Create()
        {
            m_WaterFxPass = new WaterFxPass();

            m_CausticsPass = new WaterCausticsPass();

            causticShader = causticShader ? causticShader : Shader.Find("Hidden/BoatAttack/Caustics");
            if (causticShader == null) return;
            if (_causticMaterial)
            {
                DestroyImmediate(_causticMaterial);
            }
            _causticMaterial = CoreUtils.CreateEngineMaterial(causticShader);
            _causticMaterial.SetFloat("_BlendDistance", settings.causticBlendDistance);

            if (causticTexture == null)
            {
                Debug.Log("Caustics Texture missing, attempting to load.");
#if UNITY_EDITOR
                causticTexture = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.verasl.water-system/Textures/WaterSurface_single.tif");
#endif
            }
            _causticMaterial.SetTexture(CausticTexture, causticTexture);

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
                    _causticMaterial.SetFloat(SrcBlend, 2f);
                    _causticMaterial.SetFloat(DstBlend, 0f);
                    _causticMaterial.DisableKeyword("_DEBUG");
                    m_CausticsPass.renderPassEvent = RenderPassEvent.AfterRenderingSkybox + 1;
                    break;
            }

            _causticMaterial.SetFloat(Size, settings.causticScale);
            m_CausticsPass.WaterCausticMaterial = _causticMaterial;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(m_WaterFxPass);
            renderer.EnqueuePass(m_CausticsPass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                m_WaterFxPass?.Dispose();
            base.Dispose(disposing);
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

            public float causticBlendDistance = 3f;

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
