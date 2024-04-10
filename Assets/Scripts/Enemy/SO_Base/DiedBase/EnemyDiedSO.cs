using System;
using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.Enemy_Types;
using FPGame.Enemy.SO_Base.DiedBase;
using FPGame.Logic;
using UnityEditor.Animations;
using UnityEngine;

namespace FPGame.Enemy.SO_Base.DiedBase 
{
    [CreateAssetMenu(fileName = "DiedSO", menuName = "Enemy Logic/EnemyDied")]
    public class EnemyDiedSO : EnemyDiedBaseSO 
    {

        public override void DoEnterLogic()
        {
            GetAnimation();
        }

        public override void DoUpdate()
        {
            
        }

        public override void DoFixedUpdate()
        {
        }

        public override void Initialize(GameObject go, EnemyBase enemy, Animator animator, EnemyStringHash enemyStringHash,Rigidbody2D rigidbody2D)
        {
            base.Initialize(go, enemy, animator, enemyStringHash, rigidbody2D);
        }

        public override void GetAnimation()
        {
            _animator.CrossFade(_enemyStringHash.GetAnimationKey(AnimatorStates.Died), 1f);
        }

        public override void AnimationTriggerEvent(AnimationTriggerType animationTriggerType)
        {
            if(AnimationTriggerType.Died == animationTriggerType)
            {

            }

            if(AnimationTriggerType.StopAnimator == animationTriggerType)
            {
                _animator.enabled = false;
            }
        }
    }
}