using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X"); /*Recoge la rotación X*/
        float inputY = Input.GetAxis("Mouse Y"); /*Recoge la rotación Y*/
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f); /*Max Y Rotation*/
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation; /*Transmite la rotación Y*/

        cameraVerticalRotation += inputX;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f); /*Max X Rotation*/
        transform.localEulerAngles = Vector3.up * cameraVerticalRotation; /*Transmite la rotación X*/
    }
}
