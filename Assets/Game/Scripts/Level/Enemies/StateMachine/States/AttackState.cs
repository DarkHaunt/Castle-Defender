using Game.Common.Interfaces;


namespace Game.Level.Enemies.StateMachine.States
{
    public class AttackState : IEnemyState
    {
        private readonly IAttackTarget _attackTarget;
        private readonly float _cooldown;
        private readonly IEnemy _enemy;

        private float _passedTime;


        public AttackState(IEnemy enemy, IAttackTarget attackTarget, float cooldown)
        {
            _enemy = enemy;
            _attackTarget = attackTarget;
            _cooldown = cooldown;
        }


        public void Enter()
            => RefreshPassedTime();

        public void Exit() {}

        public void Tick(float timeDelta)
        {
            if (_passedTime > _cooldown)
            {
                _enemy.Attack(_attackTarget);
                RefreshPassedTime();
            }
        }

        private void RefreshPassedTime()
            => _passedTime = 0f;
    }
}