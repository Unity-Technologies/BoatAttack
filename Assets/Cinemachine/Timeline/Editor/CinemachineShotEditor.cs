using UnityEditor;
using UnityEngine;
using Cinemachine.Editor;

namespace Cinemachine.Timeline
{
    [CustomEditor(typeof(CinemachineShot))]
    internal sealed class CinemachineShotEditor : UnityEditor.Editor
    {
        private static readonly string[] m_excludeFields = new string[] { "m_Script" };
        private SerializedProperty mVirtualCameraProperty = null;
        private static readonly GUIContent kVirtualCameraLabel
            = new GUIContent("Virtual Camera", "The virtual camera to use for this shot");

        private void OnEnable()
        {
            if (serializedObject != null)
                mVirtualCameraProperty = serializedObject.FindProperty("VirtualCamera");
        }

        private void OnDisable()
        {
            DestroyComponentEditors();
        }

        private void OnDestroy()
        {
            DestroyComponentEditors();
        }

        public override void OnInspectorGUI()
        {
            CinemachineVirtualCameraBase obj
                = mVirtualCameraProperty.exposedReferenceValue as CinemachineVirtualCameraBase;
            if (obj == null)
            {
                serializedObject.Update();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(mVirtualCameraProperty, kVirtualCameraLabel, GUILayout.ExpandWidth(true));
                obj = mVirtualCameraProperty.exposedReferenceValue as CinemachineVirtualCameraBase;
                if ((obj == null) && GUILayout.Button(new GUIContent("Create"), GUILayout.ExpandWidth(false)))
                {
                    CinemachineVirtualCameraBase vcam = CinemachineMenu.CreateDefaultVirtualCamera();
                    mVirtualCameraProperty.exposedReferenceValue = vcam;
                }
                EditorGUILayout.EndHorizontal();
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                serializedObject.Update();
                DrawPropertiesExcluding(serializedObject, m_excludeFields);

                // Create an editor for each of the cinemachine virtual cam and its components
                UpdateComponentEditors(obj);
                if (m_editors != null)
                {
                    foreach (UnityEditor.Editor e in m_editors)
                    {
                        EditorGUILayout.Separator();
                        if (e.target.GetType() != typeof(Transform))
                        {
                            GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) } );
                            EditorGUILayout.LabelField(e.target.GetType().Name, EditorStyles.boldLabel);
                        }
                        e.OnInspectorGUI();
                    }
                }
                serializedObject.ApplyModifiedProperties();
            }
        }

        CinemachineVirtualCameraBase m_cachedReferenceObject;
        UnityEditor.Editor[] m_editors = null;
        void UpdateComponentEditors(CinemachineVirtualCameraBase obj)
        {
            MonoBehaviour[] components = null;
            if (obj != null)
                components = obj.gameObject.GetComponents<MonoBehaviour>();
            int numComponents = (components == null) ? 0 : components.Length;
            int numEditors = (m_editors == null) ? 0 : m_editors.Length;
            if (m_cachedReferenceObject != obj || (numComponents + 1) != numEditors)
            {
                DestroyComponentEditors();
                m_cachedReferenceObject = obj;
                if (obj != null)
                {
                    m_editors = new UnityEditor.Editor[components.Length + 1];
                    CreateCachedEditor(obj.gameObject.GetComponent<Transform>(), null, ref m_editors[0]);
                    for (int i = 0; i < components.Length; ++i)
                        CreateCachedEditor(components[i], null, ref m_editors[i + 1]);
                }
            }
        }

        void DestroyComponentEditors()
        {
            m_cachedReferenceObject = null;
            if (m_editors != null)
            {
                for (int i = 0; i < m_editors.Length; ++i)
                {
                    if (m_editors[i] != null)
                        UnityEngine.Object.DestroyImmediate(m_editors[i]);
                    m_editors[i] = null;
                }
                m_editors = null;
            }
        }
    }
}
