using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float animationSpeed = 1f; // Speed at which the texture offset is animated
    private MeshRenderer meshRenderer; // Reference to the MeshRenderer component

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Get the MeshRenderer component on the same GameObject
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Called every frame
    private void Update()
    {
        // Update the main texture offset to create a parallax effect
        // The offset is applied to the X-coordinate to simulate horizontal movement
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
