using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class StartLevelState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        

        public StartLevelState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        
        public void Enter()
        {
            Debug.Log($"<color=white>Start level</color>");
            
            _stateSwitcher.SwitchToState<EndLevelState>();
        }

        public void Exit()
        {
            
        }
    }
}