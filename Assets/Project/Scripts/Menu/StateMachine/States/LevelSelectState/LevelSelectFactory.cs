using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs;
using Project.Scripts.Menu.Data;


namespace Project.Scripts.Menu.StateMachine.States.LevelSelectState
{
    public class LevelSelectFactory
    {
        private readonly ConfigsProvider _configsProvider;
        private readonly LevelSelectData _selectData;

        public LevelSelectFactory(ConfigsProvider configsProvider, LevelSelectData selectData)
        {
            _configsProvider = configsProvider;
            _selectData = selectData;
        }

        public LevelSelect CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _configsProvider, _selectData);
    }
}