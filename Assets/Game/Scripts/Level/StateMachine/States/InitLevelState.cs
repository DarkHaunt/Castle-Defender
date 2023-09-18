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
        private readonly ICastleHandleService _castleHandleService;
        private readonly EnemyHandleService _enemyHandleService;
        private readonly EnemySpawnService _enemySpawnService;
        private readonly IStateSwitcher _stateSwitcher;


        public InitLevelState(IStateSwitcher stateSwitcher, IInitializeDataProvider initializeDataProvider, ICastleHandleService castleHandleService, 
            IWeaponPointsContainer weaponPointsContainer, EnemyHandleService enemyHandleService, EnemySpawnService enemySpawnService)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleHandleService = castleHandleService;
            _enemyHandleService = enemyHandleService;
            _enemySpawnService = enemySpawnService;
            _stateSwitcher = stateSwitcher;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Init Level</color>");
            
            var levelInitData = _initializeDataProvider.GetInitializeData();
            
            var level = levelInitData.Level;
            var castle = level.Castle;
            
            _castleHandleService.Init(castle.PhysicBody, levelInitData.CastleHealth);
            _weaponPointsContainer.Init(castle.WeaponHandlePoints);
            _enemySpawnService.Init(levelInitData, level);
            _enemyHandleService.Init(castle.PhysicBody);

            SwitchToLevelStart();
        }

        private void SwitchToLevelStart()
            => _stateSwitcher.SwitchToState<StartLevelState>();

        public void Exit() {}
    }
}