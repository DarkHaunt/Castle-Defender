using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using Game.Level.StateMachine.States.Factories;
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
            RegisterStateFactories(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<LevelStartState>(Lifetime.Singleton);
            builder.Register<LevelEndState>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<LevelStartStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, LevelStartState>(container => 
                container.Resolve<LevelStartStateFactory>().CreateState, Lifetime.Singleton);        

            builder.Register<LevelEndStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<LevelEndState>(container => 
                container.Resolve<LevelEndStateFactory>().CreateState, Lifetime.Singleton);
        }
    }
}