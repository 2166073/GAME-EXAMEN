using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Reference to the prefab to be spawned
    public GameObject prefab;

    // Rate at which the prefabs are spawned per second
    public float spawnRate = 1f;

    // Minimum and maximum height values for random vertical positioning
    public float minHeight = -1f;
    public float maxHeight = 2f;

    // Called when the object becomes enabled and active
    private void OnEnable()
    {
        // Start repeating the Spawn method with the specified spawn rate
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Called when the object becomes disabled or inactive
    private void OnDisable()
    {
        // Cancel the repeating invocation of the Spawn method
        CancelInvoke(nameof(Spawn));
    }

    // Method to spawn prefabs
    private void Spawn()
    {
        // Instantiate a prefab at the spawner's position with no rotation
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        // Adjust the spawned prefab's position vertically within the specified range
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}

