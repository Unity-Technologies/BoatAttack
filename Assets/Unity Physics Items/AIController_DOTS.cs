using BoatAttack;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

class PathData
{
	public Vector3[] pathPoint;
	public int curPoint;
	public int curWP;
	public bool foundPath;
};

public class AIController_DOTS : MonoBehaviour
{
	static AIController_DOTS main;

	Dictionary<Entity, PathData> paths;


	private void Awake()
	{
		if (main != null && main != this)
		{
			Destroy(this);
			return;
		}

		main = this;
		paths = new Dictionary<Entity, PathData>();
	}

	public static void Register(Entity entity)
	{
		if (main.paths.ContainsKey(entity))
			return;

		PathData data = new PathData();

		main.paths.Add(entity, data);
	}

	public static void GetInputs(Entity entity, float3 pos, quaternion rot, out float throttle, out float steering)
	{
		main.GetInputsInternal(entity, pos, rot, out throttle, out steering);
	}

	void GetInputsInternal(Entity entity, float3 pos, quaternion rot, out float throttle, out float steering)
	{
		throttle = steering = 0;

		//Do we have data?
		PathData data;
		if (!paths.TryGetValue(entity, out data))
			return;

		if (data.pathPoint == null)
		{
			WaypointGroup.Waypoint wp = WaypointGroup.instance.GetClosestWaypoint(pos);
			CalculatePath(WaypointGroup.instance.GetNextWaypoint(wp), data, pos);
		}
		else if (data.pathPoint.Length > data.curPoint && data.foundPath)
		{
			if ((Vector3.Distance(pos, data.pathPoint[data.curPoint])) < 8) // If we are close to the current point on the path get the next
			{
				data.curPoint++; // Move on to next point
				if (data.curPoint >= data.pathPoint.Length)
					CalculatePath(WaypointGroup.instance.GetWaypoint(data.curWP), data, pos);
			}
		}

		if (data.pathPoint != null && data.pathPoint.Length > data.curPoint)
		{
			//Get angle to the destination and the side
			Vector3 normDir = data.pathPoint[data.curPoint] - (Vector3)pos;
			normDir = normDir.normalized;

			var forward = math.forward(rot);
			float dot = Vector3.Dot(normDir, forward);

			//float angle = Mathf.Acos (dot) * Mathf.Rad2Deg;
			float targetSide = Vector3.Cross(forward, normDir).y;//positive on right side, negative on left side

			steering = Mathf.Clamp(targetSide, -1.0f, 1.0f);
			throttle = dot > 0 ? 1f : 0.25f;
		}
	}

	void CalculatePath(WaypointGroup.Waypoint wp, PathData data, float3 pos)
	{
		var offset = (UnityEngine.Random.value * 2f - 1f) * wp.WPwidth * Vector3.left;
		var curWPPos = wp.point + wp.rotation * offset;

		data.curWP++;
		if (data.curWP >= WaypointGroup.instance.WPs.Count)
			data.curWP = 0;

		var navPath = new NavMeshPath(); // New nav path
		NavMesh.CalculatePath(pos, curWPPos, 255, navPath);

		if (navPath.status == NavMeshPathStatus.PathComplete) // if the path is good(complete) use it
		{
			data.pathPoint = navPath.corners;
			data.curPoint = 1;
			data.foundPath = true;
		}
		else if (navPath == null || navPath.status == NavMeshPathStatus.PathInvalid) // if the path is bad, we havent found a path
		{
			data.foundPath = false;
		}
	}
}
