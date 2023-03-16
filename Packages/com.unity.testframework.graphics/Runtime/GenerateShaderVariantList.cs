using UnityEngine;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.TestTools.Graphics
{
    public static class GenerateShaderVariantList
    {
        public static readonly Regex s_CompiledShaderRegex = new Regex(@"Compiled shader: (?<shaderName>[^,]*), pass: (?<passName>[^,]*), stage: (?<stage>[^,]*), keywords (?<keywords>.*)");
        public static readonly Regex s_CompiledComputeShaderRegex = new Regex("Compiled compute shader: (?<computeName>[^,]*), kernel: (?<kernelName>[^,]*), keywords (?<keywords>.*)");
        public static readonly Regex s_ShaderVariantNotFoundRegex = new Regex("Shader (?<shaderName>[^,]*), subshader (?<subShaderIndex>\\d+), pass (?<passIndex>\\d+), stage (?<stage>[^,]*): variant (?<keywords>.*) not found.");
        public static readonly string s_NoKeywordText = "<no keywords>";
        public static readonly string k_UseGraphicsTestStripperEnv = "USE_GFX_TEST_STRIPPER";
        public static readonly string k_UseFastShaderVariantListGeneration = "FAST_SHADER_TRACE_GENERATION";
        
    #if !UNITY_EDITOR
        [RuntimeInitializeOnLoadMethod]
        static void RunOnStart()
        {
            GraphicsSettings.logWhenShaderIsCompiled = true;
            Debug.Log("Register log file processing");
            Application.quitting += ConvertShaderErrorsToLog;
        }
    #endif

        static void ConvertShaderErrorsToLog()
        {
            string logFilePath = Application.consoleLogPath;
    
            StringBuilder finalList;
            // Read log while the handle is still controlled by Unity
            using (var logFile = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(logFile, Encoding.Default))
                    AppendAllShaderLines(out finalList, reader.ReadToEnd(), true);
            }
            Debug.Log("The following list of Compiled Shaders are directly converted from shader not found errors. You can ignore them as it's only used for the Graphics Test Shader Variants Stripper system.");
            
            Debug.Log(finalList);
        }

        public static void AppendAllShaderLines(out StringBuilder finalFile, string playerLogContent, bool ignoreValidShadersAndCompute = false)
        {
            var lines = new SortedSet<string>();
            AppendAllShaderLines(out finalFile, playerLogContent, lines, ignoreValidShadersAndCompute);
        }

        public static void AppendAllShaderLines(out StringBuilder finalFile, string playerLogContent, SortedSet<string> existingFileContent, bool ignoreValidShadersAndCompute = false)
        {
            var notFoundMatchSet = new HashSet<string>();
            
            foreach (var line in playerLogContent.Split('\n'))
            {
                var lineTrimmed = line.Trim();

                if (!ignoreValidShadersAndCompute)
                {
                    if (s_CompiledShaderRegex.IsMatch(lineTrimmed))
                        existingFileContent.Add(lineTrimmed);
                    if (s_CompiledComputeShaderRegex.IsMatch(lineTrimmed))
                        existingFileContent.Add(lineTrimmed);
                }
#if !UNITY_EDITOR
                // Shader not found error can be spammed quite a bit in the log, causing this process to stall with 10000s of calls
                if (notFoundMatchSet.Contains(lineTrimmed))
                    continue;
                
                var notFoundMatch = s_ShaderVariantNotFoundRegex.Match(lineTrimmed);
                if (notFoundMatch.Success)
                {
                    notFoundMatchSet.Add(lineTrimmed);
                    // Convert not found shader using the available data in the build
                    var shaderName = notFoundMatch.Groups["shaderName"].Value;
                    var shader = Shader.Find(shaderName);
                    if (shader == null)
                    {
                        Debug.LogError($"Could not find shader {shaderName}");
                        continue;
                    }
                    var dummyMaterial = new Material(shader);
                    int.TryParse(notFoundMatch.Groups["passIndex"].Value, out int passIndex);
                    existingFileContent.Add($"Compiled shader: {shaderName}, pass: {dummyMaterial.GetPassName(passIndex)}, stage: {notFoundMatch.Groups["stage"]}, keywords {notFoundMatch.Groups["keywords"]}");
                    Object.DestroyImmediate(dummyMaterial);
                }
#endif
            }

            finalFile = new StringBuilder();
            foreach (var line in existingFileContent)
                finalFile.AppendLine(line);
        }
    }
}