using UnityEngine;
using FPGame.Logic;

namespace FPGame
{
    public class FallState: State
    {
        public FallState(Player player, Animator animator, HashAnimationNamesPlayer hashName,StateMachine stateMachine) : base(player, animator, hashName, stateMachine)
        {
        }

        public override void EnterState()
        {
            GetAnimation();
            _player.isJumpPressed = false;
        }

        public override void ExitState()
        {
            
        }

        public override void Update()
        {
            if (_player.IsGrounded )
                _stateMachine.ChangeState<IdleState>();
            if(_player.IsGrounded && _player.MovementDirection.x != 0)
                _stateMachine.ChangeState<RunState>();
            if(_player.isJumpPressed && _player._jumpState.AllowDoubleJump)
                _stateMachine.ChangeState<JumpState>(); 
        }
        public override void GetAnimation()
        {
            _animator.CrossFade(_hashNameKey.GetAnimationKey(AnimatorStates.Fall), 0.1f);
        }
    }
}
