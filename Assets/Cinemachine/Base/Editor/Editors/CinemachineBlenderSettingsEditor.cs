using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineBlenderSettings))]
    internal sealed class CinemachineBlenderSettingsEditor : BaseEditor<CinemachineBlenderSettings>
    {
        private ReorderableList mBlendList;

        /// <summary>
        /// Called when building the Camera popup menus, to get the domain of possible
        /// cameras.  If no delegate is set, will find all top-level (non-slave)
        /// virtual cameras in the scene.
        /// </summary>
        public GetAllVirtualCamerasDelegate GetAllVirtualCameras;
        public delegate CinemachineVirtualCameraBase[] GetAllVirtualCamerasDelegate();

        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            excluded.Add(FieldPath(x => x.m_CustomBlends));
            return excluded;
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            if (mBlendList == null)
                SetupBlendList();

            DrawRemainingPropertiesInInspector();

            UpdateCameraCandidates();
            mBlendList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private string[] mCameraCandidates;
        private Dictionary<string, int> mCameraIndexLookup;
        private void UpdateCameraCandidates()
        {
            List<string> vcams = new List<string>();
            mCameraIndexLookup = new Dictionary<string, int>();

            CinemachineVirtualCameraBase[] candidates;
            if (GetAllVirtualCameras != null)
                candidates = GetAllVirtualCameras();
            else
            {
                // Get all top-level (i.e. non-slave) virtual cameras
                candidates = Resources.FindObjectsOfTypeAll(
                        typeof(CinemachineVirtualCameraBase)) as CinemachineVirtualCameraBase[];

                for (int i = 0; i < candidates.Length; ++i)
                    if (candidates[i].ParentCamera != null)
                        candidates[i] = null;
            }
            vcams.Add("(none)");
            vcams.Add(CinemachineBlenderSettings.kBlendFromAnyCameraLabel);
            foreach (CinemachineVirtualCameraBase c in candidates)
                if (c != null && !vcams.Contains(c.Name))
                    vcams.Add(c.Name);

            mCameraCandidates = vcams.ToArray();
            for (int i = 0; i < mCameraCandidates.Length; ++i)
                mCameraIndexLookup[mCameraCandidates[i]] = i;
        }

        private int GetCameraIndex(string name)
        {
            if (name == null || mCameraIndexLookup == null)
                return 0;
            if (!mCameraIndexLookup.ContainsKey(name))
                return 0;
            return mCameraIndexLookup[name];
        }

        void SetupBlendList()
        {
            mBlendList = new ReorderableList(serializedObject,
                    serializedObject.FindProperty(() => Target.m_CustomBlends),
                    true, true, true, true);

            // Needed for accessing string names of fields
            CinemachineBlenderSettings.CustomBlend def = new CinemachineBlenderSettings.CustomBlend();
            CinemachineBlendDefinition def2 = new CinemachineBlendDefinition();

            float vSpace = 2;
            float hSpace = 3;
            float floatFieldWidth = EditorGUIUtility.singleLineHeight * 2.5f;
            mBlendList.drawHeaderCallback = (Rect rect) =>
                {
                    rect.width -= (EditorGUIUtility.singleLineHeight + 2 * hSpace);
                    rect.width /= 3;
                    Vector2 pos = rect.position; pos.x += EditorGUIUtility.singleLineHeight;
                    rect.position = pos;
                    EditorGUI.LabelField(rect, "From");

                    pos.x += rect.width + hSpace; rect.position = pos;
                    EditorGUI.LabelField(rect, "To");

                    pos.x += rect.width + hSpace; rect.width -= floatFieldWidth + hSpace; rect.position = pos;
                    EditorGUI.LabelField(rect, "Style");

                    pos.x += rect.width + hSpace; rect.width = floatFieldWidth; rect.position = pos;
                    EditorGUI.LabelField(rect, "Time");
                };

            mBlendList.drawElementCallback
                = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    SerializedProperty element
                        = mBlendList.serializedProperty.GetArrayElementAtIndex(index);

                    rect.y += vSpace;
                    rect.height = EditorGUIUtility.singleLineHeight;
                    Vector2 pos = rect.position;
                    rect.width -= 2 * hSpace; rect.width /= 3;
                    SerializedProperty fromProp = element.FindPropertyRelative(() => def.m_From);
                    int current = GetCameraIndex(fromProp.stringValue);
                    int sel = EditorGUI.Popup(rect, current, mCameraCandidates);
                    if (current != sel)
                        fromProp.stringValue = mCameraCandidates[sel];

                    pos.x += rect.width + hSpace; rect.position = pos;
                    SerializedProperty toProp = element.FindPropertyRelative(() => def.m_To);
                    current = GetCameraIndex(toProp.stringValue);
                    sel = EditorGUI.Popup(rect, current, mCameraCandidates);
                    if (current != sel)
                        toProp.stringValue = mCameraCandidates[sel];

                    SerializedProperty blendProp = element.FindPropertyRelative(() => def.m_Blend);
                    pos.x += rect.width + hSpace; rect.width -= floatFieldWidth; rect.position = pos;
                    SerializedProperty styleProp = blendProp.FindPropertyRelative(() => def2.m_Style);
                    EditorGUI.PropertyField(rect, styleProp, GUIContent.none);

                    if (styleProp.intValue != (int)CinemachineBlendDefinition.Style.Cut)
                    {
                        pos.x += rect.width + hSpace; rect.width = floatFieldWidth; rect.position = pos;
                        SerializedProperty timeProp = blendProp.FindPropertyRelative(() => def2.m_Time);
                        EditorGUI.PropertyField(rect, timeProp, GUIContent.none);
                    }
                };

            mBlendList.onAddCallback = (ReorderableList l) =>
                {
                    var index = l.serializedProperty.arraySize;
                    ++l.serializedProperty.arraySize;
                    SerializedProperty blendProp = l.serializedProperty.GetArrayElementAtIndex(
                            index).FindPropertyRelative(() => def.m_Blend);

                    blendProp.FindPropertyRelative(() => def2.m_Style).enumValueIndex
                        = (int)CinemachineBlendDefinition.Style.EaseInOut;
                    blendProp.FindPropertyRelative(() => def2.m_Time).floatValue = 2f;
                };
        }
    }
}
