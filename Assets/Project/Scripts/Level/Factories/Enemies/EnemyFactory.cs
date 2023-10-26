using Game.Level.Services.Enemies;
using Game.Level.Enemies;
using Game.Extensions;
using UnityEngine;


namespace Game.Level.Factories.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyPoolService _enemyPoolService;


        public EnemyFactory(EnemyPoolService enemyPoolService)
        {
            _enemyPoolService = enemyPoolService;
        }

        
        public Enemy CreateEnemy(Enemy prefab, Vector2 position)
        {
            var enemy = _enemyPoolService.PopEnemyFromPool(prefab.Id);
            
            enemy.Init();
            enemy.transform.SetInPosition(position);
            
            return enemy;
        } 
    }
}