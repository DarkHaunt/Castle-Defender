using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Factories.Enemies
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(Enemy prefab, Vector2 position);
    }
}