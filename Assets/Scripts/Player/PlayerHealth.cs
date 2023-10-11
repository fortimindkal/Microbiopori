using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;

    public Text healthUI;
    public Slider healthSlider;

    // UnityEvents to handle health changes and player death.
    public UnityEvent<int, int> OnHealthChangedEvent = new UnityEvent<int, int>();
    public UnityEvent OnPlayerDeathEvent = new UnityEvent();

    private const int maxHealth = 10;

    private void Start()
    {
        InitializeHealth();
        UpdateHealthUI();
    }

    private void InitializeHealth()
    {
        currentHealth = maxHealth;
        healthUI.text = "Health : " + currentHealth.ToString();
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            // Trigger the health changed UnityEvent.
            OnHealthChangedEvent.Invoke(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth += healAmount;
            //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthUI.text = "Health : " + currentHealth.ToString();
            healthSlider.value = currentHealth;

            // Trigger the health changed UnityEvent.
            OnHealthChangedEvent.Invoke(currentHealth, maxHealth);

            Debug.Log("Heal");
        }
    }

    private void Die()
    {
        // Trigger the player death UnityEvent.
        OnPlayerDeathEvent.Invoke();
    }

    private void UpdateHealthUI()
    {
        // Trigger the health changed UnityEvent.
        OnHealthChangedEvent.Invoke(currentHealth, maxHealth);
    }
}
