using System.Collections;
using UnityEngine;

namespace Microbiopori
{
    public class PowerUp : MonoBehaviour
    {
        public float duration = 10f; // Duration of the power-up.
        public AudioClip powerUpSound; // Sound to play when the power-up is picked up.

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the power-up has collided with the player (or another object with a specific tag).
            if (other.CompareTag("Player"))
            {
                // Get the PlayerShield component (assuming you have one).
                PlayerShield playerShield = other.GetComponent<PlayerShield>();

                // Check if the playerShield is not null.
                if (playerShield != null)
                {
                    // Activate the shield.
                    playerShield.ActivateShield();

                    // Start a coroutine to deactivate the shield after a duration.
                    StartCoroutine(DeactivateShieldAfterDuration(playerShield));
                }

                // Play a power-up sound if specified.
                if (powerUpSound != null)
                {
                    AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
                }

                // Disable the power-up object.
                gameObject.SetActive(false);
            }
        }

        private IEnumerator DeactivateShieldAfterDuration(PlayerShield playerShield)
        {
            yield return new WaitForSeconds(duration);

            // Deactivate the shield.
            playerShield.DeactivateShield();
        }
    }
}
