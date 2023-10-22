using System;


namespace Game.Level.Health
{
    public interface IDamageable
    {
        event Action<HealthParamsHandler> OnHealthUpdate;
        event Action<float> OnDamage;
        event Action OnDeath;
        
        void GetDamage(float damage);
    }
}