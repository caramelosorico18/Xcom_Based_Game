using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //*??
        xRotation -= mouseY;

        //Max Rotation
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation + 8.98f, yRotation + 2.24f, 0f);
    }
}
