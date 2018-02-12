using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineTargetGroup))]
    internal sealed class CinemachineTargetGroupEditor : BaseEditor<CinemachineTargetGroup>
    {
        private UnityEditorInternal.ReorderableList mTargetList;

        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            excluded.Add(FieldPath(x => x.m_Targets));
            return excluded;
        }

        void OnEnable()
        {
            mTargetList = null;
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            DrawRemainingPropertiesInInspector();

            if (mTargetList == null)
                SetupTargetList();
            EditorGUI.BeginChangeCheck();
            mTargetList.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }

        void SetupTargetList()
        {
            float vSpace = 2;
            float floatFieldWidth = EditorGUIUtility.singleLineHeight * 3f;
            float hBigSpace = EditorGUIUtility.singleLineHeight * 2 / 3;

            mTargetList = new UnityEditorInternal.ReorderableList(
                    serializedObject, FindProperty(x => x.m_Targets),
                    true, true, true, true);

            // Needed for accessing field names as strings
            CinemachineTargetGroup.Target def = new CinemachineTargetGroup.Target();

            mTargetList.drawHeaderCallback = (Rect rect) =>
                {
                    rect.width -= EditorGUIUtility.singleLineHeight + 2 * (floatFieldWidth + hBigSpace);
                    Vector2 pos = rect.position; pos.x += EditorGUIUtility.singleLineHeight;
                    rect.position = pos;
                    EditorGUI.LabelField(rect, "Target");

                    pos.x += rect.width + hBigSpace; rect.width = floatFieldWidth; rect.position = pos;
                    EditorGUI.LabelField(rect, "Weight");

                    pos.x += rect.width + hBigSpace; rect.position = pos;
                    EditorGUI.LabelField(rect, "Radius");
                };

            mTargetList.drawElementCallback
                = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    SerializedProperty elemProp = mTargetList.serializedProperty.GetArrayElementAtIndex(index);

                    rect.y += vSpace;
                    rect.height = EditorGUIUtility.singleLineHeight;
                    Vector2 pos = rect.position;
                    //rect.width -= hSpace + 2 * EditorGUIUtility.singleLineHeight;
                    rect.width -= 2 * (floatFieldWidth + hBigSpace);
                    EditorGUI.PropertyField(rect, elemProp.FindPropertyRelative(() => def.target), GUIContent.none);

                    float oldWidth = EditorGUIUtility.labelWidth;
                    EditorGUIUtility.labelWidth = EditorGUIUtility.singleLineHeight; 
                    pos.x += rect.width; rect.width = floatFieldWidth + hBigSpace; rect.position = pos;
                    EditorGUI.PropertyField(rect, elemProp.FindPropertyRelative(() => def.weight), new GUIContent(" "));
                    pos.x += rect.width; rect.position = pos;
                    EditorGUI.PropertyField(rect, elemProp.FindPropertyRelative(() => def.radius), new GUIContent(" "));
                    EditorGUIUtility.labelWidth = oldWidth; 
                };

            mTargetList.onAddCallback = (UnityEditorInternal.ReorderableList l) =>
                {
                    var index = l.serializedProperty.arraySize;
                    ++l.serializedProperty.arraySize;
                    SerializedProperty elemProp = mTargetList.serializedProperty.GetArrayElementAtIndex(index);
                    elemProp.FindPropertyRelative(() => def.weight).floatValue = 1;
                };
        }
    }
}
