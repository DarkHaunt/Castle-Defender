using Game.Level.StateMachine.States;
using Game.Level.Factories.States;
using Game.Level.Factories.Level;
using Game.Level.Services.Level;
using Game.Level.Common.Physics;
using Game.Level.StateMachine;
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

            RegisterLevelCollisionService(builder);
        }
        
        private void RegisterLevelCollisionService(IContainerBuilder builder)
        {
            builder.Register<LevelCollisionsService>(Lifetime.Scoped);
        }

        private void RegisterLevelBootstrapper(IContainerBuilder builder)
        {
            builder.RegisterComponent(_levelBootstrapper);
        }

        private void RegisterPlayerProgressDataProvider(IContainerBuilder builder)
        {
            builder
                .Register<PlayerProgressDataProvider>(Lifetime.Scoped)
                .As<IPlayerProgressDataProvider>();
        }

        private void RegisterInitializeDataProvider(IContainerBuilder builder)
        {
            builder
                .Register<InitializeDataProvider>(Lifetime.Scoped)
                .As<IInitializeDataProvider>();
        }

        private void RegisterLevelConfigProvider(IContainerBuilder builder)
        {
            builder
                .Register<LevelConfigProvider>(Lifetime.Scoped)
                .As<ILevelConfigProvider>();
        }

        private void RegisterLevelFactory(IContainerBuilder builder)
        {
            builder
                .Register<LevelFactory>(Lifetime.Scoped)
                .WithParameter(_levelParentObject)
                .As<ILevelFactory>();

            builder.RegisterFactory<string, LevelComponentsContainer>(container =>
                container.Resolve<LevelFactory>().CreateLevel, Lifetime.Scoped);
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
            builder.Register<LoadingLevelDataState>(Lifetime.Scoped);
            builder.Register<InitLevelState>(Lifetime.Scoped);
            builder.Register<StartLevelState>(Lifetime.Scoped);
            builder.Register<EndLevelState>(Lifetime.Scoped);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<LoadingLevelDataStateFactory>(Lifetime.Scoped);
            builder.RegisterFactory<IStateSwitcher, LoadingLevelDataState>(container => 
                container.Resolve<LoadingLevelDataStateFactory>().CreateState, Lifetime.Scoped);  
            
            builder.Register<InitLevelStateFactory>(Lifetime.Scoped);
            builder.RegisterFactory<IStateSwitcher, InitLevelState>(container => 
                container.Resolve<InitLevelStateFactory>().CreateState, Lifetime.Scoped);

            builder.Register<StartLevelStateFactory>(Lifetime.Scoped);
            builder.RegisterFactory<IStateSwitcher, StartLevelState>(container => 
                container.Resolve<StartLevelStateFactory>().CreateState, Lifetime.Scoped);
            
            builder.Register<EndLevelStateFactory>(Lifetime.Scoped);
            builder.RegisterFactory<EndLevelState>(container => 
                container.Resolve<EndLevelStateFactory>().CreateState, Lifetime.Scoped);
        }
    }
}