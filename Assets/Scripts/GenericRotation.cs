using UnityEngine;
using System.Collections;

public class GenericRotation : MonoBehaviour {

	public Vector3 rotationVector;
	
	private Transform t;

	// Use this for initialization
	void Start () {
		t = transform;
	}
	
	// Update is called once per frame
	void Update () {
		t.localEulerAngles += rotationVector * Time.deltaTime;
	}
}
