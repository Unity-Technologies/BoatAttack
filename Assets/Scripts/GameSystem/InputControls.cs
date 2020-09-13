// GENERATED AUTOMATICALLY FROM 'Assets/Data/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""BoatControls"",
            ""id"": ""ef127e39-c6d2-4d6f-8edc-46296d5de0cb"",
            ""actions"": [
                {
                    ""name"": ""Trottle"",
                    ""type"": ""Value"",
                    ""id"": ""591093b7-743c-42e6-b71e-bab02d178bd1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone(min=0.1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Value"",
                    ""id"": ""67e3403a-b3e8-43af-ab52-4575ba23afef"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone(min=0.1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""218640d2-e6dc-4136-842e-4621c0883e15"",
                    ""expectedControlType"": """",
                    ""processors"": ""AxisDeadzone(min=0.1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""097a2ec8-8df3-4d48-96e5-fbf096270878"",
                    ""expectedControlType"": """",
                    ""processors"": ""AxisDeadzone(min=0.1,max=1)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Triggers"",
                    ""id"": ""3466fe24-0064-418d-9331-557be3fdcac4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Trottle"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""eff0cde8-c5f9-43b6-86e8-8385017c8985"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b9957a1f-893b-4ee8-9579-667c3bb073d3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6b1d89c6-a8e7-4b32-9c05-f848bb1064a8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c59fc22d-e257-4273-9159-4416a56a15d0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""71ae2e67-e9b6-4a48-9669-38e7fe243cbc"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e7382d1c-3b18-4582-9511-5569c858581e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""de45f7f3-08ae-4508-a9d8-aca8191f35a1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b25a71de-239c-4d0a-8050-0169566cea38"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a91b562c-2ac5-4d79-9a5b-1f2e59241e92"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a1291229-823b-4ede-82e6-090bc1bdfa21"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""30ce0b9b-3da0-420a-abc3-8f2040388953"",
                    ""path"": ""<Touchscreen>/touch/position/y"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Trottle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""LeftThumbstick"",
                    ""id"": ""01df8425-ce9a-4024-bad4-0f5e8002094f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3866264b-46e4-428b-9624-ada67f2de7bd"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""010e7196-f4dd-4d5c-8f42-f47f3984bc01"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c07695cd-a24b-4ba5-8162-fd6c1d55667a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9a637b8c-8d48-42f2-9cef-114e3b8bb2ba"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""36de1a52-c485-4d40-8d4d-323d8fe73445"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""72970fc1-f5b9-4e7b-bfb0-8356935a6274"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3d3dbb25-9147-4e77-ae9d-04d1c01d2666"",
                    ""path"": ""<Touchscreen>/tilt/x"",
                    ""interactions"": """",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a7ffffc-09c1-403a-b879-7a91dfb5b29d"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b449cb97-f7cf-448b-9aa9-900c8085c53d"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8b1e58a-fd18-487f-ae58-dc92e5273625"",
                    ""path"": ""<Touchscreen>/primaryTouch/tapCount"",
                    ""interactions"": ""MultiTap(tapCount=3)"",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbe374df-c0a2-4067-8743-605cc47e112b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c9efbd8-b12e-4a6d-9787-042b4abda799"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""DebugControls"",
            ""id"": ""625f8e9a-b2de-4422-89d6-ca2dcf289a8d"",
            ""actions"": [
                {
                    ""name"": ""PauseTime"",
                    ""type"": ""Button"",
                    ""id"": ""c57759c4-f215-4fe9-bd6c-1c835c6074bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TimeOfDay"",
                    ""type"": ""Value"",
                    ""id"": ""bfb079cd-5e64-4031-b061-eb65384dacba"",
                    ""expectedControlType"": """",
                    ""processors"": ""AxisDeadzone(min=0.1,max=1)"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b0262d6e-137b-4503-8f4b-124b75ec4df5"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PauseTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b0434a7-171f-43b3-9d03-4ce4b094f5e3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Dpad horizontal"",
                    ""id"": ""bfedaf52-7184-467b-92f9-65d70942efe0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bcf9de83-e5b3-4bac-9d76-81453677755a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ff51058c-7728-4c35-9a9b-81d916d2c847"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""02b681cb-4360-4b75-aca7-b0e2af63dc98"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cb19bc84-0e7b-4a9a-904c-15b238d10952"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f3f7d26e-9e8b-43bf-985a-c53211bfa141"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3788c13b-1c68-4e83-9699-fd8cf9ef4660"",
                    ""path"": ""<Touchscreen>/primaryTouch/tapCount"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": ""TouchScreen"",
                    ""action"": ""TimeOfDay"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<SwitchProControllerHID>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""TouchScreen"",
            ""bindingGroup"": ""TouchScreen"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // BoatControls
        m_BoatControls = asset.FindActionMap("BoatControls", throwIfNotFound: true);
        m_BoatControls_Trottle = m_BoatControls.FindAction("Trottle", throwIfNotFound: true);
        m_BoatControls_Steering = m_BoatControls.FindAction("Steering", throwIfNotFound: true);
        m_BoatControls_Reset = m_BoatControls.FindAction("Reset", throwIfNotFound: true);
        m_BoatControls_Pause = m_BoatControls.FindAction("Pause", throwIfNotFound: true);
        // DebugControls
        m_DebugControls = asset.FindActionMap("DebugControls", throwIfNotFound: true);
        m_DebugControls_PauseTime = m_DebugControls.FindAction("PauseTime", throwIfNotFound: true);
        m_DebugControls_TimeOfDay = m_DebugControls.FindAction("TimeOfDay", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // BoatControls
    private readonly InputActionMap m_BoatControls;
    private IBoatControlsActions m_BoatControlsActionsCallbackInterface;
    private readonly InputAction m_BoatControls_Trottle;
    private readonly InputAction m_BoatControls_Steering;
    private readonly InputAction m_BoatControls_Reset;
    private readonly InputAction m_BoatControls_Pause;
    public struct BoatControlsActions
    {
        private @InputControls m_Wrapper;
        public BoatControlsActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Trottle => m_Wrapper.m_BoatControls_Trottle;
        public InputAction @Steering => m_Wrapper.m_BoatControls_Steering;
        public InputAction @Reset => m_Wrapper.m_BoatControls_Reset;
        public InputAction @Pause => m_Wrapper.m_BoatControls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_BoatControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoatControlsActions set) { return set.Get(); }
        public void SetCallbacks(IBoatControlsActions instance)
        {
            if (m_Wrapper.m_BoatControlsActionsCallbackInterface != null)
            {
                @Trottle.started -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnTrottle;
                @Trottle.performed -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnTrottle;
                @Trottle.canceled -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnTrottle;
                @Steering.started -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnSteering;
                @Reset.started -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnReset;
                @Pause.started -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_BoatControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_BoatControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Trottle.started += instance.OnTrottle;
                @Trottle.performed += instance.OnTrottle;
                @Trottle.canceled += instance.OnTrottle;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public BoatControlsActions @BoatControls => new BoatControlsActions(this);

    // DebugControls
    private readonly InputActionMap m_DebugControls;
    private IDebugControlsActions m_DebugControlsActionsCallbackInterface;
    private readonly InputAction m_DebugControls_PauseTime;
    private readonly InputAction m_DebugControls_TimeOfDay;
    public struct DebugControlsActions
    {
        private @InputControls m_Wrapper;
        public DebugControlsActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseTime => m_Wrapper.m_DebugControls_PauseTime;
        public InputAction @TimeOfDay => m_Wrapper.m_DebugControls_TimeOfDay;
        public InputActionMap Get() { return m_Wrapper.m_DebugControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugControlsActions set) { return set.Get(); }
        public void SetCallbacks(IDebugControlsActions instance)
        {
            if (m_Wrapper.m_DebugControlsActionsCallbackInterface != null)
            {
                @PauseTime.started -= m_Wrapper.m_DebugControlsActionsCallbackInterface.OnPauseTime;
                @PauseTime.performed -= m_Wrapper.m_DebugControlsActionsCallbackInterface.OnPauseTime;
                @PauseTime.canceled -= m_Wrapper.m_DebugControlsActionsCallbackInterface.OnPauseTime;
                @TimeOfDay.started -= m_Wrapper.m_DebugControlsActionsCallbackInterface.OnTimeOfDay;
                @TimeOfDay.performed -= m_Wrapper.m_DebugControlsActionsCallbackInterface.OnTimeOfDay;
                @TimeOfDay.canceled -= m_Wrapper.m_DebugControlsActionsCallbackInterface.OnTimeOfDay;
            }
            m_Wrapper.m_DebugControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseTime.started += instance.OnPauseTime;
                @PauseTime.performed += instance.OnPauseTime;
                @PauseTime.canceled += instance.OnPauseTime;
                @TimeOfDay.started += instance.OnTimeOfDay;
                @TimeOfDay.performed += instance.OnTimeOfDay;
                @TimeOfDay.canceled += instance.OnTimeOfDay;
            }
        }
    }
    public DebugControlsActions @DebugControls => new DebugControlsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_TouchScreenSchemeIndex = -1;
    public InputControlScheme TouchScreenScheme
    {
        get
        {
            if (m_TouchScreenSchemeIndex == -1) m_TouchScreenSchemeIndex = asset.FindControlSchemeIndex("TouchScreen");
            return asset.controlSchemes[m_TouchScreenSchemeIndex];
        }
    }
    public interface IBoatControlsActions
    {
        void OnTrottle(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IDebugControlsActions
    {
        void OnPauseTime(InputAction.CallbackContext context);
        void OnTimeOfDay(InputAction.CallbackContext context);
    }
}
