using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace BoatAttack.Boat
{
    /// <summary>
    /// AIController is for non-human boats to control the engine of the boat
    /// </summary>
    public class AIcontroller : MonoBehaviour
    {
        public NavMeshPath navPath;//navigation path;
        private Vector3[] pathPoint = null;
        public Vector3 curWPPos;
        public float curWPsize;
        public int curPoint = 0;
        public int curWP = 0;
        public bool foundPath;
        private int pathPointNum;
        public Engine engine;//cache for AIs engine
    
        private Vector3 tempFrom;//nav from position
        private Vector3 tempTo;//nav to position
        private float targetSide;//side of destination, positive on right side, negative on left side
    
        private WaypointGroup.Waypoint[] WPs;
    
    
        // Use this for initialization
        void Start ()
        {
            engine = GetComponent<Engine> ();// find the engine for the boat
    
            //CalculatePath (targetPos);//calculate path to target
            float delay = WaypointGroup.Instance.raceDelay;
    
            Invoke("GetNearestWP", delay);
            
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (pathPoint != null)
            {
                if (pathPoint.Length > curPoint && foundPath)
                {
/*                    if (Vector3.Distance(transform.position, pathPoint[pathPoint.Length - 1]) <
                        WaypointGroup.Instance.GetWaypoint(curWP).WPradius * 2) // If we are close to the waypoint get the next one
                    {
                        GetNextWP(); // Get next waypoint
                    }*/

                    if ((Vector3.Distance(transform.position, pathPoint[curPoint])) < 8) // If we are close to the current point on the path get the next
                    {
                        curPoint++; // Move on to next point
                        if (curPoint >= pathPoint.Length)
                            GetNextWP();
                    }
                    
                }
            }
        }
        
        // Update is called once per frame
        void FixedUpdate () 
        {
            if (pathPoint != null && pathPoint.Length > curPoint)
            {
                //\\\\\\\\Get angle to the destination and the side
                Vector3 normDir = pathPoint[curPoint] - transform.position;
                normDir = normDir.normalized;
                float dot = Vector3.Dot(normDir, transform.forward);
                //float angle = Mathf.Acos (dot) * Mathf.Rad2Deg;
                targetSide = Vector3.Cross(transform.forward, normDir).y;//positive on right side, negative on left side

                engine.Turn(Mathf.Clamp(targetSide, -1.0f, 1.0f));
                engine.Accel(dot > 0 ? 1f : 0.25f);
            }
        }
    
        void GetNearestWP()
        {
            WaypointGroup.Waypoint wp = WaypointGroup.Instance.GetClosestWaypoint(transform.position);
            if (Vector3.Dot(wp.point - transform.position, transform.forward) < 0)
                AssignWP(WaypointGroup.Instance.GetNextWaypoint(wp));
            else
                AssignWP(WaypointGroup.Instance.GetClosestWaypoint(transform.position));
        }
    
        void GetNextWP()
        {
            AssignWP(WaypointGroup.Instance.GetWaypoint(curWP));
        }
    
        void AssignWP(WaypointGroup.Waypoint wp)
        {
            curWPsize = wp.WPradius;
            Vector3 offset = Random.insideUnitSphere * curWPsize;
            offset.y = 0f;
            curWPPos = wp.point + offset;
            curWP++;
            if (curWP >= WaypointGroup.Instance.WPs.Count)
                curWP = 0;
            CalculatePath();
        }

        /// <summary>
        /// Calculates a new path to the next waypoint
        /// </summary>
        void CalculatePath()
        {
            navPath = new NavMeshPath(); // New nav path
            NavMesh.CalculatePath(transform.position, curWPPos, 255, navPath);
            if (navPath.status == NavMeshPathStatus.PathComplete) // if the path is good(complete) use it
            {
                pathPoint = navPath.corners;
                curPoint = 1;
                foundPath = true;
            }
            else if(navPath == null || navPath.status == NavMeshPathStatus.PathInvalid) // if the path is bad, we havent found a path
            {
                foundPath = false;
            }
        }

        // Draw some helper gizmos
        void OnDrawGizmosSelected()
        {
            var c = Color.green;
            c.a = 0.5f;
            Gizmos.color = c;
            
            if (foundPath)
            {
                Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f),
                    WaypointGroup.Instance.GetWaypoint(curWP).point);
                Gizmos.DrawSphere(curWPPos, 1);

                c = Color.red;
                Gizmos.color = c;
                if (pathPoint[curPoint] != Vector3.zero)
                    Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f), pathPoint[curPoint]);
                c = Color.yellow;
                Gizmos.color = c;

                for (int i = 0; i < pathPoint.Length - 1; i++)
                {
                    if (i == pathPoint.Length - 1)
                        Gizmos.DrawLine(pathPoint[pathPoint.Length - 1], pathPoint[i]);
                    else
                        Gizmos.DrawLine(pathPoint[i], pathPoint[i + 1]);
                }
            }
        }
    }
}
