using Game.Level.Common.Damage;
using UnityEngine;


namespace Game.Level.Enemies
{
    public interface IAttackTarget : IDamageable
    {
        void Init(float initHealth);

        void UpdateHealth();
        
        Vector2 Position { get; }
    }
}