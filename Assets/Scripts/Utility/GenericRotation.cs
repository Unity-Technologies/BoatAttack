using UnityEngine;
using System.Collections;

public class GenericRotation : MonoBehaviour 
{
	public Vector3 rotationVector;
	// Update is called once per frame
	void Update () {
		transform.localEulerAngles += rotationVector * Time.deltaTime;
	}
}
