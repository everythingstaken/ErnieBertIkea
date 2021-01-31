// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Reset"",
            ""id"": ""2d4eb35d-9031-4da3-98c4-9564c3f0ca5e"",
            ""actions"": [
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""a5de5b48-3c34-4cad-b3b0-c651fb795204"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a7a82c1-404c-4f7a-b62b-5a89b26df9af"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Reset
        m_Reset = asset.FindActionMap("Reset", throwIfNotFound: true);
        m_Reset_Reset = m_Reset.FindAction("Reset", throwIfNotFound: true);
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

    // Reset
    private readonly InputActionMap m_Reset;
    private IResetActions m_ResetActionsCallbackInterface;
    private readonly InputAction m_Reset_Reset;
    public struct ResetActions
    {
        private @Controls m_Wrapper;
        public ResetActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Reset => m_Wrapper.m_Reset_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Reset; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ResetActions set) { return set.Get(); }
        public void SetCallbacks(IResetActions instance)
        {
            if (m_Wrapper.m_ResetActionsCallbackInterface != null)
            {
                @Reset.started -= m_Wrapper.m_ResetActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_ResetActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_ResetActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_ResetActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public ResetActions @Reset => new ResetActions(this);
    public interface IResetActions
    {
        void OnReset(InputAction.CallbackContext context);
    }
}
