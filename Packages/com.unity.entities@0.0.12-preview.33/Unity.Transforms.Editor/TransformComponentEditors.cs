using Unity.Entities.Editor;
using UnityEditor;
using UnityEngine;

namespace Unity.Transforms.Editor
{
    abstract class BaseTransformComponentEditor : ComponentDataProxyBaseEditor
    {
        string m_DrivenMessage;
        string m_InitializedMessage;
        CopyTransformFromGameObjectProxy m_Driver;
        CopyInitialTransformFromGameObjectProxy m_Initializer;

        protected override void OnEnable()
        {
            m_Driver = (target as Component).GetComponent<CopyTransformFromGameObjectProxy>();
            m_DrivenMessage = string.Format(
                L10n.Tr("Value is driven by {0}"),
                ObjectNames.NicifyVariableName(typeof(CopyTransformFromGameObject).Name)
            );
            m_Initializer = (target as Component).GetComponent<CopyInitialTransformFromGameObjectProxy>();
            m_InitializedMessage = string.Format(
                L10n.Tr("Initial value will be determined by {0}"),
                ObjectNames.NicifyVariableName(typeof(CopyInitialTransformFromGameObject).Name)
                );
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(m_Driver != null || m_Initializer != null && !EditorApplication.isPlaying);
            base.OnInspectorGUI();
            EditorGUI.EndDisabledGroup();
            if (m_Driver != null)
                EditorGUILayout.HelpBox(m_DrivenMessage, MessageType.None);
            else if (m_Initializer != null && !EditorApplication.isPlaying)
                EditorGUILayout.HelpBox(m_InitializedMessage, MessageType.None);
        }
    }

    [CustomEditor(typeof(TranslationProxy), true), CanEditMultipleObjects]
    class PositionComponentEditor : BaseTransformComponentEditor
    {

    }

    [CustomEditor(typeof(RotationProxy), true), CanEditMultipleObjects]
    class RotationComponentEditor : BaseTransformComponentEditor
    {

    }
}
