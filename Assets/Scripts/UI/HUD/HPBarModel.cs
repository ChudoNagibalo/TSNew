using System;
using UnityEngine;

namespace FPGame.UI.HUD
{
     public class HPBarModel
    {
        public event Action PlayerMaxHPChanged;
        public event Action PlayerCurrentHPChanged;

        private int _maxPlayerHP;
        private int _currentHP;
        public int CurrentHP => _currentHP;
        public int MaxPlayerHP => _maxPlayerHP;

        public HPBarModel(int maxPlayerHp, int currentHP)
        {
            _maxPlayerHP = maxPlayerHp;
            _currentHP = currentHP;
        }

        public void SetPlayerMaxHP(int maxHP)
        {
            _maxPlayerHP = maxHP;
            PlayerMaxHPChanged?.Invoke();
        }

        public void SetPlayerCurrentHP(int currentHP)
        {
            _currentHP = currentHP;
            PlayerCurrentHPChanged?.Invoke();
        }


    }
}

