namespace Project.Scripts.Common.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitchToState<TState>() where TState : IState;
    }
}