using Game.Level.Enemies.StateMachine.States;
using Game.Level.Enemies.StateMachine;
using Game.Level.Common.Damage;
using Game.Common.Interfaces;
using Game.Extensions;
using UnityEngine;
using System;


namespace Game.Level.Enemies
{
    public abstract class Enemy : MonoBehaviour, IEnemy, ICoroutineRunner
    {
        [Header("--- Params ---")]
        [SerializeField] private float _health;
        [SerializeField] protected float _speed;

        [Header("--- Components ---")]
        [SerializeField] private CollideAttackTarget _attackTarget;

        [Header("--- State Machine ---")]
        [SerializeField] private EnemyStateMachineData _enemyStateMachineData; 

        protected Rigidbody2D _rigidbody;
        protected EnemyStateMachine _enemyStateMachine;


        public abstract void Move(IAttackTarget attackTarget, float timeDelta);

        public abstract void Attack(IAttackTarget attackTarget);

        public abstract void Die(float timeDelta);


        public void Init(IAttackTarget enemyTarget)
        {
            _enemyStateMachine = new EnemyStateMachine(this, enemyTarget, _enemyStateMachineData);
            _attackTarget.Init(_health);
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemyStateMachine.SwitchToState<MoveState>();
        }

        public void EndBehavior()
            => _rigidbody.Deactivate();

        public void PerformBehavior(float timeDelta)
            => _enemyStateMachine.UpdateCurrentStateBehavior(timeDelta);
    }


    [Serializable]
    public struct EnemyStateMachineData
    {
        public float AttackCooldown; 
    }
}