using Game.Level.Factories.Enemies;
using System.Collections.Generic;
using Game.Common.Interfaces;
using System.Collections;
using Game.Level.Enemies;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Services.Enemies
{
    public class EnemiesSpawnService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IEnemyService _enemyService;

        private IEnumerable<Transform> _spawnPoints;
        private IEnumerable<Enemy> _enemiesPrefabs;
        
        private Coroutine _spawning;
        private float _waveSpawnTime;


        public EnemiesSpawnService(IEnemyFactory enemyFactory, IEnemyService enemyService, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _enemyFactory = enemyFactory;
            _enemyService = enemyService;
        }


        public void Init(float waveSpawnTime, IEnumerable<Transform> spawnPoints, IEnumerable<Enemy> enemiesPrefabs)
        {
            _spawnPoints = spawnPoints;
            _enemiesPrefabs = enemiesPrefabs;
            _waveSpawnTime = waveSpawnTime;
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
                
                _enemyService.RegisterEnemy(enemy);
            }
        }
    }
}