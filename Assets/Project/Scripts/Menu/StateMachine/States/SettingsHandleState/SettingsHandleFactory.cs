using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Data;

namespace Project.Scripts.Menu.StateMachine.States.SettingsHandleState
{
    public class SettingsHandleFactory
    {
        private readonly SettingsSelectData _settingsSelectData;

        public SettingsHandleFactory(SettingsSelectData settingsSelectData)
        {
            _settingsSelectData = settingsSelectData;
        }

        public SettingsHandle CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _settingsSelectData);
    }
}