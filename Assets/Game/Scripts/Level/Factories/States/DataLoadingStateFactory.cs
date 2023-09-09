using Game.Level.Configs;
using Game.Level.Factories.Level;
using Game.Level.Services.Castles;
using Game.Level.Weapons.HandlePoints;
using Game.Shared;


namespace Game.Level.StateMachine.States.Factories
{
    public class DataLoadingStateFactory
    {
        private readonly IPlayerProgressDataProvider _playerProgressDataProvider;
        private readonly IWeaponPointsContainer _weaponPointsContainer;
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly ICastleService _castleService;
        private readonly ILevelFactory _levelFactory;


        public DataLoadingStateFactory(ILevelConfigProvider levelConfigProvider, ILevelFactory levelFactory,
            ICastleService castleService, IWeaponPointsContainer weaponPointsContainer, IPlayerProgressDataProvider playerProgressDataProvider)
        {
            _playerProgressDataProvider = playerProgressDataProvider;
            _weaponPointsContainer = weaponPointsContainer;
            _levelConfigProvider = levelConfigProvider;
            _castleService = castleService;
            _levelFactory = levelFactory;
        }


        public DataLoadingState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _levelFactory, _castleService, _levelConfigProvider, _weaponPointsContainer, _playerProgressDataProvider);
    }
}