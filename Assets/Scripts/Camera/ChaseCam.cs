using UnityEngine;
using System.Collections;

public class ChaseCam : MonoBehaviour {

	public Vector3 Offset;
	public Transform target;
	private Vector3 refVel;
	private Vector3 boatOffset;

    private float v;

	void Start()
	{

	}

	void LateUpdate () 
	{
        v = Mathf.Lerp(v, Camera.main.velocity.sqrMagnitude, Time.deltaTime);
        Camera.main.fieldOfView = Mathf.Clamp((v * 0.1f) + 70f, 70f, 90f);
		boatOffset = target.TransformPoint (Offset);
		boatOffset.y = Offset.y;

		transform.position = Vector3.SmoothDamp(transform.position, boatOffset, ref refVel, Time.deltaTime * 25f); //new Vector3(boatOffset.x, 2f, boatOffset.z);
		transform.LookAt (target.position + (Vector3.up * Offset.y));
    }
}
