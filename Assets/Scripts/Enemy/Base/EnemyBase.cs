using System;
using System.Collections;
using System.Collections.Generic;
using FPGame.Enemy.EnemiesHashAnimations;
using FPGame.Enemy.Enemy_Types;
using FPGame.Enemy.Interfaces;
using FPGame.Enemy.SO_Base.AttackBase;
using FPGame.Enemy.SO_Base.ChaseBase;
using FPGame.Enemy.SO_Base.DiedBase;
using FPGame.Enemy.SO_Base.IdleBase;
using FPGame.Enemy.SO_Base.WanderBase;
using FPGame.Enemy.StateMachine;
using FPGame.Enemy.StateMachine.AllEnemyStates;
using FPGame.Logic;
using FPGame.ObjPool;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace FPGame.Enemy.Base
{
    public abstract class EnemyBase : MonoBehaviour, IEnemyMovable, ITriggerCheck, IDamagable
{
    [SerializeField] private FlyingEyeOP flyingOP;
    [SerializeField] private Transform _checkObstacles;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Collider2D _collider2D;
    private bool _isAlive = true;
    public bool IsAlive => _isAlive;
    private bool hasTarget;
    public bool HasTarget => hasTarget;
    private event Action  EnemyChangeHPEvent ;
    public Action EnemyChangeHPGetEvent {get { return EnemyChangeHPEvent;} set {value = EnemyChangeHPEvent;}}
    public Transform AttackPoint => _attackPoint;
    [SerializeField] private float castDistanceObs = 0.5f;
    private Animator _animator;
    public Transform CheckObstacles => _checkObstacles;
    public float CastDistanceObs => castDistanceObs;
    public bool _invertScale;

    #region  SOStates
    [SerializeField] private EnemyAttackBaseSO enemyAttackBaseSO;
    [SerializeField] private EnemyIdleBaseSo enemyIdleBaseSo;
    [SerializeField] private EnemyChaseBaseSO enemyChaseBaseSO;
    [SerializeField] private EnemyWanderBaseSO enemyWanderBaseSO;
    [SerializeField] private EnemyDiedBaseSO enemyDiedBaseSO;

    public EnemyAttackBaseSO EnemyAttackBaseSO {get;set;}
    public EnemyIdleBaseSo EnemyIdleBaseSo {get;set;}
    public EnemyChaseBaseSO EnemyChaseBaseSO {get;set;}
    public EnemyWanderBaseSO EnemyWanderBaseSO {get;set;}
    public EnemyDiedBaseSO EnemyDiedBaseSO {get;set;}
    #endregion

    [SerializeField] private float _randomMovementRange = 3f;
    [SerializeField] private float _randomMovementSpeed = 1f;

    public float RandomMovementRange  {get {return _randomMovementRange;}}
    public float RandomMovementSpeed {get {return _randomMovementSpeed;}}



    public abstract int MaxHealth {get;set;}
    public abstract int CurrentHealth {get;set;}

    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight {get; set; }

    public EnemySM EnemySM {get;set;}
    protected EnemyStringHash EnemyStringHash {get;set;}
    public AttackEnemyState AttackEnemyState {get;set;}
    public WanderEnemyState PatrolEnemyState {get;set;}
    public ChaseEnemyState ChaseEnemyState {get;set;}
    public IdleEnemyState IdleEnemyState {get;set;}
    public DiedEnemyState DiedEnemyState {get;set;}
    public bool IsAggro { get;set;}
    public bool IsAttackDistance { get;set;}
    [SerializeField] private float _attackRange = 0.5f;
    public float AttackRange => _attackRange;
    [SerializeField] private LayerMask _playerLayer;
    public LayerMask PlayerLayer => _playerLayer;


    private void Awake() 
    {
        CurrentHealth = MaxHealth;
        EnemyStringHash = new EnemyStringHash();
        _collider2D = GetComponent<Collider2D>();




        EnemyIdleBaseSo = Instantiate(enemyIdleBaseSo);
        EnemyChaseBaseSO = Instantiate(enemyChaseBaseSO);
        EnemyAttackBaseSO = Instantiate(enemyAttackBaseSO);
        EnemyWanderBaseSO = Instantiate(enemyWanderBaseSO);
        EnemyDiedBaseSO = Instantiate(enemyDiedBaseSO);

        EnemySM = new EnemySM(this);

        AttackEnemyState = new AttackEnemyState(this, EnemySM,EnemyStringHash);
        PatrolEnemyState = new WanderEnemyState(this,EnemySM,EnemyStringHash);
        ChaseEnemyState = new ChaseEnemyState(this, EnemySM,EnemyStringHash);
        IdleEnemyState = new IdleEnemyState(this, EnemySM,EnemyStringHash);
        DiedEnemyState = new DiedEnemyState (this, EnemySM, EnemyStringHash);
    }

    public void Start() 
    {
        

        RB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        IsFacingRight = true;
        _invertScale = false;
        

        EnemySM.AddState(new WanderEnemyState(this,EnemySM,EnemyStringHash));
        EnemySM.AddState(new ChaseEnemyState(this,EnemySM,EnemyStringHash));
        EnemySM.AddState(new AttackEnemyState(this,EnemySM,EnemyStringHash));
        EnemySM.AddState(new IdleEnemyState(this,EnemySM,EnemyStringHash));
        EnemySM.AddState(new DiedEnemyState(this,EnemySM,EnemyStringHash));

        EnemyIdleBaseSo.Initialize(gameObject, this, _animator, EnemyStringHash);
        EnemyChaseBaseSO.Initialize(gameObject, this, _animator, EnemyStringHash);
        EnemyAttackBaseSO.Initialize(gameObject, this, _animator, EnemyStringHash, flyingOP);
        EnemyWanderBaseSO.Initialize(gameObject, this, _animator, EnemyStringHash);
        EnemyDiedBaseSO.Initialize(gameObject,this, _animator, EnemyStringHash, RB);


        EnemySM.ChangeState<IdleEnemyState>();

    }

    private void Update() 
    {
        EnemySM.Update();
        Debug.Log($" {EnemySM.CurrentEnemyState}");
        TimeToDestroy();
    }

    private void FixedUpdate() 
    {
        EnemySM.FixedUpdate();
    }


    public void TakeDamage(int damageAmount)
    {
     
        CurrentHealth -= damageAmount;

        _animator.SetTrigger(EnemyStringHash.GetAnimationKey(AnimatorStates.Hit));
        _animator.ResetTrigger(EnemyStringHash.GetAnimationKey(AnimatorStates.BasickAttack));
        
        
        
        if(CurrentHealth <= 0)
        {
            Die();
            _isAlive = false;
            _collider2D.enabled = false;
        }
    }
   

    public void Die()
    {
        EnemySM.ChangeState<DiedEnemyState>();
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void MoveEnemy( float speed)
    {
        RB.velocity = new Vector2(speed, RB.velocity.y);
        if(RB.velocity.x != 0)
        {
            CheckDirectionToFace(RB.velocity.x > 0);
        }
    }

   public void Turn()
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            IsFacingRight = !IsFacingRight; 
        }
    public void CheckDirectionToFace(bool isMovingRight)
        {
            if (isMovingRight != IsFacingRight)
            {
                 Turn();
            }
        }
    
    private void AttackEvent(AnimationTriggerType animationTriggerType) 
    {
        EnemyAttackBaseSO.AnimationTriggerEvent(animationTriggerType);
    }

    private void DiedEvevnt(AnimationTriggerType animationTriggerType)
    {
        EnemyDiedBaseSO.AnimationTriggerEvent(animationTriggerType);
    }

    public void SetAggroStatus(bool isAggro)
    {
        IsAggro = isAggro;
    }

    public void SetAttackDistance(bool isAttackDistance)
    {
        IsAttackDistance = isAttackDistance;
        if(IsAttackDistance)
        {
            hasTarget = true;
        }
        else{
            hasTarget = false;
        }
    }


    public void OnDrawGizmos()
    {
        if(AttackPoint == null) return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }

    public void TimeToDestroy()
    {
        if(!_isAlive)
        {
            Destroy(gameObject, 3f);
        }
    }
}
}

