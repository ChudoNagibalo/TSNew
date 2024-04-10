using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.Interfaces;
using FPGame.Enemy.StateMachine;
using UnityEngine;

namespace FPGame.Enemy.StateMachine.AllEnemyStates
{
    public class AttackEnemyState : EnemyState
{

    private Transform _playerTransform;
    public AttackEnemyState(EnemyBase enemyBase, EnemySM enemySM, EnemyStringHash hashAnimation) : base(enemyBase, enemySM, hashAnimation)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
   public override void EnterState() 
    {
        _enemyBase.EnemyAttackBaseSO.DoEnterLogic();
    }
    public override void ExitState() 
    {
        _enemyBase.EnemyAttackBaseSO.DoExitLogic();
    }
    public override void Update() 
    {
        _enemyBase.EnemyAttackBaseSO.DoUpdate();
    }
    public override void FixedUpdate() 
    {
        _enemyBase.EnemyAttackBaseSO.DoFixedUpdate();
    }
    public  void GetAnimation()
    {
        _enemyBase.EnemyAttackBaseSO.GetAnimation();
    }

    public void AnimationTriggerEvent(AnimationTriggerType animationTriggerType)
    {
        _enemyBase.EnemyAttackBaseSO.AnimationTriggerEvent(animationTriggerType);
    }
}
}
