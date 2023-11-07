using Project.Scripts.Menu.Data;
using Game.Level.StateMachine;


namespace Project.Scripts.Menu.StateMachine.State
{
    public class MenuHandleFactory
    {
        private readonly MenuData _menuData;

        public MenuHandleFactory(MenuData menuData)
        {
            _menuData = menuData;
        }

        public MenuHandle CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _menuData);
    }
}