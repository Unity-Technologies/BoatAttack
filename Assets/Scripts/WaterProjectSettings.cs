using System.Collections.Generic;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
#endif
using UnityEngine;

namespace WaterSystem
{
// to strip out ond have in runtime
    class WaterProjectSettings : ScriptableObject
    {
        private static WaterProjectSettings _instance;

        public static WaterProjectSettings Instance
        {
            get
            {
                if (_instance) return _instance;
#if UNITY_EDITOR
                if (Application.isEditor) return GetOrCreateSettings();
#endif
                return FindObjectOfType<WaterProjectSettings>();
            }
            private set => _instance = value;
        }

        [SerializeField] public int m_Number = 42;
        [SerializeField] public string m_SomeString = "The answer to the universe";

#if UNITY_EDITOR
        #region EditorOnly
        // editor sections
        
        internal static bool isDirty;
        internal static WaterProjectSettings GetOrCreateSettings()
        {
            //Does WaterSettings exist?
            if (_instance != null)
                return _instance;

            _instance = FindObjectOfType<WaterProjectSettings>();
            if(_instance == null)
                _instance = CreateInstance<WaterProjectSettings>();
            _instance.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontUnloadUnusedAsset;
            
            if (File.Exists(SettingsConsts.FullEditorPath))
            {
                // load it from ProjectSettings
                var data = File.ReadAllText(SettingsConsts.FullEditorPath);
                EditorJsonUtility.FromJsonOverwrite(data, _instance);
            }
            else
            {
                // Generate new file
                File.WriteAllText(SettingsConsts.FullEditorPath, EditorJsonUtility.ToJson(_instance));
            }
            return _instance;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
        #endregion 
#endif
    }
    
#if UNITY_EDITOR
    /*
    // Pre/Post Builds steps
    public class SettingsBuilder : IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        public int callbackOrder { get; }
        
        public void OnPreprocessBuild(BuildReport report)
        {
            CleanBuildFolder();

            if (!Directory.Exists(SettingsConsts.BuildFolder))
                Directory.CreateDirectory(SettingsConsts.BuildFolder);
            
            File.Copy(SettingsConsts.FullEditorPath, SettingsConsts.FullBuildPath);
        }
        
        public void OnPostprocessBuild(BuildReport report)
        {
            CleanBuildFolder();
        }

        private void CleanBuildFolder()
        {
            if (Directory.Exists(SettingsConsts.FullBuildPath))
                Directory.Delete(SettingsConsts.FullBuildPath, true);
        }
    }
    */
    
    // Settings GUI
    static class ProjectSettingsGUI
    {
        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider()
        {
            // First parameter is the path in the Settings window.
            // Second parameter is the scope of this setting: it only appears in the Project Settings window.
            var provider = new SettingsProvider("Project/Water System (Boat Attack)", SettingsScope.Project)
            {
                // Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
                guiHandler = (searchContext) =>
                {
                    var settings = WaterProjectSettings.GetSerializedSettings();
                    EditorGUILayout.PropertyField(settings.FindProperty("m_Number"), new GUIContent("My Number"));
                    EditorGUILayout.PropertyField(settings.FindProperty("m_SomeString"), new GUIContent("My String"));
                    if(settings.hasModifiedProperties)
                        SaveOnChange(settings);
                },

                // Populate the search keywords to enable smart search filtering and label highlighting:
                keywords = new HashSet<string>(new[] {"Number", "Some String"})
            };

            return provider;
        }

        private static void SaveOnChange(SerializedObject obj)
        {
            WaterProjectSettings.isDirty = true;
            obj.ApplyModifiedProperties();
        }
    }
    
    //Saving
    public class Saver : AssetModificationProcessor
    {
        static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log("OnWillSaveAssets");
            foreach (string path in paths)
                Debug.Log(path);

            if (WaterProjectSettings.isDirty)
            {
                Debug.Log("Saving Water Settings");
                File.WriteAllText(SettingsConsts.FullEditorPath, EditorJsonUtility.ToJson(WaterProjectSettings.Instance));
                WaterProjectSettings.isDirty = false;
            }
            
            return paths;
        }
    }

    internal static class SettingsConsts
    {
        internal static string EditorFolder = "/ProjectSettings/";
        internal static string Build = "/WaterSystemTemporary/Resources/";
        internal static string BuildRelativeFolder = "Assets" + Build;
        internal static string BuildFolder = Application.dataPath + Build;
        internal static string AssetString = "WaterSystemSettings.asset";

        internal static string FullEditorPath => Directory.GetParent(Application.dataPath) + EditorFolder + AssetString;
        internal static string FullBuildPath => BuildFolder + AssetString;
    }
#endif
}