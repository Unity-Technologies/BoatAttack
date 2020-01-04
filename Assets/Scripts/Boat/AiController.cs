using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace BoatAttack
{
    /// <summary>
    /// AIController is for non-human boats to control the engine of the boat
    /// </summary>
    public class AiController : BaseController
    {
        public NavMeshPath navPath;//navigation path;
        private Vector3[] _pathPoint;
        private Vector3 _curWpPos;
        private int _curPoint;
        private int _curWp;
        private bool _foundPath;
        private int _pathPointNum;

        private float _idleTime;
        private Vector3 _tempFrom;//nav from position
        private Vector3 _tempTo;//nav to position
        private float _targetSide;//side of destination, positive on right side, negative on left side
    
        private WaypointGroup.Waypoint[] _wPs;

        public AiController()
        {
            _curWp = 0;
        }

        // Use this for initialization
        IEnumerator Start ()
        {
            float delay = WaypointGroup.RaceDelay;
            yield return new WaitForSeconds(delay);
            AssignWp(WaypointGroup.Instance.GetWaypoint(0));
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (_pathPoint != null)
            {
                if (_pathPoint.Length > _curPoint && _foundPath)
                {
                    if ((Vector3.Distance(transform.position, _pathPoint[_curPoint])) < 8) // If we are close to the current point on the path get the next
                    {
                        _curPoint++; // Move on to next point
                        if (_curPoint >= _pathPoint.Length)
                            GetNextWp();
                    }
                    
                }
            }

            if (_idleTime > 4f)
            {
                Debug.Log($"AI boat {gameObject.name} was stuck, re-spawning.");
                _idleTime = 0f;
                controller.ResetPosition();
            }

            if (engine.VelocityMag < 0.1f)
            {
                _idleTime += Time.deltaTime;
            }
            else
            {
                _idleTime = 0f;
            }
        }
        
        // Update is called once per frame
        private void FixedUpdate () 
        {
            if (_pathPoint != null && _pathPoint.Length > _curPoint)
            {
                //\\\\\\\\Get angle to the destination and the side
                var normDir = _pathPoint[_curPoint] - transform.position;
                normDir = normDir.normalized;
                var dot = Vector3.Dot(normDir, transform.forward);
                _targetSide = Vector3.Cross(transform.forward, normDir).y;//positive on right side, negative on left side

                engine.Turn(Mathf.Clamp(_targetSide, -1.0f, 1.0f));
                engine.Accelerate(dot > 0 ? 1f : 0.25f);
            }
        }

        private void GetNextWp()
        {
            AssignWp(WaypointGroup.Instance.GetWaypoint(_curWp));
        }

        private void AssignWp(WaypointGroup.Waypoint wp)
        {
            var offset = (Random.value * 2f - 1f) * wp.width * Vector3.left;
            _curWpPos = wp.point + wp.rotation * offset;
            _curWp++;
            if (_curWp >= WaypointGroup.Instance.WPs.Count)
                _curWp = 0;
            CalculatePath();
        }

        /// <summary>
        /// Calculates a new path to the next waypoint
        /// </summary>
        private void CalculatePath()
        {
            navPath = new NavMeshPath(); // New nav path
            NavMesh.CalculatePath(transform.position, _curWpPos, 255, navPath);
            if (navPath.status == NavMeshPathStatus.PathComplete) // if the path is good(complete) use it
            {
                _pathPoint = navPath.corners;
                _curPoint = 1;
                _foundPath = true;
            }
            else if(navPath == null || navPath.status == NavMeshPathStatus.PathInvalid) // if the path is bad, we haven't found a path
            {
                _foundPath = false;
            }
        }

        // Draw some helper gizmos
        private void OnDrawGizmosSelected()
        {
            var c = Color.green;
            c.a = 0.5f;
            Gizmos.color = c;

            if (!_foundPath) return;
            
            Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f),
                WaypointGroup.Instance.GetWaypoint(_curWp).point);
            Gizmos.DrawSphere(_curWpPos, 1);

            c = Color.red;
            Gizmos.color = c;
            if (_pathPoint[_curPoint] != Vector3.zero)
                Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f), _pathPoint[_curPoint]);
            c = Color.yellow;
            Gizmos.color = c;

            for (var i = 0; i < _pathPoint.Length - 1; i++)
            {
                if (i == _pathPoint.Length - 1)
                    Gizmos.DrawLine(_pathPoint[_pathPoint.Length - 1], _pathPoint[i]);
                else
                    Gizmos.DrawLine(_pathPoint[i], _pathPoint[i + 1]);
            }
        }
    }
}
