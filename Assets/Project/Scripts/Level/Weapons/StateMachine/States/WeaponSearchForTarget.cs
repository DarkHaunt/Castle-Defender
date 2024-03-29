﻿using Project.Scripts.Common.StateMachine;
using Project.Scripts.Extensions;
using Project.Scripts.Level.Weapons.EnemiesDetection;


namespace Project.Scripts.Level.Weapons.StateMachine.States
{
    public class WeaponSearchForTarget : IState
    {
        private readonly WeaponTargetHolder _weaponTargetHolder;
        private readonly EnemiesDetector _enemiesDetector;
        private readonly IStateSwitcher _stateSwitcher;


        public WeaponSearchForTarget(IStateSwitcher stateSwitcher, WeaponTargetHolder weaponTargetHolder,
            EnemiesDetector enemiesDetector)
        {
            _stateSwitcher = stateSwitcher;
            _weaponTargetHolder = weaponTargetHolder;
            _enemiesDetector = enemiesDetector;
        }


        public void Enter()
        {
            _enemiesDetector.OnEnemyDetected += ChoseEnemyTarget;
            
            if(_weaponTargetHolder.TryToGetEnemyTarget(out _))
                _stateSwitcher.SwitchToState<WeaponAttack>();
        }

        public void Exit()
            => _enemiesDetector.OnEnemyDetected -= ChoseEnemyTarget;

        private void ChoseEnemyTarget()
        {
            var enemy = _enemiesDetector.GetDetectedEnemies().PickRandom();
            
            _weaponTargetHolder.SetEnemyTarget(enemy);
            
            _stateSwitcher.SwitchToState<WeaponAttack>();
        }
    }
}