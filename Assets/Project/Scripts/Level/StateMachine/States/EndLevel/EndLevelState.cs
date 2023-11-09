using Project.Scripts.Common.StateMachine;
using Project.Scripts.UI;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.EndLevel
{
    public class EndLevelState : IState
    {
        private readonly GameOverUIService _gameOverUIService;

        public EndLevelState(GameOverUIService gameOverUIService)
        {
            _gameOverUIService = gameOverUIService;
        }
        
        public void Enter()
        {
            _gameOverUIService.Enable();
            Debug.Log($"<color=yellow>End Level</color>");
        }

        public void Exit()
            => _gameOverUIService.Disable();
    }
}