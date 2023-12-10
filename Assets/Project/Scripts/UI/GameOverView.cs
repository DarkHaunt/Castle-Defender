using Project.Scripts.Common.Scene;
using UnityEngine.UI;
using UnityEngine;
using VContainer;


namespace Project.Scripts.UI
{
    public class GameOverView : MonoBehaviour
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
            gameObject.SetActive(true);
            
            _menuButton.onClick.AddListener(GoToMenuScene);
            _restartButton.onClick.AddListener(GoToLevelScene);
        }
				
        public void Disable() 
        {
            gameObject.SetActive(false);
            
            _menuButton.onClick.RemoveListener(GoToMenuScene);
            _restartButton.onClick.RemoveListener(GoToLevelScene);
        }

        private void GoToMenuScene()
            => _sceneLoader.LoadSceneWithTransition(Scenes.MainMenu);

        private void GoToLevelScene()
            => _sceneLoader.LoadSceneWithTransition(Scenes.Level);
    }
}