using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineBlendListCamera))]
    internal sealed class CinemachineBlendListCameraEditor 
        : CinemachineVirtualCameraBaseEditor<CinemachineBlendListCamera>
    {
        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            excluded.Add(FieldPath(x => x.m_Instructions));
            return excluded;
        }

        private UnityEditorInternal.ReorderableList mChildList;
        private UnityEditorInternal.ReorderableList mInstructionList;

        protected override void OnEnable()
        {
            base.OnEnable();
            mChildList = null;
            mInstructionList = null;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            if (mInstructionList == null)
                SetupInstructionList();
            if (mChildList == null)
                SetupChildList();

            // Ordinary properties
            DrawHeaderInInspector();
            DrawPropertyInInspector(FindProperty(x => x.m_Priority));
            DrawTargetsInInspector(FindProperty(x => x.m_Follow), FindProperty(x => x.m_LookAt));
            DrawRemainingPropertiesInInspector();

            // Instructions
            UpdateCameraCandidates();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.Separator();
            mInstructionList.DoLayoutList();

            // vcam children
            EditorGUILayout.Separator();
            mChildList.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                Target.ValidateInstructions();
            }

            // Extensions
            DrawExtensionsWidgetInInspector();
        }

        private string[] mCameraCandidates;
        private Dictionary<CinemachineVirtualCameraBase, int> mCameraIndexLookup;
        private void UpdateCameraCandidates()
        {
            List<string> vcams = new List<string>();
            mCameraIndexLookup = new Dictionary<CinemachineVirtualCameraBase, int>();
            vcams.Add("(none)");
            CinemachineVirtualCameraBase[] children = Target.ChildCameras;
            foreach (var c in children)
            {
                mCameraIndexLookup[c] = vcams.Count;
                vcams.Add(c.Name);
            }
            mCameraCandidates = vcams.ToArray();
        }

        private int GetCameraIndex(Object obj)
        {
            if (obj == null || mCameraIndexLookup == null)
                return 0;
            CinemachineVirtualCameraBase vcam = obj as CinemachineVirtualCameraBase;
            if (vcam == null)
                return 0;
            if (!mCameraIndexLookup.ContainsKey(vcam))
                return 0;
            return mCameraIndexLookup[vcam];
        }

        void SetupInstructionList()
        {
            mInstructionList = new UnityEditorInternal.ReorderableList(serializedObject,
                    serializedObject.FindProperty(() => Target.m_Instructions),
                    true, true, true, true);

            // Needed for accessing field names as strings
            CinemachineBlendListCamera.Instruction def = new CinemachineBlendListCamera.Instruction();

            float vSpace = 2;
            float hSpace = 3;
            float floatFieldWidth = EditorGUIUtility.singleLineHeight * 2.5f;
            float hBigSpace = EditorGUIUtility.singleLineHeight * 2 / 3;
            mInstructionList.drawHeaderCallback = (Rect rect) =>
                {
                    float sharedWidth = rect.width - EditorGUIUtility.singleLineHeight 
                        - floatFieldWidth - hSpace - hBigSpace;
                    rect.x += EditorGUIUtility.singleLineHeight; rect.width = sharedWidth / 2; 
                    EditorGUI.LabelField(rect, "Child");

                    rect.x += rect.width + hSpace; 
                    EditorGUI.LabelField(rect, "Blend in");

                    rect.x += rect.width + hBigSpace; rect.width = floatFieldWidth;
                    EditorGUI.LabelField(rect, "Hold");
                };

            mInstructionList.drawElementCallback
                = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    SerializedProperty instProp = mInstructionList.serializedProperty.GetArrayElementAtIndex(index);
                    float sharedWidth = rect.width - floatFieldWidth - hSpace - hBigSpace;
                    rect.y += vSpace; rect.height = EditorGUIUtility.singleLineHeight;

                    rect.width = sharedWidth / 2; 
                    SerializedProperty vcamSelProp = instProp.FindPropertyRelative(() => def.m_VirtualCamera);
                    int currentVcam = GetCameraIndex(vcamSelProp.objectReferenceValue);
                    int vcamSelection = EditorGUI.Popup(rect, currentVcam, mCameraCandidates);
                    if (currentVcam != vcamSelection)
                        vcamSelProp.objectReferenceValue = (vcamSelection == 0)
                            ? null : Target.ChildCameras[vcamSelection - 1];

                    rect.x += rect.width + hSpace; rect.width = sharedWidth / 2;
                    if (index > 0)
                        EditorGUI.PropertyField(rect, instProp.FindPropertyRelative(() => def.m_Blend), 
                            GUIContent.none);

                    if (index < mInstructionList.count - 1)
                    {
                        float oldWidth = EditorGUIUtility.labelWidth;
                        EditorGUIUtility.labelWidth = hBigSpace; 

                        rect.x += rect.width; rect.width = floatFieldWidth + hBigSpace;
                        SerializedProperty holdProp = instProp.FindPropertyRelative(() => def.m_Hold);
                        EditorGUI.PropertyField(rect, holdProp, new GUIContent(" ", holdProp.tooltip));
                        holdProp.floatValue = Mathf.Max(holdProp.floatValue, 0);

                        EditorGUIUtility.labelWidth = oldWidth; 
                    }
                };
        }

        void SetupChildList()
        {
            float vSpace = 2;
            mChildList = new UnityEditorInternal.ReorderableList(serializedObject,
                    serializedObject.FindProperty(() => Target.m_ChildCameras),
                    true, true, true, true);

            mChildList.drawHeaderCallback = (Rect rect) =>
                {
                    EditorGUI.LabelField(rect, "Virtual Camera Children");
                };
            mChildList.drawElementCallback
                = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    rect.y += vSpace;
                    Vector2 pos = rect.position;
                    rect.height = EditorGUIUtility.singleLineHeight;
                    SerializedProperty element
                        = mChildList.serializedProperty.GetArrayElementAtIndex(index);
                    EditorGUI.PropertyField(rect, element, GUIContent.none);
                };
            mChildList.onChangedCallback = (UnityEditorInternal.ReorderableList l) =>
                {
                    if (l.index < 0 || l.index >= l.serializedProperty.arraySize)
                        return;
                    Object o = l.serializedProperty.GetArrayElementAtIndex(
                            l.index).objectReferenceValue;
                    CinemachineVirtualCameraBase vcam = (o != null)
                        ? (o as CinemachineVirtualCameraBase) : null;
                    if (vcam != null)
                        vcam.transform.SetSiblingIndex(l.index);
                };
            mChildList.onAddCallback = (UnityEditorInternal.ReorderableList l) =>
                {
                    var index = l.serializedProperty.arraySize;
                    var vcam = CinemachineMenu.CreateDefaultVirtualCamera();
                    Undo.SetTransformParent(vcam.transform, Target.transform, "");
                    vcam.transform.SetSiblingIndex(index);
                };
            mChildList.onRemoveCallback = (UnityEditorInternal.ReorderableList l) =>
                {
                    Object o = l.serializedProperty.GetArrayElementAtIndex(
                            l.index).objectReferenceValue;
                    CinemachineVirtualCameraBase vcam = (o != null)
                        ? (o as CinemachineVirtualCameraBase) : null;
                    if (vcam != null)
                        Undo.DestroyObjectImmediate(vcam.gameObject);
                };
        }
    }
}
