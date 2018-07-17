using UnityEngine;
using System.Collections;
using UnityEditor;

namespace BoatAttack
{
    [CustomEditor(typeof(WaypointGroup))]
    public class WaypointGroupEditor : Editor
    {

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
    }
}
