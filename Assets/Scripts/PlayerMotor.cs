using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;

    private Vector3 playerVelocity;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessMove(Vector2 input) {
        Vector3 moveDir = new Vector3(input.x, 0, input.y);
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);
    }
}
