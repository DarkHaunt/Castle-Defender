using Game.Level.StateMachine.States;
using Game.Common.Scene;


namespace Project.Scripts.Menu.StateMachine.State
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