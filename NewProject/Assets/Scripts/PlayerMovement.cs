using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 10f;
    private CharacterController control;

    private void Start()
    {
        control = GetComponent<CharacterController>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;

        control.Move(velocity * Time.deltaTime);
    }
}
