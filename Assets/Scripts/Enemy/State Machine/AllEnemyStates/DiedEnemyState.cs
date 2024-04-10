using FPGame.Enemy.Base;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.StateMachine;
using UnityEngine;

namespace FPGame.Enemy.StateMachine.AllEnemyStates
{
    public class DiedEnemyState : EnemyState
    {
        public DiedEnemyState(EnemyBase enemyBase, EnemySM enemySM, EnemyStringHash hashAnimation) : base(enemyBase, enemySM, hashAnimation) {}

        public override void EnterState() 
        {
            _enemyBase.EnemyDiedBaseSO.DoEnterLogic();
        }
        public override void FixedUpdate() 
        {
            _enemyBase.EnemyDiedBaseSO.DoFixedUpdate();
        }
        public override void Update() 
        {
            _enemyBase.EnemyDiedBaseSO.DoUpdate();
        }

        public  void GetAnimation()
        {
           _enemyBase.EnemyDiedBaseSO.GetAnimation();
        }
    }
}