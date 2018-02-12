using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWobble : MonoBehaviour {

	public float amount = 0.1f;

	Vector3 backupRot;
	void Start () {
		backupRot = transform.localEulerAngles;
	}

	void Update()
	{
		transform.localEulerAngles = backupRot;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 sins = new Vector3(Mathf.Sin(Time.time * 3.51f), Mathf.Sin(Time.time * 3.12f), Mathf.Sin(Time.time * 1.78f));
		Vector3 sinsFast = new Vector3(Mathf.Sin(Time.time * 6.51f), Mathf.Sin(Time.time * 10.12f), Mathf.Sin(Time.time * 14.78f)) * 0.25f;

        float x = sins.x + sins.z - sinsFast.z;
        float y = sins.y - sins.z + sinsFast.y;

        transform.localEulerAngles += new Vector3(x, y, 0f) * amount;
    }
}
