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
            RegisterStateFactories(builder);
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelStateMachine>();
        }
        
        private void RegisterStates(IContainerBuilder builder)
        {
            builder.Register<LevelStart>(Lifetime.Singleton);
            builder.Register<LevelEnd>(Lifetime.Singleton);
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<LevelStartStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<IStateSwitcher, LevelStart>(container => 
                container.Resolve<LevelStartStateFactory>().CreateState, Lifetime.Singleton);        

            builder.Register<LevelEndStateFactory>(Lifetime.Singleton);
            builder.RegisterFactory<LevelEnd>(container => 
                container.Resolve<LevelEndStateFactory>().CreateState, Lifetime.Singleton);
        }
    }
}