using System;
using System.Collections.Generic;
using System.Linq;
using NUnit;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Rendering;
using UnityEngine.TestTools.Graphics;

namespace UnityEditor.TestTools.Graphics
{
    class GraphicsTestShaderStripper : IPreprocessBuildWithReport
    {
        const string k_EnableStripperKey = "GraphicsTestStripperEnabled";

        static readonly List<ShaderVariantList> s_AllVariantListAssets = new List<ShaderVariantList>();
        [NonSerialized] static ShaderVariantList s_CurrentVariantListInUse = null;
        [NonSerialized] private static bool? s_UseGraphicsTestStripper = null;

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            // Reset current variant list in use because we build
            s_CurrentVariantListInUse = null;
        }

        static GraphicsTestShaderStripper()
        {
            s_AllVariantListAssets.Clear();
            var shaderVariantListGUIDs =
                AssetDatabase.FindAssets("t:ShaderVariantList", new[] { "Assets", "Packages" });
            foreach (var guid in shaderVariantListGUIDs)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var svl = AssetDatabase.LoadAssetAtPath<ShaderVariantList>(path);
                if (svl != null && svl.settings.enabled)
                    s_AllVariantListAssets.Add(svl);
            }
        }

#if UNITY_EDITOR
        [MenuItem("Tests/Graphics Test Stripper Mode/Enabled")]
        static void EnableGraphicsTestStripper() => EnableGraphicsTestStripper(true);
        [MenuItem("Tests/Graphics Test Stripper Mode/Disabled")]
        static void DisableGraphicsTestStripper() => EnableGraphicsTestStripper(false);

        [MenuItem("Tests/Graphics Test Stripper Mode/Enabled", true)]
        static bool EnableGraphicsTestStripperValidate() => !EditorPrefs.GetBool(k_EnableStripperKey, true);
        [MenuItem("Tests/Graphics Test Stripper Mode/Disabled", true)]
        static bool DisableGraphicsTestStripperValidate() => EditorPrefs.GetBool(k_EnableStripperKey, true);
        static void EnableGraphicsTestStripper(bool enabled)
        {
            EditorPrefs.SetBool(k_EnableStripperKey, enabled);
            string message;
            if (enabled)
            {
                message = "Shader Stripper Enabled!";
                Debug.Log($"<color=green>{message}</color>");
            }
            else
            {
                message = "Shader Stripper Disabled!";
                Debug.Log($"<color=red>{message}</color>");
            }

            foreach (SceneView scene in SceneView.sceneViews)
                scene.ShowNotification(new GUIContent(message));
        }
#endif

        static ShaderVariantList GetCurrentShaderVariantList()
        {
            // Check if Graphic test stripper is enable
            if (!EditorPrefs.GetBool(k_EnableStripperKey, true)) // Disable stripper by default
                return null;
            if (s_UseGraphicsTestStripper == null)
            {
                var useGfxTestStripper = Environment.GetEnvironmentVariable(GenerateShaderVariantList.k_UseGraphicsTestStripperEnv);
                s_UseGraphicsTestStripper = useGfxTestStripper == null || useGfxTestStripper.ToLower() == "true";
            }

            if (!s_UseGraphicsTestStripper.Value)
                return null;

            if (s_CurrentVariantListInUse == null)
            {
                var currentAPI = GetCurrentGraphicsAPI();
                var matchingVariant = s_AllVariantListAssets.FirstOrDefault(s => s.MatchSettings(currentAPI, RuntimeSettings.reuseTestsForXR));

                if (matchingVariant == null)
                {
                    matchingVariant = s_AllVariantListAssets.FirstOrDefault(s => s.MatchSettings(ShaderCompilerPlatform.D3D, false));
                    Debug.Log($"Couldn't find the Shader Variant List for the Graphics API {currentAPI}{(RuntimeSettings.reuseTestsForXR ? " in XR" : "")}. Falling back on the D3D platform file");
                }

                if (matchingVariant == null)
                {
                    Debug.Log("Couldn't find any Shader Variant List for this config, disabling Graphics Test Stripper");
                    s_UseGraphicsTestStripper = false;
                }
                s_CurrentVariantListInUse = matchingVariant;
            }

            return s_CurrentVariantListInUse;
        }

        static ShaderCompilerPlatform GetCurrentGraphicsAPI()
        {
            GraphicsDeviceType currentAPI;
            if (BuildPipeline
                .isBuildingPlayer) // In the editor we use the current graphics device instead of the list to avoid blocking the rendering if an invalid API is added but not enabled.
                currentAPI = PlayerSettings.GetGraphicsAPIs(EditorUserBuildSettings.activeBuildTarget).First();
            else
                currentAPI = SystemInfo.graphicsDeviceType;

            return GraphicsDeviceTypeToShaderCompilerPlatform(currentAPI);
        }

        static ShaderCompilerPlatform GraphicsDeviceTypeToShaderCompilerPlatform(GraphicsDeviceType type)
        {
            switch (type)
            {
                case GraphicsDeviceType.Direct3D11: return ShaderCompilerPlatform.D3D;
                case GraphicsDeviceType.OpenGLES3: return ShaderCompilerPlatform.GLES3x;
                case (GraphicsDeviceType)13: return (ShaderCompilerPlatform)11;
                case GraphicsDeviceType.XboxOne: return ShaderCompilerPlatform.XboxOneD3D11;
                case GraphicsDeviceType.Metal: return ShaderCompilerPlatform.Metal;
                case GraphicsDeviceType.OpenGLCore: return ShaderCompilerPlatform.OpenGLCore;
                case GraphicsDeviceType.Direct3D12: return ShaderCompilerPlatform.D3D;
                case GraphicsDeviceType.Vulkan: return ShaderCompilerPlatform.Vulkan;
                case GraphicsDeviceType.WebGPU: return ShaderCompilerPlatform.WebGPU;
                case (GraphicsDeviceType)22: return (ShaderCompilerPlatform)19;
                case GraphicsDeviceType.XboxOneD3D12: return ShaderCompilerPlatform.XboxOneD3D12;
#if UNITY_2022_2_OR_NEWER
                case GraphicsDeviceType.GameCoreXboxOne: return ShaderCompilerPlatform.GameCoreXboxOne;
                case GraphicsDeviceType.GameCoreXboxSeries: return ShaderCompilerPlatform.GameCoreXboxSeries;
#else
                case GraphicsDeviceType.GameCoreXboxOne: return ShaderCompilerPlatform.GameCore;
                case GraphicsDeviceType.GameCoreXboxSeries: return ShaderCompilerPlatform.GameCore;
#endif
                case (GraphicsDeviceType)26: return (ShaderCompilerPlatform)23;
                case (GraphicsDeviceType)27: return (ShaderCompilerPlatform)24;
                default: throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public class ShaderPreProcessor : IPreprocessShaders
        {
            public int callbackOrder => Int32.MinValue;

            public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
            {
                var currentVariantList = GetCurrentShaderVariantList();
                if (currentVariantList == null)
                    return;

                // When the shader is not in the list we can just remove the whole shader
                if (!currentVariantList.variantListPerShader.TryGetValue(shader.name, out var variantList))
                {
                    data.Clear();
                    return;
                }

                // If the pass and stage doesn't exist in the list we can also remove the whole shader snippet
                if (!variantList.TryGetValue((snippet.shaderType, snippet.passName), out var keywordSetList))
                {
                    data.Clear();
                    return;
                }

                for (int i = 0; i < data.Count; i++)
                {
                    if (!MatchKeywordSet(data[i].shaderKeywordSet, keywordSetList))
                    {
                        data.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

#if UNITY_2020_2_OR_NEWER
        class GraphicsTestComputeShaderStripper : IPreprocessComputeShaders
        {
            public int callbackOrder => Int32.MinValue;

            public void OnProcessComputeShader(ComputeShader shader, string kernelName, IList<ShaderCompilerData> data)
            {
                var currentVariantList = GetCurrentShaderVariantList();

                // In case the compute shader variant list is 0, either the project doesn't have compute (so this code is not called)
                // Or there is compute but the shader variant list was generated from SVC, in this case we skip the compute stripping
                // To add back the compute variants you just need to aggregate the log result of a run.
                if (currentVariantList == null || currentVariantList.variantListPerComputeShader.Count == 0)
                    return;

                // When the shader is not in the list we can just remove the whole shader
                if (!currentVariantList.variantListPerComputeShader.TryGetValue(shader.name, out var variantList))
                {
                    data.Clear();
                    return;
                }

                // If the pass and stage doesn't exist in the list we can also remove the whole shader snippet
                if (!variantList.TryGetValue(kernelName, out var keywordSetList))
                {
                    data.Clear();
                    return;
                }

                for (int i = 0; i < data.Count; i++)
                {
                    if (!MatchKeywordSet(data[i].shaderKeywordSet, keywordSetList))
                    {
                        data.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
#endif
        
        static bool MatchKeywordSet(ShaderKeywordSet variantKeywordSet,
            List<ShaderVariantList.KeywordSet> keywordSetList)
        {
            var variantKeywords = variantKeywordSet.GetShaderKeywords();

            foreach (var keywordSet in keywordSetList)
            {
                if (variantKeywords.Length != keywordSet.Count)
                    continue;

                bool matching = true;
                foreach (var keyword in keywordSet)
                {
                    if (!variantKeywordSet.IsEnabled(keyword))
                    {
                        matching = false;
                        break;
                    }
                }

                if (matching)
                    return true;
            }

            return false;
        }
    }
}