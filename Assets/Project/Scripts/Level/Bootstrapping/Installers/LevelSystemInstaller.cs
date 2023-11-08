using Game.Level.StateMachine;
using Game.Shared;
using Project.Scripts.Level.Common;
using Project.Scripts.Level.Common.Physics;
using Project.Scripts.Level.Creation;
using Project.Scripts.Level.Handling;
using Project.Scripts.Level.StateMachine;
using Project.Scripts.Level.StateMachine.States.EndLevel;
using Project.Scripts.Level.StateMachine.States.InitLevel;
using Project.Scripts.Level.StateMachine.States.LoadingLevelData;
using Project.Scripts.Level.StateMachine.States.StartLevel;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Project.Scripts.Level.Bootstrapping.Installers
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
            RegisterStateMachine(builder);
            
            RegisterPlayerProgressDataProvider(builder);
            RegisterInitializeDataProvider(builder);
            RegisterLevelConfigProvider(builder);
            RegisterLevelFactory(builder);

            RegisterLevelBootstrapper(builder);
            RegisterStateFactories(builder);
            RegisterStates(builder);

            RegisterLevelCollisionService(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<LevelStateMachine>()
                .As<IStateSwitcher>()
                .AsSelf();
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
            builder.Register<InitializeDataProvider>(Lifetime.Scoped);
        }

        private void RegisterLevelConfigProvider(IContainerBuilder builder)
        {
            builder.Register<LevelConfigProvider>(Lifetime.Scoped);
        }

        private void RegisterLevelFactory(IContainerBuilder builder)
        {
            builder
                .Register<LevelFactory>(Lifetime.Scoped)
                .WithParameter(_levelParentObject);

            builder.RegisterFactory<string, LevelComponentsContainer>(container =>
                container.Resolve<LevelFactory>().CreateLevel, Lifetime.Scoped);
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