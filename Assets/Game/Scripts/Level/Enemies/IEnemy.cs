﻿using Game.Level.Common.Damage;


namespace Game.Level.Enemies
{
    public interface IEnemy : IDamageable
    {
        void UpdateBehavior(IAttackTarget enemiesTarget);
    }
}