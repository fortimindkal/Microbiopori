using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject powerupPrefab;
    public GameObject[] obstaclePrefab;
    public GameObject[] enemyPrefab;

    public Transform[] coinSpawnPoints;
    public Transform[] powerupSpawnPoints;
    public Transform[] obstacleSpawnPoints;
    public Transform[] enemySpawnPoints;

    public float coinSpawnInterval = 2f;
    public float powerupSpawnInterval = 5f;
    public float obstacleSpawnInterval = 3f;
    public float enemySpawnInterval = 3f;

    private float coinTimeSinceLastSpawn = 0f;
    private float powerupTimeSinceLastSpawn = 0f;
    private float obstacleTimeSinceLastSpawn = 0f;
    private float enemyTimeSinceLastSpawn = 0f;

    public float coinSpawnRange = 10f;
    public float powerupSpawnRange = 15f;
    public float obstacleSpawnRange = 10f;
    public float enemySpawnRange = 10f;

    private void Update()
    {
        SpawnCoins();
        SpawnPowerups();
        SpawnObstacles();
        SpawnEnemy();
    }

    private void SpawnCoins()
    {
        coinTimeSinceLastSpawn += Time.deltaTime;

        if (coinTimeSinceLastSpawn >= coinSpawnInterval)
        {
            if (coinSpawnPoints.Length > 0)
            {
                Transform randomSpawnPoint = coinSpawnPoints[Random.Range(0, coinSpawnPoints.Length)];
                Instantiate(coinPrefab, GetRandomPosition(randomSpawnPoint, coinSpawnRange), randomSpawnPoint.rotation);
            }
            coinTimeSinceLastSpawn = 0f;
        }
    }

    private void SpawnPowerups()
    {
        powerupTimeSinceLastSpawn += Time.deltaTime;

        if (powerupTimeSinceLastSpawn >= powerupSpawnInterval)
        {
            if (powerupSpawnPoints.Length > 0)
            {
                Transform randomSpawnPoint = powerupSpawnPoints[Random.Range(0, powerupSpawnPoints.Length)];
                Instantiate(powerupPrefab, GetRandomPosition(randomSpawnPoint, powerupSpawnRange), randomSpawnPoint.rotation);
            }
            powerupTimeSinceLastSpawn = 0f;
        }
    }

    private void SpawnObstacles()
    {
        obstacleTimeSinceLastSpawn += Time.deltaTime;

        if (obstacleTimeSinceLastSpawn >= obstacleSpawnInterval)
        {
            if (obstacleSpawnPoints.Length > 0)
            {
                Transform randomSpawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)];
                GameObject randomObstaclePrefab = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];
                Instantiate(randomObstaclePrefab, GetRandomPosition(randomSpawnPoint, obstacleSpawnRange), randomSpawnPoint.rotation);
            }
            obstacleTimeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        enemyTimeSinceLastSpawn += Time.deltaTime;

        if (enemyTimeSinceLastSpawn >= enemySpawnInterval)
        {
            if (enemySpawnPoints.Length > 0)
            {
                Transform randomSpawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
                GameObject randomEnemyPrefab = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
                Instantiate(randomEnemyPrefab, GetRandomPosition(randomSpawnPoint, enemySpawnRange), randomSpawnPoint.rotation);
            }
            enemyTimeSinceLastSpawn = 0f;
        }
    }

    private Vector3 GetRandomPosition(Transform spawnPoint, float range)
    {
        Vector3 randomOffset = Random.insideUnitSphere * range;
        randomOffset.z = 0; // Ensure it's in the same plane as the spawn point.
        return spawnPoint.position + randomOffset;
    }
}
