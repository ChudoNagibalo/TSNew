using FPGame.Enemy;
using UnityEngine;

namespace FPGame.Enemy.Interfaces
{
    public interface IDamagable
    {
         void TakeDamage(int damageAmount);

         Transform GetTransform();

         void Die();
    }
}


