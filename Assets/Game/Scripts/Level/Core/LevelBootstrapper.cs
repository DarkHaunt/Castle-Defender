using Game.Level.StateMachine.StatesFactory;
using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using VContainer.Unity;
using VContainer;


namespace Game.Level.Core
{
    public class LevelBootstrapper : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStates(builder);
            RegisterStateMachine(builder);
            RegisterStateFactory(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder
                .Register<LevelStart>(Lifetime.Singleton)
                .AsSelf();

            builder
                .Register<LevelEnd>(Lifetime.Singleton)
                .AsSelf();
        }

        private void RegisterStateFactory(IContainerBuilder builder)
        {
            builder
                .Register<StateFactory>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}