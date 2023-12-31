using System.Collections;
using UnityEngine;

namespace Microbiopori
{
    public class PowerUp : MonoBehaviour
    {
        public float duration = 10f; // Duration of the power-up.

        public GameEvent onPlayerPickPowerup;

        private void Start()
        {
            //onPlayerPickPowerup.OnEventTriggered.AddListener();
        }

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
                    
                }

                // Disable the power-up object.
                gameObject.SetActive(false);
            }
        }

        
    }
}
