namespace Game.Level.StateMachine.States.Factories
{
    public class StartLevelStateFactory
    {
        public StartLevelState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher);
    }
}