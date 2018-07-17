using UnityEngine;
using System.Collections;

namespace BoatAttack.Boat
{
	/// <summary>
	/// This sends input controls to the boat engine if 'Human'
	/// </summary>
    public class HumanController : MonoBehaviour
    {
        public Engine engine; // the engine script

        void Start()
        {
            engine = GetComponent<Engine>(); // get the engine script
        }

        void FixedUpdate()
        {
            ////////////////////////////// Mobile controls - UNTESTED ////////////////////////////////
            foreach (Touch touch in Input.touches) // Acceleration
            {
                if (touch.position.x >= Screen.width * 0.8f && touch.position.y <= Screen.height * 0.3f)
                    engine.Accel(1.0f);
            }
			if(Input.acceleration.x != 0f) // Turning
			{
                engine.Turn(Input.acceleration.x * 2f);
            }
			/////////////////////////////// Desktop/Controller controls ///////////////////////////////
            if (Input.GetAxis("Accellerate") > 0.1f) // Acceleration
            {
                engine.Accel(1.0f);
            }
            float steer = Input.GetAxis("Horizontal");
            if (Mathf.Abs(steer) > 0.05f) // Turning
            {
                engine.Turn(steer);
            }
        }
    }
}

