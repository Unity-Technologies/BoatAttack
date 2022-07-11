using UnityEngine;

public class GenericRotation : MonoBehaviour 
{
	public Vector3 rotationVector;
	
	private void Update () 
	{
		transform.localEulerAngles += rotationVector * Time.deltaTime;
	}
}
