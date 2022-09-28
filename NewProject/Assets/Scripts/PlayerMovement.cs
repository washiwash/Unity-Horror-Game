using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 10f;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
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

        body.velocity = new Vector3(velocity.x, body.velocity.y, velocity.z);
    }
}
