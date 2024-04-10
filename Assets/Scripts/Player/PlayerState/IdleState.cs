using UnityEngine;
using FPGame.Logic;

namespace FPGame
{
    public class IdleState : State
    {
        public IdleState(Player player, Animator animator, HashAnimationNamesPlayer hashName, StateMachine stateMachine) : base(player, animator, hashName, stateMachine)
        {

        }

        public override void Update()
        {
            if (_player.MovementDirection.x != 0)
                _stateMachine.ChangeState<RunState>();
             if(_player.isJumpPressed || _player.Rb.velocity.y > 0)
                _stateMachine.ChangeState<JumpState>();
        }

        public override void EnterState()
        {
            GetAnimation();
        }

        public override void ExitState() 
        {

        }
       
        public override void GetAnimation()
        {
            _player._animator.CrossFade(_hashNameKey.GetAnimationKey(AnimatorStates.Idle), 0.3f);

        }
    }
}
