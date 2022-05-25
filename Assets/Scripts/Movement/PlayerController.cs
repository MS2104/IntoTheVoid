using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera settings")]
    [SerializeField] Transform playerCamera = null;
    [SerializeField] [Range(0.1f, 5f)] float mouseSensitivity = 2f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.025f;

    [Header("Movement settings")]
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] [Range(0.0f, 10f)] float jumpSpeed = 6f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.25f;

    [Header("Cursor settings")]
    [SerializeField] bool lockCursor = true;

    public float jumpForce;
    float cameraPitch = 0f;

    // This value keeps track of the downwards speed. It is set to 0 by default.
    float velocityY = 0f;

    Vector3 moveVelocity;

    CharacterController controller = null;

    // These two smooth the movement of the player.
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    // These two smooth the mouse movement so you can look around S M O O T H L Y
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateMouseLook();

        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        // Gravity basically
        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // This makes sure the downwards velocity is set to 0 as long as you are touching the ground.
        if (controller.isGrounded)
        {
            velocityY = 0f;
        }
        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY; // Gravity works independently from walkspeed, therefore it is not needed to multiply it with the walkspeed.
        controller.Move(velocity * Time.deltaTime);
    }
}