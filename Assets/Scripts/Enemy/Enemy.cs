using UnityEngine;

namespace Microbiopori
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData enemyData; // Reference to the EnemyData Scriptable Object.

        protected int currentHealth;

        public GameEvent onEnemyAttack;

        protected virtual void Start()
        {
            onEnemyAttack.OnEventTriggered.AddListener(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().UpdateHealthUI);
            currentHealth = enemyData.maxHealth;
        }

        protected virtual void OnDestroy()
        {
            onEnemyAttack.OnEventTriggered.RemoveListener(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().UpdateHealthUI);
        }

        public virtual void TakeDamage(int damageAmount)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damageAmount;
                currentHealth = Mathf.Clamp(currentHealth, 0, enemyData.maxHealth);

                if (currentHealth <= 0)
                {
                    Die();
                }
            }
        }

        protected virtual void Die()
        {
            // Implement enemy death logic here.
            // Play the death sound from the enemyData if specified.
            if (enemyData.deathSound != null)
            {
                AudioSource.PlayClipAtPoint(enemyData.deathSound, transform.position);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the enemy collides with the player.
            if (other.CompareTag("Player"))
            {
                // Deal damage to the player.
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(enemyData.damage);
                }

                onEnemyAttack.TriggerEvent();

                // Destroy the enemy on contact with the player.
                Destroy(gameObject);
            }
        }
    }
}
