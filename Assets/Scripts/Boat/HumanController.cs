using UnityEngine;
using UnityEngine.InputSystem;

namespace BoatAttack
{
    /// <summary>
    /// This sends input controls to the boat engine if 'Human'
    /// </summary>
    public class HumanController : BaseController
    {
        [Header("Input Settings")]
        [Range(0.1f, 2.0f)]
        [Tooltip("조종 감도 조절 (낮을수록 느림, 높을수록 빠름)")]
        public float steeringSensitivity = 0.3f;

        private InputControls _controls;

        private float _throttle;
        private float _steering;

        private bool _paused;
        
        private void Awake()
        {
            _controls = new InputControls();
            
            _controls.BoatControls.Trottle.performed += context => _throttle = context.ReadValue<float>();
            _controls.BoatControls.Trottle.canceled += context => _throttle = 0f;
            
            _controls.BoatControls.Steering.performed += context => _steering = context.ReadValue<float>();
            _controls.BoatControls.Steering.canceled += context => _steering = 0f;

            _controls.BoatControls.Reset.performed += ResetBoat;
            _controls.BoatControls.Pause.performed += FreezeBoat;

            _controls.DebugControls.TimeOfDay.performed += SelectTime;
        }

        public override void OnEnable()
        {
            base.OnEnable();
            _controls.BoatControls.Enable();
        }

        private void OnDisable()
        {
            _controls.BoatControls.Disable();
        }

        private void ResetBoat(InputAction.CallbackContext context)
        {
            controller.ResetPosition();
        }

        private void FreezeBoat(InputAction.CallbackContext context)
        {
            _paused = !_paused;
            if(_paused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        private void SelectTime(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();
            Debug.Log($"changing day time, input:{value}");
            DayNightController.SelectPreset(value);
        }

        void FixedUpdate()
        {
            // 학습 모드일 때는 플레이어 입력 무시
            if (GameModeManager.IsTrainingMode)
            {
                return;
            }

            engine.Accelerate(_throttle);
            // 감도 조절 적용 (결과값을 -1~1 범위로 제한)
            var adjustedSteering = Mathf.Clamp(_steering * steeringSensitivity, -1f, 1f);
            engine.Turn(adjustedSteering);
        }
    }
}

