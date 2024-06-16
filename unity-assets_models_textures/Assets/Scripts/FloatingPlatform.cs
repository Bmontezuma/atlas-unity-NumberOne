using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float amplitude = 0.5f;  // The height of the floating movement
    public float speed = 1f;        // The speed of the floating movement

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate new position
        float newX = initialPosition.x + Mathf.Sin(Time.time * speed) * amplitude;
        float newY = initialPosition.y + Mathf.Cos(Time.time * speed * 0.5f) * amplitude;
        float newZ = initialPosition.z + Mathf.Sin(Time.time * speed * 0.75f) * amplitude;

        transform.position = new Vector3(newX, newY, newZ);
    }
}
