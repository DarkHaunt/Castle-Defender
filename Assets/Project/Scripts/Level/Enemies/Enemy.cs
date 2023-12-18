using Project.Scripts.Level.Enemies.BehaviorTree.Common;
using Project.Scripts.Level.Common.Damage;
using Project.Scripts.Extensions;
using System.Threading.Tasks;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Enemies
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<Enemy> OnDeactivate;
        public event Action<IEnemy> OnDeath;

        [Header("--- Params ---")]
        [SerializeField] private int _id;
        [SerializeField] private int _reward;
        [SerializeField] private float _health;
        [SerializeField] protected float _speed;

        [Header("--- Components ---")]
        [SerializeField] private CollideAttackTarget _attackTarget;

        [Header("--- State Machine ---")]
        [SerializeField] private EnemyBehaviorData _enemyBehaviorData;

        protected Rigidbody2D _rigidbody;
        private EnemyBehaviorTree _behaviorTree;

        public Vector3 Position => _rigidbody.position;
        public int CoinsReward => _reward;
        public int Id => _id;

        
        protected abstract EnemyBehaviorTree CreateBehaviorTree(EnemyBehaviorData behaviorData);
        public abstract void Move(Vector2 attackTarget, float timeDelta);
        public abstract void Attack(IAttackTarget attackTarget);
        protected abstract Task DieLogic();


        private void Awake()
            => _rigidbody = GetComponent<Rigidbody2D>();

        private void OnEnable()
            => _attackTarget.OnDeath += Die;

        private void OnDisable()
            => _attackTarget.OnDeath -= Die;

        public void Init()
        {
            _behaviorTree = CreateBehaviorTree(_enemyBehaviorData);
            _behaviorTree.Construct();
            
            _attackTarget.Init(_health);
            _attackTarget.Enable();
        }

        public void GetDamage(float damage)
            => _attackTarget.GetDamage(damage);

        public void EndBehavior()
            => _rigidbody.Deactivate();

        public void PerformBehavior(float timeDelta)
            => _behaviorTree?.UpdateTreeBehavior(timeDelta);

        private async void Die()
        {
            OnDeath?.Invoke(this);

            _attackTarget.Disable();

            await DieLogic();
            
            OnDeactivate?.Invoke(this);
        }
    }


    [Serializable]
    public class EnemyBehaviorData
    {
        public Vector2 SearchDirection;
        public float AttackCooldown;
        public float AttackRadius;
    }
}