using System;
using UnityEngine;

namespace FPGame
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _countDamage;

        public static Action<int> onDamageTaken;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            onDamageTaken?.Invoke(_countDamage);
        }

    }
}
