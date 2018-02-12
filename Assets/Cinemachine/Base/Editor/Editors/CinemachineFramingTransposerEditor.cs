using UnityEngine;
using UnityEditor;
using Cinemachine.Utility;
using System.Collections.Generic;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineFramingTransposer))]
    internal class CinemachineFramingTransposerEditor : BaseEditor<CinemachineFramingTransposer>
    {
        CinemachineScreenComposerGuides mScreenGuideEditor;

        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            if (Target.m_UnlimitedSoftZone)
            {
                excluded.Add(FieldPath(x => x.m_SoftZoneWidth));
                excluded.Add(FieldPath(x => x.m_SoftZoneHeight));
                excluded.Add(FieldPath(x => x.m_BiasX));
                excluded.Add(FieldPath(x => x.m_BiasY));
            }
            CinemachineTargetGroup group = Target.TargetGroup;
            if (group == null || Target.m_GroupFramingMode == CinemachineFramingTransposer.FramingMode.None)
            {
                excluded.Add(FieldPath(x => x.m_GroupFramingSize));
                excluded.Add(FieldPath(x => x.m_AdjustmentMode));
                excluded.Add(FieldPath(x => x.m_MaxDollyIn));
                excluded.Add(FieldPath(x => x.m_MaxDollyOut));
                excluded.Add(FieldPath(x => x.m_MinimumDistance));
                excluded.Add(FieldPath(x => x.m_MaximumDistance));
                excluded.Add(FieldPath(x => x.m_MinimumFOV));
                excluded.Add(FieldPath(x => x.m_MaximumFOV));
                excluded.Add(FieldPath(x => x.m_MinimumOrthoSize));
                excluded.Add(FieldPath(x => x.m_MaximumOrthoSize));
                if (group == null)
                    excluded.Add(FieldPath(x => x.m_GroupFramingMode));
            }
            else 
            {
                CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(Target.VirtualCamera);
                bool ortho = brain != null ? brain.OutputCamera.orthographic : false;
                if (ortho)
                {
                    excluded.Add(FieldPath(x => x.m_AdjustmentMode));
                    excluded.Add(FieldPath(x => x.m_MaxDollyIn));
                    excluded.Add(FieldPath(x => x.m_MaxDollyOut));
                    excluded.Add(FieldPath(x => x.m_MinimumDistance));
                    excluded.Add(FieldPath(x => x.m_MaximumDistance));
                    excluded.Add(FieldPath(x => x.m_MinimumFOV));
                    excluded.Add(FieldPath(x => x.m_MaximumFOV));
                }
                else 
                {
                    excluded.Add(FieldPath(x => x.m_MinimumOrthoSize));
                    excluded.Add(FieldPath(x => x.m_MaximumOrthoSize));
                    switch (Target.m_AdjustmentMode)
                    {
                    case CinemachineFramingTransposer.AdjustmentMode.DollyOnly:
                        excluded.Add(FieldPath(x => x.m_MinimumFOV));
                        excluded.Add(FieldPath(x => x.m_MaximumFOV));
                        break;
                    case CinemachineFramingTransposer.AdjustmentMode.ZoomOnly:
                        excluded.Add(FieldPath(x => x.m_MaxDollyIn));
                        excluded.Add(FieldPath(x => x.m_MaxDollyOut));
                        excluded.Add(FieldPath(x => x.m_MinimumDistance));
                        excluded.Add(FieldPath(x => x.m_MaximumDistance));
                        break;
                    default:
                        break;
                    }
                }
            }
            return excluded;
        }

        protected virtual void OnEnable()
        {
            mScreenGuideEditor = new CinemachineScreenComposerGuides();
            mScreenGuideEditor.GetHardGuide = () => { return Target.HardGuideRect; };
            mScreenGuideEditor.GetSoftGuide = () => { return Target.SoftGuideRect; };
            mScreenGuideEditor.SetHardGuide = (Rect r) => { Target.HardGuideRect = r; };
            mScreenGuideEditor.SetSoftGuide = (Rect r) => { Target.SoftGuideRect = r; };
            mScreenGuideEditor.Target = () => { return serializedObject; };

            Target.OnGUICallback += OnGUI;
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }

        protected virtual void OnDisable()
        {
            if (Target != null)
                Target.OnGUICallback -= OnGUI;
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            if (Target.FollowTarget == null)
                EditorGUILayout.HelpBox(
                    "Framing Transposer requires a Follow target.  Change Body to Do Nothing if you don't want a Follow target.", 
                    MessageType.Warning);
            if (Target.LookAtTarget != null)
                EditorGUILayout.HelpBox(
                    "The LookAt target must be null.  The Follow target will be used in place of the LookAt target.",
                    MessageType.Warning);

            // First snapshot some settings
            Rect oldHard = Target.HardGuideRect;
            Rect oldSoft = Target.SoftGuideRect;

            // Draw the properties
            DrawRemainingPropertiesInInspector();
            mScreenGuideEditor.SetNewBounds(oldHard, oldSoft, Target.HardGuideRect, Target.SoftGuideRect);
        }

        protected virtual void OnGUI()
        {
            // Draw the camera guides
            if (!Target.IsValid || !CinemachineSettings.CinemachineCoreSettings.ShowInGameGuides)
                return;

            CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(Target.VirtualCamera);
            if (brain == null || brain.OutputCamera.activeTexture != null)
                return;

            bool isLive = CinemachineCore.Instance.IsLive(Target.VirtualCamera);

            // Screen guides
            mScreenGuideEditor.OnGUI_DrawGuides(isLive, brain.OutputCamera, Target.VcamState.Lens, !Target.m_UnlimitedSoftZone);

            // Draw an on-screen gizmo for the target
            if (Target.FollowTarget != null && isLive)
            {
                Vector3 targetScreenPosition = brain.OutputCamera.WorldToScreenPoint(Target.TrackedPoint);
                if (targetScreenPosition.z > 0)
                {
                    targetScreenPosition.y = Screen.height - targetScreenPosition.y;

                    GUI.color = CinemachineSettings.ComposerSettings.TargetColour;
                    Rect r = new Rect(targetScreenPosition, Vector2.zero);
                    float size = (CinemachineSettings.ComposerSettings.TargetSize 
                        + CinemachineScreenComposerGuides.kGuideBarWidthPx) / 2;
                    GUI.DrawTexture(r.Inflated(new Vector2(size, size)), Texture2D.whiteTexture);
                    size -= CinemachineScreenComposerGuides.kGuideBarWidthPx;
                    if (size > 0)
                    {
                        Vector4 overlayOpacityScalar 
                            = new Vector4(1f, 1f, 1f, CinemachineSettings.ComposerSettings.OverlayOpacity);
                        GUI.color = Color.black * overlayOpacityScalar;
                        GUI.DrawTexture(r.Inflated(new Vector2(size, size)), Texture2D.whiteTexture);
                    }
                }
            }
        }

        [DrawGizmo(GizmoType.Active | GizmoType.InSelectionHierarchy, typeof(CinemachineFramingTransposer))]
        private static void DrawGroupComposerGizmos(CinemachineFramingTransposer target, GizmoType selectionType)
        {
            // Show the group bounding box, as viewed from the camera position
            CinemachineTargetGroup group = target.TargetGroup;
            if (group != null)
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
