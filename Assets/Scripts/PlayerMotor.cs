using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -30f;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 playerVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = new Vector3(input.x, 0, input.y);
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        if (controller.isGrounded)
        {
            playerVelocity.y = -2f;
        }
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
