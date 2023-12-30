using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Init;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Boot.Installers
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
            RegisterEnemyProvider(builder);
            
            RegisterEnemyPoolService(builder);
            RegisterEnemySpawnService(builder);
            RegisterEnemyHandleService(builder);
        }

        private void RegisterEnemyProvider(IContainerBuilder builder)
        {
            builder.Register<EnemyProvider>(Lifetime.Scoped);
        }

        private void RegisterEnemyPoolService(IContainerBuilder builder)
        {
            builder
                .Register<EnemyPoolService>(Lifetime.Scoped)
                .WithParameter(_enemyParent);
        }

        private void RegisterEnemyFactory(IContainerBuilder builder)
        {
            builder.Register<EnemyFactory>(Lifetime.Scoped);
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