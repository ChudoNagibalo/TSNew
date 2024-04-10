using System;
using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using FPGame.ObjPool;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.AttackBase
{
    public class EnemyAttackBaseSO : ScriptableObject 
    {
        protected EnemyBase _enemy;
        protected Transform _transform;
        protected GameObject _go;
        protected Animator _animator;
        protected EnemyStringHash _enemyStringHash;
        protected FlyingEyeOP _flyingEyeOP;

        protected Transform _playerTransform;

        public virtual void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash, FlyingEyeOP flyingEyeOP)
        {
            _go = go;
            _transform = _go.transform;
            _animator = go.GetComponent<Animator>();
            _enemy = enemy;
            _enemyStringHash = enemyStringHash;
            _flyingEyeOP = flyingEyeOP;

            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public virtual void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash)
        {
            _go = go;
            _transform = _go.transform;
            _animator = go.GetComponent<Animator>();
            _enemy = enemy;
            _enemyStringHash = enemyStringHash;

            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        }

        public virtual void DoEnterLogic() {}
        public virtual void DoExitLogic() {}
        public virtual void DoUpdate() {}
        public virtual void DoFixedUpdate() {}
        public virtual void GetAnimation() {}
        public virtual void AnimationTriggerEvent(AnimationTriggerType animationTriggerType) {}

    }
}