using UnityEngine;
using System.Collections;

public class CreateTrail : MonoBehaviour 
{
	
	public float startWidth = 0.5f;
	public int maxCount = 5;
	public float Height = 0f;
	public float spreadSpeed = 1f;

	private bool addSeg = false;
	private int curCount = 0;
	private Vector3[] verts = new Vector3[8];
	private Vector3 iPos;
	private Vector3 iiPos;

	private bool init = false;
	public class Segment
	{
		public Vector3 vertex1;//position of vertex1
		public Vector3 vertex2;//position of vertex2
		public Vector2 vertexUV1;//uv coordinates for vertex no1
		public Vector2 vertexUV2;//uv coordinates for vertex no2
		public Vector3 normal;//normal direction

		public Segment(Vector3 v1, Vector3 v2, Vector2 uv1, Vector2 uv2, Vector3 norm)
		{
			vertex1 = v1;
			vertex2 = v2;
			normal = norm;
			vertexUV1 = uv1;
			vertexUV2 = uv2;
		}
	}


	IEnumerator Timer ()
	{
		Debug.Log("did it");
		bool addSeg = true;
		yield return new WaitForSeconds(2f);
	}

	//move class
	/*
	IEnumerator Move ()
	{
		for (int f = 0; f <= curCount-2; f++) 
		{
			//Vector3 v = verts[f+2];
			verts[f+2] += transform.InverseTransformPoint(0, Height, Time.time);
			yield return;
		}
	}
	*/
	// Update is called once per frame
	void LateUpdate ()
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.Clear();
		
		//make segment

		Segment thisSegment = new Segment(new Vector3(-startWidth/2, Height, 0),
		                                  new Vector3(startWidth/2, Height, 0),
		                                  new Vector2(0f, 0f),
		                                  new Vector2(0f, 1f),
		                                  new Vector3(0f, 1f, 0));

		//make vertices

		//curCount = verts.Length;

		if(curCount < 2)
		{
			curCount += 2;
			Timer();
		}if (addSeg == true)
		{
			curCount++;
			addSeg = false;
		}


		//make normals
		
		Vector3[] normals = new Vector3[8];
		for (int i = 1; i <= curCount*2; i++)
		{
			normals[i-1] = thisSegment.normal;
		}
		
		//make UVs
		
		
		//make Triangles
		
		int[] tri = new int[18]
		{
			0,1,3,
			0,3,2,
			2,3,5,
			5,4,2,
			4,5,7,
			7,6,4,
		};
		//move verts

		//Move();

		for (int f = 1; f <= curCount-1; f++)
		{
			Debug.Log(f + "iteration" + curCount + " howMany verts");
			if(init == false){
				iPos = transform.position;
			}
			verts[f*2] = transform.InverseTransformPoint(iPos.x-startWidth/2f, Height+f, -f*Time.time);
			if(init == false){
				iiPos = transform.position;
			}
			verts[f*2+1] = transform.InverseTransformPoint(iPos.x+startWidth/2f, Height+f, -f*Time.time);
			//yield return;
		}init = true;

		//make mesh
		
		mesh.vertices = verts;
		
		mesh.RecalculateBounds();
		
		mesh.normals = normals;
		mesh.triangles = tri;
		
		
	}
}
