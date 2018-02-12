using UnityEngine;
using UnityEditor;
using Cinemachine.Editor;
using System.Collections.Generic;
using Cinemachine.Utility;

namespace Cinemachine
{
    [CustomEditor(typeof(CinemachineFreeLook))]
    internal sealed class CinemachineFreeLookEditor 
        : CinemachineVirtualCameraBaseEditor<CinemachineFreeLook>
    {
        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            excluded.Add(FieldPath(x => x.m_Orbits));
            if (!Target.m_CommonLens)
                excluded.Add(FieldPath(x => x.m_Lens));
            if (Target.m_BindingMode == CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp)
            {
                excluded.Add(FieldPath(x => x.m_Heading));
                excluded.Add(FieldPath(x => x.m_RecenterToTargetHeading));
            }
            return excluded;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            // Must destroy child editors or we get exceptions
            if (m_editors != null)
                foreach (UnityEditor.Editor e in m_editors)
                    if (e != null)
                        UnityEngine.Object.DestroyImmediate(e);
        }

        public override void OnInspectorGUI()
        {
            // Ordinary properties
            BeginInspector();
            DrawHeaderInInspector();
            DrawPropertyInInspector(FindProperty(x => x.m_Priority));
            DrawTargetsInInspector(FindProperty(x => x.m_Follow), FindProperty(x => x.m_LookAt));
            DrawRemainingPropertiesInInspector();

            // Orbits
            EditorGUI.BeginChangeCheck();
            SerializedProperty orbits = FindProperty(x => x.m_Orbits);
            for (int i = 0; i < CinemachineFreeLook.RigNames.Length; ++i)
            {
                float hSpace = 3;
                SerializedProperty orbit = orbits.GetArrayElementAtIndex(i);
                Rect rect = EditorGUILayout.GetControlRect(true);
                rect = EditorGUI.PrefixLabel(rect, new GUIContent(CinemachineFreeLook.RigNames[i]));
                rect.height = EditorGUIUtility.singleLineHeight;
                rect.width = rect.width / 2 - hSpace;

                float oldWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = rect.width / 2; 
                SerializedProperty heightProp = orbit.FindPropertyRelative(() => Target.m_Orbits[i].m_Height);
                EditorGUI.PropertyField(rect, heightProp, new GUIContent("Height"));
                rect.x += rect.width + hSpace;
                SerializedProperty radiusProp = orbit.FindPropertyRelative(() => Target.m_Orbits[i].m_Radius);
                EditorGUI.PropertyField(rect, radiusProp, new GUIContent("Radius"));
                EditorGUIUtility.labelWidth = oldWidth; 
            }
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            // Rigs
            UpdateRigEditors();
            for (int i = 0; i < m_editors.Length; ++i)
            {
                if (m_editors[i] == null)
                    continue;
                EditorGUILayout.Separator();
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.LabelField(RigNames[i], EditorStyles.boldLabel);
                ++EditorGUI.indentLevel;
                m_editors[i].OnInspectorGUI();
                --EditorGUI.indentLevel;
                EditorGUILayout.EndVertical();
            }

            // Extensions
            DrawExtensionsWidgetInInspector();
        }

        string[] RigNames;
        CinemachineVirtualCameraBase[] m_rigs;
        UnityEditor.Editor[] m_editors;
        void UpdateRigEditors()
        {
            RigNames = CinemachineFreeLook.RigNames;
            if (m_rigs == null)
                m_rigs = new CinemachineVirtualCameraBase[RigNames.Length];
            if (m_editors == null)
                m_editors = new UnityEditor.Editor[RigNames.Length];
            for (int i = 0; i < RigNames.Length; ++i)
            {
                CinemachineVirtualCamera rig = Target.GetRig(i);
                if (rig == null || rig != m_rigs[i])
                {
                    m_rigs[i] = rig;
                    if (m_editors[i] != null)
                        UnityEngine.Object.DestroyImmediate(m_editors[i]);
                    m_editors[i] = null;
                    if (rig != null)
                        CreateCachedEditor(rig, null, ref m_editors[i]);
                }
            }
        }

        /// <summary>
        /// Register with CinemachineFreeLook to create the pipeline in an undo-friendly manner
        /// </summary>
        [InitializeOnLoad]
        class CreateRigWithUndo
        {
            static CreateRigWithUndo()
            {
                CinemachineFreeLook.CreateRigOverride
                    = (CinemachineFreeLook vcam, string name, CinemachineVirtualCamera copyFrom) =>
                    {
                        // Create a new rig with default components
                        GameObject go = new GameObject(name);
                        Undo.RegisterCreatedObjectUndo(go, "created rig");
                        Undo.SetTransformParent(go.transform, vcam.transform, "parenting rig");
                        CinemachineVirtualCamera rig = Undo.AddComponent<CinemachineVirtualCamera>(go);
                        Undo.RecordObject(rig, "creating rig");
                        if (copyFrom != null)
                            ReflectionHelpers.CopyFields(copyFrom, rig);
                        else
                        {
                            go = rig.GetComponentOwner().gameObject;
                            Undo.RecordObject(Undo.AddComponent<CinemachineOrbitalTransposer>(go), "creating rig");
                            Undo.RecordObject(Undo.AddComponent<CinemachineComposer>(go), "creating rig");
                        }
                        return rig;
                    };
                CinemachineFreeLook.DestroyRigOverride = (GameObject rig) =>
                    {
                        Undo.DestroyObjectImmediate(rig);
                    };
            }
        }

        [DrawGizmo(GizmoType.Active | GizmoType.Selected, typeof(CinemachineFreeLook))]
        private static void DrawFreeLookGizmos(CinemachineFreeLook vcam, GizmoType selectionType)
        {
            // Standard frustum and logo
            CinemachineBrainEditor.DrawVirtualCameraBaseGizmos(vcam, selectionType);

            Color originalGizmoColour = Gizmos.color;
            bool isActiveVirtualCam = CinemachineCore.Instance.IsLive(vcam);
            Gizmos.color = isActiveVirtualCam
                ? CinemachineSettings.CinemachineCoreSettings.ActiveGizmoColour
                : CinemachineSettings.CinemachineCoreSettings.InactiveGizmoColour;

            if (vcam.Follow != null)
            {
                Vector3 pos = vcam.Follow.position;
                Vector3 up = Vector3.up;
                CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(vcam);
                if (brain != null)
                    up = brain.DefaultWorldUp;

                var MiddleRig = vcam.GetRig(1).GetCinemachineComponent<CinemachineOrbitalTransposer>();
                Quaternion orient = MiddleRig.GetReferenceOrientation(up);
                up = orient * Vector3.up;
                float rotation = vcam.m_XAxis.Value + vcam.m_Heading.m_HeadingBias;
                orient = Quaternion.AngleAxis(rotation, up) * orient;

                CinemachineOrbitalTransposerEditor.DrawCircleAtPointWithRadius(
                    pos + up * vcam.m_Orbits[0].m_Height, orient, vcam.m_Orbits[0].m_Radius);
                CinemachineOrbitalTransposerEditor.DrawCircleAtPointWithRadius(
                    pos + up * vcam.m_Orbits[1].m_Height, orient, vcam.m_Orbits[1].m_Radius);
                CinemachineOrbitalTransposerEditor.DrawCircleAtPointWithRadius(
                    pos + up * vcam.m_Orbits[2].m_Height, orient, vcam.m_Orbits[2].m_Radius);

                DrawCameraPath(pos, orient, vcam);
            }

            Gizmos.color = originalGizmoColour;
        }

        private static void DrawCameraPath(Vector3 atPos, Quaternion orient, CinemachineFreeLook vcam)
        {
            Matrix4x4 prevMatrix = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(atPos, orient, Vector3.one);

            const int kNumStepsPerPair = 30;
            Vector3 currPos = vcam.GetLocalPositionForCameraFromInput(0f);
            for (int i = 1; i < kNumStepsPerPair + 1; ++i)
            {
                float t = (float)i / (float)kNumStepsPerPair;
                Vector3 nextPos = vcam.GetLocalPositionForCameraFromInput(t);
                Gizmos.DrawLine(currPos, nextPos);
                Gizmos.DrawWireSphere(nextPos, 0.02f);
                currPos = nextPos;
            }
            Gizmos.matrix = prevMatrix;
        }
    }
}
