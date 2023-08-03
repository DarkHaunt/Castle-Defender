using System;
using System.Collections.Generic;
using Game.Level.StateMachine.States;
using Game.Level.Weapons.StateMachine.States;


namespace Game.Level.Weapons.StateMachine
{
    public class WeaponStateMachine : IWeaponStateSwitcher
    {
        private readonly Dictionary<Type, IWeaponState> _states;
        private IState _currentState;


        public WeaponStateMachine()
        {
            _states = new Dictionary<Type, IWeaponState>
            {
                
            };
        }

        public void SwitchToState<TState>() where TState : IWeaponState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];
            
            _currentState!.Enter();
        }
    }
}