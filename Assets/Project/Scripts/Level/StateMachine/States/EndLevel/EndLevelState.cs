using Project.Scripts.Common.StateMachine;
using Project.Scripts.Configs;
using Project.Scripts.UI;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.EndLevel
{
    public class EndLevelState : IState
    {
        private readonly GameOverView _gameOverView;
        private readonly ConfigsProvider _configsProvider;

        public EndLevelState(ConfigsProvider configsProvider, GameOverView gameOverView)
        {
            _gameOverView = gameOverView;
            _configsProvider = configsProvider;
        }
        
        public void Enter()
        {
            _configsProvider.SaveConfigs();
            _gameOverView.Enable();
            Debug.Log($"<color=yellow>End Level</color>");
        }

        public void Exit()
            => _gameOverView.Disable();
    }
}