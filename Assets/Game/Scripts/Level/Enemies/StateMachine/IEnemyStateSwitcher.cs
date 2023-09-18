using Game.Level.Enemies.StateMachine.States;


namespace Game.Level.Enemies.StateMachine
{
    public interface IEnemyStateSwitcher
    {
        void SwitchToState<TState>() where TState : IEnemyState;
    }
}