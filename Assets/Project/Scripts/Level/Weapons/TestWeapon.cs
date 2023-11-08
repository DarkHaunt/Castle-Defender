using Project.Scripts.Level.Enemies;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Weapons
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