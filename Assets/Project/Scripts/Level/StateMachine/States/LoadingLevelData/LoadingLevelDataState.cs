using Game.Level.StateMachine;
using Game.Level.StateMachine.States;
using Project.Scripts.Level.Handling;
using Project.Scripts.Level.StateMachine.States.InitLevel;
using UnityEngine;


namespace Project.Scripts.Level.StateMachine.States.LoadingLevelData
{
    public class LoadingLevelDataState : IState
    {
        private readonly InitializeDataProvider _initializeDataProvider;
        private readonly IStateSwitcher _stateSwitcher;


        public LoadingLevelDataState(IStateSwitcher stateSwitcher, InitializeDataProvider initializeDataProvider) 
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