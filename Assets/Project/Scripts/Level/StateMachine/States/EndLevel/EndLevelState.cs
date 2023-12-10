using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs;
using Project.Scripts.UI;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.EndLevel
{
    public class EndLevelState : IState
    {
        private readonly GameOverUIService _gameOverUIService;
        private readonly ConfigsProvider _configsProvider;

        public EndLevelState(ConfigsProvider configsProvider, GameOverUIService gameOverUIService)
        {
            _gameOverUIService = gameOverUIService;
            _configsProvider = configsProvider;
        }
        
        public void Enter()
        {
            _configsProvider.SaveConfigs();
            _gameOverUIService.Enable();
            Debug.Log($"<color=yellow>End Level</color>");
        }

        public void Exit()
            => _gameOverUIService.Disable();
    }
}