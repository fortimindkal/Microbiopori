using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microbiopori
{
    public class Jamur : Enemy
    {
        private bool moveRight = true; // Flag to control the movement direction.

        protected override void Start()
        {
            base.Start();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private  void Update()
        {
            Move();
        }

        protected override void Die()
        {
            base.Die();
        }

        public override void TakeDamage(int damageAmount)
        {
            base.TakeDamage(damageAmount);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            // Handle collisions with other objects.
            if (other.CompareTag("Wall"))
            {
                // Change direction upon collision with an obstacle.
                moveRight = !moveRight;
                Flip();
            }
            base.OnTriggerEnter2D(other);
        }

        private void Move()
        {
            // Move the Jamur left or right based on the moveRight flag.
            float horizontalMovement = moveRight ? enemyData.moveSpeed : -enemyData.moveSpeed;
            Vector3 movement = new Vector3(horizontalMovement, 0, 0) * Time.deltaTime;
            transform.Translate(movement);
        }

        private void Flip()
        {
            // Flip the object when changing direction.
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
