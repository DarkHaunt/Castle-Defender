using Game.Level.StateMachine.States.Factories;
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
            RegisterStateFactories(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
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
    }
}