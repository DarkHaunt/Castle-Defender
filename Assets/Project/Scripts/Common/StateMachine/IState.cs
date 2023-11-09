namespace Project.Scripts.Common.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}