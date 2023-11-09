using Project.Scripts.UI;


namespace Project.Scripts.Level.StateMachine.States.EndLevel
{
    public class EndLevelStateFactory
    {
        private readonly GameOverUIService _gameOverUIService;

        public EndLevelStateFactory(GameOverUIService gameOverUIService)
        {
            _gameOverUIService = gameOverUIService;
        }
        
        public EndLevelState CreateState()
            => new (_gameOverUIService);
    }
}