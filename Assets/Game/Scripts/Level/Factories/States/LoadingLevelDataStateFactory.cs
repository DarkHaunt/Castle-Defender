using Game.Level.Configs;


namespace Game.Level.StateMachine.States.Factories
{
    public class LoadingLevelDataStateFactory
    {
        private readonly IInitializeDataProvider _initializeDataProvider;


        public LoadingLevelDataStateFactory(IInitializeDataProvider initializeDataProvider)
        {
            _initializeDataProvider = initializeDataProvider;
        }


        public LoadingLevelDataState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider);
    }
}