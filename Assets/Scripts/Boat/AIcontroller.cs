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

        public NavMeshPath navPath; // navigation path
        public Vector3[] pathPoint = null; // list of points along the path
        //private Vector3 curDest; // the current destination point
        private int curWPindex = 0; // the current waypoint index;
        private WaypointGroup.Waypoint curWP;
        public Vector3 curWPPos; // the current WayPoint point
        //public float curWPsize; // the current waypoints size
        public int curPoint = 0;
        public bool foundPath = false;
        private int pathPointNum;
        private Engine engine; // cache the boats engine

        // Use this for initialization
        void Start()
        {
            engine = GetComponent<Engine>(); // find the engine for the boat
            GetNextWP(); // Get the starting waypoint
            InvokeRepeating("CalculatePath", Random.Range(0f, 0.2f), 0.25f);
        }

        // Update is called once per frame
        private void Update()
        {
            if (pathPoint.Length > curPoint && foundPath)
            {
                if (Vector3.Distance(transform.position, pathPoint[pathPoint.Length - 1]) < curWP.WPradius) // If we are close to the waypoint get the next one
                {
                    GetNextWP(); // Get next waypoint
                }
                if ((Vector3.Distance(transform.position, pathPoint[curPoint])) < 2f) // If we are cloase to the current point on the path get the next
                {
                    curPoint++; // Move on to next point
                    if(curPoint >= pathPoint.Length)
                        curPoint = 0;
                }
            }
        }

        // FixedUpdate is called once per physics update
        void FixedUpdate()
        {
            if (foundPath) // Do we have a path to race?
            {
                // Steering
                Vector3 normDir = Vector3.Normalize(pathPoint[curPoint] - transform.position); // get the direction to the cur dest
                float steering = Vector3.Cross(transform.forward, normDir).y;//positive on right side, negative on left side
                engine.Turn(steering); // Set the engines turning
                // Acceleration
                float dot = Vector3.Dot(normDir, transform.forward); // how lined up is the boat to the cur dest
                engine.Accel(dot > 0 ? 1f : 0.25f); // Set the engines accel
            }
        }

        /// <summary>
        /// Gets the next waypoint from the current waypoint group
        /// </summary>
        void GetNextWP()
        {
            curWP = WaypointGroup.Instance.GetWaypoint(curWPindex); // Gets the waypoint
            Vector3 offset = Random.insideUnitSphere * curWP.WPradius * 0.5f; // creates the random offset form the waypoint
            offset.y = 0f; // Zeroes out the offsets 'Y' to be flat
            curWPPos = curWP.point + offset; // Add the offset to the waypoint center
            CalculatePath(); // Update the path with new waypoint
            curWPindex++; // Increments the waypoint
            if (curWPindex >= WaypointGroup.Instance.WPs.Count) // Keeps WPindex looping
                curWPindex = 0;
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
            Gizmos.color = Color.green;

            if (foundPath)
            {
                if (curWP != null)
                    Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f), curWP.point);
                Gizmos.color = Color.red;
                if (pathPoint[curPoint] != Vector3.zero)
                    Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f), pathPoint[curPoint]);
                Gizmos.color = Color.yellow;

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
