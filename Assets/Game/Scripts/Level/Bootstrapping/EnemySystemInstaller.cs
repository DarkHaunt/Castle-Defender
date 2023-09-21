﻿using Game.Level.Factories.Enemies;
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
            RegisterEnemyHandleService(builder);
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

        private void RegisterEnemyHandleService(IContainerBuilder builder)
        {
            builder
                .Register<EnemyHandleService>(Lifetime.Singleton)
                .As<IEnemyRegister>()
                .AsSelf();
        }

        private void RegisterEnemySpawnService(IContainerBuilder builder)
        {
            builder.Register<EnemySpawnService>(Lifetime.Singleton);
        }
    }
}