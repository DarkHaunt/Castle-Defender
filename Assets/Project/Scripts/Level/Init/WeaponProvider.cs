using Project.Scripts.Level.Weapons;
using Project.Scripts.Global;
using UnityEngine;
using System;


namespace Project.Scripts.Configs.Game
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