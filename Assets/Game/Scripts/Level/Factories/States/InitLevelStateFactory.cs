using Game.Level.Weapons.HandlePoints;
using Game.Level.Services.Castles; 
using Game.Level.Services.Enemies;
using Game.Level.Configs;


namespace Game.Level.StateMachine.States.Factories
{
    public class InitLevelStateFactory
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly ICastleHandleService _castleHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly EnemyHandleService _enemyHandleService;


        public InitLevelStateFactory(IInitializeDataProvider initializeDataProvider, ICastleHandleService castleHandleService, 
            IWeaponPointsContainer weaponPointsContainer, EnemyHandleService enemyHandleService, EnemySpawnService enemySpawnService)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleHandleService = castleHandleService;
            _enemySpawnService = enemySpawnService;
            _enemyHandleService = enemyHandleService;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _castleHandleService, _weaponPointsContainer, _enemyHandleService, _enemySpawnService);
    }
}