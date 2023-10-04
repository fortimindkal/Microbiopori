using UnityEngine;

namespace Microbiopori
{
    public class Collectible : MonoBehaviour
    {
        public int points = 10; // The number of points the collectible gives to the player when collected.
        public AudioClip collectSound; // Sound to play when the collectible is picked up.

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the collectible has collided with the player (or another object with a specific tag).
            if (other.CompareTag("Player"))
            {
                // Add points to the player's score.
                GameManager.instance.AddScore(points);

                // Play a collect sound if specified.
                if (collectSound != null)
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                }

                // Destroy the collectible object.
                Destroy(gameObject);
            }
        }
    }
}
