using System.Collections.Generic;
using Game.Common.Interfaces;
using Game.Level.Enemies;
using System.Collections;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Services.Enemies
{
    public class EnemyHandleService : IEnemyRegister
    {
        private readonly ISet<IEnemyBehaviorHandler> _enemies = new HashSet<IEnemyBehaviorHandler>();
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EnemyPoolService _poolService;

        private Coroutine _updateBehavior;


        public EnemyHandleService(ICoroutineRunner coroutineRunner, EnemyPoolService poolService)
        {
            _coroutineRunner = coroutineRunner;
            _poolService = poolService;
        }
        
        
        public void Enable()
            => _updateBehavior = _coroutineRunner.StartCoroutine(UpdateBehaviorOfEnemies());

        public void Disable()
        {
            _coroutineRunner.StopCoroutine(_updateBehavior);

            foreach (var enemy in _enemies)
                enemy.EndBehavior();
        }

        public void RegisterEnemy(IEnemyBehaviorHandler enemy)
        {
            _enemies.Add(enemy);
            
            enemy.OnBehaviorHandlingEnded += UnregisterEnemy;
        }

        private void UnregisterEnemy(IEnemyBehaviorHandler enemy)
        {
            _enemies.Remove(enemy);

            enemy.OnBehaviorHandlingEnded -= UnregisterEnemy;
        }

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