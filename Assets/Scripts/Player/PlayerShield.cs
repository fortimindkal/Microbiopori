using System.Collections;
using UnityEngine;

namespace Microbiopori
{
    public class PlayerShield : MonoBehaviour
    {
        [SerializeField] private float shieldDuration = 10.0f;

        private Animator anim;
        private bool isShieldActive = false;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Enable the shield.
        public void ActivateShield()
        {
            anim.SetBool("isShield", true);
            isShieldActive = true;
            AudioManager.instance.Play("CollectingPowerup");
            StartCoroutine(DeactivateShieldAfterDuration(shieldDuration));
            // TODO: Add any visual or gameplay effects for the shield activation.
            Debug.Log("Shield Activated!");
        }

        // Disable the shield.
        public void DeactivateShield()
        {
            anim.SetBool("isShield", false);
            isShieldActive = false;
            // TODO: Add any visual or gameplay effects for the shield deactivation.
            Debug.Log("Shield Deactivated!");
        }

        // Check if the shield is currently active.
        public bool IsShieldActive()
        {
            return isShieldActive;
        }

        private IEnumerator DeactivateShieldAfterDuration(float duration)
        {
            yield return new WaitForSeconds(duration);

            // Deactivate the shield.
            DeactivateShield();
        }
    }
}
