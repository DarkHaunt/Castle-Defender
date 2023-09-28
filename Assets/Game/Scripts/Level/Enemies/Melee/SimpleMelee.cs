﻿using Game.Level.Enemies.BehaviorTree;
using Game.Level.Enemies.BehaviorTree.Common;
using Game.Level.Enemies.BehaviorTree.MeleeSimple;
using UnityEngine;


namespace Game.Level.Enemies.Melee
{
    public class SimpleMelee : Enemy
    {
        [SerializeField] private float _meleeAttackDamage;
        
        
        protected override EnemyBehaviorTree CreateBehaviorTree(EnemyBehaviorData behaviorData)
            => new SimpleEnemyBehaviorTree(this, transform, behaviorData);

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

        public override void DieLogic(float timeDelta)
        {
            throw new System.NotImplementedException();
        }
    }
}