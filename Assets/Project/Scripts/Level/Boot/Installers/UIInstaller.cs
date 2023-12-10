using Project.Scripts.Consume;
using Project.Scripts.UI;
using VContainer.Unity;
using VContainer;


namespace Project.Scripts.Level.Boot.Installers
{
    public class UIInstaller : IInstaller
    {
        private readonly GameOverView _gameOverView;
        private readonly CoinsHandleView _coinsHandleView;


        public UIInstaller(GameOverView gameOverView, CoinsHandleView coinsHandleView)
        {
            _gameOverView = gameOverView;
            _coinsHandleView = coinsHandleView;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterGameOverView(builder);
            RegisterCoinsHandleView(builder);
        }

        private void RegisterCoinsHandleView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_coinsHandleView);
        }

        private void RegisterGameOverView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_gameOverView);
        }
    }
}