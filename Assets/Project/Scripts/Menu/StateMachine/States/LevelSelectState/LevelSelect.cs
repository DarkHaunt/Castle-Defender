using Project.Scripts.Common.Infrastructure;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs.Level;
using Project.Scripts.Global;
using Project.Scripts.Menu.Data;
using Project.Scripts.Menu.StateMachine.States.LevelLoadState;


namespace Project.Scripts.Menu.StateMachine.States.LevelSelectState
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
            
            JsonSerializer.SaveToFile(InfrastructureKeys.LevelConfigsPath, serializedLevelConfigs);
         
            _stateSwitcher.SwitchToState<LevelLoad>();
        }
    }
}