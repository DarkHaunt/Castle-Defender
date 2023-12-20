using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Data;

namespace Project.Scripts.Menu.StateMachine.States.ShopHandleState
{
    public class ShopHandleFactory
    {
        private readonly ShopData _shopData;

        public ShopHandleFactory(ShopData shopData)
        {
            _shopData = shopData;
        }

        public ShopHandle CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _shopData);
    }
}