using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Weapons;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class StartLevelState : IState
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly ICastleHandleService _castleHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly IStateSwitcher _stateSwitcher;


        public StartLevelState(IStateSwitcher stateSwitcher, ICastleHandleService castleHandleService, IWeaponHandleService weaponHandleService, EnemySpawnService enemySpawnService)
        {
            _weaponHandleService = weaponHandleService;
            _castleHandleService = castleHandleService;
            _enemySpawnService = enemySpawnService;
            _stateSwitcher = stateSwitcher;
        }
        
        
        public void Enter()
        {
            Debug.Log($"<color=yellow>Start level</color>");
            
            _castleHandleService.OnCastleDestroyed += FinishLevel;

            _weaponHandleService.Enable();
            _castleHandleService.Enable();
            _enemySpawnService.Enable();
        }

        public void Exit()
        {
            _castleHandleService.OnCastleDestroyed -= FinishLevel;
            
            _weaponHandleService.Disable();
            _castleHandleService.Disable();
            _enemySpawnService.Disable();
        }

        private void FinishLevel()
        {
            _stateSwitcher.SwitchToState<EndLevelState>();
        }
    }
}