using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Services;
using Project.Scripts.Menu.Data;
using Project.Scripts.Consume;

namespace Project.Scripts.Menu.StateMachine.States.ShopHandleState
{
    public class ShopHandleFactory
    {
        private readonly CoinsHandleService _coinsHandleService;
        private readonly ShopService _shopService;
        private readonly ShopData _shopData;

        public ShopHandleFactory(ShopData shopData, ShopService shopService, CoinsHandleService coinsHandleService)
        {
            _coinsHandleService = coinsHandleService;
            _shopService = shopService;
            _shopData = shopData;
        }

        public ShopHandle CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _coinsHandleService, _shopService, _shopData);
    }
}