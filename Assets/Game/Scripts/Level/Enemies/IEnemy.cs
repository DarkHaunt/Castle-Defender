using Game.Level.Health;
using UnityEngine;
using System;


namespace Game.Level.Enemies
{
    public interface IEnemy
    {
        event Action<IEnemy> OnDeath;
        
        Vector2 CurrentPosition { get; }
        
        void Move(IAttackTarget attackTarget, float timeDelta);
        void Attack(IAttackTarget attackTarget);
        void GetDamage(float damage);
    }
}