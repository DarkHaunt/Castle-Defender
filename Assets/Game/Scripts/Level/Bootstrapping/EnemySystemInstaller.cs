using Game.Level.Services.Enemies;
using VContainer.Unity;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class EnemySystemInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            RegisterEnemyService(builder);
            RegisterEnemySpawnService(builder);
        }

        private static void RegisterEnemyService(IContainerBuilder builder)
        {
            builder.Register<EnemyHandleService>(Lifetime.Singleton);
        }

        private static void RegisterEnemySpawnService(IContainerBuilder builder)
        {
            builder.Register<EnemySpawnService>(Lifetime.Singleton);
        }
    }
}