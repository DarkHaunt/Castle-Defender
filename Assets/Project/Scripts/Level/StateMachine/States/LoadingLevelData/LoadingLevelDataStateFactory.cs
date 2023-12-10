using Project.Scripts.Common.StateMachine;
using Project.Scripts.Level.Debugging;
using Project.Scripts.Level.Init;
using Project.Scripts.Configs;


namespace Project.Scripts.Level.StateMachine.States.LoadingLevelData
{
    public class LoadingLevelDataStateFactory
    {
        private readonly InitializeService _initializeService;
        private readonly ConfigsProvider _configsProvider;
        private readonly DebugService _debugService;


        public LoadingLevelDataStateFactory(ConfigsProvider configsProvider, InitializeService initializeService, DebugService debugService)
        {
            _initializeService = initializeService;
            _configsProvider = configsProvider;
            _debugService = debugService;
        }


        public LoadingLevelDataState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _configsProvider, _initializeService, _debugService);
    }
}