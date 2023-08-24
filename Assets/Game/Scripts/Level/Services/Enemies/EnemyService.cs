using Game.Level.Enemies;
using System.Collections.Generic;


namespace Game.Level.Services.Enemies
{
    public class EnemyService : IEnemyService
    {
        private readonly ISet<IEnemy> _enemies = new HashSet<IEnemy>();


        public void RegisterEnemy(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void UnregisterEnemy(IEnemy enemy)
        {
            _enemies.Remove(enemy);
        }
    }
}