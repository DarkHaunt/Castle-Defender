using Game.Level.StateMachine.States;


namespace Game.Level.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitchToState(State state);
    }
}