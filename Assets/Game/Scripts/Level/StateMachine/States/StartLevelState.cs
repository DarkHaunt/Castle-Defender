using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Weapons;
using Game.Common.Physics;
using UnityEngine;


namespace Game.Level.StateMachine.States
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
            _castleModel = castleModel;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _collisionsService = collisionsService;
            _stateSwitcher = stateSwitcher;
        }
        
        
        public void Enter()
        {
            Debug.Log($"<color=yellow>Start level</color>");
            
            _castleModel.PhysicBody.OnDeath += FinishLevel;

            _collisionsService.EnableCollisionsSettings();
            _weaponHandleService.Enable();
            _enemyHandleService.Enable();
            _enemySpawnService.Enable();
            _castleModel.Enable();
        }

        public void Exit()
        {
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