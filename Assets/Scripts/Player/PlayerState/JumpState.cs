using UnityEngine;
using FPGame.Logic;

namespace FPGame
{
    public class JumpState : State
    {
      
        private float _jumpForce = 14f;
    
        public bool AllowDoubleJump { get; private set; }
     
    
        public JumpState(Player player, Animator animator, HashAnimationNamesPlayer hashName, StateMachine stateMachine) : base(player, animator, hashName, stateMachine)
        {
        }

        public override void EnterState()
        {
            GetAnimation();
        }

        public override void ExitState()
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            Jump();
            _player.RunState.Run();


             if (_player.Rb.velocity.y < 0 )
               _stateMachine.ChangeState<FallState>();

            Debug.Log($"AllowdoubleJumple {AllowDoubleJump}");
        }



        public override void GetAnimation()
        {
            _animator.CrossFade(_hashNameKey.GetAnimationKey(AnimatorStates.Jump), 0.1f);
        }

        public void Jump()
        {
            if (_player.IsGrounded && _player.isJumpPressed)
            {
                _player.Rb.velocity = new Vector2(_player.Rb.velocity.x, _jumpForce);
                AllowDoubleJump = true;
                _player.isJumpPressed = false;
            }

             if (AllowDoubleJump && !_player.IsGrounded && _player.isJumpPressed)
            {
                _player.Rb.velocity = new Vector2(_player.Rb.velocity.x, _jumpForce);
                _player.isJumpPressed = false;
                AllowDoubleJump = false;
            }
        }
    }
}
