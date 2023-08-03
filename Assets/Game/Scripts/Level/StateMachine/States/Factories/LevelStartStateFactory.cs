namespace Game.Level.StateMachine.States.Factories
{
    public class LevelStartStateFactory
    {
        public LevelStartState CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher);
    }
}