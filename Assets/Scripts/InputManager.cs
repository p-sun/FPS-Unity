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
        playerInput = new PlayerInput();
        motor = GetComponent<PlayerMotor>();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(playerInput.OnFoot.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerInput.OnFoot.Enable();
    }

    private void OnDisable()
    {
        playerInput.OnFoot.Disable();
    }
}
