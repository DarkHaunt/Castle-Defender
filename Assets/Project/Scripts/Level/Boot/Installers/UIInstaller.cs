using Project.Scripts.UI;
using VContainer;
using VContainer.Unity;


namespace Project.Scripts.Level.Boot.Installers
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