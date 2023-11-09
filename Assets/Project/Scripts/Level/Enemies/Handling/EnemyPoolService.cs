using Project.Scripts.Extra;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Enemies.Handling
{
    public class EnemyPoolService
    {
        private const int InitPoolSize = 3;
        
        private readonly Dictionary<int, PoolMono<Enemy>> _enemyPools = new ();
        private readonly Transform _parentObject;


        public EnemyPoolService(Transform parentObject)
        {
            _parentObject = parentObject;
        }
        
    
        public void Init(IEnumerable<Enemy> prefabs)
        {
            foreach (var enemyPrefab in prefabs)
            {
                var pool = new PoolMono<Enemy>(enemyPrefab, InitPoolSize, _parentObject, true);
                
                _enemyPools.Add(enemyPrefab.Id, pool);
            }
        }

        public Enemy PopEnemyFromPool(int id)
        {
            AssertPoolHaveAnId(id);

            return _enemyPools[id].GetFreeElement();
        }

        public void PushEnemyInPool(Enemy enemy)
            => enemy.gameObject.SetActive(false);

        private void AssertPoolHaveAnId(int id)
        {
            if (!_enemyPools.ContainsKey(id))
                throw new ArgumentException($"Pool Service doesn't have a key of enemy id: {id}");
        }
    }
}