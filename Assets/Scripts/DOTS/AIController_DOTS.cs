using BoatAttack;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;


class PathData
{
	public Vector3[] pathPoints;
	public int currentPathPoint;
	public WaypointGroup.Waypoint currentWaypoint;
	public bool foundPath;
	public bool nearEnd;
	public Vector3 storedPosition;
};

public class AIController_DOTS : MonoBehaviour
{
	static AIController_DOTS main;

	public float nearDistanceSquared = 8f;

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

	private void Update()
	{
		foreach (var path in paths)
		{
			if (path.Value.nearEnd || !path.Value.foundPath)
				CalculatePath(path.Value);
		}
	}

	public static void Register(Entity entity, Vector3 pos)
	{
		if (main.paths.ContainsKey(entity))
			return;

		PathData data = new PathData();
		data.currentWaypoint = WaypointGroup.instance.GetClosestWaypoint(pos);
		data.storedPosition = pos;
		data.nearEnd = true;

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
		if (!paths.TryGetValue(entity, out data) || data.pathPoints == null)
			return;

		data.storedPosition = pos; //Store position for navmesh calculations

		if (data.currentPathPoint < data.pathPoints.Length && data.foundPath)
		{
			//Get angle to the destination and the side
			Vector3 normDir = data.pathPoints[data.currentPathPoint] - (Vector3)pos;
			normDir = normDir.normalized;

			var forward = math.forward(rot);
			float dot = Vector3.Dot(normDir, forward);

			//float angle = Mathf.Acos (dot) * Mathf.Rad2Deg;
			float targetSide = Vector3.Cross(forward, normDir).y;//positive on right side, negative on left side

			steering = Mathf.Clamp(targetSide, -1.0f, 1.0f);
			throttle = dot > 0 ? 1f : 0.25f;


			if (Vector3.Distance(pos, data.pathPoints[data.currentPathPoint]) < nearDistanceSquared) // If we are close to the current point on the path get the next
			{
				//Debug.Log($"Distance: {Vector3.Distance(pos, data.pathPoints[data.currentPathPoint])} SqrMag: {(data.storedPosition - data.pathPoints[data.currentPathPoint]).sqrMagnitude}");

				data.currentPathPoint++; // Move on to next point
				if (data.currentPathPoint >= data.pathPoints.Length)
					data.nearEnd = true;
			}
		}
	}

	void CalculatePath(PathData data)
	{
		var wp = WaypointGroup.instance.GetNextWaypoint(data.currentWaypoint);
		var offset = (UnityEngine.Random.value * 2f - 1f) * wp.WPwidth * Vector3.left;
		var curWPPos = wp.point + wp.rotation * offset;

		var navPath = new NavMeshPath(); // New nav path
		NavMesh.CalculatePath(data.storedPosition, curWPPos, 255, navPath);

		if (navPath.status == NavMeshPathStatus.PathComplete) // if the path is good(complete) use it
		{
			data.currentWaypoint = wp;
			data.pathPoints = navPath.corners;
			data.currentPathPoint = 1;
			data.foundPath = true;
			data.nearEnd = false;
		}
		else if (navPath == null || navPath.status == NavMeshPathStatus.PathInvalid) // if the path is bad, we havent found a path
		{
			data.foundPath = false;
		}
	}
}
