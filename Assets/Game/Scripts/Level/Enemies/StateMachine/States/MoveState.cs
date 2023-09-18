namespace Game.Level.Enemies.StateMachine.States
{
    public class MoveState : IEnemyState
    {
        private readonly IAttackTarget _moveTarget;
        private readonly IEnemy _enemy;

        
        public MoveState(IEnemy enemy, IAttackTarget moveTarget)
        {
            _moveTarget = moveTarget;
            _enemy = enemy;
        }


        public void Enter() {}

        public void Exit() {}

        public void Tick(float timeDelta)
            => _enemy.Move(_moveTarget, timeDelta);
    }
}