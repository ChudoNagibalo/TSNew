using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.WanderBase
{
    [CreateAssetMenu(fileName = "WanderSO", menuName = "Enemy Logic/ EnemyWander")]
    public class EnemyWanderSO : EnemyWanderBaseSO
    {
        private float _currentSpeed = 2f;
        private float _changeDirectionTime = -1f;
        private int _minCountNumber = 3;
        private int _maxCountNumber = 4;
        private int _counterObstecles;
        private int _reset = 0;

        public override void DoEnterLogic() 
        {
            GetAnimation();
        }

        public override void DoExitLogic() 
        {
            _counterObstecles = _reset;
        }

        public override void DoUpdate() 
        {
            TimeToIdlePos(_counterObstecles);
            IsAggroed();
            TryToAttack();
        }

        public override void DoFixedUpdate() 
        {
            if(IsHittingObstecles())
            {
                _currentSpeed *= _changeDirectionTime;
            }
            _enemy.MoveEnemy(_currentSpeed);
        }
        public override void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash)
        {
            base.Initialize(go,enemy, animator, enemyStringHash);
        }

        private bool IsHittingObstecles()
        {
            var obstacle = false;

            float castDistance;

            if(_enemy.transform.localScale.x > 0)
            {
                castDistance = _enemy.CastDistanceObs;
            }
            else
            {
                castDistance = -_enemy.CastDistanceObs;
            }

            Vector3 targetPos = _enemy.CheckObstacles.position;
            targetPos.x += castDistance;

            Debug.DrawLine(_enemy.CheckObstacles.position, targetPos, Color.blue );

            if(Physics2D.Linecast(_enemy.CheckObstacles.position, targetPos, 1 << LayerMask.NameToLayer("Obstacle")))
            {
                obstacle = true;
                _counterObstecles ++;
            }
            else
            {
                obstacle = false;
            }

            return obstacle;
        }

        public override void GetAnimation()
        {
            _animator.CrossFade(_enemyStringHash.GetAnimationKey(Logic.AnimatorStates.Patrol), 0.1f);
        }

        private void TimeToIdlePos(float counter)
        {
            if(counter == UnityEngine.Random.Range(_minCountNumber,_maxCountNumber))
            {
                _enemy.EnemySM.ChangeState<IdleEnemyState>();
            }
        }

        public void IsAggroed()
        {
            if(_enemy.IsAggro)
            {
                _enemy.EnemySM.ChangeState<ChaseEnemyState>();
            }
        }

        public void TryToAttack()
        {
            if(_enemy.IsAttackDistance)
            {
                _enemy.EnemySM.ChangeState<AttackEnemyState>();
            }
        }
    }
}