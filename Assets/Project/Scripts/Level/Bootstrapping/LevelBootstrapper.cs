using Game.Level.StateMachine;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.StateMachine.States.LoadingLevelData;
using UnityEngine;
using VContainer;


namespace Project.Scripts.Level.Bootstrapping
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