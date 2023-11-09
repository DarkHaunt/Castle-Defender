using Project.Scripts.Common.Scene;


namespace Project.Scripts.Menu.StateMachine.States.LevelLoadState
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