using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.StateMachine;

public class IdleEnemyState : EnemyState
{
    public IdleEnemyState(EnemyBase enemyBase, EnemySM enemySM, EnemyStringHash hashAnimation) : base(enemyBase, enemySM,hashAnimation) {}
    public override void EnterState() 
    {
        _enemyBase.EnemyIdleBaseSo.DoEnterLogic();
    }
    public override void ExitState() 
    {
        _enemyBase.EnemyIdleBaseSo.DoExitLogic();
    }
    public override void Update() 
    {
        _enemyBase.EnemyIdleBaseSo.DoUpdate();
    }
    public override void FixedUpdate() 
    {
        _enemyBase.EnemyIdleBaseSo.DoFixedUpdate();
    }

    public void GetAnimation()
    {
        _enemyBase.EnemyIdleBaseSo.GetAnimation();
    }
}
