using Project.Scripts.Menu.StateMachine.State;
using Game.Level.StateMachine.States;
using System.Collections.Generic;
using Game.Level.StateMachine;
using VContainer.Unity;
using System;


namespace Project.Scripts.Menu.StateMachine
{
    public class MenuStateMachine : IStateSwitcher, IStartable
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public MenuStateMachine(MenuHandleFactory menuHandleFactory, LevelSelectFactory levelSelectFactory,
            LevelLoadFactory levelLoadFactory)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(MenuHandle)] = menuHandleFactory.CreateState(this),
                [typeof(LevelSelect)] = levelSelectFactory.CreateState(this),
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