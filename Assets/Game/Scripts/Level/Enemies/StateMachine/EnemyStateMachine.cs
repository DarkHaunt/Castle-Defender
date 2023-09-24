using Game.Level.Enemies.StateMachine.States;
using System.Collections.Generic;
using System;


namespace Game.Level.Enemies.StateMachine
{
    public class EnemyStateMachine : IEnemyStateSwitcher
    {
        private readonly Dictionary<Type, IEnemyState> _states;
        private IEnemyState _currentState;


        public EnemyStateMachine(IEnemy enemy, IAttackTarget enemyTarget, EnemyBehaviorData enemyBehaviorData)
        {
            _states = new Dictionary<Type, IEnemyState>()
            {
                [typeof(AttackState)] = new AttackState(enemy, enemyTarget, enemyBehaviorData.AttackCooldown),
                [typeof(MoveState)] = new MoveState(enemy, enemyTarget),
                [typeof(DeathState)] = new DeathState(),
            };
        }


        public void SwitchToState<TState>() where TState : IEnemyState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];

            _currentState!.Enter();
        }

        public void UpdateCurrentStateBehavior(float timeDelta)
            => _currentState?.Tick(timeDelta);
    }
}