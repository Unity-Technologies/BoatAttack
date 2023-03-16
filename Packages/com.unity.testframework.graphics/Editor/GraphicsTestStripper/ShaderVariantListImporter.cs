using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor.ProjectWindowCallback;
using UnityEditor.Rendering;
using UnityEngine.TestTools.Graphics;

namespace UnityEditor.TestTools.Graphics
{
#if UNITY_2020_2_OR_NEWER
    [ScriptedImporter(1, "shadervariantlist")]
    public class ShaderVariantListImporter : ScriptedImporter
    {
        [MenuItem("Assets/Create/Testing/Shader Variant List", false, 1)]
        public static void CreateEmptyShaderVariantList()
        {
            AssetDatabase.Refresh();
            var action = ScriptableObject.CreateInstance< CreateShaderVariantListAsset >();
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, action, "variants.shadervariantlist", null, null);
        }
        
        class CreateShaderVariantListAsset : EndNameEditAction
        {
            public override void Action(int instanceId, string pathName, string resourceFile)
            {
                File.WriteAllText(pathName, JsonUtility.ToJson(new ShaderVariantList.Settings()));
                AssetDatabase.ImportAsset(pathName);
            }
        }
    
        public override void OnImportAsset(AssetImportContext ctx)
        {
            // Example of the log we try to parse:
            // Compiled shader: Custom/MyTestShader, pass: MyTestShader/Pass, stage: vertex, keywords <no keywords>
            // Compiled compute shader: ProbeVolumeBlendStates, kernel: BlendScenarios, keywords 
            // Original format: "Compiled shader: %s, pass: %s, stage: %s, keywords %s\n", shaderName, passName, stageDesc, keywordNames
            // "Compiled compute shader: %s, kernel: %s, keywords %s\n", Name, kernelName, keywordNames);

            var shaderVariantListAsset = ScriptableObject.CreateInstance<ShaderVariantList>();

            string[] compiledShaderLines;
            try
            {
                compiledShaderLines = File.ReadAllLines(ctx.assetPath);
            }
            catch (Exception)
            {
                // When the file was just created, unity can't read it but that's not an issue since it's empty anyway
                compiledShaderLines = Array.Empty<string>();
            }

            // We use the first line to store file settings in JSON:
            var settings = new ShaderVariantList.Settings();
            try
            {
                JsonUtility.FromJsonOverwrite(compiledShaderLines[0], settings);
            }
            catch (Exception) { }

            shaderVariantListAsset.settings = settings;

            shaderVariantListAsset.serializedShaderVariants.Clear();
            foreach (var line in compiledShaderLines)
            {
                var matchCompiledShader = GenerateShaderVariantList.s_CompiledShaderRegex.Match(line);
                if (matchCompiledShader.Success)
                {
                    var serializedVariant = new ShaderVariantList.SerializedShaderVariant();
                    try
                    {
                        serializedVariant.shaderName = matchCompiledShader.Groups["shaderName"].Value;
                        string passName = matchCompiledShader.Groups["passName"].Value;
                        if (passName.StartsWith("<Unnamed Pass"))
                            passName = "";
                        serializedVariant.passName = passName;
                        var keywords = matchCompiledShader.Groups["keywords"].Value;
                        if (keywords == GenerateShaderVariantList.s_NoKeywordText)
                            serializedVariant.keywords = new List<string>();
                        else
                            serializedVariant.keywords = keywords.Split(' ').ToList();

                        var stage = matchCompiledShader.Groups["stage"].Value;
                        if (stage == "all")
                        {
                            shaderVariantListAsset.serializedShaderVariants.AddRange(
                                GenerateAllStageForVariant(serializedVariant));
                        }
                        else
                        {
                            serializedVariant.stage = ParseShaderType(stage);
                            shaderVariantListAsset.serializedShaderVariants.Add(serializedVariant);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log($"Unable to parse line {line}:");
                        Debug.LogException(e);
                    }
                }

                var matchCompiledComputeShader = GenerateShaderVariantList.s_CompiledComputeShaderRegex.Match(line);
                if (matchCompiledComputeShader.Success)
                {
                    var serializedComputeVariant = new ShaderVariantList.SerializedComputeShaderVariant();
                    try
                    {
                        serializedComputeVariant.computeShaderName =
                            matchCompiledComputeShader.Groups["computeName"].Value;
                        serializedComputeVariant.kernelName = matchCompiledComputeShader.Groups["kernelName"].Value;
                        var keywords = matchCompiledComputeShader.Groups["keywords"].Value;
                        if (keywords == GenerateShaderVariantList.s_NoKeywordText)
                            serializedComputeVariant.keywords = new List<string>();
                        else
                            serializedComputeVariant.keywords = keywords.Split(' ').ToList();
                        shaderVariantListAsset.serializedComputeShaderVariants.Add(serializedComputeVariant);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError($"Unable to parse line {line}:");
                        Debug.LogException(e);
                    }
                }
            }

            ShaderType ParseShaderType(string stage)
            {
                switch (stage)
                {
                    case "vertex":
                        return ShaderType.Vertex;
                    case "pixel":
                    case "fragment":
                        return ShaderType.Fragment;
                    case "geometry":
                        return ShaderType.Geometry;
                    case "hull":
                        return ShaderType.Hull;
                    case "domain":
                        return ShaderType.Domain;
                    case "raytracing":
                        return ShaderType.Surface; // For some reason raytracing shader end-up being marked as Surface Shader Type during the stripping
                    default:
                        throw new Exception("Unhandled shader stage: " + stage);
                }
            }

            ctx.AddObjectToAsset("Variants List", shaderVariantListAsset);
            ctx.SetMainObject(shaderVariantListAsset);
        }

        IEnumerable<ShaderVariantList.SerializedShaderVariant> GenerateAllStageForVariant(
            ShaderVariantList.SerializedShaderVariant variant)
        {
            foreach (ShaderType stage in Enum.GetValues(typeof(ShaderType)))
            {
                variant.stage = stage;
                yield return variant;
            }
        }
    }
#endif
}