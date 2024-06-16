using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform component
    public float cameraMoveSpeed = 5f;  // Speed of the camera movement
    public float rotationSpeed = 3f;  // Speed of the camera rotation

    private Vector3 offset;  // Offset distance between the camera and player

    void Start()
    {
        offset = transform.position - player.position;  // Calculate initial offset
    }

    void Update()
    {
        // Follow the player smoothly
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);

        // Rotate the camera based on mouse input
        RotateCamera();
    }

    void RotateCamera()
    {
        // Rotate the camera using mouse input
        if (Input.GetMouseButton(1))  // Right mouse button held down
        {
            float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float verticalRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(player.position, Vector3.up, horizontalRotation);
            transform.RotateAround(player.position, transform.right, -verticalRotation);

            // Ensure camera doesn't flip upside down
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.z = 0;
            transform.eulerAngles = currentRotation;
        }
    }
}