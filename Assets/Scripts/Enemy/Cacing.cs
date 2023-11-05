using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Microbiopori
{
    public class Cacing : Enemy
    {
        [SerializeField] private Animator anim;

        private bool moveRight = true; // Flag to control the movement direction.

        protected override void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        private void Update()
        {
            Attack();
        }

        protected override void Die()
        {
            base.Die();
        }

        public override void TakeDamage(int damageAmount)
        {
            base.TakeDamage(damageAmount);
        }

        private void Attack()
        {
            anim.SetBool("isAttack", true);
        }
    }
}
