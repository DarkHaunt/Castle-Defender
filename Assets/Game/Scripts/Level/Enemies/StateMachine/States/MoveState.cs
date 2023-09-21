namespace Game.Level.Enemies.StateMachine.States
{
    public class MoveState : IEnemyState
    {
        private readonly IAttackTarget _target;
        private readonly IEnemy _enemy;

        
        public MoveState(IEnemy enemy, IAttackTarget target)
        {
            _target = target;
            _enemy = enemy;
        }


        public void Enter() {}

        public void Exit() {}

        public void Tick(float timeDelta)
            => _enemy.Move(_target, timeDelta);
    }
}