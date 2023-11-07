using Game.Level.StateMachine.States;
using Project.Scripts.Menu.Data;
using Game.Level.StateMachine;
using Game.Configs.Level;
using Game.Common.Save;
using Game.Static;


namespace Project.Scripts.Menu.StateMachine.State
{
    public class LevelSelect : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly LevelSelectData _selectData;

        
        public LevelSelect(IStateSwitcher stateSwitcher, LevelSelectData selectData)
        {
            _stateSwitcher = stateSwitcher;
            _selectData = selectData;
        }


        public void Enter()
        {
            _selectData.LevelSelectCanvas.gameObject.SetActive(true);
            
            foreach (var levelButton in _selectData.LevelButtons)
                levelButton.OnClicked += SaveSelectedLevel;  
        }

        public void Exit()
        {
            _selectData.LevelSelectCanvas.gameObject.SetActive(false);
            
            foreach (var levelButton in _selectData.LevelButtons)
                levelButton.OnClicked -= SaveSelectedLevel;
        }

        private void SaveSelectedLevel(LevelConfig levelConfig)
        {
            var serializedLevelConfigs = new SerializedLevelConfig(levelConfig);
            
            JsonSerializer.SaveToFile(StaticDataContainer.LevelConfigsPath, serializedLevelConfigs);
         
            _stateSwitcher.SwitchToState<LevelLoad>();
        }
    }
}