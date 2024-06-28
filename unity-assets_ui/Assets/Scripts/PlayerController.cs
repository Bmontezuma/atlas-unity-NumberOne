using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    public float jumpForce = 10f; // Force applied to jump
    public float fallThreshold = -10f; // Threshold for falling off the platforms
    public Transform startPosition; // Reference to the start position

    Rigidbody rb;  // Reference to the Rigidbody component
    Vector3 lastStablePosition;  // To store the last stable position

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component on the Player GameObject
        lastStablePosition = transform.position;  // Initialize last stable position to the starting position
    }

    void Update()
    {
        // Handle player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        // Handle player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            FallFromTop();
        }
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)  // Check if the player is grounded (vertically stationary)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // Apply jump force
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Adjust the tag as per your platform GameObjects
        {
            lastStablePosition = transform.position;  // Update last stable position when colliding with a platform
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathZone"))  // Adjust the tag for your death zone
        {
            Respawn();
        }
    }

    void FallFromTop()
    {
        Vector3 topPosition = new Vector3(startPosition.position.x, 20f, startPosition.position.z);  // Set the top position
        transform.position = topPosition;  // Teleport player to the top position
        rb.velocity = Vector3.zero;  // Reset player's velocity
        rb.angularVelocity = Vector3.zero;  // Reset player's angular velocity
    }

    void Respawn()
    {
        transform.position = lastStablePosition;  // Teleport player to last stable position
        rb.velocity = Vector3.zero;  // Reset player's velocity
        rb.angularVelocity = Vector3.zero;  // Reset player's angular velocity
    }
}
