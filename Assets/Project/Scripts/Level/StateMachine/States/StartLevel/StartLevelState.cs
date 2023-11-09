using Project.Scripts.Level.StateMachine.States.EndLevel;
using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Weapons.Handling;
using Project.Scripts.Level.Common.Physics;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.StartLevel
{
    public class StartLevelState : IState
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly LevelCollisionsService _collisionsService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CastleModel _castleModel;


        public StartLevelState(IStateSwitcher stateSwitcher, CastleModel castleModel, LevelCollisionsService collisionsService,
            IWeaponHandleService weaponHandleService, EnemyHandleService enemyHandleService, EnemySpawnService enemySpawnService)
        {
            _weaponHandleService = weaponHandleService;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _collisionsService = collisionsService;
            _stateSwitcher = stateSwitcher;
            _castleModel = castleModel;
        }
        
        
        public void Enter()
        {
            Debug.Log($"<color=yellow>Start level</color>");
            
            _enemyHandleService.OnRequairedEnemiesKilled += FinishLevel;
            _castleModel.PhysicBody.OnDeath += FinishLevel;

            _collisionsService.EnableCollisionsSettings();
            _weaponHandleService.Enable();
            _enemyHandleService.Enable();
            _enemySpawnService.Enable();
            _castleModel.Enable();
        }

        public void Exit()
        {
            _enemyHandleService.OnRequairedEnemiesKilled -= FinishLevel;
            _castleModel.PhysicBody.OnDeath -= FinishLevel;
            
            _collisionsService.DisableCollisionsSettings();
            _weaponHandleService.Disable();
            _enemyHandleService.Disable();
            _enemySpawnService.Disable();
            _castleModel.Disable();
        }

        private void FinishLevel()
            => _stateSwitcher.SwitchToState<EndLevelState>();
    }
}