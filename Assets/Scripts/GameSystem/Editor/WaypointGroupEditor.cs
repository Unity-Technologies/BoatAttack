using System;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace BoatAttack
{
    [CustomEditor(typeof(WaypointGroup))]
    public class WaypointGroupEditor : Editor
    {
        private WaypointGroup _wpGroup;
        private SerializedProperty _waypoints;
        private ReorderableList _waypointList;
        private int _selectedWp = -1;
        private bool _wpHeaderBool;

        private void OnEnable()
        {
            if(_wpGroup == null)
                _wpGroup = (WaypointGroup) target;

            _waypoints = serializedObject.FindProperty("WPs");
            _waypointList = new ReorderableList(serializedObject, _waypoints)
            {
                drawElementCallback = DrawElementCallback,
                drawHeaderCallback = rect => { EditorGUI.LabelField(rect, "Waypoints"); },
                onSelectCallback = list => { _selectedWp = list.index; },
                elementHeightCallback = index => EditorGUI.GetPropertyHeight(_waypoints.GetArrayElementAtIndex(index))
            };
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var prop = _waypointList.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, prop);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawPropertiesExcluding(serializedObject, "WPs");

            EditorGUI.BeginChangeCheck();
            _wpHeaderBool = EditorGUILayout.BeginFoldoutHeaderGroup(_wpHeaderBool, "Waypoint List");
            if (_wpHeaderBool)
            {
                EditorGUILayout.Space();
                _waypointList.DoLayoutList();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            if (EditorGUI.EndChangeCheck())
            {
                var len = _wpGroup.CalculateTrackDistance();
                _wpGroup.length = len;
            }
            serializedObject.ApplyModifiedProperties();
        }

        private void OnSceneGUI()
        {
            if(_wpGroup == null)
                _wpGroup = (WaypointGroup) target;

            for (var i = 0; i < _wpGroup.WPs.Count; i++)
            {
                var wp = _wpGroup.WPs[i];
                Handles.color = _wpGroup.waypointColour;

                #region Control

                if (_selectedWp == i)
                {
                    if (Tools.current == Tool.Move)
                    {
                        // Control handle
                        EditorGUI.BeginChangeCheck();
                        var pos = Handles.PositionHandle(wp.point, wp.rotation);
                        if (EditorGUI.EndChangeCheck())
                        {
                            Undo.RecordObject(_wpGroup, "Moved Waypoint");
                            pos = new Vector3((float)Math.Round(pos.x, 2), (float)Math.Round(pos.y, 2), (float)Math.Round(pos.z, 2));
                            wp.point = pos;
                        }
                    }
                    else if (Tools.current == Tool.Rotate)
                    {
                        // Control handle
                        EditorGUI.BeginChangeCheck();
                        var rot = Handles.RotationHandle(wp.rotation, wp.point);
                        if (EditorGUI.EndChangeCheck())
                        {
                            Undo.RecordObject(_wpGroup, "Rotated Waypoint");
                            wp.rotation = Quaternion.Euler(0f, Mathf.Round(rot.eulerAngles.y), 0f);
                        }
                    }
                    else if (Tools.current == Tool.Scale)
                    {
                        // Control handle
                        EditorGUI.BeginChangeCheck();
                        var scale = Handles.ScaleSlider(wp.width, wp.point, (wp.rotation * Vector3.right),
                            wp.rotation, wp.width, 0.1f);
                        if (EditorGUI.EndChangeCheck())
                        {
                            Undo.RecordObject(_wpGroup, "Scaled Waypoint");
                            wp.width = scale;
                        }
                    }
                }

                #endregion

                #region Visualization

                { // Draw lines
                    var a = wp;
                    var b = i != _wpGroup.WPs.Count - 1 ? _wpGroup.WPs[i + 1] : _wpGroup.WPs[0];

                    Handles.DrawDottedLine(a.point, b.point, 4f);

                    var aMatrix = Matrix4x4.Rotate(a.rotation);
                    var aW = Vector3.right * a.width;
                    Vector3 a1 = aMatrix * aW;
                    Vector3 a2 = aMatrix * -aW;

                    var bMatrix = Matrix4x4.Rotate(b.rotation);
                    var bW = Vector3.right * b.width;
                    Vector3 b1 = bMatrix * bW;
                    Vector3 b2 = bMatrix * -bW;

                    Handles.DrawLine(a.point + a1, b.point + b1);
                    Handles.DrawLine(a.point + a2, b.point + b2);

                    var col = _wpGroup.waypointColour;
                    col.a = 0.05f;
                    Handles.color = col;
                    Handles.DrawAAConvexPolygon(a.point + a1,
                        a.point + a2,
                        b.point + b2,
                        b.point + b1);
                }

                { // Draw points
                    var p = wp.point;
                    var r = wp.rotation;
                    var w = wp.width;

                    if (i == 0) // Draw Start/Finish line
                    {
                        Handles.color = new Color(0f, 1f, 0f, 0.5f);
                    }
                    else if (wp.isCheckpoint) // Draw Checkpoints
                    {
                        Handles.color = new Color(0f, 0f, 1f, 0.5f);
                    }
                    DrawRectangle(p, r, new Vector2(w, 1f));
                }

                #endregion

            }
        }

        private void DrawRectangle(Vector3 center, Quaternion rotation, Vector2 size)
        {
            var m = Matrix4x4.Rotate(rotation);
            Vector3 a = m * new Vector3(size.x, 0f, size.y);
            Vector3 b = m * new Vector3(size.x, 0f, -size.y);
            Handles.DrawAAConvexPolygon(center + a, center + b, center - a, center - b);
        }
    }
}
