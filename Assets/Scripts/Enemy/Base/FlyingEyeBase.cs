using System.Collections.Generic;
using FPGame.Enemy.Base;
using FPGame.ObjPool;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace FPGame.Enemy.Enemy_Types
{
    public class FlyingEyeBase : EnemyBase
    {

        [Header("Health")]
        [SerializeField] private int _maxHealth = 100;

        private int _currentHealth;
        public override int MaxHealth {get {return _maxHealth;} set{_maxHealth = value;}}
        public override int CurrentHealth {get { return _currentHealth;} set {_currentHealth = value;}}
    }
}