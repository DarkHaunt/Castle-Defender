using Game.Level.StateMachine.States;


namespace Game.Level.StateMachine.StatesFactory
{
    public class LevelEndStateFactory
    {
        public LevelEnd CreateState()
            => new ();
    }
}