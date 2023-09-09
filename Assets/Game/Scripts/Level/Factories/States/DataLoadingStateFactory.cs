using Game.Level.Configs;
using Game.Level.Factories.Level;
using Game.Level.Services.Castles;


namespace Game.Level.StateMachine.States.Factories
{
    public class DataLoadingStateFactory
    {
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly ICastleService _castleService;
        private readonly ILevelFactory _levelFactory;


        public DataLoadingStateFactory(ILevelConfigProvider levelConfigProvider, ILevelFactory levelFactory, 
            ICastleService castleService)
        {
            _levelConfigProvider = levelConfigProvider;
            _levelFactory = levelFactory;
            _castleService = castleService;
        }
        
        
        public DataLoadingState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _levelFactory, _castleService, _levelConfigProvider);
    }
}