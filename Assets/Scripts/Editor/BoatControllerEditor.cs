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

    [CustomPropertyDrawer(typeof(BoatData))]
    public class BoatDataDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var singleHeight = EditorGUIUtility.singleLineHeight;
            var singleSpace = EditorGUIUtility.standardVerticalSpacing;
            var oldLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUI.indentLevel--;
            EditorGUIUtility.labelWidth = 100;

            var halfSize = new Vector2(position.width / 2, singleHeight);
            var nameRect = new Rect(position.position + new Vector2(5, singleSpace), halfSize);
            var prefabRect = new Rect(position.position + new Vector2(nameRect.width, 0), halfSize);
            var humanRect = new Rect(position.position + new Vector2(5, singleHeight + singleSpace), halfSize);
            var color1Rect = new Rect(position.position + new Vector2(humanRect.width, singleHeight + singleSpace), halfSize * new Vector2(0.5f, 1f));
            var color2Rect = new Rect(position.position + new Vector2(humanRect.width + color1Rect.width, singleHeight + singleSpace), halfSize * new Vector2(0.5f, 1f));

            Rect box = EditorGUI.IndentedRect(position);
            GUI.Box(box, "", EditorStyles.helpBox);

            var nameProp = property.FindPropertyRelative(nameof(BoatData.boatName));
            nameProp.stringValue = EditorGUI.TextField(nameRect, "Boat Name", nameProp.stringValue);
            var prefabProp = property.FindPropertyRelative(nameof(BoatData.boatPrefab));
            EditorGUI.PropertyField(prefabRect, prefabProp, new GUIContent("Asset"));
            EditorGUI.PropertyField(humanRect, property.FindPropertyRelative(nameof(BoatData.human)));

            EditorGUIUtility.labelWidth = 70;
            EditorGUI.PropertyField(color1Rect, property.FindPropertyRelative(nameof(BoatData.livery)).FindPropertyRelative(nameof(BoatLivery.primaryColor)));
            EditorGUI.PropertyField(color2Rect, property.FindPropertyRelative(nameof(BoatData.livery)).FindPropertyRelative(nameof(BoatLivery.trimColor)));

            EditorGUIUtility.labelWidth = oldLabelWidth;
            EditorGUI.indentLevel++;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2f + EditorGUIUtility.standardVerticalSpacing * 3f;
        }
    }
}
