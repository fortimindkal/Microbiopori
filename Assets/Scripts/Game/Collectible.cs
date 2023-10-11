using UnityEngine;
using UnityEngine.Events;

namespace Microbiopori
{
    public class Collectible : MonoBehaviour
    {
        public int points = 10; // The number of points the collectible gives to the player when collected.
        public int healthIncrease = 1; // The amount to increase the player's health.
        public AudioClip collectSound; // Sound to play when the collectible is picked up.

        public GameEvent onPlayerCollect;

        private void Start()
        {
            onPlayerCollect.OnEventTriggered.AddListener(CoinCollect);
        }

        private void OnDestroy()
        {
            onPlayerCollect.OnEventTriggered.RemoveListener(CoinCollect);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collectible has collided with the player (or another object with a specific tag).
            if (other.CompareTag("Player"))
            {
                // Access the PlayerHealth script (assuming you have one).
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

                // Check if the playerHealth is not null.
                if (playerHealth != null)
                {
                    // Increase the player's health.
                    playerHealth.Heal(healthIncrease);
                }

                // Add points to the player's score.
                onPlayerCollect.TriggerEvent();

                // Play a collect sound if specified.
                if (collectSound != null)
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                }

                // Destroy the collectible object.
                Destroy(gameObject);
            }
        }

        public void CoinCollect()
        {
            GameManager.Instance.AddScore(points);
        }
    }
}
