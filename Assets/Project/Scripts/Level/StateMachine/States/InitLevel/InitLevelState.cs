using Game.Level.StateMachine;
using Game.Level.StateMachine.States;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Level.Handling;
using Project.Scripts.Level.StateMachine.States.StartLevel;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelState : IState
    {
        private readonly InitializeDataProvider _initializeDataProvider;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly EnemyPoolService _enemyPoolService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CastleModel _castleModel;


        public InitLevelState(IStateSwitcher stateSwitcher, InitializeDataProvider initializeDataProvider, 
            CastleModel castleModel, EnemySpawnService enemySpawnService, EnemyPoolService enemyPoolService)
        {
            _initializeDataProvider = initializeDataProvider;
            _enemySpawnService = enemySpawnService;
            _enemyPoolService = enemyPoolService;
            _stateSwitcher = stateSwitcher;
            _castleModel = castleModel;
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