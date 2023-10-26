using Game.Level.Enemies;
using UnityEngine;
using System;


namespace Game.Level.Weapons
{
    public class TestWeapon : Weapon
    {
        public override void Attack(IEnemy target, Action onComplete)
        {
            target.GetDamage(_damage);
            
            onComplete?.Invoke();
        }

        public override void Reload()
        {
            Debug.Log($"<color=white>Reloaded</color>");
        }
    }
}