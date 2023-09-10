using Game.Level.Factories.Enemies;
using System.Collections.Generic;
using Game.Common.Interfaces;
using System.Collections;
using Game.Level.Enemies;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Services.Enemies
{
    public class EnemySpawnService
    {
        private readonly EnemyHandleService _enemyHandleService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IEnemyFactory _enemyFactory;

        private IEnumerable<Transform> _spawnPoints;
        private IEnumerable<Enemy> _enemiesPrefabs;
        
        private Coroutine _spawning;
        private float _waveSpawnTime;


        public EnemySpawnService(IEnemyFactory enemyFactory, EnemyHandleService enemyHandleService, ICoroutineRunner coroutineRunner)
        {
            _enemyHandleService = enemyHandleService;
            _coroutineRunner = coroutineRunner;
            _enemyFactory = enemyFactory;
        }


        public void Init(float waveSpawnTime, IEnumerable<Transform> spawnPoints, IEnumerable<Enemy> enemiesPrefabs)
        {
            _enemiesPrefabs = enemiesPrefabs;
            _waveSpawnTime = waveSpawnTime;
            _spawnPoints = spawnPoints;
        }

        public void Enable()
        {
            _spawning = _coroutineRunner.StartCoroutine(InfinityWaveSpawn());
        }

        public void Disable()
        {
            _coroutineRunner.StopCoroutine(_spawning);
        }

        private IEnumerator InfinityWaveSpawn()
        {
            while (true)
            {
                yield return MonoExtensions.GetWait(_waveSpawnTime);
                
                SpawnEnemiesInPoints();
            }
        }

        private void SpawnEnemiesInPoints()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                var enemyPrefab = _enemiesPrefabs.PickRandom();
                var enemy = _enemyFactory.CreateEnemy(enemyPrefab, spawnPoint.position);
                
                _enemyHandleService.RegisterEnemy(enemy);
            }
        }
    }
}