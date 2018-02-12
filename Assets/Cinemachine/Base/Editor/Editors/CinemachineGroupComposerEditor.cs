using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using Cinemachine.Utility;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineGroupComposer))]
    internal class CinemachineGroupComposerEditor : CinemachineComposerEditor
    {
        // Specialization
        private CinemachineGroupComposer MyTarget { get { return target as CinemachineGroupComposer; } }
        protected string FieldPath<TValue>(Expression<Func<CinemachineGroupComposer, TValue>> expr)
        {
            return ReflectionHelpers.GetFieldPath(expr);
        }

        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(MyTarget.VirtualCamera);
            bool ortho = brain != null ? brain.OutputCamera.orthographic : false;
            if (ortho)
            {
                excluded.Add(FieldPath(x => x.m_AdjustmentMode));
                excluded.Add(FieldPath(x => x.m_MinimumFOV));
                excluded.Add(FieldPath(x => x.m_MaximumFOV));
                excluded.Add(FieldPath(x => x.m_MaxDollyIn));
                excluded.Add(FieldPath(x => x.m_MaxDollyOut));
                excluded.Add(FieldPath(x => x.m_MinimumDistance));
                excluded.Add(FieldPath(x => x.m_MaximumDistance));
            }
            else
            {
                excluded.Add(FieldPath(x => x.m_MinimumOrthoSize));
                excluded.Add(FieldPath(x => x.m_MaximumOrthoSize));
                switch (MyTarget.m_AdjustmentMode)
                {
                    case CinemachineGroupComposer.AdjustmentMode.DollyOnly:
                        excluded.Add(FieldPath(x => x.m_MinimumFOV));
                        excluded.Add(FieldPath(x => x.m_MaximumFOV));
                        break;
                    case CinemachineGroupComposer.AdjustmentMode.ZoomOnly:
                        excluded.Add(FieldPath(x => x.m_MaxDollyIn));
                        excluded.Add(FieldPath(x => x.m_MaxDollyOut));
                        excluded.Add(FieldPath(x => x.m_MinimumDistance));
                        excluded.Add(FieldPath(x => x.m_MaximumDistance));
                        break;
                    default:
                        break;
                }
            }
            return excluded;
        }

        public override void OnInspectorGUI()
        {
            if (MyTarget.IsValid && MyTarget.TargetGroup == null)
                EditorGUILayout.HelpBox(
                    "The Framing settings will be ignored because the LookAt target is not a kind of CinemachineTargetGroup", 
                    MessageType.Info);

            base.OnInspectorGUI();
        }

        [DrawGizmo(GizmoType.Active | GizmoType.InSelectionHierarchy, typeof(CinemachineGroupComposer))]
        private static void DrawGroupComposerGizmos(CinemachineGroupComposer target, GizmoType selectionType)
        {
            // Show the group bounding box, as viewed from the camera position
            if (target.TargetGroup != null)
            {
                Matrix4x4 m = Gizmos.matrix;
                Bounds b = target.m_LastBounds;
                Gizmos.matrix = target.m_lastBoundsMatrix;
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(b.center, b.size);
                Gizmos.matrix = m;
            }
        }
    }
}
