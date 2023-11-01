using Game.Common.Scene;
using UnityEngine.UI;
using UnityEngine;
using VContainer;


namespace Game.UI.Common
{
    public class GameOverUIService : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;
        
        private SceneLoader _sceneLoader;

        
        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void Enable() 
        {
            _menuButton.onClick.AddListener(GoToMenuScene);
            _restartButton.onClick.AddListener(GoToLevelScene);
        }
				
        public void Disable() 
        {
            _menuButton.onClick.RemoveListener(GoToMenuScene);
            _restartButton.onClick.RemoveListener(GoToLevelScene);
        }

        private void GoToMenuScene()
            => _sceneLoader.LoadSceneWithTransition(Scenes.MainMenu);

        private void GoToLevelScene()
            => _sceneLoader.LoadSceneWithTransition(Scenes.Level);
    }
}