using System.Collections;
using System.Collections.Generic;
using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.SO_Base.IdleBase;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using UnityEngine;

namespace FPGame.Enemy
{
    [CreateAssetMenu(fileName = "IdleSO", menuName = "Enemy Logic/FlyingEyeIdle")]
    public class FlyingEyeIdleSO : EnemyIdleBaseSo
    {
        private float _timer, _reset = 4f;
        private float Duration {get;set;} = 0f;

        public override void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash)
        {
            base.Initialize(go, enemy, animator, enemyStringHash);
        }

        public override void DoEnterLogic()
        {
            _timer = _reset;
            GetAnimation();
        }

        public override void DoExitLogic() {}

        public override void DoUpdate()
        {
            TimeToPatrol();
            IsAggroed();
            isAttackDistance();
        }

        public override void DoFixedUpdate() {}

        public override void GetAnimation()
        {
            _animator.CrossFade(_enemyStringHash.GetAnimationKey(Logic.AnimatorStates.Idle), 0.1f);
        }

        public void TimeToPatrol()
        {
            _timer -= Time.deltaTime;
            if(_timer < Duration)
            {
                _enemy.EnemySM.ChangeState<ChaseEnemyState>();
            }
        }

        public void IsAggroed()
        {
            if(_enemy.IsAggro)
            {
                _enemy.EnemySM.ChangeState<ChaseEnemyState>();
            }
        }

        public void isAttackDistance()
        {
            if(_enemy.IsAttackDistance)
            {
                _enemy.EnemySM.ChangeState<AttackEnemyState>();
            }
        }
    }
}