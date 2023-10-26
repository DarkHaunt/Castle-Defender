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
            RegisterEnemyFactory(builder);
            RegisterEnemyPoolService(builder);
            RegisterEnemySpawnService(builder);
            RegisterEnemyHandleService(builder);
        }

        private void RegisterEnemyPoolService(IContainerBuilder builder)
        {
            builder
                .Register<EnemyPoolService>(Lifetime.Scoped)
                .WithParameter(_enemyParent);
        }

        private void RegisterEnemyFactory(IContainerBuilder builder)
        {
            builder
                .Register<EnemyFactory>(Lifetime.Scoped)
                .As<IEnemyFactory>();
        }

        private void RegisterEnemyHandleService(IContainerBuilder builder)
        {
            builder
                .Register<EnemyHandleService>(Lifetime.Scoped)
                .As<IEnemyRegister>()
                .AsSelf();
        }

        private void RegisterEnemySpawnService(IContainerBuilder builder)
        {
            builder.Register<EnemySpawnService>(Lifetime.Scoped);
        }
    }
}