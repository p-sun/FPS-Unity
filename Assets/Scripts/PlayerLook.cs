using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    Vector2 mouseSensitivity = new Vector2(40f, 30f);
    Vector2 joystickSensitivity = new Vector2(100f, 100f);

    private float camRotX = 0f;

    public void ProcessLookMouse(Vector2 input)
    {
        _ProcessLook(input.x, input.y, mouseSensitivity);
    }

    public void ProcessLookJoystick(float x, float y)
    {
        _ProcessLook(x, y * -1, joystickSensitivity);
    }

    private void _ProcessLook(float x, float y, Vector2 sensitivity)
    {
        // Rotate camera up-down
        camRotX -= y * sensitivity.y * Time.deltaTime;
        camRotX = Mathf.Clamp(camRotX, -40f, 40f);
        cam.transform.localRotation = Quaternion.Euler(camRotX, 0, 0);

        // Rotate player left-right
        transform.Rotate(Vector3.up * x * sensitivity.x * Time.deltaTime);
    }
}
