using Project.Scripts.Configs;
using Project.Scripts.UI;


namespace Project.Scripts.Level.StateMachine.States.EndLevel
{
    public class EndLevelStateFactory
    {
        private readonly GameOverView _gameOverView;
        private readonly ConfigsProvider _configsProvider;

        public EndLevelStateFactory(ConfigsProvider configsProvider, GameOverView gameOverView)
        {
            _gameOverView = gameOverView;
            _configsProvider = configsProvider;
        }
        
        public EndLevelState CreateState()
            => new (_configsProvider, _gameOverView);
    }
}