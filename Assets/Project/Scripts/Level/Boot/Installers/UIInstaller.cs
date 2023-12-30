using Project.Scripts.Consume;
using Project.Scripts.Level.Common.Crystals;
using Project.Scripts.UI;
using VContainer.Unity;
using VContainer;


namespace Project.Scripts.Level.Boot.Installers
{
    public class UIInstaller : IInstaller
    {
        private readonly CrystalHandleView _crystalHandleView;
        private readonly GameOverView _gameOverView;


        public UIInstaller(GameOverView gameOverView, CrystalHandleView coinsHandleView)
        {
            _crystalHandleView = coinsHandleView;
            _gameOverView = gameOverView;
        }
        
        
        public void Install(IContainerBuilder builder)
        {
            RegisterGameOverView(builder);
            RegisterCoinsHandleView(builder);
        }

        private void RegisterCoinsHandleView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_crystalHandleView);
        }

        private void RegisterGameOverView(IContainerBuilder builder)
        {
            builder.RegisterComponent(_gameOverView);
        }
    }
}