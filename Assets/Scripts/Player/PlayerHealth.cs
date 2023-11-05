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

        private BoxCollider2D boxCollider;

        private const int maxHealth = 20;

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
            boxCollider = GetComponent<BoxCollider2D>();
        }

        public void TakeDamage(int damageAmount)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damageAmount;
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
                healthSlider.value -= damageAmount;
                onPlayerTakeDamage.TriggerEvent();
                AudioManager.instance.Play("CharaHurt");
                if (currentHealth <= 0)
                {
                    boxCollider.enabled = false;
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

