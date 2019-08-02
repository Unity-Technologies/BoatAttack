using System;
using UnityEngine;
using System.Collections;
using UnityEditor;

namespace BoatAttack
{
    [CustomEditor(typeof(WaypointGroup))]
    public class WaypointGroupEditor : Editor
    {
        private WaypointGroup WPGroup;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            WaypointGroup WPG = (WaypointGroup)target;

            if (GUILayout.Button("Drop Waypoint"))
            {
                WPG.CreateWaypoint();
            }

            if (GUILayout.Button("Delete Last Waypoint"))
            {
                WPG.DeleteLastWaypoint();
            }

            if (GUILayout.Button("Delete All Waypoints"))
            {
                WPG.DeleteAllWaypoints();
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }

        private void OnSceneGUI()
        {
            WPGroup = (WaypointGroup) target;

            for (int i = 0; i < WPGroup.WPs.Count; i++)
            {
                WaypointGroup.Waypoint wp = WPGroup.WPs[i];
                Handles.color = WPGroup.WaypointColour;

                if (Tools.current == Tool.Move)
                {
                    // Control handle
                    EditorGUI.BeginChangeCheck();
                    var pos = Handles.PositionHandle(wp.point, wp.rotation);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(WPGroup, "Moved Waypoint");
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
                        Undo.RecordObject(WPGroup, "Rotated Waypoint");
                        wp.rotation = rot;
                    }
                }
                else if (Tools.current == Tool.Scale)
                {
                    // Control handle
                    EditorGUI.BeginChangeCheck();
                    var scale = Handles.ScaleSlider(wp.WPwidth, wp.point, (wp.rotation * Vector3.right), wp.rotation, wp.WPwidth, 0.1f);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(WPGroup, "Scaled Waypoint");
                        wp.WPwidth = scale;
                    }
                }

                if (i != WPGroup.WPs.Count - 1)
                {
                    if(i == 0 && WPGroup.reverse)
                        Handles.color = Color.red;
                    Handles.DrawDottedLine(wp.point, WPGroup.WPs[i + 1].point, 4f);
                }
                else
                {
                    if (!WPGroup.reverse)
                        Handles.color = Color.red;
                    Handles.DrawDottedLine(wp.point, WPGroup.WPs[0].point, 4f);
                }
                
            }
        }
    }
}
