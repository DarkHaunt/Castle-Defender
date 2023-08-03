namespace Game.Level.Common.Damage
{
    public interface IAttackHandler
    {
        void Attack(IDamageable target);
    }
}