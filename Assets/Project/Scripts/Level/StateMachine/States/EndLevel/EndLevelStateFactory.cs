using Project.Scripts.Configs;
using Project.Scripts.UI;


namespace Project.Scripts.Level.StateMachine.States.EndLevel
{
    public class EndLevelStateFactory
    {
        private readonly GameOverUIService _gameOverUIService;
        private readonly ConfigsProvider _configsProvider;

        public EndLevelStateFactory(ConfigsProvider configsProvider, GameOverUIService gameOverUIService)
        {
            _gameOverUIService = gameOverUIService;
            _configsProvider = configsProvider;
        }
        
        public EndLevelState CreateState()
            => new (_configsProvider, _gameOverUIService);
    }
}