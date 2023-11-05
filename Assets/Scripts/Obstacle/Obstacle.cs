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
                PlayerShield playerShield = other.GetComponent<PlayerShield>();

                if(playerShield.IsShieldActive())
                {
                    playerShield.DeactivateShield();
                }
                else
                {
                    // Check if the playerHealth is not null.
                    if (playerHealth != null)
                    {
                        // Decrease the player's health based on the obstacle's data.
                        playerHealth.TakeDamage(obstacleData.healthImpact);
                    }
                }

                // Optionally, disable or destroy the obstacle object.
                //gameObject.SetActive(false); // Disable the obstacle.
                // Destroy(gameObject); // Destroy the obstacle.
            }
        }
    }
}
