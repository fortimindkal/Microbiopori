using UnityEngine;

namespace Microbiopori
{
    public class Obstacle : MonoBehaviour
    {
        public ObstacleData obstacleData; // Reference to the ObstacleData Scriptable Object.

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the obstacle has collided with the player (or another object with a specific tag).
            if (other.CompareTag("Player"))
            {
                // Get the PlayerHealth component (assuming you have one).
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

                // Check if the playerHealth is not null.
                if (playerHealth != null)
                {
                    // Decrease the player's health based on the obstacle's data.
                    playerHealth.TakeDamage(obstacleData.healthImpact);
                }

                // Play a collision sound if specified in the ObstacleData.
                if (obstacleData.collisionSound != null)
                {
                    AudioSource.PlayClipAtPoint(obstacleData.collisionSound, transform.position);
                }

                // Optionally, disable or destroy the obstacle object.
                //gameObject.SetActive(false); // Disable the obstacle.
                // Destroy(gameObject); // Destroy the obstacle.
            }
        }
    }
}
