using Game.Level.Castles;
using System;


namespace Game.Level.Common.Damage
{
    public interface IDamageable
    {
        event Action<HealthParamsHandler> OnHealthUpdate;
        event Action<float> OnDamage;
        event Action OnDeath;
        
        void GetDamage(float damage);
    }
}