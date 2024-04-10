using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.Interfaces;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.AttackBase
{
    [CreateAssetMenu(fileName = "AttackSO", menuName = "Enemy Logic/EnemyAttack")]
    public class EnemyAttackSO : EnemyAttackBaseSO
    {

        private float _delayBtwStates , _reset = 0.9f;

        public override void DoEnterLogic() 
        {
            Attack();
        }
        public override void DoExitLogic() { _delayBtwStates = _reset;}
        public override void DoUpdate() 
        {
            CheckDistanceBtwObjectcs();

            if(_enemy.HasTarget)
            {
                Attack();
            }

        }
        public override void DoFixedUpdate() {}
        public override void  Initialize(GameObject go , EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash)
        {
            base.Initialize(go, enemy, animator,enemyStringHash);
        }

        public override void GetAnimation()
        {
            _animator.SetTrigger(_enemyStringHash.GetAnimationKey(Logic.AnimatorStates.BasickAttack));
        }

        public void Attack()
        {
            GetAnimation();
        }

        public void OnAttack()
        {
            var hitPlayer = Physics2D.OverlapCircleAll(_enemy.AttackPoint.position, _enemy.AttackRange,_enemy.PlayerLayer);
            if(hitPlayer == null)
            {
                return;
            }
            
            foreach(var player in hitPlayer)
            {
                player.GetComponent<IDamagable>().TakeDamage(Random.Range(10,20));
            }

        }

        public void CheckDistanceBtwObjectcs()
        {
            var distance = Vector2.Distance(_enemy.transform.position, _playerTransform.position);
            Debug.DrawLine(_enemy.transform.position, _playerTransform.position, Color.green);

            if(distance > 2f && !_enemy.HasTarget)
            {
                if(CheckDelay() <= 0)
                {
                    _enemy.EnemySM.ChangeState<ChaseEnemyState>();
                }
            }
        }

        public override void AnimationTriggerEvent(AnimationTriggerType animationTriggerType)
        {
           switch (animationTriggerType)
           {
            case AnimationTriggerType.CheckPlayerCollider:
             OnAttack();
             break;
           }
          
        }

        private float CheckDelay()
        {
            return _delayBtwStates -= Time.deltaTime;
        }
    }
}