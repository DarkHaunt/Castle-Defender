﻿using Project.Scripts.Menu.StateMachine.States.SettingsSelectState;
using Project.Scripts.Menu.StateMachine.States.LevelSelectState;
using Project.Scripts.Menu.StateMachine.States.ShopHandleState;
using Project.Scripts.Menu.StateMachine.States.MenuHandleState;
using Project.Scripts.Menu.StateMachine.States.LevelLoadState;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.StateMachine;
using Project.Scripts.Menu.Data;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Menu.Boot
{
    public class MenuLifeScope : LifetimeScope
    {
        [Header("--- Data ---")]
        [SerializeField] private ShopData _shopData;
        [SerializeField] private MenuData _menuData;
        [SerializeField] private LevelSelectData _levelSelectData;
        [SerializeField] private SettingsSelectData _settingsSelectData;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterStateMachine(builder);

            RegisterSettingsHandleFactory(builder);
            RegisterLevelSelectFactory(builder);
            RegisterShopHandleFactory(builder);
            RegisterMenuHandleFactory(builder);
            RegisterLevelLoadFactory(builder);
        }

        private static void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MenuStateMachine>();
        }

        private void RegisterSettingsHandleFactory(IContainerBuilder builder)
        {
            builder.Register<SettingsHandleFactory>(Lifetime.Scoped)
                .WithParameter(_settingsSelectData);

            builder.RegisterFactory<IStateSwitcher, SettingsHandle>(container =>
                container.Resolve<SettingsHandleFactory>().CreateState, Lifetime.Scoped);
        }  
        
        private void RegisterShopHandleFactory(IContainerBuilder builder)
        {
            builder.Register<ShopHandleFactory>(Lifetime.Scoped)
                .WithParameter(_settingsSelectData);

            builder.RegisterFactory<IStateSwitcher, ShopHandle>(container =>
                container.Resolve<ShopHandleFactory>().CreateState, Lifetime.Scoped);
        }

        private void RegisterLevelLoadFactory(IContainerBuilder builder)
        {
            builder.Register<LevelLoadFactory>(Lifetime.Scoped);

            builder.RegisterFactory<LevelLoad>(container =>
                container.Resolve<LevelLoadFactory>().CreateState, Lifetime.Scoped);
        }

        private void RegisterLevelSelectFactory(IContainerBuilder builder)
        {
            builder.Register<LevelSelectFactory>(Lifetime.Scoped)
                .WithParameter(_levelSelectData);

            builder.RegisterFactory<IStateSwitcher, LevelSelect>(container =>
                container.Resolve<LevelSelectFactory>().CreateState, Lifetime.Scoped);
        }

        private void RegisterMenuHandleFactory(IContainerBuilder builder)
        {
            builder.Register<MenuHandleFactory>(Lifetime.Scoped)
                .WithParameter(_menuData);

            builder.RegisterFactory<IStateSwitcher, MenuHandle>(container =>
                container.Resolve<MenuHandleFactory>().CreateState, Lifetime.Scoped);
        }
    }
}