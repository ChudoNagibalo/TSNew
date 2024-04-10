using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.Enemy_Types;
using FPGame.Enemy.SO_Base.AttackBase;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using FPGame.ObjPool;
using UnityEngine;

namespace FPGame.Enemy
{
    [CreateAssetMenu(fileName = "AttackSO", menuName = "Enemy Logic/FlyingAttack")]
    public class FlyingEyeAttackSO : EnemyAttackBaseSO
    {
        private float _cdAttack;
        private float _resetTimer = 1.4f;
    

        public override void DoEnterLogic() 
        {
            _cdAttack = _resetTimer;
        }

        public override void DoExitLogic() {}

        public override void DoUpdate() 
        {

            Debug.Log($" cdAttack {_cdAttack}");
            CheckDistanceBtwObjectcs();

            if(_cdAttack == _resetTimer)
            {
                GetAnimation();
            }

            CDAttackTimer();

        }

        public override void DoFixedUpdate() {}

        public override void GetAnimation() 
        {
            _animator.SetTrigger(_enemyStringHash.GetAnimationKey(Logic.AnimatorStates.BasickAttack));
        }

        public override void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash, FlyingEyeOP flyingEyeOP)
        {
            base.Initialize(go, enemy, animator, enemyStringHash,flyingEyeOP);
        }

        public override void AnimationTriggerEvent(AnimationTriggerType animationTriggerType)
        {
            switch(animationTriggerType)
            {
                case AnimationTriggerType.StartAttack:
                CreateProjectile();
                break;
                // case AnimationTriggerType.CanceledAttack:
                // _attackState = false;
                // break;
            }
        }

        private void CheckDistanceBtwObjectcs()
        {
            var distance = Vector2.Distance(_enemy.transform.position, _playerTransform.position);

            if(distance > 5f && !_enemy.HasTarget)
            {
                _enemy.EnemySM.ChangeState<ChaseEnemyState>();
            }
        }

        private void CreateProjectile()
        {
            _flyingEyeOP.CreateProjectile();
        }

        private void CDAttackTimer()
        {
            _cdAttack -= Time.deltaTime;
            if(_cdAttack <= 0)
            {
                _cdAttack = _resetTimer;
            }
        }
    }
}