using Game.Level.Services.Castles;
using Game.Level.Services.Weapons;


namespace Game.Level.StateMachine.States.Factories
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly ICastleHandleService _castleHandleService;

        
        public StartLevelStateFactory(ICastleHandleService castleHandleService, IWeaponHandleService weaponHandleService)
        {
            _weaponHandleService = weaponHandleService;
            _castleHandleService = castleHandleService;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castleHandleService, _weaponHandleService);
    }
}