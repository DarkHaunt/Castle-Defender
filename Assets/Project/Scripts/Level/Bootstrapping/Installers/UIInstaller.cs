using VContainer.Unity;
using Game.UI.Common;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class UIInstaller : IInstaller
    {
        private readonly GameOverUIService _gameOverUIService;

        
        public UIInstaller(GameOverUIService gameOverUIService)
        {
            _gameOverUIService = gameOverUIService;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterGameOverUIService(builder);
        }
        
        private void RegisterGameOverUIService(IContainerBuilder builder)
        {
            builder.RegisterComponent(_gameOverUIService);
        }
    }
}