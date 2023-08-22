using Game.Level.Services.Castles;
using Game.Level.Services.Weapons;


namespace Game.Level.StateMachine.States
{
    public class StartLevelState : IState
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ICastle _castle;


        public StartLevelState(IStateSwitcher stateSwitcher, ICastle castle, IWeaponHandleService weaponHandleService )
        {
            _weaponHandleService = weaponHandleService;
            _stateSwitcher = stateSwitcher;
            _castle = castle;
        }
        
        
        public void Enter()
        {
            _castle.OnDeath += FinishLevel;
            
            _weaponHandleService.Enable();
            _castle.Enable();
        }

        public void Exit()
        {
            _castle.OnDeath -= FinishLevel;
            
            _weaponHandleService.Disable();
            _castle.Disable();
        }

        private void FinishLevel()
        {
            _stateSwitcher.SwitchToState<EndLevelState>();
        }
    }
}