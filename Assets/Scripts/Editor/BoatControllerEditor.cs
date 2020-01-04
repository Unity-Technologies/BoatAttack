using UnityEditor;
using UnityEngine;

namespace BoatAttack
{
    [CustomEditor(typeof(Boat))]
    public class BoatControllerEditor : Editor
    {
        
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

            var nameProp = property.FindPropertyRelative("boatName");
            nameProp.stringValue = EditorGUI.TextField(nameRect, "Boat Name", nameProp.stringValue);
            var prefabProp = property.FindPropertyRelative("boatPrefab");
            EditorGUI.PropertyField(prefabRect, prefabProp, new GUIContent("Asset"));
            EditorGUI.PropertyField(humanRect, property.FindPropertyRelative("Human"));
            
            EditorGUIUtility.labelWidth = 70;
            EditorGUI.PropertyField(color1Rect, property.FindPropertyRelative("livery").FindPropertyRelative("PrimaryColor"));
            EditorGUI.PropertyField(color2Rect, property.FindPropertyRelative("livery").FindPropertyRelative("TrimColor"));

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
