using Project.Scripts.Level.StateMachine.States.StartLevel;
using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Init;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelState : IState
    {
        private readonly InitializeService _initializeService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CastleModel _castleModel;


        public InitLevelState(IStateSwitcher stateSwitcher, InitializeService initializeService, 
            CastleModel castleModel, EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _initializeService = initializeService;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _stateSwitcher = stateSwitcher;
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

            SwitchToLevelStart();
        }

        private void SwitchToLevelStart()
            => _stateSwitcher.SwitchToState<StartLevelState>();

        public void Exit() {}
    }
}