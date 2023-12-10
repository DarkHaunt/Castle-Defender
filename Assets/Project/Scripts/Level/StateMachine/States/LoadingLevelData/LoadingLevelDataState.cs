using Project.Scripts.Level.StateMachine.States.InitLevel;
using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.Init;
using Project.Scripts.Configs;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.LoadingLevelData
{
    public class LoadingLevelDataState : IState
    {
        private readonly InitializeService _initializeService;
        private readonly ConfigsProvider _configsProvider;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly DebugService _debugService;


        public LoadingLevelDataState(IStateSwitcher stateSwitcher, ConfigsProvider configsProvider, 
            InitializeService initializeService, DebugService debugService) 
        {
            _initializeService = initializeService;
            _configsProvider = configsProvider;
            _stateSwitcher = stateSwitcher;
            _debugService = debugService;
        }


        public void Enter()
        {
            _debugService.PerformDebug();
            _configsProvider.LoadConfigs();
            
            _initializeService.OnInitializeDataReady += SwitchToLevelInitialize;
            
            _initializeService.LoadInitializeData();
            
            Debug.Log($"<color=yellow>Load Level Data</color>");
        }

        public void Exit()
            => _initializeService.OnInitializeDataReady -= SwitchToLevelInitialize;

        private void SwitchToLevelInitialize()
            => _stateSwitcher.SwitchToState<InitLevelState>();
    }
}