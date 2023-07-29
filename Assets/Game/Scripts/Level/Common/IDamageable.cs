using System;


namespace Game.Level.Common
{
    public interface IDamageable
    {
        event Action OnDamaged;
        
        void GetDamage(float damage);
    }
}