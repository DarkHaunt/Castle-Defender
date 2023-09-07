﻿using UnityEngine;


namespace Game.Level.Enemies.Melee
{
    public abstract class Melee : Enemy
    {
        [SerializeField] protected float _meleeAttackDamage;
        
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IAttackTarget target))
                Attack(target);
        }
    }
}