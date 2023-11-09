using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Data;


namespace Project.Scripts.Menu.StateMachine.States.LevelSelectState
{
    public class LevelSelectFactory
    {
        private readonly LevelSelectData _selectData;

        public LevelSelectFactory(LevelSelectData selectData)
        {
            _selectData = selectData;
        }

        public LevelSelect CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _selectData);
    }
}