using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.Handling;


namespace Project.Scripts.Level.StateMachine.States.LoadingLevelData
{
    public class LoadingLevelDataStateFactory
    {
        private readonly InitializeDataProvider _initializeDataProvider;
        private readonly DebugService _debugService;


        public LoadingLevelDataStateFactory(InitializeDataProvider initializeDataProvider, DebugService debugService)
        {
            _initializeDataProvider = initializeDataProvider;
            _debugService = debugService;
        }


        public LoadingLevelDataState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider, _debugService);
    }
}