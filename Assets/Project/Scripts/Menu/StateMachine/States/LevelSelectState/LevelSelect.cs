using Project.Scripts.Menu.StateMachine.States.LevelLoadState;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs.Level;
using Project.Scripts.Menu.Data;
using Project.Scripts.Configs;


namespace Project.Scripts.Menu.StateMachine.States.LevelSelectState
{
    public class LevelSelect : IState
    {
        private readonly ConfigsProvider _configsProvider;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly LevelSelectData _selectData;

        
        public LevelSelect(IStateSwitcher stateSwitcher, ConfigsProvider configsProvider, LevelSelectData selectData)
        {
            _configsProvider = configsProvider;
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
            _configsProvider.UpdateLevelConfig(levelConfig);
            _stateSwitcher.SwitchToState<LevelLoad>();
        }
    }
}