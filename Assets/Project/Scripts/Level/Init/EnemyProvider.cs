using Project.Scripts.Configs.Level;
using Project.Scripts.Level.Enemies;
using UnityEngine;

namespace Project.Scripts.Level.Init
{
    public class EnemyProvider
    {
        public Enemy[] LoadEnemies(ILevelConfig levelConfig)
        {
            var enemies = new Enemy[levelConfig.EnemiesPrefabsPatches.Length];

            for (int i = 0; i < enemies.Length; i++)
            {
                var path = levelConfig.EnemiesPrefabsPatches[i];
                enemies[i] = Resources.Load<Enemy>(path);
            }

            return enemies;
        }
    }
}