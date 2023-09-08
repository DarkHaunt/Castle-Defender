﻿using Game.Level.StateMachine.States.Factories;
using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using Game.Common.Interfaces;
using VContainer.Unity;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelSystemInstaller : IInstaller
    {
        private readonly LevelBootstrapper _levelBootstrapper;

        
        public LevelSystemInstaller(LevelBootstrapper levelBootstrapper)
        {
            _levelBootstrapper = levelBootstrapper;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterStateMachine(builder);
            RegisterStateFactories(builder);
            RegisterCoroutineRunner(builder);
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
            builder.Register<StartLevelState>(Lifetime.Singleton);
            builder.Register<EndLevelState>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<StartLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, StartLevelState>(container => 
                container.Resolve<StartLevelStateFactory>().CreateState, Lifetime.Singleton);        

            builder.Register<EndLevelStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<EndLevelState>(container => 
                container.Resolve<EndLevelStateFactory>().CreateState, Lifetime.Singleton);
        }
        
        private void RegisterCoroutineRunner(IContainerBuilder builder)
        {
            builder
                .RegisterComponent(_levelBootstrapper)
                .As<ICoroutineRunner>();
        }
    }
}