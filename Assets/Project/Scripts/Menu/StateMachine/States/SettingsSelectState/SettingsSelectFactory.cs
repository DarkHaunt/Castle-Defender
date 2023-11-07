using Project.Scripts.Menu.Data;
using Game.Level.StateMachine;


namespace Project.Scripts.Menu.StateMachine.States.SettingsSelectState
{
    public class SettingsSelectFactory
    {
        private readonly SettingsSelectData _settingsSelectData;

        public SettingsSelectFactory(SettingsSelectData settingsSelectData)
        {
            _settingsSelectData = settingsSelectData;
        }

        public SettingsSelect CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _settingsSelectData);
    }
}