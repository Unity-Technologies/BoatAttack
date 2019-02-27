using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.LWRP;

namespace WaterSystem
{
	[CustomPropertyDrawer(typeof(PlanarReflections.PlanarReflectionSettings))]
	public class PlanarSettingsDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			// Don't make child fields be indented
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			// Rects
			Rect resMultiRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			Rect offsetRect = new Rect(position.x, resMultiRect.yMax + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight);
			Rect layerMaskRect = new Rect(position.x, offsetRect.yMax + EditorGUIUtility.standardVerticalSpacing, position.width, EditorGUIUtility.singleLineHeight);
			Rect shadowRect = new Rect(position.x, layerMaskRect.yMax + EditorGUIUtility.standardVerticalSpacing, position.width * 0.5f, EditorGUIUtility.singleLineHeight);
			Rect maxLODRect = new Rect(position.x + position.width * 0.5f, layerMaskRect.yMax + EditorGUIUtility.standardVerticalSpacing, position.width * 0.5f, EditorGUIUtility.singleLineHeight);

		var resMulti = property.FindPropertyRelative("m_ResolutionMultiplier");
		EditorGUI.PropertyField(resMultiRect, resMulti);
		position.y += EditorGUIUtility.singleLineHeight;
		var offset = property.FindPropertyRelative("m_ClipPlaneOffset");
		EditorGUI.Slider(offsetRect, offset, -0.500f, 0.500f);
		var layerMask = property.FindPropertyRelative("m_ReflectLayers");
		EditorGUI.PropertyField(layerMaskRect, layerMask);
	
			// Set indent back to what it was
			EditorGUI.indentLevel = indent;

			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 4f;
		}
	}
}
