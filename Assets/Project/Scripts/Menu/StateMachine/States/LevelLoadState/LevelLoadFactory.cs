using Game.Common.Scene;


namespace Project.Scripts.Menu.StateMachine.State
{
    public class LevelLoadFactory
    {
        private readonly SceneLoader _sceneLoader;

        public LevelLoadFactory(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public LevelLoad CreateState()
            => new (_sceneLoader);
    }
}