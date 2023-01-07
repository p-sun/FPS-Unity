using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float gravity = -30f;
    // Constants
    public float walkSpeed = 5;
    public float sprintSpeed = 16;
    public float jumpHeight = 1.5f;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool crouching = false;
    private float crouchTimer = -1f;

    private bool sprinting = false;
    private float speed;

    private void Awake()
    {
        speed = walkSpeed;
    }

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

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        speed = sprinting ? sprintSpeed : walkSpeed;
    }

    // Private Update -----------------
    private void Update()
    {
        _UpdateCrouch();
    }

    private void _UpdateCrouch()
    {
        if (crouchTimer >= 0)
        {
            crouchTimer += Time.deltaTime;
            float p = Mathf.Pow(crouchTimer / 1, 1.6f); // Crouch is slow at first then fast

            // 2 - Player is exactly standing at ground height. 1 - Numbers height OR lower than 1 will move player UP.
            float targetHeight = crouching ? 1f : 2f;
            controller.height = Mathf.Lerp(controller.height, targetHeight, p);
            if (p > 1) {
                crouchTimer = -1f;
            }
        }
    }
}
