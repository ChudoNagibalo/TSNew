using FPGame.Logic;
using UnityEngine;

namespace FPGame
{
    public class RunState : State
    {
        public RunState(Player player, Animator animator, HashAnimationNamesPlayer hashName, StateMachine stateMachine) : base(player, animator, hashName, stateMachine) 
        { 
        }



        public override void EnterState()
        {
            GetAnimation();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            Run();
            if(_player.Rb.velocity.y > 0 || _player.isJumpPressed)
                _stateMachine.ChangeState<JumpState>();
            if(_player.MovementDirection.x == 0 )
                _stateMachine.ChangeState<IdleState>();
            if(_player.Rb.velocity.y < 0)
                _stateMachine.ChangeState<FallState>();
        }
       
        public override void GetAnimation()
        {
            _animator.CrossFade(_hashNameKey.GetAnimationKey(AnimatorStates.Run), 0.1f);
        }
        public void Run()
        {
            float targetSpeed = _player.MovementDirection.x * _player.data.runMaxSpeed;

            float accelRate;

            if (_player.LastOnGroundTime > 0)
                accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _player.data.runAccelAmount : _player.data.runDeccelAmount;
            else
                accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _player.data.runAccelAmount * _player.data.accelInAir : _player.data.runDeccelAmount * _player.data.deccelInAir;


            if (_player.data.doConserveMomentum && Mathf.Abs(_player.Rb.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(_player.Rb.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && _player.LastOnGroundTime < 0)
            {

                accelRate = 0;
            }

            float speedDif = targetSpeed - _player.Rb.velocity.x;

            float movement = speedDif * accelRate;

            _player.Rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
        }
    }
}
