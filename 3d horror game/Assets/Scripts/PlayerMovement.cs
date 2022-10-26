using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float velY = 0f;
    [SerializeField] private float gravity = -10f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private bool isCrouching = false;
    [SerializeField] private float crouchSpeed = 3f;
    [SerializeField] private float crouchHeight = 1.2f;
    [SerializeField] private float standHeight = 2f;
    [SerializeField][Range(0.0f, 0.5f)] private float runSmoothTime = 0.3f;
    [SerializeField] private float currentSpeed = 0f;
    Vector3 forwardSpeed;
    Vector3 sidewardSpeed;

    private CharacterController characterController;

    [Header("Control Binds")]
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode crouchKey = KeyCode.LeftControl;
    public bool crouchToggle = false;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Crouch();
    }

    private void FixedUpdate()
    {
        
    }

    private void Move()
    {
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDir.Normalize();

        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
            sidewardSpeed = transform.right * inputDir.x * currentSpeed;
        }
        else if (Input.GetKey(runKey))
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, runSpeed, ref currentSpeed, runSmoothTime);
            currentSpeed = Mathf.Clamp(currentSpeed, 0, runSpeed);
            sidewardSpeed = transform.right * inputDir.x * walkSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
            sidewardSpeed = transform.right * inputDir.x * walkSpeed;
        }

        forwardSpeed = transform.forward * currentSpeed * inputDir.y;
        Vector3 velocity = forwardSpeed + sidewardSpeed + Vector3.up * velY;

        if (characterController.isGrounded)
            velY = 0f;

        velY += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    private void Crouch()
    {
        if (!crouchToggle)
        {
            if (Input.GetKey(crouchKey))
                isCrouching = true;
            else
                isCrouching = false;
        }
        else
            if (Input.GetKeyDown(crouchKey))
                isCrouching = !isCrouching;

        if (isCrouching)
        {
            if (characterController.height > crouchHeight)
                characterController.height -= Time.deltaTime * 3;
            else
                characterController.height = crouchHeight;
        }
        else
        {
            if (characterController.height < standHeight)
                characterController.height += Time.deltaTime * 3;
            else
                characterController.height = standHeight;
        }
    }
}
