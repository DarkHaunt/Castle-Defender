﻿using Project.Scripts.Level.StateMachine.States.LoadingLevelData;
using Project.Scripts.Level.StateMachine.States.StartLevel;
using Project.Scripts.Level.StateMachine.States.InitLevel;
using Project.Scripts.Level.StateMachine.States.EndLevel;
using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.Level.Common.Physics;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Common.Prefab;
using Project.Scripts.Level.StateMachine;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.Init;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Boot.Installers
{
    public class LevelSystemInstaller : IInstaller
    {
        private readonly DebugService _debugService;
        private readonly Transform _levelParentObject;


        public LevelSystemInstaller(DebugService debugService, Transform levelParentObject)
        {
            _levelParentObject = levelParentObject;
            _debugService = debugService;
        }


        public void Install(IContainerBuilder builder)
        {
            RegisterCrystalHandleService(builder);
            RegisterStateMachine(builder);
            
            RegisterInitializeService(builder);
            RegisterLevelProvider(builder);

            RegisterLevelBootstrapper(builder);
            RegisterStateFactories(builder);
            RegisterStates(builder);

            RegisterLevelCollisionService(builder);
        }

        private void RegisterCrystalHandleService(IContainerBuilder builder)
        {
            builder.Register<CrystalHandleService>(Lifetime.Scoped);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<LevelStateMachine>()
                .AsSelf();
        }

        private void RegisterLevelCollisionService(IContainerBuilder builder)
        {
            builder.Register<LevelCollisionsService>(Lifetime.Scoped);
        }

        private void RegisterLevelBootstrapper(IContainerBuilder builder)
        {
            builder.RegisterComponent(_debugService);
        }

        private void RegisterInitializeService(IContainerBuilder builder)
        {
            builder.Register<InitializeService>(Lifetime.Scoped);
        }

        private void RegisterLevelProvider(IContainerBuilder builder)
        {
            builder
                .Register<LevelProvider>(Lifetime.Scoped)
                .WithParameter(_levelParentObject);
        }

        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<LoadingLevelDataState>(Lifetime.Scoped);
            builder.Register<StartLevelState>(Lifetime.Scoped);
            builder.Register<InitLevelState>(Lifetime.Scoped);
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