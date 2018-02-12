using UnityEngine;
using UnityEditor;

namespace Cinemachine.Editor
{
    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public sealed  class CinemachineTagFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            const float hSpace = 2;
            GUIContent clearText = new GUIContent("Clear", "Set the tag to empty");
            var textDimensions = GUI.skin.button.CalcSize(clearText);

            rect.width -= textDimensions.x + hSpace;
            string oldValue = property.stringValue;
            string newValue = EditorGUI.TagField(rect, label, oldValue);

            rect.x += rect.width; rect.width = textDimensions.x;
            GUI.enabled = oldValue.Length > 0;
            if (GUI.Button(rect, clearText))
                newValue = string.Empty;
            GUI.enabled = true;
            if (oldValue != newValue)
                property.stringValue = newValue;
        }
    }
}
