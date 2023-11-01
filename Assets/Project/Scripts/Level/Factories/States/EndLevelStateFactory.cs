using Game.Level.StateMachine.States;
using Game.UI.Common;


namespace Game.Level.Factories.States
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