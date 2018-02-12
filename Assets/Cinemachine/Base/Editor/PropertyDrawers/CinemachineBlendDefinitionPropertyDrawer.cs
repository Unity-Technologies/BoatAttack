using UnityEngine;
using UnityEditor;

namespace Cinemachine.Editor
{
    [CustomPropertyDrawer(typeof(CinemachineBlendDefinitionPropertyAttribute))]
    public sealed  class CinemachineBlendDefinitionPropertyDrawer : PropertyDrawer
    {
        CinemachineBlendDefinition myClass = new CinemachineBlendDefinition(); // to access name strings
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            float vSpace = 0;
            float floatFieldWidth = EditorGUIUtility.singleLineHeight * 2.5f;

            SerializedProperty timeProp = property.FindPropertyRelative(() => myClass.m_Time);
            GUIContent timeText = new GUIContent(" sec ", timeProp.tooltip);
            var textDimensions = GUI.skin.label.CalcSize(timeText);

            rect = EditorGUI.PrefixLabel(rect, label);

            rect.y += vSpace; rect.height = EditorGUIUtility.singleLineHeight;
            rect.width -= floatFieldWidth + textDimensions.x;

            SerializedProperty styleProp = property.FindPropertyRelative(() => myClass.m_Style);
            EditorGUI.PropertyField(rect, styleProp, GUIContent.none);

            if (styleProp.intValue != (int)CinemachineBlendDefinition.Style.Cut)
            {
                float oldWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = textDimensions.x; 
                rect.x += rect.width; rect.width = floatFieldWidth + EditorGUIUtility.labelWidth;
                EditorGUI.PropertyField(rect, timeProp, timeText);
                timeProp.floatValue = Mathf.Max(timeProp.floatValue, 0);
                EditorGUIUtility.labelWidth = oldWidth; 
            }
        }
    }
}
