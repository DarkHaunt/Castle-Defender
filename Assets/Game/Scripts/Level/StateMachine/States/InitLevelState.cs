using Game.Level.Weapons.HandlePoints;
using Game.Level.Services.Castles;
using Game.Level.Services.Enemies;
using Game.Level.Configs;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class InitLevelState : IState
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly CastleHandleService _castleHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly EnemyPoolService _enemyPoolService;
        private readonly IStateSwitcher _stateSwitcher;


        public InitLevelState(IStateSwitcher stateSwitcher, IInitializeDataProvider initializeDataProvider, CastleHandleService castleHandleService, 
            IWeaponPointsContainer weaponPointsContainer, EnemySpawnService enemySpawnService, EnemyPoolService enemyPoolService)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleHandleService = castleHandleService;
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
            
            _castleHandleService.Init(castle.PhysicBody, levelInitData.CastleHealth);
            _weaponPointsContainer.Init(castle.CreateAllWeaponPoints());
            _enemySpawnService.Init(levelInitData, level);
            _enemyPoolService.Init(levelInitData.Enemies);

            SwitchToLevelStart();
        }

        private void SwitchToLevelStart()
            => _stateSwitcher.SwitchToState<StartLevelState>();

        public void Exit() {}
    }
}