using FPGame;
using FPGame.Logic;
using UnityEngine;

public class HashAnimationNamesPlayer 
{
    private static readonly int IdleKey = Animator.StringToHash("Player_Idle");
    private static readonly int RunKey = Animator.StringToHash("Player_Run");
    private static readonly int JumpKey = Animator.StringToHash("Player_Jump");
    private static readonly int FallKey = Animator.StringToHash("Player_Fall");
    private static readonly int HitKey = Animator.StringToHash("Player_Hit");
    private static readonly int DiedKey = Animator.StringToHash("Player_Died");
    private static readonly int BasickAttackKey = Animator.StringToHash("Player_BasickAttack");
    private static readonly int Attack = Animator.StringToHash("IsAttack");
    

    public int GetAnimationKey(AnimatorStates state)
    {
        int hashName;
        if (state == AnimatorStates.Idle)
            hashName = IdleKey;
        else if (state == AnimatorStates.Run)
            hashName = RunKey;
        else if(state == AnimatorStates.Jump)
            hashName = JumpKey;
        else if(state == AnimatorStates.Fall)
            hashName = FallKey;
        else if(state == AnimatorStates.Hit)
            hashName = HitKey;
        else if(state == AnimatorStates.BasickAttack)
            hashName = BasickAttackKey;
        else if(state == AnimatorStates.Died)
            hashName = DiedKey;
        else
            hashName = default;
        return hashName;
    }
}
