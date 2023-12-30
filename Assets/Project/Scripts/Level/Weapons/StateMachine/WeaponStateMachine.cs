using Project.Scripts.Level.Weapons.StateMachine.States;
using Project.Scripts.Level.Weapons.EnemiesDetection;
using Project.Scripts.Common.StateMachine;
using System.Collections.Generic;
using System;


namespace Project.Scripts.Level.Weapons.StateMachine
{
    public class WeaponStateMachine : IStateSwitcher
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;


        public WeaponStateMachine(IWeaponBehaviorHandler weaponBehaviorHandler, WeaponTargetHolder weaponTargetHolder,
            EnemiesDetector enemiesDetector, float reloadTime)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(WeaponAttack)] = new WeaponAttack(this, weaponBehaviorHandler, weaponTargetHolder),
                [typeof(WeaponReload)] = new WeaponReload(this, weaponBehaviorHandler, reloadTime),
                [typeof(WeaponSearchForTarget)] = new WeaponSearchForTarget(this, weaponTargetHolder, enemiesDetector),
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