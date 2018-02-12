using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering;

public class AppSettings : MonoBehaviour {

	//\\\\\\\\\Game settings\\\\\\\\\\\//
	
	//Control Settings//
	public float steeringDeadspot = 0.5f;
	public float steeringSensitivity = 0.5f;

	public RenderPipelineAsset pipeline;
	// Use this for initialization
	void Start () {
		//Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
