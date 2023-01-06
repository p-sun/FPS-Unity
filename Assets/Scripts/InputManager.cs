using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMotor motor;

    void Awake()
    {
        motor = GetComponent<PlayerMotor>();
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

    private void OnEnable() // When script restarts, i.e. when InputManager.cs is saved.
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Jump.performed += ctx => motor.Jump();
        playerInput.OnFoot.Enable();
    }

    private void OnDisable()
    {
        playerInput.OnFoot.Disable();
    }
}
