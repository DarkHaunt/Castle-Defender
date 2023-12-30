using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Init;
using Project.Scripts.Consume;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelStateFactory
    {
        private readonly CrystalHandleService _crystalHandleService;
        private readonly CoinsHandleService _coinsHandleService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly InitializeService _initializeService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly CastleModel _castleModel;


        public InitLevelStateFactory(CoinsHandleService coinsHandleService, CrystalHandleService crystalHandleService, InitializeService initializeService, 
            CastleModel castleModel, EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _crystalHandleService = crystalHandleService;
            _coinsHandleService = coinsHandleService;
            _enemyHandleService = enemyHandleService;
            _initializeService = initializeService;
            _enemySpawnService = enemySpawnService;
            _castleModel = castleModel;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _coinsHandleService, _crystalHandleService, _initializeService, _castleModel, _enemySpawnService, _enemyHandleService);
    }
}