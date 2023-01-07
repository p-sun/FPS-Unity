using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInput.OnFootActions onFoot;

    void Awake()
    {
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }
    private void OnEnable() // When script restarts, i.e. when InputManager.cs is saved.
    {
        PlayerInput playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Enable();
    }

    private void Reset()
    {
    }

    private void Start()
    {
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.started += ctx => motor.Crouch();
        onFoot.Crouch.canceled += ctx => motor.Crouch();

        onFoot.Sprint.started += ctx => motor.Sprint();
        onFoot.Sprint.canceled += ctx => motor.Sprint();
    }

    private void FixedUpdate() // Pre-physics & Pre-inputs
    {
        // Move in FixedUpdate b/c this is physics based movement.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void Update() // Post-physics
    {
    }

    private void LateUpdate()
    {
        Vector2 lookInput = onFoot.Look.ReadValue<Vector2>();
        if (lookInput.Equals(Vector2.zero))
        {
            look.ProcessLookJoystick(onFoot.LookStadiaX.ReadValue<float>(), onFoot.LookStadiaY.ReadValue<float>());
        } else {
            look.ProcessLookMouse(lookInput);
        }
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
