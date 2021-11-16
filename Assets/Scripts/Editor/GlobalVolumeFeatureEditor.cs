using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[CustomEditor(typeof(GlobalVolumeFeature))]
public class GlobalVolumeFeatureEditor : Editor
{
    private GlobalVolumeFeature feature;
    private SerializedProperty profileList;
    private SerializedProperty baseProfile;
    
    private static class Styles
    {
        public static GUIStyle frameBox = new GUIStyle(EditorStyles.helpBox);
        public static GUIStyle header = new GUIStyle(EditorStyles.boldLabel);

        public static GUIContent baseGUI = new GUIContent("Global Base Profile",
            "This Profile is always active and should be treated as a default global settings for Volumes.");
    }

    private void OnEnable()
    {
        profileList = serializedObject.FindProperty(nameof(feature._qualityProfiles));
        baseProfile = serializedObject.FindProperty(nameof(feature._baseProfile));
    }

    public override void OnInspectorGUI()
    {
        feature = (GlobalVolumeFeature)target;

        EditorGUILayout.PropertyField(baseProfile, Styles.baseGUI);
        
        EditorGUILayout.LabelField("Quality Level Profiles", Styles.header);
        
        var qualityLevelNames = QualitySettings.names;
        
        EditorGUILayout.BeginVertical(Styles.frameBox);
        // Draw Quality level entries
        for (var i = 0; i < qualityLevelNames.Length; i++)
        {
            if (i >=  feature._qualityProfiles.Count)
            {
                feature._qualityProfiles.Add(null);
                EditorUtility.SetDirty(feature);
                serializedObject.Update();
            }
            EditorGUI.BeginChangeCheck();
            var obj = feature._qualityProfiles[i];
            feature._qualityProfiles[i] = (VolumeProfile)EditorGUILayout.ObjectField(qualityLevelNames[i], obj, typeof(VolumeProfile), false);
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(feature);
                serializedObject.Update();
            }
        }
        EditorGUILayout.EndVertical();

        if (qualityLevelNames.Length < feature._qualityProfiles.Count)
        {
            feature._qualityProfiles.RemoveRange(qualityLevelNames.Length, feature._qualityProfiles.Count - qualityLevelNames.Length);
            EditorUtility.SetDirty(feature);
        }
    }
}
