using Project.Scripts.Common.Scene;
using Project.Scripts.Common.StateMachine;


namespace Project.Scripts.Menu.StateMachine.States.LevelLoadState
{
    public class LevelLoad : IState
    {
        private readonly SceneLoader _sceneLoader;

        public LevelLoad(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
            => _sceneLoader.LoadSceneWithTransition(Scenes.Level);

        public void Exit() {}
    }
}