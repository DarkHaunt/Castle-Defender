using Game.Level.StateMachine;
using Project.Scripts.Menu.Data;


namespace Project.Scripts.Menu.StateMachine.States.MenuHandleState
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