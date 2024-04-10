using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.SO_Base.ChaseBase;
using FPGame.Enemy.StateMachine;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.ChaseBase
{
    [CreateAssetMenu(fileName = "ChaseSO", menuName = "Enemy Logic/EnemyChase")]
    public class EnemyChaseSO : EnemyChaseBaseSO 
    {
        private float _movementSpeed = 2.5f;

        public override void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash)
        {
            base.Initialize(go, enemy, animator, enemyStringHash);
        }

        public override void DoEnterLogic()
        {
            GetAnimation();
            Debug.Log("The chase state is active");
        }

        public override void DoExitLogic() {}
        public override void DoUpdate()
        {
            if(_enemy.IsAttackDistance)
            {
                _enemy.EnemySM.ChangeState<AttackEnemyState>();
            }
        }

        public override void DoFixedUpdate()
        {
            TryToChasePlayer();
        }

        public override void GetAnimation()
        {
            _animator.CrossFade(_enemyStringHash.GetAnimationKey(Logic.AnimatorStates.Patrol), 0.1f);
        }

        public void TryToChasePlayer()
        {
            Vector2 direction = _playerTransform.position - _enemy.transform.position;
            var distance = Vector2.Distance(_enemy.transform.position, _playerTransform.position);
            direction.Normalize();
            direction.y = 0;

            if(distance > 1f && _enemy.IsAggro)
            {
                _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _playerTransform.position, _movementSpeed * Time.fixedDeltaTime);
                if(direction.x != 0)
                {
                    _enemy.CheckDirectionToFace(direction.x > 0);
                }
            }
            else if(_enemy.IsAttackDistance)
            {
                _enemy.EnemySM.ChangeState<AttackEnemyState>();
            }
            else
            {
                _enemy.EnemySM.ChangeState<IdleEnemyState>();
            }
        }

    }
}