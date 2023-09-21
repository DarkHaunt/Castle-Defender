using Game.Level.Factories.Enemies;
using Game.Level.Services.Enemies;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class EnemySystemInstaller : IInstaller
    {
        private readonly Transform _enemyParent;

        
        public EnemySystemInstaller(Transform enemyParent)
        {
            _enemyParent = enemyParent;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterEnemyService(builder);
            RegisterEnemyFactory(builder);
            RegisterEnemySpawnService(builder);
        }

        private void RegisterEnemyFactory(IContainerBuilder builder)
        {
            builder
                .Register<EnemyFactory>(Lifetime.Singleton)
                .WithParameter(_enemyParent)
                .As<IEnemyFactory>();
        }

        private static void RegisterEnemyService(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<EnemyHandleService>()
                .AsSelf();
        }

        private static void RegisterEnemySpawnService(IContainerBuilder builder)
        {
            builder.Register<EnemySpawnService>(Lifetime.Singleton);
        }
    }
}