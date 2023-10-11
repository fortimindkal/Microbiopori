using UnityEngine;

namespace Microbiopori
{
    public class PlayerShield : MonoBehaviour
    {
        private bool isShieldActive = false;

        // Enable the shield.
        public void ActivateShield()
        {
            isShieldActive = true;
            // TODO: Add any visual or gameplay effects for the shield activation.
            Debug.Log("Shield Activated!");
        }

        // Disable the shield.
        public void DeactivateShield()
        {
            isShieldActive = false;
            // TODO: Add any visual or gameplay effects for the shield deactivation.
            Debug.Log("Shield Deactivated!");
        }

        // Check if the shield is currently active.
        public bool IsShieldActive()
        {
            return isShieldActive;
        }
    }
}
