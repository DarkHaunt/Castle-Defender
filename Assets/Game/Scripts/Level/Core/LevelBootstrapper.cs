using Game.Level.StateMachine.StatesFactory;
using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Core
{
    public class LevelBootstrapper : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"<color=white>Configure</color>");

            RegisterStates(builder);
            RegisterStateMachine(builder);
        }

        private static void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
        }

        private static void RegisterStates(IContainerBuilder builder)
        {
            builder
                .Register<StateFactory>(Lifetime.Singleton)
                .WithParameter()
                .AsImplementedInterfaces();

            builder
                .Register<LevelStart>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            builder
                .Register<LevelEnd>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}