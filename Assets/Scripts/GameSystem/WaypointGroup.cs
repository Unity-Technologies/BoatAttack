using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using System.Linq;
using UnityEngine.Serialization;

namespace BoatAttack
{
	[Serializable]
	public class WaypointGroup : MonoBehaviour
	{
		public static WaypointGroup Instance = null;
		public int WaypointGroupID = 0;
		public Color WaypointColour = Color.yellow;
		public bool Loop = false;
		public float NextWPradius = 5f;

		public float raceDelay = 4f;
		public bool raceStarted = false;
		
		[NonSerialized]
		public bool reverse = false;
		
		[NonSerialized]
		public Matrix4x4[] startingPositons = new Matrix4x4[4];

		[SerializeField] public List<Waypoint> WPs = new List<Waypoint>();
		private int curWpID;

		// Use this for initialization
		void Awake()
		{
			Instance = this;
		}

		public void Setup()
		{
			if (reverse)
			{
				WPs.Reverse();
				WPs.Insert(0, WPs[WPs.Count - 1]);
				WPs.RemoveAt(WPs.Count - 1);
			}

			GetStartPositions();
		}

		[Serializable]
		public class Waypoint
		{
			public Vector3 point;
			[FormerlySerializedAs("WPradius")] public float WPwidth;
			public Quaternion rotation = Quaternion.identity;
			public int WPnumber;
			public int WPgroup;

			public Waypoint(Vector3 position, float radius, int ID, int group)
			{

				point = position;
				WPwidth = radius;
				WPnumber = ID;
				WPgroup = group;
			}
		}


		public void CreateWaypoint()
		{
			Vector3 Pos = gameObject.transform.position;
			float Rad = NextWPradius;
			int ID = curWpID;

			Waypoint WP = new Waypoint(Pos, Rad, ID, WaypointGroupID);

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
			return wp.point + (Random.insideUnitSphere * wp.WPwidth);
		}

		public Waypoint GetWaypoint(int index)
		{
			return WPs[index];
		}
		
		public Waypoint GetNextWaypoint(Waypoint wp)
		{
			var index = WPs.IndexOf(wp);
			index = (int)Mathf.Repeat(index + 1, WPs.Count);
			return GetWaypoint(index);
		}

		public Waypoint GetClosestWaypoint(Vector3 point)
		{
			Waypoint closest = null;
			Waypoint[] sortedWPs = WPs.OrderBy(wp => Vector3.Distance(point, wp.point)).ToArray();

			if (sortedWPs[0].WPnumber < sortedWPs[1].WPnumber && !reverse)
				closest = sortedWPs[1];
			else
				closest = sortedWPs[0];

			return closest;
		}

		public Matrix4x4[] GetStartPositions()
		{
			var position = WPs[0].point;
			var rotation = WPs[0].rotation;
			if(reverse)
				rotation *= Quaternion.AngleAxis(180f, Vector3.up);
			
			for (int i = 0; i < startingPositons.Length; i++)
			{
				var pos = new Vector3(i % 2 == 0 ? 3f : -3f, 0f, i * 6f + 4f);
				pos.z = -pos.z;
				
				startingPositons[i].SetTRS(position, rotation, Vector3.one);
				startingPositons[i] *= Matrix4x4.Translate(pos);
			}
			
			return startingPositons;
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

		void OnDrawGizmos()
		{
			var c = WaypointColour;

			for (int i = 0; i < WPs.Count; i++)
			{
				Gizmos.matrix = Matrix4x4.TRS(WPs[i].point, WPs[i].rotation, Vector3.one);
				var cube = new Vector3(WPs[i].WPwidth * 2f, 4f, 0.5f);
				// Fill
				c.a = 0.5f;
				Gizmos.color = c;
				Gizmos.DrawCube(Vector3.zero, cube);
				// Outline
				c.a = 1f;
				Gizmos.color = c;
				Gizmos.DrawWireCube(Vector3.zero, cube);
			}

			startingPositons = GetStartPositions();

			c = Color.green;
			var startBox = new Vector3(2f, 0.1f, 6f);
			foreach (var startPos in startingPositons)
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
