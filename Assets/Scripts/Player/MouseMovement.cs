using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    bool lockCursor = true;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // even if frame rate is high makes it so that camera doesn't change speeds
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);


        if (Input.GetKeyDown(KeyCode.Z))
        {
            lockCursor = !lockCursor;
        }


        if (lockCursor == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (lockCursor == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

}
