﻿using Game.Level.Weapons.HandlePoints;
using Game.Level.Services.Castles; 
using Game.Level.Services.Enemies;
using Game.Level.Configs;


namespace Game.Level.StateMachine.States.Factories
{
    public class InitLevelStateFactory
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly CastleModel _castleModel;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly EnemyPoolService _enemyPoolService;


        public InitLevelStateFactory(IInitializeDataProvider initializeDataProvider, CastleModel castleModel, 
            IWeaponPointsContainer weaponPointsContainer, EnemySpawnService enemySpawnService, EnemyPoolService enemyPoolService)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleModel = castleModel;
            _enemySpawnService = enemySpawnService;
            _enemyPoolService = enemyPoolService;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _castleModel, _enemySpawnService, _enemyPoolService);
    }
}