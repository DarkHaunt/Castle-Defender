﻿using Project.Scripts.Common.Interfaces;
using Project.Scripts.Extensions;
using Project.Scripts.Level.Handling;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Enemies.Handling
{
    public class EnemyHandleService : IEnemyRegister
    {
        public event Action OnRequairedEnemiesKilled;
        
        private readonly ISet<Enemy> _enemies = new HashSet<Enemy>();
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly EnemyPoolService _poolService;

        private Coroutine _updateBehavior;
        private int _countEnemiesToKill;


        public EnemyHandleService(ICoroutineRunner coroutineRunner, EnemyPoolService poolService)
        {
            _coroutineRunner = coroutineRunner;
            _poolService = poolService;
        }
        
        public void Init(LevelInitializeData initializeData)
        {
            _countEnemiesToKill = initializeData.CountEnemiesToKill;
            _poolService.Init(initializeData.Enemies);
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

            ProcessEnemyKilled();
        }

        private void ProcessEnemyKilled()
        {
            if(--_countEnemiesToKill <= 0)
                OnRequairedEnemiesKilled?.Invoke();
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