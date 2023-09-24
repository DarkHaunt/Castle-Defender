using Game.Level.Enemies.BehaviorTree;
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
        [SerializeField] private EnemyBehaviorData _enemyBehaviorData; 

        protected Rigidbody2D _rigidbody;
        private EnemyBehaviorTree _behaviorTree;


        protected abstract EnemyBehaviorTree CreateBehaviorTree(EnemyBehaviorData behaviorData);
        public abstract void Move(IAttackTarget attackTarget, float timeDelta);
        public abstract void Attack(IAttackTarget attackTarget);
        public abstract void Die(float timeDelta);


        public void Init()
        {
            _attackTarget.Init(_health);
            _rigidbody = GetComponent<Rigidbody2D>();

            _behaviorTree = CreateBehaviorTree(_enemyBehaviorData);
            _behaviorTree.Construct();
        }

        public void EndBehavior()
            => _rigidbody.Deactivate();

        public void PerformBehavior(float timeDelta)
            => _behaviorTree.UpdateTreeBehavior(timeDelta);
    }


    [Serializable]
    public class EnemyBehaviorData
    {
        public Vector2 SearchDirection; 
        public float AttackCooldown; 
        public float AttackRadius; 
    }
}