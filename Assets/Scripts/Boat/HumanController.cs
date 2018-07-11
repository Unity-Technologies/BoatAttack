using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour
{
	public Engine engine;
	private Vector2 accelButton;
	public float tilt;

	void Start () 
	{
		engine = GetComponent<Engine> ();
	}
	
	void FixedUpdate ()
	{
		tilt = Input.acceleration.x;

		if(tilt > 0.0f)
		{
			engine.TurnRight(tilt*2f);
		}
		if(tilt <  -0.0f)
		{
			engine.TurnLeft(-tilt*2f);
		}

		foreach (Touch touch in Input.touches) 
		{
			if (touch.position.x >= Screen.width * 0.8f && touch.position.y <= Screen.height * 0.3f)
				engine.Accel(1.0f);
			
		}

		// if(Input.GetKey(KeyCode.RightArrow))
		// {
		// 	engine.TurnRight(1f);
		// }

		// if(Input.GetKey(KeyCode.LeftArrow))
		// {
		// 	engine.TurnLeft(1f);
		// }

		if(Input.GetAxis("Accellerate") > 0.1f)
		{
			engine.Accel(1.0f);
		}

        float h = Input.GetAxis("Horizontal");

        if(Mathf.Abs(h) > 0.05f)
		{
            engine.Turn(h);
        }
		
	}

}

