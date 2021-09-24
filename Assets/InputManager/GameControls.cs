// GENERATED AUTOMATICALLY FROM 'Assets/InputManager/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ea909f97-4d01-4ef4-958f-a02acb7bbf67"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""eae37ab4-1169-47d5-9406-139ec89ad4b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Keyb"",
                    ""type"": ""Value"",
                    ""id"": ""50785d9d-06f1-48c1-8492-0c09ff165cac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Value"",
                    ""id"": ""e3c29f71-2860-4ecf-88b9-781a052924c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f25b4376-a649-4c92-b19b-3fbf13fe3c2b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25405014-0620-4d2d-91ca-116d53e1f367"",
                    ""path"": ""<Keyboard>/home"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""48181ad3-2c4a-4578-b925-6d155d4cde43"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keyb"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""11cd2a54-a518-4a4f-931f-a2345372506b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Keyb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ea82b92-7554-42de-9eb5-2a91b8237784"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Keyb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a03a20a0-c7fc-4cf6-9124-767ea639b1d2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Keyb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""449df19a-46bc-4ad9-ae98-ab76aff3db7c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Keyb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""594edd5b-7e55-4200-9b91-46077cfb42af"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyb+Touch"",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyb+Touch"",
            ""bindingGroup"": ""Keyb+Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Quit = m_Player.FindAction("Quit", throwIfNotFound: true);
        m_Player_Keyb = m_Player.FindAction("Keyb", throwIfNotFound: true);
        m_Player_Touch = m_Player.FindAction("Touch", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Quit;
    private readonly InputAction m_Player_Keyb;
    private readonly InputAction m_Player_Touch;
    public struct PlayerActions
    {
        private @GameControls m_Wrapper;
        public PlayerActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quit => m_Wrapper.m_Player_Quit;
        public InputAction @Keyb => m_Wrapper.m_Player_Keyb;
        public InputAction @Touch => m_Wrapper.m_Player_Touch;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Quit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnQuit;
                @Keyb.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyb;
                @Keyb.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyb;
                @Keyb.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKeyb;
                @Touch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouch;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Keyb.started += instance.OnKeyb;
                @Keyb.performed += instance.OnKeyb;
                @Keyb.canceled += instance.OnKeyb;
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeybTouchSchemeIndex = -1;
    public InputControlScheme KeybTouchScheme
    {
        get
        {
            if (m_KeybTouchSchemeIndex == -1) m_KeybTouchSchemeIndex = asset.FindControlSchemeIndex("Keyb+Touch");
            return asset.controlSchemes[m_KeybTouchSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnQuit(InputAction.CallbackContext context);
        void OnKeyb(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
}
