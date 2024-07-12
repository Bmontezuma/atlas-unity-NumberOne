using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] targets; // Array of target positions
    public float speed = 5f; // Speed of the platform
    public float delayTime = 1f; // Delay time at each position

    private Vector3 startPosition; // Starting position of the platform
    private int targetIndex = 0; // Current target index
    private float t = 0; // Time variable for lerping
    private bool isMoving = false; // Flag to check if the platform is moving

    void Start()
    {
        startPosition = transform.position; // Cache the start position
        if (targets.Length > 0)
        {
            StartCoroutine(MovePlatform());
        }
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            isMoving = true;
            Vector3 targetPosition = targets[targetIndex].position;
            float journeyLength = Vector3.Distance(transform.position, targetPosition);
            float journeyTime = journeyLength / speed;

            while (t < journeyTime)
            {
                t += Time.deltaTime;
                float normalizedTime = t / journeyTime;
                float lerpSpeed = Mathf.SmoothStep(0, 1, normalizedTime); // Lerp speed for smoother movement
                transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed);
                yield return null;
            }

            transform.position = targetPosition;
            t = 0;
            isMoving = false;

            yield return new WaitForSeconds(delayTime);

            targetIndex = (targetIndex + 1) % targets.Length; // Cycle through the target positions
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    void OnDrawGizmos()
    {
        if (targets.Length > 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPosition, targets[0].position);
            for (int i = 0; i < targets.Length - 1; i++)
            {
                Gizmos.DrawLine(targets[i].position, targets[i + 1].position);
            }
            Gizmos.DrawLine(targets[targets.Length - 1].position, startPosition);
        }
    }
}
