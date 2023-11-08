﻿using Project.Scripts.Level.Common.Damage;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Enemies
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