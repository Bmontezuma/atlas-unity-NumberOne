using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public float turnSpeed = 5.0f; // Rotation speed for camera movement
    public bool isInverted = false; // Flag to invert Y axis movement

    private Vector3 offset; // Offset between camera and player

    void Start()
    {
        // Calculate the initial offset between camera and player
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Follow the player
        transform.position = player.transform.position + offset;

        // Rotate the camera based on mouse input
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * turnSpeed;

        if (isInverted)
        {
            mouseY *= -1; // Invert Y axis movement
        }

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        offset = rotation * offset;

        // Make sure the camera always looks at the player
        transform.LookAt(player.transform);
    }
}
