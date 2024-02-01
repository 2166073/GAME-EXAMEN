using UnityEngine;

public class Player : MonoBehaviour
{
    // Array of sprites for animation
    public Sprite[] sprites;

    // Jump strength when the player presses Space or clicks the mouse
    public float strength = 5f;

    // Gravity affecting the player's vertical movement
    public float gravity = -9.81f;

    // Tilt angle when the player moves up or down
    public float tilt = 5f;

    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    private Vector3 direction;              // Current movement direction
    private int spriteIndex;                 // Index to track the current sprite in the animation

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Get the SpriteRenderer component on the same GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Called on the frame when a script is enabled just before any of the Update methods are called
    private void Start()
    {
        // Start repeating the AnimateSprite method every 0.15 seconds after a delay of 0.15 seconds
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Called when the object becomes enabled and active
    private void OnEnable()
    {
        // Reset the player's position and direction when the player is re-enabled
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Called every frame
    private void Update()
    {
        // Check for input to make the player jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    // Method to animate the sprite by cycling through the array of sprites
    private void AnimateSprite()
    {
        spriteIndex++;

        // Reset spriteIndex if it exceeds the length of the sprites array
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // Set the current sprite based on the spriteIndex
        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    // Called when a Collider2D enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collisions with obstacles and scoring objects
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Trigger Game Over if the player collides with an obstacle
            GameManager.Instance.GameOver();
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            // Increase the score if the player passes through a scoring object
            GameManager.Instance.IncreaseScore();
        }
    }
}
