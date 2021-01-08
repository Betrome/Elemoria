// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""56ae89f3-3f78-4cc1-b5b7-a656651b442a"",
            ""actions"": [
                {
                    ""name"": ""Attack1"",
                    ""type"": ""Button"",
                    ""id"": ""96b9f06f-cd1b-4b97-86a2-da4d466fc458"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""528307af-cf77-43f0-abd3-f52f75736e98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MovePlayer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8b417dab-1ec3-417e-8c57-a700214eb4ea"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""740d46a9-c6de-4b3e-afb8-ceeca1427fe9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""54179d9a-ef4e-45ed-9a26-a9e434ec1e0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combo1"",
                    ""type"": ""Button"",
                    ""id"": ""413b5de3-b7ad-478b-961d-b769aad44842"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combo2"",
                    ""type"": ""Button"",
                    ""id"": ""6b2155b4-605c-4019-ac84-247767d5f4b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combo3"",
                    ""type"": ""Button"",
                    ""id"": ""99983d0f-4aee-424d-ac5f-630fc7455dd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Combo4"",
                    ""type"": ""Button"",
                    ""id"": ""4cb7ac84-28f3-42b6-a339-6d8b621d8dca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""e6c604b1-c8bb-4ded-bac9-16dfc34fbe77"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextTarget"",
                    ""type"": ""Button"",
                    ""id"": ""1187bf0a-f7af-4abe-abd7-bb79bd26ae8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousTarget"",
                    ""type"": ""Button"",
                    ""id"": ""4def6e91-6761-4a23-9ac7-4b8c7c8a56db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dd859f94-b969-474b-b7b1-011e84bc3387"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab47f632-0f2a-456f-a641-420a9f06d550"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15a0e286-617b-4b7f-9e40-76a0c00244bb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""830b2953-e1d2-4561-a497-cc496ee952ea"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bdd5589-36ae-4b91-9a1b-7afe4c68bf82"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77df7a16-bed2-4284-bdfa-ce499e578c8d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cfb6900-4c51-42cb-be95-db7776b0bc56"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b11ec284-a1a4-4151-96f7-379ba8953a28"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e452aa9-bd5b-4e0d-8fd0-62b6a6d3f2a5"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b37f3c29-dde3-40d6-869c-5c62919cc020"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6399c56-3a2d-4fc9-8734-b8082baa75e5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acdd0ad5-3cc9-4262-bd6b-f386d35b30fd"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Attack1 = m_Gameplay.FindAction("Attack1", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_MovePlayer = m_Gameplay.FindAction("MovePlayer", throwIfNotFound: true);
        m_Gameplay_MoveCamera = m_Gameplay.FindAction("MoveCamera", throwIfNotFound: true);
        m_Gameplay_Action = m_Gameplay.FindAction("Action", throwIfNotFound: true);
        m_Gameplay_Combo1 = m_Gameplay.FindAction("Combo1", throwIfNotFound: true);
        m_Gameplay_Combo2 = m_Gameplay.FindAction("Combo2", throwIfNotFound: true);
        m_Gameplay_Combo3 = m_Gameplay.FindAction("Combo3", throwIfNotFound: true);
        m_Gameplay_Combo4 = m_Gameplay.FindAction("Combo4", throwIfNotFound: true);
        m_Gameplay_Target = m_Gameplay.FindAction("Target", throwIfNotFound: true);
        m_Gameplay_NextTarget = m_Gameplay.FindAction("NextTarget", throwIfNotFound: true);
        m_Gameplay_PreviousTarget = m_Gameplay.FindAction("PreviousTarget", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Attack1;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_MovePlayer;
    private readonly InputAction m_Gameplay_MoveCamera;
    private readonly InputAction m_Gameplay_Action;
    private readonly InputAction m_Gameplay_Combo1;
    private readonly InputAction m_Gameplay_Combo2;
    private readonly InputAction m_Gameplay_Combo3;
    private readonly InputAction m_Gameplay_Combo4;
    private readonly InputAction m_Gameplay_Target;
    private readonly InputAction m_Gameplay_NextTarget;
    private readonly InputAction m_Gameplay_PreviousTarget;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack1 => m_Wrapper.m_Gameplay_Attack1;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @MovePlayer => m_Wrapper.m_Gameplay_MovePlayer;
        public InputAction @MoveCamera => m_Wrapper.m_Gameplay_MoveCamera;
        public InputAction @Action => m_Wrapper.m_Gameplay_Action;
        public InputAction @Combo1 => m_Wrapper.m_Gameplay_Combo1;
        public InputAction @Combo2 => m_Wrapper.m_Gameplay_Combo2;
        public InputAction @Combo3 => m_Wrapper.m_Gameplay_Combo3;
        public InputAction @Combo4 => m_Wrapper.m_Gameplay_Combo4;
        public InputAction @Target => m_Wrapper.m_Gameplay_Target;
        public InputAction @NextTarget => m_Wrapper.m_Gameplay_NextTarget;
        public InputAction @PreviousTarget => m_Wrapper.m_Gameplay_PreviousTarget;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Attack1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack1;
                @Attack1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack1;
                @Attack1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack1;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @MovePlayer.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovePlayer;
                @MovePlayer.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovePlayer;
                @MovePlayer.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovePlayer;
                @MoveCamera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveCamera;
                @Action.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Combo1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo1;
                @Combo1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo1;
                @Combo1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo1;
                @Combo2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo2;
                @Combo2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo2;
                @Combo2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo2;
                @Combo3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo3;
                @Combo3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo3;
                @Combo3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo3;
                @Combo4.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo4;
                @Combo4.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo4;
                @Combo4.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCombo4;
                @Target.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTarget;
                @NextTarget.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNextTarget;
                @NextTarget.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNextTarget;
                @NextTarget.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNextTarget;
                @PreviousTarget.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPreviousTarget;
                @PreviousTarget.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPreviousTarget;
                @PreviousTarget.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPreviousTarget;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack1.started += instance.OnAttack1;
                @Attack1.performed += instance.OnAttack1;
                @Attack1.canceled += instance.OnAttack1;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MovePlayer.started += instance.OnMovePlayer;
                @MovePlayer.performed += instance.OnMovePlayer;
                @MovePlayer.canceled += instance.OnMovePlayer;
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Combo1.started += instance.OnCombo1;
                @Combo1.performed += instance.OnCombo1;
                @Combo1.canceled += instance.OnCombo1;
                @Combo2.started += instance.OnCombo2;
                @Combo2.performed += instance.OnCombo2;
                @Combo2.canceled += instance.OnCombo2;
                @Combo3.started += instance.OnCombo3;
                @Combo3.performed += instance.OnCombo3;
                @Combo3.canceled += instance.OnCombo3;
                @Combo4.started += instance.OnCombo4;
                @Combo4.performed += instance.OnCombo4;
                @Combo4.canceled += instance.OnCombo4;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @NextTarget.started += instance.OnNextTarget;
                @NextTarget.performed += instance.OnNextTarget;
                @NextTarget.canceled += instance.OnNextTarget;
                @PreviousTarget.started += instance.OnPreviousTarget;
                @PreviousTarget.performed += instance.OnPreviousTarget;
                @PreviousTarget.canceled += instance.OnPreviousTarget;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnAttack1(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMovePlayer(InputAction.CallbackContext context);
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnCombo1(InputAction.CallbackContext context);
        void OnCombo2(InputAction.CallbackContext context);
        void OnCombo3(InputAction.CallbackContext context);
        void OnCombo4(InputAction.CallbackContext context);
        void OnTarget(InputAction.CallbackContext context);
        void OnNextTarget(InputAction.CallbackContext context);
        void OnPreviousTarget(InputAction.CallbackContext context);
    }
}
