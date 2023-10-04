using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn.
    public Transform[] spawnPoints; // An array of spawn points.
    public float spawnInterval = 2f; // The time between spawns.

    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        // Update the timer.
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new object.
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f; // Reset the timer.
        }
    }

    private void SpawnObject()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points assigned to the SpawnManager.");
            return;
        }

        // Choose a random spawn point from the array.
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the object at the chosen spawn point.
        Instantiate(objectToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);
    }
}
