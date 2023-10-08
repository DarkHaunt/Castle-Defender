using Game.Level.Enemies.BehaviorTree.MeleeSimple;
using Game.Level.Enemies.BehaviorTree.Common;
using UnityEngine;


namespace Game.Level.Enemies.Melee
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

        protected override void DieLogic(float timeDelta)
        {
            throw new System.NotImplementedException();
        }
    }
}