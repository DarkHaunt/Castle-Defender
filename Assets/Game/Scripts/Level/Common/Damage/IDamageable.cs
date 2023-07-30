using System;


namespace Game.Level.Common
{
    public interface IDamageable
    {
        event Action OnDamage;
        event Action OnDeath;
        
        void GetDamage(float damage);
    }
}