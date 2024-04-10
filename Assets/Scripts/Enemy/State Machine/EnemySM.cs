using System;
using System.Collections.Generic;
using FPGame.Enemy.Base;
using FPGame.Enemy.StateMachine;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using UnityEngine;

namespace FPGame.Enemy.StateMachine
{
    public class EnemySM 
{
    private EnemyBase _enemyBase;
    Dictionary<Type, EnemyState> _statesEnemy = new Dictionary<Type, EnemyState>();
    public EnemyState CurrentEnemyState {get;set;}

    public EnemySM(EnemyBase enemyBase) 
    {
        _enemyBase = enemyBase;
    }
    public void AddState(EnemyState state)
    {
        _statesEnemy.Add(state.GetType(), state);
    }

    public void ChangeState <T>() where T : EnemyState
    {
        if(_enemyBase.IsAlive)
        {
            var type = typeof(T);
            if(CurrentEnemyState != null && CurrentEnemyState.GetType() == type)
            {
                return;
            }
            if(_statesEnemy.TryGetValue(type, out EnemyState newState))
            {
                CurrentEnemyState?.ExitState();
                CurrentEnemyState = newState;
                CurrentEnemyState.EnterState();
            }
        }
    }

    public void Update()
    {
        CurrentEnemyState?.Update();
    }

    public void FixedUpdate()
    {
        CurrentEnemyState?.FixedUpdate();
    }
}
}

