using System.Collections.Generic;
using System.Diagnostics;
using FPGame.Logic;
using UnityEditor.Animations;
using UnityEngine;

namespace FPGame.Enemy.EnemiesHashAnimations
{
    public class EnemyStringHash
    {
        private static readonly int AttackKey  = Animator.StringToHash("IsAttack");
        private static readonly int IdleKey = Animator.StringToHash("Idle");
        private static readonly int PatrolKey = Animator.StringToHash("Patrol");
        private static readonly int DeathKey = Animator.StringToHash("Death");
        private static readonly int HitKey = Animator.StringToHash("IsHitting");


        public int GetAnimationKey(AnimatorStates state)
        {
            return state switch
            {
                AnimatorStates.Idle => IdleKey,
                AnimatorStates.Patrol => PatrolKey,
                AnimatorStates.BasickAttack => AttackKey,
                AnimatorStates.Died => DeathKey,
                AnimatorStates.Hit => HitKey,
                _ => IdleKey
            };
            
        }
    }
}