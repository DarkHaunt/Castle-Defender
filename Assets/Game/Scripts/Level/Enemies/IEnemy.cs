using Game.Level.Common.Damage;


namespace Game.Level.Enemies
{
    public interface IEnemy : IDamageable
    {
        void PerformBehavior(float timeDelta);

        void Move(IAttackTarget attackTarget, float timeDelta);
        void Attack(IAttackTarget attackTarget);
        void Die(float timeDelta);
    }
}