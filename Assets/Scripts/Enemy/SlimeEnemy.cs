using UnityEngine;

namespace Microbiopori
{
    public class SlimeEnemy : Enemy
    {
        protected override void Start()
        {
            base.Start();
            // Additional initialization specific to SlimeEnemy.
        }//

        public override void TakeDamage(int damageAmount)
        {
            base.TakeDamage(damageAmount);

            // Additional behavior for when the slime enemy takes damage.
        }

        protected override void Die()
        {
            base.Die();

            // Additional behavior for when the slime enemy dies.
        }

        // Additional behaviors specific to SlimeEnemy.
        public void SlimeJump()
        {
            // Implement slime jump logic here.
        }
    }
}
