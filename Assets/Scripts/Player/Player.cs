using FPGame.Enemy.Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace FPGame
{
    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField] private ParticleSystem _dust;
        public PlayerData data;
        public Image image;
        public Animator _animator;
        public InputReader _inputReader;
        public JumpState _jumpState;
        private RunState _runState;
        public RunState RunState => _runState;
        private StateMachine _stateMachine;
        private HashAnimationNamesPlayer _nameHashKey = new HashAnimationNamesPlayer();

        public Vector2 MovementDirection { get; private set; }
        public bool isJumpPressed ;

        public Rigidbody2D Rb { get; private set; }

        public bool IsJumpPressed { get; private set; }
        public bool IsFacingRight { get; private set; }


        [SerializeField] private Transform _attackPointTrans;
        public Transform AttackPointTrans => _attackPointTrans;


        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private LayerMask _layerGround;
        [SerializeField] private float _checkRadiusGround;
        public bool IsGrounded { get; private set; }
        public float LastOnGroundTime { get; private set; }
        [SerializeField] private LayerMask _enemyLayer;
        public LayerMask EnemyLayer => _enemyLayer;

        private int _maxHealth = 100;
        public int MaxHealth => _maxHealth;
        public int _currentHelth = 100;
        public int CurrentHealth => _currentHelth;


        private void Awake()
        {
            _currentHelth = _maxHealth;
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {

            IsFacingRight = true;

            _stateMachine = new StateMachine();
            _jumpState = new JumpState(this, _animator, _nameHashKey, _stateMachine);
            _runState = new RunState(this, _animator, _nameHashKey, _stateMachine);
            
            _animator = GetComponent<Animator>();

            _stateMachine.AddState(new IdleState(this, _animator, _nameHashKey,_stateMachine));
            _stateMachine.AddState(new RunState(this, _animator, _nameHashKey, _stateMachine));
            _stateMachine.AddState(new JumpState(this, _animator, _nameHashKey, _stateMachine));
            _stateMachine.AddState(new FallState(this, _animator, _nameHashKey, _stateMachine));
            _stateMachine.AddState(new AttackBasickState(this, _animator,_nameHashKey,_stateMachine));

            _stateMachine.ChangeState<IdleState>();

            _inputReader.MovementEvent += HandleMovement;
            _inputReader.JumpEvent += HandleJump;
            _inputReader.AttackEvent += HandleAttack;
        }

        public void HandleAttack()
        {
            _stateMachine.ChangeState<AttackBasickState>();
        }

        public void HandleJump()
        {
           // _jumpState.Jump();
          // _stateMachine.ChangeState<JumpState>();
           isJumpPressed = true;
        }

        public void HandleMovement(Vector2 vector)
        {
            MovementDirection = vector;
        }

        private void Update()
        {

            CheckGrounded();
            LastOnGroundTime -= Time.deltaTime;
            if(MovementDirection.x != 0 ) 
            {
                CheckDirectionToFace(MovementDirection.x > 0);
            }

            _stateMachine.Update();
        }

        private void FixedUpdate() 
        {

            _stateMachine.FixedUpdate();
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
                Turn();
        }
        public bool CheckGrounded()
        {
            if (Physics2D.OverlapCircle(_groundCheckPoint.position, _checkRadiusGround, _layerGround))
            {
                LastOnGroundTime = 0.1f;
                IsGrounded = true;
            }
            else
                IsGrounded = false;

            return IsGrounded;
        }


        private void OnDrawGizmosSelected()
        {
            if (_attackPointTrans.position == null) return;
            Gizmos.DrawWireSphere(_attackPointTrans.position, 0.5f);
        }

        public void TakeDamage(int damageAmount)
        {
            _currentHelth -= damageAmount;
            Debug.Log(_currentHelth);

            if(_currentHelth <= 0)
            {
                Die();
            }

            image.fillAmount = _currentHelth/100f;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Die()
        {
            Debug.Log("Hero died");
            GameObject.Destroy(gameObject);
        }

        public void TurnOnDust()
        {
            if(!IsGrounded || MovementDirection.x == 0)
            {
                _dust.Stop();
                return;
            }
            _dust.Play();
        }

    }
}
