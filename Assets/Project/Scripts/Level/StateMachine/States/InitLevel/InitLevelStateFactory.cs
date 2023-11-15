using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Handling;
using Project.Scripts.Level.Castles;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelStateFactory
    {
        private readonly InitializeDataProvider _initializeDataProvider;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly CastleModel _castleModel;


        public InitLevelStateFactory(InitializeDataProvider initializeDataProvider, CastleModel castleModel, 
            EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _initializeDataProvider = initializeDataProvider;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _castleModel = castleModel;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _castleModel, _enemySpawnService, _enemyHandleService);
    }
}