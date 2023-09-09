using Game.Level.Weapons.HandlePoints;
using Game.Level.Services.Castles;
using Game.Level.Factories.Level;
using Game.Level.Configs;
using Game.Shared;


namespace Game.Level.StateMachine.States
{
    public class DataLoadingState : IState
    {
        private readonly IPlayerProgressDataProvider _playerProgressDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ICastleService _castleService;
        private readonly ILevelFactory _levelFactory;


        public DataLoadingState(IStateSwitcher stateSwitcher, ILevelFactory levelFactory, ICastleService castleService, 
            ILevelConfigProvider levelConfigProvider, IWeaponPointsContainer weaponPointsContainer, IPlayerProgressDataProvider playerProgressDataProvider)
        {
            _playerProgressDataProvider = playerProgressDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _levelConfigProvider = levelConfigProvider;
            _castleService = castleService;
            _stateSwitcher = stateSwitcher;
            _levelFactory = levelFactory;
        }


        public void Enter()
        {
            var playerData = _playerProgressDataProvider.GetPlayerProgressData();
            var levelConfigs = _levelConfigProvider.GetLevelConfig();
            
            var level = _levelFactory.CreateLevel(levelConfigs.LevelPrefabPath);
            var castle = level.Castle;
            
            _castleService.Init(castle, playerData.CastleHealth);
            _weaponPointsContainer.Init(castle.WeaponHandlePoints);
            
            SwitchToStartLevelState();
        }

        public void Exit() {}

        private void SwitchToStartLevelState()
            => _stateSwitcher.SwitchToState<StartLevelState>();
    }
}