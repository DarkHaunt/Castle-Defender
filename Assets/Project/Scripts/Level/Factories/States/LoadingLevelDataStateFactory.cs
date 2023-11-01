using Game.Level.StateMachine.States;
using Game.Level.Services.Level;
using Game.Level.StateMachine;


namespace Game.Level.Factories.States
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