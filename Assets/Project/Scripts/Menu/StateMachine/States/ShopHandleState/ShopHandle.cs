using Project.Scripts.Menu.StateMachine.States.MenuHandleState;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Data;

namespace Project.Scripts.Menu.StateMachine.States.ShopHandleState
{
    public class ShopHandle : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ShopData _shopData;

        
        public ShopHandle(IStateSwitcher stateSwitcher, ShopData shopData)
        {
            _stateSwitcher = stateSwitcher;
            _shopData = shopData;
        }
        
        
        public void Enter()
        {
            _shopData.ShopCanvas.gameObject.SetActive(true);

            _shopData.ExitButton.onClick.AddListener(SwitchToMenu);
        }

        public void Exit()
        {
            _shopData.ShopCanvas.gameObject.SetActive(false);
            
            _shopData.ExitButton.onClick.AddListener(SwitchToMenu);
        }

        private void SwitchToMenu()
            => _stateSwitcher.SwitchToState<MenuHandle>();
    }
}