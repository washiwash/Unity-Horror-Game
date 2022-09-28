using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector2 sens = new Vector2(400f, 400f);
    [SerializeField] private Vector2 rotation;
    [SerializeField] private Transform playerTransform;

    [Header("Mouse")]
    [SerializeField] private Vector2 mouseDelta;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens.x,
                                    Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens.y);

        // Player Horizontal Rotation
        playerTransform.Rotate(Vector3.up * mouseDelta.x);

        // Camera Vertical Rotation
        rotation.x = Mathf.Clamp(rotation.x - mouseDelta.y, -85f, 85f);
        transform.localEulerAngles = Vector3.right * rotation.x;
    }
}
