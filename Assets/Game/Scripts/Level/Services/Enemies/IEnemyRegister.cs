using Game.Level.Enemies;


namespace Game.Level.Services.Enemies
{
    public interface IEnemyRegister
    {
        void RegisterEnemy(IEnemy enemy);
    }
}