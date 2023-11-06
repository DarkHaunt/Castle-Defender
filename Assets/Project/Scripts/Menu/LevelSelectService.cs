using System.Collections.Generic;
using Project.Scripts.Menu.UI;
using Game.Configs.Level;
using Game.Common.Scene;
using Game.Common.Save;
using Game.Static;


namespace Project.Scripts.Menu
{
    public class LevelSelectService
    {
        private readonly List<LevelButton> _levelButtons;
        private readonly SceneLoader _sceneLoader;

        
        public LevelSelectService(SceneLoader sceneLoader, List<LevelButton> levelButtons)
        {
            _levelButtons = levelButtons;
            _sceneLoader = sceneLoader;
        }
        
        
        public void Enable() 
        {
            foreach (var levelButton in _levelButtons)
                levelButton.OnClicked += SaveSelectedLevel;  
        }

        public void Disable() 
        {
            foreach (var levelButton in _levelButtons)
                levelButton.OnClicked -= SaveSelectedLevel;
        }

        private void SaveSelectedLevel(LevelConfig levelConfig)
        {
            var serializedLevelConfigs = new SerializedLevelConfig(levelConfig);
            
            JsonSerializer.SaveToFile(StaticDataContainer.LevelConfigsPath, serializedLevelConfigs);
            
            _sceneLoader.LoadSceneWithTransition(Scenes.Level);
        }
    }
}