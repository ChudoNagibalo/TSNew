using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileOfFlyingEye : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _projectileLifeTime = 6f;
    [SerializeField] private float _projectileSpeed = 0.1f;
    [SerializeField] private bool _invertX ;
    private int _direction;

    private int KEYProjectileCollision = Animator.StringToHash("IsHitting");


    private void Start() 
    {
        var mod = _invertX ? 1 : -1;
        _direction = mod * transform.localScale.x > 0 ? 1 : -1;
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        var position = _rb.position;
        position.x += _direction * _projectileSpeed;
        _rb.MovePosition(position);
    }

    private void LifeTimeCheck()
    {
        _projectileLifeTime -= Time.deltaTime;
        if(_projectileLifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player") || other.collider.CompareTag("Obstacle"))
        {
            _animator.SetTrigger(KEYProjectileCollision);
        }
        else 
        {
            return;
        }
    }

    public void ProjectileSetFalse()
    {
        gameObject.SetActive(false);
    }


}
