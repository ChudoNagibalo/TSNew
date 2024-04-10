using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace FPGame
{


    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth;

        public Image _slider;

        private void Awake()
        {
            _health = _maxHealth;
            _slider.fillAmount = _health;
        }

        private void ConsoleMessage(int value)
        {
            _health -= value;
            if( _health > 0 )
            {
                Debug.Log($"Ti live {_health}");
            }
            else if( _health <= 0 )
            {
                Debug.Log($"You died {_health}");
                return;
            }
       
        }


        private void OnEnable()
        {
            DamageComponent.onDamageTaken += ConsoleMessage;
        }

        private void OnDestroy()
        {
            DamageComponent.onDamageTaken -= ConsoleMessage;
        }

    }
}
