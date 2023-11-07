using Game.Level.StateMachine.States;
using Game.Level.Services.Debugging;
using Game.Level.StateMachine;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelBootstrapper : MonoBehaviour
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

            _stateSwitcher.SwitchToState<LoadingLevelDataState>();
        }
    }
}