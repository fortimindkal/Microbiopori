using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player.
    public int currentHealth; // Current health of the player.

    // Events to handle health changes and player death.
    public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);
    public event HealthChangedDelegate OnHealthChanged;
    public delegate void PlayerDeathDelegate();
    public event PlayerDeathDelegate OnPlayerDeath;

    private void Start()
    {
        // Initialize the player's health.
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Call this function to apply damage to the player.
    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            // Trigger the health changed event.
            UpdateHealthUI();

            // Check if the player has died.
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    // Call this function to heal the player.
    public void Heal(int healAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            // Trigger the health changed event.
            UpdateHealthUI();
        }
    }

    // Handle player death.
    private void Die()
    {
        // Trigger the player death event.
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
    }

    // Update the UI or perform other actions when health changes.
    private void UpdateHealthUI()
    {
        // Trigger the health changed event.
        if (OnHealthChanged != null)
        {
            OnHealthChanged(currentHealth, maxHealth);
        }
    }
}
