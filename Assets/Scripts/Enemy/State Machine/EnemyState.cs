using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.StateMachine;
using UnityEngine;

namespace FPGame.Enemy.StateMachine
{
    public abstract class EnemyState 
{
    protected EnemyBase _enemyBase;
    protected EnemySM _enemySM;
    protected EnemyStringHash _enemyStringHash;
    public EnemyState(EnemyBase enemyBase, EnemySM enemySM, EnemyStringHash enemyStringHash)
    {
        _enemyBase = enemyBase;
        _enemySM = enemySM;
        _enemyStringHash = enemyStringHash;
    }

    public virtual void EnterState() {}
    public virtual void ExitState() {}
    public virtual void Update() {}
    public virtual void FixedUpdate() {}
}
}

