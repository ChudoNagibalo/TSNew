using FPGame.Enemy.Base;
using UnityEngine;

namespace FPGame.Enemy.TriggerChecks
{
    public class EnemyAttackDistanceCheck : MonoBehaviour
{
    public GameObject PlayerTarget {get;set;}
    private EnemyBase _enemy;

    private void Awake() 
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");

        _enemy = GetComponentInParent<EnemyBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject == PlayerTarget)
        {
            _enemy.SetAttackDistance(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject == PlayerTarget)
        {
            _enemy.SetAttackDistance(false);
        }
    }
}
}

