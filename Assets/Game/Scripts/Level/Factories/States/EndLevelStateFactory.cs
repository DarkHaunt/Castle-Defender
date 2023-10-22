using Game.Level.StateMachine.States;


namespace Game.Level.Factories.States
{
    public class EndLevelStateFactory
    {
        public EndLevelState CreateState()
            => new ();
    }
}