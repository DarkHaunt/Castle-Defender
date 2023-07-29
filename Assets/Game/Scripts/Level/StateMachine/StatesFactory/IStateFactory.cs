using Game.Level.StateMachine.States;


namespace Game.Level.StateMachine.StatesFactory
{
    public interface IStateFactory
    {
        IState CreateState(State state);
    }
}