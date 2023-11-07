using Game.Level.StateMachine;
using Game.Level.StateMachine.States;
using Project.Scripts.Menu.Data;
using Project.Scripts.Menu.StateMachine.States.LevelSelectState;
using Project.Scripts.Menu.StateMachine.States.SettingsSelectState;


namespace Project.Scripts.Menu.StateMachine.States.MenuHandleState
{
    public class MenuHandle : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly MenuData _menuData;

        
        public MenuHandle(IStateSwitcher stateSwitcher, MenuData menuData)
        {
            _stateSwitcher = stateSwitcher;
            _menuData = menuData;
        }
        
        
        public void Enter()
        {
            _menuData.MenuCanvas.gameObject.SetActive(true);

            _menuData.StartButton.onClick.AddListener(SelectLevel);
            _menuData.SettingsButton.onClick.AddListener(SelectSettings);
        }

        public void Exit()
        {
            _menuData.MenuCanvas.gameObject.SetActive(false);
            
            _menuData.StartButton.onClick.RemoveListener(SelectLevel);
            _menuData.SettingsButton.onClick.RemoveListener(SelectSettings);
        }

        private void SelectLevel()
            => _stateSwitcher.SwitchToState<LevelSelect>();   
        
        private void SelectSettings()
            => _stateSwitcher.SwitchToState<SettingsSelect>();
    }
}