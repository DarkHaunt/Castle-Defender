using Game.Level.Factories.Enemies;
using System.Collections.Generic;
using Game.Common.Interfaces;
using System.Collections;
using Game.Level.Enemies;
using Game.Level.Configs;
using Game.Level.Common;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Services.Enemies
{
    public class EnemySpawnService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IEnemyRegister _enemyRegister;
        private readonly IEnemyFactory _enemyFactory;

        private IEnumerable<Transform> _spawnPoints;
        private IEnumerable<Enemy> _enemiesPrefabs;
        
        private Coroutine _spawning;
        private float _waveSpawnTime;


        public EnemySpawnService(ICoroutineRunner coroutineRunner, IEnemyFactory enemyFactory, IEnemyRegister enemyRegister)
        {
            _coroutineRunner = coroutineRunner;
            _enemyRegister = enemyRegister;
            _enemyFactory = enemyFactory;
        }

        
        public void Init(LevelInitializeData levelInitializeData, LevelComponentsContainer level)
        {
            _waveSpawnTime = levelInitializeData.EnemiesWaveSpawnTime;
            _enemiesPrefabs = levelInitializeData.Enemies;
            _spawnPoints = level.EnemiesSpawnPoints;
        }

        public void Enable()
            => _spawning = _coroutineRunner.StartCoroutine(InfinityWaveSpawn());

        public void Disable()
            => _coroutineRunner.StopCoroutine(_spawning);

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
                
                _enemyRegister.RegisterEnemy(enemy);
            }
        }
    }
}