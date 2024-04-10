using FPGame.Enemy;
using FPGame.Enemy.Interfaces;
using FPGame.Logic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPGame
{
    public class AttackBasickState : State
    {

        private float _duration;
        public float _attackRange = 1f;
        private int _amountDamage;
        protected float Fixedtime { get; set; }

        public AttackBasickState(Player player, Animator animator, HashAnimationNamesPlayer hashName, StateMachine stateMachine) : base(player, animator, hashName, stateMachine)
        {
        }

        public override void EnterState()
        {
            _duration = 0.5f;
            Attack();
            GetAnimation();
        }
        public override void ExitState()
        {
            Fixedtime = 0;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            Fixedtime += Time.deltaTime;
            if (Fixedtime >= _duration)
                _stateMachine.ChangeState<IdleState>();
        }
        public override void GetAnimation()
        {
            _animator.CrossFade(_hashNameKey.GetAnimationKey(AnimatorStates.BasickAttack), 0.1f);
        }

        private void Attack()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_player.AttackPointTrans.position, _attackRange, _player.EnemyLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
              
                IDamagable enemyHP = enemy.GetComponent<IDamagable>();
                enemyHP.TakeDamage(DamageRandom());
                Debug.Log("We hit " + enemy.name);
                DamagePopup.Create(enemyHP.GetTransform().position, DamageRandom());
            }
        }

        public int DamageRandom()
        {
            var maxDmg = 15;
            var minDmg = 10;
           return  _amountDamage = UnityEngine.Random.Range(minDmg,maxDmg);
        }

    }
}

