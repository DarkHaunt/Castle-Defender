using Project.Scripts.Level.StateMachine.States.StartLevel;
using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Init;
using Project.Scripts.Consume;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CoinsHandleService _coinsHandleService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly InitializeService _initializeService;
        private readonly CastleModel _castleModel;


        public InitLevelState(IStateSwitcher stateSwitcher, CoinsHandleService coinsHandleService, InitializeService initializeService, 
            CastleModel castleModel, EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _stateSwitcher = stateSwitcher;
            _coinsHandleService = coinsHandleService;
            _enemyHandleService = enemyHandleService;
            _initializeService = initializeService;
            _enemySpawnService = enemySpawnService;
            _castleModel = castleModel;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Init Level</color>");

            var levelInitData = _initializeService.GetInitializeData();
            
            var level = levelInitData.Level;
            var castle = level.Castle;
            
            _enemyHandleService.Init(levelInitData.Enemies, levelInitData.CountEnemiesToKill);
            _castleModel.Init(castle, levelInitData.CastleHealth);
            _enemySpawnService.Init(levelInitData, level);
            _coinsHandleService.Init();

            SwitchToLevelStart();
        }

        private void SwitchToLevelStart()
            => _stateSwitcher.SwitchToState<StartLevelState>();

        public void Exit() {}
    }
}