using Project.Scripts.Level.Common.Damage;
using Project.Scripts.Level.Enemies.BehaviorTree.Common;
using Project.Scripts.Level.Enemies.Melee.Behavior;
using System.Threading.Tasks;
using UnityEngine;


namespace Project.Scripts.Level.Enemies.Melee
{
    public class SimpleMelee : Enemy
    {
        [SerializeField] private float _meleeAttackDamage;


        protected override EnemyBehaviorTree CreateBehaviorTree(EnemyBehaviorData behaviorData)
            => new SimpleEnemyBehaviorTree(this, behaviorData);

        public override void Move(IAttackTarget attackTarget, float timeDelta)
        {
            var targetDirection = (attackTarget.Position - (Vector2)transform.position).normalized;
            _rigidbody.AddForce(targetDirection * _speed * timeDelta);
        }

        public override void Attack(IAttackTarget attackTarget)
        {
            _rigidbody.velocity = Vector2.zero;
            attackTarget.GetDamage(_meleeAttackDamage);
        }

        protected override Task DieLogic()
        {
            gameObject.SetActive(false);

            return Task.CompletedTask;
        }
    }
}