using Game.Level.StateMachine;
using Project.Scripts.Level.Handling;


namespace Project.Scripts.Level.StateMachine.States.LoadingLevelData
{
    public class LoadingLevelDataStateFactory
    {
        private readonly InitializeDataProvider _initializeDataProvider;


        public LoadingLevelDataStateFactory(InitializeDataProvider initializeDataProvider)
        {
            _initializeDataProvider = initializeDataProvider;
        }


        public LoadingLevelDataState CreateState(IStateSwitcher stateSwitcher)
            => new(stateSwitcher, _initializeDataProvider);
    }
}