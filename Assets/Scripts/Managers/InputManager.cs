using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>, InputControls.IGameInputActions
{
    private InputControls inputControls;
    private InputControls.GameInputActions inputActions;

    public event Action<Vector2> OnTouchEvent;

    private void OnEnable()
    {
        if(inputControls == null)
        {
            inputControls = new InputControls();
            inputActions = inputControls.GameInput;

            inputControls.Enable();
            inputActions.SetCallbacks(this);
        }
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            
        }
    }

    public void OnTouchPosition(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            OnTouchEvent?.Invoke(context.ReadValue<Vector2>());
        } 
    }

    private void OnDisable()
    {
        inputActions.RemoveCallbacks(this);
        inputControls.Disable();
    }
}
