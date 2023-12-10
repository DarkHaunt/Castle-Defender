﻿using Project.Scripts.Level.Enemies.Creation;
using Project.Scripts.Level.Enemies.Handling;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Castles;
using Project.Scripts.Level.Init;


namespace Project.Scripts.Level.StateMachine.States.InitLevel
{
    public class InitLevelStateFactory
    {
        private readonly InitializeService _initializeService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly CastleModel _castleModel;


        public InitLevelStateFactory(InitializeService initializeService, CastleModel castleModel, 
            EnemySpawnService enemySpawnService, EnemyHandleService enemyHandleService)
        {
            _initializeService = initializeService;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _castleModel = castleModel;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeService, _castleModel, _enemySpawnService, _enemyHandleService);
    }
}