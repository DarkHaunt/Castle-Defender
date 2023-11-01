using Game.UI.Common;
using UnityEngine;


namespace Game.Level.StateMachine.States
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