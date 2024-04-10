using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.WanderBase
{
    public class EnemyWanderBaseSO : ScriptableObject
    {
        protected EnemyBase _enemy;
        protected Transform _transform;
        protected GameObject _go;
        protected Animator _animator;
        protected EnemyStringHash _enemyStringHash;
        protected Transform _playerTransform;

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