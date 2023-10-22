using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Services.Level;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class InitLevelState : IState
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly EnemyPoolService _enemyPoolService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CastleModel _castleModel;


        public InitLevelState(IStateSwitcher stateSwitcher, IInitializeDataProvider initializeDataProvider, 
            CastleModel castleModel, EnemySpawnService enemySpawnService, EnemyPoolService enemyPoolService)
        {
            _initializeDataProvider = initializeDataProvider;
            _castleModel = castleModel;
            _enemySpawnService = enemySpawnService;
            _enemyPoolService = enemyPoolService;
            _stateSwitcher = stateSwitcher;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Init Level</color>");
            
            var levelInitData = _initializeDataProvider.GetInitializeData();
            
            var level = levelInitData.Level;
            var castle = level.Castle;
            
            _castleModel.Init(castle, levelInitData.CastleHealth);
            _enemySpawnService.Init(levelInitData, level);
            _enemyPoolService.Init(levelInitData.Enemies);

            SwitchToLevelStart();
        }

        private void SwitchToLevelStart()
            => _stateSwitcher.SwitchToState<StartLevelState>();

        public void Exit() {}
    }
}