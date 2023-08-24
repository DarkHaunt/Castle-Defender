

namespace Game.Level.Enemies.Melee
{
    public class SimpleMelee : Melee
    {
        public override void FollowTarget(IAttackTarget attackTarget) {}

        protected override void Attack(IAttackTarget attackTarget)
        {
            attackTarget.GetDamage(_meleeAttackDamage);
        }
    }
}