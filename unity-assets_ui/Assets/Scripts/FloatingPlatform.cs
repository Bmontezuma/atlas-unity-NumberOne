using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float floatStrength = 0.5f; // Strength of the floating effect
    public float floatSpeed = 1.0f;    // Speed of the floating effect
    public float moveStrength = 0.2f;  // Strength of the left/right movement
    public float moveSpeed = 0.5f;     // Speed of the left/right movement

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Floating up and down
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatStrength;

        // Moving left and right
        float newX = initialPosition.x + Mathf.Sin(Time.time * moveSpeed) * moveStrength;

        transform.position = new Vector3(newX, newY, initialPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
