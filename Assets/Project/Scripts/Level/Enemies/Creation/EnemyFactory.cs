using Project.Scripts.Extensions;
using Project.Scripts.Level.Enemies.Handling;
using UnityEngine;


namespace Project.Scripts.Level.Enemies.Creation
{
    public class EnemyFactory
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