using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private Vector2 sens = new Vector2(400f, 400f);
    [SerializeField] private Vector2 rotation;

    [Header("Mouse")]
    [SerializeField] private Vector2 mousePosition;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        mousePosition = new Vector2(Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens.x,
                                    Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens.y);

        rotation.y += mousePosition.x;
        rotation.x = Mathf.Clamp(rotation.x - mousePosition.y, -85f, 85f);

        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
    }
}
