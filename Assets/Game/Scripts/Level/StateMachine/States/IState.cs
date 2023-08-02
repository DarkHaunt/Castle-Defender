namespace Game.Level.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Tick();
        void Exit();
    }
}