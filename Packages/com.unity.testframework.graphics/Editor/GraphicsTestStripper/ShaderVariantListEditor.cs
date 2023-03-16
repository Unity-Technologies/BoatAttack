using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine.Rendering;
using UnityEngine.TestTools.Graphics;

namespace UnityEditor.TestTools.Graphics
{
    [CustomEditor(typeof(ShaderVariantList))]
    public class ShaderVariantListImporterEditor : Editor
    {
        new ShaderVariantList target => base.target as ShaderVariantList;

        int m_UpdateFromSCVEventID = -1;
        int m_AggregateFromSCVEventID = -1;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUI.EndDisabledGroup();

            using (new GUILayout.VerticalScope("HelpBox"))
            {
                EditorGUILayout.LabelField("Logs operations", EditorStyles.boldLabel);

                if (GUILayout.Button(new GUIContent("Update Shader Variants From Player.log",
                        "You can provide the full Player.log file in this text area to manually update the list of shader variants to strip.")))
                {
                    string defaultPath =
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                            .Replace("Roaming", "LocalLow") + "/DefaultCompany/UnityTestFramework/";

                    string path = EditorUtility.OpenFilePanel("Select Player.log or shadervariantlist file",
                        defaultPath, "log,txt,shadervariantlist");
                    var playerLog = File.ReadAllText(path);
                    UpdateVariantsFromLog(playerLog);
                }

                if (GUILayout.Button(new GUIContent("Aggregate Shader Variants From Player.log",
                        "You can provide the full Player.log file in this text area to manually update the list of shader variants to strip.")))
                {
                    string defaultPath =
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                            .Replace("Roaming", "LocalLow") + "/DefaultCompany/UnityTestFramework/";

                    string path = EditorUtility.OpenFilePanel("Select Player.log or shadervariantlist file",
                        defaultPath, "log,txt,shadervariantlist");
                    var playerLog = File.ReadAllText(path);
                    AggregateVariantsFromLog(playerLog);
                }
            }
            
            EditorGUILayout.Space();

            using (new GUILayout.VerticalScope("HelpBox"))
            {
                EditorGUILayout.LabelField("Shader Variant Collection Operations", EditorStyles.boldLabel);

                if (GUILayout.Button(new GUIContent("Update Shader Variants From SVC",
                        "You can provide a full Player.log file in this text area to manually update the list of shader variants to strip.")))
                {
                    m_UpdateFromSCVEventID = EditorGUIUtility.GetControlID(FocusType.Passive) + 101;
                    EditorGUIUtility.ShowObjectPicker<ShaderVariantCollection>(null, false, "", m_UpdateFromSCVEventID);
                }
                if (GUILayout.Button(new GUIContent("Aggregate Shader Variants From SVC",
                        "You can provide a full Player.log file in this text area to manually update the list of shader variants to strip.")))
                {
                    m_AggregateFromSCVEventID = EditorGUIUtility.GetControlID(FocusType.Passive) + 42;
                    EditorGUIUtility.ShowObjectPicker<ShaderVariantCollection>(null, false, "", m_AggregateFromSCVEventID);
                }
            }
            
            EditorGUILayout.Space();

            var oldColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;
            using (new GUILayout.VerticalScope("HelpBox"))
            {
                if (GUILayout.Button("Clear All Data"))
                    ClearAllData();
            }
            GUI.backgroundColor = oldColor;

            if (Event.current.commandName == "ObjectSelectorUpdated")
            {
                ShaderVariantCollection pickedCollection = null;
                
                if (EditorGUIUtility.GetObjectPickerControlID() == m_UpdateFromSCVEventID)
                {
                    pickedCollection = EditorGUIUtility.GetObjectPickerObject() as ShaderVariantCollection;
                    m_UpdateFromSCVEventID = -1;
                    UpdateVariantsFromSVC(pickedCollection);
                }
                if (EditorGUIUtility.GetObjectPickerControlID() == m_AggregateFromSCVEventID)
                {
                    pickedCollection = EditorGUIUtility.GetObjectPickerObject() as ShaderVariantCollection;
                    m_AggregateFromSCVEventID = -1;
                    AggregateVariantsFromSVC(pickedCollection);
                }
            }

            EditorGUI.BeginChangeCheck();
            target.settings.enabled = EditorGUILayout.Toggle("Enabled", target.settings.enabled);
            target.settings.targetPlatform = (ShaderCompilerPlatform)EditorGUILayout.EnumPopup("Target Platform", target.settings.targetPlatform);
            target.settings.xr = EditorGUILayout.Toggle("XR", target.settings.xr);
            if (EditorGUI.EndChangeCheck())
            {
                UpdateVariantsSettingsInFile();
            }

            EditorGUI.BeginDisabledGroup(true);
            base.OnInspectorGUI();

            serializedObject.ApplyModifiedProperties();
        }

        void UpdateVariantsFromLog(string playerLogContent)
        {
            GenerateShaderVariantList.AppendAllShaderLines(out var finalFile, playerLogContent);
            WriteAllTextToSVL(AssetDatabase.GetAssetPath(target), finalFile);
        }

        void UpdateVariantsFromSVC(ShaderVariantCollection svc)
        {
            var svcLog = TransformSVCToLog(svc);
            
            GenerateShaderVariantList.AppendAllShaderLines(out var finalFile, svcLog.ToString());
            WriteAllTextToSVL(AssetDatabase.GetAssetPath(target), finalFile);
        }

        StringBuilder TransformSVCToLog(ShaderVariantCollection svc)
        {
            // Generate compiled shader lines form SVC
            var serializedSVC = new SerializedObject(svc);
            var shaders = serializedSVC.FindProperty("m_Shaders");
            var svcLog = new StringBuilder();
            
            for (int i = 0; i < shaders.arraySize; i++)
            {
                var shaderVariants = shaders.GetArrayElementAtIndex(i);
                Shader shader = (Shader)shaderVariants.FindPropertyRelative("first").objectReferenceValue;
                var shaderPassNames = GetAllPassNamesInShader(shader);
                
                // Shader name and button to remove it
                var variantsProp = shaderVariants.FindPropertyRelative("second.variants");
                for (int variantIndex = 0; variantIndex < variantsProp.arraySize; ++variantIndex)
                {
                    var prop = variantsProp.GetArrayElementAtIndex(variantIndex);
                    var keywords = prop.FindPropertyRelative("keywords").stringValue;
                    if (string.IsNullOrEmpty(keywords))
                        keywords = "<no keywords>";
                    
                    // Ignore pass type as it's useless in SRPs and hardcode all stage instead because we don't have the info
                    foreach (var passName in shaderPassNames)
                        svcLog.AppendLine($"Compiled shader: {shader.name}, pass: {passName}, stage: all, keywords {keywords}");
                }
            }

            return svcLog;
        }

        List<string> GetAllPassNamesInShader(Shader shader)
        {
            var shaderData = ShaderUtil.GetShaderData(shader);
            var shaderPassNames = new List<string>();

#if UNITY_2021_2_OR_NEWER
            // Gather pass names for the current shader, filtered using the current render pipeline
            for (int subShaderIndex = 0; subShaderIndex < shaderData.SubshaderCount; subShaderIndex++)
            {
                var subShader = shaderData.GetSubshader(subShaderIndex);

                var renderPipeline = subShader.FindTagValue(new ShaderTagId("RenderPipeline")).name;
                if (RenderPipelineManager.currentPipeline == null ||
                    renderPipeline == RenderPipelineManager.currentPipeline.GetType().Name)
                {
                    for (int passIndex = 0; passIndex < subShader.PassCount; passIndex++)
                    {
                        string passName = subShader.GetPass(passIndex).Name;
                        if (String.IsNullOrEmpty(passName))
                            passName = "<Unnamed Pass " + passIndex + ">";
                        shaderPassNames.Add(passName);
                    }
                }
            }
#endif

            return shaderPassNames;
        }

        void AggregateVariantsFromLog(string playerLogContent)
        {
            var path = AssetDatabase.GetAssetPath(target);
            var existingLines = new SortedSet<string>();
            
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path).ToList();
                try
                {
                    var settingsLine = JsonUtility.FromJson<ShaderVariantList.Settings>(lines[0]);
                    if (settingsLine != null)
                        lines.RemoveAt(0);
                } catch {}
                
                // Deduplicate entries
                foreach (var line in lines)
                    existingLines.Add(line.Trim());
            }

            GenerateShaderVariantList.AppendAllShaderLines(out var finalFile, playerLogContent, existingLines);
            WriteAllTextToSVL(path, finalFile);
        }

        void WriteAllTextToSVL(string path, StringBuilder finalFile)
        {
            finalFile.Insert(0, JsonUtility.ToJson(target.settings) + "\n");
            File.WriteAllText(path, finalFile.ToString());
            AssetDatabase.Refresh();
            AssetDatabase.ImportAsset(path);
        }

        void AggregateVariantsFromSVC(ShaderVariantCollection svc)
        {
            var path = AssetDatabase.GetAssetPath(target);
            var svcLog = TransformSVCToLog(svc);

            var existingLines = new SortedSet<string>();
            if (File.Exists(path))
            {
                // Deduplicate entries
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                    existingLines.Add(line.Trim());
            }

            GenerateShaderVariantList.AppendAllShaderLines(out var finalFile, svcLog.ToString(), existingLines);
            WriteAllTextToSVL(path, finalFile);
        }

        void UpdateVariantsSettingsInFile()
        {
            var path = AssetDatabase.GetAssetPath(target);
            var fileLines = File.ReadAllLines(path).ToList();
            var settingsText = JsonUtility.ToJson(target.settings);

            try
            {
                JsonUtility.FromJson<ShaderVariantList.Settings>(fileLines[0]);
                fileLines[0] = settingsText;
            }
            catch (Exception)
            {
                fileLines.Insert(0, settingsText);
            }

            File.WriteAllLines(path, fileLines);
            AssetDatabase.Refresh();
            AssetDatabase.ImportAsset(path);
        }

        void ClearAllData()
        {
            var path = AssetDatabase.GetAssetPath(target);
            var settingsText = JsonUtility.ToJson(target.settings);
            File.WriteAllText(path, settingsText);
            AssetDatabase.Refresh();
            AssetDatabase.ImportAsset(path);
        }
    }
}