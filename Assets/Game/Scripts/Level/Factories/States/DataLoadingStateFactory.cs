using Game.Level.Configs;


namespace Game.Level.StateMachine.States.Factories
{
    public class DataLoadingStateFactory
    {
        private readonly ILevelConfigProvider _levelConfigProvider;
        

        public DataLoadingStateFactory(ILevelConfigProvider levelConfigProvider)
        {
            _levelConfigProvider = levelConfigProvider;
        }
        
        
        public DataLoadingState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher, _levelConfigProvider);
    }
}