using Game.Level.Enemies;
using UnityEngine;


namespace Game.Level.Factories.Enemies
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(Enemy prefab, Vector2 position);
    }
}