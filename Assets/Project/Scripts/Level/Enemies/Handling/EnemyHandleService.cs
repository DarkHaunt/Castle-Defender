using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.Common.Coroutines;
using Project.Scripts.Level.Common;
using Project.Scripts.Extensions;
using System.Collections.Generic;
using Project.Scripts.Consume;
using System.Collections;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Enemies.Handling
{
    public class EnemyHandleService : IEnemyRegister
    {
        public event Action OnRequiredEnemiesKilled;
        
        private readonly ISet<Enemy> _enemies = new HashSet<Enemy>();
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EnemyPoolService _poolService;
        
        private readonly CrystalHandleService _crystalHandleService;
        private readonly CoinsHandleService _coinsHandleService;

        private Coroutine _updateBehavior;
        private int _countEnemiesToKill;


        public EnemyHandleService(ICoroutineRunner coroutineRunner, EnemyPoolService poolService, 
            CoinsHandleService coinsHandleService, CrystalHandleService crystalHandleService)
        {
            _crystalHandleService = crystalHandleService;
            _coinsHandleService = coinsHandleService;
            
            _coroutineRunner = coroutineRunner;
            _poolService = poolService;
        }
        
        
        public void Init(IEnumerable<Enemy> enemies, int countEnemiesToKill)
        {
            _countEnemiesToKill = countEnemiesToKill;
            _poolService.Init(enemies);
        }
        
        public void Enable()
            => _updateBehavior = _coroutineRunner.StartCoroutine(UpdateBehaviorOfEnemies());

        public void Disable()
        {
            _coroutineRunner.StopCoroutine(_updateBehavior);

            foreach (var enemy in _enemies)
                enemy.EndBehavior();
        }

        public void RegisterEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            
            enemy.OnDeactivate += UnregisterEnemy;
            enemy.OnDeactivate += _poolService.PushEnemyInPool;
        }

        private void UnregisterEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);

            enemy.OnDeactivate -= UnregisterEnemy;
            enemy.OnDeactivate -= _poolService.PushEnemyInPool;

            ProcessEnemyKilled(enemy);
        }

        private void ProcessEnemyKilled(Enemy enemy)
        {
            if(--_countEnemiesToKill <= 0)
                OnRequiredEnemiesKilled?.Invoke();
            
            _crystalHandleService.AddCrystals(enemy.CrystalReward);
            _coinsHandleService.AddCoins(LevelStaticData.RewardCoinsForKillEnemy);
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