using UnityEngine;

namespace FPGame.Enemy.Interfaces
{
   public interface ITriggerCheck 
{
   bool IsAggro {get;set;}
   bool IsAttackDistance {get;set;}

   void SetAggroStatus(bool isAggro);
   void SetAttackDistance(bool isAttackDistance);
}
}

