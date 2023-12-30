using Project.Scripts.Level.Weapons;
using Project.Scripts.Configs.Game;
using Project.Scripts.Global;
using UnityEngine;
using System;


namespace Project.Scripts.Level.Init
{
    public class WeaponProvider
    {
        public Weapon[] LoadWeapons(IPlayerConfig playerConfig)
        {
            var weapons = new Weapon[playerConfig.AvailableWeapons.Length];

            for (int i = 0; i < weapons.Length; i++)
            {
                var type = playerConfig.AvailableWeapons[i];
                weapons[i] = GetWeaponPrefab(type);
            }

            return weapons;
        }

        private Weapon GetWeaponPrefab(WeaponType weaponType)
        {
            var prefabPath = weaponType switch
            {
                WeaponType.Crossbow => "Weapons/Crossbow",
                WeaponType.Cannon => "Weapons/Catapult",
                _ => throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null),
            };

            return Resources.Load<Weapon>(prefabPath);
        }
    }
}