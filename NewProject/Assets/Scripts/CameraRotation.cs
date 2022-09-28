using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector2 sens = new Vector2(4f, 4f);
    [SerializeField][Range(0.0f, 0.5f)] private float cameraSmoothTime = 0.03f;
    [SerializeField] private Vector2 rotation = Vector2.zero;
    [SerializeField] private Transform playerTransform;

    [Header("Mouse")]
    [SerializeField] private Vector2 currentMouseDelta = Vector2.zero;
    [SerializeField] private Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxisRaw("Mouse X") * sens.x, Input.GetAxisRaw("Mouse Y") * sens.y);
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, cameraSmoothTime);

        // Player Horizontal Rotation
        playerTransform.Rotate(Vector3.up * currentMouseDelta.x);

        // Camera Vertical Rotation
        rotation.x = Mathf.Clamp(rotation.x - currentMouseDelta.y, -85f, 85f);
        transform.localEulerAngles = Vector3.right * rotation.x;
    }
}
