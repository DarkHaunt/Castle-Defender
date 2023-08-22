using Game.Level.Services.Castles;
using Game.Level.Services.Weapons;


namespace Game.Level.StateMachine.States.Factories
{
    public class StartLevelStateFactory
    {
        private readonly IWeaponHandleService _weaponHandleService;
        private readonly ICastle _castle;

        
        public StartLevelStateFactory(ICastle castle, IWeaponHandleService weaponHandleService)
        {
            _weaponHandleService = weaponHandleService;
            _castle = castle;
        }
        
        
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _castle, _weaponHandleService);
    }
}