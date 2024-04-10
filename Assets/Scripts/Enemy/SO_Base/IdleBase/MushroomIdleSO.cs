using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.IdleBase
{
    [CreateAssetMenu(fileName = "IdleSO", menuName = "Enemy Logic/MushroomIdle")]
    public class MushroomIdleSO : EnemyIdleBaseSo
    {
        private float _timer , _reset = 7f;
        private float Duration {get;set;} = 0f;

        public override void DoEnterLogic()
        {
            _timer = _reset;
            GetAnimation();
        }
        public override void DoExitLogic()
        {
        }
        public override void DoUpdate()
        {
            TimeToPatrol();
            IsAggroed();
        }
        public override void DoFixedUpdate() {}
        public override void GetAnimation()
        {
            _animator.CrossFade(_enemyStringHash.GetAnimationKey(Logic.AnimatorStates.Idle), 0.1f);
        }

        public override void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash)
        {
            base.Initialize(go, enemy, animator, enemyStringHash);
        }

        public void TimeToPatrol()
        {
            _timer -= Time.deltaTime;
            if(_timer <= Duration)
            {
                _enemy.EnemySM.ChangeState<WanderEnemyState>();
            }
        }

        public void IsAggroed()
        {
            if(_enemy.IsAggro)
            {
                _enemy.EnemySM.ChangeState<ChaseEnemyState>();
            }
        }
    }
}