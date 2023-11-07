using Game.Level.StateMachine.States;
using Project.Scripts.Menu.Data;
using Game.Level.StateMachine;


namespace Project.Scripts.Menu.StateMachine.State
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
        }

        public void Exit()
        {
            _menuData.MenuCanvas.gameObject.SetActive(false);
            
            _menuData.StartButton.onClick.RemoveListener(SelectLevel);
        }

        private void SelectLevel()
            => _stateSwitcher.SwitchToState<LevelSelect>();
    }
}