using Project.Scripts.Menu.StateMachine.State;
using Project.Scripts.Menu.StateMachine;
using Project.Scripts.Menu.Data;
using Game.Level.StateMachine;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Menu.Bootstrapping
{
    public class MenuLifeScope : LifetimeScope
    {
        [Header("--- Data ---")]
        [SerializeField] private MenuData _menuData;
        [SerializeField] private LevelSelectData _levelSelectData;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStateMachine(builder);

            RegisterStateFactories(builder);
        }

        private static void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MenuStateMachine>();
        }

        private void RegisterStateFactories(IContainerBuilder builder)
        {
            builder.Register<MenuHandleFactory>(Lifetime.Scoped)
                .WithParameter(_menuData);
            builder.RegisterFactory<IStateSwitcher, MenuHandle>(container => 
                container.Resolve<MenuHandleFactory>().CreateState, Lifetime.Scoped);

            builder.Register<LevelSelectFactory>(Lifetime.Scoped)
                .WithParameter(_levelSelectData);
            builder.RegisterFactory<IStateSwitcher, LevelSelect>(container => 
                container.Resolve<LevelSelectFactory>().CreateState, Lifetime.Scoped);

            builder.Register<LevelLoadFactory>(Lifetime.Scoped);
            builder.RegisterFactory<LevelLoad>(container => 
                container.Resolve<LevelLoadFactory>().CreateState, Lifetime.Scoped);
        }
    }
}