using FPGame.Enemy.Base;
using UnityEngine;

namespace FPGame.Enemy.Enemy_Types
{
    public class MushroomBase : EnemyBase
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHelth ;
        public override int MaxHealth {get {return _maxHealth;} set {_maxHealth = value;}}
        public override int CurrentHealth {get {return _currentHelth;} set {_currentHelth = value;}}
    }
}