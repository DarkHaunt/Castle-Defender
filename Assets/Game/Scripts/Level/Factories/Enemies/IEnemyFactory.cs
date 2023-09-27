using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Factories.Enemies
{
    public interface IEnemyFactory
    {
        IEnemyBehaviorHandler CreateEnemy(EnemyBehaviorHandler prefab, Vector2 position);
    }
}