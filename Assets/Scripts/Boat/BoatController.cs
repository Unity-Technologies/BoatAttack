using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour {

	//Boat stats
	public bool Human;
	public int AIdifficulty;
	public float speed;
	public float weight;
	public float strength;
	public float wakeWidth;

	//cache the engine connected to the boat
	//private Engine boatEngine;

	//local cache
	//private Rigidbody RB;
	//private AudioSource AS;

	// Use this for initialization
	void Start () 
	{
		//RB = gameObject.GetComponent<Rigidbody>();
		//AS = gameObject.GetComponent<AudioSource>();
		//boatEngine = gameObject.GetComponent<Engine>();

		if (Human == true) 
		{
			gameObject.AddComponent<HumanController>();
		} 
		else 
		{
			gameObject.AddComponent<AIcontroller>();
		}
	}
}
