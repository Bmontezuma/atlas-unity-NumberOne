using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlane : MonoBehaviour
{
    public GameObject[] cubes;  // Array to hold all the cubes in the level
    public float jumpForce = 10f;  // Force applied to the player for the jump

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get a random cube
            GameObject randomCube = cubes[Random.Range(0, cubes.Length)];

            // Calculate the direction and force of the jump
            Vector3 direction = (randomCube.transform.position - other.transform.position).normalized;
            Vector3 jumpVector = direction * jumpForce;

            // Apply the jump force to the player
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(jumpVector, ForceMode.Impulse);
            }
        }
    }
}
