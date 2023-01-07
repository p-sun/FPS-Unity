using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }

    private void Reset()
    {
    }

    private void Start()
    {
    }

    void FixedUpdate() // Pre-physics & Pre-inputs
    {
        // Move in FixedUpdate b/c this is physics based movement.
        motor.ProcessMove(playerInput.OnFoot.Movement.ReadValue<Vector2>());
    }

    void Update() // Post-physics
    {
    }

    private void LateUpdate()
    {
        Vector2 lookInput = playerInput.OnFoot.Look.ReadValue<Vector2>();
        if (lookInput.Equals(Vector2.zero))
        {
            look.ProcessLookJoystick(playerInput.OnFoot.LookStadiaX.ReadValue<float>(), playerInput.OnFoot.LookStadiaY.ReadValue<float>());
        } else {
            look.ProcessLookMouse(lookInput);
        }
    }

    private void OnEnable() // When script restarts, i.e. when InputManager.cs is saved.
    {
        playerInput = new PlayerInput();
        
        playerInput.OnFoot.Jump.performed += ctx => motor.Jump();
        
        playerInput.OnFoot.Crouch.started += ctx => motor.Crouch();
        playerInput.OnFoot.Crouch.canceled += ctx => motor.Crouch();

        playerInput.OnFoot.Sprint.started += ctx => motor.Sprint();
        playerInput.OnFoot.Sprint.canceled += ctx => motor.Sprint();

        playerInput.OnFoot.Enable();
    }

    private void OnDisable()
    {
        playerInput.OnFoot.Disable();
    }
}
