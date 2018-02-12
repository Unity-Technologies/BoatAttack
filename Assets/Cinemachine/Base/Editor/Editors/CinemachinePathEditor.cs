using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal;
using Cinemachine.Utility;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachinePath))]
    internal sealed class CinemachinePathEditor : BaseEditor<CinemachinePath>
    {
        private ReorderableList mWaypointList;
        static bool mWaypointsExpanded;
        static bool mPreferHandleSelection = true;

        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            excluded.Add(FieldPath(x => x.m_Waypoints));
            return excluded;
        }

        void OnEnable()
        {
            mWaypointList = null;
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            if (mWaypointList == null)
                SetupWaypointList();
            if (mWaypointList.index >= mWaypointList.count)
                mWaypointList.index = mWaypointList.count - 1;

            // Ordinary properties
            DrawRemainingPropertiesInInspector();

            GUILayout.Label(new GUIContent("Selected Waypoint:"));
            EditorGUILayout.BeginVertical(GUI.skin.box);
            Rect rect = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight * 3 + 10);
            if (mWaypointList.index >= 0)
            {
                DrawWaypointEditor(rect, mWaypointList.index);
                serializedObject.ApplyModifiedProperties();
            }
            else
            {
                if (Target.m_Waypoints.Length > 0)
                {
                    EditorGUI.HelpBox(rect,
                        "Click on a waypoint in the scene view\nor in the Path Details list",
                        MessageType.Info);
                }
                else if (GUI.Button(rect, new GUIContent("Add a waypoint to the path")))
                {
                    InsertWaypointAtIndex(mWaypointList.index);
                    mWaypointList.index = 0;
                }
            }
            EditorGUILayout.EndVertical();

            mPreferHandleSelection = EditorGUILayout.Toggle(
                    new GUIContent("Prefer Tangent Drag",
                        "When editing the path, if waypoint position and tangent coincide, dragging will apply preferentially to the tangent"),
                    mPreferHandleSelection);

            mWaypointsExpanded = EditorGUILayout.Foldout(mWaypointsExpanded, "Path Details");
            if (mWaypointsExpanded)
            {
                EditorGUI.BeginChangeCheck();
                mWaypointList.DoLayoutList();
                if (EditorGUI.EndChangeCheck())
                    serializedObject.ApplyModifiedProperties();
            }
        }

        void SetupWaypointList()
        {
            mWaypointList = new ReorderableList(
                    serializedObject, FindProperty(x => x.m_Waypoints),
                    true, true, true, true);
            mWaypointList.elementHeight *= 3;

            mWaypointList.drawHeaderCallback = (Rect rect) =>
                {
                    EditorGUI.LabelField(rect, "Waypoints");
                };

            mWaypointList.drawElementCallback
                = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    DrawWaypointEditor(rect, index);
                };

            mWaypointList.onAddCallback = (ReorderableList l) =>
                {
                    InsertWaypointAtIndex(l.index);
                };
        }

        void DrawWaypointEditor(Rect rect, int index)
        {
            // Needed for accessing string names of fields
            CinemachinePath.Waypoint def = new CinemachinePath.Waypoint();

            Vector2 numberDimension = GUI.skin.button.CalcSize(new GUIContent("999"));
            Vector2 labelDimension = GUI.skin.label.CalcSize(new GUIContent("Position"));
            Vector2 addButtonDimension = new Vector2(labelDimension.y + 5, labelDimension.y + 1);
            float vSpace = 2;
            float hSpace = 3;

            SerializedProperty element = mWaypointList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += vSpace / 2;

            Rect r = new Rect(rect.position, numberDimension);
            Color color = GUI.color;
            // GUI.color = Target.m_Appearance.pathColor;
            if (GUI.Button(r, new GUIContent(index.ToString(), "Go to the waypoint in the scene view")))
            {
                mWaypointList.index = index;
                SceneView.lastActiveSceneView.pivot = Target.EvaluatePosition(index);
                SceneView.lastActiveSceneView.size = 3;
                SceneView.lastActiveSceneView.Repaint();
            }
            GUI.color = color;

            r = new Rect(rect.position, labelDimension);
            r.x += hSpace + numberDimension.x;
            EditorGUI.LabelField(r, "Position");
            r.x += hSpace + r.width;
            r.width = rect.width - (numberDimension.x + hSpace + r.width + hSpace + addButtonDimension.x + hSpace);
            EditorGUI.PropertyField(r, element.FindPropertyRelative(() => def.position), GUIContent.none);
            r.x += r.width + hSpace;
            r.size = addButtonDimension;
            GUIContent buttonContent = EditorGUIUtility.IconContent("d_RectTransform Icon");
            buttonContent.tooltip = "Set to scene-view camera position";
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.alignment = TextAnchor.MiddleCenter;
            if (GUI.Button(r, buttonContent, style))
            {
                Undo.RecordObject(Target, "Set waypoint");
                CinemachinePath.Waypoint wp = Target.m_Waypoints[index];
                Vector3 pos = SceneView.lastActiveSceneView.camera.transform.position;
                wp.position = Target.transform.InverseTransformPoint(pos);
                Target.m_Waypoints[index] = wp;
            }

            r = new Rect(rect.position, labelDimension);
            r.y += numberDimension.y + vSpace;
            r.x += hSpace + numberDimension.x; r.width = labelDimension.x;
            EditorGUI.LabelField(r, "Tangent");
            r.x += hSpace + r.width;
            r.width = rect.width - (numberDimension.x + hSpace + r.width + hSpace + addButtonDimension.x + hSpace);
            EditorGUI.PropertyField(r, element.FindPropertyRelative(() => def.tangent), GUIContent.none);
            r.x += r.width + hSpace;
            r.size = addButtonDimension;
            buttonContent = EditorGUIUtility.IconContent("ol minus@2x");
            buttonContent.tooltip = "Remove this waypoint";
            if (GUI.Button(r, buttonContent, style))
            {
                Undo.RecordObject(Target, "Delete waypoint");
                var list = new List<CinemachinePath.Waypoint>(Target.m_Waypoints);
                list.RemoveAt(index);
                Target.m_Waypoints = list.ToArray();
                if (index == Target.m_Waypoints.Length)
                    mWaypointList.index = index - 1;
            }

            r = new Rect(rect.position, labelDimension);
            r.y += 2 * (numberDimension.y + vSpace);
            r.x += hSpace + numberDimension.x; r.width = labelDimension.x;
            EditorGUI.LabelField(r, "Roll");
            r.x += hSpace + labelDimension.x;
            r.width = rect.width
                - (numberDimension.x + hSpace)
                - (labelDimension.x + hSpace)
                - (addButtonDimension.x + hSpace);
            r.width /= 3;
            EditorGUI.MultiPropertyField(r, new GUIContent[] { new GUIContent(" ") },
                element.FindPropertyRelative(() => def.roll));

            r.x = rect.x + rect.width - addButtonDimension.x;
            r.size = addButtonDimension;
            buttonContent = EditorGUIUtility.IconContent("ol plus@2x");
            buttonContent.tooltip = "Add a new waypoint after this one";
            if (GUI.Button(r, buttonContent, style))
            {
                mWaypointList.index = index;
                InsertWaypointAtIndex(index);
            }
        }

        void InsertWaypointAtIndex(int indexA)
        {
            Vector3 pos = Vector3.forward;
            Vector3 tangent = Vector3.right;
            float roll = 0;

            // Get new values from the current indexA (if any)
            int numWaypoints = Target.m_Waypoints.Length;
            if (indexA < 0)
                indexA = numWaypoints - 1;
            if (indexA >= 0)
            {
                int indexB = indexA + 1;
                if (Target.m_Looped && indexB >= numWaypoints)
                    indexB = 0;
                if (indexB >= numWaypoints)
                {
                    // Extrapolate the end
                    if (!Target.m_Waypoints[indexA].tangent.AlmostZero())
                        tangent = Target.m_Waypoints[indexA].tangent;
                    pos = Target.m_Waypoints[indexA].position + tangent;
                    roll = Target.m_Waypoints[indexA].roll;
                }
                else
                {
                    // Interpolate
                    pos = Target.transform.InverseTransformPoint(
                            Target.EvaluatePosition(0.5f + indexA));
                    tangent = Target.transform.InverseTransformDirection(
                            Target.EvaluateTangent(0.5f + indexA).normalized);
                    roll = Mathf.Lerp(
                            Target.m_Waypoints[indexA].roll, Target.m_Waypoints[indexB].roll, 0.5f);
                }
            }
            Undo.RecordObject(Target, "Add waypoint");
            var wp = new CinemachinePath.Waypoint();
            wp.position = pos;
            wp.tangent = tangent;
            wp.roll = roll;
            var list = new List<CinemachinePath.Waypoint>(Target.m_Waypoints);
            list.Insert(indexA + 1, wp);
            Target.m_Waypoints = list.ToArray();
            mWaypointList.index = indexA + 1; // select it
        }

        void OnSceneGUI()
        {
            if (mWaypointList == null)
                SetupWaypointList();

            if (Tools.current == Tool.Move)
            {
                Matrix4x4 mOld = Handles.matrix;
                Color colorOld = Handles.color;

                Handles.matrix = Target.transform.localToWorldMatrix;
                for (int i = 0; i < Target.m_Waypoints.Length; ++i)
                {
                    DrawSelectionHandle(i);
                    if (mWaypointList.index == i)
                    {
                        // Waypoint is selected
                        if (mPreferHandleSelection)
                        {
                            DrawPositionControl(i);
                            DrawTangentControl(i);
                        }
                        else
                        {
                            DrawTangentControl(i);
                            DrawPositionControl(i);
                        }
                    }
                }
                Handles.color = colorOld;
                Handles.matrix = mOld;
            }
        }

        void DrawSelectionHandle(int i)
        {
            if (Event.current.button != 1)
            {
                Vector3 pos = Target.m_Waypoints[i].position;
                float size = HandleUtility.GetHandleSize(pos) * 0.2f;
                Handles.color = Color.white;
                if (Handles.Button(pos, Quaternion.identity, size, size, Handles.SphereHandleCap)
                    && mWaypointList.index != i)
                {
                    mWaypointList.index = i;
                    InternalEditorUtility.RepaintAllViews();
                }
                // Label it
                Handles.BeginGUI();
                Vector2 labelSize = new Vector2(
                        EditorGUIUtility.singleLineHeight * 2, EditorGUIUtility.singleLineHeight);
                Vector2 labelPos = HandleUtility.WorldToGUIPoint(pos);
                labelPos.y -= labelSize.y / 2;
                labelPos.x -= labelSize.x / 2;
                GUILayout.BeginArea(new Rect(labelPos, labelSize));
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.black;
                style.alignment = TextAnchor.MiddleCenter;
                GUILayout.Label(new GUIContent(i.ToString(), "Waypoint " + i), style);
                GUILayout.EndArea();
                Handles.EndGUI();
            }
        }

        void DrawTangentControl(int i)
        {
            CinemachinePath.Waypoint wp = Target.m_Waypoints[i];
            Vector3 hPos = wp.position + wp.tangent;

            Handles.color = Color.yellow;
            Handles.DrawLine(wp.position, hPos);

            EditorGUI.BeginChangeCheck();
            Quaternion rotation = (Tools.pivotRotation == PivotRotation.Local)
                ? Quaternion.identity : Quaternion.Inverse(Target.transform.rotation);
            float size = HandleUtility.GetHandleSize(hPos) * 0.1f;
            Handles.SphereHandleCap(0, hPos, rotation, size, EventType.Repaint);
            Vector3 newPos = Handles.PositionHandle(hPos, rotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Change Waypoint Tangent");
                wp.tangent = newPos - wp.position;
                Target.m_Waypoints[i] = wp;
                Target.InvalidateDistanceCache();
            }
        }

        void DrawPositionControl(int i)
        {
            CinemachinePath.Waypoint wp = Target.m_Waypoints[i];
            EditorGUI.BeginChangeCheck();
            Handles.color = Target.m_Appearance.pathColor;
            Quaternion rotation = (Tools.pivotRotation == PivotRotation.Local)
                ? Quaternion.identity : Quaternion.Inverse(Target.transform.rotation);
            float size = HandleUtility.GetHandleSize(wp.position) * 0.1f;
            Handles.SphereHandleCap(0, wp.position, rotation, size, EventType.Repaint);
            Vector3 pos = Handles.PositionHandle(wp.position, rotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Move Waypoint");
                wp.position = pos;
                Target.m_Waypoints[i] = wp;
                Target.InvalidateDistanceCache();
            }
        }

        internal static void DrawPathGizmo(CinemachinePathBase path, Color pathColor)
        {
            // Draw the path
            Color colorOld = Gizmos.color;
            Gizmos.color = pathColor;
            float step = 1f / path.m_Resolution;
            Vector3 lastPos = path.EvaluatePosition(path.MinPos);
            Vector3 lastW = (path.EvaluateOrientation(path.MinPos)
                             * Vector3.right) * path.m_Appearance.width / 2;
            for (float t = path.MinPos + step; t <= path.MaxPos + step / 2; t += step)
            {
                Vector3 p = path.EvaluatePosition(t);
                Quaternion q = path.EvaluateOrientation(t);
                Vector3 w = (q * Vector3.right) * path.m_Appearance.width / 2;
                Vector3 w2 = w * 1.2f;
                Vector3 p0 = p - w2;
                Vector3 p1 = p + w2;
                Gizmos.DrawLine(p0, p1);
                Gizmos.DrawLine(lastPos - lastW, p - w);
                Gizmos.DrawLine(lastPos + lastW, p + w);
#if false
                // Show the normals, for debugging
                Gizmos.color = Color.red;
                Vector3 y = (q * Vector3.up) * width / 2;
                Gizmos.DrawLine(p, p + y);
                Gizmos.color = pathColor;
#endif
                lastPos = p;
                lastW = w;
            }
            Gizmos.color = colorOld;
        }

        [DrawGizmo(GizmoType.Active | GizmoType.NotInSelectionHierarchy
             | GizmoType.InSelectionHierarchy | GizmoType.Pickable, typeof(CinemachinePath))]
        static void DrawGizmos(CinemachinePath path, GizmoType selectionType)
        {
            DrawPathGizmo(path, 
                (Selection.activeGameObject == path.gameObject)
                ? path.m_Appearance.pathColor : path.m_Appearance.inactivePathColor);
        }
    }
}
