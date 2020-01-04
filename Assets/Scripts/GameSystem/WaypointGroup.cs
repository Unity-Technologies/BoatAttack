using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace BoatAttack
{
	public class WaypointGroup : MonoBehaviour
	{
		public static float RaceDelay = 4f;

		public int waypointGroupId = 0;
		public Color waypointColour = Color.yellow;
		public bool loop = true;
		public float nextWpRadius = 5f;

		public bool raceStarted = false;
		
		[NonSerialized]
		public bool Reverse = false;
		
		[NonSerialized]
		public Matrix4x4[] StartingPositions = new Matrix4x4[4];

		[SerializeField] public List<Waypoint> WPs = new List<Waypoint>();
		private readonly Dictionary<BoxCollider, Waypoint> _triggerPairs = new Dictionary<BoxCollider, Waypoint>();
		private int _curWpId;
		
		public static WaypointGroup Instance { get; private set; }

		private BoxCollider[] _triggers;

		// Use this for initialization
		private void Awake()
		{
			Instance = this;
		}

		public void Setup()
		{
			if (Reverse)
			{
				WPs.Reverse();
				WPs.Insert(0, WPs[WPs.Count - 1]);
				WPs.RemoveAt(WPs.Count - 1);
			}

			var i = 0;
			_triggers = new BoxCollider[WPs.Count];
			foreach (var wp in WPs)
			{
				var obj = new GameObject($"wp{i}_trigger", typeof(BoxCollider))
				{
					hideFlags = HideFlags.HideInHierarchy, tag = gameObject.tag
				};
				obj.transform.SetPositionAndRotation(wp.point, wp.rotation);
				obj.TryGetComponent(out _triggers[i]);
				_triggers[i].isTrigger = true;
				_triggers[i].size = new Vector3(wp.width * 2f, 50f, 0.5f);
				_triggerPairs.Add(_triggers[i], wp);
				wp.Trigger = _triggers[i];
				i++;
			}

			GetStartPositions();
		}

		[Serializable]
		public class Waypoint
		{
			public Vector3 point;
			[FormerlySerializedAs("WPwidth")] public float width;
			public Quaternion rotation = Quaternion.identity;
			public int index;
			public bool isCheckpoint;
			[NonSerialized] public BoxCollider Trigger;

			public Waypoint(Vector3 position, float radius)
			{
				point = position;
				width = radius;
			}
		}

		public Vector3 GetWaypointDestination(int index)
		{
			var wp = GetWaypoint(index);
			return wp.point + (Random.insideUnitSphere * wp.width);
		}

		public Waypoint GetWaypoint(int index) { return WPs[(int)Mathf.Repeat(index, WPs.Count)]; }

		public int GetWaypointIndex(Waypoint wp) { return WPs.IndexOf(wp); }

		public Waypoint GetTriggersWaypoint(BoxCollider trigger)
		{
			return _triggerPairs.TryGetValue(trigger, out var wp) ? wp : null;
		}

		public Waypoint GetNextWaypoint(Waypoint wp)
		{
			return GetWaypoint(WPs.IndexOf(wp) + 1);
		}

		public Waypoint GetPreviousWaypoint(Waypoint wp)
		{
			return GetWaypoint(WPs.IndexOf(wp) - 1);
		}

		public Waypoint GetClosestWaypoint(Vector3 point)
		{
			return WPs.OrderBy(wp => Vector3.Distance(point, wp.point)).ToArray()[0];
		}

		public float GetCurrentSegmentPercentage(Waypoint wp, Vector3 point)
		{
			return GetCurrentSegmentPercentage(WPs.IndexOf(wp), point);
		}
		
		public float GetCurrentSegmentPercentage(int index, Vector3 point)
		{
			index = (int)Mathf.Repeat(index, WPs.Count);
			var a = WPs[index].point;
			var b = GetNextWaypoint(WPs[index]).point;
			
			var pointOnLine = FindNearestPointOnLine(a, b, point);
			var distToCurrent = Vector3.Distance(pointOnLine, a);
			var distToNext = Vector3.Distance(a, b);

			return distToCurrent / distToNext;
		}

		public Vector3 GetClosestPointOnPath(Vector3 point)
		{
			var closest = GetClosestWaypoint(point);
			var next = GetNextWaypoint(closest);
			var previous = GetPreviousWaypoint(closest);

			var nextLine = FindNearestPointOnLine(closest.point, next.point, point);
			var prevLine = FindNearestPointOnLine(closest.point, previous.point, point);

			return Vector3.Distance(point, nextLine) < Vector3.Distance(point, prevLine) ? nextLine : prevLine;
		}
		
		public Matrix4x4 GetClosestPointOnWaypoint(Vector3 point)
		{
			var sortedWPs = WPs.OrderBy(wp => Vector3.Distance(point, wp.point)).ToArray();

			var wpA = sortedWPs[0];
			var wpB = sortedWPs[1];

			
			if (Mathf.Abs(wpA.index - wpB.index) > 1)
				wpB = WPs[(int)Mathf.Repeat(wpA.index + 2, WPs.Count)];

			var respawnPoint = FindNearestPointOnLine(wpA.point, wpB.point, point);
			respawnPoint.y = 0f;
			
			Vector3 lookVec;
			if (wpA.index > wpB.index)
			{
				lookVec = wpA.point - wpB.point;
			}
			else
			{
				lookVec = wpB.point - wpA.point;
			}

			if ((wpA.index == 0 && wpB.index == WPs.Count - 1) || (wpB.index == 0 && wpA.index == WPs.Count - 1)) // if at the loop point we need to reverse the lookVec
				lookVec = -lookVec;
			
			Quaternion facing = Quaternion.LookRotation(Vector3.Normalize(lookVec * (Reverse ? -1f : 1f)), Vector3.up);

			Matrix4x4 matrix = Matrix4x4.TRS(respawnPoint, facing, Vector3.one);
			
			return matrix;
		}

		private Matrix4x4[] GetStartPositions()
		{
			var position = WPs[0].point + Vector3.up;
			var rotation = WPs[0].rotation;
			if(Reverse)
				rotation *= Quaternion.AngleAxis(180f, Vector3.up);
			
			for (int i = 0; i < StartingPositions.Length; i++)
			{
				var pos = new Vector3(i % 2 == 0 ? 3f : -3f, 0f, i * 6f + 4f);
				pos.z = -pos.z;
				
				StartingPositions[i].SetTRS(position, rotation, Vector3.one);
				StartingPositions[i] *= Matrix4x4.Translate(pos);
			}
			
			return StartingPositions;
		}

		private static Vector3 FindNearestPointOnLine(Vector3 start, Vector3 end, Vector3 point)
		{
			var line = (end - start);
			var len = line.magnitude;
			line.Normalize();

			var v = point - start;
			var d = Vector3.Dot(v, line);
			d = Mathf.Clamp(d, 0f, len);
			return start + line * d;
		}

		private void OnDrawGizmos()
		{
			StartingPositions = GetStartPositions();

			var c = Color.green;
			var startBox = new Vector3(2f, 0.1f, 6f);
			foreach (var startPos in StartingPositions)
			{
				Gizmos.matrix = startPos;
				c.a = 0.5f;
				Gizmos.color = c;
				Gizmos.DrawCube(Vector3.zero, startBox);
				c.a = 1f;
				Gizmos.color = c;
				Gizmos.DrawWireCube(Vector3.zero, startBox);
			}
			
		}
	}
}
