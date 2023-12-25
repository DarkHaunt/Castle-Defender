using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Data;
using Project.Scripts.Menu.StateMachine.States.LevelSelectState;
using Project.Scripts.Menu.StateMachine.States.SettingsHandleState;
using Project.Scripts.Menu.StateMachine.States.ShopHandleState;


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

            _menuData.ShopButton.onClick.AddListener(OpenShop);
            _menuData.StartButton.onClick.AddListener(SelectLevel);
            _menuData.SettingsButton.onClick.AddListener(OpenSettings);
        }

        public void Exit()
        {
            _menuData.MenuCanvas.gameObject.SetActive(false);
            
            _menuData.ShopButton.onClick.RemoveListener(OpenShop);
            _menuData.StartButton.onClick.RemoveListener(SelectLevel);
            _menuData.SettingsButton.onClick.RemoveListener(OpenSettings);
        }

        private void SelectLevel()
            => _stateSwitcher.SwitchToState<LevelSelect>();

        private void OpenShop()
            => _stateSwitcher.SwitchToState<ShopHandle>();

        private void OpenSettings()
            => _stateSwitcher.SwitchToState<SettingsHandle>();
    }
}