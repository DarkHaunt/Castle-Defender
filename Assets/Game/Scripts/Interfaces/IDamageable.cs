using System;


namespace Interfaces
{
    public interface IDamageable
    {
        event Action OnDamaged;
        
        void GetDamage(float damage);
    }
}