using UnityEngine;

namespace FPGame
{
    public abstract class State
    {
        protected Player _player;
        protected Animator _animator;
        protected HashAnimationNamesPlayer _hashNameKey;
        protected StateMachine _stateMachine;

        protected State(Player player,Animator animator, HashAnimationNamesPlayer hashName, StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _animator = animator;
            _player = player;
            _hashNameKey = hashName;
        }
        public virtual void EnterState() { }
       

        public virtual void ExitState() { }

        public virtual void Update() { }

        public virtual void FixedUpdate() { }

        public virtual void GetAnimation() { }

    }
}

