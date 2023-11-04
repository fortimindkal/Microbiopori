using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microbiopori
{
    public class Bakteri : Enemy
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
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
            base.OnTriggerEnter2D(other);
        }
    }
}
