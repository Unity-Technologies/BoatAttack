using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterSystem;
using Unity.Mathematics;

public class WindsurferLogic : MonoBehaviour {

    private float3[] point = new float3[1];
    private float3[] heights = new float3[1];
    private Vector3 smoothPosition;
    private int _guid;
    private float vel = 0f;

    // Use this for initialization
    void Start () 
    {
        _guid = gameObject.GetInstanceID();
        smoothPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update () 
    {
        smoothPosition = transform.position;
        point[0] = transform.position;
	GerstnerWavesJobs.UpdateSamplePoints(point, _guid, false);
	GerstnerWavesJobs.GetData(_guid, ref heights);
	if(heights[0].y > smoothPosition.y)
            smoothPosition.y += Time.deltaTime;
	else
            smoothPosition.y -= Time.deltaTime * 0.25f;
        transform.position = smoothPosition;
    }
}
