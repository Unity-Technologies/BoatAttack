using UnityEngine;
using System.Collections;

public class CreateWake : MonoBehaviour {


	private Segment[][] segments;
	private Transform[] boatsT;

	public GameObject[] boatGMs; 
	public int boats;
	public int maxSegments;
	public int[] curSegs;
	public Color[] boatCol;
	

	// Use this for initialization
	void Awake () {
		boatGMs = GameObject.FindGameObjectsWithTag ("boat");

		boats = boatGMs.Length;

		boatsT = new Transform[boats];

		for (int x = 0; x < boatGMs.Length; x++) {
			boatsT[x] = boatGMs[x].transform;
		}


		curSegs = new int[boats];
		segments = new Segment[boats][];

		for (int i = 0; i < segments.Length; i++) {
						segments [i] = new Segment[maxSegments];
				}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		for (int x = 0; x < segments.Length; x++) {
			
			//stuff per boat
			
			for (int i = 0; i < curSegs[x]; i++) {

				//stuff per segment.
				Segment S = segments[x][i];

				S.wake1.y = 0f;
				S.wake2.y = 0f;

				float newVel = Mathf.Clamp(100f-(S.vel-(S.vel/2f)/10), 30f, 100f);
				//Debug.Log(newVel);
				Matrix4x4 m1 = Matrix4x4.TRS(S.wake1, S.segDir, Vector3.one);
				Matrix4x4 m2 = Matrix4x4.TRS(S.wake2, S.segDir, Vector3.one);

				Vector3 offset = new Vector3(1f,0f,-0.5f);

				S.wake1 = m1.MultiplyPoint3x4(offset/newVel);
				S.wake2 = m2.MultiplyPoint3x4(-offset/newVel);

				Matrix4x4 m3 = Matrix4x4.TRS(S.wake1, S.segDir, Vector3.one);
				Matrix4x4 m4 = Matrix4x4.TRS(S.wake2, S.segDir, Vector3.one);

				//Vector3 offset2 = new Vector3(0.1f,0f,0f);

				S.v1 = m3.MultiplyPoint3x4(offset);
				S.v2 = m3.MultiplyPoint3x4(-offset);
				S.v3 = m4.MultiplyPoint3x4(offset);
				S.v4 = m4.MultiplyPoint3x4(-offset);

				//offset the vertices



			}
		}
	}

	public class Segment
	{
		public Vector3 wake1;//center of wake side 1
		public Vector3 wake2;//center of wake side 2

		public Vector3 segPos;//center of wake
		public Quaternion segDir;//direction of wake

		public float vel;
		 
		//Two points two sides
		public Vector3 v1;
		public Vector3 v2;
		public Vector3 v3;
		public Vector3 v4;


		public Segment(Vector3 pos, Quaternion dir, Vector3 w1, Vector3 w2, float v, Vector3 vx1, Vector3 vx2, Vector3 vx3, Vector3 vx4)
		{
			segPos = pos;
			segDir = dir;
			wake1 = w1;
			wake2 = w2;
			vel = v;
			v1 = vx1;
			v2 = vx2;
			v3 = vx3;
			v4 = vx4;
		}
	}

	public void CreateSegment(Vector3 segPos, Quaternion segDir, Transform boatT, float vel, float width, Vector3 offset, int boatID)
	{

		//\\\\\\\\CREATE SEGMENT CODE HERE, TO CREATE VERTEXDATA\\\\\\\ 

		Vector3 w1 = boatT.TransformPoint (new Vector3(1f*width, offset.y, offset.z));
		Vector3 w2 = boatT.TransformPoint (new Vector3(-1f*width, offset.y, offset.z));



		//\\\\\\\\\WRITE DATA TO THE SEGMENT\\\\\\\

		Segment thisSeg = new Segment (segPos, segDir, w1, w2, vel, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero);

		for (int i = curSegs[boatID]-1; i >= 0; i--)
		{
			if (segments [boatID][i] != null) 
			{
				Segment segOld = segments[boatID][i];
				if((i + 1) < maxSegments)segments[boatID][i + 1] = segOld;
			}
		}
		segments[boatID][0] = thisSeg;
		if (curSegs[boatID] < maxSegments)curSegs[boatID]++;
	}


	void OnDrawGizmosSelected()
	{
		if(segments != null)
		{
			for (int x = 0; x < segments.Length; x++) 
			{
				Gizmos.color = boatCol [x];

				for (int i = 0; i < curSegs[x]; i++) {
					Gizmos.DrawSphere(segments [x] [i].v1, 0.2f);
					Gizmos.DrawSphere(segments [x] [i].v2, 0.2f);
					Gizmos.DrawSphere(segments [x] [i].v3, 0.2f);
					Gizmos.DrawSphere(segments [x] [i].v4, 0.2f);
				}
			}
		}
	}
}
