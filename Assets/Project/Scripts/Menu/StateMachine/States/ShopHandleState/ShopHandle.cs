using Project.Scripts.Menu.StateMachine.States.MenuHandleState;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Services;
using Project.Scripts.Menu.Data;
using Project.Scripts.Consume;

namespace Project.Scripts.Menu.StateMachine.States.ShopHandleState
{
    public class ShopHandle : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CoinsHandleService _coinsHandleService;
        private readonly ShopService _shopService;
        private readonly ShopData _shopData;

        
        public ShopHandle(IStateSwitcher stateSwitcher, CoinsHandleService coinsHandleService, 
            ShopService shopService, ShopData shopData)
        {
            _stateSwitcher = stateSwitcher;
            _coinsHandleService = coinsHandleService;
            _shopService = shopService;
            _shopData = shopData;
        }
        
        
        public void Enter()
        {
            _shopService.Enable();
            
            _coinsHandleService.Init();
            
            _shopData.ShopCanvas.gameObject.SetActive(true);
            _shopData.ExitButton.onClick.AddListener(SwitchToMenu);
        }

        public void Exit()
        {
            _shopService.Disable();
            
            _shopData.ShopCanvas.gameObject.SetActive(false);
            _shopData.ExitButton.onClick.AddListener(SwitchToMenu);
        }

        private void SwitchToMenu()
            => _stateSwitcher.SwitchToState<MenuHandle>();
    }
}