using System;
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
        [NonSerialized] public NavMeshPath NavPath;// navigation path
        private Vector3[] _pathPoint;
        private Vector3 _curWpPos;
        private int _curPoint;
        [NonSerialized] public int CurWp;
        private bool _foundPath;
        private int _pathPointNum;

        private float _idleTime;
        private Vector3 _tempFrom;//nav from position
        private Vector3 _tempTo;//nav to position
        private float _targetSide;//side of destination, positive on right side, negative on left side

        private WaypointGroup.Waypoint[] _wPs;

        [Header("Auto Start")]
        [Tooltip("레이스 시작 없이도 자동으로 움직이기 시작합니다")]
        public bool autoStart = false;
        
        [Tooltip("자동 시작 대기 시간 (초)")]
        public float autoStartDelay = 1f;

        private void Start ()
        {
            RaceManager.raceStarted += StartRace;
            
            // 자동 시작 모드일 때
            if (autoStart)
            {
                StartCoroutine(AutoStartCoroutine());
            }
        }

        private IEnumerator AutoStartCoroutine()
        {
            // WaypointGroup이 준비될 때까지 대기
            while (WaypointGroup.Instance == null)
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(autoStartDelay);
            
            // 레이스가 시작되지 않았어도 움직이기 시작
            if (!RaceManager.RaceStarted)
            {
                Debug.Log($"[AiController] {gameObject.name}: 자동 시작 모드로 움직이기 시작");
                StartRace(true);
            }
        }

        private void StartRace(bool start)
        {
            if (WaypointGroup.Instance == null)
            {
                Debug.LogWarning($"[AiController] {gameObject.name}: WaypointGroup.Instance가 null입니다!");
                return;
            }
            
            AssignWp(WaypointGroup.Instance.GetWaypoint(0));
            InvokeRepeating(nameof(CalculatePath), 1f, 1f);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            RaceManager.raceStarted -= StartRace;
        }

        private void LateUpdate()
        {
            if(NavPath?.status == NavMeshPathStatus.PathInvalid)
                CalculatePath();

            if (_pathPoint != null &&_pathPoint.Length > _curPoint && _foundPath)
            {
                // If we are close to the current point on the path get the next
                if (Vector3.Distance(transform.position, _pathPoint[_curPoint]) < 8)
                {
                    _curPoint++; // Move on to next point
                    if (_curPoint >= _pathPoint.Length)
                        AssignWp(WaypointGroup.Instance.GetWaypoint(CurWp));
                }
            }

            if(RaceManager.RaceStarted)
            {
                if (_idleTime > 3f) // if been idle for 3 seconds assume AI is stuck
                {
                    Debug.Log($"AI boat {gameObject.name} was stuck, re-spawning.");
                    _idleTime = 0f;
                    controller.ResetPosition();
                }
                _idleTime = (engine.VelocityMag < 0.15f || transform.up.y < 0) ? _idleTime + Time.deltaTime : _idleTime = 0f;
            }
        }

        // Update is called once per frame
        private void FixedUpdate ()
        {
            if (_pathPoint == null || _pathPoint.Length <= _curPoint) return;
            //\\\\\\\\Get angle to the destination and the side
            var normDir = _pathPoint[_curPoint] - transform.position;
            normDir = normDir.normalized;
            var dot = Vector3.Dot(normDir, transform.forward);
            _targetSide = Vector3.Cross(transform.forward, normDir).y;//positive on right side, negative on left side

            engine.Turn(Mathf.Clamp(_targetSide, -1.0f, 1.0f));
            engine.Accelerate(dot > 0 ? 1f : 0.25f);
        }

        private void AssignWp(WaypointGroup.Waypoint wp)
        {
            var offset = (Random.value * 2f - 1f) * wp.width * Vector3.left;
            _curWpPos = wp.point + wp.rotation * offset;
            CurWp = CurWp >= WaypointGroup.Instance.WPs.Count ? 0 : CurWp + 1;
            CalculatePath();
        }

        /// <summary>
        /// Calculates a new path to the next waypoint
        /// </summary>
        private void CalculatePath()
        {
            NavPath = new NavMeshPath(); // New nav path
            NavMesh.CalculatePath(transform.position, _curWpPos, 255, NavPath);
            if (NavPath.status == NavMeshPathStatus.PathComplete) // if the path is good(complete) use it
            {
                _pathPoint = NavPath.corners;
                _curPoint = 1;
                _foundPath = true;
            }
            else if(NavPath == null || NavPath.status == NavMeshPathStatus.PathInvalid) // if the path is bad, we haven't found a path
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
                WaypointGroup.Instance.GetWaypoint(CurWp).point);
            Gizmos.DrawSphere(_curWpPos, 1);

            c = Color.red;
            Gizmos.color = c;
            if (_pathPoint[_curPoint] != Vector3.zero)
                Gizmos.DrawLine(transform.position + (Vector3.up * 0.1f), _pathPoint[_curPoint]);
        }

        private void OnDrawGizmos()
        {
            var c = Color.yellow;
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
