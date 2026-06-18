using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController Instance { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public Quaternion currentRotation;
    public float mouseSensitivity = 300f;
    public float xRotation = 0f;
    public float yRotation = 0f;
    public float mouseY;
    public float mouseX;
    public GameObject camera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        yRotation += mouseX;

        RotacionActual();
    }
    public void RotacionActual()
    {
        currentRotation = Quaternion.Euler(xRotation + 8.98f, yRotation + 2.24f, 0f);
    }
}
