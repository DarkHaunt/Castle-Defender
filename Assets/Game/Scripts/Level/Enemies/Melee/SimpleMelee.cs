using UnityEngine;


namespace Game.Level.Enemies.Melee
{
    public class SimpleMelee : Melee
    {
        public override void Move(IAttackTarget attackTarget, float timeDelta)
        {
            var targetDirection = attackTarget.Position - (Vector2)transform.position;
            var position = _rigidbody.position + targetDirection * _speed * timeDelta;
            
            _rigidbody.MovePosition(position);
        }

        public override void Attack(IAttackTarget attackTarget)
            => attackTarget.GetDamage(_meleeAttackDamage);

        public override void Die(float timeDelta)
        {
            throw new System.NotImplementedException();
        }
    }
}