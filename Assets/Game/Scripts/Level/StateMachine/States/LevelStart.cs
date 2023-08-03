using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class LevelStart : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        

        public LevelStart(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        
        public void Enter()
        {
            Debug.Log($"<color=white>Start level</color>");
            
            _stateSwitcher.SwitchToState<LevelEnd>();
        }

        public void Tick()
        {
        }

        public void Exit()
        {
            
        }
    }
}