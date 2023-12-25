using Project.Scripts.Common.StateMachine;
using Project.Scripts.Menu.Data;
using Project.Scripts.Menu.StateMachine.States.MenuHandleState;

namespace Project.Scripts.Menu.StateMachine.States.SettingsHandleState
{
    public class SettingsHandle : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly SettingsSelectData _settingsSelectData;

        public SettingsHandle(IStateSwitcher stateSwitcher, SettingsSelectData settingsSelectData)
        {
            _stateSwitcher = stateSwitcher;
            _settingsSelectData = settingsSelectData;
        }
        
        public void Enter()
        {
            _settingsSelectData.SettingsCanvas.gameObject.SetActive(true);
            
            _settingsSelectData.CloseButton.onClick.AddListener(SwitchToMenu);
        }

        public void Exit()
        {
            _settingsSelectData.SettingsCanvas.gameObject.SetActive(false);
            
            _settingsSelectData.CloseButton.onClick.RemoveListener(SwitchToMenu);
        }

        private void SwitchToMenu()
            => _stateSwitcher.SwitchToState<MenuHandle>();
    }
}