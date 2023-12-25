using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs;
using Project.Scripts.Menu.Data;
using Project.Scripts.Consume;

namespace Project.Scripts.Menu.StateMachine.States.ShopHandleState
{
    public class ShopHandleFactory
    {
        private readonly CoinsHandleService _coinsHandleService;
        private readonly ConfigsProvider _configsProvider;
        private readonly ShopData _shopData;

        public ShopHandleFactory(ShopData shopData, ConfigsProvider configsProvider, CoinsHandleService coinsHandleService)
        {
            _coinsHandleService = coinsHandleService;
            _configsProvider = configsProvider;
            _shopData = shopData;
        }

        public ShopHandle CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _configsProvider, _coinsHandleService, _shopData);
    }
}