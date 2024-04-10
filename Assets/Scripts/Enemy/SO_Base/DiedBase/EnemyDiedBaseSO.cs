using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.DiedBase
{
    public class EnemyDiedBaseSO : ScriptableObject 
    {
        protected EnemyBase _enemy;
        protected Transform _transform;
        protected GameObject _go;
        protected Animator _animator;
        protected EnemyStringHash _enemyStringHash;
        protected Rigidbody2D _rigidbody;

        public virtual void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash, Rigidbody2D rigidbody2D)
        {
            _go = go;
            _transform = go.transform;
            _rigidbody = go.GetComponent<Rigidbody2D>();
            _animator = go.GetComponent<Animator>();
            _enemy = enemy;
            _enemyStringHash = enemyStringHash;
        }

        public virtual void DoEnterLogic() {}
        // public virtual void DoExitLogic() {}
        public virtual void DoUpdate() {}
        public virtual void DoFixedUpdate() {}
        public virtual void GetAnimation() {}
        public virtual void AnimationTriggerEvent(AnimationTriggerType animationTriggerType) {}
    }
}