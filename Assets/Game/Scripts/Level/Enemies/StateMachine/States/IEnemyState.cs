using Game.Level.StateMachine.States;


namespace Game.Level.Enemies.StateMachine.States
{
    public interface IEnemyState : IState
    {
        void Tick(float timeDelta);
    }
}