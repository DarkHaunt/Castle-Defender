using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Handling;
using Project.Scripts.Level.Weapons.HandlePoints;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelStateFactory
    {
        private readonly InitializeDataProvider _initializeDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly CastleModel _castleModel;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly EnemyPoolService _enemyPoolService;


        public InitLevelStateFactory(InitializeDataProvider initializeDataProvider, CastleModel castleModel, 
            EnemySpawnService enemySpawnService, EnemyPoolService enemyPoolService)
        {
            _initializeDataProvider = initializeDataProvider;
            _enemySpawnService = enemySpawnService;
            _enemyPoolService = enemyPoolService;
            _castleModel = castleModel;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _castleModel, _enemySpawnService, _enemyPoolService);
    }
}