using Game.Level.StateMachine.States;


namespace Game.Level.StateMachine.StatesFactory
{
    public class LevelStartStateFactory
    {
        public LevelStart CreateState(IStateSwitcher stateSwitcher)
            => new (stateSwitcher);
    }
}