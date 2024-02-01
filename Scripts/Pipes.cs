using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Transform top;    // Reference to the top part of the pipe
    public Transform bottom; // Reference to the bottom part of the pipe
    public float speed = 5f; // Speed at which the pipe moves to the left

    private float leftEdge;   // Left edge of the screen in world coordinates

    // Called on the frame when a script is enabled just before any of the Update methods are called
    private void Start()
    {
        // Calculate the left edge of the screen in world coordinates with an additional offset
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Called every frame
    private void Update()
    {
        // Move the pipe to the left based on the specified speed
        transform.position += speed * Time.deltaTime * Vector3.left;

        // Check if the pipe has moved beyond the left edge of the screen
        if (transform.position.x < leftEdge)
        {
            // Destroy the pipe GameObject if it is no longer visible
            Destroy(gameObject);
        }
    }
}

