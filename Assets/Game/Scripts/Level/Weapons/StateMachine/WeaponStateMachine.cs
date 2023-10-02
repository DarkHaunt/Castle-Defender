using Game.Level.StateMachine.States;
using System.Collections.Generic;
using Game.Level.StateMachine;
using System;


namespace Game.Level.Weapons.StateMachine
{
    public class WeaponStateMachine : IStateSwitcher
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public WeaponStateMachine()
        {
            _states = new Dictionary<Type, IState>
            {
                
            };
        }

        public void SwitchToState<TState>() where TState : IState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];
            
            _currentState!.Enter();
        }
    }
}