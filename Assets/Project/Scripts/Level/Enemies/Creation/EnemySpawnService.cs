using Project.Scripts.Common.Coroutines;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Common.Prefab;
using Project.Scripts.Extensions;
using Project.Scripts.Level.Init;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace Project.Scripts.Level.Enemies.Creation
{
    public class EnemySpawnService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IEnemyRegister _enemyRegister;
        private readonly EnemyFactory _enemyFactory;

        private IEnumerable<Transform> _spawnPoints;
        private IEnumerable<Enemy> _enemiesPrefabs;
        
        private Coroutine _spawning;
        private float _waveSpawnTime;


        public EnemySpawnService(ICoroutineRunner coroutineRunner, EnemyFactory enemyFactory, IEnemyRegister enemyRegister)
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
                SpawnEnemiesInPoints();
                
                yield return MonoExtensions.GetWait(_waveSpawnTime);
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