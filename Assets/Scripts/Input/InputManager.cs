using System;
using UnityEngine.InputSystem;

public class InputManager
{

    private PlayerControls playerControls;


    public float Movement => playerControls.GamePlay.Movement.ReadValue<float>();

    public event Action OnJump;
    public InputManager() { 
    
        playerControls = new PlayerControls();
        playerControls.GamePlay.Enable();

        playerControls.GamePlay.Jump.performed += OnJumpPerfomed;

    }
    private void OnJumpPerfomed(
        InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }
}
