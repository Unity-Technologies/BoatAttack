using UnityEngine;
using UnityEngine.InputSystem;

namespace BoatAttack.Boat
{
    /// <summary>
    /// This sends input controls to the boat engine if 'Human'
    /// </summary>
    public class HumanController : MonoBehaviour
    {
        public BoatController controller; // the boat controller
        public Engine engine; // the engine script

        public InputControls controls;

        public float throttle;
        public float steering;

        public bool paused;
        
        void Awake()
        {
            controls = new InputControls();
            
            controls.BoatControls.Trottle.performed += context => throttle = context.ReadValue<float>();
            controls.BoatControls.Trottle.canceled += context => throttle = 0f;
            
            controls.BoatControls.Steering.performed += context => steering = context.ReadValue<float>();
            controls.BoatControls.Steering.canceled += context => steering = 0f;

            controls.BoatControls.Reset.performed += ResetBoat;
            controls.BoatControls.Freeze.performed += FreezeBoat;

            controls.BoatControls.Time.performed += SelectTime;

            engine = GetComponent<Engine>(); // get the engine script
		}

        private void OnEnable()
        {
            controls.BoatControls.Enable();
        }

        private void OnDisable()
        {
            controls.BoatControls.Disable();
        }

        private void ResetBoat(InputAction.CallbackContext context)
        {
            controller.ResetPosition();
        }

        private void FreezeBoat(InputAction.CallbackContext context)
        {
            paused = !paused;
            if(paused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            //engine.RB.isKinematic = !engine.RB.isKinematic;
        }

        private void SelectTime(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            Debug.Log($"changing day time, input:{value}");
            DayNightController.SelectPreset(value);
        }

        void FixedUpdate()
        {
            engine.Accel(throttle);
            engine.Turn(steering);
        }
    }
}

