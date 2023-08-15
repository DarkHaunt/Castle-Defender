using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class EndLevelState : IState
    {
        public void Enter()
        {
            Debug.Log($"<color=white>End level</color>");
        }

        public void Exit()
        {
        }
    }
}