using Project.Scripts.Global;
using Project.Scripts.Level.Weapons;
using System;
using UnityEngine;


namespace Project.Scripts.Level.Init
{
    public class WeaponProvider
    {
        public Weapon GetWeaponPrefab(WeaponType weaponType)
        {
            var prefabPath = weaponType switch
            {
                WeaponType.Crossbow => "Weapons/Crossbow",
                WeaponType.Catapult => "Weapons/Catapult",
                _ => throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null),
            };

            return Resources.Load<Weapon>(prefabPath);
        }
    }
}