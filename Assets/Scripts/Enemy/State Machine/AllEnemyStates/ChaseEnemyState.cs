using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using UnityEngine;

namespace FPGame.Enemy.StateMachine.AllEnemyStates
{
    public class ChaseEnemyState : EnemyState
{
    public ChaseEnemyState(EnemyBase enemyBase, EnemySM enemySM, EnemyStringHash hashAnimation) : base(enemyBase, enemySM, hashAnimation)
    {
    }

   public override void EnterState() 
    {
        _enemyBase.EnemyChaseBaseSO.DoEnterLogic();
    }
    public override void ExitState() 
    {
        _enemyBase.EnemyChaseBaseSO.DoExitLogic();
    }
    public override void Update() 
    {
        _enemyBase.EnemyChaseBaseSO.DoUpdate();
    }
    public override void FixedUpdate() 
    {
        _enemyBase.EnemyChaseBaseSO.DoFixedUpdate();
    }

    public void GetAnimation()
    {
        _enemyBase.EnemyChaseBaseSO.GetAnimation();
    }
}
}
