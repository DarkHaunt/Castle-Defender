using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class EndLevelState : IState
    {
        public void Enter()
        {
            Debug.Log($"<color=yellow>End Level</color>");
        }

        public void Exit() {}
    }
}