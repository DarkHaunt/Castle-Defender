using Game.Level.Weapons.HandlePoints;
using Game.Level.Services.Castles;
using Game.Level.Configs;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class InitLevelState : IState
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly ICastleHandleService _castleHandleService;
        private readonly IStateSwitcher _stateSwitcher;

        
        public InitLevelState(IStateSwitcher stateSwitcher, IInitializeDataProvider initializeDataProvider, 
            ICastleHandleService castleHandleService, IWeaponPointsContainer weaponPointsContainer)
        {
            _initializeDataProvider = initializeDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _castleHandleService = castleHandleService;
            _stateSwitcher = stateSwitcher;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Init Level</color>");
            
            var levelInitData = _initializeDataProvider.GetInitializeData();
            var castle = levelInitData.Level.Castle;
            
            _castleHandleService.Init(castle.PhysicBody, levelInitData.CastleHealth);
            _weaponPointsContainer.Init(castle.WeaponHandlePoints);

            SwitchToLevelStart();
        }

        private void SwitchToLevelStart()
            => _stateSwitcher.SwitchToState<StartLevelState>();

        public void Exit() {}
    }
}