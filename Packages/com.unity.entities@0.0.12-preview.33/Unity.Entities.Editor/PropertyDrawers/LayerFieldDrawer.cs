using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    /// <summary>
    /// Custom drawer for a LayerField dropdown.
    /// </summary>
    [CustomPropertyDrawer(typeof(LayerFieldAttribute))]
    sealed class LayerFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                position = EditorGUI.PrefixLabel(position, label);

                EditorGUI.BeginChangeCheck();
                var layer = EditorGUI.LayerField(position, property.intValue);
                if (EditorGUI.EndChangeCheck())
                    property.intValue = layer;
            }
            else
            {
                EditorGUI.LabelField(position, label.text, $"LayerFieldAttribute is only meant for ints. You used it on a {property.propertyType}.");
            }

            EditorGUI.EndProperty();
        }
    }
}
