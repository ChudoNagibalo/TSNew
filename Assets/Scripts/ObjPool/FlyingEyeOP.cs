using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace FPGame.ObjPool
{
    public class FlyingEyeOP : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 6;
        [SerializeField] private bool _autoExpand = true;
        [SerializeField] private ProjectileOfFlyingEye _projectilePrefab; 
        [SerializeField] private GameObject _launchOffset;

        private ObjPool<ProjectileOfFlyingEye> _objectPool;

        private void Awake() 
        {
            _objectPool = new ObjPool<ProjectileOfFlyingEye>(_projectilePrefab, _poolCount, _launchOffset.transform);
            _objectPool.AutoExpand = _autoExpand;
        }
        public void CreateProjectile()
        {
            var position = new Vector2(_launchOffset.transform.position.x , _launchOffset.transform.position.y);
            var projectile = _objectPool.GetFreeElement();
            projectile.transform.position = position;
        }
    }
}