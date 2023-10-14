using UnityEngine;
using UnityEngine.UI;

namespace Microbiopori
{
    public class PlayerHealth : MonoBehaviour
    {
        public int currentHealth;

        public Slider healthSlider;

        public GameEvent onPlayerDeathEvent;
        public GameEvent onPlayerTakeDamage;

        private const int maxHealth = 10;

        private void Start()
        {
            //onPlayerDeathEvent.OnEventTriggered.AddListener(GameManager.Instance.GameOver);
            onPlayerDeathEvent.OnEventTriggered.AddListener(GetComponent<PlayerController>().SetPlayerDead);
            onPlayerTakeDamage.OnEventTriggered.AddListener(GetComponent<PlayerController>().SetPlayerDamaged);

            InitializeHealth();
            UpdateHealthUI();
        }

        private void InitializeHealth()
        {
            currentHealth = maxHealth;
            healthSlider.value = currentHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damageAmount;
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
                onPlayerTakeDamage.TriggerEvent();

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
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
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

