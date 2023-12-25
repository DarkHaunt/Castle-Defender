using Project.Scripts.Menu.StateMachine.States.MenuHandleState;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs;
using Project.Scripts.Menu.Data;
using Project.Scripts.Consume;

namespace Project.Scripts.Menu.StateMachine.States.ShopHandleState
{
    public class ShopHandle : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly CoinsHandleService _coinsHandleService;
        private readonly ConfigsProvider _configsProvider;
        private readonly ShopData _shopData;

        
        public ShopHandle(IStateSwitcher stateSwitcher, ConfigsProvider configsProvider, 
            CoinsHandleService coinsHandleService, ShopData shopData)
        {
            _coinsHandleService = coinsHandleService;
            _configsProvider = configsProvider;
            _stateSwitcher = stateSwitcher;
            _shopData = shopData;
        }
        
        
        public void Enter()
        {
            _configsProvider.LoadConfigs();
            _coinsHandleService.Init();
            
            _shopData.ShopCanvas.gameObject.SetActive(true);
            _shopData.ExitButton.onClick.AddListener(SwitchToMenu);
        }

        public void Exit()
        {
            _configsProvider.SaveConfigs();
            
            _shopData.ShopCanvas.gameObject.SetActive(false);
            _shopData.ExitButton.onClick.AddListener(SwitchToMenu);
        }

        private void SwitchToMenu()
            => _stateSwitcher.SwitchToState<MenuHandle>();
    }
}