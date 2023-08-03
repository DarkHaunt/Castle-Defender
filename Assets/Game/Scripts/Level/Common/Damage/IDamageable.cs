using System;


namespace Game.Level.Common.Damage
{
    public interface IDamageable
    {
        event Action OnDamage;
        event Action OnDeath;
        
        void GetDamage(float damage);
    }
}