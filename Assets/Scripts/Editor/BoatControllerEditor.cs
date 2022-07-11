using System.Globalization;
using BoatAttack.UI;
using UnityEditor;
using UnityEngine;

namespace BoatAttack
{
    [CustomEditor(typeof(Boat))]
    public class BoatEditor : Editor
    {
        private bool _generalHeaderBool;
        private bool _debugHeaderBool;

        public override void OnInspectorGUI()
        {
            var boat = target as Boat;

            DrawGeneralSettings();
            DrawDebugInfo(boat);

        }

        private void DrawGeneralSettings()
        {
            _generalHeaderBool = EditorGUILayout.BeginFoldoutHeaderGroup(_generalHeaderBool, "General");
            if (_generalHeaderBool)
            {
                base.OnInspectorGUI();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        private void DrawDebugInfo(Boat boat)
        {
            _debugHeaderBool = EditorGUILayout.BeginFoldoutHeaderGroup(_debugHeaderBool, "Debug Information");
            if (_debugHeaderBool)
            {
                if (Application.isPlaying) Repaint();

                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("Place", boat.Place.ToString());
                EditorGUILayout.LabelField("Lap Percentage", boat.LapPercentage.ToString(CultureInfo.InvariantCulture));
                EditorGUILayout.LabelField("Lap Count", boat.LapCount.ToString());
                EditorGUILayout.LabelField("Match Status", boat.MatchComplete ? "Complete" : "Incomplete");

                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.LabelField("Split", "Time", EditorStyles.boldLabel);
                if (Application.isPlaying)
                {
                    var i = 0;
                    foreach (var split in boat.SplitTimes)
                    {
                        EditorGUILayout.LabelField($"Split {i}:", RaceUI.FormatRaceTime(split));
                        i++;
                    }
                }
                else
                {
                    EditorGUILayout.LabelField("Null:", "00:00.000");
                }
                EditorGUILayout.EndVertical();

                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }

    //[CustomPropertyDrawer(typeof(BoatData))]
    public class BoatDataDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // name
            var nameProp = property.FindPropertyRelative(nameof(BoatData.name));
            var nameRect = EditorGUILayout.GetControlRect();
            nameProp.stringValue = EditorGUI.TextField(nameRect, "Boat Name", nameProp.stringValue);
            
            // stats
            
            // runtime data
            var humanRect = EditorGUILayout.GetControlRect();
            EditorGUI.PropertyField(humanRect, property.FindPropertyRelative(nameof(BoatData.Human)));
            var color1Rect = EditorGUILayout.GetControlRect();
            EditorGUI.PropertyField(color1Rect, property.FindPropertyRelative(nameof(BoatData.Livery)).FindPropertyRelative(nameof(BoatLivery.primaryColor)));
            var color2Rect = EditorGUILayout.GetControlRect();
            EditorGUI.PropertyField(color2Rect, property.FindPropertyRelative(nameof(BoatData.Livery)).FindPropertyRelative(nameof(BoatLivery.trimColor)));

            
            // assets
            var prefabProp = property.FindPropertyRelative(nameof(BoatData.boatPrefab));
            var prefabRect = EditorGUILayout.GetControlRect();
            EditorGUI.PropertyField(prefabRect, prefabProp, new GUIContent("Asset"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2f + EditorGUIUtility.standardVerticalSpacing * 3f;
        }
    }
}
