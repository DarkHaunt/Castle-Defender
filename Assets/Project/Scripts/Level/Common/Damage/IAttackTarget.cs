using UnityEngine;


namespace Project.Scripts.Level.Common.Damage
{
    public interface IAttackTarget : IDamageable
    {
        void Init(float initHealth);

        void UpdateHealth();
        
        Vector2 Position { get; }
    }
}