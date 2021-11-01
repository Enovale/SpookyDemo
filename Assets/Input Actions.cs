// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input Actions"",
    ""maps"": [
        {
            ""name"": ""Pilot"",
            ""id"": ""87025fb5-2498-4d11-b9b7-fe7e84c3b178"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""59bfb5f3-ea5d-4e2a-b24a-d58f420b9cb7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b322f8f2-3829-41d8-90e2-e0aeffa3f9f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""7cddf19b-4804-4040-b443-cc7a336c7897"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""63bd9721-6551-4ee9-b90c-88ceeb370263"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""dd4856ba-afe9-4825-8375-d87617c87992"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b284353c-2e70-4e50-9102-0282c2d395e2"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4aa48702-5902-41bb-868c-df6e97ab9ff5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""522b7808-f6a3-410d-8e95-8792dc48d939"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b62c4b3a-c272-46ad-b573-05de7ff8f894"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1cb713b4-5a94-4c5b-98cd-6fc4601be63e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a282fe4d-15f1-432d-be6a-8237d4942012"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c593d47a-5336-4939-977e-dcd0a31ae853"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0dcb0de8-d9ce-48af-9095-88965563430e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1600844a-4b66-46d2-8fd7-71859f5f7365"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a6ddf30-580a-4799-9083-b5b248c5f12e"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bffb5d83-222e-4798-b66a-9b507ac1535c"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9fef4ef-a69c-4541-aae2-3bed7e4a73a8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa0e3873-7171-4ba4-9459-2b992893e3bc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.5,y=0.5)"",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""996c74df-a467-439b-a7c9-531543f409ae"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Pilot
        m_Pilot = asset.FindActionMap("Pilot", throwIfNotFound: true);
        m_Pilot_Movement = m_Pilot.FindAction("Movement", throwIfNotFound: true);
        m_Pilot_Jump = m_Pilot.FindAction("Jump", throwIfNotFound: true);
        m_Pilot_Sprint = m_Pilot.FindAction("Sprint", throwIfNotFound: true);
        m_Pilot_Crouch = m_Pilot.FindAction("Crouch", throwIfNotFound: true);
        m_Pilot_CameraMove = m_Pilot.FindAction("CameraMove", throwIfNotFound: true);
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

    // Pilot
    private readonly InputActionMap m_Pilot;
    private IPilotActions m_PilotActionsCallbackInterface;
    private readonly InputAction m_Pilot_Movement;
    private readonly InputAction m_Pilot_Jump;
    private readonly InputAction m_Pilot_Sprint;
    private readonly InputAction m_Pilot_Crouch;
    private readonly InputAction m_Pilot_CameraMove;
    public struct PilotActions
    {
        private @InputActions m_Wrapper;
        public PilotActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Pilot_Movement;
        public InputAction @Jump => m_Wrapper.m_Pilot_Jump;
        public InputAction @Sprint => m_Wrapper.m_Pilot_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Pilot_Crouch;
        public InputAction @CameraMove => m_Wrapper.m_Pilot_CameraMove;
        public InputActionMap Get() { return m_Wrapper.m_Pilot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PilotActions set) { return set.Get(); }
        public void SetCallbacks(IPilotActions instance)
        {
            if (m_Wrapper.m_PilotActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PilotActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PilotActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PilotActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PilotActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PilotActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PilotActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_PilotActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PilotActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PilotActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_PilotActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PilotActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PilotActionsCallbackInterface.OnCrouch;
                @CameraMove.started -= m_Wrapper.m_PilotActionsCallbackInterface.OnCameraMove;
                @CameraMove.performed -= m_Wrapper.m_PilotActionsCallbackInterface.OnCameraMove;
                @CameraMove.canceled -= m_Wrapper.m_PilotActionsCallbackInterface.OnCameraMove;
            }
            m_Wrapper.m_PilotActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @CameraMove.started += instance.OnCameraMove;
                @CameraMove.performed += instance.OnCameraMove;
                @CameraMove.canceled += instance.OnCameraMove;
            }
        }
    }
    public PilotActions @Pilot => new PilotActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPilotActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
    }
}
