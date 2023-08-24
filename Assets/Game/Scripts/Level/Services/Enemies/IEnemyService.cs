using Game.Level.Enemies;


namespace Game.Level.Services.Enemies
{
    public interface IEnemyService
    {
        void RegisterEnemy(IEnemy enemy);
        void UnregisterEnemy(IEnemy enemy);
    }
}