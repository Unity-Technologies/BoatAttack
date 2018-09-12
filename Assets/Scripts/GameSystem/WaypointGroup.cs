using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using System.Linq;

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
		public bool reverse = false;

		[SerializeField] public List<Waypoint> WPs = new List<Waypoint>();
		private int curWpID;

		// Use this for initialization
		void Awake()
		{
			Instance = this;
			Invoke("StartRace", raceDelay);
		}

		public void StartRace()
		{
			raceStarted = true;
		}

		[Serializable]
		public class Waypoint
		{
			public Vector3 point;
			public float WPradius;
			public int WPnumber;
			public int WPgroup;

			public Waypoint(Vector3 position, float radius, int ID, int group)
			{

				point = position;
				WPradius = radius;
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
			return wp.point + (Random.insideUnitSphere * wp.WPradius);
		}

		public Waypoint GetWaypoint(int index)
		{
			return WPs[index];
		}
		
		public Waypoint GetNextWaypoint(Waypoint wp)
		{
			var index = WPs.IndexOf(wp);
			index = (int)Mathf.Repeat(index + 1, WPs.Count);
			return WPs[index];
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
			Gizmos.color = WaypointColour;

			Gizmos.DrawSphere(gameObject.transform.position, NextWPradius);

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
				else if (Loop)
				{
					Gizmos.color = Color.red;
					Gizmos.DrawLine(WPs[i].point, WPs[0].point);
				}
			}
		}
	}
}
