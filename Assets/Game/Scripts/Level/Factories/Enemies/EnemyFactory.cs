using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Factories.Enemies
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Transform _parentObject;

        
        public EnemyFactory(Transform parentObject)
        {
            _parentObject = parentObject;
        }

        
        public IEnemy CreateEnemy(Enemy prefab, Vector2 position)
        {
            var enemy = Object.Instantiate(prefab, position, Quaternion.identity, _parentObject);
            enemy.Init();
            
            return enemy;
        }
    }
}