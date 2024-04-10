using UnityEngine;

namespace FPGame.Enemy.Interfaces
{
   public interface IEnemyMovable 
{
   Rigidbody2D RB { get;set;}
   bool IsFacingRight {get; set;}
   void MoveEnemy(float speed) ;
   void CheckDirectionToFace(bool isMovingRight );
}
}

