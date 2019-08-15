using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Unity.Entities.Serialization;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    [CustomEditor(typeof(ComponentDataProxyBase), true), CanEditMultipleObjects]
    public class ComponentDataProxyBaseEditor : UnityEditor.Editor
    {
        string m_SerializableError;
        string m_MultipleComponentsWarning;
        string m_DisallowMultipleWarning;

        protected SerializedProperty SerializedData { get; private set; }

        protected Type ComponentDataType { get; private set; }

        protected virtual void OnEnable()
        {
            SerializedData = serializedObject.FindProperty("m_SerializedData");

            var type = target.GetType();
            var multipleInstances = targets
                .Select(t => (t as ComponentDataProxyBase).GetComponents(type))
                .Where(c => c.Length > 1)
                .ToArray();
            if (multipleInstances.Length > 0)
                m_MultipleComponentsWarning = string.Format(
                    L10n.Tr("{0} has multiple instances of {1}, but Entity may only have a single instance of any component type."),
                    multipleInstances[0][0].gameObject.name, type
                );
            var disallowMultipleType = Attribute.IsDefined(type, typeof(DisallowMultipleComponent), true) ? type : null;

            FieldInfo field = null;
            while (type.BaseType != typeof(ComponentDataProxyBase))
            {
                type = type.BaseType;
                if (disallowMultipleType == null && Attribute.IsDefined(type, typeof(DisallowMultipleComponent), true))
                    disallowMultipleType = type;
                if (field == null)
                    field = type.GetField("m_SerializedData", BindingFlags.Instance | BindingFlags.NonPublic);
            }

            if (field == null)
                return;

            ComponentDataType = field.FieldType;
            var fieldIsList = typeof(IList).IsAssignableFrom(field.FieldType);
            if (fieldIsList)
            {
                ComponentDataType = ComponentDataType.IsArray
                    ? ComponentDataType.GetElementType()
                    : ComponentDataType.GetGenericArguments().Single();
            }

            if (disallowMultipleType != null && field.FieldType.GetInterfaces().Contains(typeof(ISharedComponentData)))
                m_DisallowMultipleWarning = string.Format(
                    L10n.Tr("Proxy type {0} is marked with {1}, which is not currently compatible with {2}."),
                    disallowMultipleType, typeof(DisallowMultipleComponent), typeof(SerializeUtilityHybrid)
                );

            if (SerializedData != null)
                return;

            if (
                !Attribute.IsDefined(ComponentDataType, typeof(SerializableAttribute))
                && ComponentDataType.GetFields(BindingFlags.Public | BindingFlags.Instance).Length > 0
            )
            {
                m_SerializableError = string.Format(
                    L10n.Tr("Component type {0} is not marked with {1}."), field.FieldType, typeof(SerializableAttribute)
                );
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            if (SerializedData != null)
                DisplaySerializedDataPropertyField();
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            DisplayStatusMessages();
        }

        protected virtual void DisplaySerializedDataPropertyField()
        {
            EditorGUILayout.PropertyField(SerializedData);
        }

        protected virtual void DisplayStatusMessages()
        {
            if (!string.IsNullOrEmpty(m_SerializableError))
                EditorGUILayout.HelpBox(m_SerializableError, MessageType.Error);
            if (!string.IsNullOrEmpty(m_MultipleComponentsWarning))
                EditorGUILayout.HelpBox(m_MultipleComponentsWarning, MessageType.Warning);
            if (!string.IsNullOrEmpty(m_DisallowMultipleWarning))
                EditorGUILayout.HelpBox(m_DisallowMultipleWarning, MessageType.Warning);
        }
    }
}
