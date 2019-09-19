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
        public int curPoint = 0;
        public int curWP = 0;
        public bool foundPath;
        private int pathPointNum;
        public Engine engine;//cache for AIs engine
        public BoatController controller;

        private float idleTime;
        private Vector3 tempFrom;//nav from position
        private Vector3 tempTo;//nav to position
        private float targetSide;//side of destination, positive on right side, negative on left side
    
        private WaypointGroup.Waypoint[] WPs;
    
    
        // Use this for initialization
        void Start ()
        {
            float delay = WaypointGroup.raceDelay;
			Invoke("GetNearestWP", delay);
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (pathPoint != null)
            {
                if (pathPoint.Length > curPoint && foundPath)
                {
                    if ((Vector3.Distance(transform.position, pathPoint[curPoint])) < 8) // If we are close to the current point on the path get the next
                    {
                        curPoint++; // Move on to next point
                        if (curPoint >= pathPoint.Length)
                            GetNextWP();
                    }
                    
                }
            }

            if (idleTime > 4f)
            {
                Debug.Log($"AI boat {gameObject.name} was stuck, respawing.");
                idleTime = 0f;
                controller.ResetPosition();
            }

            if (engine.velocityMag < 0.1f)
            {
                idleTime += Time.deltaTime;
            }
            else
            {
                idleTime = 0f;
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
            WaypointGroup.Waypoint wp = WaypointGroup.instance.GetClosestWaypoint(transform.position);
            AssignWP(WaypointGroup.instance.GetNextWaypoint(wp));
        }
    
        void GetNextWP()
        {
            AssignWP(WaypointGroup.instance.GetWaypoint(curWP));
        }
    
        void AssignWP(WaypointGroup.Waypoint wp)
        {
            var offset = (Random.value * 2f - 1f) * wp.WPwidth * Vector3.left;
            curWPPos = wp.point + wp.rotation * offset;
            curWP++;
            if (curWP >= WaypointGroup.instance.WPs.Count)
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
                    WaypointGroup.instance.GetWaypoint(curWP).point);
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
