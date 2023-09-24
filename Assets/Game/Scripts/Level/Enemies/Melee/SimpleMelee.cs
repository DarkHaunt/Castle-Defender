using Game.Level.Enemies.BehaviorTree;
using UnityEngine;


namespace Game.Level.Enemies.Melee
{
    public class SimpleMelee : Melee
    {
        protected override EnemyBehaviorTree CreateBehaviorTree(EnemyBehaviorData behaviorData)
            => new SimpleEnemyBehaviorTree(this, transform, behaviorData);

        public override void Move(IAttackTarget attackTarget, float timeDelta)
        {
            var targetDirection = (attackTarget.Position - (Vector2)transform.position).normalized;
            _rigidbody.AddForce(targetDirection * _speed * timeDelta);
        }

        public override void Attack(IAttackTarget attackTarget)
            => attackTarget.GetDamage(_meleeAttackDamage);

        public override void Die(float timeDelta)
        {
            throw new System.NotImplementedException();
        }
    }
}