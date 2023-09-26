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
        private readonly CastleHandleService _castleHandleService;
        private readonly EnemySpawnService _enemySpawnService;


        public InitLevelStateFactory(IInitializeDataProvider initializeDataProvider, CastleHandleService castleHandleService, 
            IWeaponPointsContainer weaponPointsContainer, EnemySpawnService enemySpawnService)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleHandleService = castleHandleService;
            _enemySpawnService = enemySpawnService;
        }
        
        
         public InitLevelState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _castleHandleService, _weaponPointsContainer, _enemySpawnService);
    }
}