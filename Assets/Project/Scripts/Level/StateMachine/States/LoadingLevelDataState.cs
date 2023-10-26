using Game.Level.Services.Level;
using UnityEngine;


namespace Game.Level.StateMachine.States
{
    public class LoadingLevelDataState : IState
    {
        private readonly IInitializeDataProvider _initializeDataProvider;
        private readonly IStateSwitcher _stateSwitcher;


        public LoadingLevelDataState(IStateSwitcher stateSwitcher, IInitializeDataProvider initializeDataProvider) 
        {
            _initializeDataProvider = initializeDataProvider;
            _stateSwitcher = stateSwitcher;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Load Level Data</color>");
            
            _initializeDataProvider.OnInitializeDataReady += SwitchToLevelInitialize;
            
            _initializeDataProvider.LoadInitializeData();
        }

        public void Exit()
        {
            _initializeDataProvider.OnInitializeDataReady -= SwitchToLevelInitialize;
        }

        private void SwitchToLevelInitialize()
            => _stateSwitcher.SwitchToState<InitLevelState>();
    }
}