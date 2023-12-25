using Project.Scripts.Menu.StateMachine.States.LevelSelectState;
using Project.Scripts.Menu.StateMachine.States.ShopHandleState;
using Project.Scripts.Menu.StateMachine.States.MenuHandleState;
using Project.Scripts.Menu.StateMachine.States.LevelLoadState;
using Project.Scripts.Common.StateMachine;
using System.Collections.Generic;
using VContainer.Unity;
using System;
using Project.Scripts.Menu.StateMachine.States.SettingsHandleState;


namespace Project.Scripts.Menu.StateMachine
{
    public class MenuStateMachine : IStateSwitcher, IStartable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public MenuStateMachine(MenuHandleFactory menuHandleFactory, LevelSelectFactory levelSelectFactory,
            LevelLoadFactory levelLoadFactory, SettingsHandleFactory settingsHandleFactory, ShopHandleFactory shopHandleFactory)
        {
            _states = new Dictionary<Type, IState>(5)
            {
                [typeof(SettingsHandle)] = settingsHandleFactory.CreateState(this),
                [typeof(LevelSelect)] = levelSelectFactory.CreateState(this),
                [typeof(MenuHandle)] = menuHandleFactory.CreateState(this),
                [typeof(ShopHandle)] = shopHandleFactory.CreateState(this),
                [typeof(LevelLoad)] = levelLoadFactory.CreateState(),
            };
        }
        

        public void SwitchToState<TState>() where TState : IState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];

            _currentState!.Enter();
        }

        void IStartable.Start()
            => SwitchToState<MenuHandle>();
    }
}