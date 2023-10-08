using System.Collections.Generic;
using Game.Level.Enemies;
using UnityEngine;
using Game.Extra;
using System;


namespace Game.Level.Services.Enemies
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
        
    
        public void InitPools(IEnumerable<Enemy> prefabs)
        {
            foreach (var enemyPrefab in prefabs)
            {
                AssertPoolHaveAnId(enemyPrefab.Id);

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
            if (_enemyPools.ContainsKey(id))
                throw new ArgumentException();
        }
    }
}