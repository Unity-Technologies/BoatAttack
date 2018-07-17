using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

namespace BoatAttack
{
    /// <summary>
    /// Very barebones waypoint system
    /// </summary>
    [Serializable]
    public class WaypointGroup : MonoBehaviour
    {
        public static WaypointGroup Instance = null;
        public Color waypointColour = Color.yellow;
        public bool loop = false;
        public bool reverse = false;
        public float nextWPradius = 5f;

        [SerializeField] public List<Waypoint> WPs = new List<Waypoint>();
        private int curWpID;

        // Use this for initialization
        void Awake()
        {
            Instance = this;
            if(reverse)
                WPs.Reverse();
        }

        [Serializable]
        public class Waypoint
        {
            public Vector3 point;
            public float WPradius;
            public Waypoint(Vector3 position, float radius)
            {
                point = position;
                WPradius = radius;
            }
        }


        public void CreateWaypoint()
        {
            Vector3 Pos = gameObject.transform.position;
            float Rad = nextWPradius;
            Waypoint WP = new Waypoint(Pos, Rad);
            WPs.Add(WP);
            curWpID++;
        }

        public Vector3 GetWaypointDestination(int index)
        {
            Waypoint wp;
            if (index > 0 && index < WPs.Count - 1)
                wp = WPs[index];
            else
                wp = null;
            return wp.point + (Random.insideUnitSphere * wp.WPradius);
        }

        public Waypoint GetWaypoint(int index)
        {
            return WPs[index];
        }

        public void DeleteLastWaypoint()
        {
            WPs.RemoveAt(curWpID);
            curWpID--;
        }

        public void DeleteAllWaypoints()
        {
            WPs.Clear();
            curWpID = 0;
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = waypointColour;
            Gizmos.DrawSphere(gameObject.transform.position, nextWPradius);

            for (int i = 0; i < WPs.Count; i++)
            {
                Gizmos.DrawWireSphere(WPs[i].point, WPs[i].WPradius);
#if UnityEditor
                UnityEditor.Handles.Label(WPs[i].point, "WP " + WPs[i].WPnumber);
#endif
                if (i < WPs.Count - 1)
                {
                    Gizmos.DrawLine(WPs[i].point, WPs[i + 1].point);
                }
                else if (loop)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(WPs[i].point, WPs[0].point);
                }
            }
        }
    }
}
