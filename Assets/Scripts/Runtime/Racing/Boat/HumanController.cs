using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BoatAttack
{
    /// <summary>
    /// This sends input controls to the boat engine if 'Human'
    /// </summary>
    public class HumanController : BaseController
    {
        private InputControls _controls;

        private float _throttle;
        private float _steering;
        
        private void Awake()
        {
            
        }

        public override void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new InputControls();
            
                _controls.BoatControl.Trottle.performed += context => _throttle = context.ReadValue<float>();
                _controls.BoatControl.Trottle.canceled += _ => _throttle = 0f;
            
                _controls.BoatControl.Steering.performed += context => _steering = context.ReadValue<float>();
                _controls.BoatControl.Steering.canceled += _ => _steering = 0f;

                _controls.BoatControl.Reset.performed += ResetBoat;
            }
            
            base.OnEnable();
            _controls.BoatControl.Enable();
        }

        private void OnDisable()
        {
            _controls.BoatControl.Disable();
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void ResetBoat(InputAction.CallbackContext context)
        {
            controller.ResetPosition();
        }

        void FixedUpdate()
        {
            if (RaceManager.State is RaceManager.RaceState.RaceStarted or RaceManager.RaceState.RaceEnded)
            {
                engine.Accelerate(_throttle);
                engine.Turn(_steering);
            }
        }
    }
}

