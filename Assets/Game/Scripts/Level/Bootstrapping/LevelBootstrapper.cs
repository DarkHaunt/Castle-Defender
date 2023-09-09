using Game.Level.StateMachine.States;
using Game.Level.Services.Debugging;
using Game.Level.StateMachine;
using Game.Common.Interfaces;
using UnityEngine;
using VContainer;
using Game.Test;


namespace Game.Level.Bootstrapping
{
    public class LevelBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ForcibleLevelConfigSetter _configSetter;
        [SerializeField] private ForcibleGameDataSetter _gameDataSetter;
        
        private IStateSwitcher _stateSwitcher;

        
        [Inject]
        private void Construct(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        private void Awake()
        {
            _configSetter.ForceSetCachedConfig();
            _gameDataSetter.ForceSetCachedPlayerProgressData();
            
            _stateSwitcher.SwitchToState<DataLoadingState>();
        }
    }
}