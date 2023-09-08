using Game.Level.StateMachine.States;
using Game.Level.StateMachine;
using Game.Common.Interfaces;
using VContainer.Unity;
using UnityEngine;
using VContainer;


namespace Game.Level.Bootstrapping
{
    public class LevelBootstrapper : MonoBehaviour, ICoroutineRunner, IInitializable
    {
        private IStateSwitcher _stateSwitcher;

        
        [Inject]
        private void Construct(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }
        
        public void Initialize()
            => _stateSwitcher.SwitchToState<DataLoadingState>();
    }
}