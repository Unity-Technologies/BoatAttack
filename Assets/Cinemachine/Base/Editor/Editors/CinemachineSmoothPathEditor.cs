using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEditorInternal;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineSmoothPath))]
    internal sealed class CinemachineSmoothPathEditor : BaseEditor<CinemachineSmoothPath>
    {
        private ReorderableList mWaypointList;

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

            // Waypoints
            EditorGUI.BeginChangeCheck();
            mWaypointList.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }

        void SetupWaypointList()
        {
            mWaypointList = new ReorderableList(
                    serializedObject, FindProperty(x => x.m_Waypoints),
                    true, true, true, true);

            mWaypointList.drawHeaderCallback = (Rect rect) =>
                { EditorGUI.LabelField(rect, "Waypoints"); };

            mWaypointList.drawElementCallback
                = (Rect rect, int index, bool isActive, bool isFocused) =>
                { DrawWaypointEditor(rect, index); };

            mWaypointList.onAddCallback = (ReorderableList l) =>
                { InsertWaypointAtIndex(l.index); };
        }

        void DrawWaypointEditor(Rect rect, int index)
        {
            // Needed for accessing string names of fields
            CinemachineSmoothPath.Waypoint def = new CinemachineSmoothPath.Waypoint();
            SerializedProperty element = mWaypointList.serializedProperty.GetArrayElementAtIndex(index);

            float hSpace = 3;
            rect.width -= hSpace; rect.y += 1;
            Vector2 numberDimension = GUI.skin.label.CalcSize(new GUIContent("999"));
            Rect r = new Rect(rect.position, numberDimension);
            if (GUI.Button(r, new GUIContent(index.ToString(), "Go to the waypoint in the scene view")))
            {
                mWaypointList.index = index;
                SceneView.lastActiveSceneView.pivot = Target.EvaluatePosition(index);
                SceneView.lastActiveSceneView.size = 4;
                SceneView.lastActiveSceneView.Repaint();
            }

            float floatFieldWidth = EditorGUIUtility.singleLineHeight * 2f;
            GUIContent rollLabel = new GUIContent("Roll");
            Vector2 labelDimension = GUI.skin.label.CalcSize(rollLabel);
            float rollWidth = labelDimension.x + floatFieldWidth;
            r.x += r.width + hSpace; r.width = rect.width - (r.width + hSpace + rollWidth) - (r.height + hSpace);
            EditorGUI.PropertyField(r, element.FindPropertyRelative(() => def.position), GUIContent.none);

            r.x += r.width + hSpace; r.width = rollWidth;
            float oldWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = labelDimension.x;
            EditorGUI.PropertyField(r, element.FindPropertyRelative(() => def.roll), rollLabel);
            EditorGUIUtility.labelWidth = oldWidth;

            r.x += r.width + hSpace; r.height += 1; r.width = r.height; 
            GUIContent setButtonContent = EditorGUIUtility.IconContent("d_RectTransform Icon");
            setButtonContent.tooltip = "Set to scene-view camera position";
            if (GUI.Button(r, setButtonContent, GUI.skin.label))
            {
                Undo.RecordObject(Target, "Set waypoint");
                CinemachineSmoothPath.Waypoint wp = Target.m_Waypoints[index];
                Vector3 pos = SceneView.lastActiveSceneView.camera.transform.position;
                wp.position = Target.transform.InverseTransformPoint(pos);
                Target.m_Waypoints[index] = wp;
            }
        }

        void InsertWaypointAtIndex(int indexA)
        {
            Vector3 pos = Vector3.right;
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
                    Vector3 delta = Vector3.right;
                    if (indexA > 0)
                        delta = Target.m_Waypoints[indexA].position - Target.m_Waypoints[indexA-1].position;
                    pos = Target.m_Waypoints[indexA].position + delta;
                    roll = Target.m_Waypoints[indexA].roll;
                }
                else
                {
                    // Interpolate
                    pos = Target.transform.InverseTransformPoint(Target.EvaluatePosition(0.5f + indexA));
                    roll = Mathf.Lerp(Target.m_Waypoints[indexA].roll, Target.m_Waypoints[indexB].roll, 0.5f);
                }
            }
            Undo.RecordObject(Target, "Add waypoint");
            var wp = new CinemachineSmoothPath.Waypoint();
            wp.position = pos;
            wp.roll = roll;
            var list = new List<CinemachineSmoothPath.Waypoint>(Target.m_Waypoints);
            list.Insert(indexA + 1, wp);
            Target.m_Waypoints = list.ToArray();
            InternalEditorUtility.RepaintAllViews();
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
                        DrawPositionControl(i); // Waypoint is selected
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

        void DrawPositionControl(int i)
        {
            CinemachineSmoothPath.Waypoint wp = Target.m_Waypoints[i];
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

        [DrawGizmo(GizmoType.Active | GizmoType.NotInSelectionHierarchy
             | GizmoType.InSelectionHierarchy | GizmoType.Pickable, typeof(CinemachineSmoothPath))]
        static void DrawGizmos(CinemachineSmoothPath path, GizmoType selectionType)
        {
            CinemachinePathEditor.DrawPathGizmo(path, 
                (Selection.activeGameObject == path.gameObject)
                ? path.m_Appearance.pathColor : path.m_Appearance.inactivePathColor);
        }
    }
}
