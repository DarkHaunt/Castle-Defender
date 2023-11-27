using Project.Scripts.Level.Common.Damage;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Enemies
{
    public interface IEnemy
    {
        event Action<IEnemy> OnDeath;
        
        Vector3 Position { get; }
        
        void Move(IAttackTarget attackTarget, float timeDelta);
        void Attack(IAttackTarget attackTarget);
        void GetDamage(float damage);
    }
}