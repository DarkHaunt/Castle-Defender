using Project.Scripts.Common.World;
using Project.Scripts.Level.Projectiles;
using Project.Scripts.Level.Enemies;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Weapons
{
    public class SimpleWeapon : Weapon
    {
        [SerializeField] private Projectile _projectilePrefab;

        private PoolMono<Projectile> _projectiles;
        
        
        public override void Attack(IEnemy target, Action onComplete)
        {
            var startPosition = transform.position;
            var direction = (target.Position - startPosition).normalized;

            var projectile = _projectiles.GetFreeElement();
            projectile.Fly(_damage, startPosition, direction);

            onComplete?.Invoke();
        }

        protected override void InitInternal()
            => _projectiles = new PoolMono<Projectile>(_projectilePrefab, 1, true);

        public override void Reload() {}
    }
}