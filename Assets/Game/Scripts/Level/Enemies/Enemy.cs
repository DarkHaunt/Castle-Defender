using Game.Level.Enemies.StateMachine.States;
using Game.Level.Enemies.StateMachine;
using Game.Level.Common.Damage;
using Game.Common.Interfaces;
using UnityEngine;
using System;


namespace Game.Level.Enemies
{
    public abstract class Enemy : MonoBehaviour, IEnemy, ICoroutineRunner
    {
        public event Action<HealthParamsHandler> OnHealthUpdate;
        public event Action<float> OnDamage;
        public event Action OnDeath;

        [SerializeField] private float _health;
        [SerializeField] protected float _speed;

        [Header("--- State Machine ---")]
        [SerializeField] private EnemyStateMachineData _enemyStateMachineData; 

        protected Rigidbody2D _rigidbody;
        protected EnemyStateMachine _enemyStateMachine;
        private HealthParamsHandler _healthParamsHandler;


        public abstract void Move(IAttackTarget attackTarget, float timeDelta);
        public abstract void Attack(IAttackTarget attackTarget);
        public abstract void Die(float timeDelta);


        public void Init(IAttackTarget enemyTarget)
        {
            _enemyStateMachine = new EnemyStateMachine(this, enemyTarget, _enemyStateMachineData);
            _healthParamsHandler = new HealthParamsHandler(_health);

            _rigidbody = GetComponent<Rigidbody2D>();
            
            _enemyStateMachine.SwitchToState<MoveState>();
        }

        public void GetDamage(float damage)
        {
            _healthParamsHandler.DecreaseHealthBy(damage);
            
            OnDamage?.Invoke(damage);
            OnHealthUpdate?.Invoke(_healthParamsHandler);
            
            if (_healthParamsHandler.IsCurrentHealthZero())
                OnDeath?.Invoke();
        }

        public void PerformBehavior(float timeDelta)
            => _enemyStateMachine.UpdateCurrentStateBehavior(timeDelta);
    }


    [Serializable]
    public struct EnemyStateMachineData
    {
        public float AttackCooldown; 
    }
}