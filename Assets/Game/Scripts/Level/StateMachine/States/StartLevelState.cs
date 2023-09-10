using Game.Level.Services.Castles;
using Game.Level.Services.Weapons;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class StartLevelState : IState
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ICastleHandleService _castleHandleService;


        public StartLevelState(IStateSwitcher stateSwitcher, ICastleHandleService castleHandleService, IWeaponHandleService weaponHandleService )
        {
            _weaponHandleService = weaponHandleService;
            _stateSwitcher = stateSwitcher;
            _castleHandleService = castleHandleService;
        }
        
        
        public void Enter()
        {
            Debug.Log($"<color=yellow>Start level</color>");
            
            _castleHandleService.OnCastleDestroyed += FinishLevel;
            
            _weaponHandleService.Enable();
            _castleHandleService.Enable();
        }

        public void Exit()
        {
            _castleHandleService.OnCastleDestroyed -= FinishLevel;
            
            _weaponHandleService.Disable();
            _castleHandleService.Disable();
        }

        private void FinishLevel()
        {
            _stateSwitcher.SwitchToState<EndLevelState>();
        }
    }
}