using UnityEngine;


namespace Game.Level.Enemies.Melee
{
    public class SimpleMelee : Melee
    {
        public override void Move(IAttackTarget attackTarget)
        {
            var targetDirection = attackTarget.Position - (Vector2)transform.position;
            
        }

        protected override void Attack(IAttackTarget attackTarget)
        {
            attackTarget.GetDamage(_meleeAttackDamage);
        }
    }
}