using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Unity.Entities.Editor
{
    [CustomEditor(typeof(DynamicBufferProxy<>), true), CanEditMultipleObjects]
    public class DynamicBufferProxyBaseEditor : ComponentDataProxyBaseEditor
    {
        static class Styles
        {
            public const float LowCapacityPercent = 0.5f;
            public static readonly string CapacityStatusFormatString =
                L10n.Tr("{0} has a specified internal buffer capacity of {1}.");
            public static readonly string DefaultCapacityStatusFormatString =
                L10n.Tr($"{{0}} is not marked with {typeof(InternalBufferCapacityAttribute).Name} and has a default capacity of {{1}}.");
            public static readonly string OverAllocatedFormatString =
                L10n.Tr("{0} has an internal capacity of {1}, but you have allocated {2} elements, which will result in cache misses. Consider increasing the buffer capacity or allocating fewer elements.");
            public static readonly string UnderUtilizedFormatString =
                L10n.Tr("{0} has an internal capacity of {1}, but you have only allocated {2} elements. If you are frequently under-utilizing the available internal buffer capacity, consider decreasing it to avoid wasting memory.");
        }

        ReorderableList m_SerializedDataList;

        string m_BufferStatusString;
        MessageType m_BufferStatus;

        int Capacity
        {
            get { return TypeManager.GetTypeInfo(TypeManager.GetTypeIndex(ComponentDataType)).BufferCapacity; }
        }

        // rebuild lazily when accessed from OnGUI() to avoid accessing TypeManager (via Capacity) in OnEnable()
        public string CapacityStatusString
        {
            get
            {
                if (string.IsNullOrEmpty(m_CapacityStatusString))
                {
                    var formatString = Attribute.IsDefined(ComponentDataType, typeof(InternalBufferCapacityAttribute))
                        ? Styles.CapacityStatusFormatString
                        : Styles.DefaultCapacityStatusFormatString;
                    m_CapacityStatusString = string.Format(formatString, ComponentDataType.Name, Capacity);
                    RebuildBufferStatusString();
                }
                return m_CapacityStatusString;
            }
        }
        string m_CapacityStatusString;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_SerializedDataList = new ReorderableList(serializedObject, SerializedData);
            var label = EditorGUIUtility.TrTextContent(m_SerializedDataList.serializedProperty.displayName);
            m_SerializedDataList.drawHeaderCallback = rect => EditorGUI.LabelField(rect, label);
            var tempLabel = new GUIContent();
            if (ComponentDataType?.GetFields().Length == 1)
            {
                m_SerializedDataList.elementHeight =
                    EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                m_SerializedDataList.drawElementCallback = (rect, index, active, focused) =>
                {
                    var element = m_SerializedDataList.serializedProperty.GetArrayElementAtIndex(index);
                    tempLabel.text = element.displayName;
                    rect = new Rect(rect) { height = rect.height - EditorGUIUtility.standardVerticalSpacing };
                    element.Next(true);
                    EditorGUI.PropertyField(rect, element, tempLabel);
                };
            }
            else
            {
                m_SerializedDataList.elementHeightCallback = index =>
                    EditorGUI.GetPropertyHeight(m_SerializedDataList.serializedProperty.GetArrayElementAtIndex(index))
                    +EditorGUIUtility.standardVerticalSpacing;
                m_SerializedDataList.drawElementCallback = (rect, index, active, focused) =>
                {
                    var hierarchyMode = EditorGUIUtility.hierarchyMode;
                    EditorGUIUtility.hierarchyMode = false;
                    var element = m_SerializedDataList.serializedProperty.GetArrayElementAtIndex(index);
                    tempLabel.text = element.displayName;
                    rect = new Rect(rect) { height = rect.height - EditorGUIUtility.standardVerticalSpacing };
                    EditorGUI.PropertyField(rect, element, tempLabel, true);
                    EditorGUIUtility.hierarchyMode = hierarchyMode;
                };
            }
        }

        protected override void DisplaySerializedDataPropertyField()
        {
            EditorGUILayout.HelpBox(CapacityStatusString, MessageType.None);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(m_SerializedDataList.serializedProperty.FindPropertyRelative("Array.size"));
            // align control fields with those outside the reorderable list control
            var labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth -= 19f;
            m_SerializedDataList?.DoLayoutList();
            EditorGUIUtility.labelWidth = labelWidth;
            if (EditorGUI.EndChangeCheck())
                RebuildBufferStatusString();
        }

        void RebuildBufferStatusString()
        {
            m_BufferStatus = MessageType.None;
            var count = m_SerializedDataList.count;
            if (count > Capacity)
            {
                m_BufferStatusString =
                    string.Format(Styles.OverAllocatedFormatString, ComponentDataType.Name, Capacity, count);
                m_BufferStatus = MessageType.Warning;
            }
            else if (count < Capacity * Styles.LowCapacityPercent)
            {
                m_BufferStatusString =
                    string.Format(Styles.UnderUtilizedFormatString, ComponentDataType.Name, Capacity, count);
                m_BufferStatus = MessageType.Warning;
            }
        }

        protected override void DisplayStatusMessages()
        {
            base.DisplayStatusMessages();
            if (m_BufferStatus != MessageType.None)
                EditorGUILayout.HelpBox(m_BufferStatusString, m_BufferStatus);
        }
    }
}
