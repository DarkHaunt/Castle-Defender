using Game.Level.Configs;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class DataLoadingState : IState
    {
        private readonly ILevelConfigProvider _levelConfigProvider;
        private readonly IStateSwitcher _stateSwitcher;
        
        
        public DataLoadingState(IStateSwitcher stateSwitcher, ILevelConfigProvider levelConfigProvider)
        {
            _levelConfigProvider = levelConfigProvider;
            _stateSwitcher = stateSwitcher;
        }
        
        
        public void Enter()
        {
            Debug.Log($"<color=yellow>Load Data</color>");
            
            _levelConfigProvider.OnLevelConfigsReady += SwitchToStartLevelState;
            
            _levelConfigProvider.RequestLevelConfig();
        }

        public void Exit()
        {
            _levelConfigProvider.OnLevelConfigsReady -= SwitchToStartLevelState;
        }

        private void SwitchToStartLevelState()
            => _stateSwitcher.SwitchToState<StartLevelState>();
    }
}