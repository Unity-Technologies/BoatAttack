using UnityEngine;
using System.Collections;
using WaterSystem;
using Unity.Mathematics;

public class Engine : MonoBehaviour 
{
	//cache vars
	private Rigidbody RB;
	public Vector3 vel;

    public AudioSource engineSound;
    public AudioSource waterSound;

    //engine stats
    public float torque = 35f;
	public float horsePower = 100f;
	public float throttle = 0f; 

	//cache for the boatcontroller
	private BuoyantObject buoyantObject;
    private float3[] point = new float3[1]; // engine submerged check
    private float3[] heights = new float3[1]; // engine submerged check
    private int _guid;
    private float yHeight;

    public Vector3 enginePosition;
	private Vector3 engineDir;

	void Awake () 
	{
		//cache rigidbody
		RB = gameObject.GetComponent<Rigidbody>();
        engineSound.time = Random.Range(0f, engineSound.clip.length);
        waterSound.time = Random.Range(0f, waterSound.clip.length);

        _guid = this.GetInstanceID();
        buoyantObject = gameObject.GetComponent<BuoyantObject>();
    }	

	void FixedUpdate()
	{
        vel = RB.velocity;
        float velMag = vel.sqrMagnitude;
        engineSound.pitch = Mathf.Max(velMag * 0.01f, 0.3f);

        point[0] = transform.TransformPoint(enginePosition);
        GerstnerWavesJobs.UpdateSamplePoints(point, _guid, false);
        GerstnerWavesJobs.GetData(_guid, ref heights);
        yHeight = heights[0].y - point[0].y;
    }

	public void Accel(float modifier)
	{
        if (yHeight > -0.1f)
        {
            Vector3 forward = transform.forward;
            forward.y = 0f;
            forward.Normalize();
            RB.AddForce(forward * modifier * horsePower, ForceMode.Acceleration);
            RB.AddRelativeTorque(-Vector3.right * modifier, ForceMode.Acceleration);
        }


        // if(throttle < 1f)
        // 	throttle += modifier;
        // if(throttle > 1f)
        // 	throttle = 1f;
    }

	public void TurnLeft(float modifier)
	{
        //if(buoyantObject.percentSubmerged > 0.05f)
        if (yHeight > -0.1f)
        {
            RB.AddRelativeTorque(new Vector3(0f, -torque, torque * 0.5f) * modifier * 500f, ForceMode.Acceleration);
        }
    }

	public void TurnRight(float modifier)
	{
        //if(buoyantObject.percentSubmerged > 0.05f)
        if (yHeight > -0.1f)
        {
            RB.AddRelativeTorque(new Vector3(0f, torque, -torque * 0.5f) * modifier * 500f, ForceMode.Acceleration);
        }
    }

    public void Turn(float modifier)
    {
        //if(buoyantObject.percentSubmerged > 0.05f)
        if (yHeight > -0.1f)
        {
            RB.AddRelativeTorque(new Vector3(0f, torque, -torque * 0.5f) * modifier * 500f, ForceMode.Acceleration);
        }
    }

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.green;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawCube (enginePosition, new Vector3(0.1f, 0.2f, 0.3f));
	}

}
