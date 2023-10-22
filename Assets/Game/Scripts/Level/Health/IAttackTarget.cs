using UnityEngine;


namespace Game.Level.Health
{
    public interface IAttackTarget : IDamageable
    {
        void Init(float initHealth);

        void UpdateHealth();
        
        Vector2 Position { get; }
    }
}