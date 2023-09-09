using Game.Level.StateMachine.States.Factories;
using Game.Level.StateMachine.States;
using Game.Level.Factories.Level;
using Game.Level.StateMachine;
using Game.Common.Interfaces;
using Game.Level.Common;
using Game.Level.Configs;
using VContainer.Unity;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelSystemInstaller : IInstaller
    {
        private readonly LevelBootstrapper _levelBootstrapper;
        private readonly LevelConfig _debugConfig;


        public LevelSystemInstaller(LevelBootstrapper levelBootstrapper, LevelConfig debugConfig)
        {
            _levelBootstrapper = levelBootstrapper;
            _debugConfig = debugConfig;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterLevelConfigProvider(builder);
            RegisterLevelFactory(builder);

            RegisterStateFactories(builder);
            RegisterBootstrapper(builder);
            RegisterStateMachine(builder);
            RegisterStates(builder);
        }

        private void RegisterLevelConfigProvider(IContainerBuilder builder)
        {
            builder
                .Register<LevelConfigProvider>(Lifetime.Singleton)
                .WithParameter(_debugConfig)
                .As<ILevelConfigProvider>();
        }

        private void RegisterLevelFactory(IContainerBuilder builder)
        {
            builder
                .Register<LevelFactory>(Lifetime.Singleton)
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
            builder.Register<DataLoadingState>(Lifetime.Singleton);
            builder.Register<StartLevelState>(Lifetime.Singleton);
            builder.Register<EndLevelState>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<DataLoadingStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, DataLoadingState>(container => 
                container.Resolve<DataLoadingStateFactory>().CreateState, Lifetime.Singleton);

            builder.Register<StartLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, StartLevelState>(container => 
                container.Resolve<StartLevelStateFactory>().CreateState, Lifetime.Singleton);
            
            builder.Register<EndLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<EndLevelState>(container => 
                container.Resolve<EndLevelStateFactory>().CreateState, Lifetime.Singleton);
        }
        
        private void RegisterBootstrapper(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(_levelBootstrapper)
                .As<ICoroutineRunner>()
                .AsSelf();
        }
    }
}