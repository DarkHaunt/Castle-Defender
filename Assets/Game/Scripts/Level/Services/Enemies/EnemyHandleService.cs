using System.Collections.Generic;
using Game.Common.Interfaces;
using Game.Level.Enemies;
using System.Collections;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Services.Enemies
{
    public class EnemyHandleService
    {
        private readonly ISet<IEnemy> _enemies = new HashSet<IEnemy>();
        private readonly ICoroutineRunner _coroutineRunner;
        private IAttackTarget _enemyTarget;
        private Coroutine _updateBehavior;


        public EnemyHandleService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        
        public void Init(IAttackTarget enemyTarget)
            => _enemyTarget = enemyTarget;

        public void Enable()
            => _updateBehavior = _coroutineRunner.StartCoroutine(UpdateBehaviorOfEnemies());

        public void Disable()
        {
            _coroutineRunner.StopCoroutine(_updateBehavior);

            foreach (var enemy in _enemies)
                enemy.EndBehavior();
        }

        public void RegisterEnemy(IEnemy enemy)
            => _enemies.Add(enemy);

        public void UnregisterEnemy(IEnemy enemy)
            => _enemies.Remove(enemy);

        private IEnumerator UpdateBehaviorOfEnemies()
        {
            while (true)
            {
                yield return MonoExtensions.GetWaitForFixedUpdate();

                foreach (var enemy in _enemies)
                    enemy.PerformBehavior(Time.fixedDeltaTime);
            }
        }
    }
}