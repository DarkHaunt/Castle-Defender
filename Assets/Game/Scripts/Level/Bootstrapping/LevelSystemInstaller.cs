using Game.Level.StateMachine.States.Factories;
using Game.Level.StateMachine.States;
using Game.Level.Factories.Level;
using Game.Level.StateMachine;
using Game.Level.Configs;
using Game.Level.Common;
using VContainer.Unity;
using Game.Shared;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelSystemInstaller : IInstaller
    {
        private readonly LevelBootstrapper _levelBootstrapper;
        private readonly Transform _levelParentObject;


        public LevelSystemInstaller(LevelBootstrapper levelBootstrapper, Transform levelParentObject)
        {
            _levelBootstrapper = levelBootstrapper;
            _levelParentObject = levelParentObject;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterPlayerProgressDataProvider(builder);
            RegisterInitializeDataProvider(builder);
            RegisterLevelConfigProvider(builder);
            RegisterLevelFactory(builder);

            RegisterLevelBootstrapper(builder);
            RegisterStateFactories(builder);
            RegisterStateMachine(builder);
            RegisterStates(builder);
        }

        private void RegisterLevelBootstrapper(IContainerBuilder builder)
        {
            builder.RegisterComponent(_levelBootstrapper);
        }

        private void RegisterPlayerProgressDataProvider(IContainerBuilder builder)
        {
            builder
                .Register<PlayerProgressDataProvider>(Lifetime.Singleton)
                .As<IPlayerProgressDataProvider>();
        }

        private void RegisterInitializeDataProvider(IContainerBuilder builder)
        {
            builder
                .Register<InitializeDataProvider>(Lifetime.Singleton)
                .As<IInitializeDataProvider>();
        }

        private void RegisterLevelConfigProvider(IContainerBuilder builder)
        {
            builder
                .Register<LevelConfigProvider>(Lifetime.Singleton)
                .As<ILevelConfigProvider>();
        }

        private void RegisterLevelFactory(IContainerBuilder builder)
        {
            builder
                .Register<LevelFactory>(Lifetime.Singleton)
                .WithParameter(_levelParentObject)
                .As<ILevelFactory>();

            builder.RegisterFactory<string, LevelComponentsContainer>(container =>
                container.Resolve<LevelFactory>().CreateLevel, Lifetime.Singleton);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<LevelStateMachine>()
                .As<IStateSwitcher>()
                .AsSelf();
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<LoadingLevelDataState>(Lifetime.Singleton);
            builder.Register<InitLevelState>(Lifetime.Singleton);
            builder.Register<StartLevelState>(Lifetime.Singleton);
            builder.Register<EndLevelState>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<LoadingLevelDataStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, LoadingLevelDataState>(container => 
                container.Resolve<LoadingLevelDataStateFactory>().CreateState, Lifetime.Singleton);  
            
            builder.Register<InitLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, InitLevelState>(container => 
                container.Resolve<InitLevelStateFactory>().CreateState, Lifetime.Singleton);

            builder.Register<StartLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, StartLevelState>(container => 
                container.Resolve<StartLevelStateFactory>().CreateState, Lifetime.Singleton);
            
            builder.Register<EndLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<EndLevelState>(container => 
                container.Resolve<EndLevelStateFactory>().CreateState, Lifetime.Singleton);
        }
    }
}