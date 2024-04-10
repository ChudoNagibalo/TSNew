using System;
using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace FPGame.Enemy.StateMachine.AllEnemyStates
{
    public class WanderEnemyState : EnemyState
{
    public WanderEnemyState(EnemyBase enemyBase, EnemySM enemySM, EnemyStringHash hashAnimation) : base(enemyBase, enemySM, hashAnimation)
    {
    }

    public override void EnterState() 
    {
        _enemyBase.EnemyWanderBaseSO.DoEnterLogic();
    }

    public override void ExitState() 
    {
        _enemyBase.EnemyWanderBaseSO.DoExitLogic();
    }
    public override void Update() 
    {
        _enemyBase.EnemyWanderBaseSO.DoUpdate();
    }
    public override void FixedUpdate() 
    {
        _enemyBase.EnemyWanderBaseSO.DoFixedUpdate();
    }
    public void GetAnimation()
    {
        _enemyBase.EnemyWanderBaseSO.GetAnimation();
    }
}

}
