// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""controls"",
            ""id"": ""65cae79c-2565-4771-93d0-f7bb9773ca75"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""94f6797f-2415-474d-810d-ca603113a7b7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""sprint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5343ab54-5f28-45fe-b237-e9094ca20df1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""44d3f097-619b-429b-92c0-66e60d6268bc"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""interact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""734acd99-df04-4659-a010-ef4a89206354"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fdc051a3-53b4-48e3-ae42-3626603d975e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""heal"",
                    ""type"": ""Button"",
                    ""id"": ""8666d784-1aab-4c38-a55a-1f9a51c49348"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""1cb545f5-9e43-4fe5-9c43-68a43027c999"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DreamDash"",
                    ""type"": ""Button"",
                    ""id"": ""2a7d7400-23bb-4d67-95e4-c4586d3c1dee"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06f217dc-2bc4-4df0-81d3-23fb4414da66"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamePad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""3e4771ab-fe0b-4baf-b1db-676e16bda624"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""618ed78b-0640-458e-9507-70b88923cdd6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""24c7ed5a-8887-4754-815b-e7291a7dd87c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""628f5222-1199-4ca6-8f12-13e23e9cb6c1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c0d0a84c-c604-4d2b-a2dc-6d8c6cf0c2a7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""303f6663-9cc8-4077-bd40-58969f9f2521"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1e9cdd7-f750-499a-aaad-17368fb18f24"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamePad"",
                    ""action"": ""sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c99f61b0-c2b9-4947-93a3-587ca6790dad"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamePad"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""904daf30-a683-47be-bce9-a7a9527b9e2c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4cc67ea-ffd7-42a2-abe8-e3825730baa0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ff9134c-eb7f-4aab-998d-aa50b02565f1"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamePad"",
                    ""action"": ""interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""903913ff-3c94-425e-80e9-25093862e936"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3f92e68-d8c8-4308-82df-df45f2c4e343"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""783bd11e-7d36-4038-bb83-947bd0b6e0d3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3006cbc8-5c5f-4b5f-b249-7064cdc6b5c8"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamePad"",
                    ""action"": ""heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3500a0de-f56f-4555-9b04-3147faa621ef"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keybord"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""789bcf1b-91ba-453d-ac63-b2500b080339"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""gamePad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a66a3091-3e27-483c-a466-0b5dddd149e7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DreamDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0beaf25a-4325-48dc-9dc3-f4fc0175b27e"",
                    ""path"": ""<HID::Bensussen Deutsch & Associates,Inc.(BDA) Core (Plus) Wired Controller>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DreamDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keybord"",
            ""bindingGroup"": ""keybord"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""gamePad"",
            ""bindingGroup"": ""gamePad"",
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
        // controls
        m_controls = asset.FindActionMap("controls", throwIfNotFound: true);
        m_controls_Move = m_controls.FindAction("Move", throwIfNotFound: true);
        m_controls_sprint = m_controls.FindAction("sprint", throwIfNotFound: true);
        m_controls_jump = m_controls.FindAction("jump", throwIfNotFound: true);
        m_controls_interact = m_controls.FindAction("interact", throwIfNotFound: true);
        m_controls_attack = m_controls.FindAction("attack", throwIfNotFound: true);
        m_controls_heal = m_controls.FindAction("heal", throwIfNotFound: true);
        m_controls_Pause = m_controls.FindAction("Pause", throwIfNotFound: true);
        m_controls_DreamDash = m_controls.FindAction("DreamDash", throwIfNotFound: true);
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

    // controls
    private readonly InputActionMap m_controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_controls_Move;
    private readonly InputAction m_controls_sprint;
    private readonly InputAction m_controls_jump;
    private readonly InputAction m_controls_interact;
    private readonly InputAction m_controls_attack;
    private readonly InputAction m_controls_heal;
    private readonly InputAction m_controls_Pause;
    private readonly InputAction m_controls_DreamDash;
    public struct ControlsActions
    {
        private PlayerControls m_Wrapper;
        public ControlsActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_controls_Move;
        public InputAction @sprint => m_Wrapper.m_controls_sprint;
        public InputAction @jump => m_Wrapper.m_controls_jump;
        public InputAction @interact => m_Wrapper.m_controls_interact;
        public InputAction @attack => m_Wrapper.m_controls_attack;
        public InputAction @heal => m_Wrapper.m_controls_heal;
        public InputAction @Pause => m_Wrapper.m_controls_Pause;
        public InputAction @DreamDash => m_Wrapper.m_controls_DreamDash;
        public InputActionMap Get() { return m_Wrapper.m_controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                sprint.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                sprint.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                sprint.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                jump.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                jump.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                jump.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnJump;
                interact.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                interact.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                interact.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                attack.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAttack;
                attack.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAttack;
                attack.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnAttack;
                heal.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnHeal;
                heal.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnHeal;
                heal.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnHeal;
                Pause.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPause;
                Pause.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPause;
                Pause.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPause;
                DreamDash.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDreamDash;
                DreamDash.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDreamDash;
                DreamDash.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnDreamDash;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                sprint.started += instance.OnSprint;
                sprint.performed += instance.OnSprint;
                sprint.canceled += instance.OnSprint;
                jump.started += instance.OnJump;
                jump.performed += instance.OnJump;
                jump.canceled += instance.OnJump;
                interact.started += instance.OnInteract;
                interact.performed += instance.OnInteract;
                interact.canceled += instance.OnInteract;
                attack.started += instance.OnAttack;
                attack.performed += instance.OnAttack;
                attack.canceled += instance.OnAttack;
                heal.started += instance.OnHeal;
                heal.performed += instance.OnHeal;
                heal.canceled += instance.OnHeal;
                Pause.started += instance.OnPause;
                Pause.performed += instance.OnPause;
                Pause.canceled += instance.OnPause;
                DreamDash.started += instance.OnDreamDash;
                DreamDash.performed += instance.OnDreamDash;
                DreamDash.canceled += instance.OnDreamDash;
            }
        }
    }
    public ControlsActions @controls => new ControlsActions(this);
    private int m_keybordSchemeIndex = -1;
    public InputControlScheme keybordScheme
    {
        get
        {
            if (m_keybordSchemeIndex == -1) m_keybordSchemeIndex = asset.FindControlSchemeIndex("keybord");
            return asset.controlSchemes[m_keybordSchemeIndex];
        }
    }
    private int m_gamePadSchemeIndex = -1;
    public InputControlScheme gamePadScheme
    {
        get
        {
            if (m_gamePadSchemeIndex == -1) m_gamePadSchemeIndex = asset.FindControlSchemeIndex("gamePad");
            return asset.controlSchemes[m_gamePadSchemeIndex];
        }
    }
    public interface IControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnDreamDash(InputAction.CallbackContext context);
    }
}
