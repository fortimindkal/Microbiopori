using UnityEngine;

namespace Microbiopori
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData enemyData; // Reference to the EnemyData Scriptable Object.

        protected int currentHealth;

        protected virtual void Start()
        {
            currentHealth = enemyData.maxHealth;
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
    }
}
