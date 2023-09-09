using Game.Level.Services.Castles;
using Game.Level.Services.Weapons;


namespace Game.Level.StateMachine.States.Factories
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly ICastleService _castleService;

        
        public StartLevelStateFactory(ICastleService castleService, IWeaponHandleService weaponHandleService)
        {
            _weaponHandleService = weaponHandleService;
            _castleService = castleService;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castleService, _weaponHandleService);
    }
}