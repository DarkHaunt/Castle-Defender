using Game.Common.Interfaces;
using UnityEngine;


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
            _attackTarget = attackTarget;
            _cooldown = cooldown;
            _enemy = enemy;
        }


        public void Enter()
        {
            Debug.Log($"<color=red>Log Entered Attack</color>");
            RefreshPassedTime();
        }

        public void Exit() {}

        public void Tick(float timeDelta)
        {
            _passedTime += timeDelta;
            
            if (_passedTime > _cooldown)
            {
                _enemy.Attack(_attackTarget);
                _passedTime = 0f;
            }
        }

        private void RefreshPassedTime()
            => _passedTime = _cooldown;
    }
}