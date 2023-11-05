using UnityEngine;

namespace Microbiopori
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject coinPrefab;
        public GameObject powerupPrefab;
        public GameObject[] obstaclePrefab;
        public GameObject[] enemyPrefab;
        public GameObject wormPrefab;

        public Transform[] coinSpawnPoints;
        public Transform[] powerupSpawnPoints;
        public Transform[] obstacleSpawnPoints;
        public Transform[] enemySpawnPoints;
        public Transform[] wormSpawnPoints;

        public float coinSpawnInterval = 2f;
        public float powerupSpawnInterval = 5f;
        public float enemySpawnInterval = 3f;
        public float wormSpawnInterval = 4f;

        private float coinTimeSinceLastSpawn = 0f;
        private float powerupTimeSinceLastSpawn = 0f;
        private float enemyTimeSinceLastSpawn = 0f;
        private float wormTimeSinceLastSpawn = 0f;

        public float coinSpawnRange = 10f;
        public float powerupSpawnRange = 15f;
        public float enemySpawnRange = 10f;
        public float obstacleSpawnRange = 3f;
        public float wormSpawnRange = 10f;

        public float[] obstacleSpawnIntervals; // Array of possible spawn intervals for obstacles.
        private float obstacleTimeSinceLastSpawn = 0f;

        private void Update()
        {
            if(GameManager.Instance.state == GameState.Playing)
            {
                SpawnCoins();
                SpawnPowerups();
                SpawnObstacles();
                SpawnEnemy();
                SpawnWorms(); // Add this line.
            }
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

            if (obstacleTimeSinceLastSpawn >= GetRandomObstacleSpawnInterval())
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

        private void SpawnWorms()
        {
            wormTimeSinceLastSpawn += Time.deltaTime;

            if (wormTimeSinceLastSpawn >= wormSpawnInterval)
            {
                if (wormSpawnPoints.Length > 0)
                {
                    Transform randomSpawnPoint = wormSpawnPoints[Random.Range(0, wormSpawnPoints.Length)];
                    Instantiate(wormPrefab, GetRandomPosition(randomSpawnPoint, wormSpawnRange), randomSpawnPoint.rotation);
                }
                wormTimeSinceLastSpawn = 0f;
            }
        }

        private float GetRandomObstacleSpawnInterval()
        {
            // Choose a random obstacle spawn interval from the array of possible intervals.
            return obstacleSpawnIntervals[Random.Range(0, obstacleSpawnIntervals.Length)];
        }

        private Vector3 GetRandomPosition(Transform spawnPoint, float range)
        {
            Vector3 randomOffset = Random.insideUnitSphere * range;
            randomOffset.z = 0; // Ensure it's in the same plane as the spawn point.
            return spawnPoint.position + randomOffset;
        }
    }
}