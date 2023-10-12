using UnityEngine;
using UnityEngine.UI;

namespace Microbiopori
{
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth;

        public Text healthUI;
        public Slider healthSlider;

        public GameEvent onPlayerDeathEvent;

        private const int maxHealth = 10;

        private void Start()
        {
            onPlayerDeathEvent.OnEventTriggered.AddListener(GameManager.Instance.GameOver);

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

                Debug.Log("Heal");
            }
        }

        private void Die()
        {
            // Trigger the player death UnityEvent.
            onPlayerDeathEvent.TriggerEvent();
        }

        public void UpdateHealthUI()
        {
            // Trigger the health changed UnityEvent.
            healthSlider.value = currentHealth;
        }
    }
}

