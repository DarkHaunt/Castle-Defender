using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Factories.Enemies
{
    public interface IEnemyFactory
    {
        void Init(IAttackTarget enemyTarget);
        IEnemy CreateEnemy(Enemy prefab, Vector2 position);
    }
}