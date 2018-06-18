using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour {

	public NavMeshPath navPath;//navigation path;
	private Vector3[] pathPoint = null;
	public Vector3 curDest;
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
	//testing vars
	private Transform targ;
	public Vector3 targetPos;

	private WaypointGroup.Waypoint[] WPs;


	// Use this for initialization
	void Start ()
	{
		engine = GetComponent<Engine> ();// find the engine for the boat

		//CalculatePath (targetPos);//calculate path to target
		GetNextWP();
		InvokeRepeating("CalculatePath", 0f, 0.5f);
	}

	private void Update() {
        if (Vector3.Distance(transform.position, curWPPos) < curWPsize * 2f)
        {
            GetNextWP();
        }
        else if ((Vector3.Distance(transform.position, curDest)) < curWPsize)
        {
            curPoint++;
            if (curPoint < pathPoint.Length)
            {
                curDest = pathPoint[curPoint];
            }
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//\\\\\\\\Get angle to the destination and the side
		Vector3 normDir = curDest - transform.position;
		normDir = normDir.normalized;
		float dot = Vector3.Dot (normDir, transform.forward);
		//float angle = Mathf.Acos (dot) * Mathf.Rad2Deg;
		targetSide = Vector3.Cross (transform.forward, normDir).y;//positive on right side, negative on left side

		float steering = 0;

		if(targetSide > 0f)
				steering = targetSide;
		else 
				steering = targetSide;

		if(steering > 0f)
				engine.TurnRight(Mathf.Clamp01(steering));
		else 
				engine.TurnLeft(Mathf.Clamp01(Mathf.Abs(steering)));

		engine.Accel (dot > 0 ? 1f : 0.25f);
	}

	void GetNextWP()
	{
		WaypointGroup.Waypoint wp = WaypointGroup.Instance.GetWaypoint(curWP);
		curWPsize = wp.WPradius;
		Vector3 offset = Random.insideUnitSphere * curWPsize;
		offset.y = 0f;
		curWPPos = wp.point + offset;
		curWP++;
		if(curWP >= WaypointGroup.Instance.WPs.Count)
			curWP = 0;
	}

	void CalculatePath()
	{
		navPath = new NavMeshPath ();
		NavMesh.CalculatePath (transform.position, curWPPos, 255, navPath);
		if(navPath.status == NavMeshPathStatus.PathComplete)
		{
			pathPoint = navPath.corners;
			curPoint = 0;
			curDest = pathPoint[0];
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		if(curWPPos == Vector3.zero)
			Gizmos.DrawLine(transform.position + (Vector3.up*0.1f), curWPPos);
		Gizmos.color = Color.red;
		if(curDest == Vector3.zero)
			Gizmos.DrawLine(transform.position + (Vector3.up*0.1f), curDest);	
		Gizmos.color = Color.yellow;

		for(int i = 0; i < pathPoint.Length - 1; i++)
		{
			if(i == pathPoint.Length - 1)
				Gizmos.DrawLine(pathPoint[pathPoint.Length - 1], pathPoint[i]);
			else
				Gizmos.DrawLine(pathPoint[i], pathPoint[i+1]);
		}
	}
}
