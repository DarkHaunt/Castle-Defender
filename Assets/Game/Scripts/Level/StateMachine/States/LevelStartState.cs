using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class LevelStartState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        

        public LevelStartState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        
        public void Enter()
        {
            Debug.Log($"<color=white>Start level</color>");
            
            _stateSwitcher.SwitchToState<LevelEndState>();
        }

        public void Exit()
        {
            
        }
    }
}