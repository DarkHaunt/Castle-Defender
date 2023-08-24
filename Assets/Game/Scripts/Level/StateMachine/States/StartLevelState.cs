using Game.Level.Services.Castles;
using Game.Level.Services.Weapons;


namespace Game.Level.StateMachine.States
{
    public class StartLevelState : IState
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ICastleService _castleService;


        public StartLevelState(IStateSwitcher stateSwitcher, ICastleService castleService, IWeaponHandleService weaponHandleService )
        {
            _weaponHandleService = weaponHandleService;
            _stateSwitcher = stateSwitcher;
            _castleService = castleService;
        }
        
        
        public void Enter()
        {
            _castleService.OnCastleDestroyed += FinishLevel;
            
            _weaponHandleService.Enable();
            _castleService.Enable();
        }

        public void Exit()
        {
            _castleService.OnCastleDestroyed -= FinishLevel;
            
            _weaponHandleService.Disable();
            _castleService.Disable();
        }

        private void FinishLevel()
        {
            _stateSwitcher.SwitchToState<EndLevelState>();
        }
    }
}