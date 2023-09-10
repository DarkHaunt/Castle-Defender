using Game.Level.Weapons.HandlePoints;
using Game.Level.Services.Castles; 
using Game.Level.Configs;


namespace Game.Level.StateMachine.States.Factories
{
    public class InitLevelStateFactory
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly ICastleHandleService _castleHandleService;

        
        public InitLevelStateFactory(IInitializeDataProvider initializeDataProvider, 
            ICastleHandleService castleHandleService, IWeaponPointsContainer weaponPointsContainer)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleHandleService = castleHandleService;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _castleHandleService, _weaponPointsContainer);
    }
}