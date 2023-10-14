using UnityEngine;

namespace Microbiopori
{
    public class EnemyBackup : MonoBehaviour
    {
        public float moveSpeed = 3f; // Enemy movement speed.
        public int damageAmount = 10; // Amount of damage the enemy inflicts on the player.

        private Transform player; // Reference to the player's Transform.
        private bool isFollowingPlayer = false;

        private void Start()
        {
            // Find the player GameObject and store its Transform.
            player = GameObject.FindGameObjectWithTag("Player").transform;

            // Start following the player.
            isFollowingPlayer = true;
        }

        private void Update()
        {
            if (isFollowingPlayer && player != null)
            {
                // Move towards the player.
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the enemy collides with the player.
            if (other.CompareTag("Player"))
            {
                // Deal damage to the player.
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                PlayerShield playerShield = other.GetComponent<PlayerShield>();
                if (playerHealth != null)
                {
                    if(!playerShield.IsShieldActive())
                    {
                        playerHealth.TakeDamage(damageAmount);
                        Debug.Log("Take Damage");
                    }
                    else
                    {
                        playerShield.DeactivateShield();
                    }
                }

                // Destroy the enemy on contact with the player.
                Destroy(gameObject);
            }
        }
    }
}

