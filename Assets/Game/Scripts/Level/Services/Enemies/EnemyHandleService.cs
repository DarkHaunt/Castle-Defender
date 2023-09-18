using System.Collections.Generic;
using Game.Level.Enemies;
using UnityEngine;
using VContainer.Unity;


namespace Game.Level.Services.Enemies
{
    public class EnemyHandleService : IFixedTickable
    {
        private readonly ISet<IEnemy> _enemies = new HashSet<IEnemy>();
        private IAttackTarget _enemyTarget;


        public void Init(IAttackTarget enemyTarget)
            => _enemyTarget = enemyTarget;

        public void RegisterEnemy(IEnemy enemy)
            => _enemies.Add(enemy);

        public void UnregisterEnemy(IEnemy enemy)
            => _enemies.Remove(enemy);

        public void FixedTick()
        {
            foreach (var enemy in _enemies)
                enemy.PerformBehavior(Time.fixedDeltaTime);
        }
    }
}