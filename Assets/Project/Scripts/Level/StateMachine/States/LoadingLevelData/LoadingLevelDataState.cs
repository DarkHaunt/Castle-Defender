using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.StateMachine.States.InitLevel;
using Project.Scripts.Level.Handling;
using Project.Scripts.Level.Debugging;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.LoadingLevelData
{
    public class LoadingLevelDataState : IState
    {
        private readonly InitializeDataProvider _initializeDataProvider;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly DebugService _debugService;


        public LoadingLevelDataState(IStateSwitcher stateSwitcher, InitializeDataProvider initializeDataProvider, DebugService debugService) 
        {
            _initializeDataProvider = initializeDataProvider;
            _stateSwitcher = stateSwitcher;
            _debugService = debugService;
        }


        public void Enter()
        {
            Debug.Log($"<color=yellow>Load Level Data</color>");
            
            _debugService.PerformDebug();
            
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